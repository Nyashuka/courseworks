using System.Collections.Generic;
using Information_system.Models;
using Information_system.ViewModels.Base;

namespace Information_system.ViewModels
{
    public class EmployeesViewModel : UserControlViewModelBase
    {
        public EmployeesViewModel() : base()
        {
            
        }

        public List<Employee> EmployeeList { get; }
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