using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HangMan
{
    public enum Status
    {
        Victory,
        Defeat,
        GameIsUnfinished
    }

    internal class HangManGame
    {
        public string SecretWord { get; private set; }
        public string GuessedWord { get; private set; }
        public int NumberOfWrongs { get; private set; }
        public string GameLanguage { get; set; }
        public int MaxNumberOfWrongs { get; } = 8;

        public HangManGame(string gameLanguage)
        {
            GameLanguage = gameLanguage.ToLower();
        }

        public void EncryptWord()
        {
            GuessedWord = new string('-', SecretWord.Length);
        }


        public bool IsWordOfLettersInBetween(char firstChar, char lastChar)
        {
            for (int i = 0; i < SecretWord.Length; i++)
            {
                if (SecretWord[i] < firstChar && SecretWord[i] > lastChar)
                {
                    return false;
                }
            }

            return true;
        }

        public bool IsCorrectWord()
        {

            if (string.IsNullOrEmpty(SecretWord))
                return false;

            if (GameLanguage == "en" && IsWordOfLettersInBetween('A', 'Z'))
                return true;

            if (GameLanguage == "ru" && IsWordOfLettersInBetween('А', 'Я'))
                return true;

            return false;
        }

        public void SetCustomWord(string customWord)
        {
            SecretWord = customWord.ToUpper();
        }

        public void SetWordFromFile(string wordListFileName)
        {
            string[] words = new string[] { };

            switch (GameLanguage)
            {
                case "ru":
                    words = new string[]
                    {
                        "имя", "область", "статья", "число", "компания", "народ",
                        "жена", "группа", "развитие", "процесс", "суд"
                    };
                    break;

                case "en":
                    words = new string[]
                    {
                        "aspect", "attitude", "director", "personality", "psychology", "recommendation", "response",
                        "selection", "storage", "version", "alcohol", "argument", "complaint", "contract", "emphasis",
                        "highway", "loss", "membership", "possession"
                    };
                    break;
            }

            if (File.Exists(wordListFileName))
            {
                words = File.ReadAllLines(wordListFileName);
            }

            Random rand = new Random();

            while (true)
            {
                SecretWord = words[rand.Next(0, words.Length - 1)].ToUpper();
                if (IsCorrectWord())
                    break;
            }
        }

        public void SuggestLetter(char suggestedLetter)
        {
            if (SecretWord.Contains(suggestedLetter))
            {
                string newWord = "";

                for (int i = 0; i < SecretWord.Length; i++)
                {
                    if (suggestedLetter == SecretWord[i])
                        newWord += suggestedLetter;
                    else
                        newWord += GuessedWord[i];
                }

                GuessedWord = newWord;
            }
            else
            {
                NumberOfWrongs++;
            }
        }

        public Status GetStatus()
        {
            if (NumberOfWrongs == MaxNumberOfWrongs) // defeat
                return Status.Defeat;

            if (GuessedWord == SecretWord) // victory
                return Status.Victory;

            return Status.GameIsUnfinished;
        }
    }
}
