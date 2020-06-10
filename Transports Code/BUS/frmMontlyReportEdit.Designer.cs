namespace BUS
{
    partial class frmMontlyReportEdit
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
            this.gvData = new System.Windows.Forms.DataGridView();
            this.groupbox1 = new System.Windows.Forms.GroupBox();
            this.btcreatereport = new System.Windows.Forms.Button();
            this.dtptodate = new System.Windows.Forms.DateTimePicker();
            this.dtpfromdate = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.gb1 = new System.Windows.Forms.GroupBox();
            this.tbcancel = new System.Windows.Forms.Button();
            this.btdetele = new System.Windows.Forms.Button();
            this.btupdate = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.tbremark = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.tbamount = new System.Windows.Forms.TextBox();
            this.cbtype = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cbbusname = new System.Windows.Forms.ComboBox();
            this.label25 = new System.Windows.Forms.Label();
            this.dtpdate = new System.Windows.Forms.DateTimePicker();
            this.label14 = new System.Windows.Forms.Label();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvData)).BeginInit();
            this.groupbox1.SuspendLayout();
            this.gb1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.gvData);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.groupBox2.Location = new System.Drawing.Point(0, 54);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(700, 178);
            this.groupBox2.TabIndex = 10;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Scheduled Data";
            // 
            // gvData
            // 
            this.gvData.AllowUserToAddRows = false;
            this.gvData.AllowUserToDeleteRows = false;
            this.gvData.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.gvData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gvData.Location = new System.Drawing.Point(3, 16);
            this.gvData.MultiSelect = false;
            this.gvData.Name = "gvData";
            this.gvData.ReadOnly = true;
            this.gvData.RowHeadersVisible = false;
            this.gvData.RowTemplate.Height = 25;
            this.gvData.RowTemplate.ReadOnly = true;
            this.gvData.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.gvData.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gvData.Size = new System.Drawing.Size(694, 159);
            this.gvData.TabIndex = 0;
            this.gvData.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gvData_CellDoubleClick);
            // 
            // groupbox1
            // 
            this.groupbox1.Controls.Add(this.btcreatereport);
            this.groupbox1.Controls.Add(this.dtptodate);
            this.groupbox1.Controls.Add(this.dtpfromdate);
            this.groupbox1.Controls.Add(this.label3);
            this.groupbox1.Controls.Add(this.label2);
            this.groupbox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupbox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupbox1.Location = new System.Drawing.Point(0, 0);
            this.groupbox1.Name = "groupbox1";
            this.groupbox1.Size = new System.Drawing.Size(700, 54);
            this.groupbox1.TabIndex = 9;
            this.groupbox1.TabStop = false;
            this.groupbox1.Text = "Option";
            // 
            // btcreatereport
            // 
            this.btcreatereport.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btcreatereport.Location = new System.Drawing.Point(481, 19);
            this.btcreatereport.Name = "btcreatereport";
            this.btcreatereport.Size = new System.Drawing.Size(122, 23);
            this.btcreatereport.TabIndex = 10;
            this.btcreatereport.Text = "Search";
            this.btcreatereport.UseVisualStyleBackColor = true;
            this.btcreatereport.Click += new System.EventHandler(this.btcreatereport_Click);
            // 
            // dtptodate
            // 
            this.dtptodate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtptodate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtptodate.Location = new System.Drawing.Point(341, 20);
            this.dtptodate.Name = "dtptodate";
            this.dtptodate.Size = new System.Drawing.Size(94, 20);
            this.dtptodate.TabIndex = 9;
            // 
            // dtpfromdate
            // 
            this.dtpfromdate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpfromdate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpfromdate.Location = new System.Drawing.Point(130, 20);
            this.dtpfromdate.Name = "dtpfromdate";
            this.dtpfromdate.Size = new System.Drawing.Size(92, 20);
            this.dtpfromdate.TabIndex = 8;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(271, 22);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 16);
            this.label3.TabIndex = 6;
            this.label3.Text = "To Date";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(31, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 16);
            this.label2.TabIndex = 5;
            this.label2.Text = "From Date";
            // 
            // gb1
            // 
            this.gb1.Controls.Add(this.tbcancel);
            this.gb1.Controls.Add(this.btdetele);
            this.gb1.Controls.Add(this.btupdate);
            this.gb1.Controls.Add(this.label1);
            this.gb1.Controls.Add(this.tbremark);
            this.gb1.Controls.Add(this.label5);
            this.gb1.Controls.Add(this.tbamount);
            this.gb1.Controls.Add(this.cbtype);
            this.gb1.Controls.Add(this.label4);
            this.gb1.Controls.Add(this.cbbusname);
            this.gb1.Controls.Add(this.label25);
            this.gb1.Controls.Add(this.dtpdate);
            this.gb1.Controls.Add(this.label14);
            this.gb1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gb1.Location = new System.Drawing.Point(3, 238);
            this.gb1.Name = "gb1";
            this.gb1.Size = new System.Drawing.Size(694, 204);
            this.gb1.TabIndex = 11;
            this.gb1.TabStop = false;
            this.gb1.Text = "Total Collection";
            // 
            // tbcancel
            // 
            this.tbcancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbcancel.Location = new System.Drawing.Point(601, 157);
            this.tbcancel.Name = "tbcancel";
            this.tbcancel.Size = new System.Drawing.Size(75, 23);
            this.tbcancel.TabIndex = 32;
            this.tbcancel.Text = "&Clear";
            this.tbcancel.UseVisualStyleBackColor = true;
            this.tbcancel.Click += new System.EventHandler(this.tbcancel_Click);
            // 
            // btdetele
            // 
            this.btdetele.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btdetele.Location = new System.Drawing.Point(490, 157);
            this.btdetele.Name = "btdetele";
            this.btdetele.Size = new System.Drawing.Size(75, 23);
            this.btdetele.TabIndex = 32;
            this.btdetele.Text = "&Delete";
            this.btdetele.UseVisualStyleBackColor = true;
            this.btdetele.Click += new System.EventHandler(this.btdetele_Click);
            // 
            // btupdate
            // 
            this.btupdate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btupdate.Location = new System.Drawing.Point(374, 158);
            this.btupdate.Name = "btupdate";
            this.btupdate.Size = new System.Drawing.Size(75, 23);
            this.btupdate.TabIndex = 31;
            this.btupdate.Text = "&Update";
            this.btupdate.UseVisualStyleBackColor = true;
            this.btupdate.Click += new System.EventHandler(this.btupdate_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(306, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 16);
            this.label1.TabIndex = 34;
            this.label1.Text = "Remark";
            // 
            // tbremark
            // 
            this.tbremark.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbremark.Location = new System.Drawing.Point(374, 26);
            this.tbremark.Multiline = true;
            this.tbremark.Name = "tbremark";
            this.tbremark.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.tbremark.Size = new System.Drawing.Size(302, 113);
            this.tbremark.TabIndex = 29;
            this.tbremark.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(63, 164);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(59, 16);
            this.label5.TabIndex = 33;
            this.label5.Text = "Amount";
            // 
            // tbamount
            // 
            this.tbamount.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbamount.Location = new System.Drawing.Point(128, 161);
            this.tbamount.Name = "tbamount";
            this.tbamount.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.tbamount.Size = new System.Drawing.Size(134, 22);
            this.tbamount.TabIndex = 26;
            this.tbamount.Text = "0.00";
            this.tbamount.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbamount_KeyPress);
            this.tbamount.Leave += new System.EventHandler(this.tbamount_Leave);
            // 
            // cbtype
            // 
            this.cbtype.FormattingEnabled = true;
            this.cbtype.Location = new System.Drawing.Point(128, 115);
            this.cbtype.Name = "cbtype";
            this.cbtype.Size = new System.Drawing.Size(134, 24);
            this.cbtype.TabIndex = 25;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(14, 119);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(108, 16);
            this.label4.TabIndex = 28;
            this.label4.Text = "Expense Type";
            // 
            // cbbusname
            // 
            this.cbbusname.FormattingEnabled = true;
            this.cbbusname.Location = new System.Drawing.Point(128, 70);
            this.cbbusname.Name = "cbbusname";
            this.cbbusname.Size = new System.Drawing.Size(134, 24);
            this.cbbusname.TabIndex = 24;
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label25.Location = new System.Drawing.Point(43, 74);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(79, 16);
            this.label25.TabIndex = 27;
            this.label25.Text = "Bus Name";
            // 
            // dtpdate
            // 
            this.dtpdate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpdate.Location = new System.Drawing.Point(128, 26);
            this.dtpdate.Name = "dtpdate";
            this.dtpdate.Size = new System.Drawing.Size(134, 22);
            this.dtpdate.TabIndex = 23;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(81, 29);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(41, 16);
            this.label14.TabIndex = 30;
            this.label14.Text = "Date";
            // 
            // frmMontlyReportEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(700, 447);
            this.Controls.Add(this.gb1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupbox1);
            this.MaximizeBox = false;
            this.Name = "frmMontlyReportEdit";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Montly Report Edit";
            this.Load += new System.EventHandler(this.frmMontlyReportEdit_Load);
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gvData)).EndInit();
            this.groupbox1.ResumeLayout(false);
            this.groupbox1.PerformLayout();
            this.gb1.ResumeLayout(false);
            this.gb1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView gvData;
        private System.Windows.Forms.GroupBox groupbox1;
        private System.Windows.Forms.Button btcreatereport;
        private System.Windows.Forms.DateTimePicker dtptodate;
        private System.Windows.Forms.DateTimePicker dtpfromdate;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox gb1;
        private System.Windows.Forms.Button btdetele;
        private System.Windows.Forms.Button btupdate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbremark;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tbamount;
        private System.Windows.Forms.ComboBox cbtype;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cbbusname;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.DateTimePicker dtpdate;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Button tbcancel;
    }
}