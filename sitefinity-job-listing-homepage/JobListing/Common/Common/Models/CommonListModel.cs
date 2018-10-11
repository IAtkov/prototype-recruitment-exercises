using System;
using System.Linq;
using Common.Services.Interfaces;
using Telerik.Sitefinity.DynamicModules.Model;
using Telerik.Sitefinity.Frontend.Mvc.Models;
using Telerik.Sitefinity.Model;
using Telerik.Sitefinity.Utilities.TypeConverters;

namespace Common.Models
{
    public class CommonListModel : ContentModelBase
    {
        public CommonListModel(IDynamicContentService dynamicContent, string itemType)
        {
            DynamicContent = dynamicContent;
            ItemType = itemType;
            this.ContentType = TypeResolutionService.ResolveType(ItemType);
            if (this.ProviderName == null)
            {
                this.ProviderName = GetManager().Provider.Name;
            }
        }

        public string ItemType { get; set; }

        public IDynamicContentService DynamicContent { get; private set; }

        protected override IQueryable<IDataItem> GetItemsQuery()
        {
            return DynamicContent.RetrieveCollectionOfLiveData(ItemType);
        }

        public virtual ContentListViewModel CreateListViewModelByParent(DynamicContent parentItem, int page)
        {
            if (page < 1)
            {
                throw new ArgumentException("'page' argument has to be at least 1.", "page");
            }

            var query = DynamicContent.GetItemsSuccesors(parentItem, ItemType);
            if (query == null)
            {
                return this.CreateListViewModelInstance();
            }

            var viewModel = this.CreateListViewModelInstance();
            this.PopulateListViewModel(page, query, viewModel);

            return viewModel;
        }
    }
}
