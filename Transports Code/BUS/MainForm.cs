using System;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;
using System.Collections.Specialized;
using System.Net;

namespace BUS
{
    public partial class MainForm : Form
    {
        bool IS_BATA_AUTO = Convert.ToBoolean(System.Configuration.ConfigurationManager.AppSettings["IS_BATA_AUTO"]);
        bool IS_WAGES_AUTO = Convert.ToBoolean(System.Configuration.ConfigurationManager.AppSettings["IS_WAGES_AUTO"]);
        bool IS_MILEAGE_AUTO = Convert.ToBoolean(System.Configuration.ConfigurationManager.AppSettings["IS_MILEAGE_AUTO"]);
        bool IS_DIESEL_AUTO = Convert.ToBoolean(System.Configuration.ConfigurationManager.AppSettings["IS_DIESEL_AUTO"]);
        int count = 0;
        string connstring = System.Configuration.ConfigurationManager.ConnectionStrings["BUS"].ConnectionString.ToString();
        string todayDate = DateTime.Now.ToString("yyyy-MM-dd");
        public MainForm()
        {

            InitializeComponent();


        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void driverToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EmpoyeeEntry newMDIChild = new EmpoyeeEntry();
            newMDIChild.MdiParent = this;
            newMDIChild.Show();
        }


        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {


        }

        private string OilAlert()
        {
            string msg = string.Empty;
            SqlConnection conn = new SqlConnection(connstring);
            conn.Open();
            string qry = "";
            qry = "select * from BusMaster order By Id";
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(qry, conn);
            da.Fill(ds);
            conn.Close();

            int rowcount = ds.Tables[0].Rows.Count;
            if (rowcount > 0)
            {
                string Message = string.Empty;
                for (int i = 0; i < (ds.Tables[0].Rows.Count); i++)
                {
                    string id = Convert.ToString(ds.Tables[0].Rows[i]["Id"]);
                    string[] serviceTypes = { "Engine Oil", "Gier Oil", "Crown Oil", "Steering Box" };
                    foreach (string serviceType in serviceTypes)
                    {
                        msg = msg + getOilAlertById(id, serviceType);
                    }
                }
            }

            return msg;
        }

        private string getOilAlertById(string Id, string serviceType)
        {
            string msg = string.Empty;

            SqlConnection conn = new SqlConnection(connstring);
            conn.Open();
            string qry = "";
            qry = "OilServiceAlert " + Id + ",'" + serviceType + "'";
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(qry, conn);
            da.Fill(ds);
            conn.Close();

            int rowcount = ds.Tables[0].Rows.Count;
            if (rowcount > 0)
            {
                string Message = string.Empty;
                for (int i = 0; i < (ds.Tables[0].Rows.Count); i++)
                {
                    string BusName = Convert.ToString(ds.Tables[0].Rows[i]["BusName"]);
                    string IsSentSMS = Convert.ToString(ds.Tables[0].Rows[i]["IsSentSMS"]);
                    if (IsSentSMS == "1")
                    {
                        msg = msg + BusName + " - " + serviceType + "\r\n";
                    }
                }
            }
            return msg;
        }

        private void send_Sms()
        {
            string Message = string.Empty;
            SqlConnection conn = new SqlConnection(connstring);
            conn.Open();
            string qry = "";
            qry = "SELECT LastDate,ReminderDate,ScheduleType+'-'+Name+'-'+RegNo AS Name,Color FROM ScheduleMaster S INNER JOIN BusMaster B ON S.BusMaster_ID = B.ID INNER JOIN ScheduleType ST On ST.ID = S.Type_ID Where S.ReminderDate='" + todayDate + "'";
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(qry, conn);
            da.Fill(ds);
            conn.Close();

            int rowcount = ds.Tables[0].Rows.Count;
            if (rowcount > 0)
            {
                for (int i = 0; i < (ds.Tables[0].Rows.Count); i++)
                {
                    Message = Message + Convert.ToString(ds.Tables[0].Rows[i]["Name"]).Trim() + "\r\n";
                }
                Message = Message + OilAlert();
            }
            else
            {
                Message = Message + OilAlert();
            }

            string responseString = string.Empty;
            string smsNumberPath = Path.GetDirectoryName(Application.ExecutablePath).ToString() + General.smsContact;
            string[] num = File.ReadAllLines(smsNumberPath);
            string _contactNumber = string.Empty;
            if (num.Length > 0)
                _contactNumber = num[0];

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

            string url = CryptorEngine.Decrypt(lines[46], true);
            string isEnable = CryptorEngine.Decrypt(lines[47], true);

            if (isEnable != "true")
            {
                smsNumberToolStripMenuItem.Visible = false;
            }

            using (var client = new WebClient())
            {
                var values = new NameValueCollection();
                if (isEnable == "true")
                {
                    url = url.Replace("[MobileNumber]", _contactNumber);
                    url = url.Replace("[Message]", "Customer, " + Message);
                    var response = client.UploadValues(url, values);
                    responseString = Encoding.Default.GetString(response);
                }
            }

            string filepath = Path.GetDirectoryName(Application.ExecutablePath).ToString() + General.smsCount;
            File.WriteAllText(filepath, todayDate);

        }
        private void MainForm_Load(object sender, EventArgs e)
        {
            // Getting Sms Contact Number From Path
            string smsNumberPath = Path.GetDirectoryName(Application.ExecutablePath).ToString() + General.smsContact;
            string[] num = File.ReadAllLines(smsNumberPath);
            string numpath = string.Empty;
            if (num.Length > 0)
                numpath = num[0];


            string filepath = Path.GetDirectoryName(Application.ExecutablePath).ToString() + General.smsCount;
            string[] str = File.ReadAllLines(filepath);
            string path = string.Empty;
            if (str.Length > 0)
                path = str[0];

            if (todayDate != path)
            {
                //send_Sms();
            }

            ScheduleReportForm newMDIChild = new ScheduleReportForm();
            newMDIChild.MdiParent = this;
            newMDIChild.Show();
            if (IS_BATA_AUTO == false)
            {
                wagesLimitSettingToolStripMenuItem1.Visible = false;
            }
            if (IS_MILEAGE_AUTO == false)
            {
                mileageLimitSettingToolStripMenuItem.Visible = false;
            }
            if (IS_WAGES_AUTO == false)
            {
                wagesLimitSettingToolStripMenuItem.Visible = false;
            }
            if (IS_DIESEL_AUTO == false)
            {
                dieselPriceToolStripMenuItem.Visible = false;
            }
        }

        private void busToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BusEntry newMDIChild = new BusEntry();
            newMDIChild.MdiParent = this;
            newMDIChild.Show();
        }

        private void collectionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string filepath = Path.GetDirectoryName(Application.ExecutablePath).ToString() + General.DieselPrice;
            string[] str = File.ReadAllLines(filepath);
            if ((Convert.ToDouble(str[0]) <= 0.00) || str[0].Equals(""))
            {
                MessageBox.Show("Please Update Diesel Price in Master-->Diesel Pirce");
            }
            else
            {
                CollectionEntryModify newMDIChild = new CollectionEntryModify();
                newMDIChild.MdiParent = this;
                newMDIChild.Show();
            }
        }

        private void driverReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DriverReport newMDIChild = new DriverReport();
            newMDIChild.MdiParent = this;
            newMDIChild.Show();

        }

        private void conductorReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ConductorReport newMDIChild = new ConductorReport();
            newMDIChild.MdiParent = this;
            newMDIChild.Show();
        }

        private void busReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BusReport newMDIChild = new BusReport();
            newMDIChild.MdiParent = this;
            newMDIChild.Show();
        }

        private void scheduleEntryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Schedule newMDIChild = new Schedule();
            newMDIChild.MdiParent = this;
            newMDIChild.Show();
        }

        private void viewScheduleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ScheduleReportForm newMDIChild = new ScheduleReportForm();
            newMDIChild.MdiParent = this;
            newMDIChild.Show();
        }

        private void collectionReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CollectionReport newMDIChild = new CollectionReport();
            newMDIChild.MdiParent = this;
            newMDIChild.Show();
        }

        private void abountToolStripMenuItem_Click(object sender, EventArgs e)
        {
            About newMDIChild = new About();
            newMDIChild.MdiParent = this;
            newMDIChild.Show();
        }

        private void dayReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DayCollectionReport newMDIChild = new DayCollectionReport();
            newMDIChild.MdiParent = this;
            newMDIChild.Show();
        }

        private void dieselPriceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DieselEntry newMDIChild = new DieselEntry();
            newMDIChild.MdiParent = this;
            newMDIChild.Show();
        }

        private void bataToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Bata newMDIChild = new Bata();
            newMDIChild.MdiParent = this;
            newMDIChild.Show();
        }

        private void editCollectionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string filepath = Path.GetDirectoryName(Application.ExecutablePath).ToString() + General.DieselPrice;
            string[] str = File.ReadAllLines(filepath);
            if ((Convert.ToDouble(str[0]) <= 0.00) || str[0].Equals(""))
            {
                MessageBox.Show("Please Update Diesel Price in Master-->Diesel Pirce");
            }
            else
            {
                CollectionModify newMDIChild = new CollectionModify();
                newMDIChild.MdiParent = this;
                newMDIChild.Show();
            }
        }



        private void fileToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void backupToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmBackup newMDIChild = new frmBackup();
            newMDIChild.MdiParent = this;
            newMDIChild.Show();
        }

        private void scheduleTypeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmScheduleTypeEntry newMDIChild = new frmScheduleTypeEntry();
            newMDIChild.MdiParent = this;
            newMDIChild.Show();
        }

        private void scheduleReportToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            string[] filePaths = Directory.GetFiles(Path.GetDirectoryName(Application.ExecutablePath).ToString(), "*.im");
            foreach (string f in filePaths)
            {
                try
                {
                    File.Delete(f);
                }
                catch (Exception ex)
                {
                }
            }
            
            string filepath = Path.GetDirectoryName(Application.ExecutablePath).ToString() + General.BackupPath;
            string[] str = File.ReadAllLines(filepath);
            string path = str[0];
            string connstring = System.Configuration.ConfigurationManager.ConnectionStrings["BUS"].ConnectionString.ToString();
            SqlConnection conn = new SqlConnection(connstring);
            conn.Open();
            string qry = "BACKUP DATABASE [TransportSMS] TO  DISK = N'" + path + "' WITH NOFORMAT, INIT,  NAME = N'Transport-Full Database Backup', SKIP, NOREWIND, NOUNLOAD,  STATS = 10";
            SqlCommand cmd = new SqlCommand(qry, conn);
            cmd.ExecuteNonQuery();
            conn.Close();
            Application.Exit();
        }

        private void monthlyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            crvScheduleReport newMDIChild = new crvScheduleReport();
            newMDIChild.MdiParent = this;
            newMDIChild.Show();
        }

        private void allToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ScheduleFullReport newMDIChild = new ScheduleFullReport();
            newMDIChild.MdiParent = this;
            newMDIChild.Show();
        }

        private void excelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Export newMDIChild = new Export();
            newMDIChild.MdiParent = this;
            newMDIChild.Show();
        }

        private void driverToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            AverageCollDriverReport newMDIChild = new AverageCollDriverReport();
            newMDIChild.MdiParent = this;
            newMDIChild.Show();
        }

        private void conductorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AverageCollCondReport newMDIChild = new AverageCollCondReport();
            newMDIChild.MdiParent = this;
            newMDIChild.Show();
        }

        private void wagesLimitSettingToolStripMenuItem_Click(object sender, EventArgs e)
        {
        //    frmWagesLimit newMDIChild = new frmWagesLimit();
        //    newMDIChild.MdiParent = this;
        //    newMDIChild.Show();
        }

        private void mileageLimitSettingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmMileageLimit newMDIChild = new frmMileageLimit();
            newMDIChild.MdiParent = this;
            newMDIChild.Show();
        }

        private void toolStripStatusLabel1_Click(object sender, EventArgs e)
        {

        }

        private void monthlyExpenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmothermonthlyexp newMDIChild = new frmothermonthlyexp();
            newMDIChild.MdiParent = this;
            newMDIChild.Show();
        }

        private void editMonthlyExpenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmMontlyReportEdit newMDIChild = new frmMontlyReportEdit();
            newMDIChild.MdiParent = this;
            newMDIChild.Show();
        }

        private void shortCollectionReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmshortcollreport newMDIChild = new frmshortcollreport();
            newMDIChild.MdiParent = this;
            newMDIChild.Show();
        }

        private void monthlyReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmMonthlyReport newMDIChild = new frmMonthlyReport();
            newMDIChild.MdiParent = this;
            newMDIChild.Show();
        }

        private void mainReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmMainReport newMDIChild = new frmMainReport();
            newMDIChild.MdiParent = this;
            newMDIChild.Show();
        }

        private void wagesLimitSettingToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmBataLimit newMDIChild = new frmBataLimit();
            newMDIChild.MdiParent = this;
            newMDIChild.Show();
        }

        private void tyerDataEntryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmTyerentry newMDIChild = new frmTyerentry();
            newMDIChild.MdiParent = this;
            newMDIChild.Show();
        }

        private void oilServiceEntryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmOilServiceEntry newMDIChild = new frmOilServiceEntry();
            newMDIChild.MdiParent = this;
            newMDIChild.Show();
        }

        private void breakServiceEntryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmBreakEntry newMDIChild = new frmBreakEntry();
            newMDIChild.MdiParent = this;
            newMDIChild.Show();
        }

        private void clutchServiceEntryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmClutchEntry newMDIChild = new frmClutchEntry();
            newMDIChild.MdiParent = this;
            newMDIChild.Show();
        }

        private void maintananceReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MaintanceReport newMDIChild = new MaintanceReport();
            newMDIChild.MdiParent = this;
            newMDIChild.Show();
        }

        private void tripEntrySeeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BusTrip newMDIChild = new BusTrip();
            newMDIChild.MdiParent = this;
            newMDIChild.Show();
        }

        private void tripEntrySheetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BusTripEntry newMDIChild = new BusTripEntry();
            newMDIChild.MdiParent = this;
            newMDIChild.Show();
        }

        private void tripEntryReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmTripSheetReport newMDIChild = new frmTripSheetReport();
            newMDIChild.MdiParent = this;
            newMDIChild.Show();
        }

        private void productIdToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmLICForm newMDIChild = new frmLICForm();
            newMDIChild.MdiParent = this;
            newMDIChild.Show();
        }

        private void mnbusreporttrip_Click(object sender, EventArgs e)
        {
            frmBusTripReport newMDIChild = new frmBusTripReport();
            newMDIChild.MdiParent = this;
            newMDIChild.Show();
        }

        private void menuStrip_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void smsNumberToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            frmSmsNumber fsn = new frmSmsNumber();
            fsn.MdiParent = this;
            fsn.Show();
        }

        private void companyNameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCompanyName fcn = new frmCompanyName();
            fcn.MdiParent = this;
            fcn.Show();
        }

        private void salaryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmSalary fs = new frmSalary();
            fs.MdiParent = this;
            fs.Show();
        }

        private void salaryReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmSalaryReport fsr = new frmSalaryReport();
            fsr.MdiParent = this;
            fsr.Show();
        }

        private void suppliersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmSupplier fsu = new frmSupplier();
            fsu.MdiParent = this;
            fsu.Show();
        }

        private void cashOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void cashOutReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
        }

        private void salaryReportToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            
        }

        private void supplierWiseReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCashOutReport fcr = new frmCashOutReport();
            fcr.MdiParent = this;
            fcr.Show();
        }

        private void maintanenceExpensesToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
        }

        private void expenseTypeReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmExpenseTypeReport ftr = new frmExpenseTypeReport();
            ftr.MdiParent = this;
            ftr.Show();
        }

        private void expenseTypeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmExpensesType fet = new frmExpensesType();
            fet.MdiParent = this;
            fet.Show();
        }

        private void salaryToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmSalary fs = new frmSalary();
            fs.MdiParent = this;
            fs.Show();
        }

        private void maintanenceExpensesToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmExpenseMaster fem = new frmExpenseMaster(0);
            fem.MdiParent = this;
            fem.Show();
        }

        private void cashOutToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmCashOut fco = new frmCashOut(0);
            fco.MdiParent = this;
            fco.Show();
        }

        private void profitReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmProfitReport fpr = new frmProfitReport();
            fpr.MdiParent = this;
            fpr.Show();

        }
    }
}
