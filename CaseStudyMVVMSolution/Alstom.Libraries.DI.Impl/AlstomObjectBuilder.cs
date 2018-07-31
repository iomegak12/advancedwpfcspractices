using Alstom.Libraries.DI.Interfaces;
using Microsoft.Practices.Unity.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity;

namespace Alstom.Libraries.DI.Impl
{
    public class AlstomObjectBuilder : IObjectBuilder
    {
        private IUnityContainer container = default(IUnityContainer);

        private AlstomObjectBuilder()
        {
            this.container = new UnityContainer().LoadConfiguration();
        }

        public T GetObject<T>()
        {
            return this.container.Resolve<T>();
        }

        public object GetObject(Type serviceType)
        {
            return this.container.Resolve(serviceType);
        }

        public T GetObject<T>(string serviceName)
        {
            return this.container.Resolve<T>(serviceName);
        }

        public object GetObject(Type serviceType, string serviceName)
        {
            return this.container.Resolve(serviceType, serviceName);
        }

        #region Singleton Implementation

        private static IObjectBuilder objectBuilder = default(IObjectBuilder);

        static AlstomObjectBuilder()
        {
            objectBuilder = new AlstomObjectBuilder();
        }

        public static IObjectBuilder Instance
        {
            get { return objectBuilder; }
        }

        #endregion
    }
}
