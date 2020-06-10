using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Management;
using System.Security.Cryptography;
using System.Configuration;

namespace BUS
{
    public partial class frmLICForm : Form
    {
        public frmLICForm()
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
                    //Get only the first CPU's ID
                    cpuInfo = mo.Properties["processorID"].Value.ToString();
                    break;
                }
            }
            return cpuInfo;
        }

        private void frmLICForm_Load(object sender, EventArgs e)
        {
            string sysid = getSystemId();
            tbProductId.Text = sysid;
        }
    }
}
