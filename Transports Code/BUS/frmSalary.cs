using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Configuration;
using System.Windows.Forms;

namespace BUS
{
    public partial class frmSalary : Form
    {
        int id = 0;
        
        public frmSalary()
        {
            InitializeComponent();
        }

        private void frmSalary_Load(object sender, EventArgs e)
        {
            load_Bus();
            loadGrid();
            load_Department();
            loadEmp();
        }
        private void load_Bus()
        {
            string connstring = System.Configuration.ConfigurationManager.ConnectionStrings["BUS"].ConnectionString.ToString();
            SqlConnection conn = new SqlConnection(connstring);
            conn.Open();
            string qry = "Select '0' As Id, '--Select Bus--' As Name Union Select Id,Name from BusMaster Order By Id";
            SqlCommand cmd = new SqlCommand(qry, conn);
            DataSet ds = new DataSet();
            SqlDataAdapter sdr = new SqlDataAdapter(cmd);
            sdr.Fill(ds);
            conn.Close();
            int rowcount = ds.Tables[0].Rows.Count;
            if (rowcount > 0)
            {
                cbBus.DataSource = ds.Tables[0];
                cbBus.ValueMember = "Id";
                cbBus.DisplayMember = "Name";
            }
            else
            {
                cbBus.DataSource = null;
                cbBus.Items.Clear();
            }
        }
        private void loadEmp()
        {
            cbEmp.Items.Clear();
            string connstring = System.Configuration.ConfigurationManager.ConnectionStrings["BUS"].ConnectionString.ToString();
            SqlConnection conn = new SqlConnection(connstring);
            conn.Open();
            string qry = "select '0' as Id,'--Select Employee--' AS Name union select Id, Name from EmployeeMaster order by id";
            SqlDataAdapter da = new SqlDataAdapter(qry, conn);
            DataSet ds = new DataSet();
            da.Fill(ds);
            conn.Close();
            int rowcount = ds.Tables[0].Rows.Count;
            if (rowcount == 0)
            {
                MessageBox.Show("No Department Record Found");
            }
            else
            {
                cbEmp.DataSource = ds.Tables[0];
                cbEmp.ValueMember = "Id";
                cbEmp.DisplayMember = "Name";
                cbEmp.SelectedIndex = 0;
            }
        }

        private void load_Department()
        {
            cbDpt.Items.Clear();
            string connstring = System.Configuration.ConfigurationManager.ConnectionStrings["BUS"].ConnectionString.ToString();
            SqlConnection conn = new SqlConnection(connstring);
            conn.Open();
            string qry = "select '--Select Department--' as Department union Select DISTINCT Department from EmployeeMaster order by Department desc";
            SqlDataAdapter da = new SqlDataAdapter(qry, conn);
            DataSet ds = new DataSet();
            da.Fill(ds);
            conn.Close();
            int rowcount = ds.Tables[0].Rows.Count;
            if (rowcount == 0)
            {
                MessageBox.Show("No Department Record Found");
            }
            else
            {
                for (int count = 0; count < rowcount; count++)
                {
                    cbDpt.Items.Insert(count, Convert.ToString(ds.Tables[0].Rows[count]["Department"]).Trim());
                }
                cbDpt.SelectedIndex = 0;
            }
        }

        private void cbDpt_SelectionChangeCommitted(object sender, EventArgs e)
        {
            
            string connstring = System.Configuration.ConfigurationManager.ConnectionStrings["BUS"].ConnectionString.ToString();
            SqlConnection conn = new SqlConnection(connstring);
            conn.Open();
            string qry = "select Id,Name from  EmployeeMaster Where Department='"+cbDpt.SelectedItem+"'";
            SqlDataAdapter da = new SqlDataAdapter(qry, conn);
            DataSet ds = new DataSet();
            da.Fill(ds);
            conn.Close();
            int rowcount = ds.Tables[0].Rows.Count;
            if (rowcount == 0)
            {
                MessageBox.Show("No Name Record Found");
            }
            else
            {
                cbEmp.DataSource = ds.Tables[0];
                cbEmp.ValueMember = "Id";
                cbEmp.DisplayMember = "Name";
                cbEmp.SelectedIndex = 0;
            }
        }


        private bool isPaid()
        {
             string connstring = System.Configuration.ConfigurationManager.ConnectionStrings["BUS"].ConnectionString.ToString();
            SqlConnection conn = new SqlConnection(connstring);
            conn.Open();
            string qry = "select * from salary where BusId = '"+cbBus.SelectedValue+"' and Employeeid='" + cbEmp.SelectedValue + "' and SalaryValidity>'"
                    + dtpdate.Value.ToString("yyyy-MM-dd") + "'";
            SqlDataAdapter da = new SqlDataAdapter(qry, conn);
            DataSet ds = new DataSet();
            da.Fill(ds);
            conn.Close();
            int rowcount = ds.Tables[0].Rows.Count;
            if (rowcount == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(cbDpt.SelectedIndex==0)
            {
                MessageBox.Show("Please Select Department");
                return;
            }
            if(cbBus.SelectedIndex == 0)
            {
                MessageBox.Show("Select Bus Name");
            }
            else
            {
                if (isPaid() == false)
                {
                    MessageBox.Show("Salary Paid for this month");
                    return;
                }
            
                string qry1 = string.Empty;

                if (id == 0)
                {
                    qry1 = "INSERT INTO Salary VALUES('" + cbDpt.SelectedItem.ToString()
      + "','"
                         + cbEmp.SelectedValue
                         + "','"
                         + dtpdate.Value.ToString("yyyy-MM-dd")
                         + "','"
                         + txtSalary.Text
                         + "'," + "DATEADD(Month, 1,'"
                         + dtpdate.Value.ToString("yyyy-MM-dd")
                         + "')" + ","
                                 + 1
                                 + ","
                                 + "GetDate()"
                                 + ","
                                 + 1
                                 + ","
                                 + "GetDate()"
                                 + ",'" + cbBus.SelectedValue + "')";
                    string connstring = System.Configuration.ConfigurationManager.ConnectionStrings["BUS"].ConnectionString.ToString();
                    SqlConnection conn = new SqlConnection(connstring);
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(qry1, conn);
                    cmd.ExecuteNonQuery();
                    conn.Close();
                    MessageBox.Show("Save Successfully");
                    loadGrid();
                }
                else
                {
                    qry1 = "UPDATE Salary"
                            + " SET "
                            + " [Department] = '" + cbDpt.SelectedItem.ToString() + "',"
                            + " [BusId] = '" + cbBus.SelectedValue + "',"
                             + " [EmployeeId] = '" + cbEmp.SelectedValue + "',"
                             + " [SalaryDate] = '" + dtpdate.Value.ToString("yyyy-MM-dd") + "',"
                             + " [Salary] = '" + txtSalary.Text + "',"
                             + " [ModifiedBy] = 1,"
                             + " [ModifiedDate] = GETDATE()"

                             //Other details logo, modifieddate etc has to be updated

                            + " WHERE"
                             + " [Id] = '" + id.ToString() + "'";
                    string connstring = System.Configuration.ConfigurationManager.ConnectionStrings["BUS"].ConnectionString.ToString();
                    SqlConnection conn = new SqlConnection(connstring);
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(qry1, conn);
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
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
                    string qry = string.Empty;

                    qry = "SELECT S.Id,EM.Name,B.Name as BusName,S.Department,S.SalaryDate,S.Salary FROM Salary S INNER JOIN [BusMaster] B WITH(NOLOCK) ON B.Id = S.BusId INNER JOIN [EmployeeMaster] EM WITH(NOLOCK) ON EM.Id = S.EmployeeId";
                    
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

        private void gvdetails_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
             try
            {
                int ri = e.RowIndex;
                 id = Convert.ToInt16(gvdetails.Rows[ri].Cells[0].Value.ToString());
                string connstring = System.Configuration.ConfigurationManager.ConnectionStrings["BUS"].ConnectionString.ToString();
                using (SqlConnection conn = new SqlConnection(connstring))
                {
                    
                    conn.Open();
                    string qry = "select Department,BusId,EmployeeId,SalaryDate,Salary FROM Salary WHERE id = '" + id + "'";
                    SqlDataAdapter da = new SqlDataAdapter(qry, conn);
                    DataSet ds = new DataSet();
                    da.Fill(ds);
                    conn.Close();
                    int rowcount = ds.Tables[0].Rows.Count;
                    if (rowcount > 0)
                    {
                        cbDpt.Text = ds.Tables[0].Rows[0]["Department"].ToString();
                        cbBus.SelectedValue = ds.Tables[0].Rows[0]["BusId"];
                        cbEmp.SelectedValue = ds.Tables[0].Rows[0]["EmployeeId"];
                        dtpdate.Text = ds.Tables[0].Rows[0]["SalaryDate"].ToString();
                        txtSalary.Text = ds.Tables[0].Rows[0]["Salary"].ToString();
                        
                    }
                }
               
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string connstring = System.Configuration.ConfigurationManager.ConnectionStrings["BUS"].ConnectionString.ToString();
            SqlConnection conn = new SqlConnection(connstring);
            conn.Open();
            string qry = "Delete FROM Salary WHERE id = '" + id + "'";
            SqlDataAdapter da = new SqlDataAdapter(qry, conn);
            DataSet ds = new DataSet();
            da.Fill(ds);
            conn.Close();
            MessageBox.Show("Selected Item Deleted");
            loadGrid();
            clear();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            clear();
        }
        public void clear()
        {
            cbDpt.SelectedIndex = 0;
            cbEmp.SelectedIndex = 0;
            cbBus.SelectedIndex = 0;
            cbEmp.SelectedIndex = 0;
            txtSalary.Text = "";
        }

        private void txtSalary_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }

    }
}