using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;

namespace HangMan.Pages
{
    /// <summary>
    /// Логика взаимодействия для MenuPage.xaml
    /// </summary>
    public partial class MenuPage : Page
    {
        public MenuPage()
        {
            InitializeComponent();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            menuImage.Source = new BitmapImage(new Uri("pack://application:,,,/images/white_wrong_8.png"));
        }

        private void btnPlayRu_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new GameModePage("ru"));
            NavigationService.RemoveBackEntry();
        }

        private void btnPlayEn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new GameModePage("en"));
            NavigationService.RemoveBackEntry();
        }

        private void btnGameRules_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new ResultPage("en", true, "hello"));
            NavigationService.RemoveBackEntry();
        }
    }
}
