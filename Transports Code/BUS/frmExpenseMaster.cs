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
    public partial class frmExpenseMaster : Form
    {
        int id = 0;
        string connstring = System.Configuration.ConfigurationManager.ConnectionStrings["BUS"].ConnectionString.ToString();
        public frmExpenseMaster(int id)
        {
            InitializeComponent();
            this.id = id;
            if (id > 0)
            {
                load_Companyname();
                load_ExpenseType();
                load_Suppliers();
                load_Bus();
                //clear();
                setValues(id);
            }
        }
        private void frmExpenseMaster_Load(object sender, EventArgs e)
        {
            label20.ForeColor = Color.Red;
            label15.ForeColor = Color.Red;
            label16.ForeColor = Color.Red;
            label17.ForeColor = Color.Red;
            label18.ForeColor = Color.Red;
            if (id == 0)
            {
                load_Companyname();
                load_ExpenseType();
                load_Suppliers();
                load_Bus();
                clear();
                id = 0;               
            }      
        }
        private void btSave_Click(object sender, EventArgs e)
        {
            if(Convert.ToInt16(cbBus.SelectedValue)==0 || Convert.ToInt16(cbExpenseType.SelectedValue)==0 || Convert.ToInt16(cbSupplier.SelectedValue)==0)
            {
                MessageBox.Show("Some Required Fields Are Not Selected");
                return;
            }
            if(isAmountTally()==false)
            {
                MessageBox.Show("Pay Full Amount");
                return;
            }
            
            if (id > 0)
            {
                SqlConnection Conn = new SqlConnection(connstring);

                try
                {

                    Conn.Open();
                    SqlCommand cmd = new SqlCommand("Update ExpenseMaster set ExpenseTypeId=@ExpenseTypeId,"
                    + "SupplierId=@SupplierId,CompanyNameId=@CompanyNameId,BusId=@BusId,Date=@Date,TotalAmount=@TotalAmount,Cash=@Cash,Credit=@Credit,"
                    + "Cheque=@Cheque,ChequeDate=@ChequeDate,ChequeDetails=@ChequeDetails,DemandDraft=@DemandDraft,"
                    + " DDDate=@DDDate,DDDetails=@DDDetails,Transfer=@Transfer,TransferDate=@TransferDate,"
                    + " TransferDetails=@TransferDetails,Remark=Remark,ModifiedDate=Getdate() where id=@id", Conn);
                    cmd.Parameters.Add(new SqlParameter("@id", id));
                    cmd.Parameters.Add(new SqlParameter("@ExpenseTypeId", cbExpenseType.SelectedValue));
                    cmd.Parameters.Add(new SqlParameter("@SupplierId", cbSupplier.SelectedValue));
                    cmd.Parameters.Add(new SqlParameter("@CompanyNameId", cbCompany.SelectedValue));
                    cmd.Parameters.Add(new SqlParameter("@BusId", cbBus.SelectedValue));
                    cmd.Parameters.Add(new SqlParameter("@Date", dtpDate.Value.ToString("yyyy'-'MM'-'dd")));
                    cmd.Parameters.Add(new SqlParameter("@TotalAmount", txtTotalAmount.Text));
                    cmd.Parameters.Add(new SqlParameter("@Cash", txtCash.Text));
                    cmd.Parameters.Add(new SqlParameter("@Credit", txtCredit.Text));
                    cmd.Parameters.Add(new SqlParameter("@Cheque", txtCheque.Text));
                    cmd.Parameters.Add(new SqlParameter("@ChequeDate", dtpChequeDate.Value.ToString("yyyy'-'MM'-'dd")));
                    cmd.Parameters.Add(new SqlParameter("@ChequeDetails", txtChequeDetails.Text));
                    cmd.Parameters.Add(new SqlParameter("@DemandDraft", txtDD.Text));
                    cmd.Parameters.Add(new SqlParameter("@DDDate", dtpDDDate.Value.ToString("yyyy'-'MM'-'dd")));
                    cmd.Parameters.Add(new SqlParameter("@DDDetails", txtDDDetails.Text));
                    cmd.Parameters.Add(new SqlParameter("@Transfer", txtTransfer.Text));
                    cmd.Parameters.Add(new SqlParameter("@TransferDate", dtpTransferDate.Value.ToString("yyyy'-'MM'-'dd")));
                    cmd.Parameters.Add(new SqlParameter("@TransferDetails", txtTransferDetails.Text));
                    cmd.Parameters.Add(new SqlParameter("@Remark", txtRemark.Text));
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Updated successfully");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString(), "Not updated");
                }
                finally
                {
                    Conn.Close();
                    clear();
                    id = 0;
                }
            }
            else
            {

                SqlConnection Conn = new SqlConnection(connstring);

                try
                {

                    Conn.Open();
                    SqlCommand cmd = new SqlCommand("insert into ExpenseMaster values(@ExpenseTypeId,@SupplierId,@CompanyNameId,@BusId,@Date,@TotalAmount,@Cash,@Credit,@Cheque,@ChequeDate,"+
                     "@ChequeDetails,@DemandDraft,@DDDate,@DDDetails,@Transfer,@TransferDate,@TransferDetails,@Remark,1,getdate(),1,getdate())", Conn);

                    cmd.Parameters.Add(new SqlParameter("@ExpenseTypeId", cbExpenseType.SelectedValue));
                    cmd.Parameters.Add(new SqlParameter("@SupplierId", cbSupplier.SelectedValue));
                    cmd.Parameters.Add(new SqlParameter("@CompanyNameId", cbCompany.SelectedValue));
                    cmd.Parameters.Add(new SqlParameter("@BusId", cbBus.SelectedValue));
                    cmd.Parameters.Add(new SqlParameter("@Date", dtpDate.Value.ToString("yyyy'-'MM'-'dd")));
                    cmd.Parameters.Add(new SqlParameter("@TotalAmount", txtTotalAmount.Text));
                    cmd.Parameters.Add(new SqlParameter("@Cash", txtCash.Text));
                    cmd.Parameters.Add(new SqlParameter("@Credit", txtCredit.Text));
                    cmd.Parameters.Add(new SqlParameter("@Cheque", txtCheque.Text));
                    cmd.Parameters.Add(new SqlParameter("@ChequeDate", dtpChequeDate.Value.ToString("yyyy'-'MM'-'dd")));
                    cmd.Parameters.Add(new SqlParameter("@ChequeDetails", txtChequeDetails.Text));
                    cmd.Parameters.Add(new SqlParameter("@DemandDraft", txtDD.Text));
                    cmd.Parameters.Add(new SqlParameter("@DDDate", dtpDDDate.Value.ToString("yyyy'-'MM'-'dd")));
                    cmd.Parameters.Add(new SqlParameter("@DDDetails", txtDDDetails.Text));
                    cmd.Parameters.Add(new SqlParameter("@Transfer", txtTransfer.Text));
                    cmd.Parameters.Add(new SqlParameter("@TransferDate", dtpTransferDate.Value.ToString("yyyy'-'MM'-'dd")));
                    cmd.Parameters.Add(new SqlParameter("@TransferDetails", txtTransferDetails.Text));
                    cmd.Parameters.Add(new SqlParameter("@Remark", txtRemark.Text));

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Saved successfully");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString() + "Not Saved");
                }
                finally
                {
                    Conn.Close();
                    clear();
                    id = 0;
                }
            }

        }

        private void btEdit_Click(object sender, EventArgs e)
        {
            frmEditExpense edit = new frmEditExpense();
            edit.Show();
        }
      
        private void btClear_Click(object sender, EventArgs e)
        {
            id = 0;
            clear();
        }
        private void btCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void setValues(int _updateId)
        {
          
            id = _updateId;
            SqlConnection conn = new SqlConnection(connstring);
            conn.Open();
            string qry = "Select Id,ExpenseTypeId,SupplierId,CompanyNameId,BusId,Convert(nvarchar,Date,105) AS Date,TotalAmount,"+
            "Cash,Credit,Cheque,Convert(nvarchar,ChequeDate,105) AS ChequeDate,ChequeDetails,DemandDraft,"+
            " Convert(nvarchar,DDDate,105) AS DDDate,DDDetails,Transfer,Convert(nvarchar,TransferDate,105) AS TransferDate,"+
            "TransferDetails,Remark From ExpenseMaster Where Id=@id";
            SqlCommand cmd = new SqlCommand(qry, conn);
            cmd.Parameters.Add(new SqlParameter("@Id", id));
            DataSet ds = new DataSet();
            SqlDataAdapter sdr = new SqlDataAdapter(cmd);
            sdr.Fill(ds);
            conn.Close();
            cbExpenseType.SelectedValue = ds.Tables[0].Rows[0]["ExpenseTypeId"].ToString();
            cbSupplier.SelectedValue = ds.Tables[0].Rows[0]["SupplierId"].ToString();
            cbCompany.SelectedValue = ds.Tables[0].Rows[0]["CompanyNameId"].ToString();
            cbBus.SelectedValue = ds.Tables[0].Rows[0]["BusId"].ToString();
            dtpDate.Text = ds.Tables[0].Rows[0]["Date"].ToString();
            txtTotalAmount.Text = ds.Tables[0].Rows[0]["TotalAmount"].ToString();
            txtCash.Text = ds.Tables[0].Rows[0]["Cash"].ToString();
            txtCredit.Text = ds.Tables[0].Rows[0]["Credit"].ToString();
            txtCheque.Text = ds.Tables[0].Rows[0]["Cheque"].ToString();
            dtpChequeDate.Text = ds.Tables[0].Rows[0]["ChequeDate"].ToString();
            txtChequeDetails.Text = ds.Tables[0].Rows[0]["ChequeDetails"].ToString();
            txtDD.Text = ds.Tables[0].Rows[0]["DemandDraft"].ToString();
            dtpDDDate.Text = ds.Tables[0].Rows[0]["DDDate"].ToString();
            txtDDDetails.Text = ds.Tables[0].Rows[0]["DDDetails"].ToString();
            txtTransfer.Text = ds.Tables[0].Rows[0]["Transfer"].ToString();
            dtpTransferDate.Text = ds.Tables[0].Rows[0]["TransferDate"].ToString();
            txtTransferDetails.Text = ds.Tables[0].Rows[0]["TransferDetails"].ToString();
            txtRemark.Text = ds.Tables[0].Rows[0]["Remark"].ToString();
          
        }

 
        private void load_ExpenseType()
        {
            SqlConnection conn = new SqlConnection(connstring);
            conn.Open();
            string qry = "Select '0' As Id, '--Select ExpenseType--' As ExpenseType Union Select Id,ExpenseType from ExpenseTypeMaster  Order By Id";
            SqlCommand cmd = new SqlCommand(qry, conn);
            DataSet ds = new DataSet();
            SqlDataAdapter sdr = new SqlDataAdapter(cmd);
            sdr.Fill(ds);
            conn.Close();
            int rowcount = ds.Tables[0].Rows.Count;
            if (rowcount > 0)
            {
                cbExpenseType.DataSource = ds.Tables[0];
                cbExpenseType.ValueMember = "Id";
                cbExpenseType.DisplayMember = "ExpenseType";
            }
            else
            {
                cbExpenseType.DataSource = null;
                cbExpenseType.Items.Clear();
            }
        }
        private void load_Suppliers()
        {
            SqlConnection conn = new SqlConnection(connstring);
            conn.Open();
            string qry = "Select '0' As Id, '--Select Supplier--' As Name Union Select Id,Name from Supplier  Order By Id";
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
        private void load_Companyname()
        {
            SqlConnection conn = new SqlConnection(connstring);
            conn.Open();
            string qry = "Select '0' As Id, '--Select Company--' As CompanyName Union select Id,CompanyName FROM CompanyName";
            SqlDataAdapter da = new SqlDataAdapter(qry, conn);
            DataSet ds = new DataSet();
            da.Fill(ds);
            conn.Close();
            int rowcount = ds.Tables[0].Rows.Count;
            if (rowcount == 0)
            {
                MessageBox.Show("No Conductor Record Found");
            }
            else
            {
                cbCompany.DataSource = ds.Tables[0];
                cbCompany.ValueMember = "Id";
                cbCompany.DisplayMember = "CompanyName";
            }
        }
        private void load_Bus()
        {
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

        private void clear()
        {
            //id = 0;
            cbCompany.SelectedIndex = 0;
            cbExpenseType.SelectedIndex = 0;
            cbSupplier.SelectedIndex = 0;
            cbBus.SelectedIndex = 0;
            dtpDate.Text = DateTime.Today.ToString("dd'-'MM'-'yyyy");
            txtTotalAmount.Text = "0.00";
            txtCash.Text = "0.00";
            txtCredit.Text = "0.00";
            txtCheque.Text = "0.00";
            dtpChequeDate.Text = DateTime.Today.ToString("dd'-'MM'-'yyyy");
            txtChequeDetails.Text = string.Empty;
            txtDD.Text = "0.00";
            dtpDDDate.Text = DateTime.Today.ToString("dd'-'MM'-'yyyy");
            txtDDDetails.Text = string.Empty;
            txtTransfer.Text = "0.00";
            dtpTransferDate.Text = DateTime.Today.ToString("dd'-'MM'-'yyyy");
            txtTransferDetails.Text = string.Empty;
            txtRemark.Text = string.Empty;
        }

        private bool isAmountTally()
        {
            double cash = Convert.ToDouble(txtCash.Text);
            double credit = Convert.ToDouble(txtCredit.Text);
            double cheque = Convert.ToDouble(txtCheque.Text);
            double dd = Convert.ToDouble(txtDD.Text);
            double transfer = Convert.ToDouble(txtTransfer.Text);
            double result = cash + credit + cheque + dd + transfer;
            if (Convert.ToDouble(txtTotalAmount.Text) == result)
                return true;
            else
                return false;          
        }

        private void btDelete_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(connstring);
            conn.Open();
            string qry = "Delete from ExpenseMaster Where Id=@id";
            SqlCommand cmd = new SqlCommand(qry, conn);
            cmd.Parameters.Add(new SqlParameter("@Id", id));
            cmd.ExecuteNonQuery();
            conn.Close();
            MessageBox.Show("Deleted Successfully");
            id = 0;
            clear();
        }

        private void cbCompany_SelectionChangeCommitted_1(object sender, EventArgs e)
        {
            string connstring = System.Configuration.ConfigurationManager.ConnectionStrings["BUS"].ConnectionString.ToString();
            SqlConnection conn = new SqlConnection(connstring);
            conn.Open();
            string qry = "select Id,Name From BusMaster Where CompanyId='" + cbCompany.SelectedValue + "'";
            SqlDataAdapter da = new SqlDataAdapter(qry, conn);
            DataSet ds = new DataSet();
            da.Fill(ds);
            conn.Close();
            int rowcount = ds.Tables[0].Rows.Count;
            if (rowcount == 0)
            {
                MessageBox.Show("No Bus Record Found");
            }
            else
            {
                cbBus.DataSource = ds.Tables[0];
                cbBus.ValueMember = "Id";
                cbBus.DisplayMember = "Name";
            }
        }
    }
}
