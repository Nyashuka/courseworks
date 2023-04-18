using System;
using System.Collections.Generic;
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

namespace sale_of_vehicles.Views.Windows
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private VehiclesShop _vehicleShop;
        private GasStation _gasStation;
        private IDataLoader _dataLoader;
        public MainWindow()
        {
            _dataLoader = new DataLoader("fuels_type.txt", "vehicle_list.txt");
            _vehicleShop = new VehiclesShop(_dataLoader.LoadVehiclesData());
            _gasStation = _dataLoader.LoadFuelData();

            InitializeComponent();

            MainFrame.NavigationUIVisibility = NavigationUIVisibility.Hidden;
            PresentCarListPage();
        }

        private void PresentCarListPage()
        {
            VehiclesPage vehiclePage = new VehiclesPage(_vehicleShop, _gasStation);
            vehiclePage.OnDataChangedEvent += SaveVehiclesData;
            ClearHistory();
            MainFrame.Content = vehiclePage;
        }

        private void AddVehicle(Vehicle obj)
        {
            _vehicleShop.AddVehicle(obj);
            SaveVehiclesData();
        }

        private void AddFuel(FuelType obj)
        {
            _gasStation.AddFuel(obj);
            SaveFuelsData();
        }

        private void SaveVehiclesData()
        {
            _dataLoader.SaveVehiclesData(_vehicleShop.VehicleList);
        }

        private void SaveFuelsData()
        {
            _dataLoader.SaveFuelData(_gasStation);
        }

        public void ClearHistory()
        {
            if (!MainFrame.CanGoBack && !MainFrame.CanGoForward)
            {
                return;
            }

            var entry = MainFrame.RemoveBackEntry();
            while (entry != null)
            {
                entry = MainFrame.RemoveBackEntry();
            }

            MainFrame.Navigate(new PageFunction<string>() { RemoveFromJournal = true });
        }

        private void ListViewMenu_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int index = ListViewMenu.SelectedIndex;

            switch (index)
            {
                case 0:
                    PresentCarListPage();
                    break;
                case 1:
                    var vehiclePage = new VehicleCreatorPage(_gasStation);
                    vehiclePage.OnVehicleCreatedEvent += AddVehicle;
                    ClearHistory();
                    MainFrame.Content = vehiclePage;
                    break;
                case 2:
                    var fuelPage = new FuelCreatorPage();
                    fuelPage.OnFuelCreatedEvent += AddFuel;
                    ClearHistory();
                    MainFrame.Content = fuelPage;
                    break;
            }
        }

        
    }
}
