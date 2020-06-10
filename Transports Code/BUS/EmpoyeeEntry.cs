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
    public partial class EmpoyeeEntry : Form
    {
        public EmpoyeeEntry()
        {
            InitializeComponent();
        }

        private byte[] convertPicBoxImageToByte(System.Windows.Forms.PictureBox pbImage)
        {
            System.IO.MemoryStream ms = new System.IO.MemoryStream();
            pbImage.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
            return ms.ToArray();
        }

        private void btsave_Click(object sender, EventArgs e)
        {
            if(cbCompanyName.SelectedIndex==0)
            {
                MessageBox.Show("Select Company Name");
            }
             else if(tbname.Text=="")
            {
                MessageBox.Show("Enter Employee Name");
            }
            else if(tbaddress.Text=="")
            {
                MessageBox.Show("Enter the Address");
            }
            else if(tbcity.Text=="")
            {
                MessageBox.Show("Enter the City");
            }
            else if(tbmobile.Text=="")
            {
                MessageBox.Show("Enter the mobile");
            }
            else if(tbage.Text=="")
            {
                MessageBox.Show("Enter the Age");
            }
            else if(tbdlno.Text=="")
            {
                MessageBox.Show("Enter the DI Number");
            }
            try
            {
                if (cbdepartment.SelectedIndex > 0)
                {
                    // LOAD IMAGE
                    string strFn = openfdadd.FileName;
                    if (strFn != "openFileDialog1")
                    {

                        byte[] m_barrImg = convertPicBoxImageToByte(picboxadd);
                        //this.pictureBox1.Image = Image.FromFile(strFn);
                        //FileInfo fiImage = new FileInfo(strFn);
                        //long m_lImageFileLength = fiImage.Length;
                        //FileStream fs = new FileStream(strFn, FileMode.Open, FileAccess.Read, FileShare.Read);
                        //byte[] m_barrImg = new byte[Convert.ToInt32(m_lImageFileLength)];
                        //int iBytesRead = fs.Read(m_barrImg, 0, Convert.ToInt32(m_lImageFileLength));
                        //fs.Close();

                        string connstring = System.Configuration.ConfigurationManager.ConnectionStrings["BUS"].ConnectionString.ToString();
                        SqlConnection conn = new SqlConnection(connstring);
                        conn.Open();
                        string qry = "insert into EmployeeMaster values('" + tbname.Text + "','" + tbaddress.Text + "','" + tbcity.Text + "','" + tbmobile.Text + "','" + tbage.Text + "','" + tbdlno.Text + "','" + cbdepartment.SelectedItem + "',@image ,'" + cbCompanyName.Text + "')";

                        SqlCommand cmd = new SqlCommand(qry, conn);
                        cmd.Parameters.Add("@image", System.Data.SqlDbType.Image);
                        cmd.Parameters["@image"].Value = m_barrImg;
                        cmd.ExecuteNonQuery();
                        conn.Close();
                        MessageBox.Show("Save Successfully");
                        clearbox();
                    }
                    else
                    {
                        MessageBox.Show("Select Picture");
                    }
                }
                else
                {
                    MessageBox.Show("Selete Department");
                }
            }
            catch (Exception ex)
            {
                
                 string msg = General.DUPLICATE;
                int count = 0;
                if (ex.Message.IndexOf("IX_EmployeeMaster") > 0)
                {
                    count++;
                    msg += "Employee Name";
                }
                
                if (count > 0)
                {
                    MessageBox.Show(msg);
                }
                else
                {
                    MessageBox.Show(General.UN_SUCCESS_MSG);
                }
            }
        }

        private void clearbox()
        {

            cbCompanyName.SelectedIndex = 0;
            tbname.Text = "";
            tbaddress.Text = "";
            tbcity.Text = "";
            tbmobile.Text = "";
            tbage.Text = "";
            tbdlno.Text = "";
            cbdepartment.SelectedIndex = 0;

        }

        private void btclear_Click(object sender, EventArgs e)
        {
            clearbox();
        }

        private void tabControl1_Selected(object sender, TabControlEventArgs e)
        {
            switch ((sender as TabControl).SelectedIndex)
            {
                case 0: loadcomboboxadd();
                    break;
                case 1: loadcombobox();
                    break;
                case 2: loaddeletecombobox();
                    break;
            }
        }

        private void loadcomboboxadd()
        {
            cbdepartment.Items.Clear();
            cbdepartment.Items.Insert(0, "-Select-");
            cbdepartment.Items.Insert(1, "Driver");
            cbdepartment.Items.Insert(2, "Conductor");
            cbdepartment.SelectedIndex = 0;

        }

        private void loadcombobox()
        {
            cbeditdepartment.Items.Clear();
            cbeditdepartment.Items.Insert(0, "-Select-");
            cbeditdepartment.Items.Insert(1, "Driver");
            cbeditdepartment.Items.Insert(2, "Conductor");
            cbeditdepartment.SelectedIndex = 0;

            cbnamelist.Items.Clear();
            string connstring = System.Configuration.ConfigurationManager.ConnectionStrings["BUS"].ConnectionString.ToString();
            SqlConnection conn = new SqlConnection(connstring);
            conn.Open();
            string qry = "select * FROM EmployeeMaster";
            SqlDataAdapter da = new SqlDataAdapter(qry, conn);
            DataSet ds = new DataSet();
            da.Fill(ds);
            conn.Close();
            int rowcount = ds.Tables[0].Rows.Count;
            if (rowcount == 0)
            {
                cleareditformvalue();
            }
            else
            {
                for (int count = 0; count < rowcount; count++)
                {
                    cbnamelist.Items.Insert(count, Convert.ToString(ds.Tables[0].Rows[count]["Name"]).Trim());
                }
            }

            if (rowcount > 0)
            {
                cbnamelist.SelectedIndex = 0;
            }

        }
        private void cleardeleteformvalue()
        {
            cbdeleterecord.Items.Clear();
            cbdeleterecord.Items.Insert(0, "No Record");
            cbdeleterecord.SelectedIndex = 0;
            tbdelname.Text = "";
            tbdeladdress.Text = "";
            tbdelcity.Text = "";
            tbdelmobile.Text = "";
            tbdelage.Text = "";
            tbdeldlno.Text = "";
            tbdeldepartment.Text = "";

        }
        private void loaddeletecombobox()
        {
            cbdeleterecord.Items.Clear();
            string connstring = System.Configuration.ConfigurationManager.ConnectionStrings["BUS"].ConnectionString.ToString();
            SqlConnection conn = new SqlConnection(connstring);
            conn.Open();
            string qry = "select * FROM EmployeeMaster";
            SqlDataAdapter da = new SqlDataAdapter(qry, conn);
            DataSet ds = new DataSet();
            da.Fill(ds);
            conn.Close();
            int rowcount = ds.Tables[0].Rows.Count;
            if (rowcount == 0)
            {
                cleardeleteformvalue();
            }
            else
            {
                for (int count = 0; count < rowcount; count++)
                {
                    cbdeleterecord.Items.Insert(count, Convert.ToString(ds.Tables[0].Rows[count]["Name"]).Trim());
                }
            }
            if (rowcount>0)
            {
                cbdeleterecord.SelectedIndex = 0;
            }
        }

        private void cleareditformvalue()
        {
            cbnamelist.Items.Clear();
            cbnamelist.Items.Insert(0, "No Record");
            cbnamelist.SelectedIndex = 0;
            tbeditname.Text = "";
            tbeditaddress.Text = "";
            tbeditcity.Text ="";
            tbeditmobile.Text = "";
            tbeditage.Text = "";
            tbeditdlno.Text = "";
            cbeditdepartment.SelectedIndex = 0;

        }

        private void cbnamelist_SelectedIndexChanged(object sender, EventArgs e)
        {
            string connstring = System.Configuration.ConfigurationManager.ConnectionStrings["BUS"].ConnectionString.ToString();
            SqlConnection conn = new SqlConnection(connstring);
            conn.Open();
            string qry = "select * FROM EmployeeMaster where Name='"+cbnamelist.SelectedItem+"'";
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
                    tbeditname.Text = Convert.ToString(ds.Tables[0].Rows[0]["Name"]).Trim();
                    tbeditaddress.Text = Convert.ToString(ds.Tables[0].Rows[0]["Address"]).Trim();
                    tbeditcity.Text = Convert.ToString(ds.Tables[0].Rows[0]["City"]).Trim();
                    tbeditmobile.Text = Convert.ToString(ds.Tables[0].Rows[0]["Mobile"]).Trim();
                    tbeditage.Text = Convert.ToString(ds.Tables[0].Rows[0]["Age"]).Trim();
                    tbeditdlno.Text = Convert.ToString(ds.Tables[0].Rows[0]["DlNo"]).Trim();
                    string dep = Convert.ToString(ds.Tables[0].Rows[0]["Department"]).Trim();

                    if (ds.Tables[0].Rows[0]["LImage"] != DBNull.Value)
                    {
                        byte[] barrImg = (byte[])ds.Tables[0].Rows[0]["LImage"];
                        string strfn = Convert.ToString(DateTime.Now.ToFileTime()) + ".im";
                        FileStream fs = new FileStream(strfn, FileMode.CreateNew, FileAccess.Write);
                        fs.Write(barrImg, 0, barrImg.Length);
                        fs.Flush();
                        fs.Close();

                        picboxedit.Image = Image.FromFile(strfn);
                    }

                    if (dep == "Driver")
                    {
                        cbeditdepartment.SelectedIndex = 1;
                    }
                    else if (dep == "Conductor")
                    {
                        cbeditdepartment.SelectedIndex = 2;
                    }
                }
            }
    
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (cbnamelist.SelectedItem.ToString() != "No Record")
            {
                btmodify.Enabled = false;
                cbnamelist.Enabled = false;
                tbeditname.Enabled = true;
                tbeditaddress.Enabled = true;
                tbeditcity.Enabled = true;
                tbeditmobile.Enabled = true;
                tbeditage.Enabled = true;
                tbeditdlno.Enabled = true;
                btupdate.Enabled = true;
                btcancel.Enabled = true;
                btBrowseedit.Enabled = true;
                
                cbeditdepartment.Enabled = true;
            }
            else
            {
                MessageBox.Show("No Recoerd to Modify");
            }
        }

        private void btupdate_Click(object sender, EventArgs e)
        {
            if (cbeditdepartment.SelectedIndex > 0)
            {
                if (tbeditname.Text == "")
                {
                    MessageBox.Show("Enter the Employee Name");
                    return;
                }
           
                byte[] m_barrImg = convertPicBoxImageToByte(picboxedit);

                string connstring = System.Configuration.ConfigurationManager.ConnectionStrings["BUS"].ConnectionString.ToString();
                SqlConnection conn = new SqlConnection(connstring);
                conn.Open();
                string qry = "update EmployeeMaster set Name='" + tbeditname.Text + "',Address='" + tbeditaddress.Text + "',City='" + tbeditcity.Text + "',Mobile='" + tbeditmobile.Text + "',Age='" + tbeditage.Text + "',DlNo='" + tbeditdlno.Text + "',Department='" + cbeditdepartment.SelectedItem + "',LImage= @Image" + " where Name='" + cbnamelist.SelectedItem + "'";
                SqlCommand cmd = new SqlCommand(qry, conn);
                cmd.Parameters.Add("@Image", System.Data.SqlDbType.Image);
                cmd.Parameters["@Image"].Value = m_barrImg;
                cmd.ExecuteNonQuery();
                conn.Close();
                MessageBox.Show("Update Completed");

                btmodify.Enabled = true;
                cbnamelist.Enabled = true;
                tbeditname.Enabled = false;
                tbeditaddress.Enabled = false;
                tbeditcity.Enabled = false;
                tbeditmobile.Enabled = false;
                tbeditage.Enabled = false;
                tbeditdlno.Enabled = false;
                btupdate.Enabled = false;
                btcancel.Enabled = false;
                btBrowseedit.Enabled = false;
                
                cbeditdepartment.Enabled = false;
                loadcombobox();
            }
            else
            {
                MessageBox.Show("Select Department");
            }
        }

        private void load_CompanyName()
        {
            cbCompanyName.Items.Clear();
            string connstring = System.Configuration.ConfigurationManager.ConnectionStrings["BUS"].ConnectionString.ToString();
            SqlConnection conn = new SqlConnection(connstring);
            conn.Open();
            string qry = "select '0' as Id,'--Select Company--' as CompanyName Union Select Id,CompanyName FROM CompanyName";
            SqlDataAdapter da = new SqlDataAdapter(qry, conn);
            DataSet ds = new DataSet();
            da.Fill(ds);
            conn.Close();
            int rowcount = ds.Tables[0].Rows.Count;
            if (rowcount == 0)
            {
                MessageBox.Show("No CompanyName Record Found");
            }
            else
            {
                for (int count = 0; count < rowcount; count++)
                {
                    cbCompanyName.Items.Insert(count, Convert.ToString(ds.Tables[0].Rows[count]["CompanyName"]).Trim());
                }
                cbCompanyName.SelectedIndex = 0;
            }
        }
        private void btcancel_Click(object sender, EventArgs e)
        {
            string connstring = System.Configuration.ConfigurationManager.ConnectionStrings["BUS"].ConnectionString.ToString();
            SqlConnection conn = new SqlConnection(connstring);
            conn.Open();
            string qry = "select * FROM EmployeeMaster where Name='" + cbnamelist.SelectedItem + "'";
            SqlDataAdapter da = new SqlDataAdapter(qry, conn);
            DataSet ds = new DataSet();
            da.Fill(ds);
            conn.Close();
            int rowcount = ds.Tables[0].Rows.Count;
            if (rowcount > 0)
            {
                tbeditname.Text = Convert.ToString(ds.Tables[0].Rows[0]["Name"]).Trim();
                tbeditaddress.Text = Convert.ToString(ds.Tables[0].Rows[0]["Address"]).Trim();
                tbeditcity.Text = Convert.ToString(ds.Tables[0].Rows[0]["City"]).Trim();
                tbeditmobile.Text = Convert.ToString(ds.Tables[0].Rows[0]["Mobile"]).Trim();
                tbeditage.Text = Convert.ToString(ds.Tables[0].Rows[0]["Age"]).Trim();
                tbeditdlno.Text = Convert.ToString(ds.Tables[0].Rows[0]["DlNo"]).Trim();
            }

            btmodify.Enabled = true;
            cbnamelist.Enabled = true;
            tbeditname.Enabled = false;
            tbeditaddress.Enabled = false;
            tbeditcity.Enabled = false;
            tbeditmobile.Enabled = false;
            tbeditage.Enabled = false;
            tbeditdlno.Enabled = false;
            btupdate.Enabled = false;
            btcancel.Enabled = false;
            btBrowseedit.Enabled = false;
            cbeditdepartment.Enabled = false;
        }

        private void btdelete_Click(object sender, EventArgs e)
        {
            if (cbdeleterecord.SelectedItem.ToString() != "No Record")
            {
                if (MessageBox.Show("Really delete?", "Confirm delete", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    string connstring = System.Configuration.ConfigurationManager.ConnectionStrings["BUS"].ConnectionString.ToString();
                    SqlConnection conn = new SqlConnection(connstring);
                    conn.Open();
                    string qry = "Delete from EmployeeMaster where Name='" + cbdeleterecord.SelectedItem + "'";
                    SqlCommand cmd = new SqlCommand(qry, conn);
                    cmd.ExecuteNonQuery();
                    conn.Close();
                    loaddeletecombobox();
                    MessageBox.Show("Record Deleted");
                }
                else
                {
                    MessageBox.Show("Deletion Aborted");
                }
            }
            else
            {
                MessageBox.Show("No Record to Delete");
            }
        
        }

        

        private void EntryDriver_Load(object sender, EventArgs e)
        {
            loadcomboboxadd();
            load_CompanyName();
            if (!General.Is_Delete)
                btdelete.Enabled = false;
            else
                btdelete.Enabled = true;
            if (!General.Is_Edit)
                btmodify.Enabled = false;
            else
                btmodify.Enabled = true;
        }

        private void cbdeleterecord_SelectedIndexChanged(object sender, EventArgs e)
        {
            string connstring = System.Configuration.ConfigurationManager.ConnectionStrings["BUS"].ConnectionString.ToString();
            SqlConnection conn = new SqlConnection(connstring);
            conn.Open();
            string qry = "select * FROM EmployeeMaster where Name='" + cbdeleterecord.SelectedItem + "'";
            SqlDataAdapter da = new SqlDataAdapter(qry, conn);
            DataSet ds = new DataSet();
            da.Fill(ds);
            conn.Close();
            int rowcount = ds.Tables[0].Rows.Count;
            if (rowcount > 0)
            {
                tbdelname.Text = Convert.ToString(ds.Tables[0].Rows[0]["Name"]).Trim();
                tbdeladdress.Text = Convert.ToString(ds.Tables[0].Rows[0]["Address"]).Trim();
                tbdelcity.Text = Convert.ToString(ds.Tables[0].Rows[0]["City"]).Trim();
                tbdelmobile.Text = Convert.ToString(ds.Tables[0].Rows[0]["Mobile"]).Trim();
                tbdelage.Text = Convert.ToString(ds.Tables[0].Rows[0]["Age"]).Trim();
                tbdeldlno.Text = Convert.ToString(ds.Tables[0].Rows[0]["DlNo"]).Trim();
                tbdeldepartment.Text = Convert.ToString(ds.Tables[0].Rows[0]["Department"]).Trim();
            }
        }



        private void button5_Click(object sender, EventArgs e)
        {
            DialogResult result = openfdadd.ShowDialog();
            if (result == DialogResult.OK) // Test result.
            {
                picboxadd.Image = Image.FromFile(openfdadd.FileName);
            }
            else
            {
                MessageBox.Show("Select File");
            }
        }

        

        private void btBrowseedit_Click(object sender, EventArgs e)
        {
            DialogResult result = openfdedit.ShowDialog();
            if (result == DialogResult.OK) // Test result.
            {
                picboxedit.Image = Image.FromFile(openfdedit.FileName);
            }
            else
            {
                MessageBox.Show("Select File");
            }
        }

        private void openfdadd_FileOk(object sender, CancelEventArgs e)
        {

        }

        private void label33_Click(object sender, EventArgs e)
        {

        }

        private void tbmobile_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }

        private void tbage_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {  
                e.Handled = true;
            }
        }

        private void tbeditmobile_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }

        private void tbeditage_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }






      
    }
}
