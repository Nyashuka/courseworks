using System.Collections.Generic;
using System.Windows;
using Information_system.Infrastructure;
using Information_system.Models;
using Information_system.ViewModels.Base;

namespace Information_system.ViewModels
{
    public class ListOfBookingViewModel : ViewModel
    {
        private Visibility _creatingVisibility = Visibility.Collapsed;

        public Visibility CreatingVisibility
        {
            get => _creatingVisibility;
            set => Set(ref _creatingVisibility, value);
        } 
        
        // private bool _isCreatingState = false;
        //
        // public bool IsCreatingState
        // {
        //     get => _isCreatingState;
        //     set
        //     {
        //         Set(ref _isCreatingState, value);
        //
        //         if (value)
        //             CreatingVisibility = Visibility.Visible;
        //         else
        //             CreatingVisibility = Visibility.Hidden;
        //     }
        // }
        
        private MyDatabaseService _databaseService;
        private List<Booking> _bookings;
        
        public List<Booking> Bookings
        {
            get => _bookings;
            set => Set(ref _bookings, value);
        }
        
        public ListOfBookingViewModel() 
        {
            _databaseService = MyDatabaseService.Instance;
            

            _bookings = new List<Booking>();
        }
    }
}
