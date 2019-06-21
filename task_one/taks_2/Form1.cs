using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace taks_2
{
    public partial class Form1 : Form
    {
        private int  ComputerNumber; 
        private int Attempts =0;
        private int minAttempts;
        public Form1()
        {
            InitializeComponent();
            Random rd = new Random();
            ComputerNumber = rd.Next(1, 100);
       
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (Attempts == 0)
            {
                MinAttempts();
            }
            Attempts++;
            
            if (ComputerNumber == int.Parse(textBox1.Text))
            {
                if(Attempts<=minAttempts)
                    MessageBox.Show("Вы выиграли! Вы угадали число за " + Attempts + " попыток!\nА компьютер за " + minAttempts);
                    else
                    MessageBox.Show("Вы угадали число за " + Attempts + " попыток!\nА компьютер за " + minAttempts);
            }
            else
            {
                CheckIfNot();
            }
        }

        private void MinAttempts()
        {
             // на случай, если пользователь угадаетс  первого раза, компьютер всегда начинает с 50
            int number = int.Parse(textBox1.Text) == ComputerNumber ?number = 50: int.Parse(textBox1.Text);
           
            int min = 0;
            int computerNumber = ComputerNumber;
            int last = 0;
            int buffer;
            while (number != computerNumber)
            {
                if (number + 1 == computerNumber)// на случай не четного числа
                {
                    min++;
                    break;
                }
                else
                {
                    if (computerNumber < number)
                    {
                        // меньше, деление
                        if (last == 0)
                        {
                            last = number; // предпоследнее число
                            number /= 2; // 25, 13, между 25-12 =  13;  13\2 = 6; 13+6=18; 13-18=5; 5/2 = 3;18-3 = 5; 
                        }
                        else
                        {
                            if (last > number)
                            {
                                last = number;
                                number /= 2;
                            }//target 15 last 12 num 18 18-12= 5/2 =3 18-3
                            else
                            {
                                buffer = last;
                                last = number;
                                number -= (number - buffer) / 2;
                            }

                        }
                    }
                    else
                    {
                        //больше
                        if (last == 0)
                        {
                            // 86
                            last = number; // предпоследнее число
                            number += (100 - number) / 2; //75; 75+13=88 
                        }
                        else
                        {
                            // искомое число в диапазоне от 81 до 87  текущее 87 , 87-81/2 =  3; 84 - текущее, последнее 81 
                            if (last > number)
                            {
                                buffer = last;
                                last = number;
                                number += (buffer - number) / 2;
                            }
                            else
                            { // last = 81 number = 84
                                buffer = last;
                                last = number;

                                number += (100 - number) / 2;
                            }
                        }

                    }
                    min++;
                }
            }
            minAttempts = min;
        }

        private void CheckIfNot()
        {
            int number = int.Parse(textBox1.Text);
            if (ComputerNumber < number)
                label1.Text = "Загаданное число меньше вашего!";
            else
                label1.Text = "Загаданное число больше вашего!";
        }
    }
}
