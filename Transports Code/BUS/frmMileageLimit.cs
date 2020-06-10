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
    public partial class frmMileageLimit : Form
    {
        int selectid = 0;
        public frmMileageLimit()
        {
            InitializeComponent();
        }

        private void frmMileageLimit_Load(object sender, EventArgs e)
        {
            LoadCombo();
            clearOperation();
        }

        void clearOperation()
        {
            cbbusname.SelectedIndex = 0;
            cbdepartment.SelectedIndex = 0;
            tbUpper.Text = "0.00";
            tbLower.Text = "0.00";
            tbBonus.Text = "0.00";
            btSave.Enabled = true;
            btDelete.Enabled = false;
            btCancel.Enabled = true;
            cbbusname.Enabled = true;
            cbdepartment.Enabled = true;
            selectid = 0;
        }

        private void BlindData()
        {
            string connstring = System.Configuration.ConfigurationManager.ConnectionStrings["BUS"].ConnectionString.ToString();
            SqlConnection conn = new SqlConnection(connstring);
            conn.Open();
            //string qry = "SELECT M.id,B.Name,M.MileageLower,M.MileageUpper,M.Bonus,M.Department "
            //                + "FROM MileageLimit M "
            //                + "INNER JOIN BusMaster B "
            //                + "ON M.BusId=B.Id "
            //                + "WHERE B.Name='" + cbbusname.SelectedItem.ToString() + "' AND M.Department='"+cbdepartment.SelectedItem.ToString()+"'";
            string qry = "SELECT M.id,B.Name,M.MileageLower,M.MileageUpper,M.Bonus "
                            + "FROM MileageLimit M "
                            + "INNER JOIN BusMaster B "
                            + "ON M.BusId=B.Id "
                            + "WHERE B.Name='" + cbbusname.SelectedItem.ToString() + "'";

            SqlDataAdapter da = new SqlDataAdapter(qry, conn);
            DataSet ds = new DataSet();
            da.Fill(ds);
            conn.Close();

            gvData.DataSource = ds.Tables[0].DefaultView;
        }

        void LoadCombo()
        {
            cbbusname.Items.Clear();
            string connstring = System.Configuration.ConfigurationManager.ConnectionStrings["BUS"].ConnectionString.ToString();
            SqlConnection conn = new SqlConnection(connstring);
            conn.Open();
            string qry = "select Name,id FROM BusMaster UNION ALL Select '-Select-' as Name, 0 as id order by id";
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
            cbdepartment.SelectedIndex = 0;
        }

        private void btSave_Click(object sender, EventArgs e)
        {
            if (tbLower.Text != "" && tbUpper.Text != "" && tbBonus.Text != "" && cbbusname.SelectedItem.ToString() != "-Select-" && cbdepartment.SelectedItem.ToString() != "-Select-") 
            {
                if (Convert.ToDouble(tbUpper.Text) > Convert.ToDouble(tbLower.Text))
                {

                    try
                    {
                        string connstring = System.Configuration.ConfigurationManager.ConnectionStrings["BUS"].ConnectionString.ToString();
                        SqlConnection conn = new SqlConnection(connstring);
                        conn.Open();
                        string qry = "";

                        if (selectid == 0)
                        {
                            qry = "INSERT INTO MileageLimit (BusId ,MileageLower ,MileageUpper,Bonus,Department) Select id as BusId,'" + tbLower.Text + "' as MileageLower,'" + tbUpper.Text + "' as MileageUpper,'" + tbBonus.Text + "' as Bonus,'" + cbdepartment.SelectedItem.ToString() + "' as Department from BusMaster where Name='" + cbbusname.SelectedItem.ToString() + "'";
                        }
                        else
                        {
                            qry = "UPDATE MileageLimit"
                                       + " SET BusId = BusId"
                                       + " ,MileageLower = " + tbLower.Text
                                       + " ,MileageUpper = " + tbUpper.Text
                                       + " ,Bonus = " + tbBonus.Text
                                       + " ,Department = '" + cbdepartment.SelectedItem.ToString()+"'"
                                       + " From MileageLimit W"
                                       + " INNER JOIN BusMaster B ON W.BusId = B.Id"
                                       + " WHERE W.id=" + selectid;
                        }
                        SqlCommand cmd = new SqlCommand(qry, conn);
                        cmd.ExecuteNonQuery();
                        conn.Close();
                        clearOperation();
                        if (selectid == 0)
                        {
                            MessageBox.Show("Save Successfully");
                            
                        }
                        else
                        {
                            MessageBox.Show("Update Successfully");
                            
                        }
                    }
                    catch (Exception ex)
                    {
                        if (ex.Message.IndexOf("IX_CollectionMaster") > 0)
                        {
                            MessageBox.Show("Error Message");
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Lower Limit is Higher then Upper Limit");
                }
            }
            else
            {
                MessageBox.Show("Please Fill required data");
            }

        }

        private void tbLower_TextChanged(object sender, EventArgs e)
        {
            if (tbLower.Text != "")
            {

            }
            else
            {
                tbLower.Text = "0.00";
                tbLower.SelectionStart = 0;
                tbLower.SelectionLength = tbLower.Text.Length;

            }
        }

        private void tbUpper_TextChanged(object sender, EventArgs e)
        {
            if (tbUpper.Text != "")
            {

            }
            else
            {
                tbUpper.Text = "0.00";
                tbUpper.SelectionStart = 0;
                tbUpper.SelectionLength = tbUpper.Text.Length;

            }
        }

        private void tbBonus_TextChanged(object sender, EventArgs e)
        {
            if (tbBonus.Text != "")
            {

            }
            else
            {
                tbBonus.Text = "0.00";
                tbBonus.SelectionStart = 0;
                tbBonus.SelectionLength = tbBonus.Text.Length;

            }
        }

        private void tbLower_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar.ToString() == "\r")
            {
                this.SelectNextControl(tbLower, true, true, true, true);
            }
        }

        private void tbUpper_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar.ToString() == "\r")
            {
                this.SelectNextControl(tbUpper, true, true, true, true);
            }
        }

        private void tbBonus_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar.ToString() == "\r")
            {
                this.SelectNextControl(tbBonus, true, true, true, true);
            }
        }

        private void tbLower_Leave(object sender, EventArgs e)
        {
            if (tbLower.Text != "")
            {
                tbLower.Text = Convert.ToDouble(tbLower.Text).ToString("F");
            }
            else
            {
                tbLower.Text = "0.00";
            }
        }

        private void tbUpper_Leave(object sender, EventArgs e)
        {
            if (tbUpper.Text != "")
            {
                tbUpper.Text = Convert.ToDouble(tbUpper.Text).ToString("F");
            }
            else
            {
                tbUpper.Text = "0.00";
            }
        }

        private void tbBonus_Leave(object sender, EventArgs e)
        {
            if (tbBonus.Text != "")
            {
                tbBonus.Text = Convert.ToDouble(tbBonus.Text).ToString("F");
            }
            else
            {
                tbBonus.Text = "0.00";
            }
        }

        private void cbbusname_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void gvData_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            selectid = Convert.ToInt32(gvData.Rows[e.RowIndex].Cells[0].Value);

            cbbusname.Text = gvData.Rows[e.RowIndex].Cells[1].Value.ToString();
            tbLower.Text = gvData.Rows[e.RowIndex].Cells[2].Value.ToString();
            tbUpper.Text = gvData.Rows[e.RowIndex].Cells[3].Value.ToString();
            tbBonus.Text = gvData.Rows[e.RowIndex].Cells[4].Value.ToString();
            if (General.Is_Delete)
                btDelete.Enabled = true;
            if (!General.Is_Edit)
                btSave.Enabled = false;
            else
                btSave.Enabled = true;
            btCancel.Enabled = true;
            cbbusname.Enabled = false;
            cbdepartment.Enabled = false;
        }

        private void btCancel_Click(object sender, EventArgs e)
        {
            clearOperation();
        }

        private void btDelete_Click(object sender, EventArgs e)
        {
            if (selectid > 0)
            {
                try
                {
                    string connstring = System.Configuration.ConfigurationManager.ConnectionStrings["BUS"].ConnectionString.ToString();
                    SqlConnection conn = new SqlConnection(connstring);
                    conn.Open();
                    string qry = "";
                    qry = "Delete From MileageLimit"
                               + " WHERE id=" + selectid;
                    SqlCommand cmd = new SqlCommand(qry, conn);
                    cmd.ExecuteNonQuery();
                    conn.Close();
                    clearOperation();
                    MessageBox.Show("Delete Successfully");
                }
                catch (Exception ex)
                {
                    if (ex.Message.IndexOf("IX_CollectionMaster") > 0)
                    {
                        MessageBox.Show("Error Message");
                    }
                }
            }
            else
            {
                MessageBox.Show("No Record Selected");
            }
        }

        private void cbdepartment_SelectedIndexChanged(object sender, EventArgs e)
        {
            BlindData();
        }

        
    }
}
