using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HangMan
{
    internal class Functional
    {
        public static string Encrypt(int length)
        {
            return new string('-', length);
        }

        public static bool IsEnglishLetter(string word)
        {
            for (int i = 0; i < word.Length; i++)
            {
                if (word[i] <= 'A' || word[i] >= 'Z')
                {
                    return false;
                }
            }

            return true;
        }

        public static bool IsRussianLetter(string word)
        {
            for (int i = 0; i < word.Length; i++)
            {
                if (word[i] <= 'А' || word[i] >= 'Я')
                {
                    return false;
                }
            }

            return true;
        }

        public static bool IsCorrectWord(string language, string word)
        {

            if (string.IsNullOrEmpty(word))
                return false;

            if (language == "en" && IsEnglishLetter(word))
                return true;

            if (language == "ru" && IsRussianLetter(word))
                return true;

            return false;
        }

        public static string LoadWord(string language, string wordListFileName)
        {
            language = language.ToLower();
            string[] words;

            if (language == "ru")
            {
                if (File.Exists(wordListFileName))
                {
                    words = File.ReadAllLines(wordListFileName);
                }
                else
                {
                    words = new string[] { "имя", "область", "статья", "число", "компания", "народ", "жена", "группа", "развитие", "процесс", "суд" };
                }

                int n = words.Length;
                Random rand = new Random();
                string word;

                while (true)
                {
                    word = words[rand.Next(0, n - 1)].ToUpper();
                    if (IsCorrectWord(language, word))
                        break;
                }

                return word;
            }

            if(language == "en")
            {
                if (File.Exists(wordListFileName))
                {
                    words = File.ReadAllLines(wordListFileName);
                }
                else
                {
                    words = new string[] { "aspect", "attitude", "director", "personality", "psychology", "recommendation", "response", "selection", "storage", "version", "alcohol", "argument", "complaint", "contract", "emphasis", "highway", "loss", "membership", "possession", "preparati" };
                }

                int n = words.Length;
                Random rand = new Random();
                string word;

                while (true)
                {
                    word = words[rand.Next(0, n - 1)].ToUpper();
                    if (IsCorrectWord(language, word))
                        break;
                }

                return word;
            }

            return "";
        }

        public static string pravda(string wordListFileName)
        {
            string[] words;
            if (File.Exists(wordListFileName))
            {
                words = File.ReadAllLines(wordListFileName);
                return "true";
            }
            return "false";
        }

        public static string SetSecretWord(string language, string customWord, string wordListFileName)
        {
            if (customWord != "")
                return customWord;
            return LoadWord(language, wordListFileName);
        }

        public static sbyte IsVictory(int numberOfWrongs, int maxNumberOfWrongs, string secretWord, string guessedWord)
        {
            if (numberOfWrongs == maxNumberOfWrongs) // lose
                return -1;
            if (guessedWord == secretWord) // win
                return 1;
            return 0;
        }
    }
}
