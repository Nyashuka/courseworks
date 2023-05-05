using System.Windows.Controls;
using Information_system.ViewModels.Base;

namespace Information_system_of_the_hotel_for_animals.Views.UserControls
{
    public partial class TypesOfRooms : UserControl
    {
        public TypesOfRooms(ViewModel dataContext)
        {
            InitializeComponent();
            DataContext = dataContext;
        }
    }
}