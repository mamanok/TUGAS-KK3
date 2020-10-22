using System;
using System.Windows.Forms;
using System.IO;

namespace FileIO_GUI
{
    public partial class Form1 : Form
    {
        Double value = 0;
        String operation = "";
        bool operation_pressed = false;

        string filelocation = @"C:\Users\LENOVO\source\repos\coba.txt";
        public Form1()
        {
            InitializeComponent();
        }

        private void Last_data(object sender, EventArgs e)
        {
            //Baca
            StreamReader sr = new StreamReader(filelocation);
            result.Text = sr.ReadToEnd();
            sr.Close();
        }

        private void button_Click(object sender, EventArgs e)
        {
            if ((result.Text == "0")|| (operation_pressed))
            {
                result.Clear();
            }

            operation_pressed = false;
            Button b = (Button)sender;
            result.Text = result.Text + b.Text;
        }

        private void button17_Click(object sender, EventArgs e)
        {   
            equation.Text = "";
            switch (operation)
            {
                case "+":
                    result.Text = (value + Double.Parse(result.Text)).ToString();
                    break;
                case "-":
                    result.Text = (value - Double.Parse(result.Text)).ToString();
                    break;
                case "*":
                    result.Text = (value * Double.Parse(result.Text)).ToString();
                    break;
                case "/":
                    result.Text = (value / Double.Parse(result.Text)).ToString();
                    break;
                default:
                    break;
            }
            //Tulis
            StreamWriter sw = new StreamWriter(filelocation);
            string text = result.Text;
            sw.WriteLine(text);
            sw.Close();
        }

        private void button14_Click(object sender, EventArgs e)
        {
            result.Text = "0";
        }

        private void operator_click(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            operation = b.Text;
            value = Double.Parse(result.Text);
            operation_pressed = true;
            equation.Text = value + " " + operation;
        }

        private void button15_Click(object sender, EventArgs e)
        {
            result.Clear();
            value = 0;
        }
    }
}
