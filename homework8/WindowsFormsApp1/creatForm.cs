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
    public partial class creatForm : Form
    {
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
            OrderManagementSystem.OrderItem additem = new OrderManagementSystem.OrderItem();
            additem.ID = item.ID;
            additem.Price = item.Price;
            additem.Amount = item.Amount;
            if(order.itemList.Contains(additem))
            {

            }
            order.itemList.Add(additem);
        }

        private void creatForm_FormClosed(object sender, FormClosedEventArgs e)
        {
         
        }
    }
}
