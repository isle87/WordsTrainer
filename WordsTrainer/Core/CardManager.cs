using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace WordsTrainer.Core
{
    public class CardManager
    {
        public List<Card> Cards = new List<Card>();

        public CardManager()
        {
            Card card = new Card("beschaffen", "procure");
            card.GermanSentence = "Ich beschaffe mir einen besseren Job";
            card.EnglishSentence = "I procure me a better Job";
            Cards.Add(card);
            card = new Card("zugeben", "admit");
            card.GermanSentence = "Ich gebe zu, dass ich geil bin";
            card.EnglishSentence = "I admit that I am awesome";
            Cards.Add(card);
        }

        public Card GetCard()
        {
            Random r = new Random();
            return Cards[r.Next(0, Cards.Count)];
        }

        public void Serialize()
        {
            XmlSerializer xml = new XmlSerializer(typeof(List<Card>));
            using (StreamWriter writer = new StreamWriter("test.xml"))
            {
                xml.Serialize(writer, Cards);
            }
        }
    }
}
