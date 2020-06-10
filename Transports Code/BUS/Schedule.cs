using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace BUS
{
    public partial class Schedule : Form
    {
        public int globalid = 0;
        public Schedule()
        {
            InitializeComponent();
        }

        private void Schedule_Load(object sender, EventArgs e)
        {
            BindBusDetails();
            EnableDisableRadio();
            bAdd.Enabled = false;
            bDelete.Enabled = false;
            bUpdate.Enabled = false;
        }

        private void BindBusDetails()
        {
            tbDay.Text = "0";
            tbMonth.Text = "0";
            tbYear.Text = "0";

            string connstring = System.Configuration.ConfigurationManager.ConnectionStrings["BUS"].ConnectionString.ToString();
            SqlConnection conn = new SqlConnection(connstring);
            conn.Open();
            string qry = "Select Name  AS Name FROM BusMaster ORDER BY Name";
            DataSet dsbus = new DataSet();
            SqlDataAdapter dabus = new SqlDataAdapter(qry, conn);
            dabus.Fill(dsbus);

            string qry1 = "SELECT '__All__' AS ScheduleType UNION Select ScheduleType FROM ScheduleType ORDER BY ScheduleType";
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(qry1, conn);
            da.Fill(ds);

            cmbBusName.DataSource = dsbus.Tables[0].DefaultView;
            cmbBusName.DisplayMember = "Name";
            cmbScheduleType.DataSource = ds.Tables[0].DefaultView;
            cmbScheduleType.DisplayMember = "ScheduleType";


            conn.Close();


        }

        private void rbDay_CheckedChanged(object sender, EventArgs e)
        {
            EnableDisableRadio();
        }

        private void rbMonth_CheckedChanged(object sender, EventArgs e)
        {
            EnableDisableRadio();
        }

        private void rbYear_CheckedChanged(object sender, EventArgs e)
        {
            EnableDisableRadio();
        }

        private void EnableDisableRadio()
        {
            tbDay.Enabled = false;
            tbMonth.Enabled = false;
            tbYear.Enabled = false;
            if (rbDay.Checked)
            {
                tbDay.Enabled = true;
                tbDay.Text = "0";
                tbMonth.Text = "0";
                tbYear.Text = "0";
            }
            else if (rbMonth.Checked)
            {
                tbMonth.Enabled = true;
                tbDay.Text = "0";
                tbDay.Text = "0";
                tbYear.Text = "0";
            }
            else
            {
                tbYear.Enabled = true;
                tbDay.Text = "0";
                tbDay.Text = "0";
                tbMonth.Text = "0";
            }
        }

        private void cmbScheduleType_SelectedIndexChanged(object sender, EventArgs e)
        {
            lDate.Text = "Last " + cmbScheduleType.Text + " Date";
            if (cmbScheduleType.SelectedIndex == 0)
            {
                BindDetails(0);
                bAdd.Enabled = false;
                bDelete.Enabled = false;
                bUpdate.Enabled = false;
                gvScheduleData.Enabled = false;
            }
            else
            {
                BindDetails(1);
                bAdd.Enabled = true;
                bDelete.Enabled = false;
                bUpdate.Enabled = false;
                gvScheduleData.Enabled = true;
            }
            ClearResult();
     


        }

        private void ClearResult()
        {
            tbDay.Text = "0";
            tbMonth.Text = "0";
            tbYear.Text = "0";
            tbDay.Enabled = true;
            tbMonth.Enabled = false;
            tbYear.Enabled = false;
            dateTimePicker1.Text = DateTime.Today.ToShortDateString();
            tbRemind.Text = "0";
            rbDay.Checked = true;
        }

        private void cmbBusName_SelectedIndexChanged(object sender, EventArgs e)
        {

            lDate.Text = "Last Date";
            if (cmbScheduleType.SelectedIndex != -1)
            {
                cmbScheduleType.SelectedIndex = 0;
            }
            BindDetails(0);
        }

        private void bAdd_Click(object sender, EventArgs e)
        {
            try
            {
                int busid = General.GetBusID(cmbBusName.Text, General.BUS);
                int type = General.GetBusID(cmbScheduleType.Text, General.SCHEDULETYPE);
                int day = Convert.ToInt32(tbDay.Text);
                int month = Convert.ToInt32(tbMonth.Text);
                int year = Convert.ToInt32(tbYear.Text);
                int recurring = 1;
                int reminderday = Convert.ToInt32(tbRemind.Text);
                DateTime olddate = Convert.ToDateTime(dateTimePicker1.Text);
                DateTime lastdate = olddate;
                string format = "";
                if (rbDay.Checked)
                {
                    lastdate = lastdate.AddDays(Convert.ToInt32(tbDay.Text));
                    format = General.DAY;
                }
                else if (rbMonth.Checked)
                {
                    lastdate = lastdate.AddMonths(Convert.ToInt32(tbMonth.Text));
                    format = General.MONTH;
                }
                else if (rbYear.Checked)
                {
                    lastdate = lastdate.AddYears(Convert.ToInt32(tbYear.Text));
                    format = General.YEAR;
                }

                DateTime reminderdate = lastdate.AddDays((-1 * Convert.ToDouble(tbRemind.Text)));

                string qry = "INSERT INTO ScheduleMaster VALUES( ";
                qry += busid + ",";
                qry += type + ",";
                qry += day + ",";
                qry += month + ",";
                qry += year + ",";
                qry += recurring + ",";
                qry += reminderday + ",";
                qry += "'" + olddate.ToString("yyyy-MM-dd") + "',";
                qry += "'" + lastdate.ToString("yyyy-MM-dd") + "',";
                qry += "'" + reminderdate.ToString("yyyy-MM-dd") + "',";
                qry += "'" + format + "')";
                string connstring = System.Configuration.ConfigurationManager.ConnectionStrings["BUS"].ConnectionString.ToString();
                SqlConnection conn = new SqlConnection(connstring);
                conn.Open();
                SqlCommand cmd = new SqlCommand(qry, conn);
                cmd.ExecuteNonQuery();
                conn.Close();
                MessageBox.Show(General.SUCCESS_MSG);
                BindDetails(1);
                ClearResult();
                this.SelectNextControl(cmbBusName, true, true, true, true);
            }
            catch (Exception ex)
            {
                if (ex.Message.IndexOf("IX_ScheduleMaster") > 0)
                {
                    MessageBox.Show("Data Already Exists");
                }
            }
        }

        private void gvScheduleData_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int id = Convert.ToInt32(gvScheduleData.Rows[e.RowIndex].Cells[0].Value);
            globalid = id;
            BindEditDetails(id);
        }

        private void BindDetails(int id)
        {
            string connstring = System.Configuration.ConfigurationManager.ConnectionStrings["BUS"].ConnectionString.ToString();
            SqlConnection conn = new SqlConnection(connstring);
            conn.Open();
            int busid = General.GetBusID(cmbBusName.Text, General.BUS);
            int type = General.GetBusID(cmbScheduleType.Text, General.SCHEDULETYPE);

            string qry = "SELECT ";
            qry += " SM.ID, BM.Name AS [Bus Name], ST.ScheduleType AS [Type], SM.OldDate AS [Old Date], SM.LastDate As [Last Date], SM.ReminderDate AS [Reminder Date]";
            qry += " FROM ScheduleMaster SM INNER JOIN BusMaster BM ON SM.BusMaster_ID = BM.ID ";
            qry += " INNER JOIN ScheduleType ST ON SM.Type_ID = ST.ID ";
            qry += " WHERE BM.ID = " + busid;
            if (id == 1)
            {
                qry += " AND ST.ID = " + type;
                groupBox3.Enabled = true;
            }
            else
            {
                groupBox3.Enabled = false;
            }


            DataSet dsbus = new DataSet();
            SqlDataAdapter dabus = new SqlDataAdapter(qry, conn);
            dabus.Fill(dsbus);
            gvScheduleData.DataSource = dsbus.Tables[0].DefaultView;
            gvScheduleData.Columns[0].Visible = false;


        }

        private void BindEditDetails(int id)
        {
            string connstring = System.Configuration.ConfigurationManager.ConnectionStrings["BUS"].ConnectionString.ToString();
            SqlConnection conn = new SqlConnection(connstring);
            conn.Open();
            string qry = "SELECT * FROM ScheduleMaster where ID = " + id;
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(qry, conn);
            da.Fill(ds);
            conn.Close();

            if (ds.Tables[0].Rows.Count > 0)
            {
                tbDay.Text = ds.Tables[0].Rows[0]["Day"].ToString();
                tbMonth.Text = ds.Tables[0].Rows[0]["Month"].ToString();
                tbYear.Text = ds.Tables[0].Rows[0]["Year"].ToString();
                string format = ds.Tables[0].Rows[0]["Format"].ToString();
                if (format == General.DAY)
                {
                    rbDay.Checked = true;
                }
                else if (format == General.MONTH)
                {
                    rbMonth.Checked = true;
                }
                else if (format == General.YEAR)
                {
                    rbYear.Checked = true;
                }
                tbRemind.Text = ds.Tables[0].Rows[0]["ReminderDay"].ToString();
                dateTimePicker1.Text = ds.Tables[0].Rows[0]["OldDate"].ToString();

                bAdd.Enabled = false;
                if (!General.Is_Edit)
                    bUpdate.Enabled = false;
                else
                    bUpdate.Enabled = true;

                if (!General.Is_Delete)
                    bDelete.Enabled = false;
                else
                    bDelete.Enabled = true;
            }


        }

        private void bUpdate_Click(object sender, EventArgs e)
        {
            int busid = General.GetBusID(cmbBusName.Text, General.BUS);
            int type = General.GetBusID(cmbScheduleType.Text, General.SCHEDULETYPE);
            int day = Convert.ToInt32(tbDay.Text);
            int month = Convert.ToInt32(tbMonth.Text);
            int year = Convert.ToInt32(tbYear.Text);
            int recurring = 1;
            int reminderday = Convert.ToInt32(tbRemind.Text);
            DateTime olddate = Convert.ToDateTime(dateTimePicker1.Text);
            DateTime lastdate = olddate;
            string format = "";
            if (rbDay.Checked)
            {
                lastdate = lastdate.AddDays(Convert.ToInt32(tbDay.Text));
                format = General.DAY;
            }
            else if (rbMonth.Checked)
            {
                lastdate = lastdate.AddMonths(Convert.ToInt32(tbMonth.Text));
                format = General.MONTH;
            }
            else if (rbYear.Checked)
            {
                lastdate = lastdate.AddYears(Convert.ToInt32(tbYear.Text));
                format = General.YEAR;
            }

            DateTime reminderdate = lastdate.AddDays((-1 * Convert.ToDouble(tbRemind.Text)));

            string qry = "UPDATE ScheduleMaster SET ";
            qry += " BusMaster_ID = "+busid + ",";
            qry += " Type_ID = "+type + ",";
            qry += " Day= "+day + ",";
            qry += " Month= "+month + ",";
            qry += " Year= "+year + ",";
            qry += " Recurring = "+recurring + ",";
            qry += " ReminderDay = "+reminderday + ",";
            qry += " OldDate = '" + olddate.ToString("yyyy-MM-dd") + "',";
            qry += " LastDate = '" + lastdate.ToString("yyyy-MM-dd") + "',";
            qry += " ReminderDate = '" +reminderdate.ToString("yyyy-MM-dd") + "',";
            qry += " Format = '" + format + "'";
            qry += " WHERE ID =" + globalid;
            string connstring = System.Configuration.ConfigurationManager.ConnectionStrings["BUS"].ConnectionString.ToString();
            SqlConnection conn = new SqlConnection(connstring);
            conn.Open();
            SqlCommand cmd = new SqlCommand(qry, conn);
            cmd.ExecuteNonQuery();
            conn.Close();
            MessageBox.Show(General.SUCCESS_MSG);
            BindDetails(1);
        }

        private void bDelete_Click(object sender, EventArgs e)
        {

            string connstring = System.Configuration.ConfigurationManager.ConnectionStrings["BUS"].ConnectionString.ToString();
            SqlConnection conn = new SqlConnection(connstring);
            conn.Open();
            SqlCommand cmd = new SqlCommand("DELETE FROM ScheduleMaster WHERE ID = "+globalid, conn);
            cmd.ExecuteNonQuery();
            conn.Close();
            MessageBox.Show(General.SUCCESS_MSG);
            BindDetails(1);
            ClearResult();
        }
    }
}
