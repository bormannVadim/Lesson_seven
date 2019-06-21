using System;
using System.Windows.Forms;
using System.Drawing;

namespace task_one
{
    class Program:Form
    {
        public static void Main()
        {
            Program pr = new Program();
            pr.Show();
        }

        public Program()
        {

            Text = "Привет";
        }
    }
}
