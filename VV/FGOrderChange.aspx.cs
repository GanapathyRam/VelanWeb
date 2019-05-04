﻿using Libraries.Entity;
using Microsoft.Practices.EnterpriseLibrary.Logging;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;

namespace VV
{
    public partial class FGOrderChange : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            #region Master Control

            #region Welcome Msg
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
                ShowFGOrderChangeFromGrid();
            }

            System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-IN");
        }

        private void ShowFGOrderChangeFromGrid()
        {
            DBUtil _DBObj = new DBUtil();
            DataSet ds = _DBObj.RetrieveBaaNDataForFGOrderChangeFromGrid();

            Cache["ImportedBaanForFGOrderChangeFromGridDBCache"] = ds;
            grdViewBaaNResult.DataSource = ds;
            grdViewBaaNResult.DataBind();
        }

        protected void grdViewBaaNResult_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            DataSet ds = (DataSet)Cache["ImportedBaanForFGOrderChangeFromGridDBCache"];

            grdViewBaaNResult.PageIndex = e.NewPageIndex;
            grdViewBaaNResult.DataSource = ds;
            grdViewBaaNResult.DataBind();

            try
            {
                String OrderType_Search = txtOrderType.Text.Trim();
                String SalesOrderNo_Search = txtSalesOrderNo.Text.Trim();
                String Pos_Search = txtPos_Search.Text.Trim();

                String searchRowFilter = String.Empty, searchRowFilter1 = String.Empty, searchRowFilter2 = String.Empty, searchRowFilter3 = String.Empty;

                if (!String.IsNullOrEmpty(OrderType_Search))
                {
                    searchRowFilter1 = "OrderType = '" + OrderType_Search + "'";
                }

                if (!String.IsNullOrEmpty(SalesOrderNo_Search))
                {
                    searchRowFilter2 = "OrderNo = '" + SalesOrderNo_Search + "'";
                }

                if (!String.IsNullOrEmpty(Pos_Search))
                {
                    searchRowFilter2 = "Pos = '" + Pos_Search + "'";
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

                if (!String.IsNullOrEmpty(searchRowFilter))
                {
                    DataView dv;
                    dv = ds.Tables[0].DefaultView;

                    dv.RowFilter = searchRowFilter;

                    grdViewBaaNResult.DataSource = dv;
                    grdViewBaaNResult.DataBind();
                }
            }

            catch (Exception ex)
            {
                Logger.Write(this.GetType().ToString() + " : View BaaN - When trying to do a Paging : " + " : " + DateTime.Now + " : " + ex.Message.ToString(), Category.General, Priority.Highest);
                throw ex;
            }
        }

        protected void btnSearchBox_Click(object sender, EventArgs e)
        {
            try
            {
                lblMessage.Visible = false;

                String OrderType_Search = txtOrderType.Text.Trim();
                String SalesOrderNo_Search = txtSalesOrderNo.Text.Trim();
                String Pos_Search = txtPos_Search.Text.Trim();

                String searchRowFilter = String.Empty, searchRowFilter1 = String.Empty, searchRowFilter2 = String.Empty, searchRowFilter3 = String.Empty;

                if (!String.IsNullOrEmpty(OrderType_Search))
                {
                    searchRowFilter1 = "OrderType = '" + OrderType_Search + "'";
                }

                if (!String.IsNullOrEmpty(SalesOrderNo_Search))
                {
                    searchRowFilter2 = "OrderNo = '" + SalesOrderNo_Search + "'";
                }

                if (!String.IsNullOrEmpty(Pos_Search))
                {
                    searchRowFilter2 = "Pos = '" + Pos_Search + "'";
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

                if (!String.IsNullOrEmpty(searchRowFilter))
                {
                    DataSet searchDS = (DataSet)Cache["ImportedBaanForFGOrderChangeFromGridDBCache"];

                    DataView dv;
                    dv = searchDS.Tables[0].DefaultView;

                    dv.RowFilter = searchRowFilter;

                    grdViewBaaNResult.DataSource = dv;
                    grdViewBaaNResult.DataBind();
                }
                else if (string.IsNullOrEmpty(searchRowFilter1) && string.IsNullOrEmpty(searchRowFilter2) && string.IsNullOrEmpty(searchRowFilter3))
                {
                    DataSet searchDS = (DataSet)Cache["ImportedBaanForFGOrderChangeFromGridDBCache"];

                    DataView dv;
                    dv = searchDS.Tables[0].DefaultView;

                    dv.RowFilter = searchRowFilter;

                    grdViewBaaNResult.DataSource = dv;
                    grdViewBaaNResult.DataBind();
                }
                else
                {
                    DataSet searchDS = (DataSet)Cache["ImportedBaanForFGOrderChangeFromGridDBCache"];
                    grdViewBaaNResult.DataSource = searchDS;
                    grdViewBaaNResult.DataBind();
                }
            }
            catch (Exception ex)
            {
                Logger.Write(this.GetType().ToString() + " : btnSearchBox_Click : " + " : " + DateTime.Now + " : " + ex.Message.ToString(), Category.General, Priority.Highest);
                throw ex;
            }

        }

        public void Convert(DataSet ds, string fileName)
        {
            Convert(ds.Tables, fileName);
        }

        public void Convert(IEnumerable tables, string fileName)
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

        protected void btnConvert_Click(object sender, EventArgs e)
        {
            DBUtil _DBObj = new DBUtil();
            lblMessage.Text = "";

            try
            {
                string qtyToBeConvert = txtQtyToConvert.Text;

                foreach (GridViewRow row in grdViewBaaNResult.Rows)
                {
                    bool isChecked = ((CheckBox)row.FindControl("chkSelect")).Checked;
                    if (isChecked)
                    {
                        string lblOrderNo = ((Label)row.FindControl("lblOrderNo")).Text.ToString();
                        string lblPos = ((Label)row.FindControl("lblPos")).Text.ToString();
                        string lblItem = ((Label)row.FindControl("lblItem")).Text.ToString();
                        string lblFGQty = ((Label)row.FindControl("lblFGQty")).Text.ToString();


                        if (System.Convert.ToInt32(qtyToBeConvert) <= System.Convert.ToInt32(lblFGQty))
                        {
                            DataSet ds = _DBObj.RetrieveBaaNDataForFGOrderChangeToGrid(System.Convert.ToInt32(qtyToBeConvert));
                            Cache["ImportedBaanForFGOrderChangeToGridDBCache"] = ds;

                            GridView1.DataSource = ds;
                            GridView1.DataBind();
                        }
                        else
                        {
                            lblMessage.Text = "Cannot convert!. Please try with other order no.";
                            lblMessage.Visible = true;
                        }

                    }
                }
            }
            catch (Exception ex)
            {
                LogError(ex, "Exception from while converting FG To Other!.");
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

        protected void btnConfirm_Click(object sender, EventArgs e)
        {
            #region Variable Declaration
            string qtyToConvert = string.Empty;
            string fromOrderNo = string.Empty;
            string fromPos = string.Empty;
            string toOrderNo = string.Empty;
            string toPos = string.Empty;
            bool fromOrder = false;
            bool toOrder = false;
            #endregion

            DBUtil _DBObj = new DBUtil();
            lblMessage.Text = "";

            try
            {
                qtyToConvert = txtQtyToConvert.Text;

                foreach (GridViewRow row in grdViewBaaNResult.Rows)
                {
                    bool isChecked = ((CheckBox)row.FindControl("chkSelect")).Checked;
                    if (isChecked)
                    {
                        fromOrder = true;
                    }
                }

                foreach (GridViewRow row in GridView1.Rows)
                {
                    bool isChecked = ((CheckBox)row.FindControl("chkSelect1")).Checked;
                    if (isChecked)
                    {
                        toOrder = true;
                    }
                }

                if (!fromOrder || !toOrder)
                {
                    lblMessage.Text =  @"Please select the checkbox options from ""From Order And To Order"" Grid!.";
                    lblMessage.Visible = true;
                }

                if (!string.IsNullOrEmpty(qtyToConvert) && fromOrder && toOrder)
                {
                    foreach (GridViewRow row in grdViewBaaNResult.Rows)
                    {
                        bool isChecked = ((CheckBox)row.FindControl("chkSelect")).Checked;
                        if (isChecked)
                        {
                            fromOrderNo = ((Label)row.FindControl("lblOrderNo")).Text.ToString();
                            fromPos = ((Label)row.FindControl("lblPos")).Text.ToString();
                            string lblReleaseQty = ((Label)row.FindControl("lblToReleaseQty")).Text.ToString() == "" ? "0" : ((Label)row.FindControl("lblToReleaseQty")).Text.ToString();
                            string lblFGQty = ((Label)row.FindControl("lblFGQty")).Text.ToString() == "" ? "0" : ((Label)row.FindControl("lblFGQty")).Text.ToString();

                            //update From Order:
                            _DBObj.UpdateBaaNDataInMISOrderStatusFromOrder(System.Convert.ToInt32(fromOrderNo), System.Convert.ToInt32(fromPos),
                                System.Convert.ToInt32(lblReleaseQty), System.Convert.ToInt32(lblFGQty), System.Convert.ToInt32(qtyToConvert));
                        }
                    }

                    foreach (GridViewRow row in GridView1.Rows)
                    {
                        bool isChecked = ((CheckBox)row.FindControl("chkSelect1")).Checked;
                        if (isChecked)
                        {
                            toOrderNo = ((Label)row.FindControl("lblOrderNo")).Text.ToString();
                            toPos = ((Label)row.FindControl("lblPos")).Text.ToString();
                            string lblReleaseQty = ((Label)row.FindControl("lblToReleaseQty")).Text.ToString() == "" ? "0" : ((Label)row.FindControl("lblToReleaseQty")).Text.ToString();
                            string lblFGQty = ((Label)row.FindControl("lblFGQty")).Text.ToString() == "" ? "0" : ((Label)row.FindControl("lblFGQty")).Text.ToString();

                            //update To Order :
                            _DBObj.UpdateBaaNDataInMISOrderStatusToOrder(System.Convert.ToInt32(toOrderNo), System.Convert.ToInt32(toPos),
                                System.Convert.ToInt32(lblReleaseQty), System.Convert.ToInt32(lblFGQty), System.Convert.ToInt32(qtyToConvert));

                            lblMessage.Text = "Updated Successfully.";
                            lblMessage.Visible = true;
                        }
                    }

                    _DBObj.InsertFGConvert(System.Convert.ToInt32(fromOrderNo), System.Convert.ToInt32(fromPos),
                        System.Convert.ToInt32(qtyToConvert), System.Convert.ToInt32(toOrderNo), System.Convert.ToInt32(toPos));
                }

            }
            catch (Exception ex)
            {
                LogError(ex, "Exception from while confirming the FG To Other!.");
            }

            txtQtyToConvert.Text = "";
            ShowFGOrderChangeFromGrid();
        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            DataSet ds = (DataSet)Cache["ImportedBaanForFGOrderChangeToGridDBCache"];

            GridView1.PageIndex = e.NewPageIndex;
            GridView1.DataSource = ds;
            GridView1.DataBind();

            try
            {
                String OrderType_Search = txtOrderType.Text.Trim();
                String SalesOrderNo_Search = txtSalesOrderNo.Text.Trim();
                String Pos_Search = txtPos_Search.Text.Trim();

                String searchRowFilter = String.Empty, searchRowFilter1 = String.Empty, searchRowFilter2 = String.Empty, searchRowFilter3 = String.Empty;

                if (!String.IsNullOrEmpty(OrderType_Search))
                {
                    searchRowFilter1 = "OrderType = '" + OrderType_Search + "'";
                }

                if (!String.IsNullOrEmpty(SalesOrderNo_Search))
                {
                    searchRowFilter2 = "OrderNo = '" + SalesOrderNo_Search + "'";
                }

                if (!String.IsNullOrEmpty(Pos_Search))
                {
                    searchRowFilter2 = "Pos = '" + Pos_Search + "'";
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

                if (!String.IsNullOrEmpty(searchRowFilter))
                {
                    DataView dv;
                    dv = ds.Tables[0].DefaultView;

                    dv.RowFilter = searchRowFilter;

                    GridView1.DataSource = dv;
                    GridView1.DataBind();
                }
            }

            catch (Exception ex)
            {
                Logger.Write(this.GetType().ToString() + " : View BaaN - When trying to do a Paging : " + " : " + DateTime.Now + " : " + ex.Message.ToString(), Category.General, Priority.Highest);
                throw ex;
            }
        }

        protected void btnSearch1_Click(object sender, EventArgs e)
        {
            try
            {
                lblMessage.Visible = false;

                String OrderType_Search = txtOrderType1.Text.Trim();
                String SalesOrderNo_Search = txtSalesOrderNo1.Text.Trim();
                String Pos_Search = txtPos1.Text.Trim();

                String searchRowFilter = String.Empty, searchRowFilter1 = String.Empty, searchRowFilter2 = String.Empty, searchRowFilter3 = String.Empty;

                if (!String.IsNullOrEmpty(OrderType_Search))
                {
                    searchRowFilter1 = "OrderType = '" + OrderType_Search + "'";
                }

                if (!String.IsNullOrEmpty(SalesOrderNo_Search))
                {
                    searchRowFilter2 = "OrderNo = '" + SalesOrderNo_Search + "'";
                }

                if (!String.IsNullOrEmpty(Pos_Search))
                {
                    searchRowFilter2 = "Pos = '" + Pos_Search + "'";
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

                if (!String.IsNullOrEmpty(searchRowFilter))
                {
                    DataSet searchDS = (DataSet)Cache["ImportedBaanForFGOrderChangeToGridDBCache"];

                    DataView dv;
                    dv = searchDS.Tables[0].DefaultView;

                    dv.RowFilter = searchRowFilter;

                    GridView1.DataSource = dv;
                    GridView1.DataBind();
                }
                else if (string.IsNullOrEmpty(searchRowFilter1) && string.IsNullOrEmpty(searchRowFilter2) && string.IsNullOrEmpty(searchRowFilter3))
                {
                    DataSet searchDS = (DataSet)Cache["ImportedBaanForFGOrderChangeToGridDBCache"];

                    DataView dv;
                    dv = searchDS.Tables[0].DefaultView;

                    dv.RowFilter = searchRowFilter;

                    GridView1.DataSource = dv;
                    GridView1.DataBind();
                }
                else
                {
                    DataSet searchDS = (DataSet)Cache["ImportedBaanForFGOrderChangeToGridDBCache"];
                    GridView1.DataSource = searchDS;
                    GridView1.DataBind();
                }
            }
            catch (Exception ex)
            {
                Logger.Write(this.GetType().ToString() + " : btnSearchBox1_Click : " + " : " + DateTime.Now + " : " + ex.Message.ToString(), Category.General, Priority.Highest);
                throw ex;
            }
        }
    }
}