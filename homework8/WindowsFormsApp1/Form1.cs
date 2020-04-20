using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OrderManagementSystem;
/*
 * 为订单管理的程序添加一个WinForm的界面。通过这个界面，调用OrderService的各个方法，实现创建订单、删除订单、修改订单、查询订单、导出订单、导入订单等功能。
 * 要求：
 *（1）WinForm的界面部分单独写一个项目，依赖于原来的项目。
 *（2）可以使用两个窗口。主窗口实现查询展示功能，以及放置各种功能按钮。新建/修改订单功能使用弹出窗口。
 *（3）注意窗口的布局，在窗口尺寸变化时，不出现错位挤压等情况。
 *（4）尽量通过数据绑定来实现功能。订单和订单明细各使用一个bindingsource，通过DataMember来实现主从对象绑定。 
 */
namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        OrderManagementSystem.OrderService service;
        public Form1()
        {
            InitializeComponent();
            service = new OrderManagementSystem.OrderService();

            dataGridView1.DataSource = service.orderList;
        }

        private void querybtn_Click(object sender, EventArgs e)
        {

        }
        private void creatbtn_Click(object sender, EventArgs e)
        {
            int lastrow = dataGridView1.Rows.GetLastRow(DataGridViewElementStates.None);
            int orderID = 0;
            if (lastrow >= 0)
            {
                int? ID = dataGridView1.Rows[lastrow].Cells[0].Value as int?;
                if (ID != null)
                    orderID = (int)ID+1;
            }
            creatForm form = new creatForm(orderID);

            if (DialogResult.OK == form.ShowDialog())
            {
                service.addOrder(form.order);
                dataGridView1.DataSource = new mList<Order>();
                dataGridView1.DataSource = service.orderList;
                form.Dispose();
            }
        }

        private void deletebtn_Click(object sender, EventArgs e)
        {

        }

        private void editbtn_Click(object sender, EventArgs e)
        {

        }

        private void exportbtn_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFile = new SaveFileDialog();
            saveFile.Title = "请选择导出路径";
            saveFile.Filter = "XML文件|*.xml";
            if (DialogResult.OK == saveFile.ShowDialog())
            {
                service.Export(saveFile.FileName);
            }
        }

        private void importbtn_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog();
            openFile.Title = "请选择导入的XML文件";
            openFile.Filter = "XML文件|*.xml";
            if(DialogResult.OK  == openFile.ShowDialog())
            {
                service.Import(openFile.FileName);
                dataGridView1.DataSource = new mList<Order>();
                dataGridView1.DataSource = service.orderList;
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
