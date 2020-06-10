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
    public partial class BusTrip : Form
    {
        string title = "Enter Time";
        string promptText = "Enter Trip Time";
        string value;
        string busid;
        List<string> list = new List<string>();
        List<string> list1 = new List<string>();
        

                 
       
        public BusTrip()
        {
            InitializeComponent();
            
        }

        private void BusTrip_Load(object sender, EventArgs e)
        {
            string connstring = System.Configuration.ConfigurationManager.ConnectionStrings["BUS"].ConnectionString.ToString();
            SqlConnection conn = new SqlConnection(connstring);
            cbbusname.Items.Clear();
            conn.Open();
          String  qry = "select * FROM BusMaster";
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

            label3.Visible = false;
            textBox1.Visible = false;
            button1.Visible = false;
            this.gvData.DataSource = null;
            this.gvData.Rows.Clear();

        }

        private void cbbusname_SelectedIndexChanged(object sender, EventArgs e)
        {
            label3.Visible = true;
            textBox1.Visible = true;
            button1.Visible = true;

            string busids = "";
            string connstring = System.Configuration.ConfigurationManager.ConnectionStrings["BUS"].ConnectionString.ToString();
            SqlConnection conn = new SqlConnection(connstring);
            conn.Open();
            String s = cbbusname.SelectedItem.ToString();
            string query = "select Id from BusMaster where Name = '" + cbbusname.SelectedItem.ToString() + "'";
            SqlDataAdapter da = new SqlDataAdapter(query, conn);
            DataSet ds = new DataSet();
            da.Fill(ds);
            int rowcount = ds.Tables[0].Rows.Count;
            if (rowcount == 0)
            {

            }
            else
            {
                for (int count = 0; count < rowcount; count++)
                {
                    busids = Convert.ToString(ds.Tables[0].Rows[count]["Id"]);
                }
            }

            if (busids =="")
            {
                MessageBox.Show(" table is not yet created");
            }
            else
            {

                string Qury = "SELECT BT.Id, BT.[Date],BM.Name AS Bus,EMD.Name AS Driver,EMC.Name AS Conductor ,";

                using (SqlCommand command = conn.CreateCommand())
                {
                    command.CommandText = " SELECT column_name FROM information_schema.columns WHERE table_name ='BusTripSheet_" + busids + "'  ";
                    list1.Clear();
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            list1.Add(reader.GetString(0));

                        }
                    }
                }

                string[] ResultList = list1.ToArray();
                string listcount = list1.Count.ToString();
                int countlist = int.Parse(listcount);
                countlist = countlist - 6;
                try
                {

                    for (int i = 0; i <= countlist; i++)
                    {
                        string Resultcount = ResultList[i + 5];
                        Qury = Qury + "BT" + ".[" + Resultcount + "],";
                    }

                    Qury = Qury.Substring(0, Qury.Length - 1);
                    Qury = Qury + " FROM dbo.BusTripSheet_" + busids + " BT INNER JOIN BusMaster BM ON BT.BusName = BM.Id INNER JOIN EmployeeMaster EMD ON BT.DriverName = EMD.Id INNER JOIN EmployeeMaster EMC ON BT.ConductorName = EMC.Id WHERE EMD.Department = 'Driver' AND EMC.Department = 'Conductor'  order by BT.[Date]";

                    Qury = Qury + " ;";

                    //string qry = " select * from BusTripSheet_" + busid + "";
                    SqlDataAdapter da1 = new SqlDataAdapter(Qury, conn);
                    DataSet ds1 = new DataSet();
                    da1.Fill(ds1);
                    conn.Close();
                    gvData.DataSource = ds1.Tables[0].DefaultView;
                }
                catch (Exception e1)
                {
                    MessageBox.Show("Table is not yet created");
                    this.gvData.DataSource = null;
                    this.gvData.Rows.Clear();
                  
                }

               }
        }

        private void popupbox()
        {
            Form form = new Form();
            Label label = new Label();
            TextBox textBox = new TextBox();
            Button buttonOk = new Button();
            Button buttonCancel = new Button();

            form.Text = title;
            label.Text = promptText;
            textBox.Text = value;

            buttonOk.Text = "OK";
            buttonCancel.Text = "Cancel";
            buttonOk.DialogResult = DialogResult.OK;
            buttonCancel.DialogResult = DialogResult.Cancel;

            label.SetBounds(9, 20, 372, 13);
            textBox.SetBounds(12, 36, 372, 20);
            buttonOk.SetBounds(228, 72, 75, 23);
            buttonCancel.SetBounds(309, 72, 75, 23);

            label.AutoSize = true;
            textBox.Anchor = textBox.Anchor | AnchorStyles.Right;
            buttonOk.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            buttonCancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;

            form.ClientSize = new Size(396, 107);
            form.Controls.AddRange(new Control[] { label, textBox, buttonOk, buttonCancel });
            form.ClientSize = new Size(Math.Max(300, label.Right + 10), form.ClientSize.Height);
            form.FormBorderStyle = FormBorderStyle.FixedDialog;
            form.StartPosition = FormStartPosition.CenterScreen;
            form.MinimizeBox = false;
            form.MaximizeBox = false;
            form.AcceptButton = buttonOk;
            form.CancelButton = buttonCancel;

            DialogResult dialogResult = form.ShowDialog();
            value = textBox.Text;
        }

        
        private void button1_Click(object sender, EventArgs e)
        {
            
            string s = textBox1.Text.ToString();
            int ab = Int32.Parse(s);
            int n = 0;
            if (s != "")
            {

            }
            else
            {
                MessageBox.Show("Enter Number of Trip");
            }

            for (n = 0; n < ab; n++)
            {
                popupbox();
                list.Add(value);
                
                                
            }
            string cbbus = cbbusname.SelectedItem.ToString();

            string connstring = System.Configuration.ConfigurationManager.ConnectionStrings["BUS"].ConnectionString.ToString();
            SqlConnection conn = new SqlConnection(connstring);
            conn.Open();
            string qry1 = "select Id from BusMaster where Name = '" + cbbusname.SelectedItem.ToString() + "'";
            SqlDataAdapter da = new SqlDataAdapter(qry1, conn);
            DataSet ds = new DataSet();
            da.Fill(ds);
            int rowcount = ds.Tables[0].Rows.Count;
            if (rowcount == 0)
            {
                
            }
            else
            {
                for (int count = 0; count < rowcount; count++)
                {
                  busid = Convert.ToString(ds.Tables[0].Rows[count]["Id"]);
                }
            }
            String Qry = "Create Table BusTripSheet_" + busid + " (Id [bigint] IDENTITY(1,1) NOT NULL,[Date] [datetime] NULL,[BusName] [bigint] NOT NULL,[DriverName] [bigint] NOT NULL,[ConductorName] [bigint] NOT NULL, ";      
             
            foreach (var author in list)
            {
                string[] ResultList = list.ToArray();
                Qry = Qry + "[" + author + "] " + "float, ";
            }
            Qry = Qry.Substring(0, Qry.Length - 2);
            Qry = Qry + " );";
            SqlCommand cmd = new SqlCommand(Qry, conn);
            cmd.ExecuteNonQuery();
            conn.Close();
            MessageBox.Show("Table created Successfully");

        }

        
        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar >= '0' && e.KeyChar <= '9' ) //The  character represents a backspace
    {
        e.Handled = false; //Do not reject the input
    }
    else
    {
        e.Handled = true; //Reject the input
    }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void dtpdate_ValueChanged(object sender, EventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            cbbusname.Enabled = false;
            textBox1.Visible = false;
            button1.Visible = false;
            dtpdate.Enabled = false;
            label3.Visible = false;
            DialogResult dialogResult = MessageBox.Show("If you Want to delete this table ", "Alert Box", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                string idbus = "";
                string connstring = System.Configuration.ConfigurationManager.ConnectionStrings["BUS"].ConnectionString.ToString();
                SqlConnection conn = new SqlConnection(connstring);
                conn.Open();
                String s = cbbusname.SelectedItem.ToString();
                string query = "select Id from BusMaster where Name = '" + cbbusname.SelectedItem.ToString() + "'";
                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                DataSet ds = new DataSet();
                da.Fill(ds);
                int rowcount = ds.Tables[0].Rows.Count;
                if (rowcount == 0)
                {

                }
                else
                {
                    for (int count = 0; count < rowcount; count++)
                    {
                        idbus = Convert.ToString(ds.Tables[0].Rows[count]["Id"]);
                    }
                }


                string Query = "SELECT COUNT(*) FROM BusTripSheet_"+idbus+" ";
                SqlDataAdapter sda = new SqlDataAdapter(Query, conn);
                DataSet dse = new DataSet();
                sda.Fill(dse);
                int rowcounts = dse.Tables[0].Rows.Count;
                if (rowcounts == 0)
                {

                    string Qyrt = " DROP TABLE BusTripSheet_"+idbus+" ";
                    SqlCommand cmd = new SqlCommand(Qyrt, conn);
                    cmd.ExecuteNonQuery();
                    conn.Close();
                    MessageBox.Show("Table Deleted Successfully");


                }
                else
                {
                    for (int count = 0; count < rowcounts; count++)
                    {
                        MessageBox.Show(" Not Possible To Delete ");
                    }
                }



            }
            else if (dialogResult == DialogResult.No)
            {
                cbbusname.Enabled = true;
                textBox1.Visible = true;
                button1.Visible = true;
                dtpdate.Enabled = true;
                label3.Visible = true;
            }
            
        }

        private void gvData_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            cbbusname.Enabled = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            cbbusname.Enabled = true;
            cbbusname.Visible = true;
            dtpdate.Visible = true;
            dtpdate.Enabled = true;
            this.gvData.DataSource = null;
            this.gvData.Rows.Clear();
            
        }
    }
}
