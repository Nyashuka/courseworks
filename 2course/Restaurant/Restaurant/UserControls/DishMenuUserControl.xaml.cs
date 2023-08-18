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

namespace Restaurant
{
    /// <summary>
    /// Interaction logic for Dish.xaml
    /// </summary>
    public partial class DishMenuUserControl : UserControl
    {
        public event Action <Dish>? OnAddPressed;
        public DishMenuUserControl()
        {
            InitializeComponent();
        }

        private void ButtonAdd_Click(object sender, RoutedEventArgs e)
        {
            Dish dish = (Dish)DishData.Tag;

            OnAddPressed?.Invoke(dish);
        }
    }
}
