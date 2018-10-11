using System;
using System.Collections.Generic;
using Telerik.Sitefinity.Taxonomies.Model;

namespace Common.Services.Interfaces
{
    public interface ITaxonomiesService
    {
        string GetTaxonTitleById(Guid id);

        IList<string> GetTitlesFromFlatTaxonomy(string taxonomyName);

        ITaxon GetTaxonFromFlatTaxonomy(string taxonomyName, string taxaTitle);
    }
}
