using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.IO;

namespace BUS
{
    public partial class frmMontlyReportEdit : Form
    {
        public frmMontlyReportEdit()
        {
            InitializeComponent();
        }
        int id = 0;
        string bus_id = string.Empty;
        string type_id = string.Empty;
        private void frmMontlyReportEdit_Load(object sender, EventArgs e)
        {
            if (!General.Is_Edit)
                btupdate.Enabled = false;
            else
                btupdate.Enabled = true;

            if (!General.Is_Delete)
                btdetele.Enabled = false;
            else
                btdetele.Enabled = true;

            
            gb1.Enabled = false;

            cbbusname.Items.Clear();
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

        private void btcreatereport_Click(object sender, EventArgs e)
        {
            BlindData();
        }
        private void BlindData()
        {
            string connstring = System.Configuration.ConfigurationManager.ConnectionStrings["BUS"].ConnectionString.ToString();
            SqlConnection conn = new SqlConnection(connstring);
            conn.Open();
            string qry = "select mem.Id,mem.Date,bm.Name,etm.ExpenseType,mem.Amount,mem.Remark from BusMaster bm,MonthlyExpenseMaster mem,ExpenseTypeMaster etm where bm.Id=mem.BusName and etm.Id=mem.ExpenseType AND Date between '" + dtpfromdate.Value.ToString("yyyy-MM-dd") + "' AND '" + dtptodate.Value.ToString("yyyy-MM-dd") + "' order by Date";
            SqlDataAdapter da = new SqlDataAdapter(qry, conn);
            DataSet ds = new DataSet();
            da.Fill(ds);
            conn.Close();

            gvData.DataSource = ds.Tables[0].DefaultView;
        }

        private void gvData_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            id = Convert.ToInt32(gvData.Rows[e.RowIndex].Cells[0].Value);


            string connstring = System.Configuration.ConfigurationManager.ConnectionStrings["BUS"].ConnectionString.ToString();
            SqlConnection conn = new SqlConnection(connstring);
            conn.Open();
            string qry = "select mem.Id,mem.Date,bm.Name,etm.ExpenseType,mem.Amount,mem.Remark from BusMaster bm,MonthlyExpenseMaster mem,ExpenseTypeMaster etm where bm.Id=mem.BusName and etm.Id=mem.ExpenseType AND mem.Id=" + id;
            SqlDataAdapter da = new SqlDataAdapter(qry, conn);
            DataSet ds = new DataSet();
            da.Fill(ds);
            conn.Close();
            int rowcount = ds.Tables[0].Rows.Count;
            if (rowcount > 0)
            {
                dtpdate.Text = Convert.ToString(ds.Tables[0].Rows[0]["Date"]).Trim();
                cbbusname.Text = Convert.ToString(ds.Tables[0].Rows[0]["Name"]).Trim();
                cbtype.Text = Convert.ToString(ds.Tables[0].Rows[0]["ExpenseType"]).Trim();
                tbamount.Text = Convert.ToString(ds.Tables[0].Rows[0]["Amount"]).Trim();
                tbremark.Text = Convert.ToString(ds.Tables[0].Rows[0]["Remark"]).Trim();
                
                gb1.Enabled = true;
                dtpdate.Select();
            }
            
        }

        private void btupdate_Click(object sender, EventArgs e)
        {
            try
            {
                string connstring = System.Configuration.ConfigurationManager.ConnectionStrings["BUS"].ConnectionString.ToString();
                SqlConnection conn = new SqlConnection(connstring);
                conn.Open();
                string qry = "SELECT Id From BusMaster where Name='" + cbbusname.Text + "'";
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
                qry = "update MonthlyExpenseMaster set Date='" + dtpdate.Value.ToString("yyyy-MM-dd") + "',BusName='" + bus_id + "',ExpenseType='" + type_id + "',Amount='" + tbamount.Text.ToString() + "',Remark='" + tbremark.Text + "' Where id=" + id;
                SqlCommand cmd = new SqlCommand(qry, conn);
                cmd.ExecuteNonQuery();
                conn.Close();
                MessageBox.Show(General.SUCCESS_MSG);
                BlindData();
                gb1.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Update Failed.");
            }
        }

        private void tbamount_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar.ToString() == "\r")
            {
                this.SelectNextControl(tbamount, true, true, true, true);
            }

            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if (e.KeyChar == '.'
                && (sender as TextBox).Text.IndexOf('.') > -1)
            {
                e.Handled = true;
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

        private void btdetele_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Really delete?", "Confirm delete", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                string connstring = System.Configuration.ConfigurationManager.ConnectionStrings["BUS"].ConnectionString.ToString();
                SqlConnection conn = new SqlConnection(connstring);
                conn.Open();
                string qry = "Delete from MonthlyExpenseMaster where Id=" + id;
                SqlCommand cmd = new SqlCommand(qry, conn);
                cmd.ExecuteNonQuery();
                conn.Close();

                MessageBox.Show("Record Deleted");
                BlindData();
                gb1.Enabled = false;

                dtpfromdate.Select();
            }
            else
            {
                MessageBox.Show("Deletion Aborted");
            }
        }

        private void tbcancel_Click(object sender, EventArgs e)
        {
            BlindData();
            gb1.Enabled = false; 
            dtpfromdate.Select();
            cbbusname.SelectedIndex = 0;
            cbtype.SelectedIndex = 0;
            tbamount.Text = "0.00";
            tbremark.Text = "";

        }
    }
}
