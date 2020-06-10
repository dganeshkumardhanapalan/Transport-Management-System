using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.IO;
using System.Threading;
using System.Globalization;

namespace BUS
{
    public partial class CollectionModify : Form
    {
        bool IS_BATA_AUTO = Convert.ToBoolean(System.Configuration.ConfigurationManager.AppSettings["IS_BATA_AUTO"]);
        bool IS_WAGES_AUTO = Convert.ToBoolean(System.Configuration.ConfigurationManager.AppSettings["IS_WAGES_AUTO"]);
        bool IS_MILEAGE_AUTO = Convert.ToBoolean(System.Configuration.ConfigurationManager.AppSettings["IS_MILEAGE_AUTO"]);
        bool IS_DIESEL_AUTO = Convert.ToBoolean(System.Configuration.ConfigurationManager.AppSettings["IS_DIESEL_AUTO"]); 
        public CollectionModify()
        {
            InitializeComponent();
        }

        //string bata = "";
        int id=0;
       // double Bata = 0.0;


        string bata = "";
        double bonus = 0.0;
        double dwages = 0.0;
        double dBata = 0.0;
        double cwages = 0.0;
        double cBata = 0.0;

        private void CollectionModify1_Load(object sender, EventArgs e)
        {
            if (!General.Is_Edit)
                btsave.Enabled = false;
            else
                btsave.Enabled = true;

            if (!General.Is_Delete)
                button1.Enabled = false;
            else
                button1.Enabled = true;

            gb1.Enabled = false;
            gb2.Enabled = false;
            gb3.Enabled = false;

            //string filepath = Path.GetDirectoryName(Application.ExecutablePath).ToString() + General.DieselPrice;
            //string[] str = File.ReadAllLines(filepath);
            //tbpricelitrs.Text = str[0];

            string filepath1 = Path.GetDirectoryName(Application.ExecutablePath).ToString() + General.Batapath;
            string[] str1 = File.ReadAllLines(filepath1);
            bata = str1[0];

            cbdrivername.Items.Clear();
            string connstring = System.Configuration.ConfigurationManager.ConnectionStrings["BUS"].ConnectionString.ToString();
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

            loadDriver2();
            loadConductor2();
            loadTrip();
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


            cbbusname.Items.Clear();
            conn.Open();
            qry = "select * FROM BusMaster";
            da = new SqlDataAdapter(qry, conn);
            ds = new DataSet();
            da.Fill(ds);
            conn.Close();
            rowcount = ds.Tables[0].Rows.Count;
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
            if (IS_DIESEL_AUTO == false)
            {
                tbdiesel.Enabled = true;
                tbpricelitrs.Enabled = true;
            }
            if (IS_BATA_AUTO == false)
            {
                
                tbDbata.Enabled = true;
                tbCbata.Enabled = true;
               
            }
            if(IS_WAGES_AUTO==false)
            {
                tbDwages.Enabled = true;
                tbCwages.Enabled = true;
            }
        }

        private void loadDriver2()
        {
            cbDriver2.Items.Clear();
            string connstring = System.Configuration.ConfigurationManager.ConnectionStrings["BUS"].ConnectionString.ToString();
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
                    cbDriver2.Items.Insert(count, Convert.ToString(ds.Tables[0].Rows[count]["Name"]).Trim());
                }
                cbDriver2.SelectedIndex = 0;
            }
        }

        private void loadConductor2()
        {
            cbConductor2.Items.Clear();
            string connstring = System.Configuration.ConfigurationManager.ConnectionStrings["BUS"].ConnectionString.ToString();
            SqlConnection conn = new SqlConnection(connstring);
            conn.Open();
            string qry = "select * FROM EmployeeMaster where Department='Conductor'";
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
                for (int count = 0; count < rowcount; count++)
                {
                    cbConductor2.Items.Insert(count, Convert.ToString(ds.Tables[0].Rows[count]["Name"]).Trim());
                }
                cbConductor2.SelectedIndex = 0;
            }

        }

        private void loadTrip()
        {
            cbtrip.Items.Clear();

            string filepath1 = Path.GetDirectoryName(Application.ExecutablePath).ToString() + General.Batapath;
            int trip = Convert.ToInt32(System.Configuration.ConfigurationManager.AppSettings["MAX_TRIP"]);
            string[] str1 = File.ReadAllLines(filepath1);
            bata = str1[0];
            for (int i = 1; i <= trip; i++)
            {
                string[] numbers = { i.ToString() };
                cbtrip.Items.AddRange(numbers);
            }

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void btcreatereport_Click(object sender, EventArgs e)
        {
            BlindData();
        }

        private void BlindData()
        {
            string connstring = System.Configuration.ConfigurationManager.ConnectionStrings["BUS"].ConnectionString.ToString();
            SqlConnection conn = new SqlConnection(connstring);
            conn.Open();
            string qry = "select * FROM CollectionMaster WHERE Date between '" + dtpfromdate.Value.ToString("yyyy-MM-dd") + "' AND '" + dtptodate.Value.ToString("yyyy-MM-dd") + "' order by Date" ;
            SqlDataAdapter da = new SqlDataAdapter(qry, conn);
            DataSet ds = new DataSet();
            da.Fill(ds);
            conn.Close();

            gvData.DataSource = ds.Tables[0].DefaultView;
        }

        private void gvData_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            id = Convert.ToInt32(gvData.Rows[e.RowIndex].Cells[0].Value);
            string connstring = System.Configuration.ConfigurationManager.ConnectionStrings["BUS"].ConnectionString.ToString();
            SqlConnection conn = new SqlConnection(connstring);
            conn.Open();
            string qry = "select * FROM CollectionMaster where Id=" + id  ;
            SqlDataAdapter da = new SqlDataAdapter(qry, conn);
            DataSet ds = new DataSet();
            da.Fill(ds);
            conn.Close();
            int rowcount = ds.Tables[0].Rows.Count;
            if (rowcount > 0)
            {
                dtpdate.Text = Convert.ToString(ds.Tables[0].Rows[0]["Date"]).Trim();
                cbdrivername.Text = Convert.ToString(ds.Tables[0].Rows[0]["Driver1"]).Trim();
                cbconductorname.Text = Convert.ToString(ds.Tables[0].Rows[0]["Conductor1"]).Trim();
                cbbusname.Text = Convert.ToString(ds.Tables[0].Rows[0]["BusName"]).Trim();
                cbtrip.Text = Convert.ToString(ds.Tables[0].Rows[0]["Trip"]).Trim();
                tbcollection.Text = Convert.ToString(ds.Tables[0].Rows[0]["Collection"]).Trim();
                tbdiesel.Text = Convert.ToString(ds.Tables[0].Rows[0]["DLit"]).Trim();
                tbpricelitrs.Text = Convert.ToString(ds.Tables[0].Rows[0]["DPrice"]).Trim();
                tbdieselAmount.Text =  (Convert.ToDouble(tbdiesel.Text) * Convert.ToDouble(tbpricelitrs.Text)).ToString();
                cbDriver2.Text = Convert.ToString(ds.Tables[0].Rows[0]["Driver2"]).Trim();
                //cbDriver2.Text = Convert.ToString(ds.Tables[0].Rows[0]["Driver2"]).Trim();
                cbConductor2.Text = Convert.ToString(ds.Tables[0].Rows[0]["Conductor2"]).Trim();
                txtEveningCollection.Text = Convert.ToString(ds.Tables[0].Rows[0]["EveningCollection"]).Trim();
                tbStartKm.Text = Convert.ToString(ds.Tables[0].Rows[0]["StartKm"]).Trim();
                tbEndKm.Text = Convert.ToString(ds.Tables[0].Rows[0]["EndKm"]).Trim();

                tbDwages.Text = Convert.ToString(ds.Tables[0].Rows[0]["DWages"]).Trim();
                tbCwages.Text = Convert.ToString(ds.Tables[0].Rows[0]["CWages"]).Trim();

                tbDbata.Text = Convert.ToString(ds.Tables[0].Rows[0]["DBata"]).Trim();
                tbCbata.Text = Convert.ToString(ds.Tables[0].Rows[0]["CBata"]).Trim();

                tbwages.Text = (Convert.ToDouble( tbDwages.Text)+Convert.ToDouble( tbCwages.Text)).ToString();
                tbbata.Text = (Convert.ToDouble(tbDbata.Text) + Convert.ToDouble(tbCbata.Text)).ToString();

                tbcleaner.Text = Convert.ToString(ds.Tables[0].Rows[0]["Cleaner"]).Trim();
                tbstand.Text = Convert.ToString(ds.Tables[0].Rows[0]["Stand"]).Trim();
                tbgtc.Text = Convert.ToString(ds.Tables[0].Rows[0]["Gtc"]).Trim();
                tbpooja.Text = Convert.ToString(ds.Tables[0].Rows[0]["Pooja"]).Trim();
                tbextra.Text = Convert.ToString(ds.Tables[0].Rows[0]["Extra"]).Trim();
                tbgreese.Text = Convert.ToString(ds.Tables[0].Rows[0]["Greese"]).Trim();
                tbsparse.Text = Convert.ToString(ds.Tables[0].Rows[0]["Sparse"]).Trim();

                

                //tbdelage.Text = Convert.ToString(ds.Tables[0].Rows[0]["Age"]).Trim();
                //tbdeldlno.Text = Convert.ToString(ds.Tables[0].Rows[0]["DlNo"]).Trim();
                //tbdeldepartment.Text = Convert.ToString(ds.Tables[0].Rows[0]["Department"]).Trim();

                gb1.Enabled = true;
                gb2.Enabled = true;
                gb3.Enabled = true;
                dtpdate.Select();
            }
            

        }

        private void tbcollection_Leave(object sender, EventArgs e)
        {
            if (tbcollection.Text != "")
            {
                tbcollection.Text = Convert.ToDouble(tbcollection.Text).ToString("F");
            }
            else
            {
                tbcollection.Text = "0.00";
            }
        }

        private void tbcollection_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (tbcollection.Text != "")
                {
                    //tbbata.Text = ((Convert.ToDouble(tbcollection.Text) * Convert.ToDouble(bata)) / 100).ToString("F");
                    //double amount;
                    //if (double.TryParse(tbbata.Text, out amount))
                    //{
                    //    amount = Math.Round(amount);
                    //    tbbata.Text = amount.ToString("F");
                    //}
                }
                else
                {
                    tbcollection.Text = "0.00";
                    tbcollection.SelectionStart = 0;
                    tbcollection.SelectionLength = tbcollection.Text.Length;
                }
                tbnetcollection.Text = tbcollection.Text;

                string connstring = System.Configuration.ConfigurationManager.ConnectionStrings["BUS"].ConnectionString.ToString();
                if (IS_WAGES_AUTO)
                {
                    
                    SqlConnection conn = new SqlConnection(connstring);
                    conn.Open();
                    string qry = "Select W.Department,W.Wages from WagesLimit W"
                                    + " INNER JOIN BusMaster B ON W.BusId=B.Id"
                                    + " where (W.LowerLimit < " + tbcollection.Text + " AND W.UpperLimit >= " + tbcollection.Text + ") AND B.Name='" + cbbusname.SelectedItem.ToString() + "' ORDER BY W.Department";

                    SqlDataAdapter da = new SqlDataAdapter(qry, conn);
                    DataSet ds = new DataSet();
                    da.Fill(ds);
                    conn.Close();
                    int rowcount = ds.Tables[0].Rows.Count;
                    if (rowcount == 0)
                    {
                        dwages = 0.0;
                        cwages = 0.0;
                    }
                    else
                    {
                        for (int count = 0; count < rowcount; count++)
                        {
                            if (ds.Tables[0].Rows[count]["Department"].Equals("Driver"))
                            {
                                dwages = Convert.ToDouble(ds.Tables[0].Rows[count]["Wages"]);
                            }
                            else if (ds.Tables[0].Rows[count]["Department"].Equals("Conductor"))
                            {
                                cwages = Convert.ToDouble(ds.Tables[0].Rows[count]["Wages"]);
                            }
                        }
                    }
                    tbDwages.Text = (dwages + bonus).ToString();
                    tbDwages.Text = Convert.ToDouble(tbDwages.Text).ToString("F");

                    tbCwages.Text = cwages.ToString();
                    tbCwages.Text = Convert.ToDouble(tbCwages.Text).ToString("F");
                    
                }

                if (IS_BATA_AUTO)
                {
                    //  string connstring1 = General.CONNECTION_STRING;
                    SqlConnection conn1 = new SqlConnection(connstring);
                    conn1.Open();
                    string qry1 = "Select W.Department,W.Bata from BataLimit W"
                                    + " INNER JOIN BusMaster B ON W.BusId=B.Id"
                                    + " where (W.LowerLimit < " + tbcollection.Text + " AND W.UpperLimit >= " + tbcollection.Text + ") AND B.Name='" + cbbusname.SelectedItem.ToString() + "' ORDER BY W.Department";

                    SqlDataAdapter da1 = new SqlDataAdapter(qry1, conn1);
                    DataSet ds1 = new DataSet();
                    da1.Fill(ds1);
                    conn1.Close();
                    int rowcount1 = ds1.Tables[0].Rows.Count;
                    if (rowcount1 == 0)
                    {
                        dBata = 0.0;
                        cBata = 0.0;
                    }
                    else
                    {
                        for (int count = 0; count < rowcount1; count++)
                        {
                            if (ds1.Tables[0].Rows[count]["Department"].Equals("Driver"))
                            {
                                dBata = Convert.ToDouble(ds1.Tables[0].Rows[count]["Bata"]);
                            }
                            else if (ds1.Tables[0].Rows[count]["Department"].Equals("Conductor"))
                            {
                                cBata = Convert.ToDouble(ds1.Tables[0].Rows[count]["Bata"]);
                            }
                        }
                    }
                    tbDbata.Text = ((Convert.ToDouble(tbcollection.Text) * dBata) / 100).ToString("F");
                    tbCbata.Text = ((Convert.ToDouble(tbcollection.Text) * cBata) / 100).ToString("F");
                    double amount;
                    if (double.TryParse(tbDbata.Text, out amount))
                    {
                        amount = Math.Round(amount);
                        tbDbata.Text = amount.ToString("F");
                    }

                    if (double.TryParse(tbCbata.Text, out amount))
                    {
                        amount = Math.Round(amount);
                        tbCbata.Text = amount.ToString("F");
                    }

                    tbbata.Text = (Convert.ToDouble(tbDbata.Text) + Convert.ToDouble(tbCbata.Text)).ToString(); 
                }


                tbwages.Text = (dwages + cwages).ToString();

                tbDTotal.Text= (Convert.ToDouble(tbDwages.Text) + Convert.ToDouble(tbDbata.Text)).ToString();
                tbCTotal.Text = (Convert.ToDouble(tbCwages.Text) + Convert.ToDouble(tbCbata.Text)).ToString();

            }


              catch (Exception)
            {

                MessageBox.Show("Invalid Data Format");
                tbcollection.Text = "0.00";
            }
        }
        

        private void tbdiesel_Leave(object sender, EventArgs e)
        {
            if (tbdiesel.Text != "")
            {
                tbdiesel.Text = Convert.ToDouble(tbdiesel.Text).ToString("F");
            }
            else
            {
                tbdiesel.Text = "0.00";
            }
        }

        private void tbdiesel_TextChanged(object sender, EventArgs e)
        {
            if (tbdiesel.Text != "")
            {
                //Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture; System.Globalization.CultureInfo.CurrentCulture
                tbdieselAmount.Text = (Convert.ToDouble(tbdiesel.Text) * Convert.ToDouble(tbpricelitrs.Text)).ToString("F");
            }
            else
            {
                tbdieselAmount.Text = "0.00";
                tbdiesel.Text = "0.00";
                tbdiesel.SelectionStart = 0;
                tbdiesel.SelectionLength = tbdiesel.Text.Length;
            }
        }
        private void calcdriverandconductortotal()
        {
            tbDTotal.Text = (Convert.ToDouble(tbDbata.Text) + Convert.ToDouble(tbDwages.Text)).ToString();
            tbCTotal.Text = (Convert.ToDouble(tbCbata.Text) + Convert.ToDouble(tbCwages.Text)).ToString();
            tbbata.Text = (Convert.ToDouble(tbDbata.Text) + Convert.ToDouble(tbCbata.Text)).ToString();
            tbwages.Text = (Convert.ToDouble(tbDwages.Text) + Convert.ToDouble(tbCwages.Text)).ToString();
        }
        private void expenses()
        {
            tbexpenses.Text = (Convert.ToDouble(tbdieselAmount.Text) + Convert.ToDouble(tbDbata.Text) + Convert.ToDouble(tbDwages.Text) + Convert.ToDouble(tbcleaner.Text) + Convert.ToDouble(tbstand.Text) + Convert.ToDouble(tbgtc.Text) + Convert.ToDouble(tbpooja.Text) + Convert.ToDouble(tbextra.Text) + Convert.ToDouble(tbgreese.Text) + Convert.ToDouble(tbsparse.Text)).ToString("F");
        }

        private void tbdieselAmount_TextChanged(object sender, EventArgs e)
        {
            expenses();
        }

        private void tbbata_Leave(object sender, EventArgs e)
        {
            if (tbDbata.Text != "")
            {
                tbDbata.Text = Convert.ToDouble(tbDbata.Text).ToString("F");
            }
            else
            {
                tbDbata.Text = "0.00";
            }
        }

        private void tbbata_TextChanged(object sender, EventArgs e)
        {
            if (tbDbata.Text != "")
            {
                expenses();
                calcdriverandconductortotal();
            }
            else
            {
                tbDbata.Text = "0.00";
                tbDbata.SelectionStart = 0;
                tbDbata.SelectionLength = tbDbata.Text.Length;

            }
        }

        private void tbwages_Leave(object sender, EventArgs e)
        {
            if (tbDwages.Text != "")
            {
                tbDwages.Text = Convert.ToDouble(tbDwages.Text).ToString("F");
            }
            else
            {
                tbDwages.Text = "0.00";
            }
        }

        private void tbwages_TextChanged(object sender, EventArgs e)
        {
            if (tbDwages.Text != "")
            {
                expenses();
                calcdriverandconductortotal();
            }
            else
            {
                tbDwages.Text = "0.00";
                tbDwages.SelectionStart = 0;
                tbDwages.SelectionLength = tbDwages.Text.Length;
            }
        }

        private void tbcleaner_Leave(object sender, EventArgs e)
        {
            if (tbcleaner.Text != "")
            {
                tbcleaner.Text = Convert.ToDouble(tbcleaner.Text).ToString("F");
            }
            else
            {
                tbcleaner.Text = "0.00";
            }
        }

        private void tbcleaner_TextChanged(object sender, EventArgs e)
        {
            if (tbcleaner.Text != "")
            {
                expenses();
            }
            else
            {
                tbcleaner.Text = "0.00";
                tbcleaner.SelectionStart = 0;
                tbcleaner.SelectionLength = tbcleaner.Text.Length;
            }
        }

        private void tbstand_Leave(object sender, EventArgs e)
        {
            if (tbstand.Text != "")
            {
                tbstand.Text = Convert.ToDouble(tbstand.Text).ToString("F");
            }
            else
            {
                tbstand.Text = "0.00";
            }
        }

        private void tbstand_TextChanged(object sender, EventArgs e)
        {
            if (tbstand.Text != "")
            {
                expenses();
            }
            else
            {
                tbstand.Text = "0.00";
                tbstand.SelectionStart = 0;
                tbstand.SelectionLength = tbstand.Text.Length;
            }
        }

        private void tbgtc_Leave(object sender, EventArgs e)
        {
            if (tbgtc.Text != "")
            {
                tbgtc.Text = Convert.ToDouble(tbgtc.Text).ToString("F");
            }
            else
            {
                tbgtc.Text = "0.00";
            }
        }

        private void tbStartKm_Leave(object sender, EventArgs e)
        {
            if (tbStartKm.Text != "")
            {
                tbStartKm.Text = Convert.ToDouble(tbStartKm.Text).ToString("F");
            }
            else
            {
                tbStartKm.Text = "0.00";
            }
        }

        private void tbEndKm_Leave(object sender, EventArgs e)
        {
            if (tbEndKm.Text != "")
            {
                tbEndKm.Text = Convert.ToDouble(tbEndKm.Text).ToString("F");
            }
            else
            {
                tbEndKm.Text = "0.00";
            }
        }

        private void tbgtc_TextChanged(object sender, EventArgs e)
        {
            if (tbgtc.Text != "")
            {
                expenses();
            }
            else
            {
                tbgtc.Text = "0.00";
                tbgtc.SelectionStart = 0;
                tbgtc.SelectionLength = tbgtc.Text.Length;
            }
        }

        private void tbpooja_Leave(object sender, EventArgs e)
        {
            if (tbpooja.Text != "")
            {
                tbpooja.Text = Convert.ToDouble(tbpooja.Text).ToString("F");
            }
            else
            {
                tbDwages.Text = "0.00";
            }
        }

        private void tbpooja_TextChanged(object sender, EventArgs e)
        {
            if (tbpooja.Text != "")
            {
                expenses();
            }
            else
            {
                tbpooja.Text = "0.00";
                tbpooja.SelectionStart = 0;
                tbpooja.SelectionLength = tbpooja.Text.Length;
            }
        }

        private void tbextra_Leave(object sender, EventArgs e)
        {
            if (tbextra.Text != "")
            {
                tbextra.Text = Convert.ToDouble(tbextra.Text).ToString("F");
            }
            else
            {
                tbextra.Text = "0.00";
            }
        }

        private void tbextra_TextChanged(object sender, EventArgs e)
        {
            if (tbextra.Text != "")
            {
                expenses();
            }
            else
            {
                tbextra.Text = "0.00";
                tbextra.SelectionStart = 0;
                tbextra.SelectionLength = tbextra.Text.Length;
            }
        }

        private void tbgreese_Leave(object sender, EventArgs e)
        {
            if (tbgreese.Text != "")
            {
                tbgreese.Text = Convert.ToDouble(tbgreese.Text).ToString("F");
            }
            else
            {
                tbgreese.Text = "0.00";
            }
        }

        private void tbgreese_TextChanged(object sender, EventArgs e)
        {
            if (tbgreese.Text != "")
            {
                expenses();
            }
            else
            {
                tbgreese.Text = "0.00";
                tbgreese.SelectionStart = 0;
                tbgreese.SelectionLength = tbgreese.Text.Length;
            }
        }

        private void tbsparse_Leave(object sender, EventArgs e)
        {
            if (tbsparse.Text != "")
            {
                tbsparse.Text = Convert.ToDouble(tbsparse.Text).ToString("F");
            }
            else
            {
                tbsparse.Text = "0.00";
            }
        }

        private void tbsparse_TextChanged(object sender, EventArgs e)
        {
            if (tbsparse.Text != "")
            {
                expenses();
            }
            else
            {
                tbsparse.Text = "0.00";
                tbsparse.SelectionStart = 0;
                tbsparse.SelectionLength = tbsparse.Text.Length;
            }
        }

        private void tbStartKm_TextChanged(object sender, EventArgs e)
        {
            if (tbStartKm.Text != "")
            {
                expenses();
            }
            else
            {
                tbStartKm.Text = "0.00";
                tbStartKm.SelectionStart = 0;
                tbStartKm.SelectionLength = tbStartKm.Text.Length;
            }

            try
            {
                tbMileage.Text = ((Convert.ToDouble(tbEndKm.Text) - Convert.ToDouble(tbStartKm.Text)) / (Convert.ToDouble(tbdiesel.Text))).ToString();
                tbMileage.Text = Convert.ToDouble(tbMileage.Text).ToString("F");
            }
            catch
            {
                tbMileage.Text = "0.00";
            }
        }

        private void tbEndKm_TextChanged(object sender, EventArgs e)
        {
            if (tbEndKm.Text != "")
            {
                expenses();
            }
            else
            {
                tbEndKm.Text = "0.00";
                tbEndKm.SelectionStart = 0;
                tbEndKm.SelectionLength = tbEndKm.Text.Length;
            }

            try
            {
                tbMileage.Text = ((Convert.ToDouble(tbEndKm.Text) - Convert.ToDouble(tbStartKm.Text)) / (Convert.ToDouble(tbdiesel.Text))).ToString();
                tbMileage.Text = Convert.ToDouble(tbMileage.Text).ToString("F");
            }
            catch
            {
                tbMileage.Text = "0.00";
            }
        }

        private void caltotal()
        {
            tbtotal.Text = (Convert.ToDouble(tbcollection.Text) - (Convert.ToDouble(tbdieselAmount.Text) + Convert.ToDouble(tbDbata.Text) + Convert.ToDouble(tbDwages.Text) + Convert.ToDouble(tbcleaner.Text) + Convert.ToDouble(tbstand.Text) + Convert.ToDouble(tbgtc.Text) + Convert.ToDouble(tbpooja.Text) + Convert.ToDouble(tbextra.Text) + Convert.ToDouble(tbgreese.Text) + Convert.ToDouble(tbsparse.Text))).ToString("F"); ;
        }
        private void tbnetcollection_TextChanged(object sender, EventArgs e)
        {
            caltotal();
        }

        private void tbexpenses_TextChanged(object sender, EventArgs e)
        {
            caltotal();
        }

        private void btsave_Click(object sender, EventArgs e)
        {
            try
            {
                string connstring = System.Configuration.ConfigurationManager.ConnectionStrings["BUS"].ConnectionString.ToString();
                SqlConnection conn = new SqlConnection(connstring);
                conn.Open();

                string qry = "update CollectionMaster set Date='" + dtpdate.Value.ToString("yyyy-MM-dd") 
                    +"'"+ ",Driver1='" + cbdrivername.SelectedItem.ToString() 
                    + "',Conductor1='" + cbconductorname.Text.ToString() 
                    + "',BusName='" + cbbusname.Text.ToString() 
                    + "',Trip= " + cbtrip.Text.ToString()
                    + ",Collection='" + tbcollection.Text 
                    + "',DLit='" + tbdiesel.Text 
                    + "',DAmount='" + tbdieselAmount.Text 
                    + "',StartKm='" + tbStartKm.Text 
                    + "',EndKm='" + tbEndKm.Text 
                    + "',Bata='" + tbbata.Text
                    + "',Wages='" + tbwages.Text 
                    + "',Cleaner='" + tbcleaner.Text 
                    + "',Stand='" + tbstand.Text 
                    + "',Gtc='" + tbgtc.Text 
                    + "',Pooja='" + tbpooja.Text 
                    + "',Extra='" + tbextra.Text 
                    + "',Greese='" + tbgreese.Text 
                    + "',Sparse='" + tbsparse.Text 
                    + "',Expenses='" + tbexpenses.Text
                    + "'" + ",Driver2='" + cbDriver2.SelectedItem.ToString()
                    + "',Conductor2='" + cbConductor2.Text.ToString() 
                    + "',Total='" + tbtotal.Text
                    + "',EveningCollection='" + txtEveningCollection.Text 
                    + "',netTotal='" + "0.00" 
                    + "',Dwages='" + tbDwages.Text
                    + "', DBata='" + tbDbata.Text 
                    + "',CWages='" + tbCwages.Text 
                    + "',CBata='" + tbCbata.Text
                    + "' Where id=" + id;
              //string qry = "update CollectionMaster set Date='" + dtpdate.Value.ToString("yyyy-MM-dd") + "',Driver='" + cbdrivername.SelectedItem.ToString() + "',Conductor='" + cbconductorname.SelectedItem.ToString() + "',BusName='" + cbbusname.SelectedItem.ToString() + "',Trip= '" + int.Parse(cbtrip.SelectedItem.ToString()) + "',Collection='" + tbcollection.Text + "',DLit='" + tbdiesel.Text + "',DAmount='" + tbdieselAmount.Text + "',StartKm='" + tbStartKm.Text + "',EndKm='" + tbEndKm.Text + "',Bata='" + tbbata.Text + "',Wages='" + tbwages.Text + "',Cleaner='" + tbcleaner.Text + "',Stand='" + tbstand.Text + "',Gtc='" + tbgtc.Text + "',Pooja='" + tbpooja.Text + "',Extra='" + tbextra.Text + "',Greese='" + tbgreese.Text + "',Sparse='" + tbsparse.Text + "',Expenses='" + tbexpenses.Text + "',Total='" + tbtotal.Text + "',netTotal='" + "0.00" + "',Dwages='" + tbDwages.Text + "', DBata='" + tbDbata.Text + "',CWages='" + tbCwages.Text + "',CBata='" + tbCbata.Text + "' Where id= + id ";
                SqlCommand cmd = new SqlCommand(qry, conn);
                cmd.ExecuteNonQuery();
                conn.Close();
                MessageBox.Show(General.SUCCESS_MSG);
                BlindData();
                gb1.Enabled = false;
                gb2.Enabled = false;
                gb3.Enabled = false;
            }
            catch (Exception ex)
            {
                    MessageBox.Show("Update Failed.");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Really delete?", "Confirm delete", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                string connstring = System.Configuration.ConfigurationManager.ConnectionStrings["BUS"].ConnectionString.ToString();
                SqlConnection conn = new SqlConnection(connstring);
                conn.Open();
                string qry = "Delete from CollectionMaster where Id=" + id ;
                SqlCommand cmd = new SqlCommand(qry, conn);
                cmd.ExecuteNonQuery();
                conn.Close();
                
                MessageBox.Show("Record Deleted");
                BlindData();
                gb1.Enabled = false;
                gb2.Enabled = false;
                gb3.Enabled = false;
                dtpfromdate.Select();
            }
            else
            {
                MessageBox.Show("Deletion Aborted");
            }
        }

        private void btclear_Click(object sender, EventArgs e)
        {
            BlindData();
            gb1.Enabled = false;
            gb2.Enabled = false;
            gb3.Enabled = false;
            dtpfromdate.Select();
        }

        private void dtpdate_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar.ToString() == "\r")
            {
                this.SelectNextControl(dtpdate, true, true, true, true);
            }
        }

        private void cbdrivername_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar.ToString() == "\r")
            {
                this.SelectNextControl(cbdrivername, true, true, true, true);
            }
        }

        private void cbconductorname_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar.ToString() == "\r")
            {
                this.SelectNextControl(cbconductorname, true, true, true, true);
            }
        }

        private void cbbusname_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar.ToString() == "\r")
            {
                this.SelectNextControl(cbbusname, true, true, true, true);
            }
        }

        private void tbcollection_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar.ToString() == "\r")
            {
                this.SelectNextControl(tbcollection, true, true, true, true);
            }

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

        private void tbdiesel_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar.ToString() == "\r")
            {
                this.SelectNextControl(tbdiesel, true, true, true, true);
            }

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

        private void tbbata_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar.ToString() == "\r")
            {
                this.SelectNextControl(tbDbata, true, true, true, true);
            }

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

        private void tbwages_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar.ToString() == "\r")
            {
                this.SelectNextControl(tbDwages, true, true, true, true);
            }

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

        private void tbcleaner_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar.ToString() == "\r")
            {
                this.SelectNextControl(tbcleaner, true, true, true, true);
            }

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

        private void tbstand_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar.ToString() == "\r")
            {
                this.SelectNextControl(tbstand, true, true, true, true);
         
            }

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

        private void tbgtc_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar.ToString() == "\r")
            {
                this.SelectNextControl(tbgtc, true, true, true, true);
            }

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

        private void tbpooja_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar.ToString() == "\r")
            {
                this.SelectNextControl(tbpooja, true, true, true, true);
            }

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

        private void tbextra_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar.ToString() == "\r")
            {
                this.SelectNextControl(tbextra, true, true, true, true);
            }

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

        private void tbgreese_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar.ToString() == "\r")
            {
                this.SelectNextControl(tbgreese, true, true, true, true);
            }

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

        private void tbsparse_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar.ToString() == "\r")
            {
                this.SelectNextControl(tbsparse, true, true, true, true);
            }

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


        private void tbStartKm_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar.ToString() == "\r")
            {
                this.SelectNextControl(tbStartKm, true, true, true, true);
            }

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


        private void tbEndKm_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar.ToString() == "\r")
            {
                this.SelectNextControl(tbEndKm, true, true, true, true);
            }

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

        private void btsave_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar.ToString() == "\r")
            {
                dtpfromdate.Select();
            }
        }

        private void tbMileage_TextChanged(object sender, EventArgs e)
        {
            string connstring = System.Configuration.ConfigurationManager.ConnectionStrings["BUS"].ConnectionString.ToString();
            SqlConnection conn = new SqlConnection(connstring);
            conn.Open();
            string qry = "Select * from MileageLimit M"
                            + " INNER JOIN BusMaster B ON M.BusId=B.Id"
                            + " Where  (M.MileageLower < " + Convert.ToDouble(tbMileage.Text) + " AND M.MileageUpper >= " + Convert.ToDouble(tbMileage.Text) + ") AND B.Name='" + cbbusname.SelectedItem.ToString() + "' AND M.Department='Driver'";
            SqlDataAdapter da = new SqlDataAdapter(qry, conn);
            DataSet ds = new DataSet();
            da.Fill(ds);
            conn.Close();
            int rowcount = ds.Tables[0].Rows.Count;
            if (rowcount == 0)
            {
                bonus = 0;
            }
            else
            {
                for (int count = 0; count < rowcount; count++)
                {
                    bonus = Convert.ToDouble(ds.Tables[0].Rows[count]["Bonus"]);
                }
            }
            //tbDwages.Text = (dwages + bonus).ToString();
            tbDwages.Text = (dwages + bonus).ToString();
            tbDwages.Text = Convert.ToDouble(tbDwages.Text).ToString("F");
            tbwages.Text = (Convert.ToDouble(tbDwages.Text) + Convert.ToDouble(tbCwages.Text)).ToString();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void lbtrip_Click(object sender, EventArgs e)
        {

        }

        private void Modifty_Enter(object sender, EventArgs e)
        {

        }

        private void tbpricelitrs_TextChanged(object sender, EventArgs e)
        {

        }

        
    }
}
