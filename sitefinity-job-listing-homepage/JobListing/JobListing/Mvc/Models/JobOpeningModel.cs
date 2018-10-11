using System;
using System.Linq;
using Common.Constants;
using Common.Models;
using Common.Services.Interfaces;
using JobListing.Constants;
using Telerik.Sitefinity.Data.Linq.Dynamic;
using Telerik.Sitefinity.Model;

namespace JobListing.Mvc.Models
{
    public class JobOpeningModel : CommonListModel
    {
        private readonly ITaxonomiesService taxonomiesService;

        public JobOpeningModel(IDynamicContentService dynamicContentService, ITaxonomiesService taxonomiesService)
          : base(dynamicContentService, ContentTypes.JobOpeningType)
        {
            this.taxonomiesService = taxonomiesService;
        }

        public string TypeOfJobFilter { get; set; } = CommonConstants.All;

        public string NationalityFilter { get; set; }

        public string GenderFilter { get; set; }

        public int ItemsCount { get; set; }

        public int DateFilter { get; set; } = -1;

        protected override IQueryable<IDataItem> GetItemsQuery()
        {
            var query =  DynamicContent.RetrieveCollectionOfLiveData(ItemType);

            if (!string.IsNullOrWhiteSpace(TypeOfJobFilter) && TypeOfJobFilter.ToLower() != CommonConstants.All)
            {
                var taxon = taxonomiesService.GetTaxonFromFlatTaxonomy(TaxonomyConstants.JobTypes, TypeOfJobFilter);
                if (taxon != null)
                {
                    query = query.Where(TaxonomyConstants.JobTypes + ".Contains((" + taxon.Id.ToString() + "))");
                }
            }
            if (!string.IsNullOrWhiteSpace(NationalityFilter) && NationalityFilter.ToLower() != CommonConstants.All)
            {
                var taxon = taxonomiesService.GetTaxonFromFlatTaxonomy(TaxonomyConstants.Countries, NationalityFilter);
                if (taxon != null)
                {
                    query = query.Where(TaxonomyConstants.Countries + ".Contains((" + taxon.Id.ToString() + "))");
                }
            }
            if (!string.IsNullOrWhiteSpace(GenderFilter) && GenderFilter.ToLower() != CommonConstants.All)
            {
                query = query.Where("Gender = \"" + GenderFilter + "\"");
            }
            if (DateFilter != -1)
            {
                DateFilter = -DateFilter;
                var date = new DateTime(DateTime.UtcNow.Year, DateTime.UtcNow.Month, DateTime.UtcNow.Day, 0, 0, 0).AddDays(DateFilter);
                query = query.Where(t => t.DateCreated >= date);
            }

            ItemsCount = query.Count();

            return query;
        }
    }
}