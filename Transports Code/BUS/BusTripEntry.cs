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
    public partial class BusTripEntry : Form
    {
        public static string empid;
        List<string> list = new List<string>();
        List<string> list1 = new List<string>();
        List<string> columnlist = new List<string>();
        private List<TextBox> inputTextBoxes;
        string busid;
        string conid;
        string drid;
        string ids;
        public BusTripEntry()
        {
            InitializeComponent();
        }

        private void BusTripEntry_Load(object sender, EventArgs e)
        {
            button2.Visible = false;
            string connstring = System.Configuration.ConfigurationManager.ConnectionStrings["BUS"].ConnectionString.ToString();
            SqlConnection conn = new SqlConnection(connstring);
            cbbusname.Items.Clear();
            conn.Open();
            String qry = "select * FROM BusMaster";
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


            LoadCombo();

            cbdrivername.Items.Clear();
            string connstring1 = System.Configuration.ConfigurationManager.ConnectionStrings["BUS"].ConnectionString.ToString();
            
            SqlConnection conn1 = new SqlConnection(connstring1);
            conn1.Open();
            string qry3 = "select * FROM EmployeeMaster where Department='Driver'";
            SqlDataAdapter da1 = new SqlDataAdapter(qry3, conn1);
            DataSet ds1 = new DataSet();
            da1.Fill(ds1);
            conn1.Close();
            int rowcount1 = ds1.Tables[0].Rows.Count;
            if (rowcount1 == 0)
            {
                MessageBox.Show("No Driver Record Found");
            }
            else
            {
                for (int count = 0; count < rowcount1; count++)
                {
                    cbdrivername.Items.Insert(count, Convert.ToString(ds1.Tables[0].Rows[count]["Name"]).Trim());
                }
                cbdrivername.SelectedIndex = 0;
            }


            cbconductorname.Items.Clear();
            conn.Open();
            qry = "select * FROM EmployeeMaster where Department='Conductor'";
            da = new SqlDataAdapter(qry, conn);
            ds = new DataSet();
            da.Fill(ds);
            conn.Close();
            rowcount = ds.Tables[0].Rows.Count;
            if (rowcount == 0)
            {
                MessageBox.Show("No Conductor Record Found");
            }
            else
            {
                for (int count = 0; count < rowcount; count++)
                {
                    cbconductorname.Items.Insert(count, Convert.ToString(ds.Tables[0].Rows[count]["Name"]).Trim());
                }
                cbconductorname.SelectedIndex = 0;
            }
            this.gvData.DataSource = null;
            this.gvData.Rows.Clear();

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
                //cbbusname.SelectedIndex = 0;
            }
        }

        private void cbbusname_SelectedIndexChanged(object sender, EventArgs e)
        {
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
            string Qury = "SELECT BT.Id, BT.[Date],BM.Name AS Bus,EMD.Name AS Driver,EMC.Name AS Conductor ,";

            using (SqlCommand command = conn.CreateCommand())
            {
                command.CommandText = " SELECT column_name FROM information_schema.columns WHERE table_name ='BusTripSheet_" + busids + "'  ";
                list.Clear();                
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(reader.GetString(0));

                    }
                }
            }

            string[] ResultList = list.ToArray();
            string listcount = list.Count.ToString();
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
            catch (Exception e2)
            {
                MessageBox.Show("Table is not yet craeted");
            }
            try
            {
                string qry4 = "select Date from BusTripSheet_" + busids + " where Date = '" + dtpdate.Value.ToString("yyyy-MM-dd") + "' ";
                SqlDataAdapter da2 = new SqlDataAdapter(qry4, conn);
                DataSet ds2 = new DataSet();
                da2.Fill(ds2);
                int rowcount1 = ds2.Tables[0].Rows.Count;
                if (rowcount1 == 0)
                {

                }
                else
                {
                    for (int count = 0; count < rowcount1; count++)
                    {
                        button2.Visible = true;
                    }
                }
            }
            catch (Exception e1)
            {
                MessageBox.Show("Table is not yet craeted");
                this.gvData.DataSource = null;
                this.gvData.Rows.Clear();
                button2.Visible = false;
            }


        }


        public void createTxtTeamNames()
        {
            TextBox[] txtTeamNames = new TextBox[4];

            int rowcount = 1;
            int colcount = 2;


            for (int u = 0; u < txtTeamNames.Length; u++)
            {
                txtTeamNames[u] = new TextBox();
                string name = list[u];

                if (rowcount > 2)
                {
                    rowcount = 1;
                    colcount++;
                }


                txtTeamNames[u].Text = name;
                txtTeamNames[u].Location = new Point(rowcount * 150, colcount * 40);
                txtTeamNames[u].Visible = true;
                this.Controls.Add(txtTeamNames[u]);
                rowcount++;
            }

        }

        public void hidedata()
        {
            groupBox1.Visible = false;
            groupBox2.Visible = false;

        }

        private void generate()
        {
            int rowcount = 1;
            int colcount = 4;

            int inputNumber = Int32.Parse(textBox1.Text);
            inputTextBoxes = new List<TextBox>();
            for (int i = 5; i < inputNumber; i++)
            {

                Label labelInput = new Label();
                TextBox textBoxNewInput = new TextBox();
                string name = list[i];
                if (rowcount > 4)
                {
                    rowcount = 1;
                    colcount++;
                }

                labelInput.Text = name;
                //labelInput.Location = new Point(30, textBox1.Bottom + (i * 30));
                labelInput.Location = new Point(rowcount * 150, colcount * 47);
                labelInput.AutoSize = true;




                //textBoxNewInput.Location = new Point(labelInput.Width-90, labelInput.Top);
                textBoxNewInput.Location = new Point(rowcount * 150, colcount * 50);
                inputTextBoxes.Add(textBoxNewInput);
                this.Controls.Add(labelInput);
                this.Controls.Add(textBoxNewInput);
                rowcount++;

            }
            groupBox3.Visible = true;

            Button buttonAdd = new Button();
            buttonAdd.Text = "Add";
            buttonAdd.Location = new Point(this.Width / 2 - buttonAdd.Width / 2,
            inputTextBoxes[inputTextBoxes.Count - 1].Bottom + 20);

            buttonAdd.Click += new EventHandler(buttonAdd_Click);

            this.Controls.Add(buttonAdd);

            this.CenterToScreen();
        }


        void buttonAdd_Click(object sender, EventArgs e)
        {
           
            String s = cbconductorname.SelectedItem.ToString();
           
                string connstring = System.Configuration.ConfigurationManager.ConnectionStrings["BUS"].ConnectionString.ToString();
                SqlConnection conn = new SqlConnection(connstring);
                conn.Open();

                string query = "select Id from EmployeeMaster where Name = '" + cbdrivername.SelectedItem.ToString() + "' and Department = 'Driver'";
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
                        drid = Convert.ToString(ds.Tables[0].Rows[count]["Id"]);
                    }
                }
                conn.Close();

                conn.Open();

                string query1 = "select Id from EmployeeMaster where Name = '" + cbconductorname.SelectedItem.ToString() + "' and Department = 'Conductor'";
                SqlDataAdapter da1 = new SqlDataAdapter(query1, conn);
                DataSet ds1 = new DataSet();
                da1.Fill(ds1);

                int rowcount1 = ds.Tables[0].Rows.Count;

                if (rowcount1 == 0)
                {

                }
                else
                {
                    for (int count = 0; count < rowcount1; count++)
                    {
                        conid = Convert.ToString(ds1.Tables[0].Rows[count]["Id"]);
                    }
                }
            

            int sum = 0;
            string counts = list.Count.ToString();
            int count1 = int.Parse(counts);
            count1 = count1 - 5;
            for (int p = 0; p < count1; p++)
            {
                // '" + inputTextBoxes[0].Text + "',
                string g = inputTextBoxes[p].Text;
                list1.Add(g);
            }

            string[] ResultList = list1.ToArray();

            //string ResultString = string.Join(",", ResultList.ToArray());

            string output = "'" + string.Join("','", ResultList) + "'";
            foreach (TextBox inputBox in inputTextBoxes)
            {
                if (inputBox.Text == String.Empty)
                {
                    MessageBox.Show("Plaese fill in all the text boxes.", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                {
                    sum += Int32.Parse(inputBox.Text);
                    string busids1 = "";
                    string connstring1 =  System.Configuration.ConfigurationManager.ConnectionStrings["BUS"].ConnectionString.ToString();
                    SqlConnection conn1 = new SqlConnection(connstring1);
                    conn1.Open();
                    String s1 = cbbusname.SelectedItem.ToString();
                    string query12 = "select Id from BusMaster where Name = '" + cbbusname.SelectedItem.ToString() + "'";
                    SqlDataAdapter da12 = new SqlDataAdapter(query12, conn1);
                    DataSet ds12 = new DataSet();
                    da12.Fill(ds12);
                    int rowcount12 = ds12.Tables[0].Rows.Count;
                    if (rowcount12 == 0)
                    {

                    }
                    else
                    {
                        for (int count = 0; count < rowcount12; count++)
                        {
                            busids1 = Convert.ToString(ds12.Tables[0].Rows[count]["Id"]);
                        }
                    }
                    
                    string qrys = "insert into BusTripSheet_" + busids1 + " values('" + dtpdate.Value.ToString("yyyy-MM-dd") + "'," + busids1 + "," + drid + "," + conid + "," + output + ")";
                    SqlCommand cmd = new SqlCommand(qrys, conn);
                    cmd.ExecuteNonQuery();

                    MessageBox.Show(" inserted Successfully");
                    break;

                }
            }
            //MessageBox.Show("The Sum is " + sum);
            inputTextBoxes.Clear();
            groupBox1.Visible = true;
            groupBox2.Visible = true;
            button2.Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string busid2 = "0";
            String s = cbbusname.SelectedItem.ToString();
            if (s == "-Select-")
            {
                MessageBox.Show(" Select a Busname");
            }
            else{


                string connstring = System.Configuration.ConfigurationManager.ConnectionStrings["BUS"].ConnectionString.ToString();
                SqlConnection conn = new SqlConnection(connstring);
                conn.Open();

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
                        busid2 = Convert.ToString(ds.Tables[0].Rows[count]["Id"]);
                    }
                }


                using (SqlCommand command = conn.CreateCommand())
                {
                    command.CommandText = " SELECT column_name FROM information_schema.columns WHERE table_name ='BusTripSheet_" + busid2 + "'  ";
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            columnlist.Add(reader.GetString(0));

                        }
                    }
                }
                string counts = columnlist.Count.ToString();
                textBox1.Text = counts;
                generate();
                hidedata();
                conn.Close();
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {

            if ( cbbusname.SelectedItem.ToString() != "-Select-")
            {
                try
                {
                    string buus = "0";
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
                             buus = Convert.ToString(ds.Tables[0].Rows[count]["Id"]);
                        }
                    }

                    MessageBox.Show(" The id " + ids + "  is deleted ");
                    cbbusname.Enabled = false;
                    cbdrivername.Enabled = false;
                    cbconductorname.Enabled = false;

                                        string qry = "";
                                        qry = "Delete From BusTripSheet_" + buus + ""
                               + " WHERE Id = "+ ids+" ";
                    SqlCommand cmd = new SqlCommand(qry, conn);
                    cmd.ExecuteNonQuery();
                    conn.Close();
                   
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

        private void cbdrivername_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void gvData_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
             ids  = gvData.Rows[gvData.CurrentRow.Index].Cells["Id"].Value.ToString();
            button2.Visible = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            cbbusname.Enabled = true;
            cbbusname.SelectedIndex = 0;
            cbdrivername.Enabled = true;
            cbconductorname.Enabled = true;
            this.gvData.DataSource = null;
            this.gvData.Rows.Clear();

        }
    }

        

    }

