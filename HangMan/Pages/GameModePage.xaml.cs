using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace HangMan.Pages
{
    /// <summary>
    /// Interaction logic for HangManGameMode.xaml
    /// </summary>
    public partial class GameModePage : Page
    {
        private string gameLanguage;
        public GameModePage(string language)
        {
            InitializeComponent();

            gameLanguage = language.ToLower();
        }

        private void openGamePage(string language, string word)
        {
            switch (language)
            {
                case "en":
                    NavigationService.Navigate(new GameEnPage(word));
                    break;
                case "ru":
                    NavigationService.Navigate(new GameRuPage(word));
                    break;
            }
        }

        private void openGamePage(string language)
        {
            switch (language)
            {
                case "en":
                    NavigationService.Navigate(new GameEnPage());
                    break;
                case "ru":
                    NavigationService.Navigate(new GameRuPage());
                    break;
            }
        }

        private void btnPlayCustomWordMode_Click(object sender, RoutedEventArgs e)
        {
            string customWord = txtBoxCustomWord.Text.Trim().ToUpper();
            
            if (!HangManGame.IsCorrectWord(gameLanguage, customWord))
            {
                InfoWindow infoWindow = new InfoWindow("incorrect input", "", "#DF2A36");
                infoWindow.Show();
                return;
            }

            openGamePage(gameLanguage, customWord);
        }

        private void btnPlayClassicMode_Click(object sender, RoutedEventArgs e)
        {
            openGamePage(gameLanguage);
        }
    }
}