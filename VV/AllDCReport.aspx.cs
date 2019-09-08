using Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
//using Outlook = Microsoft.Office.Interop.Outlook;

namespace VV
{
    public partial class AllDCReport : System.Web.UI.Page
    {
        SqlCommand cmd = new SqlCommand();
        System.Data.DataTable dt = new System.Data.DataTable();
        DBUtil _dbObj = new DBUtil();

        protected void Page_Load(object sender, EventArgs e)
        {
            #region Master Control

            #region Welcome Msg

            DateTime dt = DateTime.MinValue;
            Console.WriteLine(dt);
            string UserName = (String)HttpContext.Current.Session["LoggedOnUser"];
            System.Web.UI.WebControls.Label lblUserName = (System.Web.UI.WebControls.Label)Page.Master.FindControl("lblUserName");
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
            #endregion



            #endregion

            if (!Page.IsPostBack)
            {
                FillEmployeeDropDown();
            }
        }

        protected void imgExcelForPending_Click(object sender, ImageClickEventArgs e)
        {
            lblMessage.Text = "";
            string query = string.Empty;
            string str = string.Empty;

            try
            {
                DataSet ds = _dbObj.RetriveByDCPendingItems();
                System.Data.DataTable dt = ds.Tables[0];

                if (dt.Rows.Count > 0)
                {
                    Response.ClearContent();
                    Response.Buffer = true;
                    Response.AddHeader("content-disposition", string.Format("attachment; filename={0}", "DCPendingItems.xls"));
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
                    //lblConfirm.Text = "No Records Found.";
                    //lblConfirm.Attributes.Add("style", "color:Red");
                }
            }
            catch (Exception ex)
            {
                LogError(ex, "Exception from export button click from DC Pending Items!");
            }
        }

        protected void imgExcelForSentDCItems_Click(object sender, ImageClickEventArgs e)
        {
            lblMessage.Text = "";
            string query = string.Empty;
            string str = string.Empty;

            if (string.IsNullOrEmpty(txtFromDate.Text) || string.IsNullOrEmpty(txtToDate.Text))
            {
                lblMessage.Text = "Please select From Date and To Date.";
                return;
            }

            try
            {
                DataSet ds = _dbObj.RetriveByDCSentItems(txtFromDate.Text.ToString(), txtToDate.Text.ToString());
                System.Data.DataTable dt = ds.Tables[0];

                if (dt.Rows.Count > 0)
                {
                    Response.ClearContent();
                    Response.Buffer = true;
                    Response.AddHeader("content-disposition", string.Format("attachment; filename={0}", "DCSentItems.xls"));
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
                    //lblConfirm.Text = "No Records Found.";
                    //lblConfirm.Attributes.Add("style", "color:Red");
                }
            }
            catch (Exception ex)
            {
                LogError(ex, "Exception from export button click from DC Sent Items!");
            }
        }

        protected void imgExcelForReceivedDCItems_Click(object sender, ImageClickEventArgs e)
        {
            lblMessage.Text = "";
            string query = string.Empty;
            string str = string.Empty;

            if (string.IsNullOrEmpty(txtFromDate.Text) || string.IsNullOrEmpty(txtToDate.Text))
            {
                lblMessage.Text = "Please select From Date and To Date.";
                return;
            }

            try
            {
                DataSet ds = _dbObj.RetriveByDCReceivedItems(txtFromDate.Text.ToString(), txtToDate.Text.ToString());

                System.Data.DataTable dt = ds.Tables[0];

                if (dt.Rows.Count > 0)
                {
                    Response.ClearContent();
                    Response.Buffer = true;
                    Response.AddHeader("content-disposition", string.Format("attachment; filename={0}", "DCReceivedItems.xls"));
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
                    //lblConfirm.Text = "No Records Found.";
                    //lblConfirm.Attributes.Add("style", "color:Red");
                }
            }
            catch (Exception ex)
            {
                LogError(ex, "Exception from export button click from DC Received Items!");
            }
        }

        protected void btnSubmitBox_Click(object sender, EventArgs e)
        {
            string query = string.Empty;
            string str = string.Empty;

            #region DownLoad Excel
            //DataSet ds = _dbObj.RetriveByDCPendingItemsToSendMail(dropdownCustomer.SelectedValue.ToString());
            //System.Data.DataTable dt = ds.Tables[0];

            //if (dt.Rows.Count > 0)
            //{
            //    Response.ClearContent();
            //    Response.Buffer = true;
            //    Response.AddHeader("content-disposition", string.Format("attachment; filename={0}", ""+ dropdownCustomer.SelectedValue.ToString() + ".xls"));
            //    Response.ContentType = "application/ms-excel";

            //    foreach (DataColumn dtcol in dt.Columns)
            //    {
            //        Response.Write(str + dtcol.ColumnName);
            //        str = "\t";
            //    }
            //    Response.Write("\n");
            //    foreach (DataRow dr in dt.Rows)
            //    {
            //        str = "";
            //        for (int j = 0; j < dt.Columns.Count; j++)
            //        {
            //            Response.Write(str + Convert.ToString(dr[j]));
            //            str = "\t";
            //        }
            //        Response.Write("\n");
            //    }
            //    Response.End();

            //}
            //else
            //{
            //    lblMessage.Text = "No Records Found.";
            //    lblMessage.Attributes.Add("style", "color:Red");
            //}

            #endregion

            #region Excel Open
            //Microsoft.Office.Interop.Excel.Application xlApp;
            //Workbook xlWorkBook;
            //Worksheet xlWorkSheet;
            //object misValue = System.Reflection.Missing.Value;

            //string filePath = @"c:\users\ganapathy\documents\visual studio 2015\Projects\ExcelCheck\ExcelCheck\EmailExcel\Sample.xls";

            //xlApp = new Microsoft.Office.Interop.Excel.Application();
            //xlApp.Visible = true;
            //Microsoft.Office.Interop.Excel.Workbooks books = xlApp.Workbooks;

            //xlWorkBook = books.Open(filePath);
            #endregion

            sendEMailThroughOUTLOOK(dropdownCustomer.SelectedValue.ToString(), dropdownCustomer.SelectedItem.Text.Trim());
        }

        private void releaseObject(object obj)
        {
            try
            {
                System.Runtime.InteropServices.Marshal.ReleaseComObject(obj);
                obj = null;
            }
            catch (Exception ex)
            {
                obj = null;
                //MessageBox.Show("Unable to release the Object " + ex.ToString());
            }
            finally
            {
                GC.Collect();
            }
        }

        protected void dropdownCustomer_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void FillEmployeeDropDown()
        {
            DBUtil _DBObj = new DBUtil();
            DataSet ds = _DBObj.GetEmailFormEmployeeName();

            dropdownCustomer.DataSource = ds;
            dropdownCustomer.DataBind();
        }

        //private void SendDCPendingEmail(string emailId, string employeeName)
        //{

        //    string[] networkCredentials = ConfigurationManager.AppSettings["NetworkCredentials"].ToString().Split(',');


        //    lblMessage.Text = "";
        //    string query = string.Empty;
        //    string str = string.Empty;
        //    string fileName = "PDc_" + employeeName + "_" + System.DateTime.UtcNow.ToString("ddMMyyyyhhmmss");
        //    string filePath = HttpContext.Current.Server.MapPath("~/EmailExcel");
        //    string path = filePath + @"\" + fileName + ".xls";

        //    if (!File.Exists(path))
        //    {
        //        using (var fileCreate = File.Create(path)) { }
        //    }

        //    try
        //    {
        //        DataSet ds = _dbObj.RetriveByDCPendingItemsToSendMail(emailId);
        //        System.Data.DataTable dt = ds.Tables[0];

        //        if (dt.Rows.Count > 0)
        //        {
        //            GridView GridView1 = new GridView();
        //            GridView1.AllowPaging = false;
        //            GridView1.DataSource = dt;
        //            GridView1.DataBind();

        //            Response.Clear();
        //            Response.Buffer = true;
        //            //Response.AddHeader("content-disposition", "attachment;filename=PendingDC's.xls");

        //            Response.Charset = "";
        //            Response.ContentType = "application/vnd.ms-excel";

        //            StringWriter sw = new StringWriter();
        //            HtmlTextWriter hw = new HtmlTextWriter(sw);

        //            for (int i = 0; i < GridView1.Rows.Count; i++)
        //            {
        //                //Apply text style to each Row
        //                GridView1.Rows[i].Attributes.Add("class", "textmode");
        //            }

        //            GridView1.RenderControl(hw);

        //            Response.Output.Write(sw.ToString());

        //            System.IO.File.WriteAllText(path, sw.ToString());

        //            MailMessage eMail = new MailMessage();
        //            eMail.To.Add(emailId);
        //            eMail.From = new MailAddress("");
        //            eMail.Subject = "List of Pending DC's";
        //            eMail.Body = "";
        //            SmtpClient MailClient = new SmtpClient();
        //            MailClient.Host = "smtp.gmail.com";
        //            NetworkCredential NC = new NetworkCredential(networkCredentials[0].ToString(), networkCredentials[1].ToString());

        //            MailClient.UseDefaultCredentials = true;
        //            MailClient.Credentials = NC;
        //            MailClient.EnableSsl = true;
        //            MailClient.Port = 587;
        //            MailClient.Send(eMail);
        //            //Response.Write("Email Sent");

        //            Response.Flush();
        //            Response.End();
        //        }
        //        else
        //        {
        //            lblMessage.Text = "There is no DC pending items, Please try again with other vendor.";
        //            return;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        LogError(ex, "Exception from opening Outlook mail!");
        //    }
        //}

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

        private void sendEMailThroughOUTLOOK(string emailId, string employeeName)
        {
            try
            {
                string[] networkCredentials = ConfigurationManager.AppSettings["NetworkCredentials"].ToString().Split(',');

                string fromAddress = ConfigurationManager.AppSettings["FromAddress"].ToString();
                string port = ConfigurationManager.AppSettings["EmailPort"].ToString();
                string hostName = ConfigurationManager.AppSettings["HostName"].ToString();

                lblMessage.Text = "";
                string query = string.Empty;
                string str = string.Empty;
                string fileName = "PDc_" + employeeName + "_" + System.DateTime.UtcNow.ToString("ddMMyyyyhhmmss");
                string filePath = HttpContext.Current.Server.MapPath("~/EmailExcel");
                string path = filePath + @"\" + fileName + ".xls";

                if (!File.Exists(path))
                {
                    using (var fileCreate = File.Create(path)) { }
                }

                DataSet ds = _dbObj.RetriveByDCPendingItemsToSendMail(emailId);
                System.Data.DataTable dt = ds.Tables[0];

                if (dt.Rows.Count > 0)
                {
                    GridView GridView1 = new GridView();
                    GridView1.AllowPaging = false;
                    GridView1.DataSource = dt;
                    GridView1.DataBind();

                    Response.Clear();
                    Response.Buffer = true;
                    Response.AddHeader("content-disposition", string.Format("attachment; filename={0}", "" + dropdownCustomer.SelectedValue.ToString() + ".xls"));

                    Response.Charset = "";
                    Response.ContentType = "application/vnd.ms-excel";

                    StringWriter sw = new StringWriter();
                    HtmlTextWriter hw = new HtmlTextWriter(sw);

                    for (int i = 0; i < GridView1.Rows.Count; i++)
                    {
                        //Apply text style to each Row
                        GridView1.Rows[i].Attributes.Add("class", "textmode");
                    }

                    GridView1.RenderControl(hw);

                    Response.Output.Write(sw.ToString());

                    File.WriteAllText(path, sw.ToString());

                    // Create the Outlook application.
                    // These 3 lines solved the problem
                    using (MailMessage eMail = new MailMessage())
                    {
                        eMail.From = new MailAddress(fromAddress);
                        eMail.To.Add(new MailAddress(emailId));
                        eMail.CC.Add(new MailAddress(fromAddress));
                        eMail.Subject = "List of Pending DC's";
                        eMail.Body = "";
                        var attachment = new Attachment(path);
                        eMail.Attachments.Add(attachment);
                        using (var MailClient = new SmtpClient())
                        {
                            MailClient.Host = Convert.ToString(hostName);
                            NetworkCredential NC = new NetworkCredential(networkCredentials[0].ToString(), networkCredentials[1].ToString());
                            MailClient.UseDefaultCredentials = true;
                            MailClient.Credentials = NC;
                            MailClient.EnableSsl = true;
                            MailClient.Port = Convert.ToInt16(port);

                            MailClient.Send(eMail);
                            lblMessage.Visible = true;
                        }
                    }
                }

                lblMessage.Text = "Successfully mail sent";
            }
            catch (Exception ex)
            {
                LogError(ex, "Exception from email sending!");
            }
            finally
            {
                HttpContext.Current.Response.Flush();
                HttpContext.Current.Response.SuppressContent = true;
                HttpContext.Current.ApplicationInstance.CompleteRequest();
            }
        }
    }
}
