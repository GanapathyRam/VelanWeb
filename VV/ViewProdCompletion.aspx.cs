﻿using Libraries.Entity;
using Microsoft.Practices.EnterpriseLibrary.Logging;
using System;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;

namespace VV
{
    public partial class ViewProdCompletion : System.Web.UI.Page
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
                    else if (MenuID == 3) // Primary Box Entry
                        tbstr.Items[ParentMenuID].ChildItems[MenuID].Enabled = true;
                    else if (MenuID == 4) // Primary Box Maintance
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

                    else if (MenuID == 7) // Secondary Box Entry
                        tbstr.Items[ParentMenuID].ChildItems[6].Enabled = true;
                    else if (MenuID == 8) // Secondary Box Entry - Maintenance
                        tbstr.Items[ParentMenuID].ChildItems[7].Enabled = true;
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
                showgrid();
        }

        protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            DataSet searchDS = (DataSet)Cache["ProdCompletionDataFromDBCache"];
            GridView1.DataSource = searchDS;
            GridView1.DataBind();

            GridView1.EditIndex = -1;
            //  showgrid();

            GridView1.DataSource = searchDS;
            GridView1.DataBind();

            GridView1.EditIndex = -1;
        }

        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            lblMessage.Visible = false;

            DataSet searchDS = (DataSet)Cache["ProdCompletionDataFromDBCache"];
            GridView1.DataSource = searchDS;
            GridView1.DataBind();

            GridView1.EditIndex = e.NewEditIndex;

            GridView1.DataSource = searchDS;
            GridView1.DataBind();
        }

        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            DataSet ds = new DataSet();
            DBUtil _dbObj = new DBUtil();
            bool isHeatNoControl = false;

            try
            {
                Label lbProdOrderNo = (Label)GridView1.Rows[e.RowIndex].FindControl("lblProdOrderNo");
                Label lbSerialNo = (Label)GridView1.Rows[e.RowIndex].FindControl("lblSerialNo");
                Label lbOrderNo = (Label)GridView1.Rows[e.RowIndex].FindControl("lblOrderNo");
                Label lbLineNo = (Label)GridView1.Rows[e.RowIndex].FindControl("lblLineNo");
                Label lbPos = (Label)GridView1.Rows[e.RowIndex].FindControl("lblPos");
                Label lblBodyHeatNo = (Label)GridView1.Rows[e.RowIndex].FindControl("lblBodyHeatNo");

                TextBox txProdDeliveryDate = (TextBox)GridView1.Rows[e.RowIndex].FindControl("txtProdDeliveryDate");
                TextBox txProdComplDate = (TextBox)GridView1.Rows[e.RowIndex].FindControl("txtProdComplDate");
                // TextBox txProdRemarks = (TextBox)GridView1.Rows[e.RowIndex].FindControl("txtProdRemarks");

                DropDownList drDwnPrdRem = (DropDownList)GridView1.Rows[e.RowIndex].FindControl("drpDwnPrdRem");

                ds = _dbObj.FetchHeatNoControl();

                if (ds.Tables.Count > 0)
                {
                    isHeatNoControl = Convert.ToBoolean(ds.Tables[0].Rows[0]["HeatNoControl"].ToString());
                }

                if (isHeatNoControl && drDwnPrdRem.SelectedItem.Text.Trim() == "Under TPI")
                {
                    if (!string.IsNullOrEmpty(lblBodyHeatNo.Text) && !string.IsNullOrEmpty(lbSerialNo.Text))
                    {
                        _dbObj.UpdateProdCompletion(Convert.ToString(lbOrderNo.Text.Trim()), lbLineNo.Text.Trim(), Int32.Parse(lbPos.Text.Trim()), lbProdOrderNo.Text.Trim(), lbSerialNo.Text.Trim(), txProdDeliveryDate.Text.Trim(), txProdComplDate.Text.Trim(), drDwnPrdRem.SelectedItem.Text.Trim());
                    }
                    else
                    {
                        // showing the error message like heat or serial no is not available
                        //lblMessage.Visible = true;
                        //lblMessage.ForeColor = System.Drawing.Color.Red;
                        //lblMessage.Text = "Selected row does not have body heat number to proceed further.";

                        ScriptManager.RegisterClientScriptBlock(Page, this.GetType(), "alert",
                            string.Format("alert('{1}', '{0}');", "", "Selected row does not have body heat number to proceed further."), true);
                    }
                }
                else
                {
                    _dbObj.UpdateProdCompletion(Convert.ToString(lbOrderNo.Text.Trim()), lbLineNo.Text.Trim(), Int32.Parse(lbPos.Text.Trim()), lbProdOrderNo.Text.Trim(), lbSerialNo.Text.Trim(), txProdDeliveryDate.Text.Trim(), txProdComplDate.Text.Trim(), drDwnPrdRem.SelectedItem.Text.Trim());
                }
                //_dbObj.UpdateProdCompletion(Int32.Parse(lbOrderNo.Text.Trim()), lbLineNo.Text.Trim(), Int32.Parse(lbPos.Text.Trim()), lbProdOrderNo.Text.Trim(), lbSerialNo.Text.Trim(), txProdDeliveryDate.Text.Trim(), txProdComplDate.Text.Trim(), txProdRemarks.Text.Trim());

                // Commented From Ganapathy on : 10/04/2019
                //_dbObj.UpdateProdCompletion(Int32.Parse(lbOrderNo.Text.Trim()), lbLineNo.Text.Trim(), Int32.Parse(lbPos.Text.Trim()), lbProdOrderNo.Text.Trim(), lbSerialNo.Text.Trim(), txProdDeliveryDate.Text.Trim(), txProdComplDate.Text.Trim(), drDwnPrdRem.SelectedItem.Text.Trim());

                GridView1.EditIndex = -1;
                showgrid();
            }
            catch (Exception ex)
            {
                Logger.Write(this.GetType().ToString() + " : GridView1_RowUpdating : " + " : " + DateTime.Now + " : " + ex.Message.ToString(), Category.General, Priority.Highest);
                throw ex;
            }
        }

        public DataSet GetRemarks()
        {
            try
            {
                DataTable tblRemarks = new DataTable();

                DataColumn column;
                DataRow row;

                column = new DataColumn();
                column.DataType = System.Type.GetType("System.String");
                column.ColumnName = "remarkdesc";
                tblRemarks.Columns.Add(column);

                column = new DataColumn();
                column.DataType = System.Type.GetType("System.Int32");
                column.ColumnName = "remarkid";
                tblRemarks.Columns.Add(column);



                string[] ddlValues = ConfigurationManager.AppSettings["ProdRemarks"].ToString().Split(',');

                //row = tblRemarks.NewRow();
                //row["remarkid"] = 0;
                //row["remarkdesc"] = "Please Select";
                //tblRemarks.Rows.Add(row);

                for (int i = 0; i <= ddlValues.Length - 1; i++)
                {
                    row = tblRemarks.NewRow();
                    row["remarkid"] = ddlValues[i].Split('-')[0].Trim();
                    row["remarkdesc"] = ddlValues[i].Split('-')[1].Trim();
                    tblRemarks.Rows.Add(row);
                }

                DataSet dsRemarks = new DataSet();
                dsRemarks.Tables.Add(tblRemarks);

                return dsRemarks;
            }
            catch (Exception ex)
            {
                Logger.Write(this.GetType().ToString() + " : GetRemarks : " + " : " + DateTime.Now + " : " + ex.Message.ToString(), Category.General, Priority.Highest);
                throw ex;
            }
        }

        public void showgrid()
        {
            try
            {
                DBUtil _DBObj = new DBUtil();
                DataSet ds = _DBObj.RetrieveProdCompletionData();

                Cache["ProdCompletionDataFromDBCache"] = ds;
                GridView1.DataSource = ds;
                GridView1.DataBind();
            }
            catch (Exception ex)
            {
                Logger.Write(this.GetType().ToString() + " : showgrid : " + " : " + DateTime.Now + " : " + ex.Message.ToString(), Category.General, Priority.Highest);
                throw ex;
            }
        }

        protected void btnSearchBox_Click(object sender, EventArgs e)
        {
            lblMessage.Visible = false;

            try
            {
                String FigNo_Search = txtFigNo.Text.Trim();
                String ProdOrderNo_Search = txtProdOrderNo.Text.Trim();

                String searchRowFilter = String.Empty, searchRowFilter1 = String.Empty, searchRowFilter2 = String.Empty;

                if (!String.IsNullOrEmpty(FigNo_Search))
                {
                    searchRowFilter1 = "FigNo = '" + FigNo_Search + "'";
                }

                if (!String.IsNullOrEmpty(ProdOrderNo_Search))
                {
                    searchRowFilter2 = "ProdOrderNo = '" + ProdOrderNo_Search + "'";
                }

                if (!String.IsNullOrEmpty(searchRowFilter1))
                {
                    searchRowFilter = searchRowFilter + searchRowFilter1;

                    if (!String.IsNullOrEmpty(searchRowFilter2))
                        searchRowFilter = searchRowFilter + " AND " + searchRowFilter2;
                }
                else
                {
                    searchRowFilter = searchRowFilter + searchRowFilter2;
                }

                if (!String.IsNullOrEmpty(searchRowFilter))
                {
                    DataSet searchDS = (DataSet)Cache["ProdCompletionDataFromDBCache"];

                    DataView dv;
                    dv = searchDS.Tables[0].DefaultView;

                    dv.RowFilter = searchRowFilter;

                    GridView1.DataSource = dv;
                    GridView1.DataBind();

                    DataSet DS = new DataSet();
                    DS.Tables.Add(dv.ToTable());
                    Cache["ProdCompletionDataFromDBCache"] = DS;
                }
                else
                {
                    DataSet searchDS = (DataSet)Cache["ProdCompletionDataFromDBCache"];
                    GridView1.DataSource = searchDS;
                    GridView1.DataBind();
                }
            }
            catch (Exception ex)
            {
                Logger.Write(this.GetType().ToString() + " : btnSearchBox_Click : " + " : " + DateTime.Now + " : " + ex.Message.ToString(), Category.General, Priority.Highest);
                throw ex;
            }
        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            lblMessage.Visible = false;

            DataSet ds = (DataSet)Cache["ProdCompletionDataFromDBCache"];

            GridView1.PageIndex = e.NewPageIndex;
            GridView1.DataSource = ds;
            GridView1.DataBind();

            try
            {
                String FigNo_Search = txtFigNo.Text.Trim();
                String ProdOrderNo_Search = txtProdOrderNo.Text.Trim();

                String searchRowFilter = String.Empty, searchRowFilter1 = String.Empty, searchRowFilter2 = String.Empty;

                if (!String.IsNullOrEmpty(FigNo_Search))
                {
                    searchRowFilter1 = "FigNo = '" + FigNo_Search + "'";
                }

                if (!String.IsNullOrEmpty(ProdOrderNo_Search))
                {
                    searchRowFilter2 = "ProdOrderNo = '" + ProdOrderNo_Search + "'";
                }

                if (!String.IsNullOrEmpty(searchRowFilter1))
                {
                    searchRowFilter = searchRowFilter + searchRowFilter1;

                    if (!String.IsNullOrEmpty(searchRowFilter2))
                        searchRowFilter = searchRowFilter + " AND " + searchRowFilter2;
                }
                else
                {
                    searchRowFilter = searchRowFilter + searchRowFilter2;
                }

                if (!String.IsNullOrEmpty(searchRowFilter))
                {
                    DataSet searchDS = (DataSet)Cache["ProdCompletionDataFromDBCache"];

                    DataView dv;
                    dv = searchDS.Tables[0].DefaultView;

                    dv.RowFilter = searchRowFilter;

                    GridView1.DataSource = dv;
                    GridView1.DataBind();
                }
            }

            catch (Exception ex)
            {
                Logger.Write(this.GetType().ToString() + " : View Prod Completion - When trying to do a Paging : " + " : " + DateTime.Now + " : " + ex.Message.ToString(), Category.General, Priority.Highest);
                throw ex;
            }
        }

        private void MessageBox(string strMsg)
        {

            //Label lbl = new Label();
            //lblMessage.Text = @"<script language='javascript'>" & Environment.NewLine _ & "window.alert(" & "'" & strMsg & "'" & ")</script>";
            //Page.Controls.Add(lbl)
        }

        //protected void Button1_Click(object sender, EventArgs e)
        //{ }
    }
}