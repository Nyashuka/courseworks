using System.Windows.Controls;
using Information_system_of_the_hotel_for_animals.Views.UserControls.Base;
using Information_system.ViewModels.Base;

namespace Information_system_of_the_hotel_for_animals.Views.UserControls
{
    public partial class Employees 
    {
        public Employees(ViewModel dataContext)
        {
            InitializeComponent();
            DataContext = dataContext;
        }
    }
}