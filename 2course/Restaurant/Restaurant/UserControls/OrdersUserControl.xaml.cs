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
    /// Interaction logic for OrdersUserControl.xaml
    /// </summary>
    public partial class OrdersUserControl : UserControl
    {
        public event Action<DateTimeContainer, DishCount>? OnCancelPressed;
        public event Action<DateTimeContainer, DishCount>? OnFinishPressed;

        public OrdersUserControl()
        {
            InitializeComponent();

        }
        
        private void ButtonCancel_Click(object sender, RoutedEventArgs e)
        {
            DishCount dish = (DishCount)DishCountData.Tag;
            DateTimeContainer date = (DateTimeContainer)CookDate.Tag;

            OnCancelPressed?.Invoke(date, dish);
        }

        private void ButtonFinish_Click(object sender, RoutedEventArgs e)
        {
            DishCount dish = (DishCount)DishCountData.Tag;
            DateTimeContainer date = (DateTimeContainer)CookDate.Tag;

            OnFinishPressed?.Invoke(date, dish);
        }
    }
}
