using System;
using System.Collections.Generic;
using System.IO;
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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        // pages
        private MainPage _mainPage = new MainPage();
        private OrdersPage _ordersPage = new OrdersPage();
        private DishEditingPage _listOfDishesPage = new DishEditingPage();
        private IngredientsPage _ingredientsPage = new IngredientsPage();
        // services
        private Storage _storage = new Storage();
        private CookingPlan _cookingPlan = new CookingPlan();
        //private BudgetCalculator _budgetCalculator = new BudgetCalculator(new List<Taxe>());
        private DataLoader _dataLoader = new DataLoader("cooking_list.json", "storage.json");

        public MainWindow()
        {
            InitializeComponent();

            MainFrame.Content = _mainPage;
            MainFrame.NavigationUIVisibility = NavigationUIVisibility.Hidden;

            _cookingPlan = _dataLoader.LoadCookingPlan();
            _storage = _dataLoader.LoadStorage();
        
            SignEvents();

            ShowMenuOfDishes(_storage.Menu);
            ShowDishes(_storage.Menu);
            ShowOrders(_cookingPlan.Orders);
            ShowIngredients(_storage.Ingredients);
        }

        public void SaveAllData()
        {
            _dataLoader.SaveCookingPlan(_cookingPlan);
            _dataLoader.SaveStorage(_storage);
        }

        public void DeleteDishFromMenu(Dish dish)
        {
            _storage.Menu.Remove(dish);
            ShowDishes(_storage.Menu);
        }

        public void GoPageToCreatingDish()
        {
            DishCreatorPage dishCreatorPage = new DishCreatorPage(_storage.Ingredients.ToList());
            dishCreatorPage.OnSaveDish += AddNewDish;
            ChangePage(dishCreatorPage);
        }

        public void GoPageToCreatingIngredient()
        {
            IngredientCreatorPage ingredientCreatorPage = new IngredientCreatorPage();
            ingredientCreatorPage.OnSaveIngredient += AddNewIngredien;
            ChangePage(ingredientCreatorPage);
        }

        private void SignEvents()
        {
            _listOfDishesPage.OnCreateButtonClick += GoPageToCreatingDish;
            _listOfDishesPage.OnSaveChangesEvent += SaveAllData;

            _ingredientsPage.OnCreatIngredientClick += GoPageToCreatingIngredient;
            _ingredientsPage.OnSaveChangesEvent += SaveAllData;
        }
    

        public void AddNewDish(Dish dish)
        {
            _storage.Menu.Add(dish);
            ShowDishes(_storage.Menu);
            ChangePage(_listOfDishesPage);
        }

        public void AddNewIngredien(IngredientWeight ingredient)
        {
            _storage.Ingredients.Add(ingredient);
            ShowIngredients(_storage.Ingredients);
            ChangePage(_ingredientsPage);
        }

        public void AddOldIngredien(Ingredient ingredient)
        {
           
            ShowDishes(_storage.Menu);
            ChangePage(_listOfDishesPage);
        }

        public void EditIngredient(IngredientWeight ingredient)
        {
            _storage.Ingredients.Remove(ingredient);
            _storage.Ingredients.Add(ingredient);
            ShowIngredients(_storage.Ingredients);
            ChangePage(_ingredientsPage);
        }

        public void DeleteIngredientFromStorage(IngredientWeight ingredient)
        {
            _storage.Ingredients.Remove(ingredient);
            ShowIngredients(_storage.Ingredients);
        }

        public void EditIngredientInStorage(IngredientWeight ingredient)
        {
            IngredientEditorPage ingredientEditorPage = new IngredientEditorPage(ingredient);

            ingredientEditorPage.OnSaveIngredient += EditIngredient;

            ChangePage(ingredientEditorPage);
        }

        private void ShowMenuOfDishes(List<Dish> dishes)
        {
            _mainPage.DishesListStackPanel.Children.Clear();

            foreach (var dish in dishes)
            {
                int countDishCanCook = _storage.GetCountDishCanCook(dish.Recipe);

                if (countDishCanCook <= 0)
                    continue;
                
                DishMenuUserControl dishUserControl = new DishMenuUserControl();
                //Uri fileUri = new Uri(Directory.GetCurrentDirectory() + "/dish_images/" + dish.Id + ".jpg");
                //dishUserControl.DishImage.Source = new BitmapImage(fileUri);

                dishUserControl.DishData.Tag = dish;
                dishUserControl.DishName.Text = dish.Name;
                dishUserControl.DishIngredients.Text = dish.RecipeToString();
                dishUserControl.DishPrice.Text = dish.PricePerServing + "грн.";
                dishUserControl.DishCount.Text = "Можна приготувати: " + countDishCanCook + "шт.";
                dishUserControl.OnAddPressed += AddOrder;

                _mainPage.DishesListStackPanel.Children.Add(dishUserControl);
            }
        }

        private void ShowDishes(List<Dish> dishes)
        {
            _listOfDishesPage.DishesListStackPanel.Children.Clear();

            foreach (var dish in dishes)
            {
                DishUserControl dishUserControl = new DishUserControl();

                string imagePath = Directory.GetCurrentDirectory() + "/dish_images/" + dish.Id + ".jpg";
                if (File.Exists(imagePath))
                {
                    Uri fileUri = new Uri(imagePath);
                    dishUserControl.DishImage.Source = new BitmapImage(fileUri);
                }

                dishUserControl.DishData.Tag = dish;
                dishUserControl.DishName.Text = dish.Name;
                dishUserControl.DishIngredients.Text = dish.RecipeToString();
                dishUserControl.DishPrice.Text = dish.PricePerServing + "грн.";
                dishUserControl.OnDeleteEvent += DeleteDishFromMenu;

                _listOfDishesPage.DishesListStackPanel.Children.Add(dishUserControl);
            }
        }

        private void ShowOrders(HashSet<Order> orders)
        {
            _ordersPage.OrdersListStackPanel.Children.Clear();

            foreach (var order in orders)
            {
                foreach (var dish in order.Dishes)
                {
                    OrdersUserControl dishUserControl = new OrdersUserControl();
                    //Uri fileUri = new Uri(Directory.GetCurrentDirectory() + "/dish_images/" + dish.Dish.Id + ".jpg");
                    //dishUserControl.DishImage.Source = new BitmapImage(fileUri);

                    dishUserControl.DishCountData.Tag = dish;
                    dishUserControl.CookDate.Tag = order.Date;
                    dishUserControl.DishName.Text = dish.Dish.Name;
                    dishUserControl.DishIngredients.Text = dish.Dish.RecipeToString();
                    dishUserControl.DishPrice.Text = dish.Dish.PricePerServing + "грн.";
                    dishUserControl.DishCount.Text = "Треба приготувати: " + dish.Count + "шт.";
                    dishUserControl.CookDate.Text = "Дата для приготування: " + order.Date.ToString();

                    dishUserControl.OnCancelPressed += CancelOrder;
                    dishUserControl.OnFinishPressed += FinishOrder;

                    _ordersPage.OrdersListStackPanel.Children.Add(dishUserControl);
                }
            }
        }

        private void ShowIngredients(HashSet<IngredientWeight> ingredients)
        {
            _ingredientsPage.IngredientsListStackPanel.Children.Clear();

            foreach (var ingredient in ingredients)
            {
                IngredientUserControl ingredientUserControl = new IngredientUserControl();

                ingredientUserControl.IngredientData.Tag = ingredient;
                ingredientUserControl.IngredientName.Text = ingredient.Ingredient.Name;
                ingredientUserControl.IngredientPrice.Text = ingredient.Ingredient.PricePerOneKilogram + "грн.";
                ingredientUserControl.IngredientWeight.Text = ingredient.Weight.ToString();
                ingredientUserControl.OnDeleteEvent += DeleteIngredientFromStorage;
                ingredientUserControl.OnEditEvent += EditIngredientInStorage;

                _ingredientsPage.IngredientsListStackPanel.Children.Add(ingredientUserControl);
            }
        }

        private void AddOrder(Dish dish)
        {
            _cookingPlan.AddDishInOrder(new DateTimeContainer(), new DishCount(dish, 1));
            _storage.DecreaseIngredients(dish.Recipe);
            ShowMenuOfDishes(_storage.Menu);
        }

        private void CancelOrder(DateTimeContainer date, DishCount dish)
        {
            _cookingPlan.RemoveDishFromOrder(date, new DishCount(dish.Dish,1));
            _storage.IncreaseIngredients(dish.Dish.Recipe);
            ShowOrders(_cookingPlan.Orders);
        }

        private void FinishOrder(DateTimeContainer date, DishCount dish)
        {
            _cookingPlan.RemoveDishFromOrder(date, new DishCount(dish.Dish, 1));        
            ShowOrders(_cookingPlan.Orders);
        }

        private void ToMenuButton_Click(object sender, RoutedEventArgs e)
        {
            ChangePage(_mainPage);
        }

        private void ToListOfOrders_Click(object sender, RoutedEventArgs e)
        {
            ChangePage(_listOfDishesPage);
        }

        public void ChangePage(Page page)
        {
            MainFrame.Content = page;
        }

        private void ButtonFechar_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
        private void ButtonFullScreen_Click(object sender, RoutedEventArgs e)
        {
            if (Application.Current.MainWindow.WindowState == WindowState.Normal)
                Application.Current.MainWindow.WindowState = WindowState.Maximized;
            else
                Application.Current.MainWindow.WindowState = WindowState.Normal;
        }

        private void ButtonMinimized_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.MainWindow.WindowState = WindowState.Minimized;

        }

        private void ListViewMenu_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int index = ListViewMenu.SelectedIndex;
            MoveCursorMenu(index);

            switch (index)
            {
                case 0:
                    ShowMenuOfDishes(_storage.Menu);
                    ChangePage(_mainPage);
                    break;
                case 1:
                    ShowOrders(_cookingPlan.Orders);
                    ChangePage(_ordersPage);
                    break;
                case 2:
                    ShowDishes(_storage.Menu);
                    ChangePage(_listOfDishesPage);
                    break;
                case 3:
                    ShowIngredients(_storage.Ingredients);
                    ChangePage(_ingredientsPage);
                    break;
                default:
                    break;
            }
        }

        private void MoveCursorMenu(int index)
        {
            TrainsitionigContentSlide.OnApplyTemplate();
            GridCursor.Margin = new Thickness(0, (100 + (60 * index)), 0, 0);
        }

        private void Grid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            try
            {
                DragMove();
            }
            catch (Exception)
            {

                return;
            }
        }
    }
}
