using Excel;
using Libraries.Entity;
using Microsoft.Practices.EnterpriseLibrary.Logging;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections;

namespace VV
{
    public partial class UploadBaan : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            # region Master Control

            # region Welcome Msg
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
                # endregion

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

            # endregion
        }

        protected void grdSearchResult_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            DataSet ds = (DataSet)Cache["ImportBaanCache"];

            grdSearchResult.PageIndex = e.NewPageIndex;
            grdSearchResult.DataSource = ds;
            grdSearchResult.DataBind();


            try
            {

                DataView dv;
                dv = ds.Tables[0].DefaultView;
                dv.RowFilter = null;

                grdSearchResult.DataSource = dv;
                grdSearchResult.DataBind();
            }

            catch (Exception ex)
            {
                Logger.Write(this.GetType().ToString() + " : Manage Employee - When trying to do a Paging : " + " : " + DateTime.Now + " : " + ex.Message.ToString(), Category.General, Priority.Highest);
            }
        }

        protected void grdSearchResult_Sorting(object sender, GridViewSortEventArgs e)
        {

        }

        protected void UploadButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (FileUploader.HasFile)
                {

                    string filename = Path.GetFileName(FileUploader.FileName);
                    FileUploader.SaveAs(Server.MapPath("~/") + filename);

                    FileStream stream;
                    IExcelDataReader excelReader;

                    DataSet ds_UploadedExcelData = new DataSet();

                    //String ExcelPath = Program.GetAppSetting("MapPath").Trim() + "\\AUS.xls";
                    stream = File.Open(Server.MapPath("~/") + filename, FileMode.Open, FileAccess.Read);

                    //1. Reading from a binary Excel file ('97-2003 format; *.xls)
                    //excelReader = ExcelReaderFactory.CreateBinaryReader(stream);
                    //...
                    //2. Reading from a OpenXml Excel file (2007 format; *.xlsx)
                    //IExcelDataReader excelReader = ExcelReaderFactory.CreateOpenXmlReader(stream);
                    excelReader = ExcelReaderFactory.CreateOpenXmlReader(stream);
                    //...
                    //3. DataSet - The result of each spreadsheet will be created in the result.Tables
                    //DataSet result = excelReader.AsDataSet();
                    //...
                    //4. DataSet - Create column names from first row
                    excelReader.IsFirstRowAsColumnNames = true;

                    ds_UploadedExcelData = excelReader.AsDataSet();
                    excelReader.Close();


                    // Get all the records from the DB from MISOrderStatus table & check for the Duplicate Entries.

                    DBUtil _dbObj = new DBUtil();

                    DataSet ds_fromDB = _dbObj.RetrieveBaaNDataForInvoice();

                    # region Get rid of all cols except Cols 1  (OrderNo),4 (LineNum),5(Pos), 15(OrderQty)

                    if (ds_fromDB != null)
                    {
                        if (ds_fromDB.Tables.Count > 0)
                        {
                            for (int i = ds_fromDB.Tables[0].Columns.Count - 1; i > 15; i--)
                            {
                                ds_fromDB.Tables[0].Columns.RemoveAt(i);
                            }

                            for (int i = 14; i > 5; i--)
                            {
                                ds_fromDB.Tables[0].Columns.RemoveAt(i);
                            }

                            ds_fromDB.Tables[0].Columns.RemoveAt(3);
                            ds_fromDB.Tables[0].Columns.RemoveAt(2);
                            ds_fromDB.Tables[0].Columns.RemoveAt(0);

                            ds_fromDB.AcceptChanges();
                        }
                    }
                    # endregion

                    # region Check for the Duplicates in MISOrderStatus Table
                    for (int i = ds_UploadedExcelData.Tables[0].Rows.Count - 1; i >= 0; i--)
                    {
                        String OrderNo = ds_UploadedExcelData.Tables[0].Rows[i]["Order"].ToString();
                        String LineNum = ds_UploadedExcelData.Tables[0].Rows[i]["Line #"].ToString();
                        int Pos = Int32.Parse(ds_UploadedExcelData.Tables[0].Rows[i]["Pos"].ToString());
                        String CustomerName = ds_UploadedExcelData.Tables[0].Rows[i]["Customer Name"].ToString();

                        String Item = ds_UploadedExcelData.Tables[0].Rows[i]["Item"].ToString();
                        String Description = ds_UploadedExcelData.Tables[0].Rows[i]["Description"].ToString();
                        String ItemGroup = ds_UploadedExcelData.Tables[0].Rows[i]["Item Group"].ToString();
                        int PlanWeek = Int32.Parse(ds_UploadedExcelData.Tables[0].Rows[i]["PlanWeek"].ToString());
                        int WIPWeek = Int32.Parse(ds_UploadedExcelData.Tables[0].Rows[i]["WIPWeek"].ToString());
                        int FGWeek = Int32.Parse(ds_UploadedExcelData.Tables[0].Rows[i]["FGWeek"].ToString());
                        string PlannedPromDate = ds_UploadedExcelData.Tables[0].Rows[i]["Planned DelDate"].ToString();
                        string OriginalPromDate = ds_UploadedExcelData.Tables[0].Rows[i]["Orignal PromDate"].ToString();

                        float AmtFromExcel = float.Parse(ds_UploadedExcelData.Tables[0].Rows[i]["Amount[INR]"].ToString());
                        string Description_2 = ds_UploadedExcelData.Tables[0].Rows[i]["Description_2"].ToString();

                        // Section For checking, If OrderNo and Pos is not available into MISOrderStatus table add it, Or else Updating the Original PromDate,
                        // PlannedDelDate, Item, Description

                        //DataSet ds_fromDBByOrderNoAndPos = _dbObj.RetrieveBaaNDataForInvoiceFromOrderNoAndPos(Convert.ToInt32(OrderNo), Convert.ToInt32(Pos));

                        //if (ds_fromDBByOrderNoAndPos != null && ds_fromDBByOrderNoAndPos.Tables[0].Rows.Count > 0)
                        //{
                        //    // Updating data into MisOrderStatus Table
                        //    _dbObj.UpdateBaanDataByOrderNoAndPos(Int32.Parse(OrderNo), Pos, Item, Description, OriginalPromDate, PlannedPromDate);
                        //}
                        //else
                        //{
                        //    // Inserting data into MisOrderStatus Table


                        //}

                        if (AmtFromExcel > 0)
                        {
                            AmtFromExcel = AmtFromExcel / Int32.Parse(ds_UploadedExcelData.Tables[0].Rows[i]["Balance Qty"].ToString());
                            //dr["Amount[INR]"] = AmtFromExcel;
                        }

                        //DataRow[] FilterOnDB = ds_fromDB.Tables[0].Select("OrderNo = '" + OrderNo + "' AND LineNum = '" + LineNum + "' AND Pos = " + Pos);
                        DataRow[] FilterOnDB = ds_fromDB.Tables[0].Select("OrderNo = '" + OrderNo + "' AND Pos = " + Pos);

                        if (FilterOnDB.Length > 0)
                        {
                            // Update the Record in the DB & then Remove the Record from DataSet
                            // Update FigNo/ Item (nvarchar), Description (nvarchar), ItemGroup (nvarchar), OrderQty (int), PlanWeek (int), WIPweek (int), FGWeek (int)

                            int OrderQty_FromDB = 0;

                            if (!String.IsNullOrEmpty(FilterOnDB[0]["OrderQty"].ToString().Trim()))
                                OrderQty_FromDB = Int32.Parse(FilterOnDB[0]["OrderQty"].ToString().Trim());

                            int OrderQty_FromUploaded = Int32.Parse(ds_UploadedExcelData.Tables[0].Rows[i]["Ord. Qty"].ToString());

                            int DiffQty = OrderQty_FromUploaded - OrderQty_FromDB;

                            # region New Logic
                            /*
                                    * Update OrderQty only if the new orderqty is > existing in MISOrderStatus.
                                    
                                        Existing (From DB) : 10  & New (From Uploaded Excel) : 12

                                        Diff: 12-10 = 2

                                        Orderqty = orderqty + diff
                                        BALQty = BALQty + Diff
                                        ToRelQty = ToRelQty + Diff
                                    */
                            # endregion

                            if (DiffQty > 0)
                            {
                                // Update OrderQty Also + BalanceQty + ToReleaseQty + other cols
                                _dbObj.UpdateBaaNDataInMISOrderStatus(Int32.Parse(OrderNo), LineNum, Pos, Item, Description, ItemGroup, DiffQty, PlanWeek, WIPWeek, FGWeek, 
                                    AmtFromExcel, Convert.ToDateTime(PlannedPromDate), Convert.ToDateTime(OriginalPromDate), CustomerName, Description_2);
                            }
                            else
                            {
                                // Update other Cols other than OrderQty,BalanceQty,ToReleaseQty
                                _dbObj.UpdateBaaNDataInMISOrderStatus(Int32.Parse(OrderNo), LineNum, Pos, Item, Description, ItemGroup, 0, PlanWeek, WIPWeek, FGWeek, AmtFromExcel,
                                    Convert.ToDateTime(PlannedPromDate), Convert.ToDateTime(OriginalPromDate), CustomerName, Description_2);
                            }

                            ds_UploadedExcelData.Tables[0].Rows.RemoveAt(i);

                            ds_UploadedExcelData.AcceptChanges();
                        }
                    }
                    # endregion

                    RemoveUnwantedColumnsFromDataSet(ds_UploadedExcelData);

                }
            }
            catch (Exception ex)
            {
                Logger.Write(this.GetType().ToString() + " : UploadButton_Click : " + " : " + DateTime.Now + " : " + ex.Message.ToString(), Category.General, Priority.Highest);
                throw ex;
            }
        }

        /// <summary>
        /// Remove the Unwanted Columns from the DataSet
        /// </summary>
        /// <param name="ds"></param>
        private void RemoveUnwantedColumnsFromDataSet(DataSet ds)
        {
            try
            {
                //if(ds.Tables["SO Backlog Detail by Valve Code"].Columns.Count > 100)
                //    ds.Tables[0].Columns.RemoveAt(100);

                //ds.Tables["SO Backlog Detail by Valve Code"].Columns.RemoveAt(102);
                //ds.Tables["SO Backlog Detail by Valve Code"].Columns.RemoveAt(101);
                //ds.Tables["SO Backlog Detail by Valve Code"].Columns.RemoveAt(100);

                for (int i = 93; i >= 59; i--)
                    ds.Tables["SO Backlog Detail by Valve Code"].Columns.RemoveAt(i); // Removing Amount now & having Price in place

                // Need Column-58 (BG) - Amount(INR)

                ds.Tables["SO Backlog Detail by Valve Code"].Columns.RemoveAt(57); 
                ds.Tables["SO Backlog Detail by Valve Code"].Columns.RemoveAt(56); 

                for (int i = 54; i >= 49; i--)
                    ds.Tables["SO Backlog Detail by Valve Code"].Columns.RemoveAt(i);

                ds.Tables["SO Backlog Detail by Valve Code"].Columns.RemoveAt(47);

                for (int i = 43; i >= 35; i--)
                    ds.Tables["SO Backlog Detail by Valve Code"].Columns.RemoveAt(i);

                //for (int i = 31; i >= 16; i--)
                //    ds.Tables["SO Backlog Detail by Valve Code"].Columns.RemoveAt(i);

                #region New Added Code : 10/02/2019
                for (int i = 31; i >= 21; i--)
                    ds.Tables["SO Backlog Detail by Valve Code"].Columns.RemoveAt(i);

                ds.Tables["SO Backlog Detail by Valve Code"].Columns.RemoveAt(19);
                ds.Tables["SO Backlog Detail by Valve Code"].Columns.RemoveAt(18);
                ds.Tables["SO Backlog Detail by Valve Code"].Columns.RemoveAt(17);
                ds.Tables["SO Backlog Detail by Valve Code"].Columns.RemoveAt(16);
               
                #endregion

                ds.Tables["SO Backlog Detail by Valve Code"].Columns.RemoveAt(14);

                ds.Tables["SO Backlog Detail by Valve Code"].Columns.RemoveAt(9);
                ds.Tables["SO Backlog Detail by Valve Code"].Columns.RemoveAt(7);
                ds.Tables["SO Backlog Detail by Valve Code"].Columns.RemoveAt(6);
                ds.Tables["SO Backlog Detail by Valve Code"].Columns.RemoveAt(4);
                ds.Tables["SO Backlog Detail by Valve Code"].Columns.RemoveAt(3);
                ds.Tables["SO Backlog Detail by Valve Code"].Columns.RemoveAt(0);

                ds.Tables["SO Backlog Detail by Valve Code"].Columns.Add("ToReleaseQty");

                ds.AcceptChanges();

                DataTable dt = new DataTable();
                DataColumn dc1 = new DataColumn(ds.Tables["SO Backlog Detail by Valve Code"].Columns[0].ColumnName.Trim()); dc1.DataType = typeof(String); dt.Columns.Add(dc1);
                DataColumn dc2 = new DataColumn(ds.Tables["SO Backlog Detail by Valve Code"].Columns[1].ColumnName.Trim()); dc2.DataType = typeof(Int32); dt.Columns.Add(dc2);
                DataColumn dc3 = new DataColumn(ds.Tables["SO Backlog Detail by Valve Code"].Columns[2].ColumnName.Trim()); dc3.DataType = typeof(String); dt.Columns.Add(dc3);
                DataColumn dc4 = new DataColumn(ds.Tables["SO Backlog Detail by Valve Code"].Columns[3].ColumnName.Trim()); dc4.DataType = typeof(String); dt.Columns.Add(dc4);
                DataColumn dc5 = new DataColumn(ds.Tables["SO Backlog Detail by Valve Code"].Columns[4].ColumnName.Trim()); dc5.DataType = typeof(String); dt.Columns.Add(dc5);

                DataColumn dc6 = new DataColumn(ds.Tables["SO Backlog Detail by Valve Code"].Columns[5].ColumnName.Trim()); dc6.DataType = typeof(Int32); dt.Columns.Add(dc6);
                DataColumn dc7 = new DataColumn(ds.Tables["SO Backlog Detail by Valve Code"].Columns[6].ColumnName.Trim()); dc7.DataType = typeof(String); dt.Columns.Add(dc7);
                DataColumn dc8 = new DataColumn(ds.Tables["SO Backlog Detail by Valve Code"].Columns[7].ColumnName.Trim()); dc8.DataType = typeof(String); dt.Columns.Add(dc8);

                // Col8 - ItemGroup

                DataColumn dc9 = new DataColumn(ds.Tables["SO Backlog Detail by Valve Code"].Columns[8].ColumnName.Trim()); dc9.DataType = typeof(String); dt.Columns.Add(dc9);

                #region Original Code -- Added by Arun --- 11/02/2019
                //DataColumn dc10 = new DataColumn(ds.Tables["SO Backlog Detail by Valve Code"].Columns[9].ColumnName.Trim()); dc10.DataType = typeof(Int32); dt.Columns.Add(dc10);
                //DataColumn dc11 = new DataColumn(ds.Tables["SO Backlog Detail by Valve Code"].Columns[10].ColumnName.Trim()); dc11.DataType = typeof(DateTime); dt.Columns.Add(dc11);

                //DataColumn dc12 = new DataColumn(ds.Tables["SO Backlog Detail by Valve Code"].Columns[11].ColumnName.Trim()); dc12.DataType = typeof(Int32); dt.Columns.Add(dc12);
                //DataColumn dc13 = new DataColumn(ds.Tables["SO Backlog Detail by Valve Code"].Columns[12].ColumnName.Trim()); dc13.DataType = typeof(DateTime); dt.Columns.Add(dc13);
                //DataColumn dc14 = new DataColumn(ds.Tables["SO Backlog Detail by Valve Code"].Columns[13].ColumnName.Trim()); dc14.DataType = typeof(DateTime); dt.Columns.Add(dc14);
                //DataColumn dc15 = new DataColumn(ds.Tables["SO Backlog Detail by Valve Code"].Columns[14].ColumnName.Trim()); dc15.DataType = typeof(DateTime); dt.Columns.Add(dc15);
                //DataColumn dc16 = new DataColumn(ds.Tables["SO Backlog Detail by Valve Code"].Columns[15].ColumnName.Trim()); dc16.DataType = typeof(Int32); dt.Columns.Add(dc16);

                //DataColumn dc17 = new DataColumn(ds.Tables["SO Backlog Detail by Valve Code"].Columns[16].ColumnName.Trim()); dc17.DataType = typeof(Int32); dt.Columns.Add(dc17);
                //DataColumn dc18 = new DataColumn(ds.Tables["SO Backlog Detail by Valve Code"].Columns[17].ColumnName.Trim()); dc18.DataType = typeof(float); dt.Columns.Add(dc18);
                //DataColumn dc19 = new DataColumn(ds.Tables["SO Backlog Detail by Valve Code"].Columns[18].ColumnName.Trim()); dc19.DataType = typeof(Int32); dt.Columns.Add(dc19);
                //DataColumn dc20 = new DataColumn(ds.Tables["SO Backlog Detail by Valve Code"].Columns[19].ColumnName.Trim()); dc20.DataType = typeof(Int32); dt.Columns.Add(dc20);
                //DataColumn dc21 = new DataColumn(ds.Tables["SO Backlog Detail by Valve Code"].Columns[20].ColumnName.Trim()); dc21.DataType = typeof(Int32); dt.Columns.Add(dc21);

                //// Add the Rel Qty Here                      
                //DataColumn dc22 = new DataColumn(ds.Tables["SO Backlog Detail by Valve Code"].Columns[21].ColumnName.Trim()); dc22.DataType = typeof(DateTime); dt.Columns.Add(dc22);
                //DataColumn dc23 = new DataColumn(ds.Tables["SO Backlog Detail by Valve Code"].Columns[22].ColumnName.Trim()); dc23.DataType = typeof(DateTime); dt.Columns.Add(dc23);
                //DataColumn dc24 = new DataColumn(ds.Tables["SO Backlog Detail by Valve Code"].Columns[23].ColumnName.Trim()); dc24.DataType = typeof(DateTime); dt.Columns.Add(dc24);

                //DataColumn dc25 = new DataColumn(ds.Tables["SO Backlog Detail by Valve Code"].Columns[24].ColumnName.Trim()); dc25.DataType = typeof(Int32); dt.Columns.Add(dc25);

                //// Week Cols
                //DataColumn dc26 = new DataColumn(ds.Tables["SO Backlog Detail by Valve Code"].Columns[25].ColumnName.Trim()); dc26.DataType = typeof(Int32); dt.Columns.Add(dc26);
                //DataColumn dc27 = new DataColumn(ds.Tables["SO Backlog Detail by Valve Code"].Columns[26].ColumnName.Trim()); dc27.DataType = typeof(Int32); dt.Columns.Add(dc27);
                //DataColumn dc28 = new DataColumn(ds.Tables["SO Backlog Detail by Valve Code"].Columns[27].ColumnName.Trim()); dc28.DataType = typeof(Int32); dt.Columns.Add(dc28);
                #endregion

                DataColumn dc10 = new DataColumn(ds.Tables["SO Backlog Detail by Valve Code"].Columns[9].ColumnName.Trim()); dc10.DataType = typeof(String); dt.Columns.Add(dc10);

                DataColumn dc11 = new DataColumn(ds.Tables["SO Backlog Detail by Valve Code"].Columns[10].ColumnName.Trim()); dc11.DataType = typeof(Int32); dt.Columns.Add(dc11);
                DataColumn dc12 = new DataColumn(ds.Tables["SO Backlog Detail by Valve Code"].Columns[11].ColumnName.Trim()); dc12.DataType = typeof(DateTime); dt.Columns.Add(dc12);

                DataColumn dc13 = new DataColumn(ds.Tables["SO Backlog Detail by Valve Code"].Columns[12].ColumnName.Trim()); dc13.DataType = typeof(Int32); dt.Columns.Add(dc13);
                DataColumn dc14 = new DataColumn(ds.Tables["SO Backlog Detail by Valve Code"].Columns[13].ColumnName.Trim()); dc14.DataType = typeof(DateTime); dt.Columns.Add(dc14);
                DataColumn dc15 = new DataColumn(ds.Tables["SO Backlog Detail by Valve Code"].Columns[14].ColumnName.Trim()); dc15.DataType = typeof(DateTime); dt.Columns.Add(dc15);
                DataColumn dc16 = new DataColumn(ds.Tables["SO Backlog Detail by Valve Code"].Columns[15].ColumnName.Trim()); dc16.DataType = typeof(DateTime); dt.Columns.Add(dc16);
                DataColumn dc17 = new DataColumn(ds.Tables["SO Backlog Detail by Valve Code"].Columns[16].ColumnName.Trim()); dc17.DataType = typeof(Int32); dt.Columns.Add(dc17);

                DataColumn dc18 = new DataColumn(ds.Tables["SO Backlog Detail by Valve Code"].Columns[17].ColumnName.Trim()); dc18.DataType = typeof(Int32); dt.Columns.Add(dc18);
                DataColumn dc19 = new DataColumn(ds.Tables["SO Backlog Detail by Valve Code"].Columns[18].ColumnName.Trim()); dc19.DataType = typeof(float); dt.Columns.Add(dc19);
                DataColumn dc20 = new DataColumn(ds.Tables["SO Backlog Detail by Valve Code"].Columns[19].ColumnName.Trim()); dc20.DataType = typeof(Int32); dt.Columns.Add(dc20);
                DataColumn dc21 = new DataColumn(ds.Tables["SO Backlog Detail by Valve Code"].Columns[20].ColumnName.Trim()); dc21.DataType = typeof(Int32); dt.Columns.Add(dc21);
                DataColumn dc22 = new DataColumn(ds.Tables["SO Backlog Detail by Valve Code"].Columns[21].ColumnName.Trim()); dc22.DataType = typeof(Int32); dt.Columns.Add(dc22);

                // Add the Rel Qty Here                      
                DataColumn dc23 = new DataColumn(ds.Tables["SO Backlog Detail by Valve Code"].Columns[22].ColumnName.Trim()); dc23.DataType = typeof(DateTime); dt.Columns.Add(dc23);
                DataColumn dc24 = new DataColumn(ds.Tables["SO Backlog Detail by Valve Code"].Columns[23].ColumnName.Trim()); dc24.DataType = typeof(DateTime); dt.Columns.Add(dc24);
                DataColumn dc25 = new DataColumn(ds.Tables["SO Backlog Detail by Valve Code"].Columns[24].ColumnName.Trim()); dc25.DataType = typeof(DateTime); dt.Columns.Add(dc25);

                DataColumn dc26 = new DataColumn(ds.Tables["SO Backlog Detail by Valve Code"].Columns[25].ColumnName.Trim()); dc26.DataType = typeof(Int32); dt.Columns.Add(dc26);

                // Week Cols
                DataColumn dc27 = new DataColumn(ds.Tables["SO Backlog Detail by Valve Code"].Columns[26].ColumnName.Trim()); dc27.DataType = typeof(Int32); dt.Columns.Add(dc27);
                DataColumn dc28 = new DataColumn(ds.Tables["SO Backlog Detail by Valve Code"].Columns[27].ColumnName.Trim()); dc28.DataType = typeof(Int32); dt.Columns.Add(dc28);
                DataColumn dc29 = new DataColumn(ds.Tables["SO Backlog Detail by Valve Code"].Columns[28].ColumnName.Trim()); dc29.DataType = typeof(Int32); dt.Columns.Add(dc29);

                DataSet UpdatedDS = new DataSet();
                UpdatedDS.Tables.Add(dt);
                UpdatedDS.AcceptChanges();

                //                int ctr = 1;
                foreach (DataRow dataRow in ds.Tables["SO Backlog Detail by Valve Code"].Rows)
                {
                    UpdatedDS.Tables[0].ImportRow(dataRow);
                    UpdatedDS.Tables[0].AcceptChanges();
                    //  ctr = ctr + 1;
                }


                foreach (DataRow dr in UpdatedDS.Tables[0].Rows)
                {
                    //Add the Logic to update the To Rel Qty Here   To Rel = balanceqty-fgqty-wipqty;

                    int FG_Qty = 0, WIP_Qty = 0;

                    if (String.IsNullOrEmpty(dr["FG QTY"].ToString().Trim()))
                        FG_Qty = 0;
                    else
                        FG_Qty = Int32.Parse(dr["FG QTY"].ToString().Trim());

                    if (String.IsNullOrEmpty(dr["WIP QTY"].ToString().Trim()))
                        WIP_Qty = 0;
                    else
                        WIP_Qty = Int32.Parse(dr["WIP QTY"].ToString().Trim());

                    dr["ToReleaseQty"] = Int32.Parse(dr["Balance Qty"].ToString()) - FG_Qty - WIP_Qty;

                    float AmtFromExcel = float.Parse(dr["Amount[INR]"].ToString());

                    if (AmtFromExcel > 0)
                    {
                        AmtFromExcel = AmtFromExcel / Int32.Parse(dr["Balance Qty"].ToString());
                        dr["Amount[INR]"] = AmtFromExcel;
                    }

                    UpdatedDS.Tables[0].AcceptChanges();
                }

                UpdatedDS.AcceptChanges();

                DBUtil _dbObj = new DBUtil();
                _dbObj.BulkIngestIntoDatabase(UpdatedDS);

                # region Check & insert/update into MISFinanceInput Table
                
                // Get the List of Distinct OrderNo from MISFinanecInput table & put them in an ArrayList
                DataSet ds_DMISFinanceInput = _dbObj.GetAllOrderNoFromMISFinanceInput();
                ArrayList myArrayList_OrderNo = new ArrayList();

                if (ds_DMISFinanceInput != null && ds_DMISFinanceInput.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow dtRow in ds_DMISFinanceInput.Tables[0].Rows)
                    {
                        myArrayList_OrderNo.Add(dtRow);
                    }
                }

                // Against every OrderNo in the Actual dataset, check it is in the arraylist.
                // If exists, then ignor. Otherwise, insert it.

                for (int i = 0; i < UpdatedDS.Tables[0].Rows.Count; i++)
                {
                    if (myArrayList_OrderNo.Contains(UpdatedDS.Tables[0].Rows[i][1].ToString().Trim()))
                    {
                        // DOnt do anything; skip to the next row
                    }
                    else
                    {
                        // Insert into MISFinanceInput
                        _dbObj.InsertIntoMISFinanceInput(Int32.Parse(UpdatedDS.Tables[0].Rows[i][1].ToString().Trim()), UpdatedDS.Tables[0].Rows[i][4].ToString().Trim(), Int32.Parse(UpdatedDS.Tables[0].Rows[i][5].ToString().Trim()), String.Empty, String.Empty, String.Empty);

                        // Add the same into the ArrayList
                        myArrayList_OrderNo.Add(UpdatedDS.Tables[0].Rows[i][1].ToString().Trim());
                    }
                }

                # endregion

                DataView view = UpdatedDS.Tables[0].DefaultView;

                view.Sort = "Order, Pos ASC";

                DataSet DS = new DataSet();
                DS.Tables.Add(view.ToTable());

                Cache["ImportBaanCache"] = DS;

                grdSearchResult.DataSource = DS;
                grdSearchResult.DataBind();

            }
            catch (Exception ex)
            {
                Logger.Write(this.GetType().ToString() + " : RemoveUnwantedColumnsFromDataSet : " + " : " + DateTime.Now + " : " + ex.Message.ToString(), Category.General, Priority.Highest);
                throw ex;
            }
        }

        # region Not Used
        /*
        protected void UploadButton_Click_(object sender, EventArgs e)
        {
            // Specify the path on the server to
            // save the uploaded file to.
            String savePath = @"e:\Uploads\";

            // Before attempting to perform operations
            // on the the file, verify that the FileUpload 
            // control contains a file.
            if (FileUploader.HasFile)
            {
                ReadCSVContent(FileUploader.FileContent);
                // Append the name of the file to upload to the path.
                savePath += FileUploader.FileName;

                // Call the SaveAs method to save the 
                // uploaded file to the specified path.
                // This example does not perform all
                // the necessary error checking.               
                // If a file with the same name
                // already exists in the specified path,  
                // the uploaded file overwrites it.
                FileUploader.SaveAs(savePath);

                // Notify the user that the file was uploaded successfully.
                
                // Call a helper routine to display the contents
                // of the file to upload.
               // DisplayFileContents(FileUploader.PostedFile);
            }
        }

        protected void DisplayFileContents(HttpPostedFile file)
        {
            System.IO.Stream myStream;
            Int32 fileLen;
            StringBuilder displayString = new StringBuilder();

            // Get the length of the file.
            fileLen = FileUploader.PostedFile.ContentLength;

            // Display the length of the file in a label.
           // lblWelcome.Text = "The length of the file is " +
             //                  fileLen.ToString() + " bytes.";

            // Create a byte array to hold the contents of the file.
            Byte[] Input = new Byte[fileLen];

            // Initialize the stream to read the uploaded file.
            myStream = FileUploader.FileContent;

            // Read the file into the byte array.
            myStream.Read(Input, 0, fileLen);

            // Copy the byte array to a string.
            for (int loop1 = 0; loop1 < fileLen; loop1++)
            {
                displayString.Append(Input[loop1].ToString());
            }



        }

        protected void ReadCSVContent(Stream InputStream)
        {
            StreamReader oStreamReader = new StreamReader(InputStream); // ("e:\\FL_insurance_sample.csv");

            DataTable oDataTable = null;
            int RowCount = 0;
            string[] ColumnNames = null;
            string[] oStreamDataValues = null;
            //using while loop read the stream data till end
            while (!oStreamReader.EndOfStream)
            {
                String oStreamRowData = oStreamReader.ReadLine().Trim();
                if (oStreamRowData.Length > 0)
                {
                    oStreamDataValues = oStreamRowData.Split(',');
                    //Bcoz the first row contains column names, we will poluate 
                    //the column name by
                    //reading the first row and RowCount-0 will be true only once
                    if (RowCount == 0)
                    {
                        RowCount = 1;
                        ColumnNames = oStreamRowData.Split(',');
                        oDataTable = new DataTable();

                        //using foreach looping through all the column names
                        foreach (string csvcolumn in ColumnNames)
                        {
                            DataColumn oDataColumn = new DataColumn(csvcolumn.ToUpper(), typeof(string));

                            //setting the default value of empty.string to newly created column
                            oDataColumn.DefaultValue = string.Empty;

                            //adding the newly created column to the table
                            oDataTable.Columns.Add(oDataColumn);
                        }
                    }
                    else
                    {
                        //creates a new DataRow with the same schema as of the oDataTable            
                        DataRow oDataRow = oDataTable.NewRow();

                        //using foreach looping through all the column names
                        for (int i = 0; i < ColumnNames.Length; i++)
                        {
                            oDataRow[ColumnNames[i]] = oStreamDataValues[i] == null ? string.Empty : oStreamDataValues[i].ToString();
                        }

                        //adding the newly created row with data to the oDataTable       
                        oDataTable.Rows.Add(oDataRow);
                    }
                }
            }
            //close the oStreamReader object
            oStreamReader.Close();
            //release all the resources used by the oStreamReader object
            oStreamReader.Dispose();

            DataSet ds = new DataSet();
            ds.Tables.Add(oDataTable);

            Cache["BaanCache"] = ds;

            //lblStatus.Text = "File Uploaded Successfully";
           // lblStatus.ForeColor = System.Drawing.Color.Green;

            grdSearchResult.DataSource = ds;
            grdSearchResult.DataBind();

            //Looping through all the rows in the Datatable
            //foreach (DataRow oDataRow in oDataTable.Rows)
            //{

            //    string RowValues = string.Empty;

            //    //Looping through all the columns in a row

            //    foreach (string csvcolumn in ColumnNames)
            //    {
            //        //concatenating the values for display purpose
            //        RowValues += csvcolumn + "=" + oDataRow[csvcolumn].ToString() + ";  ";
            //    }
            //    //Displaying the result on the console window
            //    Console.WriteLine(RowValues);
            //}
        }
        */
        # endregion

        protected void btnSearchBox_Click(object sender, EventArgs e)
        {

        }

    }
}