using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sale_of_vehicles
{
    public interface IInterfaceDataReceiver<T>
    {
        T GetData();
    }
}
