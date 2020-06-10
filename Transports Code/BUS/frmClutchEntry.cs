using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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
    public partial class frmClutchEntry : Form
    {
        int selectid = 0;
        public frmClutchEntry()
        {
            InitializeComponent();
        }

        private void frmClutchEntry_Load(object sender, EventArgs e)
        {
            LoadCombo();
            clearOperation();
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
        void clearOperation()
        {
            cbbusname.SelectedIndex = 0;
            tbmanu.Text = "";
            tbamount.Text = "0.00";
            tbremark.Text = "";
            dtpdate.Value = DateTime.Now;
            btsave.Enabled = true;

        }
        private void BlindData()
        {
            string connstring = System.Configuration.ConfigurationManager.ConnectionStrings["BUS"].ConnectionString.ToString();
            SqlConnection conn = new SqlConnection(connstring);
            conn.Open();
            string qry = "SELECT W.Id,B.Name,km,W.Date,W.Manufacturer,W.Amount,W.Remark "
                            + "FROM ClutchData W "
                            + "INNER JOIN BusMaster B "
                            + "ON W.BusId=B.Id "
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
        }

        private void btcancel_Click(object sender, EventArgs e)
        {
            clearOperation();
            cbbusname.Enabled = true;
        }

        private void cbbusname_SelectedIndexChanged(object sender, EventArgs e)
        {
            BlindData();
        }

        private void btsave_Click(object sender, EventArgs e)
        {
            if (tbmanu.Text != "" && tbamount.Text != "" && cbbusname.SelectedItem.ToString() != "-Select-" && tbkm.Text !="")
            {
                try
                {
                    string connstring = System.Configuration.ConfigurationManager.ConnectionStrings["BUS"].ConnectionString.ToString();
                    SqlConnection conn = new SqlConnection(connstring);
                    conn.Open();
                    string qry = "";

                    if (selectid == 0)
                    {
                        qry = "INSERT INTO ClutchData ( BusId,km,Date,Manufacturer,Amount,Remark) Select id as BusId,'" + tbkm.Text + "' as km,'" + dtpdate.Value.ToString("yyyy-MM-dd") + "','" + tbmanu.Text + "' as Manufacturer,'" + tbamount.Text + "' as Amount,'" + tbremark.Text + "' as Remark from BusMaster where Name='" + cbbusname.SelectedItem.ToString() + "'";
                    }
                    else
                    {
                        qry = "UPDATE ClutchData"
                                   + " SET BusId = BusId"
                                   + " ,km = "+tbkm.Text
                                   + " ,Date = " + dtpdate.Text
                                   + " ,Manufacturer = '" + tbmanu.Text
                                   + "' ,Amount = '" + tbamount.Text
                                   + "' ,Remark = '" + tbremark.Text
                                   + "' From ClutchData W"
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
                        cbbusname.Enabled = true;
                    }
                    else
                    {
                        MessageBox.Show("Update Successfully");
                        cbbusname.Enabled = true;
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
                MessageBox.Show("Please Fill required data");
            }

        }

        private void btdelete_Click(object sender, EventArgs e)
        {
            if (selectid > 0)
            {
                try
                {
                    string connstring = System.Configuration.ConfigurationManager.ConnectionStrings["BUS"].ConnectionString.ToString();
                    SqlConnection conn = new SqlConnection(connstring);
                    conn.Open();
                    string qry = "";
                    qry = "Delete From ClutchData"
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

        private void gvData_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            selectid = Convert.ToInt32(gvData.Rows[e.RowIndex].Cells[0].Value);

            cbbusname.Text = gvData.Rows[e.RowIndex].Cells[1].Value.ToString();
            tbkm.Text = gvData.Rows[e.RowIndex].Cells[2].Value.ToString();
            tbmanu.Text = gvData.Rows[e.RowIndex].Cells[4].Value.ToString();
            tbamount.Text = gvData.Rows[e.RowIndex].Cells[5].Value.ToString();
            tbremark.Text = gvData.Rows[e.RowIndex].Cells[6].Value.ToString();
            if (!General.Is_Edit)
                btsave.Enabled = false;
            else
                btsave.Enabled = true;

            if (!General.Is_Delete)
                btdelete.Enabled = false;
            else
                btdelete.Enabled = true;
            btcancel.Enabled = true;
            cbbusname.Enabled = false;
        }

        private void tbamount_KeyPress(object sender, KeyPressEventArgs e)
        {
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
    }
}
