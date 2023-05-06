using System.Collections.Generic;
using System.Windows.Input;
using Information_system.Models;
using Information_system.ViewModels.Base;

namespace Information_system.ViewModels
{
    public class ServicesViewModel : UserControlViewModelBase
    {
        public List<Service> ServicesList { get; }

        public ServicesViewModel() : base()
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