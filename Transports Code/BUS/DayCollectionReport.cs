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
    public partial class DayCollectionReport : Form
    {
        public DayCollectionReport()
        {
            InitializeComponent();
        }

        private void DayCollectionReport_Load(object sender, EventArgs e)
        {

        }

        private void btcreate_Click(object sender, EventArgs e)
        {
            string connstring = System.Configuration.ConfigurationManager.ConnectionStrings["BUS"].ConnectionString.ToString();
            SqlConnection conn = new SqlConnection(connstring);
            conn.Open();
            string qry = "";
            //string date = DateTime.Today.ToString("dd/MM/yyyy");
            qry = "select * FROM CollectionMaster WHERE Date='" + dtpdate.Value.ToString("yyyy-MM-dd") + "' order by Date";
            SqlDataAdapter da = new SqlDataAdapter(qry, conn);
            DataSet ds = new DataSet();
            da.Fill(ds);
            conn.Close();
            DataTable dt = new DataTable();
            dt.Columns.Add("Date");
            dt.Columns.Add("Driver1");
            dt.Columns.Add("Conductor1");
            dt.Columns.Add("BusName");
            dt.Columns.Add("Collection");
            dt.Columns.Add("DLit");
            dt.Columns.Add("DAmount");
            dt.Columns.Add("Bata");
            dt.Columns.Add("Wages");
            dt.Columns.Add("Cleaner");
            dt.Columns.Add("Stand");
            dt.Columns.Add("Gtc");
            dt.Columns.Add("Pooja");
            dt.Columns.Add("Extra");
            dt.Columns.Add("Greese");
            dt.Columns.Add("Sparse");
            dt.Columns.Add("Expenses");
            dt.Columns.Add("Total");
            dt.Columns.Add("NetTotal");

            int length = ds.Tables[0].Rows.Count;
            string FromDate = "";
            string ToDate = "";
            string BusName = "";
            for (int i = 0; i < length; i++)
            {
                DataRow dr = dt.NewRow();
                //dr["ID"] = ds.Tables[0].Rows[i]["ID"].ToString();
                //dr["BusName"] = ds.Tables[0].Rows[i]["BusName"].ToString();
                //dr["Total"] = ds.Tables[0].Rows[i]["Total"].ToString();

                dr["Date"] = ds.Tables[0].Rows[i]["Date"].ToString().Substring(0,11);
                dr["Driver1"] = ds.Tables[0].Rows[i]["Driver1"].ToString();
                dr["Conductor1"] = ds.Tables[0].Rows[i]["Conductor1"].ToString();
                dr["BusName"] = ds.Tables[0].Rows[i]["BusName"].ToString();
                dr["Collection"] = ds.Tables[0].Rows[i]["Collection"].ToString();
                dr["DLit"] = ds.Tables[0].Rows[i]["DLit"].ToString();
                dr["DAmount"] = ds.Tables[0].Rows[i]["DAmount"].ToString();
                dr["Bata"] = ds.Tables[0].Rows[i]["Bata"].ToString();
                dr["Wages"] = ds.Tables[0].Rows[i]["Wages"].ToString();
                dr["Cleaner"] = ds.Tables[0].Rows[i]["Cleaner"].ToString();
                dr["Stand"] = ds.Tables[0].Rows[i]["Stand"].ToString();
                dr["Gtc"] = ds.Tables[0].Rows[i]["Gtc"].ToString();
                dr["Pooja"] = ds.Tables[0].Rows[i]["Pooja"].ToString();
                dr["Extra"] = ds.Tables[0].Rows[i]["Extra"].ToString();
                dr["Greese"] = ds.Tables[0].Rows[i]["Greese"].ToString();
                dr["Sparse"] = ds.Tables[0].Rows[i]["Sparse"].ToString();
                dr["Expenses"] = ds.Tables[0].Rows[i]["Expenses"].ToString();
                dr["Total"] = ds.Tables[0].Rows[i]["Total"].ToString();
                //dr["ID"] = ds.Tables[0].Rows[i]["ID"].ToString();

                BusName = ds.Tables[0].Rows[i]["BusName"].ToString();
                //FromDate = DateTime.Now.ToString("yyyy")+"-"+ DateTime.Now.ToString("MM") +"-"+"01";
                FromDate = dtpdate.Value.ToString("yyyy") + "-" + dtpdate.Value.ToString("MM") + "-" + "01";
                //ToDate = DateTime.Today.AddDays(-1).ToString("dd/MM/yyyy");
                DateTime todate = dtpdate.Value;
                //ToDate = todate.AddDays(-1).ToString("yyyy-MM-dd");
                ToDate = todate.ToString("yyyy-MM-dd");
                string NetTotal = General.GetNetTotal(BusName, FromDate, ToDate).ToString();
                dr["NetTotal"] = NetTotal;
                dt.Rows.Add(dr);
            }

            


            ReportDocument cryRptDoc = new ReportDocument();
            string reportpath = Path.GetDirectoryName(Application.ExecutablePath).ToString() + General.GetReportPath(General.DAYCOLLECTION);
            cryRptDoc.Load(reportpath);
            cryRptDoc.SetDataSource(dt.DefaultView);
            crvcollection.ReportSource = cryRptDoc;
           //cryRptDoc.SetParameterValue("BusName", cbbusname.SelectedItem.ToString());
        }

       
    }
}
