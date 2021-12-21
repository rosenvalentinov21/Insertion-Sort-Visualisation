using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Insertion_Sort_Visualizer_2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        int[] Arr = new int[0];
        TextBox[] myTextboxList = new TextBox[0];

        private void buttonEnter_Click(object sender, EventArgs e)
        {
            string arrText = textBox1.Text;

            string[] strArr = arrText.Split(',', '.', '/');

            Arr = new int[strArr.Length];
            myTextboxList = new TextBox[Arr.Length];

            for (int i = 0; i < strArr.Length; i++)
            {
                try
                {
                    Arr[i] = int.Parse(strArr[i]);
                }
                catch (FormatException)
                {
                    MessageBox.Show("Input numbers only,separated by ','  '.' , '/'");
                }
            }

            int pointX = 0;
            int pointY = 50;

            try
            {
                for (int i = 0; i < Arr.Length; i++)
                {
                    myTextboxList[i] = new TextBox();
                    myTextboxList[i].Size = new Size(panel1.Width / Arr.Length, 100);
                    myTextboxList[i].Text = Arr[i].ToString();
                    myTextboxList[i].Name = i.ToString();
                    myTextboxList[i].BackColor = Color.Yellow;
                    myTextboxList[i].Location = new Point(pointX, pointY);
                    myTextboxList[i].ReadOnly = true;
                    this.panel1.Controls.Add(myTextboxList[i]);
                    pointX += panel1.Width / Arr.Length;
                }
                panel1.Update();
            }
            catch(Exception ex)
            {
                MessageBox.Show("Exception " + ex);
            }
        }

        public void wait(int milliseconds)
        {
            var timer1 = new System.Windows.Forms.Timer();
            if (milliseconds == 0 || milliseconds < 0) return;

            // Console.WriteLine("start wait timer");
            timer1.Interval = milliseconds;
            timer1.Enabled = true;
            timer1.Start();

            timer1.Tick += (s, e) =>
            {
                timer1.Enabled = false;
                timer1.Stop();
                // Console.WriteLine("stop wait timer");
            };

            while (timer1.Enabled)
            {
                Application.DoEvents();
            }
        }

        public void sort(int[] arr)
        {
            try
            {
                myTextboxList[0].BackColor = Color.Green;
                for (int i = 1; i < arr.Length; ++i)
                {
                    int key = arr[i];
                    myTextboxList[i].BackColor = Color.Red;
                    panel1.Update();
                    wait(1000);
                    int j = i - 1;

                    while (j >= 0 && arr[j] > key)
                    {
                        myTextboxList[j].BackColor = Color.Red;
                        arr[j + 1] = arr[j];
                        myTextboxList[j + 1].Text = myTextboxList[j].Text;
                        myTextboxList[j + 1].BackColor = Color.Green;

                        if (arr[j] > key)
                        {
                            myTextboxList[j].Text = key.ToString();
                        }
                        j--;

                        panel1.Update();
                        wait(1000);
                    }
                    arr[j + 1] = key;
                    myTextboxList[j + 1].Text = key.ToString();

                    for (int k = i; k >= 0; k--)
                        myTextboxList[k].BackColor = Color.Green;
                    panel1.Update();
                    wait(1000);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("New exeption " + ex);
            }
        }
        private void buttonSort_Click(object sender, EventArgs e)
        {
            sort(Arr);
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            panel1.Controls.Clear();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
