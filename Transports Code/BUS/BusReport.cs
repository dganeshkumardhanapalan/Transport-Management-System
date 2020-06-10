using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Threading;
using System.IO;

namespace BUS
{
    public partial class BusReport : Form
    {
        public BusReport()
        {
            InitializeComponent();
        }

        private void BusReport_Load(object sender, EventArgs e)
        {
            dtpfromdate.Value = DateTime.Now;
            dtptodate.Value = DateTime.Now;

            cbbusname.Items.Clear();
            string connstring = System.Configuration.ConfigurationManager.ConnectionStrings["BUS"].ConnectionString.ToString();
            SqlConnection conn = new SqlConnection(connstring);
            conn.Open();
            string qry = "select * FROM BusMaster";
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
                    cbbusname.Items.Insert(count, Convert.ToString(ds.Tables[0].Rows[count]["Name"]).Trim());
                }
                cbbusname.SelectedIndex = 0;
            }
            DriverReport dr = new DriverReport();
        }

        private void btcreate_Click(object sender, EventArgs e)
        {
            string connstring = System.Configuration.ConfigurationManager.ConnectionStrings["BUS"].ConnectionString.ToString();
            SqlConnection conn = new SqlConnection(connstring);
            conn.Open();
            string qry = "select * FROM CollectionMaster WHERE Date between'" + dtpfromdate.Value.ToString("yyyy-MM-dd") + "' AND '" + dtptodate.Value.ToString("yyyy-MM-dd") + "' AND BusName='" + cbbusname.SelectedItem.ToString() + "'";
            SqlDataAdapter da = new SqlDataAdapter(qry, conn);
            DataSet ds = new DataSet();
            da.Fill(ds);
            conn.Close();



            //BusCrystalReport objRpt = new BusCrystalReport();
            //objRpt.Parameter_FromDate.PromptText=dtptodate.Text;
            //objRpt.Parameter_ToDate.PromptText = dtptodate.Text;
            //objRpt.SetDataSource(ds.Tables[0]);
            //crvbus.ReportSource = objRpt;
            //crvbus.Refresh();

            ReportDocument cryRptDoc = new ReportDocument();
            string reportpath = Path.GetDirectoryName(Application.ExecutablePath).ToString() + General.GetReportPath(General.BUS);
            cryRptDoc.Load(reportpath);
            cryRptDoc.SetDataSource(ds.Tables[0].DefaultView);
            cryRptDoc.SetParameterValue("FromDate", dtpfromdate.Text);
            cryRptDoc.SetParameterValue("ToDate", dtptodate.Text);
            crvbus.ReportSource = cryRptDoc;
            

           // crvbus.PrintReport();

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
