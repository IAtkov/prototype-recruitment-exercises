using System;
using System.Web.Mvc;
using System.Web.Routing;
using Ninject;
using Telerik.Sitefinity.Frontend.Mvc.Infrastructure.Controllers;
using Ninject.Extensions.Conventions;

namespace Common.Ninject
{
    public class NinjectControllerFactory : FrontendControllerFactory
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="NinjectControllerFactory"/> class.
        /// </summary>
        public NinjectControllerFactory()
        {
            ninjectKernel = Telerik.Sitefinity.Frontend.FrontendModule.Current.DependencyResolver;
            ninjectKernel.Bind(b => b.From("Common")
            .SelectAllClasses()
            .BindDefaultInterface());
        }

        protected override IController GetControllerInstance(RequestContext requestContext, Type controllerType)
        {
            if (controllerType == null)
            {
                return null;
            }

            var resolvedController = this.ninjectKernel.Get(controllerType);
            IController controller = resolvedController as IController;

            return controller;
        }

        private IKernel ninjectKernel;
    }
}
