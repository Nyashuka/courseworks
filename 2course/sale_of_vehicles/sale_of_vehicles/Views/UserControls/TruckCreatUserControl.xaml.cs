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
    /// Interaction logic for TruckCreatUserControl.xaml
    /// </summary>
    public partial class TruckCreatUserControl : UserControl, IInterfaceDataReceiver<Vehicle>
    {
        public TruckCreatUserControl(GasStation gasStation)
        {
            InitializeComponent();

        }

        public Vehicle GetData()
        {
            return new Truck(    Guid.NewGuid(),
                                 Name.Text,
                                 Model.Text,
                                 Convert.ToDouble(Price.Text),
                                 Convert.ToInt32(NumbersOfSeats.Text),
                                 (CarFuel)FuelNameTypeFilter.SelectedItem,
                                 new CarFunctionality(),
                                 Convert.ToDouble(MaxWeightOfCargo.Text),
                                 (TypeOfCargo)CargoTypeSelector.SelectedIndex
                             );
        }


    }
}
