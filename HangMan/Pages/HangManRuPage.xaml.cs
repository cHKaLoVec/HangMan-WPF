using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace HangMan.Pages
{
    /// <summary>
    /// Логика взаимодействия для HangManRuPage.xaml
    /// </summary>
    public partial class HangManRuPage : Page
    {
        private string secretWord = "";
        private string guessedWord = "";
        private string wordListFileName = "Data\\list_of_words_ru.txt";
        private int numberOfWrongs = 0;
        private int maxNumberOfWrongs = 8;
        private int lenWord;
        private readonly string gameLanguage = "ru";

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

        public HangManRuPage(string customWord)
        {
            InitializeComponent();

            secretWord = Functional.SetSecretWord(gameLanguage, customWord, wordListFileName);
            lenWord = secretWord.Length;
            guessedWord = Functional.Encrypt(lenWord);
            txtWord.Text = guessedWord;

            setButtonsClick(letterButtonGrid);
        }

        private void btnLetter_Click(object sender, RoutedEventArgs e)
        {
            checkLetterInWord(((string)((Button)e.OriginalSource).Content)[0]);
            ((Button)e.Source).IsEnabled = false;
        }

        private void changeImage(int numberOfWrongs)
        {
            if (numberOfWrongs <= maxNumberOfWrongs)
                forImage.Source = new BitmapImage(new Uri(String.Format("pack://application:,,,/images/white_wrong_{0}.png", numberOfWrongs)));
        }

        private void checkForVictory()
        {
            if (Functional.IsVictory(numberOfWrongs, maxNumberOfWrongs, secretWord, guessedWord) == -1) // lose
            {
                NavigationService.Navigate(new ResultPage(gameLanguage,false, secretWord));
                NavigationService.RemoveBackEntry();
                disableLetterButtons(letterButtonGrid);
            }

            if (Functional.IsVictory(numberOfWrongs, maxNumberOfWrongs, secretWord, guessedWord) == 1) // win
            {
                NavigationService.Navigate(new ResultPage(gameLanguage, true, secretWord));
                NavigationService.RemoveBackEntry();
                disableLetterButtons(letterButtonGrid);
            }
        }

        private void checkLetterInWord(char supposedLetter)
        {
            string newWord = "";

            // Checking for a letter in the word
            if (secretWord.Contains(supposedLetter) == true)
            {

                for (int i = 0; i < lenWord; i++)
                {
                    if (supposedLetter == secretWord[i])
                    {
                        newWord += supposedLetter;
                    }
                    else
                    {
                        newWord += guessedWord[i];
                    }
                }
                guessedWord = newWord;
                txtWord.Text = guessedWord;

            }
            else
            {
                numberOfWrongs++;
                changeImage(numberOfWrongs);
            }

            checkForVictory();
        }
    }
}