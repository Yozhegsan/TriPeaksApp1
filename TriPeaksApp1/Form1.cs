using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TriPeaksApp1
{
    public partial class Form1 : Form
    {
        Bitmap bmp = new Bitmap(800, 600);
        Graphics gfx;

        double c = 0;

        public CardsDeck MainCardsDeck;

        public List<Card> CurCards = new List<Card>();


        bool DoneFlag = true;

        public Form1()
        {
            gfx = Graphics.FromImage(bmp);
            gfx.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            MainCardsDeck = new CardsDeck();
            MainCardsDeck.CreateDeck();



        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            //pic.Image = MainCardsDeck.Cards[36].ShowCard(false);
            MakeCurCardsDeck();

            //MakeKadr();
            tmrKadr.Enabled = true;
        }

        private void MakeKadr()
        {
            //return;

            if (!DoneFlag) return;
            DoneFlag = false;
            gfx.Clear(Color.Transparent);
            //-----------------------------------------------------------------------------------------------------
            int x = 0;
            int y = 0;
            for (int i = 0; i < 52; i++)
            {
                gfx.DrawImage(CurCards[i].ShowCard(), x * 46, y * 60);
                x++;
                if (x == 13)
                {
                    x = 0;
                    y++;
                }
            }
            //=====================================================================================================
            pic.Image = bmp;
            DoneFlag = true;
        }

        private void MakeCurCardsDeck()
        {
            int GotoCount = 0;
            int tmp = -1;
            int[] mas = new int[52];
            for (int i = 0; i < 52; i++)
            {
                mas[i] = 0;
            }
            CurCards.Clear();
            int Times = 0;
            for (int i = 0; i < 52; i++)
            {
            Metka:
                Times++;
                tmp = vars.rnd.Next(52);
                if (mas[tmp] > 0)
                {
                    GotoCount++;
                    if (GotoCount > 1000) break;
                    goto Metka;
                }
                else
                {
                    GotoCount = 0;
                    mas[tmp] = 1;
                    CurCards.Add(MainCardsDeck.Cards[tmp]);
                }
            }
            if (GotoCount >= 1000)
            {
                MessageBox.Show("Goto count > 1000");
            }
            else
            {
                //MessageBox.Show("CurCardDeck done !!!");
            }
            Text = "Times = " + Times;

        }

        private void tmrKadr_Tick(object sender, EventArgs e)
        {
            MakeKadr();
        }

        private void pic_MouseUp(object sender, MouseEventArgs e)
        {
            //string st = "Mouse position:\r\nX = " + MousePosition.X + "\r\nY = " + MousePosition.Y;
            //Rectangle tmp;
            //foreach (Card s in MainCardsDeck.Cards)
            //{
            //    tmp = new Rectangle(s.Position, new Size(36, 50));
            //    if (tmp.Contains(new Point(e.X, e.Y)))
            //    {
            //        lblMousePosition.Text = st + "\r\nCard:\r\nVal = " + s.Val + "\r\nSuite = " + s.Suit;
            //        break;
            //    }
            //    lblMousePosition.Text = st;
            //}
        }
    }
}
