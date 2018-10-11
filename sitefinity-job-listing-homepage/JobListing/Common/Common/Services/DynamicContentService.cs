using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Services.Interfaces;
using Telerik.Sitefinity.DynamicModules;
using Telerik.Sitefinity.DynamicModules.Model;
using Telerik.Sitefinity.GenericContent.Model;
using Telerik.Sitefinity.Model;
using Telerik.Sitefinity.Utilities.TypeConverters;

namespace Common.Services
{
    public class DynamicContentService : IDynamicContentService
    {
        private DynamicModuleManager manager;

        public DynamicContentService()
        {
        }

        public IQueryable<DynamicContent> RetrieveCollectionOfLiveData(string typeName, string providerName = null, bool reinitializeManager = false)
        {
            InitializeManager(providerName, reinitializeManager);
            Type type = TypeResolutionService.ResolveType(typeName);

            if (type == null)
            {
                throw new ArgumentNullException("type does not exists");
            }

            var data = manager.GetDataItems(type).Where(d => d.Status == ContentLifecycleStatus.Live && d.Visible == true);

            return data;
        }

        public IQueryable<DynamicContent> GetItemsSuccesors(DynamicContent parent, string childItemType, string providerName = null, bool reinitializeManager = false)
        {
            InitializeManager(providerName, reinitializeManager);
            Type type = TypeResolutionService.ResolveType(childItemType);

            if (type == null)
            {
                throw new ArgumentNullException("ChildItemType does not exists");
            }

            IQueryable<DynamicContent> itemSuccesors = manager.GetItemSuccessors(parent, type).Where(d => d.Status == ContentLifecycleStatus.Live && d.Visible == true);

            return itemSuccesors;
        }

        private void InitializeManager(string providerName, bool reinitializeManager)
        {
            if (reinitializeManager == true || manager == null)
            {
                if (string.IsNullOrWhiteSpace(providerName))
                {
                    manager = DynamicModuleManager.GetManager();
                }
                else
                {
                    manager = DynamicModuleManager.GetManager(providerName);
                }
            }
        }
    }
}
