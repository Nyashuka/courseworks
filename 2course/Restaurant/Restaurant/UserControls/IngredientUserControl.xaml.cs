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
    /// Interaction logic for IngredientUserControl.xaml
    /// </summary>
    public partial class IngredientUserControl : UserControl
    {
        public event Action<IngredientWeight>? OnDeleteEvent;
        public event Action<IngredientWeight>? OnEditEvent;

        public IngredientUserControl()
        {
            InitializeComponent();
        }

        private void ButtonEdit_Click(object sender, RoutedEventArgs e)
        {
            IngredientWeight ingredient = (IngredientWeight)IngredientData.Tag;

            OnEditEvent?.Invoke(ingredient);
        }

        private void ButtonDelete_Click(object sender, RoutedEventArgs e)
        {
            IngredientWeight dish = (IngredientWeight)IngredientData.Tag;

            OnDeleteEvent?.Invoke(dish);
        }
    }
}
