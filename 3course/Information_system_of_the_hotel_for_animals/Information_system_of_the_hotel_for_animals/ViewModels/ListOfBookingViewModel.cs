using System.Collections.Generic;
using System.Windows;
using Information_system.Infrastructure;
using Information_system.Models;
using Information_system.ViewModels.Base;

namespace Information_system.ViewModels
{
    public class ListOfBookingViewModel : UserControlViewModelBase
    {

        #region View

        private List<Booking> _bookings;
        
        public List<Booking> Bookings
        {
            get => _bookings;
            set => Set(ref _bookings, value);
        }

        #endregion

        #region Creating
        

        #endregion
        
        public ListOfBookingViewModel() : base()
        {
            _bookings = new List<Booking>();
        }

        protected override void OnCreateRecordCommandExecute(object p)
        {
            throw new System.NotImplementedException();
        }

        protected override void OnDeleteRecordCommandExecute(object p)
        {
            throw new System.NotImplementedException();
        }
    }
}
