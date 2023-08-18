using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant
{
    public interface IDataLoader
    {
        CookingPlan LoadCookingPlan();
        Storage LoadStorage();
        void SaveCookingPlan(CookingPlan cookingPlan);
        void SaveStorage(Storage storage);
    }
}
