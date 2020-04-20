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

namespace WindowsFormsApp1
{
    public partial class editForm : Form
    {
        Order order;
        OrderManagementSystem.OrderItem item;

        public editForm()
        {
            InitializeComponent();
            order = new Order();
            item = new OrderManagementSystem.OrderItem();
            goodsIDtxt.DataBindings.Add("Text", item, "ID");
            goodsPricetxt.DataBindings.Add("Text", item, "Price");
            goodsAmountxt.DataBindings.Add("Text", item, "Amount");
        }

        public editForm(Order order):this()
        {
            this.order = order;
            orderItemBindingSource.DataSource = order.itemList;
        }

        private void OKbtn_Click(object sender, EventArgs e)
        {
            order.Customer = customertxt.Text;
        }

        private void addItembtn_Click(object sender, EventArgs e)
        {
            if (item.Amount == 0)
                return;

            OrderItem aitem = new OrderItem(item.ID, item.Price, item.Amount);

            for (int i = 0; i < order.itemList.Count; i++)
            {
                if (order.itemList[i].ID == aitem.ID)
                {
                    order.itemList[i] = aitem;

                    dataGridView1.DataSource = new nlist<OrderItem>();
                    dataGridView1.DataSource = order.itemList;
                    return;
                }
            }
            order.itemList.Add(aitem);
        }

        private void deletbtn_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewCell cell in dataGridView1.SelectedCells)
            {
                dataGridView1.Rows[cell.RowIndex].Selected = true;
            }

            foreach (DataGridViewRow row in dataGridView1.SelectedRows)
            {
                int? selectID = row.Cells[0].Value as int?;
                if (selectID == null)
                    return;
                int ID = (int)selectID;
                for (int i = 0; i < order.itemList.Count; i++)
                {
                    if (order.itemList[i].ID == ID)
                        order.itemList.RemoveAt(i);
                }
            }
        }
    }
}
