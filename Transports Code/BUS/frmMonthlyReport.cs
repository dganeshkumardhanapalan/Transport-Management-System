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
    public partial class frmMonthlyReport : Form
    {
        public frmMonthlyReport()
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
            qry = "up_GetMonthlyReport @StartDate='" + dtpfromdate.Value.ToString("yyyy-MM-dd") + "',@endDate='" + dtptodate.Value.ToString("yyyy-MM-dd") + "'";
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = qry;
            cmd.ExecuteNonQuery();

            qry = "SELECT * FROM MonthlyReport";
            SqlDataAdapter da = new SqlDataAdapter(qry, conn);
            DataSet ds = new DataSet();
            da.Fill(ds);
            conn.Close();

            ReportDocument cryRptDoc = new ReportDocument();
            string reportpath = Path.GetDirectoryName(Application.ExecutablePath).ToString() + General.GetReportPath(General.MONTHLYREPORT);
            cryRptDoc.Load(reportpath);
            cryRptDoc.SetDataSource(ds.Tables[0].DefaultView);
            cryRptDoc.SetParameterValue("FromDate", dtpfromdate.Text);
            cryRptDoc.SetParameterValue("ToDate", dtptodate.Text);
            crvcollection.ReportSource = cryRptDoc;

            
            //cryRptDoc.SetParameterValue("BusName", cbbusname.SelectedItem.ToString());

        }

        private void frmMonthlyReport_Load(object sender, EventArgs e)
        {

        }
    }
}
