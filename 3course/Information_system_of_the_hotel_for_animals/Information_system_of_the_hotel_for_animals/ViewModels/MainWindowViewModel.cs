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
            CurrentContentInAdminPanel = new Employees();
        }
        
        public ICommand LoadRooms { get; }
        private bool CanLoadRoomsCommandExecute(object p) => true;
        private void OnLoadRoomsCommandExecute(object p)
        {
            CurrentContentInAdminPanel = new Rooms();
        }
        
        public ICommand LoadServices { get; }
        private bool CanLoadServicesCommandExecute(object p) => true;
        private void OnLoadServicesCommandExecute(object p)
        {
            CurrentContentInAdminPanel = new Services();
        }
        
        public ICommand LoadTypesOfRooms { get; }
        private bool CanLoadTypesOfRoomsCommandExecute(object p) => true;
        private void OnLoadTypesOfRoomsCommandExecute(object p)
        {
            CurrentContentInAdminPanel = new TypesOfRooms();
        }
        
        public ICommand LoadTypesOfServices { get; }
        private bool CanLoadTypesOfServicesCommandExecute(object p) => true;
        private void OnLoadTypesOfServicesCommandExecute(object p)
        {
            CurrentContentInAdminPanel = new TypesOfServices();
        }
        #endregion
        
        public MainWindowViewModel()
        {
            LoadBookings = new LambdaCommand(OnLoadBookingsCommandExecute, CanLoadBookingsCommandExecute);
            LoadEmployees = new LambdaCommand(OnLoadEmployeesCommandExecute, CanLoadEmployeesCommandExecute);
            LoadRooms = new LambdaCommand(OnLoadRoomsCommandExecute, CanLoadRoomsCommandExecute);
            LoadServices = new LambdaCommand(OnLoadServicesCommandExecute, CanLoadServicesCommandExecute);
            LoadTypesOfRooms = new LambdaCommand(OnLoadTypesOfRoomsCommandExecute, CanLoadTypesOfRoomsCommandExecute);
            LoadTypesOfServices = new LambdaCommand(OnLoadTypesOfServicesCommandExecute, CanLoadTypesOfServicesCommandExecute);
            //CurrentContentInAdminPanel = new;
        }
    }
}