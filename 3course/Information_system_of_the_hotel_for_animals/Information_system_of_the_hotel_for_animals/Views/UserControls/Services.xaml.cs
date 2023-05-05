using System.Windows.Controls;
using Information_system.ViewModels.Base;

namespace Information_system_of_the_hotel_for_animals.Views.UserControls
{
    public partial class Services : UserControl
    {
        public Services(ViewModel dataContext)
        {
            InitializeComponent();
            DataContext = dataContext;
        }
    }
}