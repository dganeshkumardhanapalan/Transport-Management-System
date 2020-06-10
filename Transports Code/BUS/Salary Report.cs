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
    public partial class Salary_Report : Form
    {
        public Salary_Report()
        {
            InitializeComponent();
        }
        private void btcreate_Click(object sender, EventArgs e)
        {
            string connstring = System.Configuration.ConfigurationManager.ConnectionStrings["BUS"].ConnectionString.ToString();
            SqlConnection conn = new SqlConnection(connstring);
            conn.Open();
            string qry = "";
            //qry = "select * FROM CollectionMaster WHERE Date between'" + dtpfromdate.Value.ToString("yyyy-MM-dd") + "' AND '" + dtptodate.Value.ToString("yyyy-MM-dd") + "' AND BusName='" + cbbusname.SelectedItem.ToString() + "' order by Date";
            /*qry = "select BusName,sum(convert(decimal(7,2),Collection)) Collection,sum(convert(decimal(7,2),DAmount)) DAmount,sum(convert(decimal(7,2),Expenses)) Expenses,";
            qry = qry + "(select sum(convert(decimal(7,2),mem.Amount))";
            qry = qry + "from MonthlyExpenseMaster mem,BusMaster bm ";
            qry = qry + "where bm.Id=mem.BusName and bm.Name=cm.BusName and mem.ExpenseType='1') Bank_Due,";
            qry = qry + "(select sum(convert(decimal(7,2),mem.Amount))";
            qry = qry + "from MonthlyExpenseMaster mem,BusMaster bm ";
            qry = qry + "where bm.Id=mem.BusName and bm.Name=cm.BusName and mem.ExpenseType='2') Toll_Fee,";
            qry = qry + "(select sum(convert(decimal(7,2),mem.Amount))";
            qry = qry + "from MonthlyExpenseMaster mem,BusMaster bm ";
            qry = qry + "where bm.Id=mem.BusName and bm.Name=cm.BusName and mem.ExpenseType='3') Workshop_Exp,";
            qry = qry + "(select sum(convert(decimal(7,2),mem.Amount))";
            qry = qry + "from MonthlyExpenseMaster mem,BusMaster bm ";
            qry = qry + "where bm.Id=mem.BusName and bm.Name=cm.BusName and mem.ExpenseType='4') Other_Exp ";
            qry = qry + "from CollectionMaster cm ";
            qry = qry + "where Date between '" + dtpfromdate.Value.ToString("yyyy-MM-dd") + "' and '" + dtptodate.Value.ToString("yyyy-MM-dd") + "'";
            qry = qry + "group by BusName"; */
            qry = "procSalary @StartDate='" + dtpfromdate.Value.ToString("yyyy-MM-dd") + "',@endDate='" + dtptodate.Value.ToString("yyyy-MM-dd") + "'";
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = qry;
            cmd.ExecuteNonQuery();

            qry = "SELECT * FROM Salary";
            SqlDataAdapter da = new SqlDataAdapter(qry, conn);
            DataSet ds = new DataSet();
            da.Fill(ds);
            conn.Close();

            ReportDocument cryRptDoc = new ReportDocument();
            string reportpath = Path.GetDirectoryName(Application.ExecutablePath).ToString() + General.GetReportPath(General.SALARYREPORT);
            cryRptDoc.Load(reportpath);
            cryRptDoc.SetDataSource(ds.Tables[0].DefaultView);
            cryRptDoc.SetParameterValue("FromDate", dtpfromdate.Text);
            cryRptDoc.SetParameterValue("ToDate", dtptodate.Text);
            crvcollection.ReportSource = cryRptDoc;


            //cryRptDoc.SetParameterValue("BusName", cbbusname.SelectedItem.ToString());

        }

        private void CbDepartment_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private void load_Department()
        {
            CbDepartment.Items.Clear();
            string connstring = System.Configuration.ConfigurationManager.ConnectionStrings["BUS"].ConnectionString.ToString();
            SqlConnection conn = new SqlConnection(connstring);
            conn.Open();
            string qry = "select DISTINCT Department from EmployeeMaster";
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
                for (int count = 0; count < rowcount; count++)
                {
                    CbDepartment.Items.Insert(count, Convert.ToString(ds.Tables[0].Rows[count]["Department"]).Trim());
                }
                CbDepartment.SelectedIndex = 0;
            }
        }
        private void loadEmp()
        {
            cbEmployee.Items.Clear();
            string connstring = System.Configuration.ConfigurationManager.ConnectionStrings["BUS"].ConnectionString.ToString();
            SqlConnection conn = new SqlConnection(connstring);
            conn.Open();
            string qry = "select '0' as Id,'--Select Employee--' AS Name union select Id, Name from EmployeeMaster order by id";
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
        private void Salary_Report_Load(object sender, EventArgs e)
        {
            load_Department();
            loadEmp();
        }
    }
}
