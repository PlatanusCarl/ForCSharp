using OrderManagementSystemEF.Class;
using OrderManagementSystemEF.Forms;
using Renci.SshNet.Security;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OrderManagementSystemEF
{

    public partial class Form1 : Form
    {
        public string Keyword { set; get; }
        public Form1()
        {
            InitializeComponent();
            bindingSource1.DataSource = OrderService.GetAll();
            querytxt.DataBindings.Add("Text", this, "Keyword");
            comboBox1.Items.Add("订单Id");
            comboBox1.Items.Add("顾客名");
            comboBox1.Items.Add("商品Id");
            comboBox1.SelectedIndex = comboBox1.Items.IndexOf("订单Id");
        }

        private void querybtn_Click(object sender, EventArgs e)
        {
            if (Regex.IsMatch(Keyword, @"/^[\s\S]*.*[^\s][\s\S]*$/"))
            {
                bindingSource1.DataSource = OrderService.GetAll();
                bindingSource1.ResetBindings(false);
                return;
            }
            switch (comboBox1.SelectedItem.ToString())
            {
                case "订单Id":
                    bindingSource1.DataSource = OrderService.Get(Keyword);
                    bindingSource1.ResetBindings(false);
                    break;
                case "顾客名":
                    bindingSource1.DataSource = OrderService.QueryByCustomer(Keyword);
                    bindingSource1.ResetBindings(false);
                    break;
                case "商品Id":
                    bindingSource1.DataSource = OrderService.QueryByItem(Keyword);
                    bindingSource1.ResetBindings(false);
                    break;
            }
        }

        private void creatbtn_Click(object sender, EventArgs e)
        {
            createForm form = new createForm();

            if (DialogResult.OK == form.ShowDialog())
            {
                OrderService.Add(form.order);
                bindingSource1.DataSource = OrderService.GetAll();
                bindingSource1.ResetBindings(false);
            }
        }

        private void deletebtn_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewCell cell in dataGridView1.SelectedCells)
            {
                dataGridView1.Rows[cell.RowIndex].Selected = true;
            }
            foreach (DataGridViewRow row in dataGridView1.SelectedRows)
            {
                string selectID = row.Cells[0].Value.ToString();
                if (Regex.IsMatch(selectID, @"/^[\s\S]*.*[^\s][\s\S]*$/"))
                    return;
                string ID = selectID.ToString();
                OrderService.Remove(ID);
            }
            bindingSource1.DataSource = OrderService.GetAll();
            bindingSource1.ResetBindings(false);
        }

        private void editbtn_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewCell cell in dataGridView1.SelectedCells)
            {
                dataGridView1.Rows[cell.RowIndex].Selected = true;
            }
            if(dataGridView1.SelectedRows.Count>1)
            {
                return;
            }
            Order order1 = new Order();
            foreach (DataGridViewRow row in dataGridView1.SelectedRows)
            {
                string selectID = row.Cells[0].Value.ToString();

                string ID = selectID.ToString();
                //order1 = OrderService.Get(ID);
                OrderService.Remove(ID);
            }
            createForm form = new createForm(order1);

            if (DialogResult.OK == form.ShowDialog())
            {
                OrderService.Add(order1);
                bindingSource1.DataSource = OrderService.GetAll();
                bindingSource1.ResetBindings(false);
            }
        }

        private void exportbtn_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFile = new SaveFileDialog();
            saveFile.Title = "请选择导出路径";
            saveFile.Filter = "XML文件|*.xml";
            if (DialogResult.OK == saveFile.ShowDialog())
            {
                OrderService.Export(saveFile.FileName);
            }
        }

        private void importbtn_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog();
            openFile.Title = "请选择导入的XML文件";
            openFile.Filter = "XML文件|*.xml";
            if (DialogResult.OK == openFile.ShowDialog())
            {
                OrderService.Import(openFile.FileName);
                bindingSource1.DataSource = OrderService.GetAll();
                bindingSource1.ResetBindings(false);
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1)
                return;
            string clickedID = null;
            clickedID = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            Order clickedOrder = OrderService.Get(clickedID.ToString());
            bindingSource2.DataSource = clickedOrder.ItemList;
            bindingSource2.ResetBindings(false);
        }
    }
}
