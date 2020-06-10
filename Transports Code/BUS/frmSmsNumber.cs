using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace BUS
{
    public partial class frmSmsNumber : Form
    {
     
        public frmSmsNumber()
        {
            InitializeComponent();
           
        }

        private void label1_Click(object sender, EventArgs e)
        {
           
        }

        private void btUpdate_Click(object sender, EventArgs e)
        {
            string _mobileNumber = txtNumber.Text;
            string filepath = Path.GetDirectoryName(Application.ExecutablePath).ToString() + General.smsContact;
            File.WriteAllText(filepath, _mobileNumber);
            MessageBox.Show("Mobile Number Updated Successfully");
           
        }

        private void frmSmsNumber_Load(object sender, EventArgs e)
        {
            string smsNumberPath = Path.GetDirectoryName(Application.ExecutablePath).ToString() + General.smsContact;
            string[] num = File.ReadAllLines(smsNumberPath);
            string _contactNumber = string.Empty;
            if (num.Length > 0)
                _contactNumber = num[0];

            txtNumber.Text = _contactNumber;
        }      
    }
}
