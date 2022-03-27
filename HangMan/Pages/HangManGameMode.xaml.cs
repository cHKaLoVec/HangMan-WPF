﻿using System.Windows;
using System;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace HangMan.Pages
{
    /// <summary>
    /// Interaction logic for HangManGameMode.xaml
    /// </summary>
    public partial class HangManGameMode : Page
    {
        private string gameLanguage;
        public HangManGameMode(string language)
        {
            InitializeComponent();
            
            gameLanguage = language.ToLower();
        }

        private void openGamePage(string language, string word)
        {
            switch (language)
            {
                case "en":
                    NavigationService.Navigate(new HangManEnPage(word));
                    NavigationService.RemoveBackEntry();
                    break;
                case "ru":
                    NavigationService.Navigate(new HangManRuPage(word));
                    NavigationService.RemoveBackEntry();
                    break;
            }
        }

        private void btnPlayCustomWordMode_Click(object sender, RoutedEventArgs e)
        {
            string customWord = txtBoxCustomWord.Text.Trim().ToUpper();
            if (!Functional.IsCorrectWord(gameLanguage, customWord))
            {
                InfoWindow infoWindow = new InfoWindow("incorrect input", "", "#DF2A36");
                infoWindow.Show();
                MessageBox.Show(customWord);
                return;
            }

            openGamePage(gameLanguage, customWord);
        }

        private void btnPlayClassicMode_Click(object sender, RoutedEventArgs e)
        {
            openGamePage(gameLanguage, "");
        }
    }
}
