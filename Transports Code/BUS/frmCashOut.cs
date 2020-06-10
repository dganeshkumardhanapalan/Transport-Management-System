using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Configuration;
using System.Data.SqlClient;

namespace BUS
{
    public partial class frmCashOut : Form
    {
        int id = 0;
        string connString = String.Empty;
        public frmCashOut(int id)
        {
            InitializeComponent();
            connString = System.Configuration.ConfigurationManager.ConnectionStrings["BUS"].ConnectionString.ToString();
            this.id = id;
        }
        private void setValues(int val)
        {
            loadSupplier();
            id = val;

            SqlConnection conn = new SqlConnection(connString);
            conn.Open();
            string qry = "select * from CashOut where Id=" + id;
            SqlDataAdapter da = new SqlDataAdapter(qry, conn);
            DataSet ds = new DataSet();
            da.Fill(ds);
            conn.Close();
            int rowcount = ds.Tables[0].Rows.Count;
            if (rowcount > 0)
            {
                cbSupplier.SelectedValue = ds.Tables[0].Rows[0]["SupplierId"].ToString();
               // cbSupplier.SelectedText = Convert.ToString(ds.Tables[0].Rows[0]["SupplierId"]).Trim();
                txtAmount.Text = Convert.ToString(ds.Tables[0].Rows[0]["TotalAmount"]).Trim();
                txtCash.Text = Convert.ToString(ds.Tables[0].Rows[0]["Cash"]).Trim();
                txtCheque.Text = Convert.ToString(ds.Tables[0].Rows[0]["Cheque"]).Trim();
                dtpChequeDate.Text = Convert.ToString(ds.Tables[0].Rows[0]["ChequeDate"]).Trim();
                txtChequeDetails.Text = Convert.ToString(ds.Tables[0].Rows[0]["ChequeDetails"]).Trim();
                txtDD.Text = Convert.ToString(ds.Tables[0].Rows[0]["DD"]).Trim();
                dtpDDDate.Text = Convert.ToString(ds.Tables[0].Rows[0]["DDdate"]).Trim();
                txtDDDetails.Text = Convert.ToString(ds.Tables[0].Rows[0]["DDdetails"]).Trim();
                txtTransfer.Text = Convert.ToString(ds.Tables[0].Rows[0]["Transfer"]).Trim();
                dtpTransferDate.Text = Convert.ToString(ds.Tables[0].Rows[0]["TransferDate"]).Trim();
                txtTransferDetails.Text = Convert.ToString(ds.Tables[0].Rows[0]["TransferDetails"]).Trim();
                txtRemark.Text = Convert.ToString(ds.Tables[0].Rows[0]["Remark"]).Trim();
            }
        }
        private void frmCashOut_Load(object sender, EventArgs e)
        {
            loadSupplier();
            if(id>0)
            {
                setValues(id);
            }
            
        }
        public void loadSupplier()
        {
            //cbSupplier.Items.Clear();
            
            SqlConnection conn = new SqlConnection(connString);
            conn.Open();
            string qry = "select '0' as Id,'--Select Supplier--' AS Name union select Id,Name FROM Supplier";
            SqlDataAdapter da = new SqlDataAdapter(qry, conn);
            DataSet ds = new DataSet();
            da.Fill(ds);
            conn.Close();
            int rowcount = ds.Tables[0].Rows.Count;
            if (rowcount == 0)
            {
                MessageBox.Show("No Supplier Record Found");
            }
            else
            {
                cbSupplier.DataSource = ds.Tables[0];
                cbSupplier.ValueMember = "Id";
                cbSupplier.DisplayMember = "Name";
                cbSupplier.SelectedIndex = 0;
            }
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if(cbSupplier.SelectedIndex >0)
            {
            if (Convert.ToInt16(Convert.ToDecimal(txtAmount.Text)) == Convert.ToInt16(Convert.ToDecimal(txtCash.Text) + Convert.ToDecimal(txtCheque.Text) + Convert.ToDecimal(txtDD.Text) + Convert.ToDecimal(txtTransfer.Text)))
            {
                string qry1 = string.Empty;
                if (id == 0)
                {
                    qry1 = "insert into CashOut values('" + cbSupplier.SelectedValue + "','" + dtpdate.Value.ToString("yyyy'-'MM'-'dd") + "','" + txtAmount.Text + "','" + txtCash.Text + "','" + txtCheque.Text + "','" + dtpChequeDate.Value.ToString("yyyy'-'MM'-'dd") + "','" + txtChequeDetails.Text + "','" + txtDD.Text + "','" + dtpDDDate.Value.ToString("yyyy'-'MM'-'dd") + "','" + txtDDDetails.Text + "','" + txtTransfer.Text + "','" + dtpTransferDate.Value.ToString("yyyy'-'MM'-'dd") + "','" + txtTransferDetails.Text + "','" + txtRemark.Text + "',1,GETDATE(),1,GETDATE())";
                    SqlConnection conn = new SqlConnection(connString);
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(qry1, conn);
                    cmd.ExecuteNonQuery();
                    conn.Close();
                    MessageBox.Show("Save Successfully");
                    clear();
                }
                else
                {
                    qry1 = "UPDATE CashOut"
                            + " SET "
                            + " [SupplierId] = '" + cbSupplier.SelectedValue + "',"
                             + " [TotalAmount] = '" + txtAmount.Text + "',"
                             + " [Cash] = '" + txtCash.Text + "',"
                             + " [Cheque] = '" + txtCheque.Text + "',"
                             + " [ChequeDetails] = '" + txtChequeDetails.Text + "',"
                             + " [DD] = '" + txtDD.Text + "',"
                             + " [DDdetails] = '" + txtDDDetails.Text + "',"
                                 + " [Transfer] = '" + txtTransfer.Text + "',"
                                   + " [TransferDetails] = '" + txtTransferDetails.Text + "',"
                                     + " [Remark] = '" + txtRemark.Text + "',"
                             + " [ModifiedBy] = 1,"
                             + " [ModifiedDate] = GETDATE()"
                            + " WHERE"
                             + " [Id] = '" + id.ToString() + "'";

                    SqlConnection conn = new SqlConnection(connString);
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(qry1, conn);
                    cmd.ExecuteNonQuery();
                    conn.Close();
                    MessageBox.Show("Updated Successfully");
                    clear();
                }
                }
                    else
            {
                MessageBox.Show("Check the Amount equals or not");
            }
            
            
            }
            else
            {
                MessageBox.Show("Select Suppliers");
            }
        }
        private void btnClear_Click(object sender, EventArgs e)
        {
            clear();
        }

        public void clear()
        {
            cbSupplier.SelectedIndex = 0;
            txtAmount.Text = "0.00";
            txtCash.Text = "0.00";
            txtCheque.Text = "0.00";
            txtChequeDetails.Text = "";
            txtDD.Text = "0.00";
            txtDDDetails.Text = "";
            txtRemark.Text = "";
            txtTransfer.Text = "0.00";
            txtTransferDetails.Text = "";
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            frmEditCashOut feco = new frmEditCashOut();
            feco.Show();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                    using (SqlConnection conn = new SqlConnection(connString))
                    {
                        conn.Open();
                        string qry = string.Empty;
                        qry = "DELETE FROM CashOut WHERE id = " + id.ToString();
                        SqlCommand cmd = new SqlCommand(qry, conn);
                        cmd.ExecuteNonQuery();
                        conn.Close();
                        MessageBox.Show("User Deleted");
                    }
                    clear();
                    id = 0;
                }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        }
    }

