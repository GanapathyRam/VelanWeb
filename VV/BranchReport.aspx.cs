using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace VV
{
    public partial class BranchReport : System.Web.UI.Page
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
                    else if (MenuID == 11) // Production Order Importing
                        tbstr.Items[ParentMenuID].ChildItems[3].ChildItems[8].Enabled = true;
                    else if (MenuID == 12) // Heat No Values
                        tbstr.Items[ParentMenuID].ChildItems[4].Enabled = true;
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

            if (!Page.IsPostBack)
            {
                FillBranchReportTypes();
            }

            System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-IN");
        }

        protected void ddlReportTypes_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                DBUtil _DBObj = new DBUtil();
                DataSet ds = _DBObj.RetriveByCustomerNameForBranchReport();

                if (ddlReportTypes.SelectedItem.Text == "----Please Select----")
                {
                    ddlCustomerName.Enabled = false;
                    ddlOrderNo.Enabled = false;
                    txtOrderNo.Enabled = false;
                    btnSearch.Enabled = false;
                }
                else
                {
                    ddlCustomerName.DataSource = ds;
                    ddlCustomerName.DataBind();

                    ddlCustomerName.Items.Insert(0, "----Please Select----");

                    ddlCustomerName.Enabled = true;

                    txtOrderNo.Enabled = true;
                    btnSearch.Enabled = true;
                }

                GridView1.Visible = false;
                GridView2.Visible = false;

                ddlOrderNo.Enabled = false;
            }
            catch (Exception ex)
            {
                Helper.LogError(ex, "Exception from Branch Report Drop down selection.!");
            }
        }

        protected void ddlOrderNo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlCustomerName.SelectedItem.Text != "----Please Select----" && ddlOrderNo.SelectedItem.Text != "----Please Select----")
            {
                GridView1.Visible = true;

                ShowDetailedReport(ddlOrderNo.SelectedItem.Value);
            }
            else
            {
                GridView1.Visible = false;
            }
        }

        protected void ddlCustomerName_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                DBUtil _DBObj = new DBUtil();

                if (ddlReportTypes.SelectedItem.Text == "Detailed Report")
                {
                    DataSet ds = _DBObj.RetriveByOrderNoForBranchReport(ddlCustomerName.SelectedItem.Text);

                    ddlOrderNo.DataSource = ds;
                    ddlOrderNo.DataBind();

                    ddlOrderNo.Items.Insert(0, "----Please Select----");

                    ddlOrderNo.Enabled = true;

                    GridView1.Visible = false;
                    GridView2.Visible = false;
                }
                else
                {
                    GridView1.Visible = false;

                    ShowSummaryReport(ddlCustomerName.SelectedItem.Text);

                    ddlOrderNo.Enabled = false;

                    GridView2.Visible = true;
                }
            }
            catch (Exception ex)
            {
                Helper.LogError(ex, "Exception from Branch Report Drop down selection.!");
            }
        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            DataSet ds = (DataSet)Cache["CacheForSummaryReport"];

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
                Helper.LogError(ex, "Exception from while clicking on page number from detailed master.");
            }
        }

        protected void GridView1_Sorting(object sender, GridViewSortEventArgs e)
        {

        }


        #region Private Methods

        private DataSet FillBranchReportTypes()
        {

            DBUtil _DBObj = new DBUtil();
            DataSet ds = _DBObj.RetriveByBranchReportTypes();

            ddlReportTypes.DataSource = ds;
            ddlReportTypes.DataBind();

            ddlReportTypes.Items.Insert(0, "----Please Select----");

            return ds;
        }

        private DataSet ShowDetailedReport(string OrderNo)
        {
            string pageSize = ConfigurationManager.AppSettings["GridPageSize"].ToString();

            DBUtil _DBObj = new DBUtil();
            DataSet ds = _DBObj.RetriveByDetailedReport(Convert.ToString(OrderNo));

            Cache["CacheForDetailedReport"] = ds;

            GridView1.PageSize = Convert.ToInt32(pageSize);

            GridView1.DataSource = ds;
            GridView1.DataBind();

            return ds;
        }

        private DataSet ShowSummaryReport(string CustomerName)
        {
            string pageSize = ConfigurationManager.AppSettings["GridPageSize"].ToString();

            DBUtil _DBObj = new DBUtil();
            DataSet ds = _DBObj.RetriveBySummaryReport(CustomerName);

            Cache["CacheForSummaryReport"] = ds;

            GridView1.PageSize = Convert.ToInt32(pageSize);

            GridView2.DataSource = ds;
            GridView2.DataBind();

            return ds;
        }

        #endregion

        protected void btnGenerateExcel_Click(object sender, EventArgs e)
        {
            string query = string.Empty;
            string str = string.Empty;

            try
            {
                if (ddlReportTypes.SelectedItem.Text == "Detailed Report" && ddlCustomerName.SelectedItem.Text != "----Please Select----"
                    && ddlOrderNo.SelectedItem.Text != "----Please Select----")
                {
                    DataSet ds = ShowDetailedReport(ddlOrderNo.SelectedItem.Value);
                    System.Data.DataTable dt = ds.Tables[0];

                    if (dt.Rows.Count > 0)
                    {
                        Response.ClearContent();
                        Response.Buffer = true;
                        Response.AddHeader("content-disposition", string.Format("attachment; filename={0}", "Detailed_Report.xls"));
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
                    { }
                }
                else if (ddlReportTypes.SelectedItem.Text == "Summary Report" && ddlCustomerName.SelectedItem.Text != "----Please Select----")
                {
                    DataSet ds = ShowSummaryReport(ddlCustomerName.SelectedItem.Value);
                    System.Data.DataTable dt = ds.Tables[0];

                    if (dt.Rows.Count > 0)
                    {
                        Response.ClearContent();
                        Response.Buffer = true;
                        Response.AddHeader("content-disposition", string.Format("attachment; filename={0}", "Summary_Report.xls"));
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
                    { }
                }
            }
            catch (Exception ex)
            {
                Helper.LogError(ex, "Exception from export button click from DC Pending Items!");
            }
        }

        protected void GridView2_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            DataSet ds = (DataSet)Cache["CacheForDetailedReport"];

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
                Helper.LogError(ex, "Exception from while clicking on page number from summary report.");
            }
        }

        protected void GridView2_Sorting(object sender, GridViewSortEventArgs e)
        {

        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            if (ddlReportTypes.SelectedItem.Text == "Detailed Report")
            {
                ShowDetailedReport(txtOrderNo.Text);

                GridView1.Visible = true;
            }
        }
    }
}