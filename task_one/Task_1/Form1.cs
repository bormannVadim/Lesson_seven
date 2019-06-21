using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Task_1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            // Савенко Вадим - первое задание, сделать игру
            InitializeComponent();

        }
        private int Udvoitel;
        private int PlayNumber;
        private int attemps;

        private void button1_Click(object sender, EventArgs e)
        {
            label1.Text = (int.Parse(label1.Text) + 1).ToString();
            attemps++;
            CheckIfWin(); 
        }

        private void button2_Click(object sender, EventArgs e)
        {
            label1.Text = (int.Parse(label1.Text) * 2).ToString();
            Udvoitel++;
            label2.Text = "Статистика:\nУдвоитель: " + Udvoitel;
            attemps++;
            CheckIfWin();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            label1.Text = "1";
            Udvoitel = 0;
            label2.Text = "Статистика:\nУдвоитель: "+ Udvoitel;
            label3.Text = "Давай поиграем...";
            attemps = 0;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Play_Click(object sender, EventArgs e)
        {
            Random rn = new Random();
            PlayNumber = rn.Next(1, 100);
            label3.Text = "Вам нужно\nполучить число: " + PlayNumber;
        }

        private void CheckIfWin()
        {
            int currentValue = Convert.ToInt32(label1.Text);
            int targetValue = PlayNumber;

            if (currentValue == PlayNumber)
                //зупуск логики и подсчёт, выиграл или нет;
                if (attemps == maxAttempts())
                    MessageBox.Show("Поздравляем, вы выиграли!\nКол-во ходов: " + attemps);
                else
                    MessageBox.Show("Вы проиграли!\nКол-во ходов: " + attemps + "\nМакс. кол-во ходов: " + maxAttempts());
            else if (currentValue >= PlayNumber)
                MessageBox.Show("Вы проиграли!\nКол-во ходов: " + attemps + "\nНе попали в число");
        }

        private int maxAttempts()
        {
            int currentNumber = PlayNumber;
            int MaxAttempts = 0;
            while(currentNumber!=1)
            {
                if ((currentNumber % 2) == 0)
                    currentNumber /= 2;
                else
                {
                    currentNumber -= 1;
                }
                MaxAttempts++;
            }

            return MaxAttempts;
        }
    }
}
