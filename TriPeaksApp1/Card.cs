using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TriPeaksApp1
{
    public class Card
    {
        public Point Position { get; set; }

        public int Val;
        public int Suit;
        public Bitmap bVal;
        public Bitmap bBack;
        private List<int> UpperCards = new List<int>();
        private List<int> LowerCards = new List<int>();
        public bool IsFree { get { return UpperCards.Count == 0 ? true : false; } }
        public bool RedyToSelect { get; set; }
        public bool InGame { get; set; }

        public Card(int _Val, int _Suit, Bitmap _bVal, Bitmap _bBack, Point _Position)
        {
            Val = _Val;
            Suit = _Suit;
            bVal = new Bitmap(_bVal);
            bBack = new Bitmap(_bBack);
            Position = _Position;
            UpperCards.Clear();
            LowerCards.Clear();
            RedyToSelect = true;
            InGame = false;
        }


        public Bitmap ShowCard() { return UpperCards.Count == 0 ? bVal : bBack; }

        public void AddUpperCard(int CardIndex) { UpperCards.Add(CardIndex); }
        public void DeleteUpperCard(int CardIndex) { UpperCards.Remove(CardIndex); }
        public List<int> GetUpperCards() { return UpperCards; }

        public void AddLowerCard(int CardIndex) { LowerCards.Add(CardIndex); }
        public void DeleteLowerCard(int CardIndex) { LowerCards.Remove(CardIndex); }
        public List<int> GetLowerCards() { return LowerCards; }


    }
}
