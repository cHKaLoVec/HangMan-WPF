using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace HangMan.Pages
{
    /// <summary>
    /// Логика взаимодействия для HangManRuPage.xaml
    /// </summary>
    public partial class GameRuPage : Page
    {
        private string _wordListFileName = "Data\\list_of_words_ru.txt";

        private static readonly string gameLanguage = "ru";

        HangManGame game = new HangManGame(gameLanguage);

        public GameRuPage(string customWord)
        {
            InitializeComponent();
            
            game.SetCustomWord(customWord);

            StartGame();
        }

        public GameRuPage()
        {
            InitializeComponent();
            
            game.SetWordFromFile(_wordListFileName);

            StartGame();
        }

        private void StartGame()
        {
            game.EncryptWord();

            txtWord.Text = game.GuessedWord;

            setButtonsClick(letterButtonGrid);
        }

        private void disableLetterButtons(Grid grid)
        {
            foreach (UIElement element in grid.Children)
            {
                if (element is Button)
                {
                    ((Button)element).IsEnabled = false;
                }
            }
        }

        private void setButtonsClick(Grid grid)
        {
            foreach (UIElement element in grid.Children)
            {
                if (element is Button)
                {
                    ((Button)element).Click += btnLetter_Click;
                }
            }
        }

        private void btnLetter_Click(object sender, RoutedEventArgs e)
        {
            ((Button)e.Source).IsEnabled = false;

            char suggestedLetter =  ((string)((Button)e.OriginalSource).Content).Trim().ToUpper()[0];
            
            if(game.GetStatus() == Status.GameIsUnfinished)
            {
                game.SuggestLetter(suggestedLetter);
                txtWord.Text=game.GuessedWord;
                changeImage(game.NumberOfWrongs);
            }

            openResultPage();
        }

        private void changeImage(int numberOfWrongs)
        {
            if (numberOfWrongs <= game.MaxNumberOfWrongs)
                forImage.Source = new BitmapImage(new Uri(String.Format("pack://application:,,,/images/white_wrong_{0}.png", numberOfWrongs)));
        }

        private void openResultPage()
        {
            if (game.GetStatus() == Status.Defeat) // defeat
            {
                NavigationService.Navigate(new ResultPage(gameLanguage, false, game.SecretWord));
                disableLetterButtons(letterButtonGrid);
            }

            if (game.GetStatus() == Status.Victory) // victory
            {
                NavigationService.Navigate(new ResultPage(gameLanguage, true, game.SecretWord));
                disableLetterButtons(letterButtonGrid);
            }
        }
    }
}