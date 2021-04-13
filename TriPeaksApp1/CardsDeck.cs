using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TriPeaksApp1
{
    public class CardsDeck
    {
        public List<Card> Cards = new List<Card>();

        public CardsDeck()
        {
            Cards.Clear();
        }

        public void CreateDeck()
        {
            Bitmap CardBack = new Bitmap(36, 50);
            using (Graphics g = Graphics.FromImage(CardBack))
            {
                g.Clear(Color.Transparent);
                g.DrawImage(res.cards_suite3, new Rectangle(0, 0, 36, 50), new Rectangle(13 * 36, 3 * 50, 36, 50), GraphicsUnit.Pixel);
            }
            Random rnd = new Random();
            int r = 0;
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 13; j++)
                {

                    Cards.Add(new Card(j+2, i, GetCardSuite(i, j), CardBack, new Point(j * 36, i * 50)));
                    //r = rnd.Next(100);
                    //if (r < 30) Cards[j + (i * 13)].AddUpperCard(1);
                }
            }
        }

        private Bitmap GetCardSuite(int suite, int value)
        {
            Bitmap bmp = new Bitmap(36, 50);
            using (Graphics gfx = Graphics.FromImage(bmp))
            {
                gfx.Clear(Color.Transparent);
                gfx.DrawImage(res.cards_suite3, new Rectangle(0, 0, 36, 50), new Rectangle(value * 36, suite * 50, 36, 50), GraphicsUnit.Pixel);
            }
            return bmp;
        }





    }
}
