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
    }
}