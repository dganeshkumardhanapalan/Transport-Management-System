namespace BUS
{
    partial class frmScheduleTypeEntry
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.btacancel = new System.Windows.Forms.Button();
            this.btaadd = new System.Windows.Forms.Button();
            this.tbaddcolorname = new System.Windows.Forms.TextBox();
            this.tbaddscheduletype = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.bteditcancel = new System.Windows.Forms.Button();
            this.btupdate = new System.Windows.Forms.Button();
            this.tbeditcolorname = new System.Windows.Forms.TextBox();
            this.tbedittype = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cmboxedittype = new System.Windows.Forms.ComboBox();
            this.btmodify = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.tbdeletecolor = new System.Windows.Forms.TextBox();
            this.tbdeletetype = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.cmboxdelete = new System.Windows.Forms.ComboBox();
            this.btdelete = new System.Windows.Forms.Button();
            this.label12 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.button4 = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.button5 = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.addcolorButton = new ColorButton.ColorButton();
            this.editcolorButton = new ColorButton.ColorButton();
            this.deletecolorButton = new ColorButton.ColorButton();
            this.colorButton1 = new ColorButton.ColorButton();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(330, 242);
            this.tabControl1.TabIndex = 0;
            this.tabControl1.Selected += new System.Windows.Forms.TabControlEventHandler(this.tabControl1_Selected);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.btacancel);
            this.tabPage1.Controls.Add(this.btaadd);
            this.tabPage1.Controls.Add(this.addcolorButton);
            this.tabPage1.Controls.Add(this.tbaddcolorname);
            this.tabPage1.Controls.Add(this.tbaddscheduletype);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(322, 216);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "ADD";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // btacancel
            // 
            this.btacancel.Location = new System.Drawing.Point(177, 153);
            this.btacancel.Name = "btacancel";
            this.btacancel.Size = new System.Drawing.Size(75, 23);
            this.btacancel.TabIndex = 3;
            this.btacancel.Text = "&Cancel";
            this.btacancel.UseVisualStyleBackColor = true;
            this.btacancel.Click += new System.EventHandler(this.btacancel_Click);
            // 
            // btaadd
            // 
            this.btaadd.Location = new System.Drawing.Point(63, 153);
            this.btaadd.Name = "btaadd";
            this.btaadd.Size = new System.Drawing.Size(75, 23);
            this.btaadd.TabIndex = 3;
            this.btaadd.Text = "&Add";
            this.btaadd.UseVisualStyleBackColor = true;
            this.btaadd.Click += new System.EventHandler(this.btaadd_Click);
            // 
            // tbaddcolorname
            // 
            this.tbaddcolorname.Enabled = false;
            this.tbaddcolorname.Location = new System.Drawing.Point(145, 84);
            this.tbaddcolorname.Name = "tbaddcolorname";
            this.tbaddcolorname.Size = new System.Drawing.Size(82, 20);
            this.tbaddcolorname.TabIndex = 1;
            // 
            // tbaddscheduletype
            // 
            this.tbaddscheduletype.Location = new System.Drawing.Point(145, 40);
            this.tbaddscheduletype.Name = "tbaddscheduletype";
            this.tbaddscheduletype.Size = new System.Drawing.Size(144, 20);
            this.tbaddscheduletype.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(33, 88);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(93, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Schedule Color";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(33, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(92, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Schedule Type";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.groupBox2);
            this.tabPage2.Controls.Add(this.groupBox1);
            this.tabPage2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(322, 216);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "EDIT";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.bteditcancel);
            this.groupBox2.Controls.Add(this.btupdate);
            this.groupBox2.Controls.Add(this.editcolorButton);
            this.groupBox2.Controls.Add(this.tbeditcolorname);
            this.groupBox2.Controls.Add(this.tbedittype);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Location = new System.Drawing.Point(0, 64);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(319, 149);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Modify";
            // 
            // bteditcancel
            // 
            this.bteditcancel.Enabled = false;
            this.bteditcancel.Location = new System.Drawing.Point(174, 108);
            this.bteditcancel.Name = "bteditcancel";
            this.bteditcancel.Size = new System.Drawing.Size(75, 20);
            this.bteditcancel.TabIndex = 16;
            this.bteditcancel.Text = "&Cancel";
            this.bteditcancel.UseVisualStyleBackColor = true;
            this.bteditcancel.Click += new System.EventHandler(this.bteditcancel_Click);
            // 
            // btupdate
            // 
            this.btupdate.Enabled = false;
            this.btupdate.Location = new System.Drawing.Point(60, 108);
            this.btupdate.Name = "btupdate";
            this.btupdate.Size = new System.Drawing.Size(75, 20);
            this.btupdate.TabIndex = 17;
            this.btupdate.Text = "&Update";
            this.btupdate.UseVisualStyleBackColor = true;
            this.btupdate.Click += new System.EventHandler(this.btupdate_Click);
            // 
            // tbeditcolorname
            // 
            this.tbeditcolorname.Enabled = false;
            this.tbeditcolorname.Location = new System.Drawing.Point(131, 67);
            this.tbeditcolorname.Name = "tbeditcolorname";
            this.tbeditcolorname.Size = new System.Drawing.Size(82, 20);
            this.tbeditcolorname.TabIndex = 14;
            // 
            // tbedittype
            // 
            this.tbedittype.Enabled = false;
            this.tbedittype.Location = new System.Drawing.Point(131, 23);
            this.tbedittype.Name = "tbedittype";
            this.tbedittype.Size = new System.Drawing.Size(144, 20);
            this.tbedittype.TabIndex = 13;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(19, 71);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(93, 13);
            this.label3.TabIndex = 11;
            this.label3.Text = "Schedule Color";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(19, 26);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(92, 13);
            this.label4.TabIndex = 12;
            this.label4.Text = "Schedule Type";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cmboxedittype);
            this.groupBox1.Controls.Add(this.btmodify);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Location = new System.Drawing.Point(0, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(319, 52);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Select Type";
            // 
            // cmboxedittype
            // 
            this.cmboxedittype.FormattingEnabled = true;
            this.cmboxedittype.Location = new System.Drawing.Point(108, 19);
            this.cmboxedittype.Name = "cmboxedittype";
            this.cmboxedittype.Size = new System.Drawing.Size(131, 21);
            this.cmboxedittype.TabIndex = 0;
            this.cmboxedittype.SelectedIndexChanged += new System.EventHandler(this.cmboxedittype_SelectedIndexChanged);
            // 
            // btmodify
            // 
            this.btmodify.Location = new System.Drawing.Point(245, 19);
            this.btmodify.Name = "btmodify";
            this.btmodify.Size = new System.Drawing.Size(65, 21);
            this.btmodify.TabIndex = 17;
            this.btmodify.Text = "&Modify";
            this.btmodify.UseVisualStyleBackColor = true;
            this.btmodify.Click += new System.EventHandler(this.btmodify_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(10, 22);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(92, 13);
            this.label5.TabIndex = 12;
            this.label5.Text = "Schedule Type";
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.groupBox4);
            this.tabPage3.Controls.Add(this.groupBox3);
            this.tabPage3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(322, 216);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "DELETE";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.deletecolorButton);
            this.groupBox4.Controls.Add(this.tbdeletecolor);
            this.groupBox4.Controls.Add(this.tbdeletetype);
            this.groupBox4.Controls.Add(this.label10);
            this.groupBox4.Controls.Add(this.label11);
            this.groupBox4.Location = new System.Drawing.Point(0, 81);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(319, 132);
            this.groupBox4.TabIndex = 0;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Delete";
            // 
            // tbdeletecolor
            // 
            this.tbdeletecolor.Enabled = false;
            this.tbdeletecolor.Location = new System.Drawing.Point(136, 74);
            this.tbdeletecolor.Name = "tbdeletecolor";
            this.tbdeletecolor.Size = new System.Drawing.Size(82, 20);
            this.tbdeletecolor.TabIndex = 6;
            // 
            // tbdeletetype
            // 
            this.tbdeletetype.Enabled = false;
            this.tbdeletetype.Location = new System.Drawing.Point(136, 30);
            this.tbdeletetype.Name = "tbdeletetype";
            this.tbdeletetype.Size = new System.Drawing.Size(144, 20);
            this.tbdeletetype.TabIndex = 5;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(24, 78);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(93, 13);
            this.label10.TabIndex = 3;
            this.label10.Text = "Schedule Color";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(24, 33);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(92, 13);
            this.label11.TabIndex = 4;
            this.label11.Text = "Schedule Type";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.cmboxdelete);
            this.groupBox3.Controls.Add(this.btdelete);
            this.groupBox3.Controls.Add(this.label12);
            this.groupBox3.Location = new System.Drawing.Point(0, 6);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(319, 69);
            this.groupBox3.TabIndex = 0;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Select Type";
            // 
            // cmboxdelete
            // 
            this.cmboxdelete.FormattingEnabled = true;
            this.cmboxdelete.Location = new System.Drawing.Point(100, 24);
            this.cmboxdelete.Name = "cmboxdelete";
            this.cmboxdelete.Size = new System.Drawing.Size(131, 21);
            this.cmboxdelete.TabIndex = 18;
            this.cmboxdelete.SelectedIndexChanged += new System.EventHandler(this.cmboxdelete_SelectedIndexChanged);
            // 
            // btdelete
            // 
            this.btdelete.Location = new System.Drawing.Point(237, 24);
            this.btdelete.Name = "btdelete";
            this.btdelete.Size = new System.Drawing.Size(65, 21);
            this.btdelete.TabIndex = 20;
            this.btdelete.Text = "&Delete";
            this.btdelete.UseVisualStyleBackColor = true;
            this.btdelete.Click += new System.EventHandler(this.btdelete_Click);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(2, 27);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(92, 13);
            this.label12.TabIndex = 19;
            this.label12.Text = "Schedule Type";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(163, 119);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 20);
            this.button2.TabIndex = 16;
            this.button2.Text = "&Cancel";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(49, 119);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 20);
            this.button3.TabIndex = 17;
            this.button3.Text = "&Update";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // textBox1
            // 
            this.textBox1.Enabled = false;
            this.textBox1.Location = new System.Drawing.Point(131, 67);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(82, 20);
            this.textBox1.TabIndex = 14;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(131, 23);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(144, 20);
            this.textBox2.TabIndex = 13;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(19, 71);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(79, 13);
            this.label6.TabIndex = 11;
            this.label6.Text = "Schedule Color";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(19, 26);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(79, 13);
            this.label7.TabIndex = 12;
            this.label7.Text = "Schedule Type";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(108, 19);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(131, 21);
            this.comboBox1.TabIndex = 0;
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(245, 19);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(65, 21);
            this.button4.TabIndex = 17;
            this.button4.Text = "&Modify";
            this.button4.UseVisualStyleBackColor = true;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(10, 22);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(79, 13);
            this.label8.TabIndex = 12;
            this.label8.Text = "Schedule Type";
            // 
            // comboBox2
            // 
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Location = new System.Drawing.Point(108, 19);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(131, 21);
            this.comboBox2.TabIndex = 0;
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(245, 19);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(65, 21);
            this.button5.TabIndex = 17;
            this.button5.Text = "&Modify";
            this.button5.UseVisualStyleBackColor = true;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(10, 22);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(79, 13);
            this.label9.TabIndex = 12;
            this.label9.Text = "Schedule Type";
            // 
            // addcolorButton
            // 
            this.addcolorButton.Automatic = "";
            this.addcolorButton.Color = System.Drawing.Color.Transparent;
            this.addcolorButton.Location = new System.Drawing.Point(233, 83);
            this.addcolorButton.MoreColors = "More Colors...";
            this.addcolorButton.Name = "addcolorButton";
            this.addcolorButton.Size = new System.Drawing.Size(56, 23);
            this.addcolorButton.TabIndex = 2;
            this.addcolorButton.UseVisualStyleBackColor = true;
            this.addcolorButton.Changed += new System.EventHandler(this.addcolorButton_Changed);
            // 
            // editcolorButton
            // 
            this.editcolorButton.Automatic = "";
            this.editcolorButton.Color = System.Drawing.Color.Transparent;
            this.editcolorButton.Enabled = false;
            this.editcolorButton.Location = new System.Drawing.Point(219, 66);
            this.editcolorButton.MoreColors = "More Colors...";
            this.editcolorButton.Name = "editcolorButton";
            this.editcolorButton.Size = new System.Drawing.Size(56, 23);
            this.editcolorButton.TabIndex = 15;
            this.editcolorButton.UseVisualStyleBackColor = true;
            this.editcolorButton.Changed += new System.EventHandler(this.editcolorButton_Changed);
            // 
            // deletecolorButton
            // 
            this.deletecolorButton.Automatic = "";
            this.deletecolorButton.Color = System.Drawing.Color.Transparent;
            this.deletecolorButton.Enabled = false;
            this.deletecolorButton.Location = new System.Drawing.Point(224, 73);
            this.deletecolorButton.MoreColors = "More Colors...";
            this.deletecolorButton.Name = "deletecolorButton";
            this.deletecolorButton.Size = new System.Drawing.Size(56, 23);
            this.deletecolorButton.TabIndex = 7;
            this.deletecolorButton.UseVisualStyleBackColor = true;
            // 
            // colorButton1
            // 
            this.colorButton1.Automatic = "";
            this.colorButton1.Color = System.Drawing.Color.Transparent;
            this.colorButton1.Location = new System.Drawing.Point(219, 66);
            this.colorButton1.MoreColors = "More Colors...";
            this.colorButton1.Name = "colorButton1";
            this.colorButton1.Size = new System.Drawing.Size(56, 23);
            this.colorButton1.TabIndex = 15;
            this.colorButton1.UseVisualStyleBackColor = true;
            // 
            // frmScheduleTypeEntry
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(330, 242);
            this.Controls.Add(this.tabControl1);
            this.MaximizeBox = false;
            this.Name = "frmScheduleTypeEntry";
            this.Text = "Schedule Type Entry";
            this.Load += new System.EventHandler(this.frmScheduleTypeEntry_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TextBox tbaddscheduletype;
        private System.Windows.Forms.Button btacancel;
        private System.Windows.Forms.Button btaadd;
        private ColorButton.ColorButton addcolorButton;
        private System.Windows.Forms.TextBox tbaddcolorname;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button bteditcancel;
        private System.Windows.Forms.Button btupdate;
        private ColorButton.ColorButton editcolorButton;
        private System.Windows.Forms.TextBox tbeditcolorname;
        private System.Windows.Forms.TextBox tbedittype;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cmboxedittype;
        private System.Windows.Forms.Button btmodify;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private ColorButton.ColorButton colorButton1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Label label9;
        private ColorButton.ColorButton deletecolorButton;
        private System.Windows.Forms.TextBox tbdeletecolor;
        private System.Windows.Forms.TextBox tbdeletetype;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ComboBox cmboxdelete;
        private System.Windows.Forms.Button btdelete;
        private System.Windows.Forms.Label label12;
    }
}