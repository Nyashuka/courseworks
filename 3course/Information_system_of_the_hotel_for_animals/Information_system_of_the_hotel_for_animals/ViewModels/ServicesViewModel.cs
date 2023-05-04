using System.Collections.Generic;
using Information_system.Models;
using Information_system.ViewModels.Base;

namespace Information_system.ViewModels
{
    public class ServicesViewModel : UserControlViewModelBase
    {
        public ServicesViewModel() : base()
        {
            
        }

        public List<Service> ServicesList { get; }
    }
}