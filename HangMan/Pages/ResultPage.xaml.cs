using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;

namespace HangMan.Pages
{
    /// <summary>
    /// Логика взаимодействия для ResultPage.xaml
    /// </summary>
    public partial class ResultPage : Page
    {
        private string gameLanguage;
        public ResultPage(string language, bool victory, string word)
        {
            InitializeComponent();

            gameLanguage = language;

            if (victory)
            {
                txtVictory.Text = "YOU WIN";
                txtVictory.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#5ED05E"));
                myImage.Source = new BitmapImage(new Uri("pack://application:,,,/images/white_victory.png"));
            }
            else
            {
                txtVictory.Text = "YOU LOSE";
                txtVictory.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#DF2A36"));
                myImage.Source = new BitmapImage(new Uri("pack://application:,,,/images/white_wrong_8.png"));
            } 

            txtWord.Text = word;
        }

        private void btnGoMenu_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new MenuPage());
            NavigationService.RemoveBackEntry();
        }

        private void btnRestart_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new GameModePage(gameLanguage));
            NavigationService.RemoveBackEntry();
        }
    }
}
