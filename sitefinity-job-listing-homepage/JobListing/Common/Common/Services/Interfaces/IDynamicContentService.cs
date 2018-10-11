using System.Linq;
using Telerik.Sitefinity.DynamicModules.Model;

namespace Common.Services.Interfaces
{
    public interface IDynamicContentService
    {
        IQueryable<DynamicContent> GetItemsSuccesors(DynamicContent parent, string childItemType, string providerName = null, bool reinitializeManager = false);

        IQueryable<DynamicContent> RetrieveCollectionOfLiveData(string typeName, string providerName = null, bool reinitializeManager = false);
    }
}