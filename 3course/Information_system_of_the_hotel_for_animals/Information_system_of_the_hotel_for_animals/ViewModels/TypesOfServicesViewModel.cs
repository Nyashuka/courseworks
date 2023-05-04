using System.Collections.Generic;
using Information_system.Models;
using Information_system.ViewModels.Base;

namespace Information_system.ViewModels
{
    public class TypesOfServicesViewModel : UserControlViewModelBase
    {
        public TypesOfServicesViewModel() : base()
        {
        }
        
        public List<TypeOfService> TypesOfServicesList { get; }
    }
}