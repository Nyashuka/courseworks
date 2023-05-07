using System.Collections.Generic;
using System.Net.Http.Headers;
using System.Windows.Input;
using Information_system.Infrastructure.Commands;
using Information_system.Models;
using Information_system.ViewModels.Base;

namespace Information_system.ViewModels
{
    public class OrderedServicesViewModel : UserControlViewModelBase
    {
        #region View

        private List<OrderedService> _orderedServicesList;

        public List<OrderedService> OrderedServicesList
        {
            get => _orderedServicesList;
            set => Set(ref _orderedServicesList, value);
        }

        #endregion


        #region Creating

        private int _bookingId;

        public int BookingId
        {
            get => _bookingId;
            set => Set(ref _bookingId, _bookingId);
        }

        private List<Service> _servicesToSelect;

        public List<Service> ServicesToSelect
        {
            get => _servicesToSelect;
            set => Set(ref _servicesToSelect, value);
        }
        
        private Service _selectedService;

        public Service SelectedService
        {
            get => _selectedService;
            set => Set(ref _selectedService, value);
        }

     
        protected override void OnCreateRecordCommandExecute(object p)
        {
            _databaseService.CreateOrderedService(BookingId, SelectedService.Id);
        }

        #endregion

        #region Deleting
        protected override void OnDeleteRecordCommandExecute(object p)
        {
            
        }
        #endregion

      

        public override void UpdateData()
        {
            OrderedServicesList = _databaseService.GetAllOrderedServices();
            ServicesToSelect = _databaseService.GetAllServices();
        }


        public OrderedServicesViewModel() : base()
        {
            UpdateData();

           
        }
    }
}