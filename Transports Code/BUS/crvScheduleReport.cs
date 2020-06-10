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
using System.IO;

namespace BUS
{
    public partial class crvScheduleReport : Form
    {
        public crvScheduleReport()
        {
            InitializeComponent();
        }

        private void crvScheduleReport_Load(object sender, EventArgs e)
        {
            dtpdate.Value = DateTime.Now;
        }

        private void btcreate_Click(object sender, EventArgs e)
        {
            string connstring = System.Configuration.ConfigurationManager.ConnectionStrings["BUS"].ConnectionString.ToString();
            SqlConnection conn = new SqlConnection(connstring);
            //int busid = General.GetBusID(cmbBusName.Text, General.BUS);
            conn.Open();

            DateTime fromdate = new DateTime(dtpdate.Value.Year, dtpdate.Value.Month, 1);
            DateTime todate = new DateTime(dtpdate.Value.Year, dtpdate.Value.Month, DateTime.DaysInMonth(dtpdate.Value.Year, dtpdate.Value.Month));
            string qry1 = "";
            //qry1 = "SELECT LastDate,ReminderDate,ScheduleType+'-'+Name+'-'+RegNo AS Name,Color FROM ScheduleMaster S INNER JOIN BusMaster B ON S.BusMaster_ID = B.ID INNER JOIN ScheduleType ST On ST.ID = S.Type_ID";
            qry1 = "SELECT RegNo AS RegNo,Name As BusName,ScheduleType As ScheduleType,ReminderDate As ReminderDate,LastDate As Lastdate FROM ScheduleMaster S INNER JOIN BusMaster B ON S.BusMaster_ID = B.ID INNER JOIN ScheduleType ST On ST.ID = S.Type_ID WHERE Lastdate between '" + fromdate.ToString("yyyy-MM-dd") + "' AND '" + todate.ToString("yyyy-MM-dd") + "'";
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(qry1, conn);
            da.Fill(ds);
            conn.Close();


            ReportDocument cryRptDoc = new ReportDocument();
            string reportpath = Path.GetDirectoryName(Application.ExecutablePath).ToString() + General.GetReportPath(General.SCHEDULEREPORT);
            cryRptDoc.Load(reportpath);
            cryRptDoc.SetDataSource(ds.Tables[0].DefaultView);
            cryRptDoc.SetParameterValue("FromDate", fromdate.ToString("dd-MM-yyyy"));
            cryRptDoc.SetParameterValue("ToDate", todate.ToString("dd-MM-yyyy"));
            crvschedule.ReportSource = cryRptDoc;
            
        }
    }
}
