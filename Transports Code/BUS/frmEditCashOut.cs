using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;

namespace BUS
{
    public partial class frmEditCashOut : Form
    {
        static int id;
        public frmEditCashOut()
        {
            InitializeComponent();
        }
        string connstring = System.Configuration.ConfigurationManager.ConnectionStrings["BUS"].ConnectionString.ToString();
        private void frmEditCashOut_Load(object sender, EventArgs e)
        {
            loadSupplier();
        }
        public void loadSupplier()
        {
            cbSupplier.Items.Clear();
            SqlConnection conn = new SqlConnection(connstring);
            conn.Open();
            string qry = "select '0' as Id,'--All Suppliers--' AS Name union select Id,Name FROM Supplier";
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

        private void BlindData()
        {
            if (cbSupplier.SelectedIndex == 0)
            {
                SqlConnection conn = new SqlConnection(connstring);
                conn.Open();
                string qry = "select Co.Id,s.Name as [Supplier],CO.Date,CO.TotalAmount,Co.Cash,CO.Cheque,CO.ChequeDate,CO.ChequeDetails,CO.DD,CO.DDdate,CO.DDdetails,Co.Transfer,CO.TransferDate,Co.TransferDetails,co.Remark  FROM CashOut CO inner join Supplier s on s.Id=CO.SupplierId WHERE Date between '" + dtpFromDate.Value.ToString("yyyy'-'MM'-'dd") + "' AND '" + dtpToDate.Value.ToString("yyyy'-'MM'-'dd") + "' order by Date";
                SqlDataAdapter da = new SqlDataAdapter(qry, conn);
                DataSet ds = new DataSet();
                da.Fill(ds);
                conn.Close();
                gvDetails.DataSource = ds.Tables[0];
                gvDetails.Columns[0].Visible = false;
            }
            else
            {
                SqlConnection conn = new SqlConnection(connstring);
                conn.Open();
                string qry = "select co.Id,s.Name as [Supplier],CO.Date,CO.TotalAmount,Co.Cash,CO.Cheque,CO.ChequeDate,CO.ChequeDetails,CO.DD,CO.DDdate,CO.DDdetails,Co.Transfer,CO.TransferDate,Co.TransferDetails,co.Remark  FROM CashOut CO inner join Supplier s on s.Id=CO.SupplierId WHERE supplierId='" + cbSupplier.SelectedValue + "' INTERSECT select co.Id,s.Name, CO.Date,CO.TotalAmount,Co.Cash,CO.Cheque,CO.ChequeDate,CO.ChequeDetails,CO.DD,CO.DDdate,CO.DDdetails,Co.Transfer,CO.TransferDate,Co.TransferDetails,co.Remark FROM CashOut CO inner join Supplier s on s.Id=CO.SupplierId WHERE Date between '" + dtpFromDate.Value.ToString("yyyy'-'MM'-'dd") + "' AND '" + dtpToDate.Value.ToString("yyyy'-'MM'-'dd") + "' order by Date";
                SqlDataAdapter da = new SqlDataAdapter(qry, conn);
                DataSet ds = new DataSet();
                da.Fill(ds);
                conn.Close();
                gvDetails.DataSource = ds.Tables[0];
                gvDetails.Columns[0].Visible = false;
                
            }
        }
        private void btnSearch_Click(object sender, EventArgs e)
        {
            BlindData();
        }

        private void gvDetails_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            id = Convert.ToInt32(gvDetails.Rows[e.RowIndex].Cells[0].Value);
            frmCashOut cashout = new frmCashOut(id);
            cashout.Show();
            this.Close();
        }
      }
}