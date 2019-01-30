using Excel;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace VV
{
    public partial class TagNoDetails : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            #region Master Control

            #region Welcome Msg

            DateTime dt = DateTime.MinValue;
            Console.WriteLine(dt);
            string UserName = (String)HttpContext.Current.Session["LoggedOnUser"];
            Label lblUserName = (Label)this.Page.Master.FindControl("lblUserName");
            lblUserName.Text = "Welcome " + UserName;

            LinkButton logout_btn = (LinkButton)this.Page.Master.FindControl("lnkBtnLogOut");
            logout_btn.Visible = true;
            # endregion

            # region Menu Access
            DataSet ds_Menu = (DataSet)HttpContext.Current.Session["ds_AccessPages"];
            System.Web.UI.WebControls.Menu tbstr = (System.Web.UI.WebControls.Menu)this.Master.FindControl("Menu1");

            for (int i = 0; i < ds_Menu.Tables[0].Rows.Count; i++)
            {
                String MenuName = ds_Menu.Tables[0].Rows[i]["MenuName"].ToString().Trim();
                int MenuID = Int32.Parse(ds_Menu.Tables[0].Rows[i]["MenuID"].ToString().Trim());

                String ParentMenuName = ds_Menu.Tables[0].Rows[i]["ParentMenuName"].ToString().Trim();
                int ParentMenuID = Int32.Parse(ds_Menu.Tables[0].Rows[i]["ParentMenuID"].ToString().Trim());

                # region Planning
                if (ParentMenuID == 1) // Planning
                {
                    tbstr.Items[ParentMenuID].Enabled = true;

                    if (MenuID == 0) // Import from BaaN to be changed as Import SO Backlog
                        tbstr.Items[ParentMenuID].ChildItems[MenuID].Enabled = true;
                    else if (MenuID == 1) // Production Release
                        tbstr.Items[ParentMenuID].ChildItems[MenuID].Enabled = true;
                    else if (MenuID == 2) // Invoiced Data Import
                        tbstr.Items[ParentMenuID].ChildItems[MenuID].Enabled = true;
                    else if (MenuID == 3) // Freeze Plan
                        tbstr.Items[ParentMenuID].ChildItems[MenuID].Enabled = true;
                    else if (MenuID == 4) // Plan Review -- Release Plan
                        tbstr.Items[ParentMenuID].ChildItems[4].ChildItems[0].Enabled = true;
                    else if (MenuID == 5) // Plan Review -- FG Plan
                        tbstr.Items[ParentMenuID].ChildItems[4].ChildItems[1].Enabled = true;
                    else if (MenuID == 6) // Plan Review -- Sales Plan
                        tbstr.Items[ParentMenuID].ChildItems[4].ChildItems[2].Enabled = true;
                    else if (MenuID == 7) // Reports - Order Status Report
                        tbstr.Items[ParentMenuID].ChildItems[5].ChildItems[0].Enabled = true;
                    else if (MenuID == 8) // Reports - ToRelease Report
                        tbstr.Items[ParentMenuID].ChildItems[5].ChildItems[1].Enabled = true;
                    else if (MenuID == 9) // Reports - SO BackLog Report
                        tbstr.Items[ParentMenuID].ChildItems[5].ChildItems[2].Enabled = true;
                    else if (MenuID == 10) // Prod Order Reversal
                        tbstr.Items[ParentMenuID].ChildItems[6].Enabled = true;
                    else if (MenuID == 11) // Schedule Process
                        tbstr.Items[ParentMenuID].ChildItems[7].Enabled = true;
                    else if (MenuID == 12) // Update WIP RecDate
                        tbstr.Items[ParentMenuID].ChildItems[8].Enabled = true;
                    else if (MenuID == 13) // Update PO Committment date
                        tbstr.Items[ParentMenuID].ChildItems[9].Enabled = true;
                    else if (MenuID == 14) // View WIP Dates
                        tbstr.Items[ParentMenuID].ChildItems[10].Enabled = true;
                    else if (MenuID == 15) // View PO Dates
                        tbstr.Items[ParentMenuID].ChildItems[11].Enabled = true;
                    else if (MenuID == 16) // View Processed Items
                        tbstr.Items[ParentMenuID].ChildItems[12].Enabled = true;
                    //else if (MenuID == 17) // View ICS PO Reversal Items
                    //  tbstr.Items[ParentMenuID].ChildItems[13].Enabled = true;
                }
                # endregion

                # region Production
                else if (ParentMenuID == 2) // Production
                {
                    tbstr.Items[ParentMenuID].Enabled = true;

                    if (MenuID == 0) // WIP To FG
                        tbstr.Items[ParentMenuID].ChildItems[MenuID].Enabled = true;
                    else if (MenuID == 1) // Production Completion
                        tbstr.Items[ParentMenuID].ChildItems[MenuID].Enabled = true;
                    else if (MenuID == 2) // WIP Report
                        tbstr.Items[ParentMenuID].ChildItems[MenuID].Enabled = true;
                }
                # endregion

                # region Quality
                else if (ParentMenuID == 3) // Quality
                {
                    tbstr.Items[ParentMenuID].Enabled = true;

                    if (MenuID == 0) // TPI Offering
                        tbstr.Items[ParentMenuID].ChildItems[MenuID].Enabled = true;
                    else if (MenuID == 1) // TPI Pending Report
                        tbstr.Items[ParentMenuID].ChildItems[MenuID].Enabled = true;
                }
                # endregion

                # region Sales
                if (ParentMenuID == 4) // Sales
                {
                    tbstr.Items[ParentMenuID].Enabled = true;

                    if (MenuID == 0) // ITP/ GAD Info
                        tbstr.Items[ParentMenuID].ChildItems[MenuID].Enabled = true;
                    else if (MenuID == 1) // Stock Code/ Tag No Import
                        tbstr.Items[ParentMenuID].ChildItems[MenuID].Enabled = true;
                    else if (MenuID == 2) // SCN Input
                        tbstr.Items[ParentMenuID].ChildItems[MenuID].Enabled = true;
                    else if (MenuID == 3) // MIS Finance Input/ Commercial
                        tbstr.Items[ParentMenuID].ChildItems[MenuID].Enabled = true;
                    else if (MenuID == 4) // QR & QA
                        tbstr.Items[ParentMenuID].ChildItems[MenuID].Enabled = true;
                    else if (MenuID == 5) // QR & QA Sales Summary
                        tbstr.Items[ParentMenuID].ChildItems[MenuID].Enabled = true;
                    else if (MenuID == 6) // Commercial Review
                        tbstr.Items[ParentMenuID].ChildItems[MenuID].Enabled = true;
                }
                # endregion

                # region Print
                else if (ParentMenuID == 5) // Print
                {
                    tbstr.Items[ParentMenuID].Enabled = true;

                    if (MenuID == 0) // Assembly Order Processing
                        tbstr.Items[ParentMenuID].ChildItems[MenuID].Enabled = true;
                }
                # endregion

                # region System Util
                else if (ParentMenuID == 6) // System Util
                {
                    tbstr.Items[ParentMenuID].Enabled = true;

                    if (MenuID == 0) // Create New User
                        tbstr.Items[ParentMenuID].ChildItems[MenuID].Enabled = true;
                    else if (MenuID == 1) // Update Role Access
                        tbstr.Items[ParentMenuID].ChildItems[MenuID].Enabled = true;
                    else if (MenuID == 2) // Change Password
                        tbstr.Items[ParentMenuID].ChildItems[MenuID].Enabled = true;
                }
                # endregion

                #region Stores

                else if (ParentMenuID == 7) // Sysem Util
                {
                    tbstr.Items[ParentMenuID].Enabled = true;

                    if (MenuID == 0) // Production Order Issues
                        tbstr.Items[ParentMenuID].ChildItems[MenuID].Enabled = true;
                }
                #endregion
            }
            # endregion

            # endregion
        }

        protected void btImport_ServerClick(object sender, EventArgs e)
        {
            SqlBulkCopy oSqlBulk = null;
            DataSet ds = new DataSet();
            SqlCommand cmd = new SqlCommand();
            DataTable dt = new DataTable();
            DBUtil _dbObj = new DBUtil();

            // CHECK IF A FILE HAS BEEN SELECTED.
            if ((FileUpload.HasFile))
            {

                if (!Convert.IsDBNull(FileUpload.PostedFile) &
                    FileUpload.PostedFile.ContentLength > 0)
                {
                    try
                    {
                        string sCon = ConfigurationManager.ConnectionStrings["VVConnection"].ToString();
                        SqlConnection conn = new SqlConnection(sCon);
                        var dataTable = new DataTable();

                        cmd = conn.CreateCommand();
                        cmd.CommandType = CommandType.Text;
                        cmd.CommandText = string.Format("SET FMTONLY ON; SELECT * FROM MISSalesInput; SET FMTONLY OFF;");
                        conn.Open();
                        dataTable.Load(cmd.ExecuteReader());
                        conn.Close();

                        string filename = Path.GetFileName(FileUpload.FileName);
                        FileUpload.SaveAs(Server.MapPath("~/") + filename);

                        FileStream stream;
                        IExcelDataReader excelReader = null;

                        //String ExcelPath = Program.GetAppSetting("MapPath").Trim() + "\\AUS.xls";
                        stream = File.Open(Server.MapPath("~/") + filename, FileMode.Open, FileAccess.Read);

                        string getExtension = Path.GetExtension(FileUpload.FileName);

                        if (getExtension == ".xls")
                        {
                            //1. Reading from a binary Excel file ('97-2003 format; *.xls)
                            excelReader = ExcelReaderFactory.CreateBinaryReader(stream);
                        }
                        else if (getExtension == ".xlsx")
                        {
                            //2. Reading from a OpenXml Excel file (2007 format; *.xlsx)
                            excelReader = ExcelReaderFactory.CreateOpenXmlReader(stream);
                        }

                        excelReader.IsFirstRowAsColumnNames = true;

                        ds = excelReader.AsDataSet();

                        if (ds.Tables.Count > 0)
                        {
                            if (ds.Tables[0].Rows.Count > 0)
                            {
                                dataTable = ds.Tables[0];
                            }
                        }

                        excelReader.Close();

                        using (SqlConnection con = new SqlConnection(sCon))
                        {
                            con.Open();

                            if (dataTable.Rows.Count > 0)
                            {
                                for (int i = 0; i < dataTable.Rows.Count; i++)
                                {
                                    //string companyNo = dataTable.Rows[i]["Company No"].ToString();
                                    //string poOrder = dataTable.Rows[i]["Order"].ToString();
                                    //string poPosition = dataTable.Rows[i]["Pos"].ToString();
                                    //string orderDate = dataTable.Rows[i]["Order Date"].ToString();
                                    //string planDelDate = dataTable.Rows[i]["Plan Del. Date"].ToString();
                                    //string confDate = dataTable.Rows[i]["Conf. Date"].ToString();
                                    //string chqBy = dataTable.Rows[i]["Chq by"].ToString();
                                    //string chqDate = dataTable.Rows[i]["Chq. Date"].ToString();
                                    //string itemNumber = dataTable.Rows[i]["Item"].ToString();
                                    //string warehouse = dataTable.Rows[i]["Warehouse"].ToString();
                                    //string description = dataTable.Rows[i]["Description"].ToString();

                                    //string ig = dataTable.Rows[i]["IG"].ToString();
                                    //string exp = dataTable.Rows[i]["EXP"].ToString();
                                    //string price = dataTable.Rows[i]["Price"].ToString();
                                    //string currency = dataTable.Rows[i]["Currency"].ToString();
                                    //string ordered = dataTable.Rows[i]["Ordered"].ToString();
                                    //string deliv = dataTable.Rows[i]["Deliv."].ToString();
                                }
                            }

                            oSqlBulk = new SqlBulkCopy(con);
                            oSqlBulk.DestinationTableName = "MISSalesInput"; // TABLE NAME.

                            oSqlBulk.WriteToServer(dataTable);

                            //_dbObj.UpdateWIPBuyers();

                            //_dbObj.UpdateWIPRecDates();

                            //lblConfirm.Text = "WIP DATA IMPORTED SUCCESSFULLY.";
                            //lblConfirm.Attributes.Add("style", "color:green");
                        }
                    }
                    catch (Exception ex)
                    {
                        LogError(ex, "Exception from PO upload:");
                    }
                    finally
                    {
                        // CLEAR.
                        cmd.Dispose();
                    }
                }
            }
        }

        private void LogError(Exception ex, string section)
        {

            string message = string.Format("Time: {0}", DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss tt"));
            message += Environment.NewLine;
            message += "-----------------------------------------------------------";
            message += Environment.NewLine;
            message += string.Format("Message: {0}", ex.Message);
            message += Environment.NewLine;
            message += "Exception from SQLConnectionOpen" + "-" + section;
            message += Environment.NewLine;
            message += "-----------------------------------------------------------";
            message += Environment.NewLine;
            string path = Server.MapPath("~/ErrorLog.txt");
            using (StreamWriter writer = new StreamWriter(path, true))
            {
                writer.WriteLine(message);
                writer.Close();
            }
        }

    }
}