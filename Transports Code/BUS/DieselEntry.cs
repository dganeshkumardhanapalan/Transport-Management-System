using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace BUS
{
    public partial class DieselEntry : Form
    {
        public DieselEntry()
        {
            InitializeComponent();
        }

        private void DieselEntry_Load(object sender, EventArgs e)
        {
            string filepath = Path.GetDirectoryName(Application.ExecutablePath).ToString() + General.DieselPrice;
            string[] str = File.ReadAllLines(filepath);
            tbdieselprice.Text= str[0];
            if (!General.Is_Edit)
                button1.Enabled = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string filepath = Path.GetDirectoryName(Application.ExecutablePath).ToString() + General.DieselPrice;
            string[] str = new string[1];
            str[0] = tbdieselprice.Text;
            File.WriteAllLines(filepath, str);
            MessageBox.Show("Successfully Saved/Updated.");
            string[] str1 = File.ReadAllLines(filepath);
            tbdieselprice.Text= str1[0];
            this.Close();
        }

        private void tbdieselprice_Leave(object sender, EventArgs e)
        {
            if (tbdieselprice.Text != "")
            {
                tbdieselprice.Text = Convert.ToDouble(tbdieselprice.Text).ToString("F");
            }
            else
            {
                tbdieselprice.Text = "0.00";
            }
        }

        private void tbdieselprice_TextChanged(object sender, EventArgs e)
        {

        }

        private void tbdieselprice_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
            {
                e.Handled = true;
            }
            if (e.KeyChar == '.'
                && (sender as TextBox).Text.IndexOf('.') > -1)
            {
                e.Handled = true;
            }
        }
    }
}
