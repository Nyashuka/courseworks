using System.Windows;
using System.Windows.Controls;
using Information_system_of_the_hotel_for_animals.Views.UserControls.Base;
using Information_system.ViewModels.Base;

namespace Information_system.Views.UserControls
{
    public partial class ListOfBookings
    {
        public ListOfBookings(ViewModel dataContext) 
        {
            InitializeComponent();
            DataContext = dataContext;
        }
    }
}