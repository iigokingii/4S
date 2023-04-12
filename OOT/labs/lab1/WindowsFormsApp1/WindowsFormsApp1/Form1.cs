using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {

        string memory;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            double grad;
            if (!double.TryParse(textBox1.Text,out grad))
            {
                MessageBox.Show("Неверный формат числа");
                textBox1.BackColor = Color.Red;
            }
            else
            {
                textBox1.BackColor = Color.White;
                double x = Convert.ToDouble(textBox1.Text);
                grad = (x * 180) / Math.PI;

                switch (comboBox1.Text)
                {
                    case "sin(x)":
                        {
                            textBox2.Text = Convert.ToString(Math.Sin(grad));
                            break;
                        }
                    case "cos(x)":
                        {
                            textBox2.Text = Convert.ToString(Math.Cos(grad));
                            break;
                        }
                    case "tg(x)":
                        {
                            textBox2.Text = Convert.ToString(Math.Tan(grad));
                            break;
                        }
                    case "ctg(x)":
                        {
                            textBox2.Text = Convert.ToString(Math.Cos(grad) / Math.Sin(grad));
                            break;
                        }
                    case "sqrt(x)":
                        {
                            if (x < 0)
                            {
                                textBox1.BackColor = Color.Red;
                                MessageBox.Show("Невозможно вычислить корень, введите положительное число");
                            }
                            else
                            {
                                textBox2.Text = Convert.ToString(Math.Sqrt(x));
                            }
                            break;
                        }
                    case "кубический корень":
                        {
                            textBox2.Text = Convert.ToString(Math.Pow(x, 1.0 / 3.0));
                            break;
                        }
                    case "возведение в степень":
                        {
                            label4.Visible = true;
                            textBox3.Visible = true;
                            if (textBox3.Text == "")
                            {
                                MessageBox.Show("Введите Степень");
                            }
                            else
                            {
                                double temp;
                                if (!double.TryParse(textBox3.Text, out temp))
                                {
                                    MessageBox.Show("Неверный формат числа");
                                    textBox3.BackColor = Color.Red;
                                }
                                else
                                {
                                    if (temp < 0)
                                    {
                                        temp = Math.Abs(temp);
                                        textBox2.Text = Convert.ToString(Math.Pow(x, 1.0/temp));
                                    }
                                    else
                                    {
                                        textBox2.Text = Convert.ToString(Math.Pow(x, temp));
                                    }
                                }
                                
                            }
                            break;
                        }
                }
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            comboBox1.Text = "";
            textBox3.Visible = false;
            label4.Visible = false;

        }

        private void button3_Click(object sender, EventArgs e)
        {
            memory = textBox2.Text;
        }
        private void button4_Click(object sender, EventArgs e)
        {
            textBox1.Text = memory;
        }
    }
}
