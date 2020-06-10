using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Data.SqlClient;

namespace BUS
{
    public partial class frmBackup : Form
    {
        public frmBackup()
        {
            InitializeComponent();
        }

        private void Backup_Load(object sender, EventArgs e)
        {
            string filepath = Path.GetDirectoryName(Application.ExecutablePath).ToString() + General.BackupPath;
            string[] str = File.ReadAllLines(filepath);
            tbpath.Text = str[0];
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                lbstatus.Text = "Status : Start Backup";
                string connstring = System.Configuration.ConfigurationManager.ConnectionStrings["BUS"].ConnectionString.ToString();
                SqlConnection conn = new SqlConnection(connstring);
                conn.Open();
                string qry = "BACKUP DATABASE [Transport] TO  DISK = N'" + tbpath.Text + "' WITH NOFORMAT, INIT,  NAME = N'Transport-Full Database Backup', SKIP, NOREWIND, NOUNLOAD,  STATS = 10";
                SqlCommand cmd = new SqlCommand(qry, conn);
                cmd.ExecuteNonQuery();
                conn.Close();
                lbstatus.Text = "Status : Backup Completed.";
                MessageBox.Show("Backup Completed.");
            }
            catch (Exception)
            {
                 lbstatus.Text = "Status : Backup Failed. Cantact admin";
               
            }
        }
    }
}
