using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CalculatorWinforms
{

    public partial class Form1 : Form
    {
        long numb1 = 0, numb2 = 0;
        int time = 10;
        char? ope=null;
        void numChange(int num)
        {            
            if (CalcuScreen.Text.Length>10&&time<11)
            {
                //
                time++;
                label1.Text = $"e{time}";
                CalcuScreen.Text = $"{numb1.ToString()[0]}.{numb1.ToString().Substring(1)}";
                return;
            }
            else if(time >= 11)
            {
                time++;
                label1.Text = $"e{time}";
            }
            numb1 = numb1 * 10 + num;
            CalcuScreen.Text = $"{numb1}";
        }

        void equals()
        {
            switch(ope)
            {
                case '+':
                    numb1 += numb2;
                    break;
                case '-':
                    numb1 = numb2-numb1;
                    break;
                case '*':
                    numb1 *= numb2;
                    break;
                case '/':
                    if (numb2 == 0)
                        break;
                    numb1 = numb2/numb1;
                    break;
            }
            CalcuScreen.Text = $"{numb1}";
            ope = null;
        }

        void calculate(char operater)
        {
            equals();
            numb2 = numb1;
            numb1 = 0;
            switch (operater)
            {
                case '+':
                    ope = '+';
                    break;
                case '-':
                    ope = '-';
                    break;
                case '*':
                    ope = '*';
                    break;
                case '/':
                    ope = '/';
                    break;
            }

        }

        public Form1()
        {
            InitializeComponent();
            CalcuScreen.ReadOnly = true;
            CalcuScreen.Text = $"{numb1}";
        }

        private void num1_Click(object sender, EventArgs e)
        {
            numChange(1);
        }

        private void num2_Click(object sender, EventArgs e)
        {
            numChange(2);
        }

        private void num3_Click(object sender, EventArgs e)
        {
            numChange(3);
        }

        private void num4_Click(object sender, EventArgs e)
        {
            numChange(4);
        }

        private void num5_Click(object sender, EventArgs e)
        {
            numChange(5);
        }

        private void num6_Click(object sender, EventArgs e)
        {
            numChange(6);
        }

        private void num7_Click(object sender, EventArgs e)
        {
            numChange(7);
        }

        private void num8_Click(object sender, EventArgs e)
        {
            numChange(8);
        }

        private void num9_Click(object sender, EventArgs e)
        {
            numChange(9);
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            if (time > 10)
            {
                time--;
                label1.Text = $"e{time}";
                return;
            }
            label1.Text = $"";
            numb1 /= 10;
            CalcuScreen.Text = $"{numb1}";
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            numb1 = 0;numb2 = 0; time = 10;
            CalcuScreen.Text = $"{numb1}";
            label1.Text = $"";
        }

        private void buttonMinus_Click(object sender, EventArgs e)
        {
            calculate('-');
        }

        private void buttonMultiply_Click(object sender, EventArgs e)
        {
            calculate('*');
        }

        private void buttonDivide_Click(object sender, EventArgs e)
        {
            calculate('/');
        }

        private void buttonEqual_Click(object sender, EventArgs e)
        {
            equals();
        }

        private void buttonPlus_Click(object sender, EventArgs e)
        {
            calculate('+');
        }


    }
}
