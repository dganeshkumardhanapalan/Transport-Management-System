namespace BUS
{
    partial class frmBataLimit
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
            this.cbdepartment = new System.Windows.Forms.ComboBox();
            this.label28 = new System.Windows.Forms.Label();
            this.btCancel = new System.Windows.Forms.Button();
            this.btDelete = new System.Windows.Forms.Button();
            this.btSave = new System.Windows.Forms.Button();
            this.tbBata = new System.Windows.Forms.TextBox();
            this.tbUpper = new System.Windows.Forms.TextBox();
            this.tbLower = new System.Windows.Forms.TextBox();
            this.cbbusname = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.gvData = new System.Windows.Forms.DataGridView();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvData)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cbdepartment);
            this.groupBox1.Controls.Add(this.label28);
            this.groupBox1.Controls.Add(this.btCancel);
            this.groupBox1.Controls.Add(this.btDelete);
            this.groupBox1.Controls.Add(this.btSave);
            this.groupBox1.Controls.Add(this.tbBata);
            this.groupBox1.Controls.Add(this.tbUpper);
            this.groupBox1.Controls.Add(this.tbLower);
            this.groupBox1.Controls.Add(this.cbbusname);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.groupBox1.Location = new System.Drawing.Point(12, 22);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(762, 250);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Bata Limit Setting";
            // 
            // cbdepartment
            // 
            this.cbdepartment.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbdepartment.FormattingEnabled = true;
            this.cbdepartment.Items.AddRange(new object[] {
            "-Select-",
            "Driver",
            "Conductor"});
            this.cbdepartment.Location = new System.Drawing.Point(536, 37);
            this.cbdepartment.Name = "cbdepartment";
            this.cbdepartment.Size = new System.Drawing.Size(185, 28);
            this.cbdepartment.TabIndex = 2;
            this.cbdepartment.SelectedIndexChanged += new System.EventHandler(this.cbdepartment_SelectedIndexChanged);
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.Location = new System.Drawing.Point(389, 41);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(104, 20);
            this.label28.TabIndex = 13;
            this.label28.Text = "Department";
            // 
            // btCancel
            // 
            this.btCancel.Location = new System.Drawing.Point(485, 197);
            this.btCancel.Name = "btCancel";
            this.btCancel.Size = new System.Drawing.Size(100, 38);
            this.btCancel.TabIndex = 8;
            this.btCancel.Text = "Clear";
            this.btCancel.UseVisualStyleBackColor = true;
            this.btCancel.Click += new System.EventHandler(this.btCancel_Click);
            // 
            // btDelete
            // 
            this.btDelete.Location = new System.Drawing.Point(339, 199);
            this.btDelete.Name = "btDelete";
            this.btDelete.Size = new System.Drawing.Size(100, 35);
            this.btDelete.TabIndex = 7;
            this.btDelete.Text = "Delete";
            this.btDelete.UseVisualStyleBackColor = true;
            this.btDelete.Click += new System.EventHandler(this.btDelete_Click);
            // 
            // btSave
            // 
            this.btSave.Location = new System.Drawing.Point(189, 199);
            this.btSave.Name = "btSave";
            this.btSave.Size = new System.Drawing.Size(100, 32);
            this.btSave.TabIndex = 6;
            this.btSave.Text = "Save";
            this.btSave.UseVisualStyleBackColor = true;
            this.btSave.Click += new System.EventHandler(this.btSave_Click);
            // 
            // tbBata
            // 
            this.tbBata.Location = new System.Drawing.Point(154, 144);
            this.tbBata.Name = "tbBata";
            this.tbBata.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.tbBata.Size = new System.Drawing.Size(184, 26);
            this.tbBata.TabIndex = 5;
            this.tbBata.Text = "0.00";
            this.tbBata.TextChanged += new System.EventHandler(this.tbBata_TextChanged);
            this.tbBata.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbBata_KeyPress);
            this.tbBata.Leave += new System.EventHandler(this.tbBata_Leave);
            // 
            // tbUpper
            // 
            this.tbUpper.Location = new System.Drawing.Point(537, 91);
            this.tbUpper.Name = "tbUpper";
            this.tbUpper.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.tbUpper.Size = new System.Drawing.Size(184, 26);
            this.tbUpper.TabIndex = 4;
            this.tbUpper.Text = "0.00";
            this.tbUpper.TextChanged += new System.EventHandler(this.tbUpper_TextChanged);
            this.tbUpper.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbUpper_KeyPress);
            this.tbUpper.Leave += new System.EventHandler(this.tbUpper_Leave);
            // 
            // tbLower
            // 
            this.tbLower.Location = new System.Drawing.Point(154, 91);
            this.tbLower.Name = "tbLower";
            this.tbLower.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.tbLower.Size = new System.Drawing.Size(184, 26);
            this.tbLower.TabIndex = 3;
            this.tbLower.Text = "0.00";
            this.tbLower.TextChanged += new System.EventHandler(this.tbLower_TextChanged);
            this.tbLower.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbLower_KeyPress);
            this.tbLower.Leave += new System.EventHandler(this.tbLower_Leave);
            // 
            // cbbusname
            // 
            this.cbbusname.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbbusname.FormattingEnabled = true;
            this.cbbusname.Location = new System.Drawing.Point(154, 37);
            this.cbbusname.Name = "cbbusname";
            this.cbbusname.Size = new System.Drawing.Size(184, 28);
            this.cbbusname.TabIndex = 1;
            this.cbbusname.SelectedIndexChanged += new System.EventHandler(this.cbbusname_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 147);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(86, 20);
            this.label4.TabIndex = 3;
            this.label4.Text = "Bata in %";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(389, 94);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(101, 20);
            this.label3.TabIndex = 2;
            this.label3.Text = "Upper Limit";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 94);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "Lower Limit";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(91, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Bus Name";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.gvData);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.groupBox2.Location = new System.Drawing.Point(12, 278);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(765, 318);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Bata Amount";
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
            this.gvData.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gvData.Size = new System.Drawing.Size(759, 293);
            this.gvData.TabIndex = 1;
            this.gvData.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gvData_CellDoubleClick);
            // 
            // frmBataLimit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(790, 625);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "frmBataLimit";
            this.Text = "Bata Limit";
            this.Load += new System.EventHandler(this.frmBataLimit_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gvData)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbBata;
        private System.Windows.Forms.TextBox tbUpper;
        private System.Windows.Forms.TextBox tbLower;
        private System.Windows.Forms.ComboBox cbbusname;
        private System.Windows.Forms.Button btCancel;
        private System.Windows.Forms.Button btDelete;
        private System.Windows.Forms.Button btSave;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView gvData;
        private System.Windows.Forms.ComboBox cbdepartment;
        private System.Windows.Forms.Label label28;

    }
}