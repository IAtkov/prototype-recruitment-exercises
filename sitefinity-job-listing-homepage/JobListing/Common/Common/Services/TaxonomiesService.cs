using System;
using System.Collections.Generic;
using System.Linq;
using Common.Services.Interfaces;
using Telerik.Sitefinity.Taxonomies;
using Telerik.Sitefinity.Taxonomies.Model;

namespace Common.Services
{
    public class TaxonomiesService : ITaxonomiesService
    {
        private TaxonomyManager manager;

        public TaxonomiesService()
        {
            manager = TaxonomyManager.GetManager();
        }

        public IList<string> GetTitlesFromFlatTaxonomy(string taxonomyName)
        {
            var result = new List<string>();
            if (string.IsNullOrWhiteSpace(taxonomyName))
            {
                return result;
            }

            var taxonomy = GetFlatTaxonomy(taxonomyName);
            if (taxonomy != null)
            {
                result = taxonomy.Taxa.Select(t => t.Title.ToString()).ToList();
            }

            return result;
        }

        public ITaxon GetTaxonFromFlatTaxonomy(string taxonomyName, string taxaTitle)
        {
            if (string.IsNullOrWhiteSpace(taxonomyName))
            {
                return null;
            }

            var taxonomy = GetFlatTaxonomy(taxonomyName);
            if (taxonomy != null)
            {
                var taxon = taxonomy.Taxa.Where(t => t.Title == taxaTitle).FirstOrDefault();
                return taxon;
            }

            return null;
        }

        private FlatTaxonomy GetFlatTaxonomy(string taxonomyName)
        {
            var taxonomy = manager.GetTaxonomies<FlatTaxonomy>().Where(t => t.Name == taxonomyName).FirstOrDefault();
            return taxonomy;
        }

        public string GetTaxonTitleById(Guid id)
        {
            var taxon = manager.GetTaxon(id);
            if (taxon != null)
            {
                return taxon.Title;
            }

            return "";
        }
    }
}
