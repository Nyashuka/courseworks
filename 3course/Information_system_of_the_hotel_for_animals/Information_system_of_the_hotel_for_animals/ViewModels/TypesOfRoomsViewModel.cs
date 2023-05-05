using System.Collections.Generic;
using System.Windows.Input;
using Information_system.Infrastructure.Commands;
using Information_system.Models;
using Information_system.ViewModels.Base;

namespace Information_system.ViewModels
{
    public class TypesOfRoomsViewModel : UserControlViewModelBase
    {
        public List<TypeOfRoom> TypesOfRoomsList { get; }
        
        public ICommand CreateTypeOfRoom { get; }
        private bool CanCreateTypeOfRoomCommandExecute(object p) => true;
        private void OnCreateTypeOfRoomCommandExecute(object p)
        {
            EnterViewDataStateCommand.Execute(p);
        }
        
        public TypesOfRoomsViewModel() : base()
        {
            CreateTypeOfRoom = new LambdaCommand(OnCreateTypeOfRoomCommandExecute, CanCreateTypeOfRoomCommandExecute);
        }
        
        
    }
}