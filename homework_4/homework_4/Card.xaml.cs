using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace homework_4
{
    /// <summary>
    /// Interaction logic for Card.xaml
    /// </summary>
    public partial class Card : UserControl
    {
        public event EventHandler FlippingCompleted;
        public Card()
        {
            InitializeComponent();
        }

      
        private char  Value;

        public char Value1
        {
            get
            {
                return Value;
            }

            set
            {
                Value = value;
                tb1.Text = Value1.ToString();

            }
        }

       
    public bool card_flip=false;

        double remeber;
        public void FlipCard()
        {            
            remeber = this.ActualWidth;
                DoubleAnimation flip = new DoubleAnimation();
                flip.From = this.ActualWidth;
                flip.To = 0;
                flip.Duration = TimeSpan.FromSeconds(1);
                flip.Completed += Flip1Completed;
                tb1.Visibility = Visibility.Hidden;
                this.BeginAnimation(Card.WidthProperty, flip);
        }

        private void Flip1Completed(object sender, EventArgs e)
        {
            
            if (card_flip == true)
            {
                image1.Source = null;
                tb1.Visibility = Visibility.Visible;
            }
            else
            {
                image1.Source = new BitmapImage(new Uri(@"/Images/card_back.png", UriKind.Relative));
                tb1.Visibility = Visibility.Hidden;
            }

            DoubleAnimation flip = new DoubleAnimation();
            flip.From = 0;
            flip.To = remeber;
            flip.Duration = TimeSpan.FromSeconds(1);
            flip.Completed += Flip2Completed;
            this.BeginAnimation(Card.WidthProperty, flip);            
            }

        private void Flip2Completed(object sender, EventArgs e)
        {
            this.FlippingCompleted(this, new EventArgs());
        }

        private void grid_MouseDown_1(object sender, MouseButtonEventArgs e)
        {
           
            card_flip = !card_flip;
        }
    }
}
