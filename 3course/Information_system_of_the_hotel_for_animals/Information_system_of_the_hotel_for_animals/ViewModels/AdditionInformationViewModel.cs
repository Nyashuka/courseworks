using System.Collections.Generic;
using Information_system.Models;
using Information_system.ViewModels.Base;

namespace Information_system.ViewModels
{
    public class AdditionInformationViewModel : UserControlViewModelBase
    {
         
        #region View

        private List<BookingAdditionInformation> _informations;

        public List<BookingAdditionInformation> Informations
        {
            get => _informations;
            set => Set(ref _informations, value);
        }

        #endregion
        
        #region Creating

        private int _id;

        public int Id
        {
            get => _id;
            set => Set(ref _id, value);
        }

        private string _breedOfAnimal;

        public string BreedOfAnimal
        {
            get => _breedOfAnimal;
            set => Set(ref _breedOfAnimal, value);
        }

        private string _health;

        public string Health
        {
            get => _health;
            set => Set(ref _health, value);
        }

        private string _needs;

        public string Needs
        {
            get => _needs;
            set => Set(ref _needs, value);
        }
        
        protected override void OnCreateRecordCommandExecute(object p)
        {
            _databaseService.CreateBookingAdditionInformation(Id, BreedOfAnimal, Health, Needs);
            
            EnterViewDataStateCommand.Execute(p);
        }
        
        #endregion
       

        #region Deletign

        protected override void OnDeleteRecordCommandExecute(object p)
        {
            BookingAdditionInformation i = p as BookingAdditionInformation;
            
            _databaseService.DeleteBookingAdditionInformationById(i.Id);
        }

        #endregion
        

        public override void UpdateData()
        {
            Informations = _databaseService.GetAllAdditionInformations();
        }

        public AdditionInformationViewModel() : base()
        {
            UpdateData();
        }
    }
}