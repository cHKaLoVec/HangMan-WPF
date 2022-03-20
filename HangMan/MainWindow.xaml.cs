using System;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using HangMan.Pages;

namespace HangMan
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();

            openMenuPage();
        }

        private void openMenuPage()
        {
            myFrame.Navigate(new MenuPage());
            btnBack.Visibility = Visibility.Hidden;
            btnRestart.Visibility = Visibility.Hidden;
        }

        private void Grid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            // Moving the window
            if (e.ChangedButton == MouseButton.Left)
            {
                this.DragMove();
            }
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            Environment.Exit(0);
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            openMenuPage();
        }

        private void myFrame_Navigating(object sender, NavigatingCancelEventArgs e)
        {
            btnBack.Visibility = Visibility.Visible;
        }
    }
}
