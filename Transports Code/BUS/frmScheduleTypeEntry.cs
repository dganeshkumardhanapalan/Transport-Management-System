using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data.SqlTypes;

namespace BUS
{
    public partial class frmScheduleTypeEntry : Form
    {
        public frmScheduleTypeEntry()
        {
            InitializeComponent();
            addcolorButton.Color = Color.Red;
            tbaddcolorname.Text="#FF0000";
        }

        private void addcolorButton_Changed(object sender, EventArgs e)
        {
            string colorname = addcolorButton.Color.Name;
            colorname = "#" + colorname.Substring(2, 6).ToUpper();
            tbaddcolorname.Text = colorname;
        }

        private void addcolorButton_BackColorChanged(object sender, EventArgs e)
        {

        }

        private void btaadd_Click(object sender, EventArgs e)
        {
            try
            {

                string connstring = System.Configuration.ConfigurationManager.ConnectionStrings["BUS"].ConnectionString.ToString();
                SqlConnection conn = new SqlConnection(connstring);
                conn.Open();
                string qry = "insert into ScheduleType values('" + tbaddscheduletype.Text + "','" + tbaddcolorname.Text + "')";
                SqlCommand cmd = new SqlCommand(qry, conn);
                cmd.ExecuteNonQuery();
                conn.Close();
                MessageBox.Show(General.SUCCESS_MSG);
            }
            catch (Exception ex)
            {
                string msg = General.DUPLICATE;
                int count = 0;
                if (ex.Message.IndexOf("PK_ScheduleType") > 0)
                {
                    count++;
                    msg += "Schedule Type";
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

        private void tabControl1_Selected(object sender, TabControlEventArgs e)
        {
            switch ((sender as TabControl).SelectedIndex)
            {
                case 0: 
                    break;
                case 1: loadeditcombobox();
                    break;
                case 2: loaddeletecombobox();
                    break;
            }
        }

        private void loadeditcombobox()
        {
            cmboxedittype.Items.Clear();
            string connstring = System.Configuration.ConfigurationManager.ConnectionStrings["BUS"].ConnectionString.ToString();
            SqlConnection conn = new SqlConnection(connstring);
            conn.Open();
            string qry = "select * FROM ScheduleType";
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
                    cmboxedittype.Items.Insert(count, Convert.ToString(ds.Tables[0].Rows[count]["ScheduleType"]).Trim());
                }
            }

            if (rowcount > 0)
            {
                cmboxedittype.SelectedIndex = 0;
            }
        }

        private void cleareditformvalue()
        {
            cmboxedittype.Items.Clear();
            cmboxedittype.Items.Insert(0, "No Record");
            cmboxedittype.SelectedIndex = 0;
            tbedittype.Text = "";
            tbeditcolorname.Text = "";
        }

        private void cmboxedittype_SelectedIndexChanged(object sender, EventArgs e)
        {
            string connstring = System.Configuration.ConfigurationManager.ConnectionStrings["BUS"].ConnectionString.ToString();
            SqlConnection conn = new SqlConnection(connstring);
            conn.Open();
            string qry = "select * FROM ScheduleType where ScheduleType='"+cmboxedittype.SelectedItem+"'";
            SqlDataAdapter da = new SqlDataAdapter(qry, conn);
            DataSet ds = new DataSet();
            da.Fill(ds);
            conn.Close();
            //int rowcount = ds.Tables[0].Rows.Count;
            tbedittype.Text=Convert.ToString(ds.Tables[0].Rows[0]["ScheduleType"]).Trim();
            tbeditcolorname.Text=Convert.ToString(ds.Tables[0].Rows[0]["Color"]).Trim();

        }

        private void btmodify_Click(object sender, EventArgs e)
        {
            btmodify.Enabled = false;
            tbedittype.Enabled = true;
            tbeditcolorname.Enabled = false;
            editcolorButton.Enabled = true;
            btupdate.Enabled = true;
            bteditcancel.Enabled = true;
            cmboxedittype.Enabled = false;
        }

        private void editcolorButton_Changed(object sender, EventArgs e)
        {

            string colorname = editcolorButton.Color.Name;
            colorname = "#" + colorname.Substring(2, 6).ToUpper();
            tbeditcolorname.Text = colorname;
        }

        private void btupdate_Click(object sender, EventArgs e)
        {
            try
            {
                string connstring = System.Configuration.ConfigurationManager.ConnectionStrings["BUS"].ConnectionString.ToString();
                SqlConnection conn = new SqlConnection(connstring);
                conn.Open();
                string qry = "update ScheduleType set ScheduleType='" + tbedittype.Text + "',Color='" + tbeditcolorname.Text + "' where ScheduleType='" + cmboxedittype.SelectedItem + "'";
                SqlCommand cmd = new SqlCommand(qry, conn);
                cmd.ExecuteNonQuery();
                conn.Close();
                MessageBox.Show(General.SUCCESS_MSG);

                btmodify.Enabled = true;
                tbedittype.Enabled = false;
                tbeditcolorname.Enabled = false;
                editcolorButton.Enabled = false;
                btupdate.Enabled = false;
                bteditcancel.Enabled = false;
                cmboxedittype.Enabled = true;
            }
            catch (Exception ex)
            {
                editcanceloperation();
                MessageBox.Show(General.UN_SUCCESS_MSG);
            }
        }

        private void editcanceloperation()
        {
            btmodify.Enabled = true;
            tbedittype.Enabled = false;
            tbeditcolorname.Enabled = false;
            editcolorButton.Enabled = false;
            btupdate.Enabled = false;
            bteditcancel.Enabled = false;
            cmboxedittype.Enabled = true;

            string connstring = System.Configuration.ConfigurationManager.ConnectionStrings["BUS"].ConnectionString.ToString();
            SqlConnection conn = new SqlConnection(connstring);
            conn.Open();
            string qry = "select * FROM ScheduleType where ScheduleType='" + cmboxedittype.SelectedItem + "'";
            SqlDataAdapter da = new SqlDataAdapter(qry, conn);
            DataSet ds = new DataSet();
            da.Fill(ds);
            conn.Close();
            //int rowcount = ds.Tables[0].Rows.Count;
            tbedittype.Text = Convert.ToString(ds.Tables[0].Rows[0]["ScheduleType"]).Trim();
            tbeditcolorname.Text = Convert.ToString(ds.Tables[0].Rows[0]["Color"]).Trim();
        }

        private void bteditcancel_Click(object sender, EventArgs e)
        {
            editcanceloperation();
        }


        private void loaddeletecombobox()
        {
            cmboxdelete.Items.Clear();
            string connstring = System.Configuration.ConfigurationManager.ConnectionStrings["BUS"].ConnectionString.ToString();
            SqlConnection conn = new SqlConnection(connstring);
            conn.Open();
            string qry = "select * FROM ScheduleType";
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
                    cmboxdelete.Items.Insert(count, Convert.ToString(ds.Tables[0].Rows[count]["ScheduleType"]).Trim());
                }
            }

            if (rowcount > 0)
            {
                cmboxdelete.SelectedIndex = 0;
            }
        }

        private void cleardeleteformvalue()
        {
            cmboxdelete.Items.Clear();
            cmboxdelete.Items.Insert(0, "No Record");
            cmboxdelete.SelectedIndex = 0;
            tbdeletecolor.Text = "";
            tbdeletetype.Text = "";
        }

        private void btdelete_Click(object sender, EventArgs e)
        {
            if (cmboxdelete.SelectedItem.ToString() != "No Record")
            {
                if (MessageBox.Show("Really delete?", "Confirm delete", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    string connstring = System.Configuration.ConfigurationManager.ConnectionStrings["BUS"].ConnectionString.ToString();
                    SqlConnection conn = new SqlConnection(connstring);
                    conn.Open();
                    string qry = "Delete from ScheduleType where ScheduleType='" + cmboxdelete.SelectedItem + "'";
                    SqlCommand cmd = new SqlCommand(qry, conn);
                    cmd.ExecuteNonQuery();
                    conn.Close();
                    loaddeletecombobox();
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

        private void cmboxdelete_SelectedIndexChanged(object sender, EventArgs e)
        {
            string connstring = System.Configuration.ConfigurationManager.ConnectionStrings["BUS"].ConnectionString.ToString();
            SqlConnection conn = new SqlConnection(connstring);
            conn.Open();
            string qry = "select * FROM ScheduleType where ScheduleType='" + cmboxdelete.SelectedItem + "'";
            SqlDataAdapter da = new SqlDataAdapter(qry, conn);
            DataSet ds = new DataSet();
            da.Fill(ds);
            conn.Close();
            //int rowcount = ds.Tables[0].Rows.Count;
            tbdeletetype.Text = Convert.ToString(ds.Tables[0].Rows[0]["ScheduleType"]).Trim();
            tbdeletecolor.Text = Convert.ToString(ds.Tables[0].Rows[0]["Color"]).Trim();
        }

        private void frmScheduleTypeEntry_Load(object sender, EventArgs e)
        {
            if (!General.Is_Delete)
                btdelete.Enabled = false;
            else
                btdelete.Enabled = true;
            if (!General.Is_Edit)
                btmodify.Enabled = false;
            else
                btmodify.Enabled = true;   
        }

        private void btacancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
       
       
    }
}

