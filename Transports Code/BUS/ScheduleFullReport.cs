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
    public partial class ScheduleFullReport : Form
    {
        public ScheduleFullReport()
        {
            InitializeComponent();
        }

        private void btcreate_Click(object sender, EventArgs e)
        {
            string connstring = System.Configuration.ConfigurationManager.ConnectionStrings["BUS"].ConnectionString.ToString();
            SqlConnection conn = new SqlConnection(connstring);
            //int busid = General.GetBusID(cmbBusName.Text, General.BUS);
            conn.Open();

            
            string qry1 = "";
            //qry1 = "SELECT LastDate,ReminderDate,ScheduleType+'-'+Name+'-'+RegNo AS Name,Color FROM ScheduleMaster S INNER JOIN BusMaster B ON S.BusMaster_ID = B.ID INNER JOIN ScheduleType ST On ST.ID = S.Type_ID";
            qry1 = "SELECT RegNo AS RegNo,Name As BusName,Owner As Owner,ScheduleType As ScheduleType,LastDate As Lastdate FROM ScheduleMaster S INNER JOIN BusMaster B ON S.BusMaster_ID = B.ID INNER JOIN ScheduleType ST On ST.ID = S.Type_ID WHERE Lastdate between '" + dtpfromdate.Value.ToString("yyyy-MM-dd") + "' AND '" + dtptodate.Value.ToString("yyyy-MM-dd") + "' order by Lastdate";
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(qry1, conn);
            da.Fill(ds);
            conn.Close();


            ReportDocument cryRptDoc = new ReportDocument();
            string reportpath = Path.GetDirectoryName(Application.ExecutablePath).ToString() + General.GetReportPath(General.SCHEDULEFULLREPORT);
            cryRptDoc.Load(reportpath);
            cryRptDoc.SetDataSource(ds.Tables[0].DefaultView);
            cryRptDoc.SetParameterValue("FromDate", dtpfromdate.Value.ToString("dd-MM-yyyy"));
            cryRptDoc.SetParameterValue("ToDate", dtptodate.Value.ToString("dd-MM-yyyy"));
            crvschedule.ReportSource = cryRptDoc;
            
        }

        private void ScheduleFullReport_Load(object sender, EventArgs e)
        {

        }
    }
}
