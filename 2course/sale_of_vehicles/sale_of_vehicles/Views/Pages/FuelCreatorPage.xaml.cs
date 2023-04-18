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
    /// Interaction logic for FuelCreatorPage.xaml
    /// </summary>
    public partial class FuelCreatorPage : Page
    {
        public event Action<FuelType>? OnFuelCreatedEvent;

        public FuelCreatorPage()
        {
            InitializeComponent();
        }

        private void SaveFuelButton_Click(object sender, RoutedEventArgs e)
        {
            if(TypeOfFuelComboBox.SelectedIndex == 0)
                OnFuelCreatedEvent?.Invoke(new CarFuel(Guid.NewGuid(), Name.Text));
            else
                OnFuelCreatedEvent?.Invoke(new AviationFuel(Guid.NewGuid(), Name.Text));
        }
    }
}
