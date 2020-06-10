using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using CrystalDecisions.CrystalReports.Engine;
using System.IO;

namespace BUS
{
    public partial class frmExpenseTypeReport : Form
    {
        string connstring = System.Configuration.ConfigurationManager.ConnectionStrings["BUS"].ConnectionString.ToString();
        public frmExpenseTypeReport()
        {
            InitializeComponent();
        }

        private void frmExpenseTypeReport_Load(object sender, EventArgs e)
        {
            load_Bus();
            load_ExpenseType();
            load_Companyname();
        }
        private void load_ExpenseType()
        {
            SqlConnection conn = new SqlConnection(connstring);
            conn.Open();
            string qry = "Select '0' As Id, '--All Expense--' As ExpenseType Union Select Id,ExpenseType from ExpenseTypeMaster  Order By Id";
            SqlCommand cmd = new SqlCommand(qry, conn);
            DataSet ds = new DataSet();
            SqlDataAdapter sdr = new SqlDataAdapter(cmd);
            sdr.Fill(ds);
            conn.Close();
            int rowcount = ds.Tables[0].Rows.Count;
            if (rowcount > 0)
            {
                cbExpenseType.DataSource = ds.Tables[0];
                cbExpenseType.ValueMember = "Id";
                cbExpenseType.DisplayMember = "ExpenseType";
            }
            else
            {
                cbExpenseType.DataSource = null;
                cbExpenseType.Items.Clear();
            }
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

        private void btnLoad_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(connstring);
            conn.Open();
            string qry = "procGetExpenseTypeReport '"+cbCompany.SelectedValue +"','" + cbBus.SelectedValue + "','" + cbExpenseType.SelectedValue + "','" + dtpFromDate.Value.ToString("yyyy-MM-dd") + "','" + dtpToDate.Value.ToString("yyyy-MM-dd") + "' ";
            //  string qry = "select * FROM CollectionMaster WHERE Date between '" + dtpfromdate.Value.ToString("yyyy-MM-dd") + "' AND '" + dtptodate.Value.ToString("yyyy-MM-dd") + "' AND Driver='" + cbdrivername.SelectedItem.ToString() + "' order by Date";
            SqlDataAdapter da = new SqlDataAdapter(qry, conn);
            DataSet ds = new DataSet();
            da.Fill(ds);
            conn.Close();
            ReportDocument cryRptDoc = new ReportDocument();
            string reportpath = Path.GetDirectoryName(Application.ExecutablePath).ToString() + General.GetReportPath(General.EXPENSETYPEREPORT);
            cryRptDoc.Load(reportpath);
            cryRptDoc.SetDataSource(ds.Tables[0].DefaultView);
            cryRptDoc.SetParameterValue("Company", cbCompany.Text);
            cryRptDoc.SetParameterValue("BusName", cbBus.Text);
            cryRptDoc.SetParameterValue("ExpenseName", cbExpenseType.Text);
            rptViewer.ReportSource = cryRptDoc;
        }
        private void load_Companyname()
        {

            SqlConnection conn = new SqlConnection(connstring);
            conn.Open();
            string qry = "Select '0' As Id, '--All Company--' As CompanyName Union select Id,CompanyName FROM CompanyName";
            SqlDataAdapter da = new SqlDataAdapter(qry, conn);
            DataSet ds = new DataSet();
            da.Fill(ds);
            conn.Close();
            int rowcount = ds.Tables[0].Rows.Count;
            if (rowcount > 0)
            {
                cbCompany.DataSource = ds.Tables[0];
                cbCompany.ValueMember = "Id";
                cbCompany.DisplayMember = "CompanyName";
            }
            else
            {
                cbCompany.DataSource = null;
                cbCompany.Items.Clear();
            }
        }

        private void cbCompany_SelectionChangeCommitted(object sender, EventArgs e)
        {
            string connstring = System.Configuration.ConfigurationManager.ConnectionStrings["BUS"].ConnectionString.ToString();
            SqlConnection conn = new SqlConnection(connstring);
            conn.Open();
            string qry = "select Id,Name From BusMaster Where CompanyId='" + cbCompany.SelectedValue + "'";
            SqlDataAdapter da = new SqlDataAdapter(qry, conn);
            DataSet ds = new DataSet();
            da.Fill(ds);
            conn.Close();
            int rowcount = ds.Tables[0].Rows.Count;
            if (rowcount == 0)
            {
                MessageBox.Show("No Bus Record Found");
            }
            else
            {
                cbBus.DataSource = ds.Tables[0];
                cbBus.ValueMember = "Id";
                cbBus.DisplayMember = "Name";
            }
        }
    }
}
