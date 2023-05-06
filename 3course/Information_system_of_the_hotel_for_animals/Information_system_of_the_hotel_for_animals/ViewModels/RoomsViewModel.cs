using System;
using System.Collections.Generic;
using Information_system.Models;
using Information_system.ViewModels.Base;

namespace Information_system.ViewModels
{
    public class RoomsViewModel : UserControlViewModelBase
    {

        #region View

        private List<Room> _roomsList;

        public List<Room> RoomsList
        {
            get => _roomsList;
            set => Set(ref _roomsList, value);
        }

        #endregion

        #region Creating

        private List<TypeOfRoom> _typesOfRooms;
        public List<TypeOfRoom> TypesOfRooms
        {
            get => _typesOfRooms;
            set => Set(ref _typesOfRooms, value);
        }

        private int _numberOfRoom;
        public int NumberOfRoom
        {
            get => _numberOfRoom;
            set => Set(ref _numberOfRoom, value);
        }

        private TypeOfRoom _selectedTypeOfRoom;
        public TypeOfRoom SelectedTypeOfRoom
        {
            get => _selectedTypeOfRoom;
            set => Set(ref _selectedTypeOfRoom, value);
        }

        protected override void OnCreateRecordCommandExecute(object p)
        {
            _databaseService.CreateRoom(SelectedTypeOfRoom.Id, NumberOfRoom);
            RoomsList = _databaseService.GetAllRooms();
            EnterViewDataStateCommand.Execute(p);
        }

        #endregion

        #region Deleting

        protected override void OnDeleteRecordCommandExecute(object p)
        {
            Room obj = p as Room;
            _databaseService.DeleteRoom(obj.Id);
            RoomsList = _databaseService.GetAllRooms();
        }

        public override void UpdateData()
        {
            _typesOfRooms = _databaseService.GetAllTypesOfRooms();
            RoomsList = _databaseService.GetAllRooms();
        }

        #endregion


        public RoomsViewModel() : base()
        {
            UpdateData();
        }

      
    }
}