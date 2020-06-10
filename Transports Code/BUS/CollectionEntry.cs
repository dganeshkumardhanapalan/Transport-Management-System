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
    public partial class CollectionEntryModify : Form
    {
        int id = 0;
        bool IS_BATA_AUTO = Convert.ToBoolean(System.Configuration.ConfigurationManager.AppSettings["IS_BATA_AUTO"]);
        bool IS_WAGES_AUTO = Convert.ToBoolean(System.Configuration.ConfigurationManager.AppSettings["IS_WAGES_AUTO"]);
        bool IS_MILEAGE_AUTO = Convert.ToBoolean(System.Configuration.ConfigurationManager.AppSettings["IS_MILEAGE_AUTO"]);
        bool IS_DIESEL_AUTO = Convert.ToBoolean(System.Configuration.ConfigurationManager.AppSettings["IS_DIESEL_AUTO"]); 
        public CollectionEntryModify()
        {
            InitializeComponent();
        }

        string bata = "";
        double bonus = 0.0;
        double dwages = 0.0;
        double dBata = 0.0;
        double cwages = 0.0;
        double cBata = 0.0;
        private void btsave_Click(object sender, EventArgs e)
        {
            string[] lines = null;
            try
            {
                string licpath = Path.GetDirectoryName(Application.ExecutablePath) + "\\app.lic";
                lines = File.ReadAllLines(licpath);
            }
            catch (Exception ex)
            {
                MessageBox.Show("LIC File Missing. Contact Admin.");
            }
            DateTime todate = Convert.ToDateTime(CryptorEngine.Decrypt(lines[45], true));
            DateTime sysdate = DateTime.Now;

            bool isExpried = false;
            if (sysdate <= todate)
                isExpried = false;
            else
                isExpried = true;

            if (!isExpried)
            {
                try
                {
                    string connstring = System.Configuration.ConfigurationManager.ConnectionStrings["BUS"].ConnectionString.ToString();
                    SqlConnection conn = new SqlConnection(connstring);
                    conn.Open();
                    string qry = "insert into CollectionMaster values('" + dtpdate.Value.ToString("yyyy-MM-dd") + "','" + cbdrivername.SelectedItem.ToString() + "','" + cbconductorname.SelectedItem.ToString() + "','" + cbbusname.Text + "','" + int.Parse(cbtrip.SelectedItem.ToString()) + "','" + tbcollection.Text + "','" + tbdiesel.Text + "','" + tbpricelitrs.Text + "','" + tbdieselAmount.Text + "','" + tbStartKm.Text + "','" + tbEndKm.Text + "','" + tbbata.Text + "','" + "0.00','" + tbcleaner.Text + "','" + tbstand.Text + "','" + tbgtc.Text + "','" + tbpooja.Text + "','" + tbextra.Text + "','" + tbgreese.Text + "','" + tbsparse.Text + "','" + tbexpenses.Text + "','" + tbtotal.Text + "','"+tbnetcollection.Text+"','" + "0.00','" + tbDbata.Text + "','" + "0.00','" + tbCbata.Text + "','" + cbDriver2.SelectedItem.ToString() + "','" + cbConductor2.SelectedItem.ToString() + "','" + txtEveningCollection.Text + "','"+cbCompanyName.Text+"','"+tbMileage.Text+"')";
                    SqlCommand cmd = new SqlCommand(qry, conn);
                    cmd.ExecuteNonQuery();
                    conn.Close();
                    MessageBox.Show("Save Successfully");
                    clearoperation();
                    dtpdate.Select();
                }
                catch (Exception ex)
                {
                    if (ex.Message.IndexOf("IX_CollectionMaster") > 0)
                    {
                        MessageBox.Show("Already selected bus contain collection entry for selected date.");
                    }
                }
            }
            else
            {
                MessageBox.Show("LIC File is Expried. Contact Admin");
            }
        }

        private void tbdiesel_TextChanged(object sender, EventArgs e)
        {
            if (tbdiesel.Text != "")
            {
                tbdieselAmount.Text = (Convert.ToDouble(tbdiesel.Text) * Convert.ToDouble(tbpricelitrs.Text)).ToString("F");
            }
            else
            {
                tbdieselAmount.Text = "0.00";
                tbdiesel.Text = "0.00";
                tbdiesel.SelectionStart = 0;
                tbdiesel.SelectionLength = tbdiesel.Text.Length;
            }
            tbtotal.Text = (Convert.ToDouble(tbnetcollection.Text)-Convert.ToDouble(tbexpenses.Text)).ToString("F");
         }
        private void tbpricelitrs_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void clearoperation()
        {
            dtpdate.Value = DateTime.Now;
            cbdrivername.SelectedIndex = 0;
            cbconductorname.SelectedIndex = 0;
            cbtrip.SelectedIndex = 0;
            cbbusname.SelectedIndex = 0;
            tbcollection.Text = "0.00";
            txtEveningCollection.Text = "0.00";
            tbdiesel.Text = "0.00";
            tbCwages.Text = "0.00";
            tbDwages.Text = "0.00";
            tbCwages.Text = "0.00";
            tbDwages.Text = "0.00";
            tbwages.Text = "0.00";
            tbwages.Text = "0.00";
            tbcleaner.Text = "0.00";
            tbstand.Text = "0.00";
            tbgtc.Text = "0.00";
            tbpooja.Text = "0.00";
            tbextra.Text = "0.00";
            tbgreese.Text = "0.00";
            tbsparse.Text = "0.00";
            tbStartKm.Text = "0.00";
            tbEndKm.Text = "0.00";
            tbMileage.Text = "0.00";
            tbCwages.Text = "0.00";
            tbDwages.Text = "0.00";
            tbwages.Text = "0.00";
           // tbpricelitrs.Text = "0.00";
            tbdieselAmount.Text = "0.00";
            tbDbata.Text="0.00";
            tbDriverTotal.Text = "0.00";

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

        private void tbbata_Leave(object sender, EventArgs e)
        {

        }

        private void tbwages_Leave(object sender, EventArgs e)
        {
            if (tbwages.Text != "")
            {
                tbwages.Text = Convert.ToDouble(tbwages.Text).ToString("F");
            }
            else
            {
                tbwages.Text = "0.00";
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

        private void tbpooja_Leave(object sender, EventArgs e)
        {
            if (tbpooja.Text != "")
            {
                tbpooja.Text = Convert.ToDouble(tbpooja.Text).ToString("F");
            }
            else
            {
                tbwages.Text = "0.00";
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
                caltotal();
 string connstring = System.Configuration.ConfigurationManager.ConnectionStrings["BUS"].ConnectionString.ToString();

                if (IS_WAGES_AUTO)
                {
                    //tbDwages.Enabled = true;
                    //tbCwages.Enabled = true;
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
                    tbwages.Text = (dwages + cwages).ToString();
                }

           
              //  string connstring1 = General.CONNECTION_STRING;
                if (IS_BATA_AUTO)
                {
                    //tbCbata.Enabled = true;
                    //tbDbata.Enabled = true; 
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
                

                tbDriverTotal.Text=(Convert.ToDouble(tbDbata.Text) + Convert.ToDouble(tbDwages.Text)).ToString();
                tbConductorTotal.Text = (Convert.ToDouble(tbCbata.Text) + Convert.ToDouble(tbCwages.Text)).ToString();


            }
            catch (Exception)
            {

                MessageBox.Show("Invalid Data Format");
                tbcollection.Text = "0.00";
            }

        }

        private void caltotal()
        {
            tbtotal.Text = (Convert.ToDouble(tbcollection.Text) - (Convert.ToDouble(tbdieselAmount.Text) + Convert.ToDouble(tbbata.Text) + Convert.ToDouble(tbwages.Text) + Convert.ToDouble(tbcleaner.Text) + Convert.ToDouble(tbstand.Text) + Convert.ToDouble(tbgtc.Text) + Convert.ToDouble(tbpooja.Text) + Convert.ToDouble(tbextra.Text) + Convert.ToDouble(tbgreese.Text) + Convert.ToDouble(tbsparse.Text))).ToString("F"); 
        }
        private void expenses()
        {
            tbexpenses.Text = (Convert.ToDouble(tbdieselAmount.Text) + Convert.ToDouble(tbbata.Text) + Convert.ToDouble(tbwages.Text) + Convert.ToDouble(tbcleaner.Text) + Convert.ToDouble(tbstand.Text) + Convert.ToDouble(tbgtc.Text) + Convert.ToDouble(tbpooja.Text) + Convert.ToDouble(tbextra.Text) + Convert.ToDouble(tbgreese.Text) + Convert.ToDouble(tbsparse.Text)).ToString("F");
        }

        private void btclear_Click(object sender, EventArgs e)
        {
            clearoperation();
            dtpdate.Select();
        }

        private void CollectionEntry_Load(object sender, EventArgs e)
        {
            string filepath = Path.GetDirectoryName(Application.ExecutablePath).ToString() + General.DieselPrice;
            string[] str = File.ReadAllLines(filepath);
            if (IS_DIESEL_AUTO)
            {
                tbpricelitrs.Text = str[0]; 
            }
            if ((Convert.ToDouble(str[0]) <= 0.00) || str[0].Equals(""))
            {
                MessageBox.Show("Please Update Diesel Price in Master-->Diesel Pirce");
            }

            
            string filepath1 = Path.GetDirectoryName(Application.ExecutablePath).ToString() + General.Batapath;
            int trip = Convert.ToInt32(System.Configuration.ConfigurationManager.AppSettings["MAX_TRIP"]);
            string[] str1 = File.ReadAllLines(filepath1);
            bata = str1[0];
            for (int i = 1; i <= trip; i++)
            {
                string[] numbers = { i.ToString() };
                cbtrip.Items.AddRange(numbers);
            }
            cbtrip.SelectedIndex = 0;
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
            load_Companyname();
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
            qry = "select Id,Name FROM BusMaster";
            da = new SqlDataAdapter(qry, conn);
            ds = new DataSet();
            da.Fill(ds);
            conn.Close();
            rowcount = ds.Tables[0].Rows.Count;
            if (rowcount > 0)
            {
                cbbusname.DataSource = ds.Tables[0];
                cbbusname.ValueMember = "Id";
                cbbusname.DisplayMember = "Name";
            }
            else
            {
                cbbusname.DataSource = null;
                cbbusname.Items.Clear();
            }
            if (IS_DIESEL_AUTO==false)
            {
                tbdiesel.Enabled = true;
                tbpricelitrs.Enabled = true;
            }
            if (IS_BATA_AUTO == false)
            {
                
                tbDbata.Enabled = true;
                tbCbata.Enabled = true;

            }
            if (IS_WAGES_AUTO==false)
            {
                tbCwages.Enabled = true;
                tbDwages.Enabled = true;
            }
          }

        private void tbdieselAmount_TextChanged(object sender, EventArgs e)
        {
            expenses();
        }

        private void tbbata_TextChanged(object sender, EventArgs e)
        {
            if (tbbata.Text != "")
            {
                expenses();
                calcdriverandconductortotal();
            }
            else
            {
                tbbata.Text = "0.00";
                tbbata.SelectionStart = 0;
                tbbata.SelectionLength = tbbata.Text.Length;

            }
            tbtotal.Text = (Convert.ToDouble(tbnetcollection.Text) - Convert.ToDouble(tbexpenses.Text)).ToString("F");
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
        private void load_Companyname()
        {
            cbCompanyName.Items.Clear();
            string connstring = System.Configuration.ConfigurationManager.ConnectionStrings["BUS"].ConnectionString.ToString();
            SqlConnection conn = new SqlConnection(connstring);
            conn.Open();
            string qry = "select Id,CompanyName FROM CompanyName";
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
                cbCompanyName.DataSource = ds.Tables[0];
                cbCompanyName.ValueMember = "Id";
                cbCompanyName.DisplayMember = "CompanyName";
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

        private void calcdriverandconductortotal()
        {
            tbDriverTotal.Text = (Convert.ToDouble(tbDbata.Text) + Convert.ToDouble(tbDwages.Text)).ToString();
            tbConductorTotal.Text = (Convert.ToDouble(tbCbata.Text) + Convert.ToDouble(tbCwages.Text)).ToString();
            tbbata.Text = (Convert.ToDouble(tbDbata.Text) + Convert.ToDouble(tbCbata.Text)).ToString();
            tbwages.Text = (Convert.ToDouble(tbDwages.Text) + Convert.ToDouble(tbCwages.Text)).ToString();
        }
        private void tbwages_TextChanged(object sender, EventArgs e)
        {
            if (tbwages.Text != "")
            {
                expenses();
                calcdriverandconductortotal();
            }
            else
            {
                tbwages.Text = "0.00";
                tbwages.SelectionStart = 0;
                tbwages.SelectionLength = tbwages.Text.Length;
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
            tbtotal.Text = (Convert.ToDouble(tbnetcollection.Text) - Convert.ToDouble(tbexpenses.Text)).ToString("F");
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
            tbtotal.Text = (Convert.ToDouble(tbnetcollection.Text) - Convert.ToDouble(tbexpenses.Text)).ToString("F");
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
            tbtotal.Text = (Convert.ToDouble(tbnetcollection.Text) - Convert.ToDouble(tbexpenses.Text)).ToString("F");
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
            tbtotal.Text = (Convert.ToDouble(tbnetcollection.Text) - Convert.ToDouble(tbexpenses.Text)).ToString("F");
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
            tbtotal.Text = (Convert.ToDouble(tbnetcollection.Text) - Convert.ToDouble(tbexpenses.Text)).ToString("F");
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
            tbtotal.Text = (Convert.ToDouble(tbnetcollection.Text) - Convert.ToDouble(tbexpenses.Text)).ToString("F");
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
            tbtotal.Text = (Convert.ToDouble(tbnetcollection.Text) - Convert.ToDouble(tbexpenses.Text)).ToString("F");
        }

        private void tbnetcollection_TextChanged(object sender, EventArgs e)
        {
            caltotal();
        }

        private void tbexpenses_TextChanged(object sender, EventArgs e)
        {
            caltotal();
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

        private void tbbata_KeyPress(object sender, KeyPressEventArgs e)
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
            if (e.KeyChar.ToString() == "\r")
            {
                this.SelectNextControl(tbbata, true, true, true, true);
            }
        }

        private void tbwages_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar.ToString() == "\r")
            {
                this.SelectNextControl(tbwages, true, true, true, true);
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
        }

        private void tbEndKm_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar.ToString() == "\r")
            {
                this.SelectNextControl(tbEndKm, true, true, true, true);
            }
        }

        private void cbdrivername_SelectedIndexChanged(object sender, EventArgs e)
        {
            string connstring = System.Configuration.ConfigurationManager.ConnectionStrings["BUS"].ConnectionString.ToString();
            SqlConnection conn = new SqlConnection(connstring);
            conn.Open();
            string qry = "select * FROM EmployeeMaster where Name='" + cbdrivername.SelectedItem + "'";
            SqlDataAdapter da = new SqlDataAdapter(qry, conn);
            DataSet ds = new DataSet();
            da.Fill(ds);
            conn.Close();
            int rowcount = ds.Tables[0].Rows.Count;
            if (rowcount == 0)
            {
                // cleareditformvalue();
            }
            else
            {

                if (rowcount > 0)
                {
                    if (ds.Tables[0].Rows[0]["LImage"] != DBNull.Value)
                    {
                        byte[] barrImg = (byte[])ds.Tables[0].Rows[0]["LImage"];
                        string strfn = Convert.ToString(DateTime.Now.ToFileTime())+".im";
                        FileStream fs = new FileStream(strfn, FileMode.CreateNew, FileAccess.Write);
                        fs.Write(barrImg, 0, barrImg.Length);
                        fs.Flush();
                        fs.Close();

                        picboxdriver.Image = Image.FromFile(strfn);
                    }

                }


            }
        }

        private void cbconductorname_SelectedIndexChanged(object sender, EventArgs e)
        {
            string connstring = System.Configuration.ConfigurationManager.ConnectionStrings["BUS"].ConnectionString.ToString();
            SqlConnection conn = new SqlConnection(connstring);
            conn.Open();
            string qry = "select * FROM EmployeeMaster where Name='" + cbconductorname.SelectedItem + "'";
            SqlDataAdapter da = new SqlDataAdapter(qry, conn);
            DataSet ds = new DataSet();
            da.Fill(ds);
            conn.Close();
            int rowcount = ds.Tables[0].Rows.Count;
            if (rowcount == 0)
            {
                // cleareditformvalue();
            }
            else
            {

                if (rowcount > 0)
                {
                    if (ds.Tables[0].Rows[0]["LImage"] != DBNull.Value)
                    {
                        byte[] barrImg = (byte[])ds.Tables[0].Rows[0]["LImage"];
                        string strfn = Convert.ToString(DateTime.Now.ToFileTime());
                        FileStream fs = new FileStream(strfn, FileMode.CreateNew, FileAccess.Write);
                        fs.Write(barrImg, 0, barrImg.Length);
                        fs.Flush();
                        fs.Close();

                        picboxconductor.Image = Image.FromFile(strfn);
                    }

                }


            }
        }

        private void cbbusname_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void tbMileage_TextChanged(object sender, EventArgs e)
        {

            if (IS_MILEAGE_AUTO)
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
                    bonus = 0.0;
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
        }

        private void label38_Click(object sender, EventArgs e)
        {

        }

        private void tbEndKm_Validated(object sender, EventArgs e)
        {

        }

        private void lbtrip_Click(object sender, EventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void tbpricelitrs_TextChanged_1(object sender, EventArgs e)
        {
            if (tbpricelitrs.Text != "")
            {
                tbdieselAmount.Text = (Convert.ToDouble(tbdiesel.Text) * Convert.ToDouble(tbpricelitrs.Text)).ToString("F");
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
        int  rowcount = ds.Tables[0].Rows.Count;
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

        private void txtEveningCollection_TextChanged(object sender, EventArgs e)
        {
            if (txtEveningCollection.Text != "")
            {
                tbnetcollection.Text = (Convert.ToDouble(tbcollection.Text)+(Convert.ToDouble(txtEveningCollection.Text))).ToString();
            }
            else
            {
                txtEveningCollection.Text = "0.00";
                txtEveningCollection.SelectionStart = 0;
                txtEveningCollection.SelectionLength = txtEveningCollection.Text.Length;
            }
            tbtotal.Text = (Convert.ToDouble(tbcollection.Text) + Convert.ToDouble(txtEveningCollection.Text)).ToString();
           
        }

        private void cbtrip_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void tbtotal_TextChanged(object sender, EventArgs e)
        {

        }

        private void cbCompanyName_SelectionChangeCommitted(object sender, EventArgs e)
        {
            string connstring = System.Configuration.ConfigurationManager.ConnectionStrings["BUS"].ConnectionString.ToString();
            SqlConnection conn = new SqlConnection(connstring);
            
            conn.Open();
            string qry = "select Id,Name From BusMaster Where CompanyId='"+cbCompanyName.SelectedValue +"'";
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
                cbbusname.DataSource = ds.Tables[0];
                cbbusname.ValueMember = "Id";
                cbbusname.DisplayMember = "Name";
            }

        }

        private void cbbusname_TextChanged(object sender, EventArgs e)
        {
            string connstring = System.Configuration.ConfigurationManager.ConnectionStrings["BUS"].ConnectionString.ToString();
            SqlConnection conn = new SqlConnection(connstring);

            conn.Open();
           if(cbbusname.SelectedIndex==1)
           {
               label6.Visible = false;
               label41.Visible = false;
               tbcleaner.Visible = false;
               tbCbata.Visible = false;
               label40.Visible = false;
               label32.Visible = false;
               txtEveningCollection.Visible = false;
               label62.Visible = false;
               label61.Visible = false;
               cbConductor2.Visible = false;
               label57.Visible = false;
               label59.Visible = false;
               label60.Visible = false;
               label58.Visible = false;
               cbDriver2.Visible = false;
            }
            else
            {
              //  cbDriver2.Visible = false;
            }
           
            conn.Close();
        }
    }

}

    

       