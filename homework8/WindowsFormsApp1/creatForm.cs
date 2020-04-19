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
    public partial class creatForm : Form
    {
        public delegate void mydel(Order order);

        mydel _dele;

        public OrderManagementSystem.Order order { set; get; }

        OrderManagementSystem.OrderItem item;
        public creatForm()
        {
            InitializeComponent();
            order = new OrderManagementSystem.Order();

            dataGridView1.DataSource = order.itemList;

            item = new OrderManagementSystem.OrderItem();
            goodsIDtxt.DataBindings.Add("Text", item, "ID");
            goodsPricetxt.DataBindings.Add("Text", item, "Price");
            goodsAmountxt.DataBindings.Add("Text", item, "Amount");
        }

        private void addItembtn_Click(object sender, EventArgs e)
        {
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
            
            dataGridView1.DataSource = new nlist<OrderItem>();
            dataGridView1.DataSource = order.itemList;
        }

        private void OKbtn_Click(object sender, EventArgs e)
        {
            order.Customer = customertxt.Text;
        }
    }
}
