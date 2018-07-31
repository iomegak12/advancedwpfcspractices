using Microsoft.Practices.Unity;
using Prism.Modularity;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContentModuleLibrary
{
    public class ContentModule : IModule
    {
        private IRegionManager regionManager = default(IRegionManager);
        private IUnityContainer container = default(IUnityContainer);

        public ContentModule(IRegionManager regionManager, IUnityContainer container)
        {
            this.regionManager = regionManager;
            this.container = container;
        }

        public void Initialize()
        {
            var customersContentWidget = this.container.Resolve<CustomersWidget>();

            this.regionManager.AddToRegion("CONTENT_REGION", customersContentWidget);
        }
    }
}
