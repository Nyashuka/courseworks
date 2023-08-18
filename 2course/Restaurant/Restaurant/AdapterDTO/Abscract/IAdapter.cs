using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant
{
    public interface IAdapter<T1, T2>
    {
        T1 ConvertToModel(T2 dto);
        T2 ConvertToDTO(T1 model);
    }
}
