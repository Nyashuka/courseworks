using System;
using System.Collections.Generic;
using System.Windows.Input;
using Information_system.Infrastructure.Commands;
using Information_system.Models;
using Information_system.ViewModels.Base;

namespace Information_system.ViewModels
{
    public class ServicesViewModel : UserControlViewModelBase
    {
        #region View

        private List<Service> _servicesList;
        public List<Service> ServicesList
        {
            get => _servicesList;
            set => Set(ref _servicesList, value);
        }

        #endregion

        #region Creating
        
        private List<TypeOfService> _typesOfServices;
        public List<TypeOfService> TypesOfServices
        {
            get => _typesOfServices;
            set => Set(ref _typesOfServices, value);
        }
        
        private List<Employee> _employees;
        public List<Employee> Employees
        {
            get => _employees;
            set => Set(ref _employees, value);
        }
        

        private TypeOfService _selectedTypeOfService;
        public TypeOfService SelectedTypeOfService
        {
            get => _selectedTypeOfService;
            set => Set(ref _selectedTypeOfService, value);
        }
        
        private Employee _selectedEmployee;
        public Employee SelectedEmployee
        {
            get => _selectedEmployee;
            set => Set(ref _selectedEmployee, value);
        }
        
        private string _titleOfService;
        public string TitleOfService
        {
            get => _titleOfService;
            set => Set(ref _titleOfService, value);
        }
        
        private double _pricePerDay;
        public double PricePerDay
        {
            get => _pricePerDay;
            set => Set(ref _pricePerDay, value);
        }
        
        protected override void OnCreateRecordCommandExecute(object p)
        {
            _databaseService.CreateService(SelectedTypeOfService.Id, SelectedEmployee.Id, TitleOfService, PricePerDay);
            ServicesList = _databaseService.GetAllServices();
            EnterViewDataStateCommand.Execute(p);
        }

        #endregion

        #region Deleting
        
        protected override void OnDeleteRecordCommandExecute(object p)
        {
            Service obj = p as Service;
            _databaseService.DeleteService(obj.Id);
            ServicesList = _databaseService.GetAllServices();
        }

        public override void UpdateData()
        {
            ServicesList = _databaseService.GetAllServices();
            Employees = _databaseService.GetAllEmployees();
            TypesOfServices = _databaseService.GetAllTypesOfServices();
        }

        #endregion

        #region Modifying

        private Service _currentService;

        public Service CurrentService
        {
            get => _currentService;
            set => Set(ref _currentService, value);
        }

        public ICommand ModifyRecord { get; }
        
        private bool CanModifyRecordCommandExecute(object p) => true;

        private void OnModifyRecordCommandExecute(object p)
        {
            EnterEditFieldStateCommand.Execute(p);
            
            CurrentService = p as Service;
            TitleOfService = CurrentService.TitleOfService;
            PricePerDay = CurrentService.PricePerDay;
        }
        
        public ICommand SaveModifying { get; }
        private bool CanSaveModifyingRecordCommandExecute(object p) => true;

        private void OnSaveModifyingRecordCommandExecute(object p)
        {
            _databaseService.UpdateService(CurrentService.Id, TitleOfService, PricePerDay, SelectedTypeOfService.Id,
                SelectedEmployee.Id);
            
            EnterViewDataStateCommand.Execute(p);
        }

        #endregion

        public ServicesViewModel() : base()
        {
            UpdateData();
            
            ModifyRecord = new LambdaCommand(OnModifyRecordCommandExecute, CanModifyRecordCommandExecute);
            SaveModifying = new LambdaCommand(OnSaveModifyingRecordCommandExecute, CanSaveModifyingRecordCommandExecute);
        }
    }
}