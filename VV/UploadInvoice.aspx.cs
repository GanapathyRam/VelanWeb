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
using System.Xml;
using System.Collections;

namespace VV
{
    public partial class UploadInvoice : System.Web.UI.Page
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

            # endregion

            if (!IsPostBack)
            {
                DBUtil _DBObj = new DBUtil();
                DataSet ds_InvoiceFromDB = _DBObj.RetrieveInvoiceData();

                Cache["ImportInvoiceCache"] = ds_InvoiceFromDB;
              //  grdInvoiceResult.DataSource = ds_InvoiceFromDB;
              //  grdInvoiceResult.DataBind();
            }
        }

        protected void grdInvoiceResult_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            DataSet ds = (DataSet)Cache["ImportInvoiceCache"];

            grdInvoiceResult.PageIndex = e.NewPageIndex;
            grdInvoiceResult.DataSource = ds;
            grdInvoiceResult.DataBind();


            try
            {

                DataView dv;
                dv = ds.Tables[0].DefaultView;
                dv.RowFilter = null;

                grdInvoiceResult.DataSource = dv;
                grdInvoiceResult.DataBind();
            }

            catch (Exception ex)
            {
                Logger.Write(this.GetType().ToString() + " : Import Invoice - When trying to do a Paging : " + " : " + DateTime.Now + " : " + ex.Message.ToString(), Category.General, Priority.Highest);
            }
        }

        protected void grdInvoiceResult_Sorting(object sender, GridViewSortEventArgs e)
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

                    DataSet ds = new DataSet();

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

                    ds = excelReader.AsDataSet();
                    excelReader.Close();

                    // Cache["ActualInvoiceCacheFromExcelWithOutAlteration"] = ds;

                    RemoveUnwantedColumnsFromDataSet(ds);

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
                for (int i = 23; i >= 21; i--)
                    ds.Tables[0].Columns.RemoveAt(i);

                ds.Tables[0].Columns.RemoveAt(19);

                for (int i = 17; i >= 15; i--)
                    ds.Tables[0].Columns.RemoveAt(i);

                for (int i = 13; i >= 7; i--)
                    ds.Tables[0].Columns.RemoveAt(i);

                ds.Tables[0].Columns.RemoveAt(4);

                for (int i = 2; i >= 0; i--)
                    ds.Tables[0].Columns.RemoveAt(i);


                ds.AcceptChanges();

                for (int h = 0; h < ds.Tables[0].Rows.Count; h++)
                {
                    if (String.IsNullOrEmpty(ds.Tables[0].Rows[h][0].ToString().Trim()))
                    {
                        ds.Tables[0].Rows[h].Delete();
                    }
                }

                ds.AcceptChanges();

                // Cache["InvoiceBaanCache"] = ds;

                //  grdSearchResult.DataSource = ds;
                //  grdSearchResult.DataBind();

                IngestIntoDataBaseforInvoice(ds);

            }
            catch (Exception ex)
            {
                Logger.Write(this.GetType().ToString() + " : RemoveUnwantedColumnsFromDataSet : " + " : " + DateTime.Now + " : " + ex.Message.ToString(), Category.General, Priority.Highest);
                throw ex;
            }
        }

        private void IngestIntoDataBaseforInvoice(DataSet ds_Invoice)
        {
            try
            {
                // get the dump from MISOrderStatus & store in a dataset

                DBUtil _DBObj = new DBUtil();

                DataSet ds_MIS = _DBObj.RetrieveBaaNDataForInvoice();
                DataSet ds_InvoiceFromDB = _DBObj.RetrieveInvoiceData();

                for (int i = 0; i < ds_Invoice.Tables[0].Rows.Count; i++)
                {
                    String orderNo = ds_Invoice.Tables[0].Rows[i]["Order"].ToString().Trim();
                    String LineNo = ds_Invoice.Tables[0].Rows[i]["Line #"].ToString().Trim();
                    String Pos = ds_Invoice.Tables[0].Rows[i]["Pos."].ToString().Trim();
                    String InvoiceNo = ds_Invoice.Tables[0].Rows[i]["Invoice"].ToString().Trim();

                    int InvoicedQty_MIS = 0, BalQty_MIS = 0, FGQty_MIS = 0;

                    bool IsSuccess = true;

                    #region first check in tbl_Invoice
                    DataRow[] dr_Filter_InvoiceDB = ds_InvoiceFromDB.Tables[0].Select("OrderNo = '" + orderNo + "' And InvoiceNumber = '" + InvoiceNo + "' AND Pos = " + Pos + " AND IsSuccess = 1");

                    bool CanProceedToNextStep = false;

                    if (dr_Filter_InvoiceDB.Length > 0)
                    {
                        // Ignore & skip to next record
                        CanProceedToNextStep = false;
                    }
                    else
                    {
                        CanProceedToNextStep = true;
                    }
                    # endregion


                    if(CanProceedToNextStep)
                    {
                        DataRow[] dr_Filter_MIS = ds_MIS.Tables[0].Select("OrderNo = '" + orderNo + "' And LineNum = '" + LineNo + "' AND Pos = " + Pos + "");

                        if (dr_Filter_MIS.Length > 0)
                        {
                            if (dr_Filter_MIS.Length > 1)
                            {
                                IsSuccess = false;
                            }
                            else
                            {
                                IsSuccess = true;
                                // Matching Record Exists

                                int DelQty_Invoice = Int32.Parse(ds_Invoice.Tables[0].Rows[i]["Del. Qty"].ToString().Trim());

                                //Reduce FG Qty in MIS
                                if (!String.IsNullOrEmpty(dr_Filter_MIS[0]["FGQty"].ToString().Trim()))
                                {
                                    FGQty_MIS = Int32.Parse(dr_Filter_MIS[0]["FGQty"].ToString().Trim());

                                    if (FGQty_MIS >= DelQty_Invoice)
                                        FGQty_MIS = FGQty_MIS - DelQty_Invoice;
                                    else
                                        IsSuccess = false;
                                }

                                //Update the Succeess flag to true

                                // Update the Qty in MIS - Reduce Balance Qty & FG (FG > InvoiceQty) & Increase Invoice Qty in MIS

                                //Increase Invoiced Qty in MIS
                                if (!String.IsNullOrEmpty(dr_Filter_MIS[0]["InvoicedQty"].ToString().Trim()))
                                {
                                    InvoicedQty_MIS = Int32.Parse(dr_Filter_MIS[0]["InvoicedQty"].ToString().Trim());
                                    InvoicedQty_MIS = InvoicedQty_MIS + DelQty_Invoice;
                                }
                                else
                                {
                                    InvoicedQty_MIS = InvoicedQty_MIS + DelQty_Invoice;
                                }

                                //Reduce Balance Qty in MIS
                                if (!String.IsNullOrEmpty(dr_Filter_MIS[0]["BalanceQty"].ToString().Trim()))
                                {
                                    BalQty_MIS = Int32.Parse(dr_Filter_MIS[0]["BalanceQty"].ToString().Trim());
                                    BalQty_MIS = BalQty_MIS - DelQty_Invoice;
                                }
                                else
                                {
                                    BalQty_MIS = BalQty_MIS - DelQty_Invoice;
                                }
                            }
                        }
                        else
                        {
                            // No Matching Record exists. Update the Succeess flag to false
                            IsSuccess = false;
                        }

                        if (IsSuccess)
                        {
                            // Ingest into Invoice Table, with Status as Success
                            // Update the MISOrderStatus table

                            _DBObj.InsertInvoiceData(Int32.Parse(orderNo), LineNo, Int32.Parse(Pos), ds_Invoice.Tables[0].Rows[i]["Del. Qty"].ToString().Trim(), ds_Invoice.Tables[0].Rows[i]["Invoice Date"].ToString().Trim(), ds_Invoice.Tables[0].Rows[i]["Invoice"].ToString().Trim(), true);
                            _DBObj.UpdateQtyInMISForInvoice(Int32.Parse(orderNo), LineNo, Int32.Parse(Pos), FGQty_MIS, BalQty_MIS, InvoicedQty_MIS);
                        }
                        else
                        {
                            // Ingest into Invoice Table, with Status as Success
                            // Dont update the MISOrderStatus table
                            _DBObj.InsertInvoiceData(Int32.Parse(orderNo), LineNo, Int32.Parse(Pos), ds_Invoice.Tables[0].Rows[i]["Del. Qty"].ToString().Trim(), ds_Invoice.Tables[0].Rows[i]["Invoice Date"].ToString().Trim(), ds_Invoice.Tables[0].Rows[i]["Invoice"].ToString().Trim(), false);
                        }
                    }
                    
                }

                DataSet ds_UpdatedInvoiceFromDB = _DBObj.RetrieveInvoiceData();
                Cache["ImportInvoiceCache"] = ds_UpdatedInvoiceFromDB;

                DateTime CurrentDate = DateTime.Now.Date;

                string strFilter = string.Empty;
                DataView dv = ds_UpdatedInvoiceFromDB.Tables[0].DefaultView;

                strFilter += "CreatedOn  >= '" + CurrentDate + "'";

                if (strFilter != "")
                {
                    dv.RowFilter = strFilter;
                }
                if (dv.Count > 0)
                {
                    grdInvoiceResult.DataSource = dv;
                    grdInvoiceResult.DataBind();
                }
            }
            catch (Exception ex)
            {
                Logger.Write(this.GetType().ToString() + " : IngestIntoDataBaseforInvoice : " + " : " + DateTime.Now + " : " + ex.Message.ToString(), Category.General, Priority.Highest);
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

        protected void btnExcel_Click(object sender, EventArgs e)
        {
            try
            {
                DBUtil _DBObj = new DBUtil();
                DataSet ds_UpdatedInvoiceFromDB = _DBObj.RetrieveInvoiceData();
                Cache["ImportInvoiceCache"] = ds_UpdatedInvoiceFromDB;

                DateTime CurrentDate = DateTime.Now.Date;

                string strFilter = string.Empty;
                DataView dv = ds_UpdatedInvoiceFromDB.Tables[0].DefaultView;

                strFilter += "CreatedOn  >= '" + CurrentDate.AddDays(-30) + "'";

                if (strFilter != "")
                {
                    dv.RowFilter = strFilter;
                }

                DataTable DT2 = dv.ToTable();

                DataSet ds = new DataSet();

                if (DT2 != null & DT2.Rows.Count > 0)
                {
                    ds.Tables.Add(DT2);
                    Convert(ds, "Invoice Data");
                }
            }
            catch (Exception ex)
            {
                Logger.Write(this.GetType().ToString() + " : btnExcel_Click : " + " : " + DateTime.Now + " : " + ex.Message.ToString(), Category.General, Priority.Highest);
                throw ex;
            }
        }

        public void Convert(DataSet ds, string fileName)
        {
            Convert(ds.Tables, fileName);
        }

        public void Convert(IEnumerable tables, string fileName)
        {
            try
            {
                Response.ClearContent();
                Response.ClearHeaders();
                Response.Buffer = true;
                Response.Charset = "";
                Response.ContentType = "application/vnd.ms-excel";
                Response.AddHeader("content-disposition",
                         "attachment; filename=" + fileName + ".xls");

                using (XmlTextWriter x = new XmlTextWriter(Response.OutputStream, Encoding.UTF8))
                {
                    int sheetNumber = 0;
                    x.WriteRaw("<?xml version=\"1.0\"?><?mso-application progid=\"Excel.Sheet\"?>");
                    x.WriteRaw("<Workbook xmlns=\"urn:schemas-microsoft-com:office:spreadsheet\" ");
                    x.WriteRaw("xmlns:o=\"urn:schemas-microsoft-com:office:office\" ");
                    x.WriteRaw("xmlns:x=\"urn:schemas-microsoft-com:office:excel\">");
                    x.WriteRaw("<Styles><Style ss:ID='sText'>" +
                               "<NumberFormat ss:Format='@'/></Style>");
                    x.WriteRaw("<Style ss:ID='sDate'><NumberFormat" +
                               " ss:Format='[$-409]m/d/yy\\ h:mm\\ AM/PM;@'/>");
                    x.WriteRaw("</Style></Styles>");
                    foreach (DataTable dt in tables)
                    {
                        sheetNumber++;
                        string sheetName = !string.IsNullOrEmpty(dt.TableName) ?
                               dt.TableName : "Sheet" + sheetNumber.ToString();
                        x.WriteRaw("<Worksheet ss:Name='" + sheetName + "'>");
                        x.WriteRaw("<Table>");
                        string[] columnTypes = new string[dt.Columns.Count];

                        for (int i = 0; i < dt.Columns.Count; i++)
                        {
                            string colType = dt.Columns[i].DataType.ToString().ToLower();

                            if (colType.Contains("datetime"))
                            {
                                columnTypes[i] = "DateTime";
                                x.WriteRaw("<Column ss:StyleID='sDate'/>");

                            }
                            else if (colType.Contains("string"))
                            {
                                columnTypes[i] = "String";
                                x.WriteRaw("<Column ss:StyleID='sText'/>");

                            }
                            else
                            {
                                x.WriteRaw("<Column />");

                                if (colType.Contains("boolean"))
                                {
                                    columnTypes[i] = "Boolean";
                                }
                                else
                                {
                                    //default is some kind of number.
                                    columnTypes[i] = "Number";
                                }

                            }
                        }
                        //column headers
                        x.WriteRaw("<Row>");
                        foreach (DataColumn col in dt.Columns)
                        {
                            x.WriteRaw("<Cell ss:StyleID='sText'><Data ss:Type='String'>");
                            x.WriteRaw(col.ColumnName);
                            x.WriteRaw("</Data></Cell>");
                        }
                        x.WriteRaw("</Row>");
                        //data
                        bool missedNullColumn = false;
                        foreach (DataRow row in dt.Rows)
                        {
                            x.WriteRaw("<Row>");
                            for (int i = 0; i < dt.Columns.Count; i++)
                            {
                                if (!row.IsNull(i))
                                {
                                    if (missedNullColumn)
                                    {
                                        int displayIndex = i + 1;
                                        x.WriteRaw("<Cell ss:Index='" + displayIndex.ToString() +
                                                   "'><Data ss:Type='" +
                                                   columnTypes[i] + "'>");
                                        missedNullColumn = false;
                                    }
                                    else
                                    {
                                        x.WriteRaw("<Cell><Data ss:Type='" +
                                                   columnTypes[i] + "'>");
                                    }

                                    switch (columnTypes[i])
                                    {
                                        case "DateTime":
                                            x.WriteRaw(((DateTime)row[i]).ToString("s"));
                                            break;
                                        case "Boolean":
                                            x.WriteRaw(((bool)row[i]) ? "1" : "0");
                                            break;
                                        case "String":
                                            x.WriteString(row[i].ToString());
                                            break;
                                        default:
                                            x.WriteString(row[i].ToString());
                                            break;
                                    }

                                    x.WriteRaw("</Data></Cell>");
                                }
                                else
                                {
                                    missedNullColumn = true;
                                }
                            }
                            x.WriteRaw("</Row>");
                        }
                        x.WriteRaw("</Table></Worksheet>");
                    }
                    x.WriteRaw("</Workbook>");
                }
                Response.End();
            }
            catch (Exception ex)
            {
                Logger.Write(this.GetType().ToString() + " : Convert - Report Generation : " + " : " + DateTime.Now + " : " + ex.Message.ToString(), Category.General, Priority.Highest);
                throw ex;
            }
        }

    }
}