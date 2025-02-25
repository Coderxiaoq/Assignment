using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace task2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!double.TryParse(textBox1.Text, out double num1) ||
       !double.TryParse(textBox2.Text, out double num2))
            {
                label1.Text = "输入无效！";
                return;
            }

            string op = comboBox1.SelectedItem?.ToString();
            if (op == null)
            {
                label1.Text = "请选择运算符！";
                return;
            }

            try
            {
                double result = 0;
                switch (op)
                {
                    case "+": result = num1 + num2; break;
                    case "-": result = num1 - num2; break;
                    case "*": result = num1 * num2; break;
                    case "/": result = num1 / num2; break;
                }
                label1.Text = $"结果：{result}";
            }
            catch (DivideByZeroException)
            {
                label1.Text = "除数不能为零！";
            }
        }
    }
}
