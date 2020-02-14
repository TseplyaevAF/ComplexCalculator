using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//using System.Text.RegularExpressions;

namespace Training
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            comboBox1.Text = comboBox1.Items[0].ToString();
            comboBox2.Text = comboBox2.Items[0].ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Complex c1;
            float num;
            try
            {
                string selectedState = comboBox1.SelectedItem.ToString();
                c1 = new Complex(textBox1.Text);

                switch (selectedState)
                {
                    case "Аргумент числа":
                        num = (float)Math.Round(c1.Arg(), 4);
                        result.Text = num.ToString();
                        break;
                    case "Модуль числа":
                        num = (float)Math.Round(c1.Abs(), 4);
                        result.Text = num.ToString();
                        break;
                    case "Показательная форма":
                        c1.ToExponential();
                        result.Text = c1.Re.ToString() + "*e^i" +
                            c1.Im.ToString() + "°";
                        break;
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show($"Ошибка: {exception.Message}");
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

            Complex c1, c2;
            try
            {
                string selectedState = comboBox2.SelectedItem.ToString();
                c1 = new Complex(textBox2.Text);
                c2 = new Complex(textBox3.Text);

                switch (selectedState)
                {
                    case "Разделить":
                        result2.Text = (c1 / c2).ToString();
                        break;
                    case "Умножить":
                        result2.Text = (c1 * c2).ToString();
                        break;
                    case "Сложить":
                        result2.Text = (c1 + c2).ToString();
                        break;
                    case "Вычесть":
                        result2.Text = (c1 - c2).ToString();
                        break;
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show($"Ошибка: {exception.Message}");
            }

        }

        private void buttonLess_Click(object sender, EventArgs e)
        {
            Complex c1, c2;
            try
            {
                c1 = new Complex(textBox2.Text);
                c2 = new Complex(textBox3.Text);
                result2.Text = c1 < c2 ? c1.ToString() : c2.ToString();
            }
            catch
            {
                MessageBox.Show("Некорректные данные");
            }
        }

        private void buttonMore_Click(object sender, EventArgs e)
        {
            Complex c1, c2;
            try
            {
                c1 = new Complex(textBox2.Text);
                c2 = new Complex(textBox3.Text);
                result2.Text = c1 > c2 ? c1.ToString() : c2.ToString();
            }
            catch
            {
                MessageBox.Show("Некорректные данные");
            }
        }

        private void buttonEqual_Click(object sender, EventArgs e)
        {
            Complex c1, c2;
            try
            {
                c1 = new Complex(textBox2.Text);
                c2 = new Complex(textBox3.Text);
                result2.Text = c1 == c2 ? "Числа равны" : "Числа не равны";
            }
            catch
            {
                MessageBox.Show("Некорректные данные");
            }
        }
    }
}
