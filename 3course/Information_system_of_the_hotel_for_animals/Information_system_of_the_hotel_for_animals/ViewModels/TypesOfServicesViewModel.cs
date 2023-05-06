using System.Collections.Generic;
using System.Windows.Input;
using Information_system.Infrastructure.Commands;
using Information_system.Models;
using Information_system.ViewModels.Base;

namespace Information_system.ViewModels
{
    public class TypesOfServicesViewModel : UserControlViewModelBase
    {
        public List<TypeOfService> TypesOfServicesList { get; }
        
        
        public TypesOfServicesViewModel() : base()
        {
           
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