using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using sale_of_vehicles.Models.Abstract;

namespace sale_of_vehicles
{
    /// <summary>
    /// Interaction logic for CarsPage.xaml
    /// </summary>
    public partial class VehiclesPage : Page
    {
        #region Filter Delegates
        private FilterCarsDelegate[] _filterCarsType = new FilterCarsDelegate[5] {
                                                         (x) => { return true; },
                                                         (x) => { return x is Bus; },
                                                         (x) => { return x is Truck;},
                                                         (x) => { return x is PassengerPlane; },
                                                         (x) => { return x is TransportPlane;}
                                                        };
        private FilterCarsDelegate[] _filterFuelsType = new FilterCarsDelegate[3]
                                                        {
                                                         (x) => { return true; },
                                                         (x) => { return x.FuelType is CarFuel; },
                                                         (x) => { return x.FuelType is AviationFuel; }
                                                        };
        #endregion

        private VehiclesShop _carShop;

        public event Action? OnDataChangedEvent;

        public VehiclesPage(VehiclesShop carShop, GasStation gasStation)
        {
            InitializeComponent();

            _carShop = carShop;

            InitializePage();
        }

        public void InitializePage()
        {
            VehicleTypeFilter.SelectedIndex = 0;
            FuelsTypeFilter.SelectedIndex = 0;

            UpdateTable();
        }


        private void UpdateTable()
        {
            List<FilterCarsDelegate> filterCarsDelegates = new List<FilterCarsDelegate>();

            filterCarsDelegates.Add(_filterCarsType[VehicleTypeFilter.SelectedIndex]);
            filterCarsDelegates.Add(_filterFuelsType[FuelsTypeFilter.SelectedIndex == -1 ? 0 : FuelsTypeFilter.SelectedIndex]);

            VehicleList.ItemsSource = null;
            VehicleList.ItemsSource = _carShop.GetVehiclesByFilters(filterCarsDelegates);
        }

        private void DeleteVehicle()
        {
            _carShop.RemoveVehicle((Vehicle)VehicleList.SelectedItem);
            OnDataChangedEvent?.Invoke();
            UpdateTable();
        }

        #region Events this page
        private void DeleteRecord_Click(object sender, RoutedEventArgs e)
        {
            DeleteVehicle();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(((IInformationDetails)VehicleList.SelectedItem).GetInformation());
        }

        private void VehicleTypeFilter_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateTable();
        }

        private void FuelsTypeFilter_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateTable();
        }
        #endregion

        
    }
}
