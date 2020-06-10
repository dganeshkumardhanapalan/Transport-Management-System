using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace BUS
{
    class General
    {
        //public const string CONNECTION_STRING = @"Data Source=.\SQLEXPRESS;Initial Catalog=Transport;Integrated Security=True";
        //public const string CONNECTION_STRING = System.Configuration.ConfigurationManager.ConnectionStrings["BUS"].ConnectionString.ToString();
        public const string DieselPrice = @"\\ini File\Diesel.ini";
        public const string BackupPath = @"\\ini File\Backuppath.ini";
        public const string Batapath = @"\\ini File\Bata.ini";
        public const string smsCount = @"\\ini File\smsCount.ini";
        public const string smsContact = @"\\ini File\smsContact.ini";
        
        public const string DUPLICATE = "The following Details are Already Exists :\n\r";
        public const string REGNO = "Register Number\n\r";
        public const string BUSNAME = "Bus Name\n\r";
        public const string COMPANYNAME = "Company Name\n\r";
        public const string SUCCESS_MSG = "Successfully Saved/Updated.";
        public const string UN_SUCCESS_MSG = "Save/Update Unsuccessfull.Try Again";
        public const string DAY = "DAY";
        public const string MONTH = "MONTH";
        public const string YEAR = "YEAR";
        public const string REPORTPATH = @"\Report\";
        public const string BUS = "BUS";
        public const string DRIVER = "DRIVER";
        public const string PROFIT = "PROFIT";
       // public const string DRIVERNEW = "DRIVERNEW";
        public const string COLLECTION = "COLLECTION";
        public const string SUPPLIERWISEREPORT = "SUPPLIERWISEREPORT";
        public const string DAYCOLLECTION = "DAYCOLLECTION";
        public const string SALARY = "SALARY";
        public const string EXPENSETYPEREPORT = "EXPENSETYPEREPORT";
        public const string SCHEDULETYPE = "SCHEDULETYPE";
        public const string SCHEDULEREPORT = "SCHEDULEREPORT";
        public const string SCHEDULEFULLREPORT = "SCHEDULEFULLREPORT";
        public const string CONDUCTOR = "CONDUCTOR";
        public const string SHORTCOLLECTIONREPORT = "SHORTCOLLECTIONREPORT";
        public const string SALARYREPORT = "SALARYREPORT";
        public const string MONTHLYREPORT = "MONTHLYREPORT";
        public const string AVERAGEDRIVERCOLLECTION_REPORT = "AVERAGEDRIVERCOLLECTION_REPORT";
        public const string MAINREPORT = "MAINREPORT";
        public const string TYREREPORT = "TYREREPORT";
        public const string CLUTCHREPORT = "CLUTCHREPORT";
        public const string BREAKREPORT = "BREAKREPORT";
        public const string OILSERVICE = "OILSERVICE";
        public const string TRIPSHEET = "TRIPSHEET";
        public const string BUSTRIPREPORT = "BUSTRIPREPORT";
        public const string SALARY_REPORT = "SalaryReport.rpt";
        public const string BUS_REPORT = "BusCrystalReport.rpt";
        public const string PROFIT_REPORT = "rptProfitReport.rpt";
        public const string BUS_TRIP_REPORT = "BusTripCrystalReport.rpt";
       // public const string DRIVER_REPORT = "DriverCrystalReport.rpt";
        public const string DRIVER_REPORT = "rptDriver.rpt";
        public const string EXPENSETYPE_REPORT = "rptExpenseTypeReport.rpt";
        public const string SUPPLIERWISE_REPORT = "SupplierWiseReport.rpt";
        public const string CONDUCTOR_REPORT = "ConductorCrystalReport.rpt";
        public const string COLLECTION_REPORT = "CollectionCrystalReport_New1.rpt";
        public const string DAYCOLLECTION_REPORT = "DayCollectionCrystalReport.rpt";
        public const string SCHEDULE_REPORT = "cryScheduleReport.rpt";
        public const string SCHEDULEFULL_REPORT = "ScheduleFullCReport.rpt";
        public const string AVERAGECONDUCTORCOLLECTION_REPORT = "AvgCollByConductor.rpt";
        public const string AVERAGEDRIVERCOLLECTIONREPORT = "AvgCollByDriver.rpt";
        public const string EXPORTWAGES_REPORT = "ExportWages.rpt";
        public const string SHORTCOLLECTION_REPORT = "ShortCollectioncrystalReport.rpt";
        public const string MONTHLY_REPORT = "MonthlyCrystalReport.rpt";
        public const string MAIN_REPORT = "MainReport.rpt";
        public const string TYRE_REPORT = "NewTyreReport1.rpt";
        public const string CLUTCH_REPORT = "NewCluthchServiceReport.rpt";
        public const string BREAK_REPORT = "NewBreakServiceReport.rpt";
        public const string OIL_SERVICE = "OilReport.rpt";
        public const string TRIP_SHEET = "Tripsheet.rpt";

        public string CollectionModifyId = "0";

        public static bool Is_Edit = true;
        public static bool Is_Delete = true;

        public static string GetReportPath(string Name)
        {
            string value = "";
            if (Name == BUS)
            {
                value = REPORTPATH + BUS_REPORT;
            }
            else if (Name == DRIVER)
            {
                value = REPORTPATH + DRIVER_REPORT;
            }
            else if (Name == PROFIT)
            {
                value = REPORTPATH + PROFIT_REPORT;
            }
            else if (Name == SUPPLIERWISEREPORT)
            {
                value = REPORTPATH + SUPPLIERWISE_REPORT;
            }
            else if (Name == EXPENSETYPEREPORT)
            {
                value = REPORTPATH + EXPENSETYPE_REPORT;
            }
            else if (Name == SALARY)
            {
                value = REPORTPATH + SALARY_REPORT;
            }
            else if (Name == CONDUCTOR)
            {
                value = REPORTPATH + CONDUCTOR_REPORT;
            }
            else if (Name == COLLECTION)
            {
                value = REPORTPATH + COLLECTION_REPORT;
            }
            else if (Name == DAYCOLLECTION)
            {
                value = REPORTPATH + DAYCOLLECTION_REPORT;
            }
            else if (Name == SCHEDULEREPORT)
            {
                value = REPORTPATH + SCHEDULE_REPORT;
            }
            else if (Name == SCHEDULEFULLREPORT)
            {
                value = REPORTPATH + SCHEDULEFULL_REPORT;
            }
            else if (Name == AVERAGECONDUCTORCOLLECTION_REPORT)
            {
                value = REPORTPATH + AVERAGECONDUCTORCOLLECTION_REPORT;
            }
            else if (Name == AVERAGEDRIVERCOLLECTIONREPORT)
            {
                value = REPORTPATH + AVERAGEDRIVERCOLLECTION_REPORT;
            }
            else if (Name == EXPORTWAGES_REPORT)
            {
                value = REPORTPATH + EXPORTWAGES_REPORT;
            }
            else if (Name == SHORTCOLLECTIONREPORT)
            {
                value = REPORTPATH + SHORTCOLLECTION_REPORT;
            }
            else if (Name == MONTHLYREPORT)
            {
                value = REPORTPATH + MONTHLY_REPORT;
            }
            else if (Name == MAINREPORT)
            {
                value = REPORTPATH + MAIN_REPORT;
            }
            else if (Name == TYREREPORT)
            {
                value = REPORTPATH + TYRE_REPORT;
            }
            else if (Name == CLUTCHREPORT)
            {
                value = REPORTPATH + CLUTCH_REPORT;
            }
            else if (Name == BREAKREPORT)
            {
                value = REPORTPATH + BREAK_REPORT;
            }
            else if (Name == OILSERVICE)
            {
                value = REPORTPATH + OIL_SERVICE;
            }
            else if (Name == TRIPSHEET)
            {
                value = REPORTPATH + TRIP_SHEET;
            }
            else if (Name == BUSTRIPREPORT)
            {
                value = REPORTPATH + BUS_TRIP_REPORT;
            }
            
            
            return value;
        }

        public static int GetBusID(string name, string type)
        {
            string connstring = System.Configuration.ConfigurationManager.ConnectionStrings["BUS"].ConnectionString.ToString();
            SqlConnection conn = new SqlConnection(connstring);
            conn.Open();
            string qry = "";
            if (type == BUS)
            {
                qry = "Select ID FROM BusMaster WHERE Name= '" + name + "'";
            }
            else if (type == SCHEDULETYPE)
            {
                qry = "Select ID FROM ScheduleType WHERE ScheduleType = '" + name + "'";
            }
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(qry, conn);
            da.Fill(ds);
            int value = 0;
            if (ds.Tables[0].Rows.Count > 0)
            {
                value = Int32.Parse(ds.Tables[0].Rows[0]["ID"].ToString());
            }
            return value;
        }


        public static string GetBusName(int id, string type)
        {
            string connstring = System.Configuration.ConfigurationManager.ConnectionStrings["BUS"].ConnectionString.ToString();
            SqlConnection conn = new SqlConnection(connstring);
            conn.Open();
            string qry = "";
            if (type == BUS)
            {
                qry = "Select Name AS Name FROM BusMaster WHERE ID= " + id;
            }
            else if (type == SCHEDULETYPE)
            {
                qry = "Select ScheduleType AS Name FROM ScheduleType WHERE ID = " + id;
            }
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(qry, conn);
            da.Fill(ds);
            string value = "";
            if (ds.Tables[0].Rows.Count > 0)
            {
                value = ds.Tables[0].Rows[0]["Name"].ToString();
            }
            return value;
        }

        public static decimal GetNetTotal(string name, string FromDate, string ToDate)
        {
            string connstring = System.Configuration.ConfigurationManager.ConnectionStrings["BUS"].ConnectionString.ToString();
            SqlConnection conn = new SqlConnection(connstring);
            conn.Open();
            string qry = "";
            // if (type == BUS)
            //{
            qry = "select sum(Total) as NetTotal from CollectionMaster where BusName='" + name + "' and Date between '" + FromDate + "'and '" + ToDate + "' group by BusName";
            //}
            // else if (type == SCHEDULETYPE)
            //{
            //    qry = "Select ID FROM ScheduleType WHERE ScheduleType = '" + name + "'";
            //}
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(qry, conn);
            da.Fill(ds);
            decimal value = 0;
            if (ds.Tables[0].Rows.Count > 0)
            {
                value = Convert.ToDecimal(ds.Tables[0].Rows[0]["NetTotal"].ToString());
            }
            return value;
        }
      }
}

