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
using System.Drawing.Printing;
using GridPrintPreviewLib;

namespace BUS
{
    public partial class btcreate : Form
    {
        public btcreate()
        {
            InitializeComponent();
        }

        private void Report_Load(object sender, EventArgs e)
        {
            dtpfromdate.Value = DateTime.Now;
            dtptodate.Value = DateTime.Now;

            cbdrivername.Items.Clear();
            string connstring = General.CONNECTION_STRING;
            SqlConnection conn = new SqlConnection(connstring);
            conn.Open();
            string qry = "select * FROM EmployeeMaster where Department='Driver'";
            SqlDataAdapter da = new SqlDataAdapter(qry, conn);
            DataSet ds = new DataSet();
            da.Fill(ds);
            conn.Close();
            int rowcount = ds.Tables[0].Rows.Count;
            if (rowcount == 0)
            {
                MessageBox.Show("No Driver Record Found");
            }
            else
            {
                for (int count = 0; count < rowcount; count++)
                {
                    cbdrivername.Items.Insert(count, Convert.ToString(ds.Tables[0].Rows[count]["Name"]).Trim());
                }
                cbdrivername.SelectedIndex = 0;
            }

        }
        private void BindGrid()
        {
            try
            {
                string connstring = General.CONNECTION_STRING;
                SqlConnection conn = new SqlConnection(connstring);
                conn.Open();
                string qry = "select * FROM CollectionMaster WHERE Date>='" + dtpfromdate.Text.ToString() + "' AND Date<='" + dtptodate.Text.ToString() + "' AND Driver='"+cbdrivername.SelectedItem.ToString()+"'";
                SqlDataAdapter da = new SqlDataAdapter(qry, conn);
                DataSet ds = new DataSet();
                da.Fill(ds);
                conn.Close();

                int rowcount = ds.Tables[0].Rows.Count;

                gvLog.DataSource = null;
                if (rowcount > 0)
                {
                    gvLog.DataSource = ds.Tables[0].DefaultView;
                    gvLog.Rows[rowcount - 1].Selected = true;
                    this.gvLog.CurrentCell = this.gvLog[0, this.gvLog.Rows.Count - 1];

                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            BindGrid();

            GridPrintDocument doc = new GridPrintDocument(this.gvLog, this.gvLog.Font, true);
            doc.DocumentName = "Preview Test";
            doc.DrawCellBox = true;
            doc.DefaultPageSettings.Landscape = true;
            PrintPreviewDialog printPreviewDialog = new PrintPreviewDialog();
            printPreviewDialog.ClientSize = new Size(400, 300);
            printPreviewDialog.Location = new Point(29, 29);
            printPreviewDialog.Name = "Print Preview Dialog";
            printPreviewDialog.UseAntiAlias = true;
            printPreviewDialog.Document = doc;
            printPreviewDialog.ShowDialog();
            doc.Dispose();
            doc = null;
        }
    }
}
