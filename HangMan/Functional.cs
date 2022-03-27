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
    }
}
