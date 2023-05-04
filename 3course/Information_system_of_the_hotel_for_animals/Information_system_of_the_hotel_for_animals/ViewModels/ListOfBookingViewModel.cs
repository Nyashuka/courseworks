using System.Collections.Generic;
using System.Windows;
using Information_system.Infrastructure;
using Information_system.Models;
using Information_system.ViewModels.Base;

namespace Information_system.ViewModels
{
    public class ListOfBookingViewModel : UserControlViewModelBase
    {
        private string _text = "fdsnbghjsdvbhgsdvbhjgsd";

        public string Text
        {
            get => _text;
            set => Set(ref _text, value);
        }

        private MyDatabaseService _databaseService;
        private List<Booking> _bookings;
        
        public List<Booking> Bookings
        {
            get => _bookings;
            set => Set(ref _bookings, value);
        }
        
        public ListOfBookingViewModel() : base()
        {
            _databaseService = MyDatabaseService.Instance;
            
            _bookings = new List<Booking>();
        }
    }
}
