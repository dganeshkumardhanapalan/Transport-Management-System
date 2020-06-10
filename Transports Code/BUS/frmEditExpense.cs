using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace BUS
{
    public partial class frmEditExpense : Form
    {
        string connstring = System.Configuration.ConfigurationManager.ConnectionStrings["BUS"].ConnectionString.ToString();
        public frmEditExpense()
        {
            InitializeComponent();
        }

        private void frmEditExpense_Load(object sender, EventArgs e)
        {
            load_Suppliers();
        }
        private void load_Suppliers()
        {
            SqlConnection conn = new SqlConnection(connstring);
            conn.Open();
            string qry = " Select '0' As Id,'--All Supplier--' AS Name Union Select Id,Name from Supplier";
            SqlCommand cmd = new SqlCommand(qry, conn);
            DataSet ds = new DataSet();
            SqlDataAdapter sdr = new SqlDataAdapter(cmd);
            sdr.Fill(ds);
            conn.Close();
            int rowcount = ds.Tables[0].Rows.Count;
            if (rowcount > 0)
            {
                cbSupplier.DataSource = ds.Tables[0];
                cbSupplier.ValueMember = "Id";
                cbSupplier.DisplayMember = "Name";
            }
            else
            {
                cbSupplier.DataSource = null;
                cbSupplier.Items.Clear();
            }
        }
      
        private void btnLoad_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt16(cbSupplier.SelectedValue) == 0)
            {

                SqlConnection conn = new SqlConnection(connstring);
                conn.Open();
                string qry = "Select EM.Id,BM.Name,ETM.ExpenseType,S.Name,EM.Date,EM.TotalAmount,EM.Cash,EM.Credit,EM.Cheque,EM.ChequeDate,EM.DemandDraft,EM.DDDate," +
                " EM.Transfer,EM.TransferDate From ExpenseMaster EM" +
                " INNER JOIN [ExpenseTypeMaster] ETM ON ETM.Id=EM.ExpenseTypeId" +
                " INNER JOIN BusMaster BM ON BM.Id = EM.BusId" +
                " INNER JOIN [Supplier] S ON S.Id=EM.SupplierId where Date between '" + dtpFromDate.Value.ToString("yyyy'-'MM'-'dd") + "' and '" + dtpToDate.Value.ToString("yyyy'-'MM'-'dd") + "'";

                SqlCommand cmd = new SqlCommand(qry, conn);
                //cmd.Parameters.Add(new SqlParameter("@SupplierId", cbSupplier.SelectedValue));
                //cmd.Parameters.Add(new SqlParameter("@FromDate", dtpFromDate.Text));
                //cmd.Parameters.Add(new SqlParameter("@ToDate", dtpToDate.Text));
                DataSet ds = new DataSet();
                SqlDataAdapter sdr = new SqlDataAdapter(cmd);
                sdr.Fill(ds);
                int rowcount = ds.Tables[0].Rows.Count;
                if (rowcount > 0)
                {
                    gvDetails.DataSource = ds.Tables[0];
                    gvDetails.Columns[0].Visible = false;
                    //gvDetails.DataSource=DataBind();             
                }
                else
                {
                    gvDetails.DataSource = null;
                }
            }
            else
            {

                SqlConnection conn = new SqlConnection(connstring);
                conn.Open();
                string qry = "Select EM.Id,BM.Name,ETM.ExpenseType,S.Name,EM.Date,EM.TotalAmount,EM.Cash,EM.Credit,EM.Cheque,EM.ChequeDate,EM.DemandDraft,EM.DDDate," +
                " EM.Transfer,EM.TransferDate From ExpenseMaster EM" +
                " INNER JOIN [ExpenseTypeMaster] ETM ON ETM.Id=EM.ExpenseTypeId" +
                " INNER JOIN BusMaster BM ON BM.Id = EM.BusId" +
                " INNER JOIN [Supplier] S ON S.Id=EM.SupplierId where SupplierId='" + cbSupplier.SelectedValue + "' and date between '" + dtpFromDate.Value.ToString("yyyy'-'MM'-'dd") + "' and '" + dtpToDate.Value.ToString("yyyy'-'MM'-'dd") + "'";

                SqlCommand cmd = new SqlCommand(qry, conn);
                //cmd.Parameters.Add(new SqlParameter("@SupplierId", cbSupplier.SelectedValue));
                //cmd.Parameters.Add(new SqlParameter("@FromDate", dtpFromDate.Text));
                //cmd.Parameters.Add(new SqlParameter("@ToDate", dtpToDate.Text));
                DataSet ds = new DataSet();
                SqlDataAdapter sdr = new SqlDataAdapter(cmd);
                sdr.Fill(ds);
                int rowcount = ds.Tables[0].Rows.Count;
                if (rowcount > 0)
                {
                    gvDetails.DataSource = ds.Tables[0];
                    gvDetails.Columns[0].Visible = false;
                    //gvDetails.DataSource=DataBind();             
                }
                else
                {
                    gvDetails.DataSource = null;
                }
            }
        }

        private void gvDetails_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
          int id = Convert.ToInt32(gvDetails.Rows[e.RowIndex].Cells[0].Value);
          frmExpenseMaster expense = new frmExpenseMaster(id);
          this.Close();
          expense.Show();
        }

    }
}
