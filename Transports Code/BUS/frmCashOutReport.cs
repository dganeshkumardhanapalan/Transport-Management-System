using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Configuration;
using System.Data.SqlClient;
using System.Windows.Forms;
using CrystalDecisions.CrystalReports.Engine;
using System.IO;

namespace BUS
{
    public partial class frmCashOutReport : Form
    {
        public frmCashOutReport()
        {
            InitializeComponent();
        }
        string connstring = System.Configuration.ConfigurationManager.ConnectionStrings["BUS"].ConnectionString.ToString();
        private void frmCashOutReport_Load(object sender, EventArgs e)
        {
            loadSupplier();
        }
        public void loadSupplier()
        {
            cbSupplier.Items.Clear();
            SqlConnection conn = new SqlConnection(connstring);
            conn.Open();
            string qry = "select '0' as Id,'--All Suppliers--' AS Name union select Id,Name FROM Supplier";
            SqlDataAdapter da = new SqlDataAdapter(qry, conn);
            DataSet ds = new DataSet();
            da.Fill(ds);
            conn.Close();
            int rowcount = ds.Tables[0].Rows.Count;
            if (rowcount == 0)
            {
                MessageBox.Show("No Supplier Record Found");
            }
            else
            {

                cbSupplier.DataSource = ds.Tables[0];
                cbSupplier.ValueMember = "Id";
                cbSupplier.DisplayMember = "Name";
                cbSupplier.SelectedIndex = 0;
            }
        }

        private void btnReport_Click(object sender, EventArgs e)
        {
            string connstring = System.Configuration.ConfigurationManager.ConnectionStrings["BUS"].ConnectionString.ToString();
            SqlConnection conn = new SqlConnection(connstring);
            conn.Open();
            string qry = "Get_SUpplierWiseReport '" + cbSupplier.SelectedValue + "','" + dtpfromdate.Value.ToString("yyyy-MM-dd") + "','" + dtptodate.Value.ToString("yyyy-MM-dd") + "' ";
          //  string qry = "select * FROM CollectionMaster WHERE Date between '" + dtpfromdate.Value.ToString("yyyy-MM-dd") + "' AND '" + dtptodate.Value.ToString("yyyy-MM-dd") + "' AND Driver='" + cbdrivername.SelectedItem.ToString() + "' order by Date";
            SqlDataAdapter da = new SqlDataAdapter(qry, conn);
            DataSet ds = new DataSet();
            da.Fill(ds);
            conn.Close();
            ReportDocument cryRptDoc = new ReportDocument();
            string reportpath = Path.GetDirectoryName(Application.ExecutablePath).ToString() + General.GetReportPath(General.SUPPLIERWISEREPORT);
            cryRptDoc.Load(reportpath);
            cryRptDoc.SetDataSource(ds.Tables[0].DefaultView);
            //cryRptDoc.SetParameterValue("FromDate", dtpfromdate.Text);
            //cryRptDoc.SetParameterValue("ToDate", dtptodate.Text);
            rptViewer.ReportSource = cryRptDoc;
            
        }
        }
    }

