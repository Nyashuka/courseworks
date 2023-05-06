using System.Collections.Generic;
using System.Windows.Input;
using Information_system.Infrastructure.Commands;
using Information_system.Models;
using Information_system.ViewModels.Base;

namespace Information_system.ViewModels
{
    public class TypesOfServicesViewModel : UserControlViewModelBase
    {

        #region View

        private List<TypeOfService> _typeOfServicesList;

        public List<TypeOfService> TypesOfServicesList
        {
            get => _typeOfServicesList;
            set => Set(ref _typeOfServicesList, value);
        }

        #endregion

        #region Creating

        private string _titleOfService;

        public string TitleOfService
        {
            get => _titleOfService;
            set => Set(ref _titleOfService, value);
        }
        
        protected override void OnCreateRecordCommandExecute(object p)
        {
            _databaseService.CreateTypeOfService(TitleOfService);
            TypesOfServicesList = _databaseService.GetAllTypesOfServices();
            EnterViewDataStateCommand.Execute(p);
        }

        #endregion

        #region Deleting

        protected override void OnDeleteRecordCommandExecute(object p)
        {
            TypeOfService obj = p as TypeOfService;

            _databaseService.DeleteTypeOfService(obj.Id);
            
            TypesOfServicesList = _databaseService.GetAllTypesOfServices();
        }

        public override void UpdateData()
        {
            TypesOfServicesList = _databaseService.GetAllTypesOfServices();
        }

        #endregion

        public TypesOfServicesViewModel() : base()
        {
            UpdateData();
        }
    }
}