namespace BUS
{
    partial class frmTyerentry
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tbkm = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.btdelete = new System.Windows.Forms.Button();
            this.btcancel = new System.Windows.Forms.Button();
            this.btsave = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.tbremark = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.gvData = new System.Windows.Forms.DataGridView();
            this.tbmanu = new System.Windows.Forms.TextBox();
            this.cbcondition = new System.Windows.Forms.ComboBox();
            this.cbtyerno = new System.Windows.Forms.ComboBox();
            this.tbamount = new System.Windows.Forms.TextBox();
            this.tbtyersno = new System.Windows.Forms.TextBox();
            this.cbbusname = new System.Windows.Forms.ComboBox();
            this.dtpdate = new System.Windows.Forms.DateTimePicker();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tbkm);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.btdelete);
            this.groupBox1.Controls.Add(this.btcancel);
            this.groupBox1.Controls.Add(this.btsave);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.tbremark);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Controls.Add(this.tbmanu);
            this.groupBox1.Controls.Add(this.cbcondition);
            this.groupBox1.Controls.Add(this.cbtyerno);
            this.groupBox1.Controls.Add(this.tbamount);
            this.groupBox1.Controls.Add(this.tbtyersno);
            this.groupBox1.Controls.Add(this.cbbusname);
            this.groupBox1.Controls.Add(this.dtpdate);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(631, 693);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Expense on ";
            // 
            // tbkm
            // 
            this.tbkm.Location = new System.Drawing.Point(405, 99);
            this.tbkm.Name = "tbkm";
            this.tbkm.Size = new System.Drawing.Size(93, 22);
            this.tbkm.TabIndex = 2;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(504, 105);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(29, 16);
            this.label10.TabIndex = 18;
            this.label10.Text = "KM";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(331, 102);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(64, 16);
            this.label9.TabIndex = 17;
            this.label9.Text = "Entry on";
            // 
            // btdelete
            // 
            this.btdelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btdelete.Location = new System.Drawing.Point(446, 362);
            this.btdelete.Name = "btdelete";
            this.btdelete.Size = new System.Drawing.Size(75, 23);
            this.btdelete.TabIndex = 11;
            this.btdelete.Text = "&Delete";
            this.btdelete.UseVisualStyleBackColor = true;
            this.btdelete.Click += new System.EventHandler(this.btdelete_Click);
            // 
            // btcancel
            // 
            this.btcancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btcancel.Location = new System.Drawing.Point(446, 319);
            this.btcancel.Name = "btcancel";
            this.btcancel.Size = new System.Drawing.Size(75, 23);
            this.btcancel.TabIndex = 10;
            this.btcancel.Text = "&CLEAR";
            this.btcancel.UseVisualStyleBackColor = true;
            this.btcancel.Click += new System.EventHandler(this.btcancel_Click);
            // 
            // btsave
            // 
            this.btsave.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btsave.Location = new System.Drawing.Point(446, 274);
            this.btsave.Name = "btsave";
            this.btsave.Size = new System.Drawing.Size(75, 23);
            this.btsave.TabIndex = 9;
            this.btsave.Text = "&SAVE";
            this.btsave.UseVisualStyleBackColor = true;
            this.btsave.Click += new System.EventHandler(this.btsave_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(54, 309);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(62, 16);
            this.label8.TabIndex = 16;
            this.label8.Text = "Remark";
            // 
            // tbremark
            // 
            this.tbremark.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbremark.Location = new System.Drawing.Point(141, 274);
            this.tbremark.Multiline = true;
            this.tbremark.Name = "tbremark";
            this.tbremark.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.tbremark.Size = new System.Drawing.Size(270, 111);
            this.tbremark.TabIndex = 8;
            this.tbremark.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.gvData);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(6, 391);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(607, 296);
            this.groupBox2.TabIndex = 14;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Tyre Data";
            // 
            // gvData
            // 
            this.gvData.AllowUserToAddRows = false;
            this.gvData.AllowUserToDeleteRows = false;
            this.gvData.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.gvData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gvData.Location = new System.Drawing.Point(3, 22);
            this.gvData.MultiSelect = false;
            this.gvData.Name = "gvData";
            this.gvData.ReadOnly = true;
            this.gvData.RowHeadersVisible = false;
            this.gvData.RowTemplate.Height = 25;
            this.gvData.RowTemplate.ReadOnly = true;
            this.gvData.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.gvData.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gvData.Size = new System.Drawing.Size(601, 271);
            this.gvData.TabIndex = 11;
            this.gvData.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gvData_CellContentClick);
            this.gvData.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gvData_CellDoubleClick);
            // 
            // tbmanu
            // 
            this.tbmanu.Location = new System.Drawing.Point(141, 180);
            this.tbmanu.Name = "tbmanu";
            this.tbmanu.Size = new System.Drawing.Size(170, 22);
            this.tbmanu.TabIndex = 4;
            this.tbmanu.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // cbcondition
            // 
            this.cbcondition.FormattingEnabled = true;
            this.cbcondition.Items.AddRange(new object[] {
            "-select-",
            "Original",
            "Rebuild I",
            "Rebuild II",
            "Rebuild III",
            "Rebuild IV",
            "condament"});
            this.cbcondition.Location = new System.Drawing.Point(407, 220);
            this.cbcondition.Name = "cbcondition";
            this.cbcondition.Size = new System.Drawing.Size(114, 24);
            this.cbcondition.TabIndex = 7;
            // 
            // cbtyerno
            // 
            this.cbtyerno.FormattingEnabled = true;
            this.cbtyerno.Items.AddRange(new object[] {
            "-select-",
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7"});
            this.cbtyerno.Location = new System.Drawing.Point(141, 220);
            this.cbtyerno.Name = "cbtyerno";
            this.cbtyerno.Size = new System.Drawing.Size(170, 24);
            this.cbtyerno.TabIndex = 6;
            // 
            // tbamount
            // 
            this.tbamount.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbamount.Location = new System.Drawing.Point(407, 180);
            this.tbamount.Name = "tbamount";
            this.tbamount.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.tbamount.Size = new System.Drawing.Size(114, 22);
            this.tbamount.TabIndex = 5;
            this.tbamount.Text = "0.00";
            this.tbamount.TextChanged += new System.EventHandler(this.tbamount_TextChanged);
            this.tbamount.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbamount_KeyPress);
            // 
            // tbtyersno
            // 
            this.tbtyersno.Location = new System.Drawing.Point(141, 137);
            this.tbtyersno.Name = "tbtyersno";
            this.tbtyersno.Size = new System.Drawing.Size(170, 22);
            this.tbtyersno.TabIndex = 3;
            // 
            // cbbusname
            // 
            this.cbbusname.FormattingEnabled = true;
            this.cbbusname.Location = new System.Drawing.Point(141, 92);
            this.cbbusname.Name = "cbbusname";
            this.cbbusname.Size = new System.Drawing.Size(170, 24);
            this.cbbusname.TabIndex = 1;
            this.cbbusname.SelectedIndexChanged += new System.EventHandler(this.cbbusname_SelectedIndexChanged);
            // 
            // dtpdate
            // 
            this.dtpdate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpdate.Location = new System.Drawing.Point(141, 44);
            this.dtpdate.Name = "dtpdate";
            this.dtpdate.Size = new System.Drawing.Size(103, 22);
            this.dtpdate.TabIndex = 0;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(342, 183);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(59, 16);
            this.label7.TabIndex = 6;
            this.label7.Text = "Amount";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(328, 223);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(73, 16);
            this.label6.TabIndex = 5;
            this.label6.Text = "Condition";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(52, 220);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(64, 16);
            this.label5.TabIndex = 4;
            this.label5.Text = "Tyre No";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(19, 180);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(97, 16);
            this.label4.TabIndex = 3;
            this.label4.Text = "Manufacturer";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(36, 137);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(80, 16);
            this.label3.TabIndex = 2;
            this.label3.Text = "Tyre S.NO";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(37, 92);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "Bus Name";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(75, 44);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Date";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::BUS.Properties.Resources.Bus_Chassis;
            this.pictureBox1.Location = new System.Drawing.Point(649, 22);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(202, 482);
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            // 
            // frmTyerentry
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(874, 717);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.groupBox1);
            this.Name = "frmTyerentry";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Tyre Entry";
            this.Load += new System.EventHandler(this.frmTyerentry_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gvData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtpdate;
        private System.Windows.Forms.TextBox tbtyersno;
        private System.Windows.Forms.ComboBox cbbusname;
        private System.Windows.Forms.TextBox tbamount;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TextBox tbmanu;
        private System.Windows.Forms.ComboBox cbcondition;
        private System.Windows.Forms.ComboBox cbtyerno;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView gvData;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox tbremark;
        private System.Windows.Forms.Button btdelete;
        private System.Windows.Forms.Button btcancel;
        private System.Windows.Forms.Button btsave;
        private System.Windows.Forms.TextBox tbkm;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
    }
}