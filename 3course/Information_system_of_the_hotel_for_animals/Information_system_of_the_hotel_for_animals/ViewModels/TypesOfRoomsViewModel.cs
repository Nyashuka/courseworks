using System.Collections.Generic;
using System.Windows.Input;
using Information_system.Infrastructure.Commands;
using Information_system.Models;
using Information_system.ViewModels.Base;

namespace Information_system.ViewModels
{
    public class TypesOfRoomsViewModel : UserControlViewModelBase
    {
        #region View

        private List<TypeOfRoom> _typesOfRoomsList;

        public List<TypeOfRoom> TypesOfRoomsList
        {
            get => _typesOfRoomsList;
            set => Set(ref _typesOfRoomsList, value);
        }

        #endregion

        #region Creating

        private string _titleOfRoom;

        public string TitleOfRoom
        {
            get => _titleOfRoom;
            set => Set(ref _titleOfRoom, value);
        }

        private string _areaOfRoom;

        public string AreaOfRoom
        {
            get => _areaOfRoom;
            set => Set(ref _areaOfRoom, value);
        }

        private string _priceOerDay;

        public string PricePerDay
        {
            get => _priceOerDay;
            set => Set(ref _priceOerDay, value);
        }

        protected override void OnCreateRecordCommandExecute(object p)
        {
            _databaseService.CreateTypeOfRoom(TitleOfRoom, AreaOfRoom, PricePerDay);
            TypesOfRoomsList = _databaseService.GetAllTypesOfRooms();
            EnterViewDataStateCommand.Execute(p);
        }

        protected override void OnDeleteRecordCommandExecute(object p)
        {
            TypeOfRoom obj = p as TypeOfRoom;
            _databaseService.DeleteTypeOfRoom(obj.Id);
            TypesOfRoomsList = _databaseService.GetAllTypesOfRooms();
        }

        public override void UpdateData()
        {
            TypesOfRoomsList = _databaseService.GetAllTypesOfRooms();
        }

        #endregion

        public TypesOfRoomsViewModel() : base()
        {
            UpdateData();
        }
    }
}