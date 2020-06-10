using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Configuration;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace BUS
{
    public partial class frmSupplier : Form
    {
        int id = 0;
        public frmSupplier()
        {
            InitializeComponent();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (tbName.Text == "")
            {
                MessageBox.Show("Name Manditory");
                return;
            }

            if (tbShortName.Text == "")
            {
                MessageBox.Show("ShortName Manditory");
                return;
            }
            if (tbbalance.Text == "")
            {
                MessageBox.Show("Opening Balance Manditory");
            }
            if (tbAddress.Text == "")
            {
                MessageBox.Show("Address Manditory");
                return;
            }
            else if (tbMobile.Text == "")
            {
                MessageBox.Show("Mobile Number Manditory");
                return;
            }

            string connstring = System.Configuration.ConfigurationManager.ConnectionStrings["BUS"].ConnectionString.ToString();
            using (SqlConnection conn = new SqlConnection(connstring))
            {
                conn.Open();
                string qry1 = string.Empty;
                //int ri = e.RowIndex;
                //id = Convert.ToInt16(gvCompanyDetails.Rows[ri].Cells[0].Value.ToString());
                if (id == 0)
                {
                    qry1 = "INSERT INTO Supplier VALUES('" + tbName.Text + "','" + tbShortName.Text + "','" + tbbalance.Text + "','" + tbAddress.Text + "','" + tbMobile.Text + "','" + tbLandLine.Text + "','" + cbStatus.Checked + "',1,GETDATE(),1,GETDATE())";
                }
                else
                {
                    qry1 = "UPDATE Supplier"
                            + " SET "
                            + " [Name] = '" + tbName.Text + "',"
                             + " [ShortName] = '" + tbShortName.Text + "',"
                              + " [OpeningBalance] = '" + tbbalance.Text + "',"
                              + " [Address] = '" + tbAddress.Text + "',"
                              + " [Mobile] = '" + tbMobile.Text + "',"
                              + " [LandLine] = '" + tbLandLine.Text + "',"
                             + " [IsActive] = '" + cbStatus.Text + "',"
                             + " [ModifiedDate]=GETDATE()"
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

        private void loadGrid()
        {
            try
            {
                string connstring = System.Configuration.ConfigurationManager.ConnectionStrings["BUS"].ConnectionString.ToString();
                using (SqlConnection conn = new SqlConnection(connstring))
                {
                    conn.Open();
                    string qry = "select Id,name as [Name], shortName as [Short Name],openingBalance as [Opening Balance],address as [Address],mobile as [Mobile],landLine as [LandLine],IsActive as [Status] FROM Supplier";

                    SqlDataAdapter da = new SqlDataAdapter(qry, conn);
                    DataSet ds = new DataSet();
                    da.Fill(ds);
                    conn.Close();
                    int rowcount = ds.Tables[0].Rows.Count;
                    if (rowcount > 0)
                    {
                        gvdetails.DataSource = ds.Tables[0];
                        gvdetails.Columns[0].Visible = false;
                    }
                    else
                    {
                        gvdetails.DataSource = null;
                    }
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void frmSupplier_Load(object sender, EventArgs e)
        {
            loadGrid();
        }

        private void gvdetails_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {

                int ri = e.RowIndex;
                id = Convert.ToInt16(gvdetails.Rows[ri].Cells[0].Value.ToString());
                string connstring = System.Configuration.ConfigurationManager.ConnectionStrings["BUS"].ConnectionString.ToString();
                using (SqlConnection conn = new SqlConnection(connstring))
                {
                    conn.Open();
                    string qry = "select * FROM Supplier WHERE id = '" + id + "'";
                    SqlDataAdapter da = new SqlDataAdapter(qry, conn);
                    DataSet ds = new DataSet();
                    da.Fill(ds);
                    conn.Close();
                    int rowcount = ds.Tables[0].Rows.Count;
                    if (rowcount > 0)
                    {
                        tbName.Text = ds.Tables[0].Rows[0]["Name"].ToString();
                        tbShortName.Text = ds.Tables[0].Rows[0]["ShortName"].ToString();
                        tbbalance.Text = ds.Tables[0].Rows[0]["OpeningBalance"].ToString();
                        tbAddress.Text = ds.Tables[0].Rows[0]["Address"].ToString();
                        tbMobile.Text = ds.Tables[0].Rows[0]["Mobile"].ToString();
                        tbLandLine.Text = ds.Tables[0].Rows[0]["LandLine"].ToString();
                        cbStatus.Checked = Convert.ToBoolean(ds.Tables[0].Rows[0]["IsActive"].ToString());
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void clear()
        {
            tbName.Text = "";
            tbShortName.Text = "";
            tbbalance.Text = "";
            tbAddress.Text = "";
            tbMobile.Text = "";
            tbLandLine.Text = "";
            cbStatus.Checked = false;
        }

        private void btnDelete_Click(object sender, EventArgs e)
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
                        qry = "DELETE FROM Supplier WHERE id = " + id.ToString();
                        SqlCommand cmd = new SqlCommand(qry, conn);
                        cmd.ExecuteNonQuery();
                        conn.Close();
                        MessageBox.Show("User Deleted");
                    }
                    loadGrid();
                    id = 0;
                }
                else
                {
                    MessageBox.Show("Select Company Details");
                }
            }
            catch (Exception ex)
            {
                if (ex.Message.IndexOf("FK_CashOut_Supplier") > 0 || ex.Message.IndexOf("FK_ExpenseMaster_Supplier")>0)
                {
                    MessageBox.Show("This Supplier is being used as reference in somewhere");
                }
                else
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }
            clear();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            clear();
        }
    }
}
