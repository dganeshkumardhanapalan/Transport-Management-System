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

namespace BUS
{
    public partial class BusEntry : Form
    {
        public BusEntry()
        {
            InitializeComponent();
        }

        private void tbsave_Click(object sender, EventArgs e)
        {
            try
            {
                string connstring = System.Configuration.ConfigurationManager.ConnectionStrings["BUS"].ConnectionString.ToString();
                SqlConnection conn = new SqlConnection(connstring);
                conn.Open();
                string qry = "INSERT INTO BusMaster VALUES('" + tbbusname.Text + "','" + tbregno.Text + "','" + tbaddowner.Text + "','" + tbenginno.Text + "','" + tbchassisno.Text + "','" + dtpdop.Value.ToShortDateString() + "','"+cbCompanyName.SelectedValue+"')";
                SqlCommand cmd = new SqlCommand(qry, conn);
                cmd.ExecuteNonQuery();
                conn.Close();
                MessageBox.Show(General.SUCCESS_MSG);
                clearbox();
            }
            catch (Exception ex)
            {
                string msg = General.DUPLICATE;
                int count = 0;
                if (ex.Message.IndexOf("IX_BusMaster") > 0)
                {
                    count++;
                    msg += General.BUSNAME;
                }
                if (ex.Message.IndexOf("PK_BusMaster") > 0)
                {
                    count++;
                    msg += General.REGNO;
                }
                if (count > 0)
                {
                    MessageBox.Show(msg);
                }
                else
                {
                    MessageBox.Show(General.UN_SUCCESS_MSG);
                }
            }

        }
        private void clearbox()
        {
            cbCompanyName.SelectedIndex = 0;
            tbbusname.Text = String.Empty;
            tbregno.Text = String.Empty;
            tbenginno.Text = String.Empty;
            tbchassisno.Text = String.Empty;
            dtpdop.Value = DateTime.Today;
            dtppermit.Value = DateTime.Today;
            tbaddowner.Text = String.Empty;

        }

        private void BusEntry_Load(object sender, EventArgs e)
        {
            load_Companyname();
            load_Companynameedit();
            dtpdop.Value = DateTime.Today;
            dtppermit.Value = DateTime.Today;
            editdisableoption();
            if (!General.Is_Delete)
                btdelete.Enabled = false;
            else
                btdelete.Enabled = true;
            if (!General.Is_Edit)
                btmodify.Enabled = false;
            else
                btmodify.Enabled = true; 
        }

        private void editenableoption()
        {
            //txtCompanyNameedit.Text = cbcompanynameedit.SelectedText.ToString();
            cbbusnameedit.Enabled = true;
            tbeditbusname.Enabled = true;
            //txtCompanyNameedit.Enabled = false;
            tbeditregno.Enabled = true;
            tbeditowner.Enabled = true;
            tbeditenginno.Enabled = true;
            tbeditchassisno.Enabled = true;
            dtpeditdop.Enabled = true;
            btupdate.Enabled = true;
            btcancel.Enabled = true;
            btmodify.Enabled = false;
        }

          private void load_Companyname()
        {
            cbCompanyName.Items.Clear();
            string connstring = System.Configuration.ConfigurationManager.ConnectionStrings["BUS"].ConnectionString.ToString();
            SqlConnection conn = new SqlConnection(connstring);
            conn.Open();
            string qry = "select '0' as Id,'--Select Company--' as CompanyName Union select Id,CompanyName FROM CompanyName";
            SqlDataAdapter da = new SqlDataAdapter(qry, conn);
            DataSet ds = new DataSet();
            da.Fill(ds);
            conn.Close();
            int rowcount = ds.Tables[0].Rows.Count;
            if (rowcount == 0)
            {
                MessageBox.Show("No Company Record Found");
            }
            else
            {
                cbCompanyName.DataSource = ds.Tables[0];
                cbCompanyName.ValueMember = "Id";
                cbCompanyName.DisplayMember = "CompanyName";
            }
        }
          private void load_Companynameedit()
          {
              cbcompanynameedit.Items.Clear();
              string connstring = System.Configuration.ConfigurationManager.ConnectionStrings["BUS"].ConnectionString.ToString();
              SqlConnection conn = new SqlConnection(connstring);
              conn.Open();
              string qry = "select Id,CompanyName FROM CompanyName";
              SqlDataAdapter da = new SqlDataAdapter(qry, conn);
              DataSet ds = new DataSet();
              da.Fill(ds);
              conn.Close();
              int rowcount = ds.Tables[0].Rows.Count;
              if (rowcount == 0)
              {
                  MessageBox.Show("No Conductor Record Found");
              }
              else
              {
                  cbcompanynameedit.DataSource = ds.Tables[0];
                  cbcompanynameedit.ValueMember = "Id";
                  cbcompanynameedit.DisplayMember = "CompanyName";

              }
          }
        private void editdisableoption()
        {
            cbcompanynameedit.Enabled = true;
            //txtCompanyNameedit.Enabled = false;
            cbbusnameedit.Enabled = true;
            tbeditbusname.Enabled = false;
            tbeditregno.Enabled = false;
            tbeditowner.Enabled = false;
            tbeditenginno.Enabled = false;
            tbeditchassisno.Enabled = false;
            dtpeditdop.Enabled = false;
            btupdate.Enabled = false;
            btcancel.Enabled = false;
            btmodify.Enabled = true;
        }


        private void btclear_Click(object sender, EventArgs e)
        {
            clearbox();
        }

        private void tbcbusentry_Selected(object sender, TabControlEventArgs e)
        {
            switch ((sender as TabControl).SelectedIndex)
            {
                case 0: //loadcomboboxadd();
                    break;
                case 1: loadcomboboxedit();
                    break;
                case 2: loadcomboboxdelete();
                    deletedisableoption();
                    break;
            }
        }

        private void deletedisableoption()
        {

            cbdeletebusname.Enabled = true;
            tbdeletebusname.Enabled = false;
            tbdeleteregno.Enabled = false;
            tbdeleteowner.Enabled = false;
            tbdeleteenginno.Enabled = false;
            tbdeletechassisno.Enabled = false;
            dtpdeletedop.Enabled = false;
        }



        private void loadcomboboxedit()
        {
            cbbusnameedit.Items.Clear();
            string connstring = System.Configuration.ConfigurationManager.ConnectionStrings["BUS"].ConnectionString.ToString();
            SqlConnection conn = new SqlConnection(connstring);
            conn.Open();
            string qry = "Select * FROM BusMaster";
            SqlDataAdapter da = new SqlDataAdapter(qry, conn);
            DataSet ds = new DataSet();
            da.Fill(ds);
            conn.Close();
            int rowcount = ds.Tables[0].Rows.Count;
            if (rowcount == 0)
            {
                cleareditformvalue();
            }
            else
            {
                for (int count = 0; count < rowcount; count++)
                {
                    cbbusnameedit.Items.Insert(count, Convert.ToString(ds.Tables[0].Rows[count]["Name"]).Trim());
                }
            }

            if (rowcount > 0)
            {
                cbbusnameedit.SelectedIndex = 0;
            }

        }

        private void loadcomboboxdelete()
        {
            cbdeletebusname.Items.Clear();
            string connstring = System.Configuration.ConfigurationManager.ConnectionStrings["BUS"].ConnectionString.ToString();
            SqlConnection conn = new SqlConnection(connstring);
            conn.Open();
            string qry = "select * FROM BusMaster";
            SqlDataAdapter da = new SqlDataAdapter(qry, conn);
            DataSet ds = new DataSet();
            da.Fill(ds);
            conn.Close();
            int rowcount = ds.Tables[0].Rows.Count;
            if (rowcount == 0)
            {
                cleardeleteformvalue();
            }
            else
            {
                for (int count = 0; count < rowcount; count++)
                {
                    cbdeletebusname.Items.Insert(count, Convert.ToString(ds.Tables[0].Rows[count]["Name"]).Trim());
                }
            }

            if (rowcount > 0)
            {
                cbdeletebusname.SelectedIndex = 0;
            }

        }

        private void cleareditformvalue()
        {
            cbbusnameedit.Items.Clear();
            cbbusnameedit.Items.Insert(0, "No Record");
            cbbusnameedit.SelectedIndex = 0;
            tbdeletebusname.Text = string.Empty;
            tbdeleteregno.Text = string.Empty;
            tbdeleteenginno.Text = string.Empty;
            tbdeletechassisno.Text = string.Empty;
            dtpdeletedop.Text = DateTime.Now.ToShortDateString();

        }

        private void cleardeleteformvalue()
        {
            cbdeletebusname.Items.Clear();
            cbdeletebusname.Items.Insert(0, "No Record");
            cbdeletebusname.SelectedIndex = 0;
        }

        private void cbbusnameedit_SelectedIndexChanged(object sender, EventArgs e)
        {
            string connstring = System.Configuration.ConfigurationManager.ConnectionStrings["BUS"].ConnectionString.ToString();
            SqlConnection conn = new SqlConnection(connstring);
            conn.Open();
            string qry = "select * FROM BusMaster where Id='" + cbbusnameedit.SelectedValue + "'";
            SqlDataAdapter da = new SqlDataAdapter(qry, conn);
            DataSet ds = new DataSet();
            da.Fill(ds);
            conn.Close();
            int rowcount = ds.Tables[0].Rows.Count;
            if (rowcount == 0)
            {
                // cleareditformvalue();
            }
            else
            {

                if (rowcount > 0)
                {
                    tbeditbusname.Text = Convert.ToString(ds.Tables[0].Rows[0]["Name"]).Trim();
                    tbeditregno.Text = Convert.ToString(ds.Tables[0].Rows[0]["RegNo"]).Trim();
                    tbeditowner.Text = Convert.ToString(ds.Tables[0].Rows[0]["Owner"]).Trim();
                    tbeditenginno.Text = Convert.ToString(ds.Tables[0].Rows[0]["EnginNo"]).Trim();
                    tbeditchassisno.Text = Convert.ToString(ds.Tables[0].Rows[0]["Chassisno"]).Trim();
                    dtpeditdop.Text = Convert.ToString(ds.Tables[0].Rows[0]["DOP"]).Trim();
                }
            }

        }

        private void btmodify_Click(object sender, EventArgs e)
        {
            if (cbbusnameedit.SelectedItem.ToString() != "No Record")
            {
                editenableoption();
            }
            else
            {
                MessageBox.Show("No Record to Edit");
            }
        }

        private void btupdate_Click(object sender, EventArgs e)
        {
            if(tbeditbusname.Text=="")
            {
                MessageBox.Show("Enter Bus Name");
                return;
            }
            if (tbeditregno.Text == "")
            { 
                MessageBox.Show("Enter Registration Number");
            return;
            }
            if(tbeditowner.Text=="")
            {
                MessageBox.Show("Enter Owner Name");
                return;
            }
            if(tbeditenginno.Text=="")
            {
                MessageBox.Show("Enter Engine Number");
                return;
            }
            string connstring = System.Configuration.ConfigurationManager.ConnectionStrings["BUS"].ConnectionString.ToString();
            SqlConnection conn = new SqlConnection(connstring);
            conn.Open();
            string qry = "update BusMaster set Name='" + tbeditbusname.Text + "',RegNo='" + tbeditregno.Text + "',Owner='" + tbeditowner.Text + "',EnginNo='" + tbeditenginno.Text + "',ChassisNo='" + tbeditchassisno.Text + "',DOP='" + dtpeditdop.Value.ToShortDateString() + "' where Name='" + cbbusnameedit.SelectedItem + "'";
            SqlCommand cmd = new SqlCommand(qry, conn);
            cmd.ExecuteNonQuery();
            conn.Close();
            loadcomboboxedit();
            editdisableoption();
        }

        private void btcancel_Click(object sender, EventArgs e)
        {
            loadcomboboxedit();
            editdisableoption();
        }

        private void cbdeletebusname_SelectedIndexChanged(object sender, EventArgs e)
        {

            string connstring = System.Configuration.ConfigurationManager.ConnectionStrings["BUS"].ConnectionString.ToString();
            SqlConnection conn = new SqlConnection(connstring);
            conn.Open();
            string qry = "select * FROM BusMaster where Name='" + cbdeletebusname.SelectedItem + "'";
            SqlDataAdapter da = new SqlDataAdapter(qry, conn);
            DataSet ds = new DataSet();
            da.Fill(ds);
            conn.Close();
            int rowcount = ds.Tables[0].Rows.Count;
            if (rowcount == 0)
            {
                cleareditformvalue();
            }
            else
            {

                if (rowcount > 0)
                {
                    tbdeletebusname.Text = Convert.ToString(ds.Tables[0].Rows[0]["Name"]).Trim();
                    tbdeleteregno.Text = Convert.ToString(ds.Tables[0].Rows[0]["RegNo"]).Trim();
                    tbdeleteowner.Text = Convert.ToString(ds.Tables[0].Rows[0]["Owner"]).Trim();
                    tbdeleteenginno.Text = Convert.ToString(ds.Tables[0].Rows[0]["EnginNo"]).Trim();
                    tbdeletechassisno.Text = Convert.ToString(ds.Tables[0].Rows[0]["Chassisno"]).Trim();
                    dtpdeletedop.Text = Convert.ToString(ds.Tables[0].Rows[0]["DOP"]).Trim();
                }
            }
        }

        private void btdelete_Click(object sender, EventArgs e)
        {

            if (cbdeletebusname.SelectedItem.ToString() != "No Record")
            {
                if (MessageBox.Show("Really delete?", "Confirm delete", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    string connstring = System.Configuration.ConfigurationManager.ConnectionStrings["BUS"].ConnectionString.ToString();
                    SqlConnection conn = new SqlConnection(connstring);
                    conn.Open();
                    string qry = "Delete from BusMaster where Name='" + cbdeletebusname.SelectedItem + "'";
                    SqlCommand cmd = new SqlCommand(qry, conn);
                    cmd.ExecuteNonQuery();
                    conn.Close();
                    loadcomboboxdelete();
                    MessageBox.Show("Record Deleted");
                }
                else
                {
                    MessageBox.Show("Deletion Aborted");
                }
            }
            else
            {
                MessageBox.Show("No Record to Delete");
            }

        }

        private void cbcompanynameedit_SelectionChangeCommitted(object sender, EventArgs e)
        {
            string connstring = System.Configuration.ConfigurationManager.ConnectionStrings["BUS"].ConnectionString.ToString();
            SqlConnection conn = new SqlConnection(connstring);

            conn.Open();
            string qry = "select Id,Name From BusMaster Where CompanyId='" + cbcompanynameedit.SelectedValue + "'";
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
                cbbusnameedit.DataSource = ds.Tables[0];
                cbbusnameedit.ValueMember = "Id";
                cbbusnameedit.DisplayMember = "Name";
            }

        }
    }
}
