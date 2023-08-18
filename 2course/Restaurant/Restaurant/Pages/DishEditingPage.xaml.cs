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
    /// Interaction logic for DishEditingPage.xaml
    /// </summary>
    public partial class DishEditingPage : Page
    {
        public event Action? OnCreateButtonClick;
        public event Action? OnSaveChangesEvent;
        public DishEditingPage()
        {
            InitializeComponent();
            
        }

        private void CreateDishButton_Click(object sender, RoutedEventArgs e)
        {
            OnCreateButtonClick?.Invoke();
        }

        private void SaveChanges_Click(object sender, RoutedEventArgs e)
        {
            OnSaveChangesEvent?.Invoke();
        }
    }
}
