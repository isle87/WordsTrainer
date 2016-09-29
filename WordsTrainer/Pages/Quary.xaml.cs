using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WordsTrainer.Core;

namespace WordsTrainer.Pages
{
    /// <summary>
    /// Interaktionslogik für Quary.xaml
    /// </summary>
    public partial class Quary : Page
    {
        CardManager cm;
        Card card;
        bool clear = true;
        public Quary(CardManager CM)
        {
            InitializeComponent();

            // Object erhalten
            cm = CM;
            card = cm.GetCard();

            // Vorbereitung der Elemente
            if (card.IsPreposition())
                tbxAnswerPreposition.Visibility = Visibility.Collapsed;

            // Befüllen der Daten
            txtQuestionWord.Text = card.GermanWord;
            txtQuestionSentence.Text = card.GermanSentence;
            txtAnswerPreposition.Text = card.Preposition;
            txtAnswerWord.Text = card.EnglishWord;
            txtSentenceEnglisch.Text = card.EnglishSentence;
            txtQueries.Text = card.Score();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new MainPage());
        }

        private void CheckAnswer_Click(object sender, RoutedEventArgs e)
        {
            // Abfrage (Soll automatisch passieren. Events - da Weg nach oben)
            if (!card.CheckWord(tbxAnswerWord.Text))
                tbxAnswerWord.Background = Brushes.Pink;

            // Visuelle Reacktion
            txtAnswerPreposition.Visibility = Visibility.Visible;
            txtAnswerWord.Visibility = Visibility.Visible;
            txtSentenceEnglisch.Visibility = Visibility.Visible;
        }

        private void ShowSentence_Click(object sender, RoutedEventArgs e)
        {
            txtQuestionSentence.Visibility = Visibility.Visible;
            Button but = sender as Button;
            but.Visibility = Visibility.Collapsed;
        }

        private void tbxAnswerWord_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBox tb = sender as TextBox;
            if (clear)
            {
                tb.Text = "";
                clear = false;
            }
        }
    }
}
