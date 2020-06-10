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


namespace BUS
{
    public partial class frmothermonthlyexp : Form
    {
        public frmothermonthlyexp()
        {
            InitializeComponent();
        }

        string bus_id = string.Empty;
        string type_id = string.Empty;

        private void frmothermonthlyexp_Load(object sender, EventArgs e)
        {
            cbbusname.Items.Clear();
            load_Companyname();
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
                MessageBox.Show("No Bus Name Record Found");
            }
            else
            {
                for (int count = 0; count < rowcount; count++)
                {
                    cbbusname.Items.Insert(count, Convert.ToString(ds.Tables[0].Rows[count]["Name"]).Trim());
                }
                cbbusname.SelectedIndex = 0;
            }


            cbtype.Items.Clear();
            conn.Open();
            qry = "select * FROM ExpenseTypeMaster";
            da = new SqlDataAdapter(qry, conn);
            ds = new DataSet();
            da.Fill(ds);
            conn.Close();
            rowcount = ds.Tables[0].Rows.Count;
            if (rowcount == 0)
            {
                MessageBox.Show("No Expense Type Record Found");
            }
            else
            {
                for (int count = 0; count < rowcount; count++)
                {
                    cbtype.Items.Insert(count, Convert.ToString(ds.Tables[0].Rows[count]["ExpenseType"]).Trim());
                }
                cbtype.SelectedIndex = 0;
            }
        }

        private void tbamount_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar.ToString() == "\r")
            {
                this.SelectNextControl(tbamount, true, true, true, true);
            }
        }

        private void tbamount_Leave(object sender, EventArgs e)
        {
            if (tbamount.Text != "")
            {
                tbamount.Text = Convert.ToDouble(tbamount.Text).ToString("F");
            }
            else
            {
                tbamount.Text = "0.00";
            }
        }

        private void tbamount_TextChanged(object sender, EventArgs e)
        {
            if (tbamount.Text != "")
            {
                //expenses();
            }
            else
            {
                tbamount.Text = "0.00";
                tbamount.SelectionStart = 0;
                tbamount.SelectionLength = tbamount.Text.Length;
            }
        }
        private void clearoperation()
        {
            tbremark.Text = string.Empty;
            tbamount.Text = "0.00";
            cbbusname.SelectedIndex = 0;
            cbtype.SelectedIndex = 0;
            dtpdate.Value = DateTime.Now;
        }

        private void btsave_Click(object sender, EventArgs e)
        {
            try
                {

            if (tbamount.Text != "0.00")
            {

                string connstring = System.Configuration.ConfigurationManager.ConnectionStrings["BUS"].ConnectionString.ToString();
                SqlConnection conn = new SqlConnection(connstring);
                conn.Open();
                string qry = "SELECT Id From BusMaster where Name='"+cbbusname.Text+"'";
                SqlDataAdapter da = new SqlDataAdapter(qry, conn);
                DataSet ds = new DataSet();
                da.Fill(ds);
                conn.Close();
                int rowcount = ds.Tables[0].Rows.Count;
                if (rowcount == 0)
                {
                    MessageBox.Show("Error Code : 101");
                }
                else
                {
                        bus_id = Convert.ToString(ds.Tables[0].Rows[0]["Id"]).Trim();
                }
             
                conn.Open();
                qry = "SELECT Id From ExpenseTypeMaster where ExpenseType='" + cbtype.Text + "'";
                da = new SqlDataAdapter(qry, conn);
                ds = new DataSet();
                da.Fill(ds);
                conn.Close();
                rowcount = ds.Tables[0].Rows.Count;
                if (rowcount == 0)
                {
                    MessageBox.Show("Error Code : 102");
                }
                else
                {
                    type_id = Convert.ToString(ds.Tables[0].Rows[0]["Id"]).Trim();
                }


                
                    conn.Open();

                    String selectedItem = cbtype.SelectedItem.ToString();
                    if (selectedItem == "Tyre Exp")
                    {
                
                        if (Convert.ToDouble(tbtyerno.Text) > 0 && Convert.ToDouble(tbtyerno.Text) < 8)
                        {
                            qry = "insert into MonthlyExpenseMaster values('" + dtpdate.Value.ToString("yyyy-MM-dd") + "','" + Convert.ToInt16(bus_id) + "','" + Convert.ToInt16(type_id) + "','" + tbamount.Text + "','" + tbremark.Text + "','" + tbtyerno.Text + "','"+cbCompanyName.Text+"')";
                            SqlCommand cmd = new SqlCommand(qry, conn);
                            cmd.ExecuteNonQuery();
                            conn.Close();
                            MessageBox.Show("ok");
                            clearoperation();
                            dtpdate.Select();
                        }
                        else
                        {
                            MessageBox.Show("Select Tyre No. Between 1 to 7");
                        }
                    }
                    else
                    {
                        tbtyerno.Text = 0.ToString();
                        qry = "insert into MonthlyExpenseMaster values('" + dtpdate.Value.ToString("yyyy-MM-dd") + "','" + Convert.ToInt16(bus_id) + "','" + Convert.ToInt16(type_id) + "','" + tbamount.Text + "','" + tbremark.Text + "','" + tbtyerno.Text + "','"+cbCompanyName.Text+"')";
                        SqlCommand cmd = new SqlCommand(qry, conn);
                        cmd.ExecuteNonQuery();
                        conn.Close();
                        MessageBox.Show("ok");
                        clearoperation();
                        dtpdate.Select();
                    }
                   
                
            }
            else
            {
                MessageBox.Show("Enter Expense Amount");
            }
                }
            catch (Exception ex)
            {
                MessageBox.Show("Error Message");
            }
        }
        private void load_Companyname()
        {
            cbCompanyName.Items.Clear();
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
                cbCompanyName.DataSource = ds.Tables[0];
                cbCompanyName.ValueMember = "Id";
                cbCompanyName.DisplayMember = "CompanyName";
            
            }
        }
        private void cbtype_SelectedIndexChanged(object sender, EventArgs e)
        {
            String selectedItem = cbtype.SelectedItem.ToString();
            if (selectedItem == "Tyre Exp")
            {
                label3.Visible = true;
                tbtyerno.Visible = true;
            }
            else
            {
                label3.Visible = true;
                tbtyerno.Visible = false;
            }
        }

        private void tbtyerno_TextChanged(object sender, EventArgs e)
        {

        }

        private void tbtyerno_KeyPress(object sender, KeyPressEventArgs e)
        {
  
        }

        private void btclear_Click(object sender, EventArgs e)
        {

        }

        private void cbCompanyName_SelectionChangeCommitted(object sender, EventArgs e)
        {
            string connstring = System.Configuration.ConfigurationManager.ConnectionStrings["BUS"].ConnectionString.ToString();
            SqlConnection conn = new SqlConnection(connstring);

            conn.Open();
            string qry = "select Id,Name From BusMaster Where CompanyId='" + cbCompanyName.SelectedValue + "'";
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
                cbbusname.DataSource = ds.Tables[0];
                cbbusname.ValueMember = "Id";
                cbbusname.DisplayMember = "Name";
            }

        }
    }
}