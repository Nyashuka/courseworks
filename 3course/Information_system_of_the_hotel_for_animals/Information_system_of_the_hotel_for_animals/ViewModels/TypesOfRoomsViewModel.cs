using System.Collections.Generic;
using Information_system.Models;
using Information_system.ViewModels.Base;

namespace Information_system.ViewModels
{
    public class TypesOfRoomsViewModel : UserControlViewModelBase
    {
        public TypesOfRoomsViewModel() : base()
        {
            
        }
        
        public List<TypeOfRoom> TypesOfRoomsList { get; }
    }
}