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
    public partial class ViewWIPDates : System.Web.UI.Page
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

            if (!Page.IsPostBack)
            {
                ShowWIPGrid();
            }

            System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-IN");
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
            //try
            //{
            //    Label lbProdOrderNo = (Label)GridView2.Rows[e.RowIndex].FindControl("lblProdOrderNo");
            //    Label lbItemNumber = (Label)GridView2.Rows[e.RowIndex].FindControl("lblItemNumber");
            //    Label lblBuyer = (Label)GridView2.Rows[e.RowIndex].FindControl("lblBuyer");
            //    Label lblRemarks = (Label)GridView2.Rows[e.RowIndex].FindControl("lblRemarks");
            //    TextBox txtRecDate = (TextBox)GridView2.Rows[e.RowIndex].FindControl("txtRecDate");

            //    DBUtil _dbObj = new DBUtil();
            //    _dbObj.UpdateWIPRecDate(lbProdOrderNo.Text.Trim(), lbItemNumber.Text.Trim(), txtRecDate.Text.Trim(), lblBuyer.Text.Trim(), lblRemarks.Text.Trim());

            //    GridView2.EditIndex = -1;
            //    ShowWIPGrid();
            //}
            //catch (Exception ex)
            //{
            //    LogError(ex, "Exception from while updating row from WIP Upload Items.");
            //}
        }

        protected void GridView2_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            //lblConfirm.Text = "";
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
                //string pageSize = ConfigurationManager.AppSettings["GridPageSize"].ToString();

                DBUtil _DBObj = new DBUtil();
                DataSet ds = _DBObj.RetriveByWIPUploadItems();

                Cache["CacheFromWIPUploadItems"] = ds;

                //GridView2.PageSize = Convert.ToInt32(pageSize);
                GridView2.DataSource = ds;
                GridView2.DataBind();
                //Multiview1.ActiveViewIndex = 1;
            }
            catch (Exception ex)
            {
                LogError(ex, "Exception from Upload WIP button click!");
            }
        }

        protected void btnDisplayWIPUploadItems_ServerClick(object sender, EventArgs e)
        {
            ShowWIPGrid();
        }

        //protected void btnWIPBulkUpdate_ServerClick(object sender, EventArgs e)
        //{
        //    DBUtil _DBObj = new DBUtil();
        //    DataSet ds;

        //    try
        //    {
        //        foreach (GridViewRow row in GridView2.Rows)
        //        {
        //            ds = new DataSet();
        //            ds = _DBObj.RetrieveWIPData();
        //            Cache["CacheFromWIPUploadItems"] = ds;

        //            bool isChecked = ((CheckBox)row.FindControl("chkSelect")).Checked;
        //            if (isChecked)
        //            {
        //                String OrderNo = ((System.Web.UI.HtmlControls.HtmlInputHidden)row.FindControl("hidProdOrder")).Value.ToString();
        //                String lblProdOrderNo = ((Label)row.FindControl("lblProdOrderNo")).Text.ToString();
        //                String lblItemNumber = ((Label)row.FindControl("lblItemNumber")).Text.ToString();
        //                string RecDate = ((TextBox)row.FindControl("txtRecDate")).Text.ToString();
        //                string Buyer = ((Label)row.FindControl("lblBuyer")).Text.ToString();
        //                string Remarks = ((Label)row.FindControl("lblRemarks")).Text.ToString();

        //                DBUtil _dbObj = new DBUtil();
        //                string wipRecDate = string.Empty;
        //                string wipBuyer = string.Empty;
        //                string wipRemarks = string.Empty;

        //                if (!string.IsNullOrEmpty(RecDate) && string.IsNullOrEmpty(txtWIPUpdate.Text))
        //                {
        //                    wipRecDate = RecDate;
        //                }
        //                if (string.IsNullOrEmpty(RecDate) && !string.IsNullOrEmpty(txtWIPUpdate.Text))
        //                {
        //                    wipRecDate = txtWIPUpdate.Text;
        //                }
        //                if (!string.IsNullOrEmpty(RecDate) && !string.IsNullOrEmpty(txtWIPUpdate.Text))
        //                {
        //                    wipRecDate = txtWIPUpdate.Text;
        //                }
        //                if (string.IsNullOrEmpty(RecDate) && string.IsNullOrEmpty(txtWIPUpdate.Text))
        //                {
        //                    wipRecDate = txtWIPUpdate.Text;
        //                }
        //                if (!string.IsNullOrEmpty(txtBuyer.Text) && string.IsNullOrEmpty(txtRemarks.Text))
        //                {
        //                    wipBuyer = txtBuyer.Text.Trim();
        //                    wipRemarks = Remarks;
        //                }
        //                if (string.IsNullOrEmpty(txtBuyer.Text) && !string.IsNullOrEmpty(txtRemarks.Text))
        //                {
        //                    wipRemarks = txtRemarks.Text.Trim();
        //                    wipBuyer = Buyer;
        //                }
        //                if (!string.IsNullOrEmpty(txtBuyer.Text) && !string.IsNullOrEmpty(txtRemarks.Text))
        //                {
        //                    wipRemarks = txtRemarks.Text.Trim();
        //                    wipBuyer = txtRemarks.Text.Trim();
        //                }
        //                if (string.IsNullOrEmpty(txtBuyer.Text) && string.IsNullOrEmpty(txtRemarks.Text))
        //                {
        //                    wipRemarks = Remarks;
        //                    wipBuyer = Buyer;
        //                }

        //                if (!string.IsNullOrEmpty(txtWIPUpdate.Text.Trim()) || !string.IsNullOrEmpty(txtBuyer.Text.Trim()) || !string.IsNullOrEmpty(txtRemarks.Text.Trim()))
        //                {
        //                    if (!string.IsNullOrEmpty(txtWIPUpdate.Text.Trim()))
        //                    {
        //                        _dbObj.InsertWIPRecDateHistory(lblProdOrderNo.Trim(), lblItemNumber.Trim(), RecDate.Trim(), Buyer.Trim(), Remarks.Trim());
        //                    }
        //                    _dbObj.UpdateWIPRecDate(lblProdOrderNo.Trim(), lblItemNumber.Trim(), wipRecDate.Trim(), wipBuyer.Trim(), wipRemarks.Trim());
        //                }

        //                lblConfirm.Text = "WIP Rec Date's Updated Successfully.";
        //                lblConfirm.Attributes.Add("style", "color:green");
        //            }
        //        }

        //        ShowWIPGrid();
        //    }
        //    catch (Exception ex)
        //    {
        //        LogError(ex, "Exception occured while bulk updating wip rec date.");
        //    }
        //    finally
        //    {
        //        txtWIPUpdate.Text = "";
        //        txtBuyer.Text = "";
        //        txtRemarks.Text = "";
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

        protected void RadioButtonListForWIP_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                DBUtil _DBObj = new DBUtil();
                string dates = string.Empty;

                int radioSelection = RadioButtonListForWIP.SelectedIndex;

                DataSet ds = _DBObj.RetriveByViewWIPDates(radioSelection);

                if (radioSelection == 0)
                {
                    GridView2.Columns[11].ItemStyle.ForeColor = System.Drawing.Color.Black;
                    GridView2.Columns[11].ItemStyle.BackColor = System.Drawing.Color.White;
                }
                else if (radioSelection == 1)
                {
                    GridView2.Columns[11].ItemStyle.ForeColor = System.Drawing.Color.Black;
                    GridView2.Columns[11].ItemStyle.BackColor = System.Drawing.Color.White;
                }
                else if (radioSelection == 2)
                {
                    GridView2.Columns[11].ItemStyle.Font.Bold = true;
                    GridView2.Columns[11].ItemStyle.BackColor = System.Drawing.Color.Red;
                }
                else if (radioSelection == 3)
                {
                    GridView2.Columns[11].ItemStyle.Font.Bold = true;
                    GridView2.Columns[11].ItemStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#ffbf00");
                }
                else if (radioSelection == 4)
                {
                    GridView2.Columns[11].ItemStyle.Font.Bold = true;
                    GridView2.Columns[11].ItemStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#98FB98");
                }

                Cache["CacheFromWIPUploadItems"] = ds;

                GridView2.DataSource = ds;
                GridView2.DataBind();
            }
            catch (Exception ex)
            {
                LogError(ex, "Exception from on selection of WIP Radio button!");
            }
        }

        protected void ExcelExport_Click(object sender, ImageClickEventArgs e)
        {
            string query = string.Empty;
            DBUtil _DBObj = new DBUtil();
            string str = string.Empty;

            try
            {
                DataSet ds = _DBObj.RetriveByWIPUploadItems();
                DataTable dt = ds.Tables[0];

                if (dt.Rows.Count > 0)
                {
                    Response.ClearContent();
                    Response.Buffer = true;
                    Response.AddHeader("content-disposition", string.Format("attachment; filename={0}", "WIPRecDates.xls"));
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
                LogError(ex, "Exception from export button click from WIP view RecDates!");
            }
            finally
            {
            }
        }

        protected void GridView2_Sorting(object sender, GridViewSortEventArgs e)
        {
            string sortingDirection = string.Empty;
            DataSet ds = (DataSet)Cache["CacheFromWIPUploadItems"];

            if (dir == SortDirection.Ascending)
            {
                dir = SortDirection.Descending;
                sortingDirection = "Desc";
            }
            else
            {
                dir = SortDirection.Ascending;
                sortingDirection = "Asc";
            }

            DataView sortedView = new DataView(ds.Tables[0]);
            sortedView.Sort = e.SortExpression + " " + sortingDirection;
            GridView2.DataSource = sortedView;
            GridView2.DataBind();
        }

        public SortDirection dir
        {
            get
            {
                if (ViewState["dirState"] == null)
                {
                    ViewState["dirState"] = SortDirection.Ascending;
                }
                return (SortDirection)ViewState["dirState"];
            }
            set
            {
                ViewState["dirState"] = value;
            }
        }

        protected void ImageButton3_Click(object sender, ImageClickEventArgs e)
        {
            string query = string.Empty;
            DBUtil _DBObj = new DBUtil();
            string str = string.Empty;

            try
            {
                DataSet ds = _DBObj.RetriveByWIPUploadItems();
                DataTable dt = ds.Tables[0];

                if (dt.Rows.Count > 0)
                {
                    Response.ClearContent();
                    Response.Buffer = true;
                    Response.AddHeader("content-disposition", string.Format("attachment; filename={0}", "WIPRecDatesHistory.xls"));
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
                LogError(ex, "Exception from export button click from WIP view RecDates History!");
            }
            finally
            {
            }
        }

        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            string query = string.Empty;
            DBUtil _DBObj = new DBUtil();
            string str = string.Empty;
            string radioSelectionName = string.Empty;

            try
            {
                int radioSelection = RadioButtonListForWIP.SelectedIndex;

                if (radioSelection == 0)
                {
                    radioSelectionName = "All";
                }
                else if (radioSelection == 1)
                {
                    radioSelectionName = "Blank";
                }
                else if (radioSelection == 2)
                {
                    radioSelectionName = "PastDates";
                }
                else if (radioSelection == 3)
                {
                    radioSelectionName = "CurrentMonth";
                }
                else if (radioSelection == 4)
                {
                    radioSelectionName = "FutureDates";
                }

                DataSet ds = _DBObj.RetriveByViewWIPDates(radioSelection);
                DataTable dt = ds.Tables[0];

                if (dt.Rows.Count > 0)
                {
                    Response.ClearContent();
                    Response.Buffer = true;
                    Response.AddHeader("content-disposition", string.Format("attachment; filename={0}", "WIPRecDates"+ radioSelectionName +".xls"));
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
                LogError(ex, "Exception from export button click from WIP view RecDates History!");
            }
            finally
            {
            }
        }

        //protected void btnSearchBox_Click(object sender, EventArgs e)
        //{
        //    String searchRowFilter = String.Empty, searchRowFilter1 = String.Empty, searchRowFilter2 = String.Empty, searchRowFilter3 = String.Empty, searchRowFilter4 = String.Empty;

        //    BulkUpdateWIP.Visible = true;

        //    string ProdOrder = txtProdOrder.Text.Trim();
        //    string ItemNumber = txtItemNumber.Text.Trim();
        //    string Buyers = txtBuyers.Text.Trim();
        //    string SupplierName = txtSupplierName.Text.Trim();

        //    if (!string.IsNullOrEmpty(ProdOrder))
        //    {
        //        searchRowFilter1 = "ProdOrder = '" + ProdOrder + "'";
        //    }
        //    if (!string.IsNullOrEmpty(ItemNumber))
        //    {
        //        searchRowFilter2 = "ItemNumber = '" + ItemNumber + "'";
        //    }
        //    if (!string.IsNullOrEmpty(Buyers))
        //    {
        //        searchRowFilter3 = "Buyer = '" + Buyers + "'";
        //    }
        //    if (!string.IsNullOrEmpty(SupplierName))
        //    {
        //        searchRowFilter4 = "SupplierName = '" + SupplierName + "'";
        //    }

        //    if (!String.IsNullOrEmpty(searchRowFilter1))
        //        searchRowFilter = searchRowFilter1;

        //    if (!String.IsNullOrEmpty(searchRowFilter2))
        //    {
        //        if (!String.IsNullOrEmpty(searchRowFilter))
        //            searchRowFilter = searchRowFilter + " AND " + searchRowFilter2;
        //        else
        //            searchRowFilter = searchRowFilter2;
        //    }

        //    if (!String.IsNullOrEmpty(searchRowFilter3))
        //    {
        //        if (!String.IsNullOrEmpty(searchRowFilter))
        //            searchRowFilter = searchRowFilter + " AND " + searchRowFilter3;
        //        else
        //            searchRowFilter = searchRowFilter3;
        //    }

        //    if (!String.IsNullOrEmpty(searchRowFilter4))
        //    {
        //        if (!String.IsNullOrEmpty(searchRowFilter))
        //            searchRowFilter = searchRowFilter + " AND " + searchRowFilter4;
        //        else
        //            searchRowFilter = searchRowFilter4;
        //    }

        //    if (!String.IsNullOrEmpty(searchRowFilter))
        //    {
        //        DataSet searchDS = (DataSet)Cache["CacheFromWIPUploadItems"];

        //        DataView dv;
        //        dv = searchDS.Tables[0].DefaultView;

        //        dv.RowFilter = searchRowFilter;

        //        GridView2.DataSource = dv;
        //        GridView2.DataBind();
        //    }
        //    else
        //    {
        //        DataSet searchDS = (DataSet)Cache["CacheFromWIPUploadItems"];
        //        GridView2.DataSource = searchDS;
        //        GridView2.DataBind();
        //    }
        //}
    }
}