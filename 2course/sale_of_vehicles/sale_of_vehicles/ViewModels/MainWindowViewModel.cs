using sale_of_vehicles.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sale_of_vehicles.ViewModels
{
    public class MainWindowViewModel : ViewModel
    {
        #region Window's title
        private string _title = "Vehicle Support System";
        /// <summary> Window title</summary>
        public string Title
        {
            get => _title;
            set
            {
                Set(ref _title, value);
            }
        }
        #endregion
    }
}
