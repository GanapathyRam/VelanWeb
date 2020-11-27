using Libraries.Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace VV
{
    public partial class FgToWipReversal : System.Web.UI.Page
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
            #endregion

            # endregion

            System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-IN");

            if (!Page.IsPostBack)
            {
                //DBUtil _dbObj = new DBUtil();   

                //DataSet ds = _dbObj.RetrieveWIPData();

                //grdViewWIPResult.DataSource = ds;
                //grdViewWIPResult.DataBind();

                //Cache["WIPDataFromDBCache"] = ds;
            }
        }

        protected void grdViewWIPResult_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            DataSet ds = (DataSet)Cache["FGFromWIPReversalCache"];

            grdViewWIPResult.PageIndex = e.NewPageIndex;
            grdViewWIPResult.DataSource = ds;
            grdViewWIPResult.DataBind();

            try
            {
                String ProdOrderNo_Search = txtProdOrderNo.Text.Trim();
                String SalesOrderNo_Search = txtSalesOrderNo.Text.Trim();

                String searchRowFilter = String.Empty, searchRowFilter1 = String.Empty, searchRowFilter2 = String.Empty;

                if (!String.IsNullOrEmpty(ProdOrderNo_Search))
                {
                    searchRowFilter1 = "ProdOrderNo = '" + ProdOrderNo_Search + "'";
                }

                if (!String.IsNullOrEmpty(SalesOrderNo_Search))
                {
                    searchRowFilter2 = "OrderNo = '" + SalesOrderNo_Search + "'";
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
                    DataView dv;
                    dv = ds.Tables[0].DefaultView;

                    dv.RowFilter = searchRowFilter;

                    grdViewWIPResult.DataSource = dv;
                    grdViewWIPResult.DataBind();
                }
            }

            catch (Exception ex)
            {
                Microsoft.Practices.EnterpriseLibrary.Logging.Logger.Write(this.GetType().ToString() + " : View WIP To FG - When trying to do a Paging : " + " : " + DateTime.Now + " : " + ex.Message.ToString(), Category.General, Priority.Highest);
                throw ex;
            }
        }

        protected void btnSearchBox_Click(object sender, EventArgs e)
        {
            try
            {
                String ProdOrderNo_Search = txtProdOrderNo.Text.Trim();
                String SalesOrderNo_Search = txtSalesOrderNo.Text.Trim();

                String searchRowFilter = String.Empty, searchRowFilter1 = String.Empty, searchRowFilter2 = String.Empty;

                if (!String.IsNullOrEmpty(ProdOrderNo_Search))
                {
                    searchRowFilter1 = "ProdOrderNo = '" + ProdOrderNo_Search + "'";
                }

                if (!String.IsNullOrEmpty(SalesOrderNo_Search))
                {
                    searchRowFilter2 = "OrderNo = '" + SalesOrderNo_Search + "'";
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
                    DataSet searchDS = (DataSet)Cache["FGFromWIPReversalCache"];

                    DataView dv;
                    dv = searchDS.Tables[0].DefaultView;

                    dv.RowFilter = searchRowFilter;

                    grdViewWIPResult.DataSource = dv;
                    grdViewWIPResult.DataBind();
                }
                else
                {
                    DataSet searchDS = (DataSet)Cache["FGFromWIPReversalCache"];
                    grdViewWIPResult.DataSource = searchDS;
                    grdViewWIPResult.DataBind();
                }
            }
            catch (Exception ex)
            {
                Microsoft.Practices.EnterpriseLibrary.Logging.Logger.Write(this.GetType().ToString() + " : btnSearchBox_Click : " + " : " + DateTime.Now + " : " + ex.Message.ToString(), Category.General, Priority.Highest);
                throw ex;
            }

        }

        protected void btnConvert_Click(object sender, EventArgs e)
        {
            // DataSet ds = (DataSet)Cache["WIPDataFromDBCache"];
            DBUtil _DBObj = new DBUtil();
            DataSet ds;

            foreach (GridViewRow row in grdViewWIPResult.Rows)
            {
                ds = new DataSet();
                ds = _DBObj.RetrieveWIPData();
                Cache["FGFromWIPReversalCache"] = ds;

                bool isChecked = ((CheckBox)row.FindControl("chkSelect")).Checked;
                if (isChecked)
                {
                    String OrderNo = ((System.Web.UI.HtmlControls.HtmlInputHidden)row.FindControl("hidOrderNo")).Value.ToString();
                    String LineNum = ((Label)row.FindControl("lblLineNum")).Text.ToString();
                    String Pos = ((Label)row.FindControl("lblPos")).Text.ToString();
                    String SerialNo = ((Label)row.FindControl("lblSerialNo")).Text.ToString();
                    String ProdOrderNo = ((Label)row.FindControl("lblProdOrderNo")).Text.ToString();

                    String OrderType = ((Label)row.FindControl("lblType")).Text.ToString();

                    int WIPQty = 0, FGQty = 0, ProdBalQty = 0;

                    if (ds != null)
                    {
                        DataRow[] dr = ds.Tables[0].Select("OrderNo = '" + OrderNo + "' And LineNum = '" + LineNum + "' AND Pos = '" + Pos + "' AND SerialNo = '" + SerialNo + "' AND ProdOrderNo = '" + ProdOrderNo + "'");

                        if (dr.Length > 0)
                        {
                            if (!String.IsNullOrEmpty(dr[0]["WIPQty"].ToString().Trim()))
                                WIPQty = Int32.Parse(dr[0]["WIPQty"].ToString().Trim());

                            if (!String.IsNullOrEmpty(dr[0]["FGQty"].ToString().Trim()))
                                FGQty = Int32.Parse(dr[0]["FGQty"].ToString().Trim());

                            if (!String.IsNullOrEmpty(dr[0]["ProdBalanceQty"].ToString().Trim()))
                                ProdBalQty = Int32.Parse(dr[0]["ProdBalanceQty"].ToString().Trim());
                        }
                    }

                    WIPQty = WIPQty - 1;
                    FGQty = FGQty + 1;
                    ProdBalQty = ProdBalQty - 1;

                    _DBObj.UpdateQtyInMISOrderStatusTableForWIPToFG(OrderType.Trim(), OrderNo.Trim(), LineNum.Trim(), Int32.Parse(Pos.Trim()), FGQty, WIPQty);

                    _DBObj.UpdateBalanceQtyInProdOrderReleaseTableForWIPToFG(OrderNo.Trim(), LineNum.Trim(), Int32.Parse(Pos.Trim()), ProdOrderNo.Trim(), SerialNo.Trim(), ProdBalQty);

                    //  btnConvert.Enabled = false;

                    //lblMessage.Text = "Updated Successfully";
                }
            }

            ds = _DBObj.RetrieveWIPData();

            grdViewWIPResult.DataSource = ds;
            grdViewWIPResult.DataBind();

            Cache["FGFromWIPReversalCache"] = ds;
        }

        protected void btnRemPagination_Click(object sender, EventArgs e)
        {
            String ProdOrderNo_Search = txtProdOrderNo.Text.Trim();
            String SalesOrderNo_Search = txtSalesOrderNo.Text.Trim();

            String searchRowFilter = String.Empty, searchRowFilter1 = String.Empty, searchRowFilter2 = String.Empty;

            if (!String.IsNullOrEmpty(ProdOrderNo_Search))
            {
                searchRowFilter1 = "ProdOrderNo = '" + ProdOrderNo_Search + "'";
            }

            if (!String.IsNullOrEmpty(SalesOrderNo_Search))
            {
                searchRowFilter2 = "OrderNo = '" + SalesOrderNo_Search + "'";
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
                DataSet searchDS = (DataSet)Cache["FGFromWIPReversalCache"];

                DataView dv;
                dv = searchDS.Tables[0].DefaultView;

                dv.RowFilter = searchRowFilter;

                grdViewWIPResult.AllowPaging = false;
                grdViewWIPResult.DataSource = dv;
                grdViewWIPResult.DataBind();
            }
            else
            {
                grdViewWIPResult.AllowPaging = false;
                DataSet searchDS = (DataSet)Cache["FGFromWIPReversalCache"];
                grdViewWIPResult.DataSource = searchDS;
                grdViewWIPResult.DataBind();
            }
        }

        protected void btnClear_Click(object sender, EventArgs e)
        {

        }

        protected void btn_Search_Click(object sender, EventArgs e)
        {
            try
            {
                DBUtil _dbObj = new DBUtil();
                lblMessage.Visible = false;

                string OrderNo = txtOrderNumber.Text.Trim();
                string Pos = txtPosition.Text.Trim();
                int Flag = 0; // To get the list of rows 

                DataSet ds = _dbObj.RetrieveFGToWIReversalItems(OrderNo, Convert.ToInt32(Pos), Flag);

                grdViewWIPResult.DataSource = ds;
                grdViewWIPResult.DataBind();

                Cache["FGFromWIPReversalCache"] = ds;
                //WIPDataFromDBCache
            }
            catch (Exception ex)
            {
                LogError(ex, "Exception from display grid view details!");
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

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            DBUtil _DBObj = new DBUtil();
            lblMessage.Visible = false;
            int totalFGCount = 0;
            int selectedRowFGCount = 0;

            try
            {
                string OrderNo = txtOrderNumber.Text;
                string Pos = txtPosition.Text;

                DataSet GetFGTotalQtyCount = _DBObj.RetrieveFGToWIReversalItems(OrderNo, Convert.ToInt32(Pos), 1);

                if (GetFGTotalQtyCount.Tables[0].Rows.Count > 0)
                {
                    totalFGCount = Convert.ToInt32(GetFGTotalQtyCount.Tables[0].Rows[0]["TotalFGQty"].ToString());
                }

                if (totalFGCount == 0)
                {
                    lblMessage.Text = "Please try again with other order no and pos.";
                    lblMessage.Visible = true;
                    return;
                }

                foreach (GridViewRow row in grdViewWIPResult.Rows)
                {
                    bool isChecked = ((CheckBox)row.FindControl("chkSelect")).Checked;
                    if (isChecked)
                    {
                        selectedRowFGCount = selectedRowFGCount + 1;
                    }
                }


                foreach (GridViewRow row in grdViewWIPResult.Rows)
                {
                    bool isChecked = ((CheckBox)row.FindControl("chkSelect")).Checked;
                    if (isChecked)
                    {
                        string lblOrderNo = ((Label)row.FindControl("lblOrderNo")).Text.ToString();
                        string lblPos = ((Label)row.FindControl("lblPos")).Text.ToString();
                        string lblFgQty = ((Label)row.FindControl("lblFGQty")).Text.ToString();
                        string lblSerialNo = ((Label)row.FindControl("lblSerialNo")).Text.ToString();

                        if (totalFGCount >= selectedRowFGCount)
                        {
                            _DBObj.UpdateFGToWIReversalItems(lblOrderNo, Convert.ToInt32(lblPos), lblSerialNo);

                            lblMessage.Text = "Updated Successfully.";
                            lblMessage.Visible = true;
                        }
                        else
                        {
                            lblMessage.Text = "Invalid Input Qty";
                            lblMessage.Visible = true;
                            return;
                        }

                    }
                }

                DataSet ds = _DBObj.RetrieveFGToWIReversalItems(OrderNo, Convert.ToInt32(Pos), 0);

                grdViewWIPResult.DataSource = ds;
                grdViewWIPResult.DataBind();

                Cache["FGFromWIPReversalCache"] = ds;

            }
            catch (Exception ex)
            {
                LogError(ex, "Exception from while updating row from Sale Order Line Item Deletion.");
            }
        }
    }
}