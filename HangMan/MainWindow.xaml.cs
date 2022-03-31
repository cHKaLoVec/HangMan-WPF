using System;
using System.Windows;
using System.Windows.Input;
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
            HideBackButton();
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
            UnhideBackButton();
            myFrame.GoBack();
        }

        public void HideBackButton()
        {
            btnBack.Visibility = Visibility.Hidden;
        }

        public void UnhideBackButton()
        {
            btnBack.Visibility = Visibility.Visible;
        }

        private void myFrame_Navigating(object sender, NavigatingCancelEventArgs e)
        {
            if(myFrame.CanGoBack)
                UnhideBackButton();

            if(!myFrame.CanGoBack)
                HideBackButton();
        }
    }
}
