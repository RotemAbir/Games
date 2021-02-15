using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace blackjack
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            init_cards();
        }
        List<Card_UserControl> pack;
        private void init_cards()
        {
            pack = new List<Card_UserControl>();
            SUIT[] suits = { SUIT.CLUB, SUIT.DAIMOND, SUIT.HART, SUIT.SPADE };
            for (int v = 1; v <= 13; v++)
                foreach (SUIT s in suits)
                {
                    Card_UserControl card = new Card_UserControl();
                    card.Card_suit = s;
                    card.Card_value = v;
                    pack.Add(card);
                }
        }


        private void draw_card_Click(object sender, EventArgs e)
        {
        }

        private void stop_cards_Click(object sender, EventArgs e)
        {
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        int cols = 1;
        private void button1_Click(object sender, EventArgs e)
        {
            Random rnd = new Random();
            int index = rnd.Next(0, 13);
            cols++;
            /*  PlayerTabel.ColumnCount = cols;
              PlayerTabel.ColumnStyles.Clear();
              for (int i = 0; i < cols; i++)
              {
                  PlayerTabel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, (float)1.0 / cols));
              }
              PlayerTabel.RowCount = 1;
              PlayerTabel.RowStyles.Clear();
              PlayerTabel.RowStyles.Add(new RowStyle(SizeType.Percent, (float)1.0 / 1));
              */
            PlayerTabel.Controls.Clear();
            for (int i = 0; i < pack.Count; i++)
            {
                Card_UserControl card = pack[index];
                //cardTable.SetColumn();
                PlayerTabel.Controls.Add(card, i, 0);
                int val = card.Card_value;

                label1.Text = "Player's score:" + val;

            }
        }

        private void Form1_Load_1(object sender, EventArgs e)
        {

        }
    }
    }
