using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.CrystalReports.Design;
using CrystalDecisions.Shared;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Threading;
using System.IO;

namespace BUS
{
    public partial class DriverReport : Form
    {
        public DriverReport()
        {
            InitializeComponent();
        }

          private void DriverReport_Load(object sender, EventArgs e)
        {
            dtpfromdate.Value = DateTime.Now;
            dtptodate.Value = DateTime.Now;

            cbdrivername.Items.Clear();
            string connstring = System.Configuration.ConfigurationManager.ConnectionStrings["BUS"].ConnectionString.ToString();
            SqlConnection conn = new SqlConnection(connstring);
            conn.Open();
            string qry = "select * FROM EmployeeMaster where Department='Driver'";
            SqlDataAdapter da = new SqlDataAdapter(qry, conn);
            DataSet ds = new DataSet();
            da.Fill(ds);
            conn.Close();
            int rowcount = ds.Tables[0].Rows.Count;
            if (rowcount == 0)
            {
                MessageBox.Show("No Driver Record Found");
            }
            else
            {
                for (int count = 0; count < rowcount; count++)
                {
                    cbdrivername.Items.Insert(count, Convert.ToString(ds.Tables[0].Rows[count]["Name"]).Trim());
                }
                cbdrivername.SelectedIndex = 0;
            }
            DriverReport dr = new DriverReport();
            
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            string connstring = System.Configuration.ConfigurationManager.ConnectionStrings["BUS"].ConnectionString.ToString();
            SqlConnection conn = new SqlConnection(connstring);
            conn.Open();
            string qry = "procGetDriverReport '" + cbdrivername.SelectedItem.ToString() + "','" + dtpfromdate.Value.ToString("yyyy-MM-dd") + "','" + dtptodate.Value.ToString("yyyy-MM-dd") + "' ";
          //  string qry = "select * FROM CollectionMaster WHERE Date between '" + dtpfromdate.Value.ToString("yyyy-MM-dd") + "' AND '" + dtptodate.Value.ToString("yyyy-MM-dd") + "' AND Driver='" + cbdrivername.SelectedItem.ToString() + "' order by Date";
            SqlDataAdapter da = new SqlDataAdapter(qry, conn);
            DataSet ds = new DataSet();
            da.Fill(ds);
            conn.Close();



            //DriverCrystalReport objRpt = new DriverCrystalReport();
            //objRpt.SetDataSource(ds.Tables[0]);
            //crvdriver.ReportSource = objRpt;
            //crvdriver.Refresh();

            ReportDocument cryRptDoc = new ReportDocument();
            string reportpath = Path.GetDirectoryName(Application.ExecutablePath).ToString() + General.GetReportPath(General.DRIVER);
            cryRptDoc.Load(reportpath);
            cryRptDoc.SetDataSource(ds.Tables[0].DefaultView);
            //cryRptDoc.SetParameterValue("FromDate", dtpfromdate.Text);
            //cryRptDoc.SetParameterValue("ToDate", dtptodate.Text);
            crvdriver.ReportSource = cryRptDoc;
            
        }

  


    }
}
