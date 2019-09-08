using Excel;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Globalization;
using System.IO;
using System.Web;
using System.Web.UI.WebControls;

namespace VV
{
    public partial class Schedule_Process : System.Web.UI.Page
    {
        SqlCommand cmd = new SqlCommand();
        DataTable dt = new DataTable();
        DBUtil _dbObj = new DBUtil();

        protected void Page_Load(object sender, EventArgs e)
        {
            # region Master Control

            # region Welcome Msg

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
                    else if (MenuID == 17) // Reports - Ready To Release
                        tbstr.Items[ParentMenuID].ChildItems[5].ChildItems[3].Enabled = true;
                    else if (MenuID == 18) // Reports - Shortage Report
                        tbstr.Items[ParentMenuID].ChildItems[5].ChildItems[4].Enabled = true;
                    else if (MenuID == 19) // Buyer Master
                        tbstr.Items[ParentMenuID].ChildItems[13].Enabled = true;
                    else if (MenuID == 20) // Shortage
                        tbstr.Items[ParentMenuID].ChildItems[14].Enabled = true;
                    else if (MenuID == 21) // Update Order Status
                        tbstr.Items[ParentMenuID].ChildItems[15].Enabled = true;
                    else if (MenuID == 22) // Supplier Remarks
                        tbstr.Items[ParentMenuID].ChildItems[16].Enabled = true;
                    else if (MenuID == 23) // Bulk Release
                        tbstr.Items[ParentMenuID].ChildItems[17].Enabled = true;
                    else if (MenuID == 24) // View SCM
                        tbstr.Items[ParentMenuID].ChildItems[18].Enabled = true;
                    else if (MenuID == 25) // Week Wise Shortage Report
                        tbstr.Items[ParentMenuID].ChildItems[19].Enabled = true;
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
                    else if (MenuID == 2) // Status Importing
                        tbstr.Items[ParentMenuID].ChildItems[MenuID].Enabled = true;

                    else if (MenuID == 3) // Operator Master
                        tbstr.Items[ParentMenuID].ChildItems[3].ChildItems[0].Enabled = true;
                    else if (MenuID == 4) // IP Location Master
                        tbstr.Items[ParentMenuID].ChildItems[3].ChildItems[1].Enabled = true;
                    else if (MenuID == 5) // IP Sub Location Master
                        tbstr.Items[ParentMenuID].ChildItems[3].ChildItems[2].Enabled = true;
                    else if (MenuID == 6) // Check List Master
                        tbstr.Items[ParentMenuID].ChildItems[3].ChildItems[3].Enabled = true;
                    else if (MenuID == 7) // IP Check List Master
                        tbstr.Items[ParentMenuID].ChildItems[3].ChildItems[4].Enabled = true;
                    else if (MenuID == 8) // Report - Date Wise
                        tbstr.Items[ParentMenuID].ChildItems[3].ChildItems[5].Enabled = true;
                    else if (MenuID == 9) // Report - Monthly wise
                        tbstr.Items[ParentMenuID].ChildItems[3].ChildItems[6].Enabled = true;
                    else if (MenuID == 10) // Patrol Review
                        tbstr.Items[ParentMenuID].ChildItems[3].ChildItems[7].Enabled = true;
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
                    else if (MenuID == 7) // Branch Report
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
                    else if (MenuID == 3) // Login SupplierName Update
                        tbstr.Items[ParentMenuID].ChildItems[MenuID].Enabled = true;
                    else if (MenuID == 4) // Heat No Control
                        tbstr.Items[ParentMenuID].ChildItems[MenuID].Enabled = true;
                }
                #endregion

                #region Stores

                else if (ParentMenuID == 7) // Sysem Util
                {
                    tbstr.Items[ParentMenuID].Enabled = true;

                    if (MenuID == 0) // Production Order Issues
                        tbstr.Items[ParentMenuID].ChildItems[0].Enabled = true;
                    else if (MenuID == 1) // Vendor Master
                        tbstr.Items[ParentMenuID].ChildItems[MenuID].Enabled = true;
                    else if (MenuID == 2) // Item Master
                        tbstr.Items[ParentMenuID].ChildItems[MenuID].Enabled = true;
                    else if (MenuID == 3) // Employee Master
                        tbstr.Items[ParentMenuID].ChildItems[MenuID].Enabled = true;
                    else if (MenuID == 4) // Delivery Challan
                        tbstr.Items[ParentMenuID].ChildItems[MenuID].Enabled = true;
                    else if (MenuID == 5) // Delivery Challan Receipts
                        tbstr.Items[ParentMenuID].ChildItems[MenuID].Enabled = true;
                    else if (MenuID == 6) // Delivery Challan Reports
                        tbstr.Items[ParentMenuID].ChildItems[5].ChildItems[0].Enabled = true;
                }
                #endregion

                #region MIS Utility

                else if (ParentMenuID == 8) // Sysem Util
                {
                    tbstr.Items[ParentMenuID].Enabled = true;

                    if (MenuID == 0) // Sales Order Line Item Deletion
                        tbstr.Items[ParentMenuID].ChildItems[0].Enabled = true;

                    if (MenuID == 1) // Serial No Details
                        tbstr.Items[ParentMenuID].ChildItems[1].Enabled = true;

                    if (MenuID == 2) // Sales Order Qty Decrement
                        tbstr.Items[ParentMenuID].ChildItems[2].Enabled = true;

                    if (MenuID == 3) // FG Order Change
                        tbstr.Items[ParentMenuID].ChildItems[3].Enabled = true;

                    if (MenuID == 4) // FG To WIP Reversal
                        tbstr.Items[ParentMenuID].ChildItems[4].Enabled = true;

                    if (MenuID == 5) // Update PO
                        tbstr.Items[ParentMenuID].ChildItems[5].Enabled = true;

                    if (MenuID == 6) // Ready To Release
                        tbstr.Items[ParentMenuID].ChildItems[6].Enabled = true;
                    if (MenuID == 7) // WIP Aging
                        tbstr.Items[ParentMenuID].ChildItems[7].Enabled = true;

                    if (MenuID == 8) // Request
                        tbstr.Items[ParentMenuID].ChildItems[8].ChildItems[0].Enabled = true;

                    if (MenuID == 9) // Quality
                        tbstr.Items[ParentMenuID].ChildItems[8].ChildItems[1].Enabled = true;

                    if (MenuID == 10) // Stores
                        tbstr.Items[ParentMenuID].ChildItems[8].ChildItems[2].Enabled = true;

                    if (MenuID == 11) // Enquiries And Reports
                        tbstr.Items[ParentMenuID].ChildItems[8].ChildItems[3].Enabled = true;
                }
                #endregion
            }
            # endregion

            SearchPanel.Visible = false;

            #region Section for displaying upload counts

            int wipCounts = _dbObj.GetWIPCounts();
            lblWipCount.Text = Convert.ToString(wipCounts);
            int poCounts = _dbObj.GetPOCounts();
            lblPoCount.Text = Convert.ToString(poCounts);
            int bomCounts = _dbObj.GetBOMCounts();
            lblBomCount.Text = Convert.ToString(bomCounts);
            int inventoryCounts = _dbObj.GetInventoryCounts();
            lblInventoryCount.Text = Convert.ToString(inventoryCounts);

            #endregion

            #endregion

            System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-IN");
        }

        protected void btImport_ServerClick(object sender, EventArgs e)
        {
            string conStr = string.Empty;
            SqlBulkCopy oSqlBulk = null;

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

                        //dataTable.Columns.Add(new DataColumn("FigureNumber", System.Type.GetType("System.String")));
                        //dataTable.Columns.Add(new DataColumn("Level", System.Type.GetType("System.String")));
                        //dataTable.Columns.Add(new DataColumn("Position", System.Type.GetType("System.String")));
                        //dataTable.Columns.Add(new DataColumn("ItemNumber", System.Type.GetType("System.String")));
                        //dataTable.Columns.Add(new DataColumn("Dec", System.Type.GetType("System.String")));
                        //dataTable.Columns.Add(new DataColumn("NetQuantity", System.Type.GetType("System.Double")));
                        //dataTable.Columns.Add(new DataColumn("InvUn", System.Type.GetType("System.String")));
                        //dataTable.Columns.Add(new DataColumn("Wrh", System.Type.GetType("System.String")));
                        //dataTable.Columns.Add(new DataColumn("InventoryOnHand", System.Type.GetType("System.Double")));
                        //dataTable.Columns.Add(new DataColumn("InventoryOnOrder", System.Type.GetType("System.Double")));
                        //dataTable.Columns.Add(new DataColumn("AllocateInventoryOrder", System.Type.GetType("System.Double")));

                        var cmd = conn.CreateCommand();
                        cmd.CommandType = CommandType.Text;
                        cmd.CommandText = string.Format("SET FMTONLY ON; SELECT * FROM bom; SET FMTONLY OFF;");
                        conn.Open();
                        dataTable.Load(cmd.ExecuteReader());
                        conn.Close();

                        string filename = Path.GetFileName(FileUpload.FileName);
                        FileUpload.SaveAs(Server.MapPath("~/") + filename);

                        FileStream stream;
                        IExcelDataReader excelReader = null;

                        DataSet ds = new DataSet();

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
                        dataTable = ds.Tables[0];

                        excelReader.Close();

                        using (SqlConnection con = new SqlConnection(sCon))
                        {
                            con.Open();

                            // CHECK WHETHER TABLE HAS RECORDS OR NOT. IF YES THEN CLEARING THE RECORDS FROM TABLE.
                            cmd = new SqlCommand("Select * from bom", con);
                            cmd.CommandType = CommandType.Text;

                            SqlDataAdapter da = new SqlDataAdapter();
                            da.SelectCommand = cmd;
                            da.Fill(dt);

                            if (dt.Rows.Count > 0)
                            {
                                cmd = new SqlCommand("Delete from bom", con);
                                cmd.ExecuteNonQuery();
                            }

                            // FINALLY, LOAD DATA INTO THE DATABASE TABLE.
                            oSqlBulk = new SqlBulkCopy(con);
                            oSqlBulk.DestinationTableName = "bom"; // TABLE NAME.

                            //oSqlBulk.ColumnMappings.Add("FigureNumber", "FigureNumber");
                            //oSqlBulk.ColumnMappings.Add("Level", "Level");
                            //oSqlBulk.ColumnMappings.Add("Position", "Position");                            
                            //oSqlBulk.ColumnMappings.Add("ItemNumber", "ItemNumber");                            
                            //oSqlBulk.ColumnMappings.Add("desc", "Dec");
                            //oSqlBulk.ColumnMappings.Add("Net Quantity", "NetQuantity");
                            //oSqlBulk.ColumnMappings.Add("Inv Un", "InvUn");
                            //oSqlBulk.ColumnMappings.Add("Wrh", "Wrh");
                            //oSqlBulk.ColumnMappings.Add("Inventory on Hand", "InventoryOnHand");
                            //oSqlBulk.ColumnMappings.Add("Inventory on Order", "InventoryOnOrder");
                            //oSqlBulk.ColumnMappings.Add("Allocated Inventory", "AllocateInventoryOrder");

                            oSqlBulk.WriteToServer(dataTable);

                            lblConfirm.Text = "BOM DATA IMPORTED SUCCESSFULLY.";
                            lblConfirm.Attributes.Add("style", "color:green");
                        }
                    }
                    catch (Exception ex)
                    {
                        LogError(ex, "Exception from bom while file upload:");
                    }
                    finally
                    {
                        // CLEAR.
                        cmd.Dispose();
                        oSqlBulk.Close();
                        oSqlBulk = null;
                    }

                    int bomCounts = _dbObj.GetBOMCounts();
                    lblBomCount.Text = Convert.ToString(bomCounts);
                }
                else
                {
                    LogError(new Exception(), "WIP -- Upload file size content is zero!.");
                }
            }
            else
            {
                LogError(new Exception(), "WIP -- Doesn't have any file to uplaod. Please choose file!!:");
            }
        }

        protected void btImportForWIP_ServerClick(object sender, EventArgs e)
        {
            SqlBulkCopy oSqlBulk = null;
            //DBUtil _dbObj = new DBUtil();

            // CHECK IF A FILE HAS BEEN SELECTED.
            if ((FileUploadForWIP.HasFile))
            {
                if (!Convert.IsDBNull(FileUploadForWIP.PostedFile) &
                    FileUploadForWIP.PostedFile.ContentLength > 0)
                {
                    try
                    {
                        string sCon = ConfigurationManager.ConnectionStrings["VVConnection"].ToString();
                        SqlConnection conn = new SqlConnection(sCon);
                        DataTable dataTable = new DataTable();

                        var cmd = conn.CreateCommand();
                        cmd.CommandType = CommandType.Text;
                        cmd.CommandText = string.Format("SET FMTONLY ON; SELECT * FROM WIP; SET FMTONLY OFF;");
                        conn.Open();
                        dataTable.Load(cmd.ExecuteReader());
                        conn.Close();

                        string filename = Path.GetFileName(FileUploadForWIP.FileName);
                        FileUploadForWIP.SaveAs(Server.MapPath("~/") + filename);

                        FileStream stream;
                        IExcelDataReader excelReader = null;

                        DataSet ds = new DataSet();

                        stream = File.Open(Server.MapPath("~/") + filename, FileMode.Open, FileAccess.Read);

                        string getExtension = Path.GetExtension(FileUploadForWIP.FileName);

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

                        if (ds != null)
                        {
                            if (ds.Tables[0].Rows.Count > 0)
                            {
                                dataTable = ds.Tables[0];
                            }
                        }

                        // Inserting into WIP All
                        for (int k = 0; k < dataTable.Rows.Count; k++)
                        {
                            bool IsProdOrderNoExist = _dbObj.IsProdOrderNoAvailableFromWIPAll(dataTable.Rows[k]["Prod.Order"].ToString());

                            if (!IsProdOrderNoExist)
                            {
                                var prodOrderNo = Convert.ToString(dataTable.Rows[k]["Prod.Order"]);
                                var itemNumber = Convert.ToString(dataTable.Rows[k]["ItemNumber"]);
                                var description = Convert.ToString(dataTable.Rows[k]["Description"]);
                                string qtyOrdered = Convert.ToString(dataTable.Rows[k]["Quantity"]);

                                _dbObj.InsertWIPAllFromWIPImporting(prodOrderNo, itemNumber, description, qtyOrdered);
                            }
                        }

                        excelReader.Close();

                        using (SqlConnection con = new SqlConnection(sCon))
                        {
                            con.Open();

                            //// fetching wip uploaded items to compare with recent upload items
                            DataSet ds_fromDB = _dbObj.RetriveByWIPUploadItems();

                            if (ds_fromDB != null || dataTable != null)
                            {
                                if (ds_fromDB.Tables[0].Rows.Count > 0)
                                {
                                    #region Section for Take each row from WIP table and check whether it is available in excel. If not available in excel delete record of table

                                    for (int j = 0; j < ds_fromDB.Tables[0].Rows.Count; j++)
                                    {
                                        string prodOrder = ds_fromDB.Tables[0].Rows[j]["ProdOrder"].ToString();

                                        DataRow[] foundRows = dataTable.Select("[Prod.Order] = '" + prodOrder + "'");

                                        if (foundRows.Length == 0)
                                        {
                                            _dbObj.RemoveWIPItems(prodOrder);
                                        }
                                    }

                                    #endregion

                                    #region Section for comparing balQuantiy from upload excel into db  

                                    if (dataTable.Rows.Count > 0)
                                    {
                                        // from wip upload excel
                                        for (int i = 0; i < dataTable.Rows.Count; i++)
                                        {
                                            string prodOrder = dataTable.Rows[i]["Prod.Order"].ToString();
                                            string orderSeries = dataTable.Rows[i]["Prod.OrderSeries"].ToString();
                                            string relDate = dataTable.Rows[i]["Rel.Date"].ToString();
                                            string itemNumber = dataTable.Rows[i]["ItemNumber"].ToString();
                                            string description = dataTable.Rows[i]["Description"].ToString();
                                            string shopSC = dataTable.Rows[i]["Shop/Subcontract"].ToString();
                                            string buyer = "";
                                            string supplierCode = dataTable.Rows[i]["Supplier Code"].ToString();
                                            string supplierName = dataTable.Rows[i]["Supplier Name"].ToString();
                                            string qtyOrd = dataTable.Rows[i]["Quantity"].ToString();
                                            string qtyDlv = dataTable.Rows[i]["Del.Qty"].ToString();
                                            string balQuantity = dataTable.Rows[i]["Bal.Qty"].ToString();
                                            string wrh = dataTable.Rows[i]["Wrh"].ToString();
                                            string project = dataTable.Rows[i]["Project"].ToString();
                                            string orderStatus = dataTable.Rows[i]["OrderStatus"].ToString();
                                            string startDate = dataTable.Rows[i]["RemainingStartDate"].ToString();
                                            string finishDate = dataTable.Rows[i]["EarliestFinishDate"].ToString();

                                            string ageing = dataTable.Rows[i]["Ageing"].ToString();
                                            string ageingremarks = dataTable.Rows[i]["Ageing remarks"].ToString();

                                            // fecthing record from wip table to compare items into recent upload wip items
                                            DataSet dsForBalQuantity = _dbObj.RetriveByWIPItemsFromProdOrder(prodOrder);



                                            if (dsForBalQuantity != null)
                                            {
                                                if (dsForBalQuantity.Tables[0].Rows.Count > 0)
                                                {

                                                    #region WIP History
                                                    //string PoSeries = dsForBalQuantity.Tables[0].Rows[0]["PoSeries"].ToString().Trim();
                                                    //string DelDate = dsForBalQuantity.Tables[0].Rows[0]["DelDate"].ToString().Trim();
                                                    //string ItemNumbers = dsForBalQuantity.Tables[0].Rows[0]["ItemNumber"].ToString().Trim();
                                                    //string Descriptions = dsForBalQuantity.Tables[0].Rows[0]["Description"].ToString().Trim();
                                                    //string ShopSc = dsForBalQuantity.Tables[0].Rows[0]["ShopSC"].ToString().Trim();
                                                    //string Buyers = dsForBalQuantity.Tables[0].Rows[0]["Buyer"].ToString().Trim();
                                                    //string SupplierCode = dsForBalQuantity.Tables[0].Rows[0]["SupplierCode"].ToString().Trim();
                                                    //string SupplierName = dsForBalQuantity.Tables[0].Rows[0]["SupplierName"].ToString().Trim();
                                                    //string QtyOrd = dsForBalQuantity.Tables[0].Rows[0]["QtyOrd"].ToString().Trim();
                                                    //string QtyDlv = dsForBalQuantity.Tables[0].Rows[0]["QtyDlv"].ToString().Trim();

                                                    //string WRH = dsForBalQuantity.Tables[0].Rows[0]["WRH"].ToString().Trim();
                                                    //string Project = dsForBalQuantity.Tables[0].Rows[0]["Project"].ToString().Trim();
                                                    //string Status = dsForBalQuantity.Tables[0].Rows[0]["Status"].ToString().Trim();
                                                    //string StartDate = dsForBalQuantity.Tables[0].Rows[0]["StartDate"].ToString().Trim();
                                                    //string FinishDate = dsForBalQuantity.Tables[0].Rows[0]["FinishDate"].ToString().Trim();
                                                    //string Ageing = dsForBalQuantity.Tables[0].Rows[0]["Ageing"].ToString().Trim();
                                                    //string AgeingRemarks = dsForBalQuantity.Tables[0].Rows[0]["AgeingRemarks"].ToString().Trim();
                                                    //string Remarks = dsForBalQuantity.Tables[0].Rows[0]["Remarks"].ToString().Trim();
                                                    //string RecDate = dsForBalQuantity.Tables[0].Rows[0]["RecDate"].ToString().Trim();

                                                    // maintaining history data for wip
                                                    //_dbObj.InsertWIPHistory(ProOrder, PoSeries, DelDate, ItemNumbers, Descriptions, ShopSc, Buyers,
                                                    //    SupplierCode, SupplierName, QtyOrd, QtyDlv, BalQuantity,
                                                    //    WRH, Project, Status, StartDate, FinishDate,
                                                    //    Ageing, AgeingRemarks, Remarks, RecDate);


                                                    #endregion

                                                    string BalQuantity = dsForBalQuantity.Tables[0].Rows[0]["BalQuantity"].ToString().Trim();
                                                    string ProOrder = dsForBalQuantity.Tables[0].Rows[0]["ProdOrder"].ToString().Trim();

                                                    string ItemNumber = dsForBalQuantity.Tables[0].Rows[0]["ItemNumber"].ToString().Trim();
                                                    string Description = dsForBalQuantity.Tables[0].Rows[0]["Description"].ToString().Trim();
                                                    string OrderedQty = dsForBalQuantity.Tables[0].Rows[0]["QtyOrd"].ToString().Trim();
                                                    string DeliveredQty = dsForBalQuantity.Tables[0].Rows[0]["QtyDlv"].ToString().Trim();
                                                    string StartDate = dsForBalQuantity.Tables[0].Rows[0]["StartDate"].ToString().Trim();
                                                    string FinishDate = dsForBalQuantity.Tables[0].Rows[0]["FinishDate"].ToString().Trim();
                                                    string SupplierName = dsForBalQuantity.Tables[0].Rows[0]["SupplierName"].ToString().Trim();

                                                    if (prodOrder == ProOrder)
                                                    {
                                                        // update the balQuantity into db if mismatching from excel
                                                        _dbObj.UpdateWIPBalQuantity(ProOrder, balQuantity, itemNumber, description, qtyOrd, qtyDlv, startDate, finishDate, supplierName);

                                                        _dbObj.UpdateWIPRecDates();

                                                        lblConfirm.Text = "WIP DATA IMPORTED SUCCESSFULLY.";
                                                        lblConfirm.Attributes.Add("style", "color:green");
                                                    }
                                                }
                                                else
                                                {
                                                    // insert wip item into db
                                                    _dbObj.InsertWIPUploadItems(prodOrder, orderSeries, relDate, itemNumber, description, shopSC,
                                                        buyer, supplierCode, supplierName, qtyOrd, qtyDlv, balQuantity, wrh, project, orderStatus, startDate, finishDate,
                                                        ageing, ageingremarks);

                                                    _dbObj.UpdateWIPRecDates();

                                                    lblConfirm.Text = "WIP DATA IMPORTED SUCCESSFULLY.";
                                                    lblConfirm.Attributes.Add("style", "color:green");
                                                }
                                            }
                                            else
                                            {
                                                // insert wip item into db
                                                _dbObj.InsertWIPUploadItems(prodOrder, orderSeries, relDate, itemNumber, description, shopSC,
                                                        buyer, supplierCode, supplierName, qtyOrd, qtyDlv, balQuantity, wrh, project, orderStatus, startDate, finishDate,
                                                        ageing, ageingremarks);

                                                _dbObj.UpdateWIPRecDates();

                                                lblConfirm.Text = "WIP DATA IMPORTED SUCCESSFULLY.";
                                                lblConfirm.Attributes.Add("style", "color:green");
                                            }
                                        }
                                    }

                                    #endregion
                                }
                                else
                                {
                                    // FINALLY, LOAD DATA INTO THE DATABASE TABLE.
                                    oSqlBulk = new SqlBulkCopy(con);
                                    oSqlBulk.DestinationTableName = "wip"; // TABLE NAME.

                                    oSqlBulk.WriteToServer(dataTable);

                                    _dbObj.UpdateWIPBuyers();

                                    _dbObj.UpdateWIPRecDates();

                                    lblConfirm.Text = "WIP DATA IMPORTED SUCCESSFULLY.";
                                    lblConfirm.Attributes.Add("style", "color:green");
                                }
                            }

                            else
                            {
                                // FINALLY, LOAD DATA INTO THE DATABASE TABLE.
                                oSqlBulk = new SqlBulkCopy(con);
                                oSqlBulk.DestinationTableName = "wip"; // TABLE NAME.

                                oSqlBulk.WriteToServer(dataTable);

                                _dbObj.UpdateWIPBuyers();

                                //ShowWIPGrid();

                                _dbObj.UpdateWIPRecDates();

                                lblConfirm.Text = "WIP DATA IMPORTED SUCCESSFULLY.";
                                lblConfirm.Attributes.Add("style", "color:green");
                            }
                        }

                    }
                    catch (Exception ex)
                    {
                        LogError(ex, "Exception from wip");
                    }
                    finally
                    {
                        // CLEAR.
                        cmd.Dispose();
                    }

                    int wipCounts = _dbObj.GetWIPCounts();
                    lblWipCount.Text = Convert.ToString(wipCounts);

                }
                else
                {
                    LogError(new Exception(), "WIP -- Upload file size content is zero!.");
                }
            }
            else
            {
                LogError(new Exception(), "WIP -- Doesn't have any file to uplaod. Please choose file!!:");
            }
        }

        protected void btImportForPO_ServerClick(object sender, EventArgs e)
        {
            SqlBulkCopy oSqlBulk = null;
            DataSet ds = new DataSet();

            // CHECK IF A FILE HAS BEEN SELECTED.
            if ((FileUploadForPO.HasFile))
            {
                if (!Convert.IsDBNull(FileUploadForPO.PostedFile) &
                    FileUploadForPO.PostedFile.ContentLength > 0)
                {
                    try
                    {
                        string sCon = ConfigurationManager.ConnectionStrings["VVConnection"].ToString();
                        SqlConnection conn = new SqlConnection(sCon);
                        var dataTable = new DataTable();

                        //dataTable.Columns.Add(new DataColumn("PoOrder", System.Type.GetType("System.Int32")));
                        //dataTable.Columns.Add(new DataColumn("POPosition", System.Type.GetType("System.Int32")));
                        //dataTable.Columns.Add(new DataColumn("OrderDate", System.Type.GetType("System.String")));
                        //dataTable.Columns.Add(new DataColumn("PlanDelDate", System.Type.GetType("System.String")));
                        //dataTable.Columns.Add(new DataColumn("ItemNumber", System.Type.GetType("System.String")));
                        //dataTable.Columns.Add(new DataColumn("Description", System.Type.GetType("System.String")));
                        //dataTable.Columns.Add(new DataColumn("OrderBalance", System.Type.GetType("System.Double")));
                        //dataTable.Columns.Add(new DataColumn("ReferenceA", System.Type.GetType("System.String")));
                        //dataTable.Columns.Add(new DataColumn("Name", System.Type.GetType("System.String")));
                        //dataTable.Columns.Add(new DataColumn("X", System.Type.GetType("System.String")));
                        //dataTable.Columns.Add(new DataColumn("Commitment", System.Type.GetType("System.String")));

                        var cmd = conn.CreateCommand();
                        cmd.CommandType = CommandType.Text;
                        cmd.CommandText = string.Format("SET FMTONLY ON; SELECT * FROM PO; SET FMTONLY OFF;");
                        conn.Open();
                        dataTable.Load(cmd.ExecuteReader());
                        conn.Close();

                        string filename = Path.GetFileName(FileUploadForPO.FileName);
                        FileUploadForPO.SaveAs(Server.MapPath("~/") + filename);

                        FileStream stream;
                        IExcelDataReader excelReader = null;

                        //String ExcelPath = Program.GetAppSetting("MapPath").Trim() + "\\AUS.xls";
                        stream = File.Open(Server.MapPath("~/") + filename, FileMode.Open, FileAccess.Read);

                        string getExtension = Path.GetExtension(FileUploadForPO.FileName);

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

                        //DBUtil _dbObj = new DBUtil();

                        using (SqlConnection con = new SqlConnection(sCon))
                        {
                            con.Open();

                            //// fetching wip uploaded items to compare with recent upload items
                            DataSet ds_fromDB = _dbObj.RetriveByPOUploadItems();

                            if (ds_fromDB != null || dataTable != null)
                            {
                                if (ds_fromDB.Tables[0].Rows.Count > 0)
                                {
                                    #region Section for Take each row from PO table and check whether it is available in excel. If not available in excel delete record of table

                                    for (int j = 0; j < ds_fromDB.Tables[0].Rows.Count; j++)
                                    {
                                        string poOrderNo = ds_fromDB.Tables[0].Rows[j]["PoOrder"].ToString();
                                        string poPosition = ds_fromDB.Tables[0].Rows[j]["POPosition"].ToString();

                                        DataRow[] foundRows = dataTable.Select("[Order] = '" + poOrderNo + "' and [Pos] = '" + poPosition + "'");

                                        if (foundRows.Length == 0)
                                        {
                                            _dbObj.RemovePOItems(poOrderNo, Convert.ToInt32(poPosition));
                                        }
                                    }

                                    #endregion

                                    if (dataTable.Rows.Count > 0)
                                    {
                                        // from wip upload excel
                                        for (int i = 0; i < dataTable.Rows.Count; i++)
                                        {
                                            string companyNo = dataTable.Rows[i]["Company No"].ToString();
                                            string poOrder = dataTable.Rows[i]["Order"].ToString();
                                            string poPosition = dataTable.Rows[i]["Pos"].ToString();
                                            string orderDate = dataTable.Rows[i]["Order Date"].ToString();
                                            string planDelDate = dataTable.Rows[i]["Plan Del. Date"].ToString();
                                            string confDate = dataTable.Rows[i]["Conf. Date"].ToString();
                                            string chqBy = dataTable.Rows[i]["Chq by"].ToString();
                                            string chqDate = dataTable.Rows[i]["Chq. Date"].ToString();
                                            string itemNumber = dataTable.Rows[i]["Item"].ToString();
                                            string warehouse = dataTable.Rows[i]["Warehouse"].ToString();
                                            string description = dataTable.Rows[i]["Description"].ToString();

                                            string ig = dataTable.Rows[i]["IG"].ToString();
                                            string exp = dataTable.Rows[i]["EXP"].ToString();
                                            string price = dataTable.Rows[i]["Price"].ToString();
                                            string currency = dataTable.Rows[i]["Currency"].ToString();
                                            string ordered = dataTable.Rows[i]["Ordered"].ToString();
                                            string deliv = dataTable.Rows[i]["Deliv."].ToString();

                                            string orderBalance = dataTable.Rows[i]["Order Balance"].ToString();
                                            string amount = dataTable.Rows[i]["Amount"].ToString();
                                            string baseCurrency = dataTable.Rows[i]["Base Curr. [INR]"].ToString();
                                            string referenceA = dataTable.Rows[i]["Reference A"].ToString();
                                            string referenceB = dataTable.Rows[i]["Reference B"].ToString();

                                            string supplier = dataTable.Rows[i]["Supplier"].ToString();
                                            string name = dataTable.Rows[i]["Name"].ToString();
                                            string project = dataTable.Rows[i]["Project"].ToString();
                                            string description1 = dataTable.Rows[i]["Description"].ToString();
                                            string mo = dataTable.Rows[i]["M/O"].ToString();
                                            string pn = dataTable.Rows[i]["P/N"].ToString();
                                            string description2 = dataTable.Rows[i]["Description"].ToString();
                                            string standCost = dataTable.Rows[i]["Stand. Cost Price [INR]"].ToString();

                                            //string x = dataTable.Rows[i]["X"].ToString();

                                            // fecthing record from wip table to compare items into recent upload wip items
                                            DataSet dsForOrderBalance = _dbObj.RetriveByPOItemsFromOrderNo(poOrder, poPosition);

                                            if (dsForOrderBalance != null)
                                            {
                                                if (dsForOrderBalance.Tables[0].Rows.Count > 0)
                                                {
                                                    #region PO History
                                                    // TODO: Commented section not required for currently fuctionality. Usage of maintaing the history of PO table
                                                    //string CompanyNO = dsForOrderBalance.Tables[0].Rows[0]["CompanyNO"].ToString().Trim();

                                                    //string POPosition = dsForOrderBalance.Tables[0].Rows[0]["POPosition"].ToString().Trim();
                                                    //string OrderDate = dsForOrderBalance.Tables[0].Rows[0]["OrderDate"].ToString().Trim();
                                                    //string PlanDelDate = dsForOrderBalance.Tables[0].Rows[0]["PlanDelDate"].ToString().Trim();
                                                    //string ConfDate = dsForOrderBalance.Tables[0].Rows[0]["ConfDate"].ToString().Trim();
                                                    //string ChqBy = dsForOrderBalance.Tables[0].Rows[0]["ChqBy"].ToString().Trim();
                                                    //string ChqDate = dsForOrderBalance.Tables[0].Rows[0]["ChqDate"].ToString().Trim();
                                                    //string ItemNumber = dsForOrderBalance.Tables[0].Rows[0]["ItemNumber"].ToString().Trim();
                                                    //string Warehouse = dsForOrderBalance.Tables[0].Rows[0]["Warehouse"].ToString().Trim();
                                                    //string Description = dsForOrderBalance.Tables[0].Rows[0]["Description"].ToString().Trim();
                                                    //string IG = dsForOrderBalance.Tables[0].Rows[0]["IG"].ToString().Trim();
                                                    //string EXP = dsForOrderBalance.Tables[0].Rows[0]["EXP"].ToString().Trim();
                                                    //string Price = dsForOrderBalance.Tables[0].Rows[0]["Price"].ToString().Trim();
                                                    //string Currency = dsForOrderBalance.Tables[0].Rows[0]["Currency"].ToString().Trim();
                                                    //string Ordered = dsForOrderBalance.Tables[0].Rows[0]["Ordered"].ToString().Trim();
                                                    //string Deliv = dsForOrderBalance.Tables[0].Rows[0]["Deliv"].ToString().Trim();

                                                    //string Amount = dsForOrderBalance.Tables[0].Rows[0]["Amount"].ToString().Trim();
                                                    //string BaseCurrency = dsForOrderBalance.Tables[0].Rows[0]["BaseCurrency"].ToString().Trim();

                                                    //string ReferenceA = dsForOrderBalance.Tables[0].Rows[0]["ReferenceA"].ToString().Trim();
                                                    //string ReferenceB = dsForOrderBalance.Tables[0].Rows[0]["ReferenceB"].ToString().Trim();
                                                    //string Supplier = dsForOrderBalance.Tables[0].Rows[0]["Supplier"].ToString().Trim();
                                                    //string Name = dsForOrderBalance.Tables[0].Rows[0]["Name"].ToString().Trim();
                                                    //string Project = dsForOrderBalance.Tables[0].Rows[0]["Project"].ToString().Trim();
                                                    //string Description2 = dsForOrderBalance.Tables[0].Rows[0]["Description2"].ToString().Trim();
                                                    //string MO = dsForOrderBalance.Tables[0].Rows[0]["MO"].ToString().Trim();
                                                    //string PN = dsForOrderBalance.Tables[0].Rows[0]["PN"].ToString().Trim();
                                                    //string PnDescription = dsForOrderBalance.Tables[0].Rows[0]["PnDescription"].ToString().Trim();
                                                    //string StandCost = dsForOrderBalance.Tables[0].Rows[0]["StandCost"].ToString().Trim();
                                                    //string Commitment = dsForOrderBalance.Tables[0].Rows[0]["Commitment"].ToString().Trim();
                                                    //string Buyer = dsForOrderBalance.Tables[0].Rows[0]["Buyer"].ToString().Trim();

                                                    //string Remarks = dsForOrderBalance.Tables[0].Rows[0]["Remarks"].ToString().Trim();

                                                    // maintaning history for PO table update
                                                    //_dbObj.InsertPOHistory(CompanyNO, PoOrder, POPosition, OrderDate, PlanDelDate, ConfDate,
                                                    //     ChqBy, ChqDate, ItemNumber, Warehouse, Description, IG, EXP, Price, Currency, Ordered,
                                                    //     Deliv, OrderBalance, Amount, BaseCurrency, ReferenceA, ReferenceB, Supplier, Name, Project, Description2,
                                                    //    MO, PN, PnDescription, StandCost, Commitment, Buyer, Remarks);

                                                    #endregion

                                                    string OrderBalance = dsForOrderBalance.Tables[0].Rows[0]["OrderBalance"].ToString().Trim();
                                                    string PoOrder = dsForOrderBalance.Tables[0].Rows[0]["PoOrder"].ToString().Trim();

                                                    string ItemNumber = dsForOrderBalance.Tables[0].Rows[0]["ItemNumber"].ToString().Trim();
                                                    string Description = dsForOrderBalance.Tables[0].Rows[0]["Description"].ToString().Trim();
                                                    string OrderedQty = dsForOrderBalance.Tables[0].Rows[0]["Ordered"].ToString().Trim();
                                                    string DeliveredQty = dsForOrderBalance.Tables[0].Rows[0]["Deliv"].ToString().Trim();

                                                    //if (OrderBalance != orderBalance && PoOrder == poOrder)
                                                    //{
                                                    // update the orderBalance into db if mismatching from excel
                                                    _dbObj.UpdatePOBalanceQuantity(PoOrder, poPosition, orderBalance, itemNumber, description,
                                                        ordered, deliv, planDelDate);

                                                    _dbObj.UpdatePOCommitmentDate();

                                                    lblConfirm.Text = "PO DATA IMPORTED SUCCESSFULLY.";
                                                    lblConfirm.Attributes.Add("style", "color:green");
                                                    //}
                                                }
                                                else
                                                {
                                                    // insert upload excel po item into db
                                                    _dbObj.InsertPOUploadItems(companyNo, poOrder, poPosition, orderDate, planDelDate, confDate,
                                                        chqBy, chqDate, itemNumber, warehouse, description, ig, exp, price, currency, ordered,
                                                        deliv, orderBalance, amount, baseCurrency, referenceA, referenceB, supplier, name, project, description1,
                                                        mo, pn, description2, standCost);

                                                    _dbObj.UpdatePOCommitmentDate();

                                                    lblConfirm.Text = "PO DATA IMPORTED SUCCESSFULLY.";
                                                    lblConfirm.Attributes.Add("style", "color:green");
                                                }
                                            }
                                            else
                                            {
                                                // insert upload excel po item into db
                                                _dbObj.InsertPOUploadItems(companyNo, poOrder, poPosition, orderDate, planDelDate, confDate,
                                                       chqBy, chqDate, itemNumber, warehouse, description, ig, exp, price, currency, ordered,
                                                       deliv, orderBalance, amount, baseCurrency, referenceA, referenceB, supplier, name, project, description1,
                                                       mo, pn, description2, standCost);

                                                _dbObj.UpdatePOCommitmentDate();

                                                lblConfirm.Text = "PO DATA IMPORTED SUCCESSFULLY.";
                                                lblConfirm.Attributes.Add("style", "color:green");
                                            }
                                        }
                                    }
                                }
                                else
                                {
                                    // FINALLY, LOAD DATA INTO THE DATABASE TABLE.
                                    oSqlBulk = new SqlBulkCopy(con);
                                    oSqlBulk.DestinationTableName = "po"; // TABLE NAME.


                                    //oSqlBulk.ColumnMappings.Add("Order", "PoOrder");
                                    //oSqlBulk.ColumnMappings.Add("Pos", "POPosition");
                                    //oSqlBulk.ColumnMappings.Add("Order Date", "OrderDate");
                                    //oSqlBulk.ColumnMappings.Add("Plan Del. Date", "PlanDelDate");
                                    //oSqlBulk.ColumnMappings.Add("Item", "ItemNumber");
                                    //oSqlBulk.ColumnMappings.Add("Description", "Description");
                                    //oSqlBulk.ColumnMappings.Add("Order Balance", "OrderBalance");
                                    //oSqlBulk.ColumnMappings.Add("Reference A", "ReferenceA");
                                    //oSqlBulk.ColumnMappings.Add("Name", "Name");
                                    //oSqlBulk.ColumnMappings.Add("X", "X");

                                    oSqlBulk.WriteToServer(dataTable);

                                    //ShowPOGrid();

                                    _dbObj.UpdatePOCommitmentDate();

                                    lblConfirm.Text = "PO DATA IMPORTED SUCCESSFULLY.";
                                    lblConfirm.Attributes.Add("style", "color:green");
                                }
                            }
                            else
                            {
                                // FINALLY, LOAD DATA INTO THE DATABASE TABLE.
                                oSqlBulk = new SqlBulkCopy(con);
                                oSqlBulk.DestinationTableName = "po"; // TABLE NAME.


                                oSqlBulk.ColumnMappings.Add("Order", "PoOrder");
                                oSqlBulk.ColumnMappings.Add("Pos", "POPosition");
                                oSqlBulk.ColumnMappings.Add("Order Date", "OrderDate");
                                oSqlBulk.ColumnMappings.Add("Plan Del. Date", "PlanDelDate");
                                oSqlBulk.ColumnMappings.Add("Item", "ItemNumber");
                                oSqlBulk.ColumnMappings.Add("Description", "Description");
                                oSqlBulk.ColumnMappings.Add("Order Balance", "OrderBalance");
                                oSqlBulk.ColumnMappings.Add("Reference A", "ReferenceA");
                                oSqlBulk.ColumnMappings.Add("Name", "Name");
                                //oSqlBulk.ColumnMappings.Add("X", "X");

                                oSqlBulk.WriteToServer(dataTable);
                                //ShowPOGrid();

                                _dbObj.UpdatePOCommitmentDate();

                                lblConfirm.Text = "PO DATA IMPORTED SUCCESSFULLY.";
                                lblConfirm.Attributes.Add("style", "color:green");
                            }
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

                    int poCounts = _dbObj.GetPOCounts();
                    lblPoCount.Text = Convert.ToString(poCounts);
                }
                else
                {
                    LogError(new Exception(), "PO -- Upload file size content is zero!.");
                }
            }
            else
            {
                LogError(new Exception(), "PO -- Doesn't have any file to uplaod. Please choose file!!:");
            }
        }

        protected void btImportForInventory_ServerClick(object sender, EventArgs e)
        {
            SqlBulkCopy oSqlBulk = null;

            // CHECK IF A FILE HAS BEEN SELECTED.
            if ((FileUploadForInventory.HasFile))
            {

                if (!Convert.IsDBNull(FileUploadForInventory.PostedFile) &
                    FileUploadForInventory.PostedFile.ContentLength > 0)
                {
                    try
                    {
                        string sCon = ConfigurationManager.ConnectionStrings["VVConnection"].ToString();
                        SqlConnection conn = new SqlConnection(sCon);
                        var dataTable = new DataTable();
                        var cmd = conn.CreateCommand();
                        cmd.CommandType = CommandType.Text;
                        cmd.CommandText = string.Format("SET FMTONLY ON; SELECT * FROM Inventory; SET FMTONLY OFF;");
                        conn.Open();
                        dataTable.Load(cmd.ExecuteReader());
                        conn.Close();

                        string filename = Path.GetFileName(FileUploadForInventory.FileName);
                        FileUploadForInventory.SaveAs(Server.MapPath("~/") + filename);

                        FileStream stream;
                        IExcelDataReader excelReader = null;

                        DataSet ds = new DataSet();

                        stream = File.Open(Server.MapPath("~/") + filename, FileMode.Open, FileAccess.Read);

                        string getExtension = Path.GetExtension(FileUploadForInventory.FileName);

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
                        dataTable = ds.Tables[0];
                        excelReader.Close();

                        using (SqlConnection con = new SqlConnection(sCon))
                        {
                            con.Open();

                            // CHECK WHETHER TABLE HAS RECORDS OR NOT. IF YES THEN CLEARING THE RECORDS FROM TABLE.
                            cmd = new SqlCommand("select * from inventory", con);
                            cmd.CommandType = CommandType.Text;

                            SqlDataAdapter da = new SqlDataAdapter();
                            da.SelectCommand = cmd;
                            da.Fill(dt);

                            if (dt.Rows.Count > 0)
                            {
                                cmd = new SqlCommand("delete from inventory", con);
                                cmd.ExecuteNonQuery();
                            }

                            // FINALLY, LOAD DATA INTO THE DATABASE TABLE.
                            oSqlBulk = new SqlBulkCopy(con);
                            oSqlBulk.DestinationTableName = "Inventory"; // TABLE NAME.

                            oSqlBulk.WriteToServer(dataTable);

                            lblConfirm.Text = "INVENTORY DATA IMPORTED SUCCESSFULLY.";
                            lblConfirm.Attributes.Add("style", "color:green");
                        }

                    }
                    catch (Exception ex)
                    {
                        LogError(ex, "Exception from InventoryList:");
                    }
                    finally
                    {
                        // CLEAR.
                        cmd.Dispose();
                        oSqlBulk.Close();
                        oSqlBulk = null;
                    }

                    int inventoryCounts = _dbObj.GetInventoryCounts();
                    lblInventoryCount.Text = Convert.ToString(inventoryCounts);
                }
                else
                {
                    LogError(new Exception(), "Inventory -- Upload file size content is zero!.");
                }
            }
            else
            {
                LogError(new Exception(), "Inventory -- Doesn't have any file to uplaod. Please choose file!!:");
            }
        }

        protected void btnProcess_Click(object sender, EventArgs e)
        {
            string query = string.Empty;
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand();
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["VVConnection"].ConnectionString.ToString());

            try
            {
                conn.Open();
                cmd = new SqlCommand("[dbo].[spProcessOrders]", conn);
                cmd.CommandTimeout = 10000;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.ExecuteNonQuery();

                lblConfirm.Text = "DATA PROCESSED SUCCESSFULLY.";
                lblConfirm.Attributes.Add("style", "color:green");
            }
            catch (Exception ex)
            {
                LogError(ex, "Exception from while processing orders");
            }
            finally
            {
                conn.Close();
            }
        }

        protected void btnExport_Click(object sender, EventArgs e)
        {
            string query = string.Empty;
            string str = string.Empty;
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand();
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["VVConnection"].ConnectionString.ToString());

            try
            {
                conn.Open();

                cmd = new SqlCommand("[spGetProcessOrders]", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = cmd;

                da.Fill(dt);

                if (dt.Rows.Count > 0)
                {
                    Response.ClearContent();
                    Response.Buffer = true;
                    Response.AddHeader("content-disposition", string.Format("attachment; filename={0}", "ProcessedOrders.xls"));
                    Response.ContentType = "application/ms-excel";

                    foreach (DataColumn dtcol in dt.Columns)
                    {
                        Response.Write(str + dtcol.ColumnName);
                        str = "\t";
                    }
                    Response.Write("\n");
                    foreach (DataRow dr in dt.Rows)
                    {
                        str = "";
                        for (int j = 0; j < dt.Columns.Count; j++)
                        {
                            Response.Write(str + Convert.ToString(dr[j]));
                            str = "\t";
                        }
                        Response.Write("\n");
                    }
                    Response.End();

                }
                else
                {
                    lblConfirm.Text = "No Records Found.";
                    lblConfirm.Attributes.Add("style", "color:Red");
                }
            }
            catch (Exception ex)
            {
                LogError(ex, "Exception from export button click!");
            }
            finally
            {
                conn.Close();
            }
        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            DataSet ds = (DataSet)Cache["CacheFromProcessedItems"];

            GridView1.PageIndex = e.NewPageIndex;
            GridView1.DataSource = ds;
            GridView1.DataBind();

            try
            {
                DataView dv;
                dv = ds.Tables[0].DefaultView;
                GridView1.DataSource = dv;
                GridView1.DataBind();
            }
            catch (Exception ex)
            {
                LogError(ex, "Exception from while clicking on page number from Processed Items.");
            }
        }

        /// <summary>
        /// Method for get excel sheet names
        /// </summary>
        /// <param name="conn"></param>
        /// <returns></returns>
        public List<string> GetSheetNames(OleDbConnection conn)
        {
            var sheetNames = new List<string>();

            try
            {
                if (conn.State != ConnectionState.Open)
                {
                    conn.Open();
                }
                DataTable excelSchema = conn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);

                foreach (DataRow row in excelSchema.Rows)
                {
                    if ((!row["TABLE_NAME"].ToString().Contains("FilterDatabase") && !row["TABLE_NAME"].ToString().Contains("Print_Titles")))
                    {
                        sheetNames.Add(row["TABLE_NAME"].ToString());
                    }
                }
            }
            catch (Exception ex)
            {
                LogError(ex, "Exception From Get ExcelSheet Name");
            }
            finally
            {
            }

            return sheetNames;
        }

        public void showgrid()
        {
            try
            {
                //DBUtil _DBObj = new DBUtil();
                DataSet ds = _dbObj.RetriveByProcessedItems();

                Cache["CacheFromProcessedItems"] = ds;

                GridView1.DataSource = ds;
                GridView1.DataBind();
                Multiview1.ActiveViewIndex = 0;
            }
            catch (Exception ex)
            {
                LogError(ex, "Exception from export button click!");
            }
        }

        /// <summary>
        /// Method for Error logs 
        /// </summary>
        /// <param name="ex"></param>
        /// <param name="section"></param>
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

        protected void btnSearchBox_Click(object sender, EventArgs e)
        {
            String searchRowFilter = String.Empty, searchRowFilter1 = String.Empty, searchRowFilter2 = String.Empty, searchRowFilter3 = String.Empty, searchRowFilter4 = String.Empty;

            SearchPanel.Visible = true;

            string OrderNo = txtOrderNumber.Text;
            string Pos = txtPos.Text;
            string Item = txtItem.Text;
            string ItemNumber = txtItemNumber.Text;

            if (!string.IsNullOrEmpty(OrderNo))
            {
                searchRowFilter1 = "OrderNo = '" + OrderNo + "'";
            }
            if (!string.IsNullOrEmpty(Pos))
            {
                searchRowFilter2 = "Pos = '" + Pos + "'";
            }
            if (!string.IsNullOrEmpty(Item))
            {
                searchRowFilter3 = "Item = '" + Item + "'";
            }
            if (!string.IsNullOrEmpty(ItemNumber))
            {
                searchRowFilter4 = "ItemNumber = '" + ItemNumber + "'";
            }

            if (!String.IsNullOrEmpty(searchRowFilter1))
                searchRowFilter = searchRowFilter1;

            if (!String.IsNullOrEmpty(searchRowFilter2))
            {
                if (!String.IsNullOrEmpty(searchRowFilter))
                    searchRowFilter = searchRowFilter + " AND " + searchRowFilter2;
                else
                    searchRowFilter = searchRowFilter2;
            }

            if (!String.IsNullOrEmpty(searchRowFilter3))
            {
                if (!String.IsNullOrEmpty(searchRowFilter))
                    searchRowFilter = searchRowFilter + " AND " + searchRowFilter3;
                else
                    searchRowFilter = searchRowFilter3;
            }

            if (!String.IsNullOrEmpty(searchRowFilter4))
            {
                if (!String.IsNullOrEmpty(searchRowFilter))
                    searchRowFilter = searchRowFilter + " AND " + searchRowFilter4;
                else
                    searchRowFilter = searchRowFilter4;
            }

            if (!String.IsNullOrEmpty(searchRowFilter))
            {
                DataSet searchDS = (DataSet)Cache["CacheFromProcessedItems"];

                DataView dv;
                dv = searchDS.Tables[0].DefaultView;

                dv.RowFilter = searchRowFilter;

                GridView1.DataSource = dv;
                GridView1.DataBind();
            }
            else
            {
                DataSet searchDS = (DataSet)Cache["CacheFromProcessedItems"];
                GridView1.DataSource = searchDS;
                GridView1.DataBind();
            }
        }

        protected void btnDisplay_Click(object sender, EventArgs e)
        {
            SearchPanel.Visible = true;
            lblConfirm.Text = "";
            showgrid();
        }


        protected void GridView2_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            DataSet searchDS = (DataSet)Cache["CacheFromWIPUploadItems"];
            GridView2.DataSource = searchDS;
            GridView2.DataBind();

            GridView2.EditIndex = -1;
            //  showgrid();

            GridView2.DataSource = searchDS;
            GridView2.DataBind();

            GridView2.EditIndex = -1;
        }

        protected void GridView2_RowEditing(object sender, GridViewEditEventArgs e)
        {
            DataSet searchDS = (DataSet)Cache["CacheFromWIPUploadItems"];
            GridView2.DataSource = searchDS;
            GridView2.DataBind();

            GridView2.EditIndex = e.NewEditIndex;
            //  showgrid();

            //DataSet searchDS = (DataSet)Cache["TPIOfferingDataFromDBCache"];
            GridView2.DataSource = searchDS;
            GridView2.DataBind();

        }

        protected void GridView2_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            try
            {
                Label lbProdOrderNo = (Label)GridView2.Rows[e.RowIndex].FindControl("lblProdOrderNo");
                Label lbItemNumber = (Label)GridView2.Rows[e.RowIndex].FindControl("lblItemNumber");
                TextBox txtRecDate = (TextBox)GridView2.Rows[e.RowIndex].FindControl("txtRecDate");

                //DBUtil _dbObj = new DBUtil();
                //_dbObj.UpdateWIPRecDate(lbProdOrderNo.Text.Trim(), lbItemNumber.Text.Trim(), txtRecDate.Text.Trim());

                GridView2.EditIndex = -1;
                ShowWIPGrid();
            }
            catch (Exception ex)
            {
                LogError(ex, "Exception from while updating row from WIP Upload Items.");
            }
        }

        protected void GridView2_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            DataSet ds = (DataSet)Cache["CacheFromWIPUploadItems"];

            GridView2.PageIndex = e.NewPageIndex;
            GridView2.DataSource = ds;
            GridView2.DataBind();

            try
            {
                DataView dv;
                dv = ds.Tables[0].DefaultView;
                GridView2.DataSource = dv;
                GridView2.DataBind();
            }
            catch (Exception ex)
            {
                LogError(ex, "Exception from while clicking on page number from WIP Upload Items.");
            }
        }


        public void ShowWIPGrid()
        {
            try
            {
                //DBUtil _DBObj = new DBUtil();
                DataSet ds = _dbObj.RetriveByWIPUploadItems();

                Cache["CacheFromWIPUploadItems"] = ds;

                GridView2.DataSource = ds;
                GridView2.DataBind();
                Multiview1.ActiveViewIndex = 1;
            }
            catch (Exception ex)
            {
                LogError(ex, "Exception from Upload WIP button click!");
            }
        }

        public void ShowPOGrid()
        {
            try
            {
                //DBUtil _DBObj = new DBUtil();
                DataSet ds = _dbObj.RetriveByPOUploadItems();

                Cache["CacheFromPOUploadItems"] = ds;

                GridView3.DataSource = ds;
                GridView3.DataBind();
                Multiview1.ActiveViewIndex = 2;
            }
            catch (Exception ex)
            {
                LogError(ex, "Exception from Upload PO button click!");
            }
        }

        protected void GridView3_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            DataSet searchDS = (DataSet)Cache["CacheFromPOUploadItems"];
            GridView3.DataSource = searchDS;
            GridView3.DataBind();

            GridView3.EditIndex = -1;
            //  showgrid();

            GridView3.DataSource = searchDS;
            GridView3.DataBind();

            GridView3.EditIndex = -1;
        }

        protected void GridView3_RowEditing(object sender, GridViewEditEventArgs e)
        {
            DataSet searchDS = (DataSet)Cache["CacheFromPOUploadItems"];
            GridView3.DataSource = searchDS;
            GridView3.DataBind();

            GridView3.EditIndex = e.NewEditIndex;
            //  showgrid();

            //DataSet searchDS = (DataSet)Cache["TPIOfferingDataFromDBCache"];
            GridView3.DataSource = searchDS;
            GridView3.DataBind();

        }

        protected void GridView3_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            try
            {
                Label lbItemNumber = (Label)GridView3.Rows[e.RowIndex].FindControl("lblItemNumber");
                Label lbPoPosition = (Label)GridView3.Rows[e.RowIndex].FindControl("lblPOPosition");

                TextBox txtCommittment = (TextBox)GridView3.Rows[e.RowIndex].FindControl("txtCommitment");

                //DBUtil _dbObj = new DBUtil();
                //_dbObj.UpdatePOCommittment(lbItemNumber.Text.Trim(), lbPoPosition.Text.Trim(), txtCommittment.Text.Trim());

                GridView3.EditIndex = -1;
                ShowPOGrid();
            }
            catch (Exception ex)
            {
                LogError(ex, "Exception from while updating row from PO Upload Items.");
            }
        }

        protected void GridView3_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            DataSet ds = (DataSet)Cache["CacheFromPOUploadItems"];

            GridView3.PageIndex = e.NewPageIndex;
            GridView3.DataSource = ds;
            GridView3.DataBind();

            try
            {
                DataView dv;
                dv = ds.Tables[0].DefaultView;
                GridView3.DataSource = dv;
                GridView3.DataBind();
            }
            catch (Exception ex)
            {
                LogError(ex, "Exception from PO while clicking on page number for Uploaded Items.");
            }
        }

        protected void btnDisplayWIPUploadItems_ServerClick(object sender, EventArgs e)
        {
            SearchPanel.Visible = false;
            lblConfirm.Text = "";
            ShowWIPGrid();
        }

        protected void btnDisplayPOUploadItems_ServerClick(object sender, EventArgs e)
        {
            SearchPanel.Visible = false;
            lblConfirm.Text = "";
            ShowPOGrid();
        }

        protected void btnWIPBulkUpdate_ServerClick(object sender, EventArgs e)
        {
            //DBUtil _DBObj = new DBUtil();
            DataSet ds;

            try
            {
                foreach (GridViewRow row in GridView2.Rows)
                {
                    ds = new DataSet();
                    ds = _dbObj.RetrieveWIPData();
                    Cache["CacheFromWIPUploadItems"] = ds;

                    bool isChecked = ((CheckBox)row.FindControl("chkSelect")).Checked;
                    if (isChecked)
                    {
                        String OrderNo = ((System.Web.UI.HtmlControls.HtmlInputHidden)row.FindControl("hidProdOrder")).Value.ToString();
                        String lblProdOrderNo = ((Label)row.FindControl("lblProdOrderNo")).Text.ToString();
                        String lblItemNumber = ((Label)row.FindControl("lblItemNumber")).Text.ToString();
                        string RecDate = ((TextBox)row.FindControl("txtRecDate")).Text.ToString();

                        //DBUtil _dbObj = new DBUtil();
                        if (!string.IsNullOrEmpty(RecDate))
                        {
                            //_dbObj.UpdateWIPRecDate(lblProdOrderNo.Trim(), lblItemNumber.Trim(), RecDate.Trim());
                        }

                        lblConfirm.Text = "WIP Rec Date's Updated Successfully.";
                        lblConfirm.Attributes.Add("style", "color:green");
                    }
                }

                ShowWIPGrid();
            }
            catch (Exception ex)
            {
                LogError(ex, "Exception occured while bulk updating wip rec date.");
            }
        }

        protected void btnPOBulkUpdate_ServerClick(object sender, EventArgs e)
        {
            //DBUtil _DBObj = new DBUtil();
            DataSet ds;

            try
            {
                foreach (GridViewRow row in GridView3.Rows)
                {
                    ds = new DataSet();
                    ds = _dbObj.RetriveByPOUploadItems();
                    Cache["CacheFromPOUploadItems"] = ds;

                    bool isChecked = ((CheckBox)row.FindControl("chkSelect")).Checked;
                    if (isChecked)
                    {
                        String lblPOPosition = ((Label)row.FindControl("lblPOPosition")).Text.ToString();
                        String lblOrderNo = ((Label)row.FindControl("lblPoOrderNo")).Text.ToString();
                        string txtCommitment = ((TextBox)row.FindControl("txtCommitment")).Text.ToString();

                        //DBUtil _dbObj = new DBUtil();
                        if (!string.IsNullOrEmpty(txtCommitment))
                        {
                            //_dbObj.UpdatePOCommittment(lblOrderNo.Trim(), lblPOPosition.Trim(), txtCommitment.Trim());
                        }

                        lblConfirm.Text = "PO Committment date's are updated successfully.";
                        lblConfirm.Attributes.Add("style", "color:green");
                    }
                }

                ShowPOGrid();
            }
            catch (Exception ex)
            {
                LogError(ex, "Exception occured while bulk updating PO committment.");
            }
        }
    }
}