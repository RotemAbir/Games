using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace shole_hamokshim_winform
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
          
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            insert_labels();
            choose_random_bombs(bombs_count);
        }

        int rows ;
        int cols ;
        int bombs_count = 5;
        bool[,] bombs;
        Label[,] labels;
        
        private void insert_labels()
        {
            rows = tableLayoutPanel3.RowCount;
            cols=tableLayoutPanel3.ColumnCount;
            tableLayoutPanel3.Controls.Clear();
            labels = new Label[rows, cols];
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    Label l = new Label();
                    l.Dock = DockStyle.Fill;
                    l.BackColor = Color.LightGray;
                    l.Click += L_Click;
                    tableLayoutPanel3.SetRow(l, i);
                    tableLayoutPanel3.SetColumn(l, j);
                    tableLayoutPanel3.Controls.Add(l,j,i);
                    labels[j, i] = l;
                }
            }
        }

        
        private void choose_random_bombs(int count)
        {
            List<int> chooser = new List<int>();
            for (int i = 0; i < rows*cols; i++)
            {
                chooser.Add(i);
            }
            bombs = new bool[rows, cols];
            Random r = new Random();
            while (count > 0)
            {
                int i = chooser[r.Next(chooser.Count)];
                bombs[i % cols, i / cols] = true;
                chooser.Remove(i);
                count--;
            }
        }


        private void change_bombs_color_to(Color br)
        {
            for (int y = 0; y < rows; y++)
            {
                for (int x = 0; x < cols; x++)
                {
                    if (bombs[x, y])
                    {
                        labels[x, y].BackColor = br;
                    }
                }
            }
        }


        private void button1_Click(object sender, EventArgs e)
        {
            for (int y = 0; y < rows; y++)
            {
                for (int x = 0; x < cols; x++)
                {
                    labels[x, y].BackColor = Color.LightGray;
                    labels[x, y].Text = String.Empty;
                }
            }
            choose_random_bombs(bombs_count);
        }

        private void label1_MouseDown(object sender, MouseEventArgs e)
        {
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    if (bombs[i, j] == true)
                    {
                        labels[i, j].BackColor = Color.Yellow;
                    }
                }
            }

        }

        private void label1_MouseUp(object sender, MouseEventArgs e)
        {
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    if (bombs[i, j] == true)
                    {
                        labels[i, j].BackColor = Color.LightGray;
                    }
                }
            }
        }


        int bombCounter;
          private void L_Click(object sender, EventArgs e)
          {
              Label L = (Label)sender;
            int row = tableLayoutPanel3.GetRow(L);
            int col = tableLayoutPanel3.GetColumn(L);
           
            if (bombs[col,row] == true)
                {
                for (int i = 0; i < rows; i++)
                {
                    for (int j = 0; j < cols; j++)
                    {
                        if(bombs[j,i]==true)
                        {
                            labels[j,i].BackColor = Color.Red;
                        }
                    }
                }

                MessageBox.Show("Game Over,you loose");
            }

          else
                {
                    L.BackColor = Color.White;
                }

            //בדיקה בצדדים
          if(col !=tableLayoutPanel3.ColumnCount-1)
            {
                if(bombs[col+1,row]==true)
                {
                    bombCounter++;
                }
            }

          if(col!=0)
            {
                if (bombs[col - 1, row] == true)
                {
                    bombCounter++;
                }
            }

            //בדיקה למעלה ולמטה
            if(row!=tableLayoutPanel3.RowCount-1)
            {
                if(bombs[col,row+1]==true)
                {
                    bombCounter++;
                }
            }

            if(row!=0)
            {
                if(bombs[col,row-1]==true)
                {
                    bombCounter++;
                }
            }

            if(bombCounter==0||L.BackColor==Color.Red)
            {
                L.Text = null;
                bombCounter = 0;
            }

            else
            {
                L.Text = bombCounter.ToString();
                bombCounter = 0;
            }
          }


    }
}
