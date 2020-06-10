using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Threading;
using System.IO;

namespace BUS
{
    public partial class frmTripSheetReport : Form
    {
        

        List<string> list = new List<string>();
        List<string> list2 = new List<string>();
        string allRecords = null;
        string ans;
        string Qury = "";
         string Qury2 = "";
        string Qur = "";
        string fileLoc = @"D:\print.html";
        string idbus = "";

        ReportDocument objRpt = new ReportDocument();

        public frmTripSheetReport()
        {
            InitializeComponent();
        }

        private void frmTripSheetReport_Load(object sender, EventArgs e)
        {
            button1.Enabled = false;
            dtpfromdate.Value = DateTime.Now;
            dtptodate.Value = DateTime.Now;
            if (File.Exists(fileLoc))
            {
                File.Delete(fileLoc);
            }


            cbbusname.Items.Clear();
            string connstring = System.Configuration.ConfigurationManager.ConnectionStrings["BUS"].ConnectionString.ToString();
            SqlConnection conn = new SqlConnection(connstring);
            conn.Open();
            string qry = "select * FROM BusMaster";
            SqlDataAdapter da = new SqlDataAdapter(qry, conn);
            DataSet ds = new DataSet();
            da.Fill(ds);
            conn.Close();
            int rowcount = ds.Tables[0].Rows.Count;
            if (rowcount == 0)
            {
                MessageBox.Show("No Record Found");
            }
            else
            {
                for (int count = 0; count < rowcount; count++)
                {
                    cbbusname.Items.Insert(count, Convert.ToString(ds.Tables[0].Rows[count]["Name"]).Trim());
                }
                cbbusname.SelectedIndex = 0;
            }
        }

        private void btcreate_Click(object sender, EventArgs e)
        {
            list.Clear();
            list2.Clear();

            var xmlFileData = "";
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

                try
                {

                     Qury2 = ",(";
                    Qury = "SELECT BT.Id, replace(convert(char(11),BT.[Date],103),' ','/') as Date,BM.Name AS Bus,EMD.Name AS Driver,EMC.Name AS Conductor ,";
                    //Qur = "SELECT BT.Id as column1,BT.[Date] as column2,BT.[BusName] AS column3,BT.[DriverName] AS column4,BT.[ConductorName] AS column5 ,";
                    Qur = "SELECT BT.Id as DataColumn1,replace(convert(char(11),BT.[Date],103),' ','/') as DataColumn2,BM.Name AS DataColumn3,EMD.Name AS DataColumn4,EMC.Name AS DataColumn5 ,";

                    using (SqlCommand command = conn.CreateCommand())
                    {
                        command.CommandText = " SELECT column_name FROM information_schema.columns WHERE table_name ='BusTripSheet_" + idbus + "'  ";
                        list.Clear();
                        using (var reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                list.Add(reader.GetString(0));
                                list2.Add(reader.GetString(0));

                            }
                        }
                    }

                    string[] ResultList1 = list2.ToArray();
                    string listcount1 = list2.Count.ToString();
                    int countlist1 = int.Parse(listcount1);
                    countlist1 = countlist1 - 6;

                    for (int j = 0; j <= countlist1; j++)
                    {
                        string Resultcount1 = ResultList1[j + 5];
                        Qury2 = Qury2 + "[" + Resultcount1 + "] + ";
                    }
                    Qury2 = Qury2.Substring(0, Qury2.Length - 3);
                    Qury2 = Qury2 + ") As Total";
                }
                catch (Exception e4)
                {
                    MessageBox.Show(" Table is not created");
                    
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
                        Qur = Qur + "BT" + ".[" + Resultcount + "] as DataColumn" + (i + 5) + " ,";
                        //Qur = Qur + "as column" + (i + 5) + "";
                    }

                    Qury = Qury.Substring(0, Qury.Length - 1);
                    Qur = Qur.Substring(0, Qur.Length - 1);
                    //Qur = Qur + Qury2;
                    Qury = Qury + Qury2;
                    Qury = Qury + " FROM dbo.BusTripSheet_" + idbus + " BT INNER JOIN BusMaster BM ON BT.BusName = BM.Id INNER JOIN EmployeeMaster EMD ON BT.DriverName = EMD.Id INNER JOIN EmployeeMaster EMC ON BT.ConductorName = EMC.Id WHERE EMD.Department = 'Driver' AND EMC.Department = 'Conductor' AND (BT.[Date] BETWEEN '" + dtpfromdate.Value.ToString("yyyy-MM-dd") + "'  AND '" + dtptodate.Value.ToString("yyyy-MM-dd") + "')  order by BT.[Date] ";
                    Qur = Qur + " FROM dbo.BusTripSheet_" + idbus + " BT INNER JOIN BusMaster BM ON BT.BusName = BM.Id INNER JOIN EmployeeMaster EMD ON BT.DriverName = EMD.Id INNER JOIN EmployeeMaster EMC ON BT.ConductorName = EMC.Id WHERE EMD.Department = 'Driver' AND EMC.Department = 'Conductor' AND (BT.[Date] BETWEEN '" + dtpfromdate.Value.ToString("yyyy-MM-dd") + "'  AND '" + dtptodate.Value.ToString("yyyy-MM-dd") + "')  order by BT.[Date] ";
                    //Qur = Qur + " FROM dbo.BusTripSheet_" + idbus + " as BT"; 
                    Qury = Qury + " ;";
                    Qur = Qur + " ;";

                    SqlDataAdapter da1 = new SqlDataAdapter(Qury, conn);
                    DataSet ds1 = new DataSet();
                    da1.Fill(ds1);
                    conn.Close();

                    string bun = cbbusname.SelectedItem.ToString();
                    string fromda = dtpfromdate.Value.ToString("dd-MM-yyyy");
                    string toda = dtptodate.Value.ToString("dd-MM-yyyy");

                    int rowcount1 = ds1.Tables[0].Rows.Count;
                    string html = "<!DOCTYPE html> \r\n";
                    html = html + "<html> \r\n";
                    html = html + "<body> \r\n";
                    html = html + "<center><h3>MANI TRANSPORT</h1></center> \r\n";
                    html = html + "<center><h3>TRIP ENTRY REPORT</h1></center> \r\n";
                    html = html + "<hr> \r\n";
                    html = html + "<br> \r\n";
                    html = html + "<h4>Bus Name:" + bun + " </h4>";
                    html = html + "<h4>Date: " + fromda + " To  " + toda + "</h4>";
                    html = html + "<table border=\"1\"> \r\n";

                    for (int x = 0; x < rowcount1; x++)
                    {
                        if (x == 0)
                        {
                            for (int y = 0; y < list.Count + 1; y++)
                            {
                                html = html + "<th>";
                                html = html + ds1.Tables[0].Columns[y].ToString();
                                html = html + "</th>";
                            }
                        }
                        html = html + "<tr> \r\n";
                        for (int y = 0; y < list.Count + 1; y++)
                        {
                            html = html + "<td>";
                            if (y == 0)
                            {
                                html = html + (x + 1).ToString();
                            }
                            else
                            {
                                html = html + ds1.Tables[0].Rows[x][y].ToString();
                            }
                            html = html + "</td>";
                        }
                        html = html + "</tr> \r\n";
                    }
                    html = html + "</center>";
                    html = html + "</body> \r\n";
                    html = html + "</html>";
                    FileStream fs = null;
                    if (!File.Exists(fileLoc))
                    {
                        using (fs = File.Create(fileLoc))
                        {

                        }
                    }

                    using (StreamWriter sw = new StreamWriter(fileLoc))
                    {
                        sw.Write(html);
                    }
                    webBrowser1.Url = new Uri("file:///D:/print.html");
                    button1.Enabled = true;
                }
                catch (Exception e2)
                {
                    MessageBox.Show("Table is not yet craeted");
                    webBrowser1.Navigate("about:blank");
                }

            }
            // File.WriteAllText("D://SelectiveDatabaseBackup.xml", xmlFileData);

        }

        private void button1_Click(object sender, EventArgs e)
        {

            webBrowser1.Print();
        }

        /*private void button2_Click(object sender, EventArgs e)
        {
            string connectionString = General.CONNECTION_STRING;
            SqlConnection cnn = new SqlConnection(connectionString);
            string sql = null;
            cnn.Open();
            sql = procesSQL();
            SqlDataAdapter dscmd = new SqlDataAdapter(sql, cnn);
            DataSet1 ds = new DataSet1();
            dscmd.Fill(ds);
            cnn.Close();

            string reportpath = Path.GetDirectoryName(Application.ExecutablePath).ToString() + General.GetReportPath(General.TRIPSHEET);
            objRpt.Load(reportpath);

            objRpt.SetDataSource(ds.Tables[1]);
            //crystalReportViewer1.ReportSource = objRpt;
            //crystalReportViewer1.Refresh();
        }*/


        /*
        public string procesSQL()
        {
            string sql = null;
            string inSql = null;
            string firstPart = null;
            string lastPart = null;
            int selectStart = 0;
            int fromStart = 0;
            string[] fields = null;
            string[] sep = { "," };
            int i = 0;
            TextObject MyText;
            FieldObject MyText1;
            FieldHeadingObject MyText2;

            //textBox1.Text = Qury;
            inSql = textBox1.Text;
            inSql = inSql.ToUpper();

            selectStart = inSql.IndexOf("SELECT");
            fromStart = inSql.IndexOf("FROM");
            selectStart = selectStart + 6;
            firstPart = inSql.Substring(selectStart, (fromStart - selectStart));
            lastPart = inSql.Substring(fromStart, (inSql.Length - fromStart));

            fields = firstPart.Split(',');
            firstPart = "";
            try
            {

                for (i = 0; i <= fields.Length - 1; i++)
                {
                    if (i > 0)
                    {
                        firstPart = firstPart + ", " + fields[i].ToString() + " AS COLUMN" + (i + 1);
                        firstPart.Trim();

                        //MyText = (TextObject)objRpt.ReportDefinition.ReportObjects[i + 1];
                        MyText1 = (FieldObject)objRpt.ReportDefinition.ReportObjects[i + 1];
                        //MyText.Text = fields[i].ToString();


                    }
                    else
                    {
                        firstPart = firstPart + fields[i].ToString() + " AS COLUMN" + (i + 1);
                        firstPart.Trim();
                        string reportpath = Path.GetDirectoryName(Application.ExecutablePath).ToString() + General.GetReportPath(General.TYREREPORT);
                        objRpt.Load(reportpath);

                        MyText = (TextObject)objRpt.ReportDefinition.ReportObjects[i + 1];
                        MyText.Text = fields[i].ToString();
                    }
                }
            }
            catch (Exception e)
            {
                MyText2 = (FieldHeadingObject)objRpt.ReportDefinition.ReportObjects[i + 1];
            }
            sql = "SELECT " + firstPart + " " + lastPart;
            return sql;
        }
        */
        private void cbbusname_SelectedIndexChanged(object sender, EventArgs e)
        {
            list.Clear();
        }
    }
}
