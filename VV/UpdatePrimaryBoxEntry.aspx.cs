using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace VV
{
    public partial class UpdatePrimaryBoxEntry : System.Web.UI.Page
    {
        DataSet ds = new DataSet();
        DBUtil _dbObj = new DBUtil();
        string orderNo, lineNo, proOrderNo, item = string.Empty;
        int pos = 0;
        int ValveBoxQty = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            orderNo = Request.QueryString["OrderNo"].ToString();
            pos = Convert.ToInt32(Request.QueryString["Pos"].ToString());
            proOrderNo = Request.QueryString["ProdOrderNo"].ToString();
            item = Request.QueryString["Item"].ToString();

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
                    else if (MenuID == 13) // Box Enquiry
                        tbstr.Items[ParentMenuID].ChildItems[5].Enabled = true;
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

            if (!Page.IsPostBack)
            {
                //lblMessage.Visible = false;

                txtProdOrderNoLabel.Text = proOrderNo;
                txtItemLabel.Text = item;
                txtSoNoLabel.Text = orderNo;
                txtPosLabel.Text = Convert.ToString(pos);

            }
        }

        protected void btnSearchBox_Click(object sender, EventArgs e)
        {
            lblMessage.Visible = false;

            if (!string.IsNullOrEmpty(txtPackingQtyInput.Text) && !string.IsNullOrEmpty(txtNumberOfBoxes.Text))
            {
                var packingQty = Convert.ToInt32(txtPackingQtyInput.Text.Trim());
                var noOfBoxes = Convert.ToInt32(txtNumberOfBoxes.Text.Trim());

                orderNo = Request.QueryString["OrderNo"].ToString();
                pos = Convert.ToInt32(Request.QueryString["Pos"].ToString());
                proOrderNo = Request.QueryString["ProdOrderNo"].ToString();

                ValveBoxQty = string.IsNullOrEmpty(Request.QueryString["ValveBoxQty"].ToString()) ? 0 : Convert.ToInt32(Request.QueryString["ValveBoxQty"].ToString());

                DataSet ds = _dbObj.FetchPrimaryBoxEntryFromProdNoAndOrderNo(proOrderNo, orderNo, pos);

                if (ds != null && ds.Tables.Count > 0)
                {
                    var BodyHeatNo = ds.Tables[0].Rows[0]["BodyHeatNo"].ToString();
                    var BonnetHeatNo = ds.Tables[0].Rows[0]["BonnetHeatNo"].ToString();
                    var DrgNo = "";
                    var TagNo = "";
                    int prodReleaseQty = Convert.ToInt32(ds.Tables[0].Rows[0]["ProdReleaseQty"].ToString());

                    BindGrid(packingQty, noOfBoxes, proOrderNo, BodyHeatNo, BonnetHeatNo, DrgNo, TagNo, ValveBoxQty, prodReleaseQty);

                    //TemplateColumn tc = new TemplateColumn();

                    //GridView1.AutoGenerateColumns = false;
                    //tc.ItemTemplate = new CreateItemTemplateTextBox1("testb", "test");
                    //this.GridView1.Columns.Add(tc);

                    //loadDynamicGrid(packingQty, noOfBoxes, BodyHeatNo, BonnetHeatNo, DrgNo, TagNo, ValveBoxQty);
                }
            }
        }

        private void loadDynamicGrid(int packingQty, int noOfBoxes, string BodyHeatNo, string BonnetHeatNo, string DrgNo, string TagNo, int ValveBoxQty)
        {

            #region Code for preparing the DataTable

            //Create an instance of DataTable
            DataTable dt = new DataTable();

            //Create an ID column for adding to the Datatable
            DataColumn dcol = new DataColumn("Primary Box No", typeof(System.String));
            //dcol.AutoIncrement = true;
            dt.Columns.Add(dcol);

            //Create an ID column for adding to the Datatable
            dcol = new DataColumn("Body Heat No", typeof(System.String));
            dt.Columns.Add(dcol);

            dcol = new DataColumn("Bonnet Heat No", typeof(System.String));
            dt.Columns.Add(dcol);

            dcol = new DataColumn("Valve Box Qty", typeof(System.String));
            dt.Columns.Add(dcol);

            dcol = new DataColumn("Drg No", typeof(System.String));
            dt.Columns.Add(dcol);

            dcol = new DataColumn("Tag No", typeof(System.String));
            dt.Columns.Add(dcol);

            string primaryBoxNo = string.Empty;
            string recentBoxNo = string.Empty;

            var currentYear = Convert.ToString(DateTime.UtcNow.Year).Substring(2, 2);

            //Now add data for dynamic columns
            //As the first column is auto-increment, we do not have to add any thing.
            //Let's add some data to the second column.
            for (int nIndex = 0; nIndex < noOfBoxes; nIndex++)
            {
                var getSavedPrimaryBoxNo = _dbObj.GetPrimaryBoxNo();

                if (!string.IsNullOrEmpty(getSavedPrimaryBoxNo))
                {
                    recentBoxNo = getSavedPrimaryBoxNo.Substring(3);

                    primaryBoxNo = "P" + currentYear + (Convert.ToInt32(recentBoxNo) + 1);
                }
                else
                {
                    if (!string.IsNullOrEmpty(primaryBoxNo))
                    {
                        recentBoxNo = primaryBoxNo.Substring(3);

                        primaryBoxNo = "P" + currentYear + (Convert.ToInt32(recentBoxNo) + 1);
                    }
                    else
                    {
                        primaryBoxNo = "P" + currentYear + "1";
                    }
                }

                //Create a new row
                DataRow drow = dt.NewRow();

                drow["Primary Box No"] = primaryBoxNo;

                //Initialize the row data.
                drow["Body Heat No"] = BodyHeatNo;

                drow["Bonnet Heat No"] = BonnetHeatNo;

                drow["Valve Box Qty"] = ValveBoxQty;

                drow["Drg No"] = DrgNo;

                drow["Tag No"] = TagNo;

                //Add the row to the datatable.
                dt.Rows.Add(drow);
            }
            #endregion

            //Iterate through the columns of the datatable to set the data bound field dynamically.
            //foreach (DataColumn col in dt.Columns)
            //{
            //    //Declare the bound field and allocate memory for the bound field.
            //    BoundField bfield = new BoundField();

            //    //Initalize the DataField value.
            //    bfield.DataField = col.ColumnName;

            //    //Initialize the HeaderText field value.
            //    bfield.HeaderText = col.ColumnName;

            //    //Add the newly created bound field to the GridView.
            //    GridView1.Columns.Add(bfield);
            //}
            DataSet ds = new DataSet();

            ds.Tables.Add(dt);

            //Initialize the DataSource
            //GridView1.DataSource = ds;

            TemplateField temp1 = new TemplateField();  //Create instance of Template field
            temp1.HeaderText = "Primary Box No"; //Give the header text
            temp1.ItemTemplate = new DynamicTemplateField("", "");
            GridView1.Columns.Add(temp1);

            TemplateField temp2 = new TemplateField();  //Create instance of Template field
            temp2.HeaderText = "Body Heat No"; //Give the header text
            temp2.ItemTemplate = new DynamicTemplateField("", "");
            GridView1.Columns.Add(temp2);

            TemplateField temp3 = new TemplateField();  //Create instance of Template field
            temp3.HeaderText = "Bonnet Heat No"; //Give the header text
            temp3.ItemTemplate = new DynamicTemplateField("", "");
            GridView1.Columns.Add(temp3);

            TemplateField temp4 = new TemplateField();  //Create instance of Template field
            temp4.HeaderText = "Valve Box Qty"; //Give the header text
            temp4.ItemTemplate = new DynamicTemplateField("", "");
            GridView1.Columns.Add(temp4);

            TemplateField temp5 = new TemplateField();  //Create instance of Template field
            temp5.HeaderText = "Drg No"; //Give the header text
            temp5.ItemTemplate = new DynamicTemplateField("", "");
            GridView1.Columns.Add(temp5);

            TemplateField temp6 = new TemplateField();  //Create instance of Template field
            temp6.HeaderText = "Tag No"; //Give the header text
            temp6.ItemTemplate = new DynamicTemplateField("", "");
            GridView1.Columns.Add(temp6);

            Cache["ImportedBaanFromDBCache"] = ds;

            GridView1.DataSource = ds;
            //Bind the datatable with the GridView.
            GridView1.DataBind();
        }

        public class DynamicTemplateField : ITemplate
        {
            private string columnNameBinding;
            private string columnname;

            public DynamicTemplateField(string colname, string colNameBinding)
            {
                columnNameBinding = colNameBinding;
                columnname = colname;
            }
            public void InstantiateIn(Control container)
            {
                TextBox tb = new TextBox();
                tb.ID = "txtDynamic" + columnNameBinding;
                tb.Text = columnname;//here to set the value of textbox
                container.Controls.Add(tb);
            }
        }

        protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            //Reset the edit index.
            GridView1.EditIndex = -1;
            //Bind data to the GridView control.
            DataSet ds = (DataSet)Cache["ImportedBaanFromDBCache"];

            GridView1.DataSource = ds.Tables[0];

            //Bind the datatable with the GridView.
            GridView1.DataBind();
        }

        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridView1.EditIndex = e.NewEditIndex;

            DataSet ds = (DataSet)Cache["ImportedBaanFromDBCache"];

            GridView1.DataSource = ds.Tables[0];

            //Bind the datatable with the GridView.
            GridView1.DataBind();

        }

        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            lblMessage.Visible = false;

            try
            {
                //GridViewRow row = GridView1.Rows[e.RowIndex];

                //TextBox PrimaryBoxNo = (TextBox)GridView1.Rows[e.RowIndex].FindControl("Primary Box No");
                //TextBox BodyHeatNo = (TextBox)GridView1.Rows[e.RowIndex].FindControl("Body Heat No");
                //TextBox BonnetHeatNo = (TextBox)GridView1.Rows[e.RowIndex].FindControl("Bonnet Heat No");
                //TextBox ValveBoxQty = (TextBox)GridView1.Rows[e.RowIndex].FindControl("Valve Box Qty");
                //TextBox DrgNo = (TextBox)GridView1.Rows[e.RowIndex].FindControl("Drg No");
                //TextBox TagNo = (TextBox)GridView1.Rows[e.RowIndex].FindControl("Tag No");

                //Retrieve the table from the session object.
                DataSet ds = (DataSet)Cache["ImportedBaanFromDBCache"];

                //Update the values.
                GridViewRow row = GridView1.Rows[e.RowIndex];

                ds.Tables[0].Rows[row.DataItemIndex]["Primary Box No"] = ((TextBox)(row.Cells[1].Controls[0])).Text;
                ds.Tables[0].Rows[row.DataItemIndex]["Body Heat No"] = ((TextBox)(row.Cells[2].Controls[0])).Text;
                ds.Tables[0].Rows[row.DataItemIndex]["Bonnet Heat No"] = ((TextBox)(row.Cells[3].Controls[0])).Text;
                ds.Tables[0].Rows[row.DataItemIndex]["Valve Box Qty"] = ((TextBox)(row.Cells[4].Controls[0])).Text;
                ds.Tables[0].Rows[row.DataItemIndex]["Drg No"] = ((TextBox)(row.Cells[5].Controls[0])).Text;
                ds.Tables[0].Rows[row.DataItemIndex]["Tag No"] = ((TextBox)(row.Cells[6].Controls[0])).Text;

                _dbObj.InsertFromPrimaryBoxNo(Convert.ToString(ds.Tables[0].Rows[row.DataItemIndex]["Primary Box No"]), Convert.ToInt32(txtPackingQtyInput.Text), Convert.ToString(Request.QueryString["ProdOrderNo"].ToString()),
                    Convert.ToString(ds.Tables[0].Rows[row.DataItemIndex]["Body Heat No"]), Convert.ToString(ds.Tables[0].Rows[row.DataItemIndex]["Bonnet Heat No"]), Convert.ToString(ds.Tables[0].Rows[row.DataItemIndex]["Drg No"]),
                    Convert.ToString(ds.Tables[0].Rows[row.DataItemIndex]["Tag No"]));

                //Reset the edit index.
                GridView1.EditIndex = -1;

                lblMessage.Visible = true;
                lblMessage.ForeColor = System.Drawing.Color.Green;
                lblMessage.Text = "Details Updated successfully";

            }
            catch (Exception ex)
            {
                //LogError(ex, "Exception from while updating row from buyer Master.");
            }
        }

        protected void BtnPrint_Click(object sender, EventArgs e)
        {
            //Get the button that raised the event
            Button btn = (Button)sender;

            //Get the row that contains this button
            GridViewRow gvr = (GridViewRow)btn.NamingContainer;

            GridViewRow clickedRow = ((Button)sender).NamingContainer as GridViewRow;

            var primaryBoxNo = ((System.Web.UI.HtmlControls.HtmlInputControl)(clickedRow.FindControl("hidPrimaryBoxNo"))).Value;

            var boxQty = ((System.Web.UI.HtmlControls.HtmlInputControl)(clickedRow.FindControl("hidBoxQty"))).Value;

            //HiddenField hdnDataId = (HiddenField)clickedRow.FindControl("hidPrimaryBoxNo");

            Session["PrimaryBoxNumber"] = Convert.ToString(primaryBoxNo);
            Session["BoxQty"] = Convert.ToString(boxQty);

            //Response.Redirect("~/PrimaryBoxNoForPrint.aspx", false);
        }

        protected void BtnDocPage1_Click(object sender, EventArgs e)
        {
            //Get the button that raised the event
            Button btn = (Button)sender;

            //Get the row that contains this button
            GridViewRow gvr = (GridViewRow)btn.NamingContainer;

            GridViewRow clickedRow = ((Button)sender).NamingContainer as GridViewRow;

            var primaryBoxNo = ((System.Web.UI.HtmlControls.HtmlInputControl)(clickedRow.FindControl("hidPrimaryBoxNoDocPage1"))).Value;

            Session["PrimaryBoxNumber"] = Convert.ToString(primaryBoxNo);

            //Response.Redirect("~/DocPageOne.aspx", false);
        }

        protected void BtnDocPage3_Click(object sender, EventArgs e)
        {
            //Get the button that raised the event
            Button btn = (Button)sender;

            //Get the row that contains this button
            GridViewRow gvr = (GridViewRow)btn.NamingContainer;

            GridViewRow clickedRow = ((Button)sender).NamingContainer as GridViewRow;

            var primaryBoxNo = ((System.Web.UI.HtmlControls.HtmlInputControl)(clickedRow.FindControl("hidPrimaryBoxNoDocPage3"))).Value;

            Session["PrimaryBoxNumber"] = Convert.ToString(primaryBoxNo);

            //Page.ClientScript.RegisterStartupScript(this.GetType(), "OpenWindow", "window.open('DocPageThree.aspx','_blank');", true);

            //Response.Redirect("~/DocPageThree.aspx", false);
        }

        protected void BtnDOCPage2_Click(object sender, EventArgs e)
        {
            //Get the button that raised the event
            Button btn = (Button)sender;

            //Get the row that contains this button
            GridViewRow gvr = (GridViewRow)btn.NamingContainer;

            GridViewRow clickedRow = ((Button)sender).NamingContainer as GridViewRow;

            var primaryBoxNo = ((System.Web.UI.HtmlControls.HtmlInputControl)(clickedRow.FindControl("hidPrimaryBoxNoDocPage2"))).Value;

            Session["PrimaryBoxNumber"] = Convert.ToString(primaryBoxNo);
        }

        private void BindGrid(int packingQty, int noOfBoxes, string ProdOrderNo, string BodyHeatNo, string BonnetHeatNo, string DrgNo, string TagNo, int ValveBoxQty, int prodReleaseQty)
        {
            DataSet ds = _dbObj.FetchPrimaryBoxEntryFromProdNoAndOrderNo(ProdOrderNo, orderNo, pos);

            if (ds != null && ds.Tables.Count > 0)
            {
                //var BodyHeatNo = ds.Tables[0].Rows[0]["BodyHeatNo"].ToString();
                //var BonnetHeatNo = ds.Tables[0].Rows[0]["BonnetHeatNo"].ToString();
                //var DrgNo = "";
                //var TagNo = "";

                //Create an instance of DataTable
                DataTable dt = new DataTable();

                //Create an ID column for adding to the Datatable
                DataColumn dcol = new DataColumn("PrimaryBoxNo", typeof(System.String));
                //dcol.AutoIncrement = true;
                dt.Columns.Add(dcol);

                DataColumn dcol6 = new DataColumn("ProdOrderNo", typeof(System.String));
                dt.Columns.Add(dcol6);

                //Create an ID column for adding to the Datatable
                dcol = new DataColumn("BodyHeatNo", typeof(System.String));
                dt.Columns.Add(dcol);

                dcol = new DataColumn("BonnetHeatNo", typeof(System.String));
                dt.Columns.Add(dcol);

                dcol = new DataColumn("ValveBoxQty", typeof(System.String));
                dt.Columns.Add(dcol);

                dcol = new DataColumn("DrgNo", typeof(System.String));
                dt.Columns.Add(dcol);

                dcol = new DataColumn("TagNo", typeof(System.String));
                dt.Columns.Add(dcol);

                dcol = new DataColumn("ProdReleaseQty", typeof(System.String));
                dt.Columns.Add(dcol);

                string primaryBoxNo = string.Empty;
                string recentBoxNo = string.Empty;

                var currentYear = Convert.ToString(DateTime.UtcNow.Year).Substring(2, 2);

                var getSavedPrimaryBoxNo = _dbObj.GetPrimaryBoxNo();

                //Now add data for dynamic columns
                //As the first column is auto-increment, we do not have to add any thing.
                //Let's add some data to the second column.
                for (int nIndex = 0; nIndex < noOfBoxes; nIndex++)
                {
                    if (!string.IsNullOrEmpty(getSavedPrimaryBoxNo))
                    {
                        if (!string.IsNullOrEmpty(primaryBoxNo))
                        {
                            recentBoxNo = primaryBoxNo.Substring(3);
                        }
                        else
                        {
                            recentBoxNo = getSavedPrimaryBoxNo.Substring(3);
                        }

                        primaryBoxNo = "P" + currentYear + (Convert.ToInt32(recentBoxNo) + 1).ToString().PadLeft(4, '0');
                    }
                    else
                    {
                        if (!string.IsNullOrEmpty(primaryBoxNo))
                        {
                            recentBoxNo = primaryBoxNo.Substring(3);

                            primaryBoxNo = "P" + currentYear + (Convert.ToInt32(recentBoxNo) + 1).ToString().PadLeft(4, '0');
                        }
                        else
                        {
                            primaryBoxNo = "P" + currentYear + "0001";
                        }
                    }

                    //Create a new row
                    DataRow drow = dt.NewRow();

                    drow["PrimaryBoxNo"] = primaryBoxNo;

                    drow["ProdOrderNo"] = ProdOrderNo;

                    //Initialize the row data.
                    drow["BodyHeatNo"] = BodyHeatNo;

                    drow["BonnetHeatNo"] = BonnetHeatNo;

                    drow["ValveBoxQty"] = ValveBoxQty;

                    drow["DrgNo"] = DrgNo;

                    drow["TagNo"] = TagNo;

                    drow["ProdReleaseQty"] = prodReleaseQty;

                    //Add the row to the datatable.
                    dt.Rows.Add(drow);
                }

                DataSet ds1 = new DataSet();
                ds1.Tables.Add(dt);

                GridView1.DataSource = ds1;
                GridView1.DataBind();
            }

        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            DBUtil _DBObj = new DBUtil();
            lblMessage.Visible = false;
            int totalPackingQty = 0;
            string prodReleaseQty = string.Empty;

            try
            {
                if (!string.IsNullOrEmpty(txtPackingQtyInput.Text) && !string.IsNullOrEmpty(txtNumberOfBoxes.Text))
                {
                    foreach (GridViewRow row in GridView1.Rows)
                    {
                        string txtEnteredPackingQty = ((TextBox)row.FindControl("txtPackingQty")).Text.ToString();
                        prodReleaseQty = ((Label)row.FindControl("lblProdReleaseQty")).Text.ToString();

                        if (!string.IsNullOrEmpty(txtEnteredPackingQty))
                        {
                            totalPackingQty += Convert.ToInt32(txtEnteredPackingQty);
                        }
                    }

                    if (Convert.ToInt32(totalPackingQty) != Convert.ToInt32(txtPackingQtyInput.Text) ||
                        (Convert.ToInt32(txtPackingQtyInput.Text) > Convert.ToInt32(prodReleaseQty)))
                    {
                        lblMessage.Visible = true;
                        lblMessage.ForeColor = System.Drawing.Color.Red;
                        lblMessage.Text = "Quantity mismatch";

                        return;
                    }

                    foreach (GridViewRow row in GridView1.Rows)
                    {
                        string lblPrimaryBoxNo = ((Label)row.FindControl("lblPrimaryBoxNo")).Text.ToString();
                        string lblProdOrderNo = ((Label)row.FindControl("lblProdOrderNo")).Text.ToString();
                        string txtBodyHeatNo = ((TextBox)row.FindControl("txtBodyHeatNo")).Text.ToString();
                        string txtBonnetHeatNo = ((TextBox)row.FindControl("txtBonnetHeatNo")).Text.ToString();
                        string txtGridPackingQty = ((TextBox)row.FindControl("txtPackingQty")).Text.ToString();
                        string txtValveBoxQty = ((TextBox)row.FindControl("txtValveBoxQty")).Text.ToString();
                        string txtDrgNo = ((TextBox)row.FindControl("txtDrgNo")).Text.ToString();
                        string txtTagNo = ((TextBox)row.FindControl("txtTagNo")).Text.ToString();

                        if (!string.IsNullOrEmpty(txtBodyHeatNo))
                        {
                            var qty = string.IsNullOrEmpty(txtGridPackingQty) ? 0 : Convert.ToInt32(txtGridPackingQty);

                            _dbObj.InsertFromPrimaryBoxNo(lblPrimaryBoxNo, Convert.ToInt32(qty), lblProdOrderNo, txtBodyHeatNo, txtBonnetHeatNo, txtDrgNo, txtTagNo);
                        }
                        else
                        {
                            lblMessage.Visible = true;
                            lblMessage.ForeColor = System.Drawing.Color.Red;
                            lblMessage.Text = "Body Heat No missing";

                            return;
                        }

                        lblMessage.Visible = true;
                        lblMessage.ForeColor = System.Drawing.Color.Green;
                        lblMessage.Text = "Details Updated successfully";
                    }

                    _dbObj.UpdateProductionReleaseNewPrimaryBoxEntry(Convert.ToInt32(txtPackingQtyInput.Text), Request.QueryString["ProdOrderNo"].ToString());

                    txtNumberOfBoxes.Text = "";
                    txtPackingQtyInput.Text = "";
                }

                //BindGrid();
            }
            catch (Exception ex)
            {
                //LogError(ex, "Exception from while updating row from Sale Order Line Item Deletion.");
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("PrimaryBoxEntry.aspx");
        }
    }
}