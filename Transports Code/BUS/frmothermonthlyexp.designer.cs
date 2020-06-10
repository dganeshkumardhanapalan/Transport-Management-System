namespace BUS
{
    partial class frmothermonthlyexp
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
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.cbCompanyName = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tbtyerno = new System.Windows.Forms.TextBox();
            this.btclear = new System.Windows.Forms.Button();
            this.btsave = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.tbremark = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.tbamount = new System.Windows.Forms.TextBox();
            this.cbtype = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cbbusname = new System.Windows.Forms.ComboBox();
            this.label25 = new System.Windows.Forms.Label();
            this.dtpdate = new System.Windows.Forms.DateTimePicker();
            this.label14 = new System.Windows.Forms.Label();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.cbCompanyName);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.tbtyerno);
            this.groupBox2.Controls.Add(this.btclear);
            this.groupBox2.Controls.Add(this.btsave);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.tbremark);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.tbamount);
            this.groupBox2.Controls.Add(this.cbtype);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.cbbusname);
            this.groupBox2.Controls.Add(this.label25);
            this.groupBox2.Controls.Add(this.dtpdate);
            this.groupBox2.Controls.Add(this.label14);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(7, 2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(654, 579);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Monthly Expense Entry";
            // 
            // cbCompanyName
            // 
            this.cbCompanyName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbCompanyName.FormattingEnabled = true;
            this.cbCompanyName.Location = new System.Drawing.Point(140, 83);
            this.cbCompanyName.Name = "cbCompanyName";
            this.cbCompanyName.Size = new System.Drawing.Size(237, 24);
            this.cbCompanyName.TabIndex = 26;
            this.cbCompanyName.SelectionChangeCommitted += new System.EventHandler(this.cbCompanyName_SelectionChangeCommitted);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(11, 83);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(118, 16);
            this.label4.TabIndex = 25;
            this.label4.Text = "Company Name";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(260, 221);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(98, 16);
            this.label3.TabIndex = 24;
            this.label3.Text = "Tyre Number";
            // 
            // tbtyerno
            // 
            this.tbtyerno.Location = new System.Drawing.Point(364, 215);
            this.tbtyerno.Name = "tbtyerno";
            this.tbtyerno.Size = new System.Drawing.Size(78, 22);
            this.tbtyerno.TabIndex = 23;
            this.tbtyerno.Visible = false;
            this.tbtyerno.TextChanged += new System.EventHandler(this.tbtyerno_TextChanged);
            this.tbtyerno.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbtyerno_KeyPress);
            // 
            // btclear
            // 
            this.btclear.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btclear.Location = new System.Drawing.Point(318, 511);
            this.btclear.Name = "btclear";
            this.btclear.Size = new System.Drawing.Size(75, 23);
            this.btclear.TabIndex = 7;
            this.btclear.Text = "&CLEAR";
            this.btclear.UseVisualStyleBackColor = true;
            this.btclear.Click += new System.EventHandler(this.btclear_Click);
            // 
            // btsave
            // 
            this.btsave.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btsave.Location = new System.Drawing.Point(172, 512);
            this.btsave.Name = "btsave";
            this.btsave.Size = new System.Drawing.Size(75, 23);
            this.btsave.TabIndex = 6;
            this.btsave.Text = "&SAVE";
            this.btsave.UseVisualStyleBackColor = true;
            this.btsave.Click += new System.EventHandler(this.btsave_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(11, 269);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 16);
            this.label1.TabIndex = 22;
            this.label1.Text = "Remark";
            // 
            // tbremark
            // 
            this.tbremark.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbremark.Location = new System.Drawing.Point(140, 266);
            this.tbremark.Multiline = true;
            this.tbremark.Name = "tbremark";
            this.tbremark.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.tbremark.Size = new System.Drawing.Size(302, 214);
            this.tbremark.TabIndex = 5;
            this.tbremark.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(11, 224);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(59, 16);
            this.label5.TabIndex = 22;
            this.label5.Text = "Amount";
            // 
            // tbamount
            // 
            this.tbamount.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbamount.Location = new System.Drawing.Point(140, 218);
            this.tbamount.Name = "tbamount";
            this.tbamount.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.tbamount.Size = new System.Drawing.Size(114, 22);
            this.tbamount.TabIndex = 4;
            this.tbamount.Text = "0.00";
            this.tbamount.TextChanged += new System.EventHandler(this.tbamount_TextChanged);
            this.tbamount.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbamount_KeyPress);
            this.tbamount.Leave += new System.EventHandler(this.tbamount_Leave);
            // 
            // cbtype
            // 
            this.cbtype.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbtype.FormattingEnabled = true;
            this.cbtype.Location = new System.Drawing.Point(140, 173);
            this.cbtype.Name = "cbtype";
            this.cbtype.Size = new System.Drawing.Size(237, 24);
            this.cbtype.TabIndex = 3;
            this.cbtype.SelectedIndexChanged += new System.EventHandler(this.cbtype_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(11, 176);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(108, 16);
            this.label2.TabIndex = 5;
            this.label2.Text = "Expense Type";
            // 
            // cbbusname
            // 
            this.cbbusname.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbusname.FormattingEnabled = true;
            this.cbbusname.Location = new System.Drawing.Point(140, 127);
            this.cbbusname.Name = "cbbusname";
            this.cbbusname.Size = new System.Drawing.Size(237, 24);
            this.cbbusname.TabIndex = 2;
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label25.Location = new System.Drawing.Point(11, 127);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(79, 16);
            this.label25.TabIndex = 5;
            this.label25.Text = "Bus Name";
            // 
            // dtpdate
            // 
            this.dtpdate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpdate.Location = new System.Drawing.Point(140, 42);
            this.dtpdate.Name = "dtpdate";
            this.dtpdate.Size = new System.Drawing.Size(123, 22);
            this.dtpdate.TabIndex = 1;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(11, 48);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(41, 16);
            this.label14.TabIndex = 5;
            this.label14.Text = "Date";
            // 
            // frmothermonthlyexp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(685, 593);
            this.Controls.Add(this.groupBox2);
            this.MaximizeBox = false;
            this.Name = "frmothermonthlyexp";
            this.Text = "Monthly Expense";
            this.Load += new System.EventHandler(this.frmothermonthlyexp_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ComboBox cbbusname;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.DateTimePicker dtpdate;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbremark;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tbamount;
        private System.Windows.Forms.ComboBox cbtype;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btclear;
        private System.Windows.Forms.Button btsave;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbtyerno;
        private System.Windows.Forms.ComboBox cbCompanyName;
        private System.Windows.Forms.Label label4;
    }
}