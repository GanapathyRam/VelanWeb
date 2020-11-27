using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace VV
{
    public partial class WeekWiseShortageReport : System.Web.UI.Page
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

            System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-IN");

            if (!Page.IsPostBack)
            {
                ShowWeekWiseShortageReport();
            }

            # endregion
        }

        protected void btnSearchBox_Click(object sender, EventArgs e)
        {
            lblMessage.Visible = false;

            try
            {
                String searchRowFilter = String.Empty, searchRowFilter1 = String.Empty, searchRowFilter2 = String.Empty, searchRowFilter3 = String.Empty, searchRowFilter4 = String.Empty;

                string OrderNo = txtOrderNo.Text.Trim();
                string Pos = txtPos.Text.Trim();
                string Buyer = txtBuyer.Text.Trim();
                string Description = txtDescription.Text.Trim();

                if (!string.IsNullOrEmpty(OrderNo))
                {
                    searchRowFilter1 = "PoOrder like '%" + OrderNo + "%'";
                }
                if (!string.IsNullOrEmpty(Pos))
                {
                    searchRowFilter2 = "Name like '%" + Pos + "%'";
                }
                if (!string.IsNullOrEmpty(Buyer))
                {
                    searchRowFilter3 = "Buyer like '%" + Buyer + "%'";
                }
                if (!string.IsNullOrEmpty(Description))
                {
                    searchRowFilter4 = "ItemNumber like '%" + Description + "%'";
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
                    DataSet searchDS = (DataSet)Cache["WeekWiseShortageReportCache"];

                    DataView dv;
                    dv = searchDS.Tables[0].DefaultView;

                    dv.RowFilter = searchRowFilter;

                    GridView1.DataSource = dv;
                    GridView1.DataBind();

                    GridViewColumnFormatting(searchDS);

                }
                else
                {
                    DataSet searchDS = (DataSet)Cache["WeekWiseShortageReportCache"];
                    GridView1.DataSource = searchDS;
                    GridView1.DataBind();

                    GridViewColumnFormatting(searchDS);
                }
            }
            catch (Exception ex)
            {
                LogError(ex, "Exception from while searching record based on Order No and Pos!.");
            }
        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            lblMessage.Visible = false;

            DataSet ds = (DataSet)Cache["WeekWiseShortageReportCache"];

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
                LogError(ex, "Exception from while clicking on page number from Week Wise Shortage Report!.");
            }
        }

        private void ShowWeekWiseShortageReport()
        {
            lblMessage.Visible = false;

            try
            {
                DBUtil _DBObj = new DBUtil();
                int week = 0;
                int year = 0;

                if (!string.IsNullOrWhiteSpace(txtWeekNo.Text))
                {
                    if (Convert.ToInt32(txtWeekNo.Text.ToString()) > 41)
                    {
                        lblMessage.Visible = true;
                        lblMessage.ForeColor = System.Drawing.Color.Red;
                        lblMessage.Text = "Week no should not be greater than 41";
                        return;
                    }
                    else
                    {
                        week = Convert.ToInt32(txtWeekNo.Text.ToString());
                    }
                }

                if (!string.IsNullOrWhiteSpace(txtYear.Text))
                {
                    year = Convert.ToInt32(txtYear.Text.ToString());
                }

                DataSet ds = _DBObj.ShowWeekWiseShortageReport(year, week);
                Cache["WeekWiseShortageReportCache"] = ds;

                GridView1.DataSource = ds.Tables[0];
                GridView1.AlternatingRowStyle.HorizontalAlign = HorizontalAlign.Center;
                GridView1.HorizontalAlign = HorizontalAlign.Center;
                GridView1.DataBind();

                GridViewColumnFormatting(ds);
            }
            catch (Exception ex)
            {
                LogError(ex, "Exception from display Week Wise Shortage Report!");
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

        private void GridViewColumnFormatting(DataSet ds)
        {
            if (ds.Tables[1].Rows.Count > 0)
            {
                GridView1.HeaderRow.Cells[6].Text = Convert.ToString(ds.Tables[1].Rows[0]["Week_0"]);
                GridView1.HeaderRow.Cells[7].Text = Convert.ToString(ds.Tables[1].Rows[0]["Week_1"]);
                GridView1.HeaderRow.Cells[8].Text = Convert.ToString(ds.Tables[1].Rows[0]["Week_2"]);
                GridView1.HeaderRow.Cells[9].Text = Convert.ToString(ds.Tables[1].Rows[0]["Week_3"]);
                GridView1.HeaderRow.Cells[10].Text = Convert.ToString(ds.Tables[1].Rows[0]["Week_4"]);
                GridView1.HeaderRow.Cells[11].Text = Convert.ToString(ds.Tables[1].Rows[0]["Week_5"]);
                GridView1.HeaderRow.Cells[12].Text = Convert.ToString(ds.Tables[1].Rows[0]["Week_6"]);
                GridView1.HeaderRow.Cells[13].Text = Convert.ToString(ds.Tables[1].Rows[0]["Week_7"]);
                GridView1.HeaderRow.Cells[14].Text = Convert.ToString(ds.Tables[1].Rows[0]["Week_8"]);
                GridView1.HeaderRow.Cells[15].Text = Convert.ToString(ds.Tables[1].Rows[0]["Week_9"]);
                GridView1.HeaderRow.Cells[16].Text = Convert.ToString(ds.Tables[1].Rows[0]["Week_10"]);
                GridView1.HeaderRow.Cells[17].Text = Convert.ToString(ds.Tables[1].Rows[0]["Week_11"]);
                GridView1.HeaderRow.Cells[18].Text = Convert.ToString(ds.Tables[1].Rows[0]["Week_12"]);
                GridView1.HeaderRow.Cells[19].Text = Convert.ToString(ds.Tables[1].Rows[0]["Week_n"]);
            }
        }

        protected void btnExcelExport_Click(object sender, EventArgs e)
        {
            string query = string.Empty;
            string str = string.Empty;
            DBUtil _DBObj = new DBUtil();

            try
            {
                DataSet ds = (DataSet)Cache["WeekWiseShortageReportCache"];

                DataTable dt = ds.Tables[0];

                if (ds.Tables[1].Rows.Count > 0)
                {
                    dt.Columns["w0"].ColumnName = Convert.ToString(ds.Tables[1].Rows[0]["Week_0"]);
                    dt.Columns["w1"].ColumnName = Convert.ToString(ds.Tables[1].Rows[0]["Week_1"]);
                    dt.Columns["w2"].ColumnName = Convert.ToString(ds.Tables[1].Rows[0]["Week_2"]);
                    dt.Columns["w3"].ColumnName = Convert.ToString(ds.Tables[1].Rows[0]["Week_3"]);
                    dt.Columns["w4"].ColumnName = Convert.ToString(ds.Tables[1].Rows[0]["Week_4"]);
                    dt.Columns["w5"].ColumnName = Convert.ToString(ds.Tables[1].Rows[0]["Week_5"]);
                    dt.Columns["w6"].ColumnName = Convert.ToString(ds.Tables[1].Rows[0]["Week_6"]);
                    dt.Columns["w7"].ColumnName = Convert.ToString(ds.Tables[1].Rows[0]["Week_7"]);
                    dt.Columns["w8"].ColumnName = Convert.ToString(ds.Tables[1].Rows[0]["Week_8"]);

                    dt.Columns["w9"].ColumnName = Convert.ToString(ds.Tables[1].Rows[0]["Week_9"]);
                    dt.Columns["w10"].ColumnName = Convert.ToString(ds.Tables[1].Rows[0]["Week_10"]);
                    dt.Columns["w11"].ColumnName = Convert.ToString(ds.Tables[1].Rows[0]["Week_11"]);
                    dt.Columns["w12"].ColumnName = Convert.ToString(ds.Tables[1].Rows[0]["Week_12"]);

                    dt.Columns["wn"].ColumnName = Convert.ToString(ds.Tables[1].Rows[0]["Week_n"]);
                }

                if (dt.Rows.Count > 0)
                {
                    Response.ClearContent();
                    Response.Buffer = true;
                    Response.AddHeader("content-disposition", string.Format("attachment; filename={0}", "WeekWiseShortageReport.xls"));
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
            }
            catch (Exception ex)
            {
                Helper.LogError(ex, "Exception from export button click from Week Wise Shortage Report!");
            }
        }

        protected void btnSearchBox1_Click(object sender, EventArgs e)
        {
            lblMessage.Visible = false;

            if (string.IsNullOrWhiteSpace(txtWeekNo.Text) || string.IsNullOrWhiteSpace(txtYear.Text))
            {
                lblMessage.Visible = true;
                lblMessage.ForeColor = System.Drawing.Color.Red;
                lblMessage.Text = "Please enter a starting year and week no, to proceed further.";

                return;
            }
            else
            {
                ShowWeekWiseShortageReport();
            }
        }
    }
}