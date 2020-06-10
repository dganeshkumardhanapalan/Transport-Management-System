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
    public partial class Bata : Form
    {
        public Bata()
        {
            InitializeComponent();
        }

        private void Bata_Load(object sender, EventArgs e)
        {
           // string filepath = General.Batapath;
            string filepath = Path.GetDirectoryName(Application.ExecutablePath).ToString() + General.Batapath;
            string[] str = File.ReadAllLines(filepath);
            tbbata.Text = str[0];
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string filepath = Path.GetDirectoryName(Application.ExecutablePath).ToString() + General.Batapath;
            string[] str = new string[1];
            str[0] = tbbata.Text;
            File.WriteAllLines(filepath, str);
            MessageBox.Show("Successfully Saved/Updated.");
            string[] str1 = File.ReadAllLines(filepath);
            tbbata.Text = str1[0];
        }

        private void tbdieselprice_Leave(object sender, EventArgs e)
        {
            if (tbbata.Text != "")
            {
                tbbata.Text = Convert.ToDouble(tbbata.Text).ToString("F");
            }
            else
            {
                tbbata.Text = "0.00";
            }
        }
    }
}
