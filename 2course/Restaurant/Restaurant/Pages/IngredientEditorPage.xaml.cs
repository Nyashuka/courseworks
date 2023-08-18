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
    /// Interaction logic for IngredientEditorPage.xaml
    /// </summary>
    public partial class IngredientEditorPage : Page
    {
        public event Action<IngredientWeight>? OnSaveIngredient;

        public IngredientEditorPage(IngredientWeight ingredient)
        {
            InitializeComponent();

            IngredientData.Tag = ingredient;

            IngredientName.Text = ingredient.Ingredient.Name;
            IngredientPrice.Text = ingredient.Ingredient.PricePerOneKilogram.ToString();
            IngredientWeight.Text = ingredient.Weight.Amount.ToString();
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {

            IngredientWeight ingredient = (IngredientWeight)IngredientData.Tag;

            Ingredient newIngredientData = new Ingredient(ingredient.Ingredient.Id, IngredientName.Text, Convert.ToDouble(IngredientPrice.Text));

            OnSaveIngredient?.Invoke(new IngredientWeight(newIngredientData, new Weight(Convert.ToDouble(IngredientWeight.Text), UnitOfWeight.G)));
        }
    }
}
