using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Information_system_of_the_hotel_for_animals.Views.UserControls;
using Information_system.Infrastructure;
using Information_system.Infrastructure.Commands;
using Information_system.ViewModels.Base;
using Information_system.Views.UserControls;

namespace Information_system.ViewModels
{
    public class MainWindowViewModel : ViewModel
    {
        #region Title

        private string _title = "Information system of the hotel for animals";

        public string Title
        {
            get => _title;
            set => Set(ref _title, value);
        }

        #endregion

        private UserControl _currentContentInInfo;

        public UserControl CurrentContentInInfo
        {
            get => _currentContentInInfo;
            set => Set(ref _currentContentInInfo, value);
        }
        
        private UserControl _currentContentInAdminPanel;

        public UserControl CurrentContentInAdminPanel
        {
            get => _currentContentInAdminPanel;
            set => Set(ref _currentContentInAdminPanel, value);
        }


        private UserControl _currentContentInBooking;

        public UserControl CurrentContentInBooking
        {
            get => _currentContentInBooking;
            set => Set(ref _currentContentInBooking, value);
        }

        private ViewModel _currentViewModelInBooking;

        public ViewModel CurrentViewModelInBooking
        {
            get => _currentViewModelInBooking;
            set => Set(ref _currentViewModelInBooking, value);
        }

        private ViewModel _currentViewModelInAdminPanel;

        public ViewModel CurrentViewModelInAdminPanel
        {
            get => _currentViewModelInAdminPanel;
            set => Set(ref _currentViewModelInAdminPanel, value);
        }
        
        private ViewModel _currentViewModelInInfo;

        public ViewModel CurrentViewModelInInfo
        {
            get => _currentViewModelInInfo;
            set => Set(ref _currentViewModelInInfo, value);
        }

        #region COMMANDS

        public ICommand LoadBookings { get; }
        private bool CanLoadBookingsCommandExecute(object p) => true;

        private void OnLoadBookingsCommandExecute(object p)
        {
            CurrentViewModelInBooking = new ListOfBookingViewModel();
            CurrentContentInBooking = new ListOfBookings(CurrentViewModelInBooking);
        }

        public ICommand LoadEmployees { get; }
        private bool CanLoadEmployeesCommandExecute(object p) => true;

        private void OnLoadEmployeesCommandExecute(object p)
        {
            CurrentViewModelInAdminPanel = new EmployeesViewModel();
            CurrentContentInAdminPanel = new Employees(CurrentViewModelInAdminPanel);
        }

        public ICommand LoadRooms { get; }
        private bool CanLoadRoomsCommandExecute(object p) => true;

        private void OnLoadRoomsCommandExecute(object p)
        {
            CurrentViewModelInAdminPanel = new RoomsViewModel();
            CurrentContentInAdminPanel = new Rooms(CurrentViewModelInAdminPanel);
        }

        public ICommand LoadServices { get; }
        private bool CanLoadServicesCommandExecute(object p) => true;

        private void OnLoadServicesCommandExecute(object p)
        {
            CurrentViewModelInAdminPanel = new ServicesViewModel();
            CurrentContentInAdminPanel = new Services(CurrentViewModelInAdminPanel);
        }

        public ICommand LoadTypesOfRooms { get; }
        private bool CanLoadTypesOfRoomsCommandExecute(object p) => true;

        private void OnLoadTypesOfRoomsCommandExecute(object p)
        {
            CurrentViewModelInAdminPanel = new TypesOfRoomsViewModel();
            CurrentContentInAdminPanel = new TypesOfRooms(CurrentViewModelInAdminPanel);
        }

        public ICommand LoadTypesOfServices { get; }
        private bool CanLoadTypesOfServicesCommandExecute(object p) => true;

        private void OnLoadTypesOfServicesCommandExecute(object p)
        {
            CurrentViewModelInAdminPanel = new TypesOfServicesViewModel();
            CurrentContentInAdminPanel = new TypesOfServices(CurrentViewModelInAdminPanel);
        }

        public ICommand LoadOrderedServices { get; }
        private bool CanLoadOrderedServicesCommandExecute(object p) => true;

        private void OnLoadOrderedServicesCommandExecute(object p)
        {
            CurrentViewModelInBooking = new OrderedServicesViewModel();
            CurrentContentInBooking = new OrderedServices(CurrentViewModelInBooking);
        }

        #endregion

        public ICommand LoadTotalPrice { get; }
        private bool CanLoadTotalPriceCommandExecute(object p) => true;

        private void OnLoadTotalPriceCommandExecute(object p)
        {
            CurrentViewModelInInfo = new TotalPriceViewModel();
            CurrentContentInInfo = new TotalPriceUserControl(CurrentViewModelInInfo);
        }

        public MainWindowViewModel()
        {
            LoadBookings = new LambdaCommand(OnLoadBookingsCommandExecute, CanLoadBookingsCommandExecute);
            LoadEmployees = new LambdaCommand(OnLoadEmployeesCommandExecute, CanLoadEmployeesCommandExecute);
            LoadRooms = new LambdaCommand(OnLoadRoomsCommandExecute, CanLoadRoomsCommandExecute);
            LoadServices = new LambdaCommand(OnLoadServicesCommandExecute, CanLoadServicesCommandExecute);
            LoadTypesOfRooms = new LambdaCommand(OnLoadTypesOfRoomsCommandExecute, CanLoadTypesOfRoomsCommandExecute);
            LoadTypesOfServices =
                new LambdaCommand(OnLoadTypesOfServicesCommandExecute, CanLoadTypesOfServicesCommandExecute);
            LoadOrderedServices =
                new LambdaCommand(OnLoadOrderedServicesCommandExecute, CanLoadOrderedServicesCommandExecute);

            LoadTotalPrice = new LambdaCommand(OnLoadTotalPriceCommandExecute, CanLoadTotalPriceCommandExecute);
        }
    }
}