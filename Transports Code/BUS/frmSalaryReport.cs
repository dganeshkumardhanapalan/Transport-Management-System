using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Data.SqlClient;
using System.Configuration;
using System.Windows.Forms;
using CrystalDecisions.CrystalReports.Engine;
using System.IO;

namespace BUS
{
    public partial class frmSalaryReport : Form
    {
        public frmSalaryReport()
        {
            InitializeComponent();
        }

        private void frmSalaryReport_Load(object sender, EventArgs e)
        {
            loadEmp();
        }
        private void loadEmp()
        {
            cbEmployee.Items.Clear();
            string connstring = System.Configuration.ConfigurationManager.ConnectionStrings["BUS"].ConnectionString.ToString();
            SqlConnection conn = new SqlConnection(connstring);
            conn.Open();
            string qry = "select '0' as Id,'--All Employee--' AS Name union select Id, Name from EmployeeMaster order by id";
            SqlDataAdapter da = new SqlDataAdapter(qry, conn);
            DataSet ds = new DataSet();
            da.Fill(ds);
            conn.Close();
            int rowcount = ds.Tables[0].Rows.Count;
            if (rowcount == 0)
            {
                MessageBox.Show("No Department Record Found");
            }
            else
            {
                cbEmployee.DataSource = ds.Tables[0];
                cbEmployee.ValueMember = "Id";
                cbEmployee.DisplayMember = "Name";
                cbEmployee.SelectedIndex = 0;
            }
        }

        private void btnCreateRpt_Click(object sender, EventArgs e)
        {
            string connstring = System.Configuration.ConfigurationManager.ConnectionStrings["BUS"].ConnectionString.ToString();
            SqlConnection conn = new SqlConnection(connstring);
            conn.Open();
            string qry = "procSalary '" + cbEmployee.SelectedValue + "','" + dtpfromdate.Value.ToString("yyyy-MM-dd") + "','" + dtptodate.Value.ToString("yyyy-MM-dd") + "' ";
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
            string reportpath = Path.GetDirectoryName(Application.ExecutablePath).ToString() + General.GetReportPath(General.SALARY);
            cryRptDoc.Load(reportpath);
            cryRptDoc.SetDataSource(ds.Tables[0].DefaultView);
            cryRptDoc.SetParameterValue("emp", cbEmployee.Text);
            //cryRptDoc.SetParameterValue("ToDate", dtptodate.Text);
            rptviewer.ReportSource = cryRptDoc;
            
        }

  
        }

    }
