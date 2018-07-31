using Microsoft.Practices.Unity;
using Prism.Modularity;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedModule
{
    public class SharedModuleComponent : IModule
    {
        private IRegionManager regionManager = default(IRegionManager);
        private IUnityContainer container = default(IUnityContainer);

        public SharedModuleComponent(IRegionManager regionManager, IUnityContainer container)
        {
            this.regionManager = regionManager;
            this.container = container;
        }

        public void Initialize()
        {
            var headerWidget = this.container.Resolve<HeaderWidget>();
            var navigationWidget = this.container.Resolve<NavigationWidget>();

            this.regionManager.AddToRegion("HEADER_REGION", headerWidget);
            this.regionManager.AddToRegion("NAVIGATION_REGION", navigationWidget);
        }
    }
}
