using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Threading;
using System.Management;
using System.Security.Cryptography;
using System.Configuration;

namespace BUS
{
    public partial class Login : Form
    {
        
        public Login()
        {
            InitializeComponent();
        }

        private string getSystemId()
        {
            string cpuInfo = string.Empty;
            ManagementClass mc = new ManagementClass("win32_processor");
            ManagementObjectCollection moc = mc.GetInstances();

            foreach (ManagementObject mo in moc)
            {
                if (cpuInfo == "")
                {
                    cpuInfo = mo.Properties["processorID"].Value.ToString();
                    break;
                }
            }
            return cpuInfo;
        }
        private void btlogin_Click(object sender, EventArgs e)
        {
            try
            {
                string[] lines = null;
                try
                {
                    string licpath = Path.GetDirectoryName(Application.ExecutablePath) + "\\app.lic";
                    lines = File.ReadAllLines(licpath);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("LIC File Missing. Contact Admin.");
                }
                string sysid = getSystemId();
                string encry = CryptorEngine.Encrypt(sysid, true);
                string ssysdate = CryptorEngine.Encrypt(DateTime.Now.ToString("dd/MM/yyyy"), true);
                DateTime sysdate = DateTime.Now;
                DateTime fromdate = Convert.ToDateTime(CryptorEngine.Decrypt(lines[22], true));
                DateTime todate = Convert.ToDateTime(CryptorEngine.Decrypt(lines[45], true));
                
                bool isExpried = false;
                if (sysdate >= fromdate && sysdate <= todate)
                    isExpried = false;
                else
                    isExpried = true;
           



            if (encry.Equals(lines[15]) && !isExpried)
            //    if ( !isExpried)
            //if ( !isExpried)
            {
                string connstring = System.Configuration.ConfigurationManager.ConnectionStrings["BUS"].ConnectionString.ToString();
                SqlConnection conn = new SqlConnection(connstring);
                conn.Open();
                string qry = "select * FROM LoginMaster Where UserName='" + tbusername.Text + "'";
                SqlDataAdapter da = new SqlDataAdapter(qry, conn);
                DataSet ds = new DataSet();
                da.Fill(ds);
                conn.Close();
                int rowcount = ds.Tables[0].Rows.Count;
                if (rowcount == 1)
                {
                    string comparepass = Convert.ToString(ds.Tables[0].Rows[0]["Password"]).Trim();
                    string UserRole = Convert.ToString(ds.Tables[0].Rows[0]["UserRole"]).Trim();
                    if (comparepass == tbpassword.Text)
                    {
                        if (UserRole == "client")
                        {
                            General.Is_Edit = Convert.ToBoolean(System.Configuration.ConfigurationManager.AppSettings["IS_EDIT"]);
                            General.Is_Delete = Convert.ToBoolean(System.Configuration.ConfigurationManager.AppSettings["IS_DELETE"]);
                        }
                        this.Hide();
                        MainForm mf = new MainForm();
                        mf.Show();

                    }
                    else
                    {
                        MessageBox.Show("Invalid Password");
                    }

                }
                else
                {
                    MessageBox.Show("Invalid UserName");
                }
            }
            else
            {
                frmLICForm frm = new frmLICForm();
                frm.Show();
            }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
         }

        private void button2_Click(object sender, EventArgs e)
        {

            tbusername.Text = "";
            tbpassword.Text = "";

        }

        

        private void tbusername_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar.ToString() == "\r")
            {
                this.SelectNextControl(tbusername, true, true, true, true);
            }
        }

        private void tbpassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar.ToString() == "\r")
            {
                this.SelectNextControl(tbpassword, true, true, true, true);
            }
        }



        private void Login_Load(object sender, EventArgs e)
        {
          
            //string decrypt = CryptorEngine.Decrypt(encry, true);
            //MessageBox.Show(encry);
        }


    }
}
