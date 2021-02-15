using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace blackjack
{
    public enum SUIT
    {
        HART,
        CLUB,
        DAIMOND,
        SPADE
    }

    public partial class Card_UserConrol : UserControl
    {
        public Card_UserControl()
        {
            InitializeComponent();
        }

        private SUIT card_suit;
        public SUIT Card_suit
        {
            get
            {
                return card_suit;
            }
            set
            {
                card_suit = value;
                label2.Text = card_suit.ToString();

            }
        }

        private int card_value;
        public int Card_value
        {
            get
            {
                return card_value;
            }

            set
            {
                String s;
                switch (value)
                {
                    case 1:
                        s = "A";
                        break;
                    case 2:
                        s = "2";
                        break;
                    case 3:
                        s = "3";
                        break;
                    case 4:
                        s = "4";
                        break;
                    case 5:
                        s = "5";
                        break;
                    case 6:
                        s = "6";
                        break;
                    case 7:
                        s = "7";
                        break;
                    case 8:
                        s = "8";
                        break;
                    case 9:
                        s = "9";
                        break;
                    case 10:
                        s = "T";
                        break;
                    case 11:
                        s = "J";
                        break;
                    case 12:
                        s = "Q";
                        break;
                    case 13:
                        s = "K";
                        break;
                    default:
                        s = value.ToString();
                        break;
                }
                label1.Text = s;
                label3.Text = s;
                label4.Text = s;
                card_value = value;
            }
        }

        private void Card_UserControl_Load(object sender, EventArgs e)
        {
            label1.BackColor = Color.Transparent;
            label2.BackColor = Color.Transparent;
            label2.Visible = false;
            label3.BackColor = Color.Transparent;
            label4.BackColor = Color.Transparent;
            if (label2.Text == "HART")
            {
                this.BackgroundImage = Properties.Resources.hart;
            }
            if (label2.Text == "CLUB")
            {
                this.BackgroundImage = Properties.Resources.club;
                label1.ForeColor = Color.White;
            }
            if (label2.Text == "DAIMOND")
            {
                this.BackgroundImage = Properties.Resources.daimond;
            }
            if (label2.Text == "SPADE")
            {
                this.BackgroundImage = Properties.Resources.spade;
                label1.ForeColor = Color.White;
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
