using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

using Libraries.Entity;
using Libraries.Manager;

using Microsoft.Practices.EnterpriseLibrary.Logging;


public partial class ManageEmployees : System.Web.UI.Page
{
    EmployeeManager empMgr = new EmployeeManager();

    //private string GetSortDirection(string SortDirection)
    //{
    //    switch (SortDirection)
    //    {
    //        case "Ascending":
    //            SortDirection = "DESC";
    //            break;
    //        case "Descending":
    //            SortDirection = "ASC";
    //            break;
    //    }
    //    return SortDirection;

    //}
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            DataSet ds = (DataSet)Cache["GlobalCache"];

            Employee empObj = new Employee();
            EmployeeManager empMgr = new EmployeeManager();

            DataSet searchRst;
            empObj.BadgeNumber = 0;
            empObj.Status = 0;
            searchRst = empMgr.SearchEmployee(empObj);

            if (!Page.IsPostBack)
            {
                if (!SecurityCheck.IsPageAuthorized(this.Page))
                {
                    Response.Redirect("SecurityErrorPage.aspx");
                }

               // ddlGroupBy.Items.Add(new ListItem("--Select Column Name--", "0"));
                if (searchRst != null)
                {
                    if (ds != null)
                    {
                        DataTable genTbl = new DataTable("Gender");
                        searchRst.Merge(ds);
                        //searchRst.Relations.Add(searchRst.Tables["Gender"].Columns["id"], searchRst.Tables["Employees"].Columns["Sex"]);
                        //searchRst.Relations.Add(searchRst.Tables["MaritalStatus"].Columns["id"], searchRst.Tables["Employees"].Columns["MaritalStatus"]);
                        //searchRst.Relations.Add(searchRst.Tables["Designation"].Columns["id"], searchRst.Tables["Employees"].Columns["Designation"]);
                        //searchRst.Relations.Add(searchRst.Tables["EmployeeStatus"].Columns["id"], searchRst.Tables["Employees"].Columns["Status"]);

                    }
                    Session["grdSearchResultDATASET"] = searchRst;

                    grdSearchResult.DataSource = searchRst;
                    grdSearchResult.DataBind();
                    grdSearchResult.Columns[0].Visible = false;
                    int columnCount = grdSearchResult.Columns.Count;
                    grdSearchResult.Columns[columnCount - 1].Visible = false;

                    int grdColumnCount = grdSearchResult.Columns.Count;

                    for (int k = 0; k < grdColumnCount - 1; k++)
                    {
                        if (k > 0)
                        {
                            string columnIndex = k.ToString();
                            string columnName = grdSearchResult.Columns[k].SortExpression.ToString();
                            ddlGroupBy.Items.Add(new ListItem(columnName, columnIndex));
                        }
                    }
                    ddlGroupBy.Items.Add(new ListItem("--Remove Grouping--"));
                }
            }
            else
            {
                string strColumnName = ddlGroupBy.SelectedItem.Text;

                if (strColumnName.Equals("--Remove Grouping--") || strColumnName.Equals("--Select Column Name--"))
                {
                    grdSearchResult.DataSource = (DataSet)GetDataSource(); ;
                    grdSearchResult.DataBind();
                    grdSearchResult.Columns[0].Visible = false;
                    int colCount = grdSearchResult.Columns.Count;
                    grdSearchResult.Columns[colCount - 1].Visible = false;
                }
            }
        }
        catch (Exception ex)
        {
            Logger.Write(this.GetType().ToString() + " : Manage Employee - Page Load() : " + " : " + DateTime.Now + " : " + ex.Message.ToString(), Category.General, Priority.Highest);
        }
    }

    public DataSet GetDataSource()
    {
        DataSet dset = new DataSet();
        if (Session["SortExpression"] != null)
        {
            dset = (DataSet)Cache["SortDATASET"];
        }
        else
        {
            dset = (DataSet)Session["grdSearchResultDATASET"];
        }
        return dset;
    }

    /* Added by Arun on Dec'19-2007.
     * To get the unique values for the selected column 
     */
    public string[] GetDistinctRowValues(DataSet ResultSet, string colName)
    {
        string[] RowValues = new string[ResultSet.Tables["Employees"].Rows.Count];
        string ColValue = "";

        int j = 0;
        for (int i = 0; i < ResultSet.Tables["Employees"].Rows.Count; i++)
        {
            ColValue = Convert.ToString(ResultSet.Tables["Employees"].Rows[i][colName]);
            if (!IsValueExists(RowValues, ColValue))
            {
                RowValues[j] = ColValue;
                j = j + 1;
            }

        }

        string[] RowValuesNew = new string[j];
        for (int i = 0; i < j; i++)
        {

            RowValuesNew[i] = RowValues[i];
        }
        return RowValuesNew;
    }

    /* Added by Arun on Dec'19-2007.
     * To check if we have inserted the value into the string array already or not
     */
    public bool IsValueExists(string[] Result, string Value)
    {
        for (int i = 0; i < Result.Length; i++)
        {
            if (Result[i] != null)
            {
                if (Result[i].Contains(Value))
                    return true;
            }
        }
        return false;
    }

    protected void ddlGroupBy_SelectedIndexChanged(object sender, EventArgs e)
    {
        int RowIndex = 0;
        string strRowValue = "";
        string strCtrlName = "";
        string strRowFilter = "";
        DataSet ds = new DataSet();
        
        try
        {
            /* Added by Arun on 26-Dec'07
             * For showing the progress bar in the screen, when any of the operations are done.
            */ 
            System.Threading.Thread.Sleep(3000);
            
            
            ds = (DataSet)Session["grdSearchResultDATASET"];
            DataView dv;
            dv = ds.Tables["Employees"].DefaultView;
            dv.RowFilter = null;
            string strColumnName = ddlGroupBy.SelectedItem.Text;

            /* Added by Arun on Dec'19-2007.
             * To get the unique values of the column that we want to group by
            */
            string[] new1 = GetDistinctRowValues(ds, strColumnName);


            /* Added by Arun on Dec'19-2007. 
             * Setting the pagesize to the total number of rows in the dataset, so that we can avoid the issue in the Grid Grouping.
            */
            grdSearchResult.PageSize = ds.Tables["Employees"].Rows.Count;
            grdSearchResult.AllowPaging = false;

            
            if (strColumnName.Equals("--Remove Grouping--") || strColumnName.Equals("--Select Column Name--"))
            {
                grdSearchResult.DataSource = dv;
                grdSearchResult.DataBind();
            }
            else
            {
                dv = ds.Tables["Employees"].DefaultView;
                dv.Sort = strColumnName + "   ASC";

                /* Added by Arun on Dec'19-2007.
                 * To set the pagesize, pagination only for those columns which exceeds the normal page size
                */
                if (new1.Length > 15)
                {
                    grdSearchResult.PageSize = 15;
                    grdSearchResult.AllowPaging = true;
                }

                grdSearchResult.DataSource = dv;
                grdSearchResult.DataBind();

                int colCOUNT = grdSearchResult.Columns.Count;
                grdSearchResult.Columns[0].Visible = true;
                grdSearchResult.Columns[colCOUNT - 1].Visible = true;

                String[] usedValues = new String[100];
                int currIndex = 0;
                int currRow = 0;
                bool breakFree = false;

                
                
                foreach (GridViewRow row in grdSearchResult.Rows)
                {
                    currRow++;
                    int TotalCells = row.Cells.Count;
                    GridView gv = new GridView();
                    gv = (GridView)row.FindControl("GridView2");

                    if (strColumnName == "BadgeNumber")
                    {
                        HyperLink myLink = (HyperLink)row.Cells[1].Controls[0];
                        strRowValue = myLink.Text;
                    }
                    else if (strColumnName == "DateOfBirth")
                    {
                        strCtrlName = strColumnName;
                        strRowValue = row.Cells[10].Text;
                    }
                    else if (strColumnName == "DateOfJoin")
                    {
                        strCtrlName = strColumnName;
                        strRowValue = row.Cells[11].Text;
                    }
                    else
                    {
                        strCtrlName = "lbl" + strColumnName;
                        strRowValue = ((Label)row.FindControl(strCtrlName)).Text;
                    }

                    if (currIndex > 0)
                    {
                        for (int i = 0; i < currIndex; i++)
                            if (usedValues[i].Equals(strRowValue))
                            {
                                breakFree = true;
                                break;
                            }
                    }

                    if (breakFree)
                    {
                        breakFree = false;
                        grdSearchResult.Rows[currRow - 1].Visible = false;
                        continue;
                    }

                    usedValues[currIndex++] = strRowValue;
                    string strRV = "'" + strRowValue + "'";

                    dv = ds.Tables["Employees"].DefaultView;

                    strRowFilter = strColumnName + " = " + "'" + strRowValue + "'";
                    dv.RowFilter = strRowFilter;

                    gv.DataSource = dv;
                    gv.DataBind();
                    gv.GridLines = GridLines.Both;

                    row.Cells[1].Text = " GROUP BY  : " + strRowValue;
                    row.Cells[1].Font.Bold = true;
                    row.Cells[1].Font.Size = 7;
                    
                    for (int K = 2; K < 12; K++)
                    {
                        row.Cells[K].Text = "";
                        grdSearchResult.GridLines = GridLines.None;
                    }
                }
                grdSearchResult.HeaderRow.Enabled = false;
            }
        }
        catch (Exception ex)
        {
            Logger.Write(this.GetType().ToString() + " : Manage Employee - When trying to do a GroupBy : " + " : " + DateTime.Now + " : " + ex.Message.ToString(), Category.General, Priority.Highest);
        }
    }

    protected void grdSearchResult_Sorting(object sender, GridViewSortEventArgs e)
    {
        DataSet sortDS = new DataSet();
        string sortDirection = string.Empty;
        string sortType = string.Empty;

        try
        {
            sortDS = (DataSet)Session["grdSearchResultDATASET"];

            //if (Session["SortExpression"] != null)
            //{
            //    sortType = Session["SortExpression"].ToString();
            //}
            //else
            //{
            //    sortType = e.SortDirection.ToString();
            //    if (sortType == "Ascending") sortType = "ASC";
            //    else sortType = "DESC";
            //}
            string colN = e.SortExpression.ToString();

            DataView dv = sortDS.Tables["Employees"].DefaultView;

            if (dv.Sort.ToString().IndexOf("ASC") > 0)
            {
                dv.Sort = colN + " DESC";
            }
            else
            {
                dv.Sort = colN + " ASC";
            }

            //if (colN == (string)Session["SortExpression"])
            //{
            //    if ((Session.Count >= 1) && (colN == Session["SortExpression"].ToString()))
            //    {
            //        if (sortType == "ASC") sortDirection = "DESC";
            //        else sortDirection = "ASC";
            //    }
            //    else if (Session.Count >= 1)
            //    {
            //        if (sortType == "ASC") sortDirection = "DESC";
            //        else sortDirection = "ASC";
            //    }
            //}
            //else
            //{
            //    if (sortType == "ASC") sortDirection = "DESC";
            //    else if (sortType == "DESC") sortDirection = "ASC";
            //}

            //DataView dv = sortDS.Tables["Employees"].DefaultView;
            //dv.Sort = colN + "   " + sortDirection;

            ////Session["SortExpression"] = colN;
            //Session["SortExpression"] = sortDirection;

            grdSearchResult.DataSource = dv;
            grdSearchResult.DataBind();
        }

        catch (Exception ex)
        {
            Logger.Write(this.GetType().ToString() + " : Manage Employee - When trying to do a Sorting : " + " : " + DateTime.Now + " : " + ex.Message.ToString(), Category.General, Priority.Highest);
        }
    }

    protected void btnSearchBox_Click1(object sender, EventArgs e)
    {
        string strQuery = txtSearchBox.Text;
        DataSet DS = new DataSet();

        try
        {
            DS = (DataSet)empMgr.getSearchRecord(strQuery);

            if (DS.Tables["Employee"].Rows.Count == 0)
            {
                DataTable dt = (DataTable)DS.Tables["Employee"];
                dt.Rows.Add(dt.NewRow());
                grdSearchResult.ShowFooter = true;

                DataSet D = new DataSet();

                grdSearchResult.DataSource = dt;
                grdSearchResult.DataBind();

                int TotalColumns = grdSearchResult.Rows[0].Cells.Count;
                grdSearchResult.Rows[0].Cells.Clear();
                grdSearchResult.Rows[0].Cells.Add(new TableCell());
                grdSearchResult.Rows[0].Cells[0].ColumnSpan = TotalColumns;
                grdSearchResult.Rows[0].Cells[0].Text = " No Records Found ";
            }
            else
            {
                grdSearchResult.DataSource = DS;
                grdSearchResult.DataBind();
            }
        }

        catch (Exception ex)
        {
            Logger.Write(this.GetType().ToString() + " : Manage Employee - When trying to do a Search : " + " : " + DateTime.Now + " : " + ex.Message.ToString(), Category.General, Priority.Highest);
        }
    }

    protected void btnSearchBox_Click(object sender, EventArgs e)
    {
        string strQuery = txtSearchBox.Text;
        string searchRowFilter = "";
        string strColumnName = "";
        string strColName = "";
        string strRowVal = "";
        string strCol1 = "BadgeNumber";
        string strCol2 = "FirstName";
        string strCol3 = "MiddleName";
        string strCol4 = "LastName";
        string strCol5 = "NTLogin";
        string strCol6 = "Sex";
        string strCol7 = "Status";
        string strCol8 = "Designation";
        string strCol9 = "MaritalStatus";

        DataSet searchDS = new DataSet();

        try
        {
           
            /* Added by Arun on 26-Dec'07
             * For showing the progress bar in the screen, when any of the operations are done.
            */ 
            System.Threading.Thread.Sleep(3000);

            searchDS = (DataSet)Session["grdSearchResultDATASET"];

            int colCount = searchDS.Tables["Employees"].Columns.Count;
            int rowCount = searchDS.Tables["Employees"].Rows.Count;
            int r = 0;

            for (int k = 0; k < rowCount; k++)
            {
                for (int k1 = 1; k1 < colCount; k1++)
                {
                    strColName = searchDS.Tables["Employees"].Columns[k1].ToString();
                    strRowVal = searchDS.Tables["Employees"].Rows[k].ItemArray[k1].ToString();
                    string st1 = "%" + strQuery + "%";

                    string STR = "LIKE";
                    //Added by Arun on 20-Dec'07 Added the FirstName,MiddleName,LastName,NTLogin,Sex,Status,Designation,MaritalStatus also in the search criteria
                    searchRowFilter = (strCol2 + " " + STR + " " + "'" + st1 + "'" + " OR " + strCol3 + " " + STR + " " + "'" + st1 + "'" + " OR " + strCol4 + " " + STR + " " + "'" + st1 + "'" + " OR " + strCol5 + " " + STR + " " + "'" + st1 + "'" + " OR " + strCol6 + " " + STR + " " + "'" + st1 + "'" + " OR " + strCol7 + " " + STR + " " + "'" + st1 + "'" + " OR " + strCol8 + " " + STR + " " + "'" + st1 + "'" + " OR " + strCol9 + " " + STR + " " + "'" + st1 + "'");
                    DataView dv = searchDS.Tables["Employees"].DefaultView;
                    dv.RowFilter = searchRowFilter;

                   grdSearchResult.DataSource = dv;
                   grdSearchResult.DataBind();
                }
            }

            int ct = grdSearchResult.Rows.Count;
            if (ct <= 0)
            {
                DataSet DS1 = (DataSet)empMgr.getSearchRecord(strQuery);
                if (DS1.Tables["Employee"].Rows.Count != 0)
                {
                    grdSearchResult.DataSource = DS1;
                    grdSearchResult.DataBind();
                }
            }
        }

        catch (Exception ex)
        {
            Logger.Write(this.GetType().ToString() + " : Manage Employee - Search() : " + " : " + DateTime.Now + " : " + ex.Message.ToString(), Category.General, Priority.Highest);
        }
    }

    protected void grdSearchResult_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        grdSearchResult.PageIndex = e.NewPageIndex;
        //grdSearchResult.DataSource = (DataSet)GetDataSource(); ;
        //grdSearchResult.DataBind();

        int RowIndex = 0;
        string strRowValue = "";
        string strCtrlName = "";
        string strRowFilter = "";
        DataSet ds = new DataSet();
        try
        {
            ds = (DataSet)Session["grdSearchResultDATASET"];
            DataView dv;
            dv = ds.Tables["Employees"].DefaultView;
            dv.RowFilter = null;
            string strColumnName = ddlGroupBy.SelectedItem.Text;

            if (strColumnName.Equals("--Remove Grouping--") || strColumnName.Equals("--Select Column Name--"))
            {
                grdSearchResult.DataSource = dv;
                grdSearchResult.DataBind();
            }
            else
            {
                dv = ds.Tables["Employees"].DefaultView;
                dv.Sort = strColumnName + "   ASC";

                grdSearchResult.DataSource = dv;
                grdSearchResult.DataBind();

                int colCOUNT = grdSearchResult.Columns.Count;
                grdSearchResult.Columns[0].Visible = true;
                grdSearchResult.Columns[colCOUNT - 1].Visible = true;

                String[] usedValues = new String[100];
                int currIndex = 0;
                int currRow = 0;
                bool breakFree = false;

                foreach (GridViewRow row in grdSearchResult.Rows)
                {
                    currRow++;
                    int TotalCells = row.Cells.Count;
                    GridView gv = new GridView();
                    gv = (GridView)row.FindControl("GridView2");

                    if (strColumnName == "BadgeNumber")
                    {
                        HyperLink myLink = (HyperLink)row.Cells[1].Controls[0];
                        strRowValue = myLink.Text;
                    }
                    else if (strColumnName == "DateOfBirth")
                    {
                        strCtrlName = strColumnName;
                        strRowValue = row.Cells[10].Text;
                    }
                    else if (strColumnName == "DateOfJoin")
                    {
                        strCtrlName = strColumnName;
                        strRowValue = row.Cells[11].Text;
                    }
                    else
                    {
                        strCtrlName = "lbl" + strColumnName;
                        strRowValue = ((Label)row.FindControl(strCtrlName)).Text;
                    }

                    if (currIndex > 0)
                    {
                        for (int i = 0; i < currIndex; i++)
                            if (usedValues[i].Equals(strRowValue))
                            {
                                breakFree = true;
                                break;
                            }
                    }

                    if (breakFree)
                    {
                        breakFree = false;
                        grdSearchResult.Rows[currRow - 1].Visible = false;
                        continue;
                    }

                    usedValues[currIndex++] = strRowValue;
                    string strRV = "'" + strRowValue + "'";

                    dv = ds.Tables["Employees"].DefaultView;

                    strRowFilter = strColumnName + " = " + "'" + strRowValue + "'";
                    dv.RowFilter = strRowFilter;

                    gv.DataSource = dv;
                    gv.DataBind();
                    gv.GridLines = GridLines.Both;

                    row.Cells[1].Text = " GROUP BY  : " + strRowValue;
                    row.Cells[1].Font.Bold = true;
                    row.Cells[1].Font.Size = 7;

                    for (int K = 2; K < 12; K++)
                    {
                        row.Cells[K].Text = "";
                        grdSearchResult.GridLines = GridLines.None;
                    }
                }
                grdSearchResult.HeaderRow.Enabled = false;

            }
        }

        catch (Exception ex)
        {
            Logger.Write(this.GetType().ToString() + " : Manage Employee - When trying to do a Paging : " + " : " + DateTime.Now + " : " + ex.Message.ToString(), Category.General, Priority.Highest);
        }
    }

    /*
     * Added by Arun on 28-Jan'08
     * Added so as to show & hide the InActive Records also in the Grid
     */ 
    protected void btnShowInactive_Click(object sender, EventArgs e)
    {
        DataSet ds = (DataSet)Cache["GlobalCache"];

        Employee empObj = new Employee();
        EmployeeManager empMgr = new EmployeeManager();

        DataSet searchRst;
        empObj.BadgeNumber = 0;
        
        if (btnShowInactive.Text.Equals("Show InActive")) //InActive Records Also
            empObj.Status = 1;
        else
            empObj.Status = 0;

        searchRst = empMgr.SearchEmployee(empObj);

        if (searchRst != null)
        {
            if (ds != null)
            {
                DataTable genTbl = new DataTable("Gender");
                searchRst.Merge(ds);
            }
            Session["grdSearchResultDATASET"] = searchRst;

            grdSearchResult.DataSource = searchRst;
            grdSearchResult.DataBind();
            grdSearchResult.Columns[0].Visible = false;
            int columnCount = grdSearchResult.Columns.Count;
            grdSearchResult.Columns[columnCount - 1].Visible = false;
        }
        if(btnShowInactive.Text.Equals("Show InActive"))
            btnShowInactive.Text = "Hide InActive";
        else
            btnShowInactive.Text = "Show InActive";
    }
}