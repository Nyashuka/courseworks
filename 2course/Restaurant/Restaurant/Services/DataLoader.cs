using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant
{
    public class DataLoader : IDataLoader
    {
        private string _pathToCookingList = "";
        private string _pathToStorage = "";

        public DataLoader(string pathToCookingList, string pathToStorage)
        {
            _pathToCookingList = pathToCookingList;
            _pathToStorage = pathToStorage;
        }
        
        public CookingPlan LoadCookingPlan()
        {
            IAdapter<CookingPlan, CookingPlanDTO> adapter = new CookingPlanAdapter();
            Serializator<CookingPlanDTO> serializator = new Serializator<CookingPlanDTO>(_pathToCookingList);

            CookingPlanDTO cookingPlanDTO = serializator.Deserialize();

            return adapter.ConvertToModel(cookingPlanDTO);
        }

        public Storage LoadStorage()
        {
            IAdapter<Storage, StorageDTO> adapter = new StorageAdapter();
            Serializator<StorageDTO> serializator = new Serializator<StorageDTO>(_pathToStorage);

            StorageDTO storageDTO = serializator.Deserialize();

            return adapter.ConvertToModel(storageDTO);
        }

        public void SaveCookingPlan(CookingPlan cookingPlan)
        {
            IAdapter<CookingPlan, CookingPlanDTO> adapter = new CookingPlanAdapter();
            Serializator<CookingPlanDTO> serializator = new Serializator<CookingPlanDTO>(_pathToCookingList);

            serializator.Serialize(adapter.ConvertToDTO(cookingPlan));
        }

        public void SaveStorage(Storage storage)
        {
            IAdapter<Storage, StorageDTO> adapter = new StorageAdapter();
            Serializator<StorageDTO> serializator = new Serializator<StorageDTO>(_pathToStorage);

            serializator.Serialize(adapter.ConvertToDTO(storage));
        }

    }
}
