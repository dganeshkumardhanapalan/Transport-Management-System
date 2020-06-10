using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using BUS.Windows.Forms;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;

namespace BUS
{
    public partial class ScheduleReportForm : Form
    {
        public ScheduleReportForm()
        {
            InitializeComponent();
        }

        private void ScheduleReportForm_Load(object sender, EventArgs e)
        {
            string connstring = System.Configuration.ConfigurationManager.ConnectionStrings["BUS"].ConnectionString.ToString();
            SqlConnection conn = new SqlConnection(connstring);
            conn.Open();
            string qry1 = "SELECT '__All__' AS Name UNION Select Name FROM BusMaster ORDER BY Name";
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(qry1, conn);
            da.Fill(ds);
            cmbBusName.DataSource = ds.Tables[0].DefaultView;
            cmbBusName.DisplayMember = "Name";
            conn.Close();

        }

        private void cmbBusName_SelectedIndexChanged(object sender, EventArgs e)
        {
            string connstring = System.Configuration.ConfigurationManager.ConnectionStrings["BUS"].ConnectionString.ToString();
            SqlConnection conn = new SqlConnection(connstring);
            int busid = General.GetBusID(cmbBusName.Text, General.BUS);
            conn.Open();
            string qry1 = "";
            if (cmbBusName.Text == "__All__")
            {
                qry1 = "SELECT LastDate,ReminderDate,ScheduleType+'-'+Name+'-'+RegNo AS Name,Color FROM ScheduleMaster S INNER JOIN BusMaster B ON S.BusMaster_ID = B.ID INNER JOIN ScheduleType ST On ST.ID = S.Type_ID";
            }
            else
            {
                qry1 = "SELECT LastDate,ReminderDate,ScheduleType+'-'+Name+'-'+RegNo AS Name,Color FROM ScheduleMaster S INNER JOIN BusMaster B ON S.BusMaster_ID = B.ID INNER JOIN ScheduleType ST On ST.ID = S.Type_ID Where BusMaster_ID = " + busid;
            }
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(qry1, conn);
            da.Fill(ds);
            conn.Close();

            int length = ds.Tables[0].Rows.Count;
            calendar1.CalendarEvents.Clear();
            for (int i = 0; i < length; i++)
            {
                DateTime lastdate = Convert.ToDateTime(ds.Tables[0].Rows[i]["LastDate"].ToString());
                DateTime reminderDate = Convert.ToDateTime(ds.Tables[0].Rows[i]["ReminderDate"].ToString());
                while (lastdate >= reminderDate)
                {
                    Appointment event1 = new Appointment();
                    event1.StartTime = reminderDate;
                    event1.EndTime = reminderDate;
                    event1.BackColor = System.Drawing.ColorTranslator.FromHtml(ds.Tables[0].Rows[i]["Color"].ToString());
                    event1.Text = ds.Tables[0].Rows[i]["Name"].ToString();
                    calendar1.CalendarEvents.Add(event1);
                    reminderDate = reminderDate.AddDays(1);
                    dateTimePicker1.Text = DateTime.Today.ToShortDateString();
                    calendar1.CurrentDate = DateTime.Today;
                }

            }


        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            this.calendar1.CurrentDate = dateTimePicker1.Value;
        }

        private void button1_Click(object sender, EventArgs e)
        {

  
        }

        private void calendar1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (calendar1.SelectedAppointment != null)
            {
                string[] value = calendar1.SelectedAppointment.Text.Split('-');
                string type = value[0];
                string name = value[1];
                DialogResult dr = MessageBox.Show("Do you Want to Re-Schedule it?", "Re-Schedule", MessageBoxButtons.YesNo);
                if (dr == DialogResult.Yes)
                {
                    int busid = General.GetBusID(name, General.BUS);
                    int typeid = General.GetBusID(type, General.SCHEDULETYPE);

                    string connstring = System.Configuration.ConfigurationManager.ConnectionStrings["BUS"].ConnectionString.ToString();
                    SqlConnection conn = new SqlConnection(connstring);
                    conn.Open();
                    string qry1 = "SELECT * FROM ScheduleMaster Where BusMaster_ID = " + busid + " and type_id =" + typeid;
                    DataSet ds = new DataSet();
                    SqlDataAdapter da = new SqlDataAdapter(qry1, conn);
                    da.Fill(ds);
                    conn.Close();
                    DateTime olddate = Convert.ToDateTime(ds.Tables[0].Rows[0]["OldDate"].ToString());
                    DateTime lastdate = Convert.ToDateTime(ds.Tables[0].Rows[0]["LastDate"].ToString());
                    DateTime reminderDate = Convert.ToDateTime(ds.Tables[0].Rows[0]["ReminderDate"].ToString());
                    int day = Convert.ToInt32(ds.Tables[0].Rows[0]["Day"].ToString());
                    int Month = Convert.ToInt32(ds.Tables[0].Rows[0]["Month"].ToString());
                    int Year = Convert.ToInt32(ds.Tables[0].Rows[0]["Year"].ToString());
                    string Format = ds.Tables[0].Rows[0]["Format"].ToString();
                    int remidnerday = Convert.ToInt32(ds.Tables[0].Rows[0]["ReminderDay"].ToString());
                    olddate = lastdate;
                    if (Format == General.DAY)
                    {
                        lastdate = lastdate.AddDays(day);
                    }
                    else if (Format == General.MONTH)
                    {
                        lastdate = lastdate.AddMonths(Month);
                    }
                    else if (Format == General.YEAR)
                    {
                        lastdate = lastdate.AddYears(Year);
                    }
                    reminderDate = lastdate.AddDays(-1 * remidnerday);

                    string qry = "UPDATE ScheduleMaster SET ";
                    qry += " OldDate = '" + olddate.ToString("yyyy-MM-dd") + "',";
                    qry += " LastDate = '" + lastdate.ToString("yyyy-MM-dd") + "',";
                    qry += " ReminderDate = '" + reminderDate.ToString("yyyy-MM-dd") + "'";
                    qry += " WHERE BusMaster_ID =" + busid;
                    qry += " AND Type_ID=" + typeid;
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(qry, conn);
                    cmd.ExecuteNonQuery();
                    conn.Close();
                    dateTimePicker1.Text = DateTime.Today.ToShortDateString();
                    calendar1.CurrentDate = DateTime.Today;
                    button1_Click(sender, e);
                    MessageBox.Show("Re-Scheduled Successfully");
                    cmbBusName_SelectedIndexChanged(sender, e);
                }
                else if (dr == DialogResult.No)
                {
                    MessageBox.Show("Waiting for Rescheduled");
                }
                else
                {
                    MessageBox.Show("else");
                }
                calendar1.SelectedAppointment = null;

            }

        }

        private void btprint_Click(object sender, EventArgs e)
        {
            
        }

      

    }
}
