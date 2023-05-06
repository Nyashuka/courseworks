using System.Collections.Generic;
using Information_system.Models;
using Information_system.ViewModels.Base;

namespace Information_system.ViewModels
{
    public class RoomsViewModel : UserControlViewModelBase
    {
        public RoomsViewModel() : base()
        {
            
        }

        public List<Room> RoomsList { get; }
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