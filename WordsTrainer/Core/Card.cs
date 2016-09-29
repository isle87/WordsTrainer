using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordsTrainer.Core
{
    public class Card
    {
        public static int test;

        public Card(string germanWord, string englishWord)
        {
            GermanWord = germanWord;
            EnglishWord = englishWord;
            LastRightAnswer = new DateTime();
            LastRightAnswer = DateTime.Now;
            LastAnswerRight = false;
            Box = 1;
            test = 123;
        }

        public Card() : this("", "") { }

        public int Box { get; set; }
        public int CountRequest { get; set; }
        public string EnglishSentence { get; set; }
        public string EnglishWord { get; set; }
        public string GermanSentence { get; set; }
        public string GermanWord { get; set; }
        public string[] Irregular { get; set; } = new string[2];
        public bool LastAnswerRight { get; set; }
        public DateTime LastRightAnswer { get; set; }
        public string Preposition { get; set; }
        public int RightAnswers { get; set; }


        public bool CheckWord(string englischWord)
        {
            return englischWord.ToLower() == EnglishWord.ToLower();
        }

        public bool IsPreposition()
        {
            return Preposition != string.Empty;
        }

        /// <summary>
        /// Resets the date of the last right answer.
        /// </summary>
        public void ResetDate()
        {
            LastRightAnswer = DateTime.Now;
        }

        public string Score()
        {
            return RightAnswers.ToString() + " / " + CountRequest.ToString();
        }

        /// <summary>
        /// Sets the irregular verbs.
        /// </summary>
        /// <param name="irregOne">The irregular verb one.</param>
        /// <param name="irregTwo">The irregular verb two.</param>
        public void SetIrregular(string irregOne, string irregTwo)
        {
            Irregular[0] = irregOne;
            Irregular[1] = irregTwo;
        }

        /// <summary>
        /// Sets the irregular verb.
        /// </summary>
        /// <param name="irregular">The irregular verb.</param>
        public void SetIrregular(string irregular)
        {
            SetIrregular(irregular, "");
        }
    }
}
