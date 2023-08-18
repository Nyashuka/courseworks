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
    /// Interaction logic for DishCreatorPage.xaml
    /// </summary>
    /// 
    public class IngredientDataGridElement
    {
        public Ingredient Ingredient { get; set; }
        public string Name { get; set; } = String.Empty;
        public string Weight { get; set; } = String.Empty;

        public IngredientDataGridElement(Ingredient ingredient, string ingredientName)
        {
            Ingredient = ingredient;
            Name = ingredientName;
        }
    }
    public partial class DishCreatorPage : Page
    {
        public event Action<Dish>? OnSaveDish;
        public DishCreatorPage(List<IngredientWeight> ingredients)
        {
            InitializeComponent();

            foreach (var ingredient in ingredients)
            {
                IngredientList.Items.Add(new IngredientDataGridElement(ingredient.Ingredient, ingredient.Ingredient.Name));
            }
            IngredientListDataGrid.ItemsSource = new List<IngredientDataGridElement>();
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            IngredientListDataGrid.Items.Remove(IngredientListDataGrid.SelectedItem);
        }

        private void ReceptIngredientAdd_Click(object sender, RoutedEventArgs e)
        {
            //.Add(IngredientList.SelectedItem);
            var oldList = (List<IngredientDataGridElement>)IngredientListDataGrid.ItemsSource;
            oldList.Add((IngredientDataGridElement)IngredientList.SelectedItem);
            IngredientListDataGrid.ItemsSource = null;
            IngredientListDataGrid.ItemsSource = oldList;
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            Dish dish = new Dish(Guid.NewGuid(), DishName.Text,
                                Convert.ToDouble(DishPrice.Text),
                                new Weight(Convert.ToDouble(DishWeight.Text),
                                UnitOfWeight.G));
            
            foreach (var item in IngredientListDataGrid.Items)
            {               
                var element = (IngredientDataGridElement)item;

                dish.AddIngredientInRecipe(new IngredientWeight(element.Ingredient, new Weight(Convert.ToDouble(element.Weight), UnitOfWeight.G)));
            }

            OnSaveDish?.Invoke(dish);
        }
    }
}
