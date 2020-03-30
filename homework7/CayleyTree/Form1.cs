using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
/*将课本中例5-31的Cayley树绘图代码进行修改。
 * 添加一组控件用以调节树的绘制参数。参数包括:
 * 递归深度（n）、
 * 主干长度（leng）、
 * 右分支长度比（per1）、
 * 左分支长度比（per2）、
 * 右分支角度（th1）、
 * 左分支角度（th2）、
 * 画笔颜色（pen）。
 */
namespace CayleyTree
{
    public partial class Form1 : Form
    {
        private Graphics graphics;
        int n = 10;
        int leng = 100;
        double per1 = 0.6;
        double per2 = 0.7;
        double th1 = 30 * Math.PI / 180;
        double th2 = 20 * Math.PI / 180;
        Color penColor = Color.Red;
        public Form1()
        {
            InitializeComponent();
            this.panel1.BackColor = Color.White;
        }

        private void btnDraw_Click(object sender, EventArgs e)
        {

            if (graphics == null) graphics = this.panel1.CreateGraphics();
            graphics.Clear(Color.White);
            try
            {
                drawCayleyTree(n, 200, 310, leng, -(Math.PI / 2));
            }
            catch(Exception)
            {
                return;
            }
        }

        void drawCayleyTree(int n,double x0,double y0,double leng,double th)
        {
            if (n == 0) return;
            double x1 = x0 + leng * Math.Cos(th);
            double y1 = y0 + leng * Math.Sin(th);

            drawLine(x0, y0, x1, y1);
            drawCayleyTree(n - 1, x1, y1, per1 * leng, th + th1);
            drawCayleyTree(n - 1, x1, y1, per2 * leng, th - th2);
        }

        void drawLine(double x0,double y0,double x1,double y1)
        {
            Pen pen = new Pen(penColor, 1);
            graphics.DrawLine(
                pen, (int)x0, (int)y0, (int)x1, (int)y1);
            
        }

        private void btnColor_Click(object sender, EventArgs e)
        {
            ColorDialog colorDia = new ColorDialog();
            colorDia.Color = penColor;

            if (colorDia.ShowDialog() == DialogResult.OK)
            {
                penColor = colorDia.Color;
            }
        }

        private void txtN_TextChanged(object sender, EventArgs e)
        {
            int temp = n;
            try
            {
                n = Int16.Parse(txtN.Text);
            }
            catch(Exception)
            {
                txtN.Text = temp.ToString();
                n = temp;
            }
        }

        private void txtLeng_TextChanged(object sender, EventArgs e)
        {
            int temp = leng;
            try
            {
                leng = Int16.Parse(txtLeng.Text);
            }
            catch (Exception)
            {
                txtLeng.Text = temp.ToString();
                leng = temp;
            }
        }

        private void txtPer1_TextChanged(object sender, EventArgs e)
        {
            double temp = per1;
            try
            {
                per1 = double.Parse(txtPer1.Text);
            }
            catch (Exception)
            {
                txtPer1.Text = temp.ToString();
                per1 = temp;
            }
        }

        private void txtPer2_TextChanged(object sender, EventArgs e)
        {
            double temp = per2;
            try
            {
                per2 = double.Parse(txtPer2.Text);
            }
            catch (Exception)
            {
                txtPer2.Text = temp.ToString();
                per2 = temp;
            }
        }

        private void txtTh1_TextChanged(object sender, EventArgs e)
        {
            double temp = th1;
            try
            {
                th1 = double.Parse(txtTh1.Text) * Math.PI / 180;
            }
            catch (Exception)
            {
                txtTh1.Text = temp.ToString();
                th1 = temp;
            }
        }

        private void txtTh2_TextChanged(object sender, EventArgs e)
        {
            double temp = th2;
            try
            {
                th2 = double.Parse(txtTh1.Text) * Math.PI / 180;
            }
            catch (Exception)
            {
                txtTh2.Text = temp.ToString();
                th2 = temp;
            }
        }
    }
}
