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
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace homework_4
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        System.Windows.Threading.DispatcherTimer dispatcherTimer = new System.Windows.Threading.DispatcherTimer();
        System.Windows.Threading.DispatcherTimer dispatcherTimer2 = new System.Windows.Threading.DispatcherTimer();
        int complete;
        private void button_Click(object sender, RoutedEventArgs e)
        {
            Grid3.Children.Clear();
            if (combo1.SelectedItem == null && combo2.SelectedItem == null|| combo1.SelectedItem == null|| combo2.SelectedItem == null)
            {
                MessageBox.Show("please select rows and columns");
            }

            else
            {
                ComboBoxItem Columns = (ComboBoxItem)combo1.SelectedItem;
                String C = (String)Columns.Content;
                int cols = int.Parse(C);

                ComboBoxItem Rows = (ComboBoxItem)combo2.SelectedItem;
                String R = (String)Rows.Content;
                int rows = int.Parse(R);


                if ((rows * cols) % 2 != 0)
                {
                    MessageBox.Show("please select number of rows * columns that divide by 2");
                }

                else
                {
                    Grid3.ColumnDefinitions.Clear();
                    Grid3.RowDefinitions.Clear();
                    for (int r = 0; r < rows; r++)
                    {
                        Grid3.RowDefinitions.Add(new RowDefinition());

                    }
                    for (int c = 0; c < cols; c++)
                    {
                        Grid3.ColumnDefinitions.Add(new ColumnDefinition());
                    }
                    dispatcherTimer.Tick += new EventHandler(dispatcherTimer_Tick);
                    dispatcherTimer.Interval = new TimeSpan(0, 0, 1);
                    dispatcherTimer.Start();

                    List<Card> cards = new List<Card>();
                    for (int p = 0; p < (rows * cols) / 2; p++)
                    {
                        Card c = new Card();
                        c.Value1 = (char)('A' + p);
                        cards.Add(c);
                        c.MouseDown += Card_MouseDown;

                        c = new Card();
                        c.Value1 = (char)('A' + p);
                        cards.Add(c);
                        c.MouseDown += Card_MouseDown;

                    }

                    for (int i = 0; i < rows; i++)
                    {
                        for (int j = 0; j < cols; j++)
                        {
                            Random rnd = new Random();
                            int idx = rnd.Next(0, cards.Count);
                            Card c = cards[idx];
                            Grid.SetColumn(c, j);
                            Grid.SetRow(c, i);
                            cards.RemoveAt(idx);
                            Grid3.Children.Add(c);

                        }
                    }

                }
                complete = (rows * cols) / 2;
            }
        }

        bool first=false;
        bool second=false;
        Card firstCard;
        Card secondCard;
        int stepCount;
        int flips=0;
        int isFlipping=0;

        private void Card_MouseDown(object sender, MouseButtonEventArgs e)
        {
            
           
           
            Card c = (Card)sender;
            c.FlippingCompleted += C_FlippingCompleted;            
            if (isFlipping == 0 && flips < 2)
            {
                isFlipping = 1;
                flips++;
                isFlipping++;
                if (flips == 1)
                {
                    first = true;
                    firstCard = c;
                    firstCard.FlipCard();
                   
                }
                else
                {
                    second = true;
                    secondCard = c;
                    secondCard.FlipCard();
                    
                }
                c.card_flip = true;
               
            }
        }


        int count;    
        private void C_FlippingCompleted(object sender, EventArgs e)
        {
            
            isFlipping = 0;
            if (flips==2)
            {
                flips = 0;                
                if (firstCard.Value1 == secondCard.Value1)
                {
                    first = false;
                    second = false;
                    count = count + 1;
                }

                else
                {
                    dispatcherTimer2.Tick += new EventHandler(dispatcherTimer_Tick2);
                    dispatcherTimer2.Interval = new TimeSpan(0, 0, 1);
                    dispatcherTimer2.Start();
                    isFlipping = 1;
                    firstCard.card_flip = false; 
                    secondCard.card_flip = false;
                    //firstCard.FlipCard();
                   // secondCard.FlipCard();
                    first = false;
                    second = false;
                    //flips = 0;
                }
                stepCount++;
                moves.Content = "Moves:" + stepCount.ToString();
            }
           
           if(count==complete)
            {
                dispatcherTimer.Stop();
                myPop.IsOpen = true;
                textBlock.Visibility = Visibility.Visible;
                textBlock.Text="Horrey, you solved the Mem game in " + stepCount.ToString() + " moves and in " + TimeCount.ToString()+ " seconds. Click here to restart..";             
            }
        }
    
        int TimeCount = 0;
        private void dispatcherTimer_Tick(object sender, EventArgs e)
        {
            TimeCount++;
            time.Content = "Time:" + TimeCount.ToString();
        }
        int timerPasuse = 0;
        private void dispatcherTimer_Tick2(object sender, EventArgs e)
        {
            timerPasuse++;
            if(timerPasuse==2)
             {
                dispatcherTimer2.Stop();
                firstCard.FlipCard();
                secondCard.FlipCard();
                flips = 0;
                timerPasuse = 0;

            }
        }
        private void textBlock_MouseDown(object sender, MouseButtonEventArgs e)
        {
            myPop.IsOpen = false;
            textBlock.Visibility = Visibility.Hidden;
            Grid3.Children.Clear();
            Grid3.ColumnDefinitions.Clear();
            Grid3.RowDefinitions.Clear();
            
            TimeCount = 0;
            time.Content = "Time:" + TimeCount;
            stepCount = 0;
            moves.Content = "Moves:" + stepCount;
            combo1.SelectedItem = null;
            combo2.SelectedItem = null;
            combo1.Text = "Columns";
            combo2.Text = "Rows";
        }
    }
}
