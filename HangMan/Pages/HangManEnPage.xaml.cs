using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;

namespace HangMan.Pages
{
    /// <summary>
    /// Логика взаимодействия для HangManEnPage.xaml
    /// </summary>
    public partial class HangManEnPage : Page
    {
        private string secretWord = "";
        private string guessedWord = "";
        private string wordListFileName = "Data\\list_of_words_en.txt";
        private int numberOfWrongs = 0;
        private int maxNumberOfWrongs = 8;
        private int lenWord;
        private readonly string gameLanguage = "en";

        public HangManEnPage(string customWord)
        {
            InitializeComponent();

            secretWord = Functional.SetSecretWord(gameLanguage, customWord, wordListFileName);
            lenWord = secretWord.Length;
            guessedWord = Functional.Encrypt(lenWord);
            txtWord.Text = guessedWord;

            setButtonsClick();
        }

        private void disableLetterButtons()
        {
            foreach (UIElement element in letterButtonGrid.Children)
            {
                if (element is Button)
                {
                    ((Button)element).IsEnabled = false;
                }
            }
        }

        private void setButtonsClick()
        {
            foreach (UIElement element in letterButtonGrid.Children)
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

            char supposedLetter = ((string)((Button)e.OriginalSource).Content)[0];

            if (secretWord.Contains(supposedLetter) == true)
            {
                guessedWord = Functional.SetLetterInWord(supposedLetter, secretWord, guessedWord);
                txtWord.Text = guessedWord;
            }
            else
            {
                numberOfWrongs++;
                changeImage(numberOfWrongs);
            }

            openResultPage();
        }

        private void changeImage(int numberOfWrongs)
        {
            if (numberOfWrongs <= maxNumberOfWrongs)
                forImage.Source = new BitmapImage(new Uri(String.Format("pack://application:,,,/images/white_wrong_{0}.png", numberOfWrongs)));
        }

        private void openResultPage()
        {
            if (Functional.IsVictory(numberOfWrongs, maxNumberOfWrongs, secretWord, guessedWord) == -1) // lose
            {
                NavigationService.Navigate(new ResultPage(gameLanguage, false, secretWord));
                NavigationService.RemoveBackEntry();
                disableLetterButtons();
            }

            if (Functional.IsVictory(numberOfWrongs, maxNumberOfWrongs, secretWord, guessedWord) == 1) // win
            {
                NavigationService.Navigate(new ResultPage(gameLanguage, true, secretWord));
                NavigationService.RemoveBackEntry();
                disableLetterButtons();
            }
        }
    }
}
