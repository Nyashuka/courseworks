using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace sale_of_vehicles
{
    public class ConnectionViewModel : INotifyPropertyChanged
    {
        private readonly CollectionView _fuelTypes;
        private string _fuelType = String.Empty;

        public ConnectionViewModel(IList<FuelType> fuelTypes)
        {
            IList<FuelType> list = fuelTypes;
            _fuelTypes = new CollectionView(list);
        }

        public CollectionView FuelTypeEntries
        {
            get { return _fuelTypes; }
        }

        public string FuelTypeEntry
        {
            get { return _fuelType; }
            set
            {
                if (_fuelType == value) return;
                _fuelType = value;
                OnPropertyChanged("FuelTypeEntry");
            }
        }

        private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        public event PropertyChangedEventHandler? PropertyChanged;
    }
}
