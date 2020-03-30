namespace CayleyTree
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.btnDraw = new System.Windows.Forms.Button();
            this.txtN = new System.Windows.Forms.TextBox();
            this.txtLeng = new System.Windows.Forms.TextBox();
            this.txtPer1 = new System.Windows.Forms.TextBox();
            this.txtPer2 = new System.Windows.Forms.TextBox();
            this.txtTh1 = new System.Windows.Forms.TextBox();
            this.txtTh2 = new System.Windows.Forms.TextBox();
            this.lblN = new System.Windows.Forms.Label();
            this.lblLeng = new System.Windows.Forms.Label();
            this.lblPer1 = new System.Windows.Forms.Label();
            this.lblPer2 = new System.Windows.Forms.Label();
            this.lblTh1 = new System.Windows.Forms.Label();
            this.lblth2 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnColor = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnDraw
            // 
            this.btnDraw.Location = new System.Drawing.Point(632, 329);
            this.btnDraw.Name = "btnDraw";
            this.btnDraw.Size = new System.Drawing.Size(81, 23);
            this.btnDraw.TabIndex = 0;
            this.btnDraw.Text = "Draw(&D)";
            this.btnDraw.UseVisualStyleBackColor = true;
            this.btnDraw.Click += new System.EventHandler(this.btnDraw_Click);
            // 
            // txtN
            // 
            this.txtN.Location = new System.Drawing.Point(657, 72);
            this.txtN.Name = "txtN";
            this.txtN.Size = new System.Drawing.Size(100, 25);
            this.txtN.TabIndex = 0;
            this.txtN.Text = "10";
            this.txtN.TextChanged += new System.EventHandler(this.txtN_TextChanged);
            // 
            // txtLeng
            // 
            this.txtLeng.Location = new System.Drawing.Point(657, 103);
            this.txtLeng.Name = "txtLeng";
            this.txtLeng.Size = new System.Drawing.Size(100, 25);
            this.txtLeng.TabIndex = 0;
            this.txtLeng.Text = "100";
            this.txtLeng.TextChanged += new System.EventHandler(this.txtLeng_TextChanged);
            // 
            // txtPer1
            // 
            this.txtPer1.Location = new System.Drawing.Point(657, 134);
            this.txtPer1.Name = "txtPer1";
            this.txtPer1.Size = new System.Drawing.Size(100, 25);
            this.txtPer1.TabIndex = 0;
            this.txtPer1.Text = "0.6";
            this.txtPer1.TextChanged += new System.EventHandler(this.txtPer1_TextChanged);
            // 
            // txtPer2
            // 
            this.txtPer2.Location = new System.Drawing.Point(657, 165);
            this.txtPer2.Name = "txtPer2";
            this.txtPer2.Size = new System.Drawing.Size(100, 25);
            this.txtPer2.TabIndex = 0;
            this.txtPer2.Text = "0.7";
            this.txtPer2.TextChanged += new System.EventHandler(this.txtPer2_TextChanged);
            // 
            // txtTh1
            // 
            this.txtTh1.Location = new System.Drawing.Point(657, 196);
            this.txtTh1.Name = "txtTh1";
            this.txtTh1.Size = new System.Drawing.Size(100, 25);
            this.txtTh1.TabIndex = 0;
            this.txtTh1.Text = "30";
            this.txtTh1.TextChanged += new System.EventHandler(this.txtTh1_TextChanged);
            // 
            // txtTh2
            // 
            this.txtTh2.Location = new System.Drawing.Point(657, 227);
            this.txtTh2.Name = "txtTh2";
            this.txtTh2.Size = new System.Drawing.Size(100, 25);
            this.txtTh2.TabIndex = 0;
            this.txtTh2.Text = "20";
            this.txtTh2.TextChanged += new System.EventHandler(this.txtTh2_TextChanged);
            // 
            // lblN
            // 
            this.lblN.AutoSize = true;
            this.lblN.Location = new System.Drawing.Point(584, 75);
            this.lblN.Name = "lblN";
            this.lblN.Size = new System.Drawing.Size(67, 15);
            this.lblN.TabIndex = 1;
            this.lblN.Text = "递归深度";
            // 
            // lblLeng
            // 
            this.lblLeng.AutoSize = true;
            this.lblLeng.Location = new System.Drawing.Point(584, 106);
            this.lblLeng.Name = "lblLeng";
            this.lblLeng.Size = new System.Drawing.Size(67, 15);
            this.lblLeng.TabIndex = 1;
            this.lblLeng.Text = "主干长度";
            // 
            // lblPer1
            // 
            this.lblPer1.AutoSize = true;
            this.lblPer1.Location = new System.Drawing.Point(554, 137);
            this.lblPer1.Name = "lblPer1";
            this.lblPer1.Size = new System.Drawing.Size(97, 15);
            this.lblPer1.TabIndex = 1;
            this.lblPer1.Text = "右分支长度比";
            // 
            // lblPer2
            // 
            this.lblPer2.AutoSize = true;
            this.lblPer2.Location = new System.Drawing.Point(554, 168);
            this.lblPer2.Name = "lblPer2";
            this.lblPer2.Size = new System.Drawing.Size(97, 15);
            this.lblPer2.TabIndex = 1;
            this.lblPer2.Text = "左分支长度比";
            // 
            // lblTh1
            // 
            this.lblTh1.AutoSize = true;
            this.lblTh1.Location = new System.Drawing.Point(569, 199);
            this.lblTh1.Name = "lblTh1";
            this.lblTh1.Size = new System.Drawing.Size(82, 15);
            this.lblTh1.TabIndex = 1;
            this.lblTh1.Text = "右分支角度";
            // 
            // lblth2
            // 
            this.lblth2.AutoSize = true;
            this.lblth2.Location = new System.Drawing.Point(569, 230);
            this.lblth2.Name = "lblth2";
            this.lblth2.Size = new System.Drawing.Size(82, 15);
            this.lblth2.TabIndex = 1;
            this.lblth2.Text = "左分支角度";
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(23, 24);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(500, 396);
            this.panel1.TabIndex = 2;
            // 
            // btnColor
            // 
            this.btnColor.Location = new System.Drawing.Point(632, 286);
            this.btnColor.Name = "btnColor";
            this.btnColor.Size = new System.Drawing.Size(81, 23);
            this.btnColor.TabIndex = 3;
            this.btnColor.Text = "Color(&C)";
            this.btnColor.UseVisualStyleBackColor = true;
            this.btnColor.Click += new System.EventHandler(this.btnColor_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnColor);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.lblth2);
            this.Controls.Add(this.lblTh1);
            this.Controls.Add(this.lblPer2);
            this.Controls.Add(this.lblPer1);
            this.Controls.Add(this.lblLeng);
            this.Controls.Add(this.lblN);
            this.Controls.Add(this.txtTh2);
            this.Controls.Add(this.txtTh1);
            this.Controls.Add(this.txtPer2);
            this.Controls.Add(this.txtPer1);
            this.Controls.Add(this.txtLeng);
            this.Controls.Add(this.txtN);
            this.Controls.Add(this.btnDraw);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnDraw;
        private System.Windows.Forms.TextBox txtN;
        private System.Windows.Forms.TextBox txtLeng;
        private System.Windows.Forms.TextBox txtPer1;
        private System.Windows.Forms.TextBox txtPer2;
        private System.Windows.Forms.TextBox txtTh1;
        private System.Windows.Forms.TextBox txtTh2;
        private System.Windows.Forms.Label lblN;
        private System.Windows.Forms.Label lblLeng;
        private System.Windows.Forms.Label lblPer1;
        private System.Windows.Forms.Label lblPer2;
        private System.Windows.Forms.Label lblTh1;
        private System.Windows.Forms.Label lblth2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnColor;
    }
}

