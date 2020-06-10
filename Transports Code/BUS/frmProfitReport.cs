using CrystalDecisions.CrystalReports.Engine;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace BUS
{
    public partial class frmProfitReport : Form
    {
        string connstring = System.Configuration.ConfigurationManager.ConnectionStrings["BUS"].ConnectionString.ToString();
        public frmProfitReport()
        {
            InitializeComponent();
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {

            string connstring = System.Configuration.ConfigurationManager.ConnectionStrings["BUS"].ConnectionString.ToString();
            SqlConnection conn = new SqlConnection(connstring);
            conn.Open();
            string qry = "procGetProfitReport '" + cbBus.SelectedValue + "','" + dtpFromDate.Value.ToString("yyyy-MM-dd") + "','" + dtpToDate.Value.ToString("yyyy-MM-dd") + "' ";
            SqlDataAdapter da = new SqlDataAdapter(qry, conn);
            DataSet ds = new DataSet();
            da.Fill(ds);
            conn.Close();
            ReportDocument cryRptDoc = new ReportDocument();
            string reportpath = Path.GetDirectoryName(Application.ExecutablePath).ToString() + General.GetReportPath(General.PROFIT);
            cryRptDoc.Load(reportpath);
            cryRptDoc.SetDataSource(ds.Tables[0].DefaultView);
            cryRptDoc.SetParameterValue("BusName", cbBus.Text);
            rptViewer.ReportSource = cryRptDoc;
            
        }
        private void load_Bus()
        {
            SqlConnection conn = new SqlConnection(connstring);
            conn.Open();
            string qry = "Select '0' As Id, '--All Bus--' As Name Union Select Id,Name from BusMaster Order By Id";
            SqlCommand cmd = new SqlCommand(qry, conn);
            DataSet ds = new DataSet();
            SqlDataAdapter sdr = new SqlDataAdapter(cmd);
            sdr.Fill(ds);
            conn.Close();
            int rowcount = ds.Tables[0].Rows.Count;
            if (rowcount > 0)
            {
                cbBus.DataSource = ds.Tables[0];
                cbBus.ValueMember = "Id";
                cbBus.DisplayMember = "Name";
            }
            else
            {
                cbBus.DataSource = null;
                cbBus.Items.Clear();
            }
        }

        private void frmProfitReport_Load(object sender, EventArgs e)
        {
            load_Bus();
        }
    }
}
