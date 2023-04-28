using Information_system_of_the_hotel_for_animals.Data;
using Information_system_of_the_hotel_for_animals.ViewModels.Base;

namespace Information_system_of_the_hotel_for_animals.ViewModels
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

        public MainWindowViewModel()
        {
            DatabaseService databaseService = new DatabaseService();
        }
    }
}