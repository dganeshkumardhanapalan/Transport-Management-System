using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Threading;
using System.IO;
using CrystalDecisions.CrystalReports.Engine;



namespace BUS
{
    public partial class MaintanceReport : Form
    {
        public MaintanceReport()
        {
            InitializeComponent();
        }

        private void MaintanceReport_Load(object sender, EventArgs e)
        {
            dtpfromdate.Value = DateTime.Now;
            dtptodate.Value = DateTime.Now;
            cbmaintance.SelectedIndex = 0;

            cbbusname.Items.Clear();
            string connstring = System.Configuration.ConfigurationManager.ConnectionStrings["BUS"].ConnectionString.ToString();
            SqlConnection conn = new SqlConnection(connstring);
            conn.Open();
            string qry = "Select Id, Name from BusMaster Order By Id";
            SqlCommand cmd = new SqlCommand(qry, conn);
            DataSet ds = new DataSet();
            SqlDataAdapter sdr = new SqlDataAdapter(cmd);
            sdr.Fill(ds);
            conn.Close();
            int rowcount = ds.Tables[0].Rows.Count;
            if (rowcount > 0)
            {
                cbbusname.DataSource = ds.Tables[0];
                cbbusname.ValueMember = "Id";
                cbbusname.DisplayMember = "Name";
            }
            else
            {
                cbbusname.DataSource = null;
                cbbusname.Items.Clear();
            }
        }

        private void btcreate_Click(object sender, EventArgs e)
        {
            if (cbmaintance.SelectedIndex == 0)
            {
                MessageBox.Show("Select Maintanence");
            }
            else
            {
                String selectedItem = cbmaintance.SelectedItem.ToString();
                if (selectedItem == "Tyre Service")
                {
                    string connstring = System.Configuration.ConfigurationManager.ConnectionStrings["BUS"].ConnectionString.ToString();
                    SqlConnection conn = new SqlConnection(connstring);
                    conn.Open();
                    string qry = "TyreReport '" + cbbusname.Text + "','" + dtpfromdate.Value.ToString("yyyy-MM-dd") + "','" + dtptodate.Value.ToString("yyyy-MM-dd") + "' ";
                    SqlDataAdapter da = new SqlDataAdapter(qry, conn);
                    DataSet ds = new DataSet();
                    da.Fill(ds);
                    conn.Close();

                    ReportDocument cryRptDoc = new ReportDocument();
                    string reportpath = Path.GetDirectoryName(Application.ExecutablePath).ToString() + General.GetReportPath(General.TYREREPORT);
                    //string reportpath = @"E:\Live Projects\Bus Double Wages and Bata 11092015\BUS\BUS\Report\NewTyreReport.rpt";
                    cryRptDoc.Load(reportpath);
                    cryRptDoc.SetDataSource(ds.Tables[0].DefaultView);
                    cryRptDoc.SetParameterValue("FromDate", dtpfromdate.Text);
                    cryRptDoc.SetParameterValue("ToDate", dtptodate.Text);
                    cryRptDoc.SetParameterValue("BusName", cbbusname.Text);
                    crvbus.ReportSource = cryRptDoc;

                }
                else if (selectedItem == "Oil Service")
                {
                    try
                    {
                        string connstring = System.Configuration.ConfigurationManager.ConnectionStrings["BUS"].ConnectionString.ToString();
                        SqlConnection conn = new SqlConnection(connstring);
                        conn.Open();
                        string qry = "OilReport '" + cbbusname.SelectedItem.ToString() + "','" + dtpfromdate.Value.ToString("yyyy-MM-dd") + "','" + dtptodate.Value.ToString("yyyy-MM-dd") + "'";
                        SqlDataAdapter da = new SqlDataAdapter(qry, conn);
                        DataSet ds = new DataSet();
                        da.Fill(ds);
                        conn.Close();

                        ReportDocument cryRptDoc = new ReportDocument();
                        string reportpath = Path.GetDirectoryName(Application.ExecutablePath).ToString() + General.GetReportPath(General.OILSERVICE);
                        //string reportpath = @"E:\Karthick\Bus\Erode backup\BUS V2.0\BUS\BUS\Report\NewOilServiceReport.rpt";
                        cryRptDoc.Load(reportpath);
                        cryRptDoc.SetDataSource(ds.Tables[0].DefaultView);
                        //cryRptDoc.SetParameterValue("FromDate", dtpfromdate.Text);
                        //cryRptDoc.SetParameterValue("ToDate", dtptodate.Text);
                        //cryRptDoc.SetParameterValue("BusName", cbbusname.SelectedItem.ToString());
                        crvbus.ReportSource = cryRptDoc;
                    }
                    catch (Exception e1)
                    {

                        throw (e1);
                    }



                }

                else if (selectedItem == "Break Service")
                {
                    string connstring = System.Configuration.ConfigurationManager.ConnectionStrings["BUS"].ConnectionString.ToString();
                    SqlConnection conn = new SqlConnection(connstring);
                    conn.Open();
                    string qry = "BreakReport  '" + cbbusname.SelectedItem.ToString() + "','" + dtpfromdate.Value.ToString("yyyy-MM-dd") + "','" + dtptodate.Value.ToString("yyyy-MM-dd") + "'";
                    SqlDataAdapter da = new SqlDataAdapter(qry, conn);
                    DataSet ds = new DataSet();
                    da.Fill(ds);
                    conn.Close();

                    ReportDocument cryRptDoc = new ReportDocument();
                    string reportpath = Path.GetDirectoryName(Application.ExecutablePath).ToString() + General.GetReportPath(General.BREAKREPORT);
                    //string reportpath = @"E:\Karthick\Bus\Erode backup\BUS V2.0\BUS\BUS\Report\NewBreakServiceReport.rpt";
                    cryRptDoc.Load(reportpath);
                    cryRptDoc.SetDataSource(ds.Tables[0].DefaultView);
                    cryRptDoc.SetParameterValue("FromDate", dtpfromdate.Text);
                    cryRptDoc.SetParameterValue("ToDate", dtptodate.Text);
                    cryRptDoc.SetParameterValue("BusName", cbbusname.SelectedItem.ToString());
                    crvbus.ReportSource = cryRptDoc;

                }
                else
                {
                    string connstring = System.Configuration.ConfigurationManager.ConnectionStrings["BUS"].ConnectionString.ToString();
                    SqlConnection conn = new SqlConnection(connstring);
                    conn.Open();
                    string qry = "ClutchReport  '" + cbbusname.SelectedItem.ToString() + "','" + dtpfromdate.Value.ToString("yyyy-MM-dd") + "','" + dtptodate.Value.ToString("yyyy-MM-dd") + "'";
                    SqlDataAdapter da = new SqlDataAdapter(qry, conn);
                    DataSet ds = new DataSet();
                    da.Fill(ds);
                    conn.Close();

                    ReportDocument cryRptDoc = new ReportDocument();
                    string reportpath = Path.GetDirectoryName(Application.ExecutablePath).ToString() + General.GetReportPath(General.CLUTCHREPORT);
                    //string reportpath = @"E:\Karthick\Bus\Erode backup\BUS V2.0\BUS\BUS\Report\NewCluthchServiceReport.rpt";
                    cryRptDoc.Load(reportpath);
                    cryRptDoc.SetDataSource(ds.Tables[0].DefaultView);
                    cryRptDoc.SetParameterValue("FromDate", dtpfromdate.Text);
                    cryRptDoc.SetParameterValue("ToDate", dtptodate.Text);
                    cryRptDoc.SetParameterValue("BusName", cbbusname.SelectedItem.ToString());
                    crvbus.ReportSource = cryRptDoc;
                }

            }
        }

        private void crvbus_Load(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
