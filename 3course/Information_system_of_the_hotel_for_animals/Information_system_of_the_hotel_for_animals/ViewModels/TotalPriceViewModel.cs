using System.Data;
using System.Windows.Input;
using Information_system.Infrastructure;
using Information_system.Infrastructure.Commands;
using Information_system.ViewModels.Base;

namespace Information_system.ViewModels
{
    public class TotalPriceViewModel : ViewModel
    {
        private readonly MyDatabaseService _databaseService;
        private int _id;

        public int Id
        {
            get => _id;
            set => Set(ref _id, value);
        }

        private DataView _totalPriceView;

        public DataView TotalPriceView
        {
            get => _totalPriceView;
            set => Set(ref _totalPriceView, value);
        }

        public ICommand LoadTotalPrice { get; }

        private bool CanLoadTotalPriceCommandExecute(object p) => true;

        private void OnLoadTotalPriceStateCommandExecute(object p)
        {
            TotalPriceView = _databaseService.GetTotalPriceByBookingId(Id);
        }

        public TotalPriceViewModel()
        {
            LoadTotalPrice = new LambdaCommand(OnLoadTotalPriceStateCommandExecute, CanLoadTotalPriceCommandExecute);
            
            _databaseService = MyDatabaseService.Instance;
        }
    }
}