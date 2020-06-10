using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Configuration;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace BUS
{
    public partial class frmCompanyName : Form
    {
        int id = 0;
        public frmCompanyName()
        {
            InitializeComponent();
        }
        string connstring = System.Configuration.ConfigurationManager.ConnectionStrings["BUS"].ConnectionString.ToString();
       
        private void btAdd_Click(object sender, EventArgs e)
        {
            if(txtCompanyName.Text=="")
            {
                MessageBox.Show("Please Fill Company Name");
                return;
            }
            if(txtShortName.Text=="")
            {
                MessageBox.Show("Please Fill Short Name");
            }
                string qry = string.Empty;
                SqlConnection con1 = new SqlConnection(connstring);
                qry = "select Id,[CompanyName] From [dbo].[CompanyName] Where [CompanyName]='" + txtCompanyName.Text + "'";
                SqlDataAdapter da = new SqlDataAdapter(qry, con1);
                DataSet ds = new DataSet();
                da.Fill(ds);
                con1.Close();
                int rowcount = ds.Tables[0].Rows.Count;
                if (rowcount > 0)
                {
                    MessageBox.Show("Company Name Already Exists");
                    return;
                }
                    using (SqlConnection conn = new SqlConnection(connstring))
                    {
                        conn.Open();
                        string qry1 = string.Empty;
                        if (id == 0)
                        {
                            qry1 = "INSERT INTO CompanyName VALUES('" + txtCompanyName.Text + "','" + txtShortName.Text + "','" + chkIsActive.Checked + "')";
                        }
                        else
                        {
                            qry1 = "UPDATE CompanyName"
                                    + " SET "
                                    + " [companyName] = '" + txtCompanyName.Text + "',"
                                     + " [shortname] = '" + txtShortName.Text + "',"
                                     + " [IsActive] = '" + chkIsActive.Text + "'"
                                    + " WHERE"
                                     + " [Id] = " + id.ToString() + "";
                        }
                        SqlCommand cmd = new SqlCommand(qry1, conn);
                        cmd.ExecuteNonQuery();
                        conn.Close();
                        MessageBox.Show("Save Successfully");
                        loadGrid();
                        clear();
                    }
                }
         
            
        private void clear()
        {
            txtCompanyName.Text = "";
            txtShortName.Text = "";
            chkIsActive.Checked = false;
        }
                    
        private void loadGrid()
        {
            try
            {
                string connstring = System.Configuration.ConfigurationManager.ConnectionStrings["BUS"].ConnectionString.ToString();
                using (SqlConnection conn = new SqlConnection(connstring))
                {
                    conn.Open();
                    string qry = "select Id,companyname as [Company Name], shortName as [Short Name],IsActive as [Status] FROM CompanyName";
                    
                    SqlDataAdapter da = new SqlDataAdapter(qry, conn);
                    DataSet ds = new DataSet();
                    da.Fill(ds);
                    conn.Close();
                    int rowcount = ds.Tables[0].Rows.Count;
                    if (rowcount > 0)
                    {
                        gvCompanyDetails.DataSource = ds.Tables[0];
                        gvCompanyDetails.Columns[0].Visible = false;
                    }
                    else
                    {
                        gvCompanyDetails.DataSource = null;
                    }
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void gvCompanyDetails_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {

                int ri = e.RowIndex;
                 id = Convert.ToInt16(gvCompanyDetails.Rows[ri].Cells[0].Value.ToString());
                string connstring = System.Configuration.ConfigurationManager.ConnectionStrings["BUS"].ConnectionString.ToString();
                using (SqlConnection conn = new SqlConnection(connstring))
                {
                    conn.Open();
                    string qry = "select * FROM CompanyName WHERE id = '" + id + "'";
                    SqlDataAdapter da = new SqlDataAdapter(qry, conn);
                    DataSet ds = new DataSet();
                    da.Fill(ds);
                    conn.Close();
                    int rowcount = ds.Tables[0].Rows.Count;
                    if (rowcount > 0)
                    {
                        txtCompanyName.Text = ds.Tables[0].Rows[0]["CompanyName"].ToString();
                        txtShortName.Text = ds.Tables[0].Rows[0]["ShortName"].ToString();
                        chkIsActive.Checked = Convert.ToBoolean(ds.Tables[0].Rows[0]["IsActive"].ToString());
                       
                    }
                }
              
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void frmCompanyName_Load(object sender, EventArgs e)
        {
            loadGrid();
        }

        private void btDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (id > 0)
                {
                    string connstring = System.Configuration.ConfigurationManager.ConnectionStrings["BUS"].ConnectionString.ToString();
                    using (SqlConnection conn = new SqlConnection(connstring))
                    {
                        conn.Open();
                        string qry = string.Empty;
                        qry = "DELETE FROM CompanyName WHERE id = " + id.ToString();
                        SqlCommand cmd = new SqlCommand(qry, conn);
                        cmd.ExecuteNonQuery();
                        conn.Close();
                        MessageBox.Show("User Deleted");
                    }
                    loadGrid();
                    clear();
                    //btDelete.Enabled = false;
                    id = 0;
                }
                else
                {
                    MessageBox.Show("Select Company Details");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }

        }

        private void btEdit_Click(object sender, EventArgs e)
        {
            txtCompanyName.Enabled = true;
            txtShortName.Enabled = true;
            chkIsActive.Enabled = true;
        }
    }
}
