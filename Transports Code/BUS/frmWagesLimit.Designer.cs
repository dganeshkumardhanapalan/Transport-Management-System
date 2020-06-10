namespace BUS
{
    partial class frmWagesLimit
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
            this.gb1 = new System.Windows.Forms.GroupBox();
            this.cbdepartment = new System.Windows.Forms.ComboBox();
            this.label28 = new System.Windows.Forms.Label();
            this.btCancel = new System.Windows.Forms.Button();
            this.btDelete = new System.Windows.Forms.Button();
            this.btSave = new System.Windows.Forms.Button();
            this.cbbusname = new System.Windows.Forms.ComboBox();
            this.label25 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tbWages = new System.Windows.Forms.TextBox();
            this.tbUpper = new System.Windows.Forms.TextBox();
            this.tbLower = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.gvData = new System.Windows.Forms.DataGridView();
            this.gb1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvData)).BeginInit();
            this.SuspendLayout();
            // 
            // gb1
            // 
            this.gb1.Controls.Add(this.cbdepartment);
            this.gb1.Controls.Add(this.label28);
            this.gb1.Controls.Add(this.btCancel);
            this.gb1.Controls.Add(this.btDelete);
            this.gb1.Controls.Add(this.btSave);
            this.gb1.Controls.Add(this.cbbusname);
            this.gb1.Controls.Add(this.label25);
            this.gb1.Controls.Add(this.label3);
            this.gb1.Controls.Add(this.label2);
            this.gb1.Controls.Add(this.label1);
            this.gb1.Controls.Add(this.tbWages);
            this.gb1.Controls.Add(this.tbUpper);
            this.gb1.Controls.Add(this.tbLower);
            this.gb1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gb1.Location = new System.Drawing.Point(3, 12);
            this.gb1.Name = "gb1";
            this.gb1.Size = new System.Drawing.Size(667, 267);
            this.gb1.TabIndex = 2;
            this.gb1.TabStop = false;
            this.gb1.Text = "Wages Limit Setting";
            // 
            // cbdepartment
            // 
            this.cbdepartment.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbdepartment.FormattingEnabled = true;
            this.cbdepartment.Items.AddRange(new object[] {
            "-Select-",
            "Driver",
            "Conductor"});
            this.cbdepartment.Location = new System.Drawing.Point(481, 36);
            this.cbdepartment.Name = "cbdepartment";
            this.cbdepartment.Size = new System.Drawing.Size(157, 28);
            this.cbdepartment.TabIndex = 2;
            this.cbdepartment.SelectedIndexChanged += new System.EventHandler(this.cbdepartment_SelectedIndexChanged);
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.Location = new System.Drawing.Point(353, 40);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(104, 20);
            this.label28.TabIndex = 9;
            this.label28.Text = "Department";
            // 
            // btCancel
            // 
            this.btCancel.Location = new System.Drawing.Point(463, 206);
            this.btCancel.Name = "btCancel";
            this.btCancel.Size = new System.Drawing.Size(113, 31);
            this.btCancel.TabIndex = 8;
            this.btCancel.Text = "&Cancel";
            this.btCancel.UseVisualStyleBackColor = true;
            this.btCancel.Click += new System.EventHandler(this.btCancel_Click);
            // 
            // btDelete
            // 
            this.btDelete.Location = new System.Drawing.Point(284, 206);
            this.btDelete.Name = "btDelete";
            this.btDelete.Size = new System.Drawing.Size(113, 31);
            this.btDelete.TabIndex = 7;
            this.btDelete.Text = "&Delete";
            this.btDelete.UseVisualStyleBackColor = true;
            this.btDelete.Click += new System.EventHandler(this.btDelete_Click);
            // 
            // btSave
            // 
            this.btSave.Location = new System.Drawing.Point(114, 206);
            this.btSave.Name = "btSave";
            this.btSave.Size = new System.Drawing.Size(113, 31);
            this.btSave.TabIndex = 6;
            this.btSave.Text = "&Save";
            this.btSave.UseVisualStyleBackColor = true;
            this.btSave.Click += new System.EventHandler(this.btSave_Click);
            // 
            // cbbusname
            // 
            this.cbbusname.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbbusname.FormattingEnabled = true;
            this.cbbusname.Location = new System.Drawing.Point(156, 36);
            this.cbbusname.Name = "cbbusname";
            this.cbbusname.Size = new System.Drawing.Size(157, 28);
            this.cbbusname.TabIndex = 1;
            this.cbbusname.SelectedIndexChanged += new System.EventHandler(this.cbbusname_SelectedIndexChanged);
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label25.Location = new System.Drawing.Point(9, 40);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(91, 20);
            this.label25.TabIndex = 5;
            this.label25.Text = "Bus Name";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(9, 152);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(131, 20);
            this.label3.TabIndex = 3;
            this.label3.Text = "Wages Amount";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(353, 93);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(101, 20);
            this.label2.TabIndex = 3;
            this.label2.Text = "Upper Limit";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(9, 96);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 20);
            this.label1.TabIndex = 3;
            this.label1.Text = "Lower Limit";
            // 
            // tbWages
            // 
            this.tbWages.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbWages.Location = new System.Drawing.Point(156, 149);
            this.tbWages.Name = "tbWages";
            this.tbWages.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.tbWages.Size = new System.Drawing.Size(157, 26);
            this.tbWages.TabIndex = 5;
            this.tbWages.Text = "0.00";
            this.tbWages.TextChanged += new System.EventHandler(this.tbWages_TextChanged);
            this.tbWages.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbWages_KeyPress);
            this.tbWages.Leave += new System.EventHandler(this.tbWages_Leave);
            // 
            // tbUpper
            // 
            this.tbUpper.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbUpper.Location = new System.Drawing.Point(481, 90);
            this.tbUpper.Name = "tbUpper";
            this.tbUpper.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.tbUpper.Size = new System.Drawing.Size(157, 26);
            this.tbUpper.TabIndex = 4;
            this.tbUpper.Text = "0.00";
            this.tbUpper.TextChanged += new System.EventHandler(this.tbUpper_TextChanged);
            this.tbUpper.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbUpper_KeyPress);
            this.tbUpper.Leave += new System.EventHandler(this.tbUpper_Leave);
            // 
            // tbLower
            // 
            this.tbLower.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbLower.Location = new System.Drawing.Point(156, 93);
            this.tbLower.Name = "tbLower";
            this.tbLower.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.tbLower.Size = new System.Drawing.Size(157, 26);
            this.tbLower.TabIndex = 3;
            this.tbLower.Text = "0.00";
            this.tbLower.TextChanged += new System.EventHandler(this.tbLower_TextChanged);
            this.tbLower.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbLower_KeyPress);
            this.tbLower.Leave += new System.EventHandler(this.tbLower_Leave);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.gvData);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(3, 285);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(667, 297);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Wages Data";
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
            this.gvData.Size = new System.Drawing.Size(661, 272);
            this.gvData.TabIndex = 1;
            this.gvData.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gvData_CellDoubleClick);
            // 
            // frmWagesLimit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(682, 594);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.gb1);
            this.MaximizeBox = false;
            this.Name = "frmWagesLimit";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Wages Limit";
            this.Load += new System.EventHandler(this.frmWagesLimit_Load);
            this.gb1.ResumeLayout(false);
            this.gb1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gvData)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gb1;
        private System.Windows.Forms.ComboBox cbbusname;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbLower;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbUpper;
        private System.Windows.Forms.Button btCancel;
        private System.Windows.Forms.Button btDelete;
        private System.Windows.Forms.Button btSave;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbWages;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView gvData;
        private System.Windows.Forms.ComboBox cbdepartment;
        private System.Windows.Forms.Label label28;


    }
}