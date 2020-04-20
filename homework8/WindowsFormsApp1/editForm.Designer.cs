namespace WindowsFormsApp1
{
    partial class editForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.panel2 = new System.Windows.Forms.Panel();
            this.OKbtn = new System.Windows.Forms.Button();
            this.deletbtn = new System.Windows.Forms.Button();
            this.addItembtn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.customertxt = new System.Windows.Forms.TextBox();
            this.goodsPricelbl = new System.Windows.Forms.Label();
            this.goodsPricetxt = new System.Windows.Forms.TextBox();
            this.goodsAmountlbl = new System.Windows.Forms.Label();
            this.goodsAmountxt = new System.Windows.Forms.TextBox();
            this.goodsIDlbl = new System.Windows.Forms.Label();
            this.goodsIDtxt = new System.Windows.Forms.TextBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Price = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Amount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.iDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.totalDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.orderItemBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.orderItemBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.OKbtn);
            this.panel2.Controls.Add(this.deletbtn);
            this.panel2.Controls.Add(this.addItembtn);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.customertxt);
            this.panel2.Controls.Add(this.goodsPricelbl);
            this.panel2.Controls.Add(this.goodsPricetxt);
            this.panel2.Controls.Add(this.goodsAmountlbl);
            this.panel2.Controls.Add(this.goodsAmountxt);
            this.panel2.Controls.Add(this.goodsIDlbl);
            this.panel2.Controls.Add(this.goodsIDtxt);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(675, 91);
            this.panel2.TabIndex = 1;
            // 
            // OKbtn
            // 
            this.OKbtn.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.OKbtn.Location = new System.Drawing.Point(188, 14);
            this.OKbtn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.OKbtn.Name = "OKbtn";
            this.OKbtn.Size = new System.Drawing.Size(91, 25);
            this.OKbtn.TabIndex = 11;
            this.OKbtn.Text = "确定创建";
            this.OKbtn.UseVisualStyleBackColor = true;
            this.OKbtn.Click += new System.EventHandler(this.OKbtn_Click);
            // 
            // deletbtn
            // 
            this.deletbtn.Location = new System.Drawing.Point(573, 14);
            this.deletbtn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.deletbtn.Name = "deletbtn";
            this.deletbtn.Size = new System.Drawing.Size(91, 25);
            this.deletbtn.TabIndex = 10;
            this.deletbtn.Text = "删除商品";
            this.deletbtn.UseVisualStyleBackColor = true;
            this.deletbtn.Click += new System.EventHandler(this.deletbtn_Click);
            // 
            // addItembtn
            // 
            this.addItembtn.Location = new System.Drawing.Point(573, 51);
            this.addItembtn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.addItembtn.Name = "addItembtn";
            this.addItembtn.Size = new System.Drawing.Size(91, 25);
            this.addItembtn.TabIndex = 10;
            this.addItembtn.Text = "添加商品";
            this.addItembtn.UseVisualStyleBackColor = true;
            this.addItembtn.Click += new System.EventHandler(this.addItembtn_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 15);
            this.label1.TabIndex = 9;
            this.label1.Text = "顾客ID";
            // 
            // customertxt
            // 
            this.customertxt.Location = new System.Drawing.Point(67, 14);
            this.customertxt.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.customertxt.Name = "customertxt";
            this.customertxt.Size = new System.Drawing.Size(100, 25);
            this.customertxt.TabIndex = 8;
            // 
            // goodsPricelbl
            // 
            this.goodsPricelbl.AutoSize = true;
            this.goodsPricelbl.Location = new System.Drawing.Point(383, 54);
            this.goodsPricelbl.Name = "goodsPricelbl";
            this.goodsPricelbl.Size = new System.Drawing.Size(67, 15);
            this.goodsPricelbl.TabIndex = 7;
            this.goodsPricelbl.Text = "商品单价";
            // 
            // goodsPricetxt
            // 
            this.goodsPricetxt.Location = new System.Drawing.Point(453, 51);
            this.goodsPricetxt.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.goodsPricetxt.Name = "goodsPricetxt";
            this.goodsPricetxt.Size = new System.Drawing.Size(100, 25);
            this.goodsPricetxt.TabIndex = 6;
            // 
            // goodsAmountlbl
            // 
            this.goodsAmountlbl.AutoSize = true;
            this.goodsAmountlbl.Location = new System.Drawing.Point(185, 54);
            this.goodsAmountlbl.Name = "goodsAmountlbl";
            this.goodsAmountlbl.Size = new System.Drawing.Size(67, 15);
            this.goodsAmountlbl.TabIndex = 5;
            this.goodsAmountlbl.Text = "商品数目";
            // 
            // goodsAmountxt
            // 
            this.goodsAmountxt.Location = new System.Drawing.Point(256, 51);
            this.goodsAmountxt.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.goodsAmountxt.Name = "goodsAmountxt";
            this.goodsAmountxt.Size = new System.Drawing.Size(100, 25);
            this.goodsAmountxt.TabIndex = 4;
            // 
            // goodsIDlbl
            // 
            this.goodsIDlbl.AutoSize = true;
            this.goodsIDlbl.Location = new System.Drawing.Point(11, 54);
            this.goodsIDlbl.Name = "goodsIDlbl";
            this.goodsIDlbl.Size = new System.Drawing.Size(53, 15);
            this.goodsIDlbl.TabIndex = 3;
            this.goodsIDlbl.Text = "商品ID";
            // 
            // goodsIDtxt
            // 
            this.goodsIDtxt.Location = new System.Drawing.Point(67, 51);
            this.goodsIDtxt.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.goodsIDtxt.Name = "goodsIDtxt";
            this.goodsIDtxt.Size = new System.Drawing.Size(100, 25);
            this.goodsIDtxt.TabIndex = 2;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.iDDataGridViewTextBoxColumn,
            this.Price,
            this.Amount,
            this.totalDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.orderItemBindingSource;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 91);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 27;
            this.dataGridView1.RowTemplate.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(675, 359);
            this.dataGridView1.TabIndex = 2;
            // 
            // Price
            // 
            this.Price.DataPropertyName = "Price";
            this.Price.HeaderText = "价格";
            this.Price.MinimumWidth = 6;
            this.Price.Name = "Price";
            // 
            // Amount
            // 
            this.Amount.DataPropertyName = "Amount";
            this.Amount.HeaderText = "数目";
            this.Amount.MinimumWidth = 6;
            this.Amount.Name = "Amount";
            // 
            // iDDataGridViewTextBoxColumn
            // 
            this.iDDataGridViewTextBoxColumn.DataPropertyName = "ID";
            this.iDDataGridViewTextBoxColumn.HeaderText = "商品ID";
            this.iDDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.iDDataGridViewTextBoxColumn.Name = "iDDataGridViewTextBoxColumn";
            // 
            // totalDataGridViewTextBoxColumn
            // 
            this.totalDataGridViewTextBoxColumn.DataPropertyName = "Total";
            this.totalDataGridViewTextBoxColumn.HeaderText = "总价";
            this.totalDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.totalDataGridViewTextBoxColumn.Name = "totalDataGridViewTextBoxColumn";
            this.totalDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // orderItemBindingSource
            // 
            this.orderItemBindingSource.DataSource = typeof(OrderManagementSystem.OrderItem);
            // 
            // editForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(675, 450);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.panel2);
            this.Name = "editForm";
            this.Text = "editForm";
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.orderItemBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button OKbtn;
        private System.Windows.Forms.Button deletbtn;
        private System.Windows.Forms.Button addItembtn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox customertxt;
        private System.Windows.Forms.Label goodsPricelbl;
        private System.Windows.Forms.TextBox goodsPricetxt;
        private System.Windows.Forms.Label goodsAmountlbl;
        private System.Windows.Forms.TextBox goodsAmountxt;
        private System.Windows.Forms.Label goodsIDlbl;
        private System.Windows.Forms.TextBox goodsIDtxt;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn iDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn Price;
        private System.Windows.Forms.DataGridViewTextBoxColumn Amount;
        private System.Windows.Forms.DataGridViewTextBoxColumn totalDataGridViewTextBoxColumn;
        private System.Windows.Forms.BindingSource orderItemBindingSource;
    }
}