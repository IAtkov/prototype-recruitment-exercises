using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using Telerik.Sitefinity.Frontend.Mvc.Helpers;

namespace Common.Controllers
{
    public abstract class BaseController : Controller
    {
        private string listTemplateNamePrefix = "List.";
        private string detailTemplateNamePrefix = "Detail.";

        public string ListTemplateName { get; set; }

        public string DetailTemplateName { get; set; }

        public Type ControllerName
        {
            get
            {
                return GetType();
            }
        }

        public string ListTemplateNamePrefix
        {
            get { return listTemplateNamePrefix; }
            set { listTemplateNamePrefix = value; }
        }

        public string DetailTemplateNamePrefix
        {
            get { return detailTemplateNamePrefix; }
            set { detailTemplateNamePrefix = value; }
        }

        [NonAction]
        public string GetListTemplateName(string defaultView)
        {
            if (string.IsNullOrWhiteSpace(ListTemplateName))
            {
                return defaultView;
            }

            return ListTemplateNamePrefix + ListTemplateName;
        }

        [NonAction]
        public string GetDetailTemplateName(string defaultView)
        {
            if (string.IsNullOrWhiteSpace(DetailTemplateName))
            {
                return defaultView;
            }

            return DetailTemplateNamePrefix + DetailTemplateName;
        }

        [NonAction]
        public ContentResult ReturnAppropriateResultWhenNull(string backEndMessage)
        {
            if (SitefinityContext.IsBackend)
            {
                return Content(backEndMessage);
            }
            else
            {
                return Content(string.Empty);
            }
        }
    }
}
