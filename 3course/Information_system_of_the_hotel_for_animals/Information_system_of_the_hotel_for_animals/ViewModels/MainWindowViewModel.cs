using System.Windows.Controls;
using System.Windows.Input;
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
        
        private UserControl _currentContent = new ListOfBookings();
        public UserControl CurrentContent
        {
            get => _currentContent;
            set => Set(ref _currentContent, value);
        }

        #region COMMANDS
        
        public ICommand LoadBookings { get; }

        private bool CanLoadBookingsCommandExecute(object p) => true;
        private void OnLoadBookingsCommandExecute(object p)
        {
            CurrentContent = new ListOfBookings();
        }

        #endregion
        
        public MainWindowViewModel()
        {
            LoadBookings = new LambdaCommand(OnLoadBookingsCommandExecute, CanLoadBookingsCommandExecute);
            //CurrentContent = new ListOfBookings();
        }
    }
}