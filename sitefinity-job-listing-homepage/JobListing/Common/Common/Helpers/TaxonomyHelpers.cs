using Telerik.Sitefinity.Frontend.Mvc.Helpers;
using Telerik.Sitefinity.Utilities.TypeConverters;

namespace Common.Helpers
{
    public static class TaxonomyHelpers
    {
        public static string GetTaxonomyFields(string contentType)
        {
            var type = TypeResolutionService.ResolveType(contentType);

            var taxonomyFields = CustomFieldsHelpers.GetTaxonomyFields(type);
            return taxonomyFields;
        }
    }
}