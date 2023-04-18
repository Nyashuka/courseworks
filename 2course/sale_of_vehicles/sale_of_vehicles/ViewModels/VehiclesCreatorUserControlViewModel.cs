using sale_of_vehicles.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sale_of_vehicles.ViewModels
{
    public class VehiclesCreatorUserControlViewModel : ViewModel
    {
        private IDataLoader _dataLoader;
        private GasStation _gasStation;

        public VehiclesCreatorUserControlViewModel()
        {
            _dataLoader = new DataLoader("fuels_type.txt", "vehicle_list.txt");
            _gasStation = _dataLoader.LoadFuelData();
            _carFuels = _gasStation.GetCarFuels();
            _aviationFuels = _gasStation.GetPlaneFuels();
        }

        #region Fuel type
        private IList<FuelType> _carFuels;

        public IList<FuelType> CarFuels
        {
            get => _carFuels;
            set
            {
                Set(ref _carFuels, value);
            }
        }

        private IList<FuelType> _aviationFuels;

        public IList<FuelType> AviationFuels
        {
            get => _aviationFuels;
            set
            {
                Set(ref _aviationFuels, value);
            }
        }
        #endregion

        #region Cargo type combobox initializer
        private IEnumerable<TypeOfCargo> _typeOfCargos = Enum.GetValues(typeof(TypeOfCargo)).Cast<TypeOfCargo>();

        public IEnumerable<TypeOfCargo> TypeOfCargos
        {
            get => _typeOfCargos;
            set
            {
                Set(ref _typeOfCargos, value);
            }
        }
        #endregion
    }
}
