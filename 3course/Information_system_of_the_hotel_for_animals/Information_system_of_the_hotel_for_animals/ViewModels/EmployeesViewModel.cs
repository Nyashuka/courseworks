using System.Collections.Generic;
using Information_system.Models;
using Information_system.ViewModels.Base;

namespace Information_system.ViewModels
{
    public class EmployeesViewModel : UserControlViewModelBase
    {
        #region View

        private List<Employee> _employeesList;
        public List<Employee> EmployeeList
        {
            get => _employeesList;
            set => Set(ref _employeesList, value);
        }

        #endregion


        #region Creating

        private string _fullName;

        public string FullName
        {
            get => _fullName;
            set => Set(ref _fullName, value);
        }
        
        private string _phoneNumber;

        public string PhoneNumber
        {
            get => _phoneNumber;
            set => Set(ref _phoneNumber, value);
        }

        protected override void OnCreateRecordCommandExecute(object p)
        {
            _databaseService.CreateEmployee(FullName, PhoneNumber);
            EmployeeList = _databaseService.GetAllEmployees();
            EnterViewDataStateCommand.Execute(p);
        }

        #endregion

        #region Deleting

        protected override void OnDeleteRecordCommandExecute(object p)
        {
            Employee obj = p as Employee;
            _databaseService.DeleteEmployee(obj.Id);
            EmployeeList = _databaseService.GetAllEmployees();
        }

        #endregion
      
        
        public EmployeesViewModel() : base()
        {
            EmployeeList = _databaseService.GetAllEmployees();
        }
    }
}