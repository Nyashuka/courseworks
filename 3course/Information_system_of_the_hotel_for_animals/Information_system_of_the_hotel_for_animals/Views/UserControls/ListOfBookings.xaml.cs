using System.Windows;
using System.Windows.Controls;

namespace Information_system.Views.UserControls
{
    public partial class ListOfBookings : UserControl
    {
        public ListOfBookings()
        {
            InitializeComponent();
        }

        private void AddRecordButton_Clicked(object sender, RoutedEventArgs e)
        {
            CreatingGrid.Visibility = Visibility.Visible;
            CreatingGrid.IsEnabled = true;

            DataTableGrid.Visibility = Visibility.Collapsed;
            DataTableGrid.IsEnabled = false;
        }
    }
}