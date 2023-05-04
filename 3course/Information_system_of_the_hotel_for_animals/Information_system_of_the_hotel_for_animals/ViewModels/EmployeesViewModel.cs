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
    }
}