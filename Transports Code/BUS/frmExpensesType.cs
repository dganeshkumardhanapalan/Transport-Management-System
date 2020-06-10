using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace BUS
{
    public partial class frmExpensesType : Form
    {
        int id = 0;
        public frmExpensesType()
        {
            InitializeComponent();
        }
        string connstring = System.Configuration.ConfigurationManager.ConnectionStrings["BUS"].ConnectionString.ToString();
        
        private void btSave_Click(object sender, EventArgs e)
        {
                string connstring = System.Configuration.ConfigurationManager.ConnectionStrings["BUS"].ConnectionString.ToString();
                string qry = string.Empty;
                SqlConnection con1 = new SqlConnection(connstring);
                qry = "select id,ExpenseType from ExpenseTypeMaster where ExpenseType='" + txtExpenseType.Text + "'";
                SqlDataAdapter da = new SqlDataAdapter(qry, con1);
                DataSet ds = new DataSet();
                da.Fill(ds);
                con1.Close();
                int rowcount = ds.Tables[0].Rows.Count;
                if (rowcount > 0)
                {
                    MessageBox.Show("Expense Type Already Exists");
                    return;
                }

                    using (SqlConnection conn = new SqlConnection(connstring))
                    {
                        conn.Open();
                        string qry1 = string.Empty;
                        if (id == 0)
                        {
                            qry1 = "INSERT INTO ExpenseTypeMaster VALUES('" + txtExpenseType.Text + "')";
                        }
                        else
                        {
                            qry1 = "UPDATE ExpenseTypeMaster"
                                    + " SET "
                                    + " [ExpenseType] = '" + txtExpenseType.Text + "'"
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
            txtExpenseType.Text = "";
        }
        private void loadGrid()
        {
            try
            {
                string connstring = System.Configuration.ConfigurationManager.ConnectionStrings["BUS"].ConnectionString.ToString();
                using (SqlConnection conn = new SqlConnection(connstring))
                {
                    conn.Open();
                    string qry = "select Id,ExpenseType as [Expense Type] FROM ExpenseTypeMaster";

                    SqlDataAdapter da = new SqlDataAdapter(qry, conn);
                    DataSet ds = new DataSet();
                    da.Fill(ds);
                    conn.Close();
                    int rowcount = ds.Tables[0].Rows.Count;
                    if (rowcount > 0)
                    {
                        gvDetails.DataSource = ds.Tables[0];
                        gvDetails.Columns[0].Visible = false;
                    }
                    else
                    {
                        gvDetails.DataSource = null;
                    }
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void frmExpensesType_Load(object sender, EventArgs e)
        {
            loadGrid();
        }

        private void btDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (id > 0)
                {
                    
                    using (SqlConnection conn = new SqlConnection(connstring))
                    {
                        conn.Open();
                        string qry = string.Empty;
                        qry = "DELETE FROM ExpenseTypeMaster WHERE id = " + id.ToString();
                        SqlCommand cmd = new SqlCommand(qry, conn);
                        cmd.ExecuteNonQuery();
                        conn.Close();
                        MessageBox.Show("Selected Item Deleted");
                    }
                    loadGrid();
                    clear();
                    //btDelete.Enabled = false;
                    id = 0;
                }
                else
                {
                    MessageBox.Show("Select ExpenseType Details");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }

        }

        private void gvDetails_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {

                int ri = e.RowIndex;
                id = Convert.ToInt16(gvDetails.Rows[ri].Cells[0].Value.ToString());
                string connstring = System.Configuration.ConfigurationManager.ConnectionStrings["BUS"].ConnectionString.ToString();
                using (SqlConnection conn = new SqlConnection(connstring))
                {
                    conn.Open();
                    string qry = "select * FROM ExpenseTypeMaster WHERE id = '" + id + "'";
                    SqlDataAdapter da = new SqlDataAdapter(qry, conn);
                    DataSet ds = new DataSet();
                    da.Fill(ds);
                    conn.Close();
                    int rowcount = ds.Tables[0].Rows.Count;
                    if (rowcount > 0)
                    {
                        txtExpenseType.Text = ds.Tables[0].Rows[0]["ExpenseType"].ToString();
                        
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }

        }

        private void btClear_Click(object sender, EventArgs e)
        {
            clear();
        }
        }
    }