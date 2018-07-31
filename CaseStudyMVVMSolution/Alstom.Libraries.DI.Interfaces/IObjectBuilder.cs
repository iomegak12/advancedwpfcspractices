using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alstom.Libraries.DI.Interfaces
{
    public interface IObjectBuilder
    {
        T GetObject<T>();
        object GetObject(Type serviceType);

        T GetObject<T>(string serviceName);
        object GetObject(Type serviceType, string serviceName);
    }
}
