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
    /// Interaction logic for IngredientCreatorPage.xaml
    /// </summary>
    public partial class IngredientCreatorPage : Page
    {
        public event Action<IngredientWeight>? OnSaveIngredient;
        public IngredientCreatorPage()
        {
            InitializeComponent();
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            Ingredient ingredient = new Ingredient(Guid.NewGuid(), IngredientName.Text, Convert.ToDouble(IngredientPrice.Text));

            OnSaveIngredient?.Invoke(new IngredientWeight(ingredient, new Weight(Convert.ToDouble(IngredientWeight.Text), UnitOfWeight.G)));
        }
    }
}
