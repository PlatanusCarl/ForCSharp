using OrderManagementSystemEF.Class;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OrderManagementSystemEF.Forms
{
    partial class createForm : Form
    {
        public Order order { set; get; }
        public OrderItem orderitem { set; get; }
        public createForm()
        {
            InitializeComponent();
            orderitem = new OrderItem();
            order = new Order();
            bindingSource1.DataSource = order.ItemList;
            itemtxt.DataBindings.Add("Text", orderitem, "ItemId");
            amounttxt.DataBindings.Add("Text", orderitem, "Amount");
            pricetxt.DataBindings.Add("Text", orderitem, "Price");
        }
        public createForm(Order order1):this()
        {
            order = order1;
            bindingSource1.DataSource = order.ItemList;
            customertxt.Text = order1.CustomerName;
        }

        private void addbtn_Click(object sender, EventArgs e)
        {
            if (orderitem.Amount == 0)
                return;
            if(order.ItemList.Contains(orderitem))
            {
                for (int i=0;i< order.ItemList.Count;i++)
                {
                    if (order.ItemList[i].ItemId == orderitem.ItemId)
                        order.ItemList.RemoveAt(i);
                }
            }

            OrderItem neworderitem = new OrderItem(orderitem.ItemId, orderitem.Price, orderitem.Amount);
            order.ItemList.Add(neworderitem);
            bindingSource1.DataSource = order.ItemList;
            bindingSource1.ResetBindings(false);
        }

        private void confirmbtn_Click(object sender, EventArgs e)
        {
            order.CustomerName = customertxt.Text;
            order.ItemList.ForEach(oi =>
            {
                oi.ItemId = oi.Item.ItemId;
                oi.OrderId = order.OrderId;
            });
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
                for (int i = 0; i < order.ItemList.Count; i++)
                {
                    if (order.ItemList[i].ItemId == selectID)
                        order.ItemList.RemoveAt(i);
                }
            }
            bindingSource1.DataSource = order.ItemList;
            bindingSource1.ResetBindings(false);
        }
    }
}
