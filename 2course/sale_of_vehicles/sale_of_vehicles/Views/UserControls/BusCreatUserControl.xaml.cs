using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace sale_of_vehicles
{
    /// <summary>
    /// Interaction logic for BusCreatUserControl.xaml
    /// </summary>
    public partial class BusCreatUserControl : UserControl, IInterfaceDataReceiver<Vehicle>
    {
        public BusCreatUserControl(GasStation gasStation)
        {
            InitializeComponent();
        }

        public Vehicle GetData()
        {
            return new Bus(    Guid.NewGuid(),
                               Name.Text,
                               Model.Text,
                               Convert.ToDouble(Price.Text),
                               Convert.ToInt32(NumbersOfSeats.Text),
                               (CarFuel)FuelNameTypeFilter.SelectedItem,
                               new CarFunctionality(),
                               Convert.ToInt32(PeopleCapacity.Text)
                             );
        }

    }
}
