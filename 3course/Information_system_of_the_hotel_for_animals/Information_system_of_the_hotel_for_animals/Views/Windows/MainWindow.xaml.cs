using System;
using System.Windows;
using System.Windows.Input;

namespace Information_system_of_the_hotel_for_animals.Views.Windows
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void ButtonFechar_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void ButtonFullScreen_Click(object sender, RoutedEventArgs e)
        {
            if (Application.Current.MainWindow!.WindowState == WindowState.Normal)
                Application.Current.MainWindow.WindowState = WindowState.Maximized;
            else
                Application.Current.MainWindow.WindowState = WindowState.Normal;
        }

        private void ButtonMinimized_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.MainWindow!.WindowState = WindowState.Minimized;
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