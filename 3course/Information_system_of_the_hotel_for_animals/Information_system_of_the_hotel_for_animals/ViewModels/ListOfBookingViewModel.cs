using System;
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

        private List<TypeOfRoom> _typesOfRooms;
        public List<TypeOfRoom> TypesOfRooms
        {
            get => _typesOfRooms;
            set => Set(ref _typesOfRooms, value);
        }
        
        private TypeOfRoom _selectedRoom;
        public TypeOfRoom SelectedRoom
        {
            get => _selectedRoom;
            set => Set(ref _selectedRoom, value);
        }
        
        private string _tenantFullName;
        public string TenantFullName
        {
            get => _tenantFullName;
            set => Set(ref _tenantFullName, value);
        }
        
        private string _tenantPhoneNumber;
        public string TenantPhoneNumber
        {
            get => _tenantPhoneNumber;
            set => Set(ref _tenantPhoneNumber, value);
        }
        
        private DateTime _dateOfStart = DateTime.Now;
        public DateTime DateOfStart
        {
            get => _dateOfStart;
            set => Set(ref _dateOfStart, value);
        }
        
        private DateTime _dateOfEnd = DateTime.Now;
        public DateTime DateOfEnd
        {
            get => _dateOfEnd;
            set => Set(ref _dateOfEnd, value);
        }
        
        private double _priceOfBooking;
        public double PriceOfBooking
        {
            get => _priceOfBooking;
            set => Set(ref _priceOfBooking, value);
        }

        protected override void OnCreateRecordCommandExecute(object p)
        {
            List<Room> rooms = _databaseService.GetRoomsByDateAndType( DateOfStart, DateOfEnd, SelectedRoom);

            if (rooms == null)
            {
                MessageBox.Show("Rooms not found");
                return;
            }

            int days = (DateOfEnd - DateOfStart).Days;
            PriceOfBooking = days * SelectedRoom.PricePerDay;
            
            _databaseService.CreateBooking(rooms[0].Id, TenantFullName, TenantPhoneNumber, PriceOfBooking, DateOfStart, DateOfEnd);
        }

        #endregion
        
        

        protected override void OnDeleteRecordCommandExecute(object p)
        {
           
        }

        public override void UpdateData()
        {
            _bookings = new List<Booking>();
            TypesOfRooms = _databaseService.GetAllTypesOfRooms();
        }
        
        public ListOfBookingViewModel() : base()
        {
            
        }

      
    }
}
