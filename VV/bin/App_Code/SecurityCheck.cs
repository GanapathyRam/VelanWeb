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
using System.Xml;
using Libraries.Entity;
using Libraries.Manager;
using System.Web.Caching;
using System.Data.SqlClient;

using System.IO;


/// <summary>
/// Summary description for SecurityCheck
/// </summary>
public class SecurityCheck
{
    public SecurityCheck()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public enum ActionName
    {
        Employees = 101, AddEmployees = 102, UpdateEmployee = 103, DeleteEmployee = 104,
        Clients = 201, AddClients = 202, UpdateClients = 203, DeleteClients = 204,
        Projects = 301, AddProjects = 302, UpdateProjects = 303, DeleteProjects = 304,
        Tasks = 401, AddTasks = 402, UpdateTasks = 403, DeleteTasks = 404,
        Resources = 501, AddResources = 502, UpdateResources = 503, DeleteResources = 504,
        TimeSheets = 601, AddTimeSheet = 602, ApproveTimeSheet = 603,
        Reports = 700, TimeSheetDetailedReport = 701, TimesheetNonComplianceReport = 702,
        Leaves = 800, ManageLeaves = 801, ApplyLeave = 802, ApproveLeave = 803,
        Probation = 900, ManageProbationForm = 901, AddProbationForm = 902, UpdateProbationForm = 903,
        Admin = 1000, ViewLogs = 1001, EOMSetup = 1002, HolidayCalendar = 1003, ManageSecurity = 1004

        //Planning = 101, UploadBaaN = 102, ProductionRelease = 103, InvoicedDataImport = 104, FreezePlan = 105, ReleasePlan = 106, FGPlan = 107, SalesPlan = 108, OrderStatusReport = 109, ToReleaseReport = 110,
        //Production = 201, WIPToFG = 202, ProdCompletion = 203, WIPReport = 204,
        //Quality = 301, TPIOffering = 302, TPIPendingReport = 303,
        //Sales = 401, ITPGADINno = 402, StockCode_TagNumImport = 403, SCNInput = 404, MISFinanceInput = 405, QRQA = 406, QRQASalesSummary = 407, Commercial = 408,
        //SystemUtility = 501
    };

    //public enum MenuNames { Planning = 1, Production, Quality, Sales, SystemUtility };
    public enum MenuNames { Employees = 1, Clients, Projects, Tasks, Resources, TimeSheets, Reports, Leaves, Probation, Admin };

    public static bool IsPageAuthorized(Page myPage)
    {
        bool isAuthorized = false;

        if (myPage.Session["LoggedOnUser"] == null)
            return isAuthorized;

        string pageName = myPage.AppRelativeVirtualPath.Substring(2, myPage.AppRelativeVirtualPath.Length - 2);

        Employee objEmp = (Employee)myPage.Session["LoggedOnUser"];
        string userName = "Welcome " + objEmp.FirstName.Trim() + " " + objEmp.LastName.Trim();

        ArrayList actionsList = (ArrayList)objEmp.RoleActions;
        RoleActions rolAct;

        System.Web.UI.WebControls.Menu tbstr = (System.Web.UI.WebControls.Menu)myPage.Master.FindControl("Menu1");
        //SecurityCheck s1 = new SecurityCheck();
        SecurityCheck.BuildMenu(myPage);

        for (int i = 0; i < actionsList.Count; i++)
        {
            rolAct = (RoleActions)actionsList[i];
            for (int k = 0; k < tbstr.Items.Count; k++)
            {
                if (tbstr.Items[k].NavigateUrl == pageName)
                {
                    isAuthorized = true;
                    break;
                }
                else if (tbstr.Items[k].ChildItems.Count > 0)
                {
                    for (int c = 0; c < tbstr.Items[k].ChildItems.Count; c++)
                    {
                        //if (tbstr.Items[k].ChildItems[c].NavigateUrl == pageName)
                        if (tbstr.Items[k].ChildItems[c].NavigateUrl.Contains(pageName))
                        {
                            isAuthorized = true;
                            break;
                        }
                    }
                }
                else if (pageName.Equals("MyProfile.aspx"))
                {
                    isAuthorized = true;
                    break;
                }
            }
        }
        if (isAuthorized)
            ShowMenus(myPage, userName);

        return isAuthorized;
    }

    public static void ShowMenus(Page myPage, string userName)
    {
        Employee objEmp = (Employee)myPage.Session["LoggedOnUser"];

        int MenuCount = 0;
        // Make all the tabs invisible        
        System.Web.UI.WebControls.Menu tbstr = (System.Web.UI.WebControls.Menu)myPage.Master.FindControl("Menu1");

        for (int i = 1; i < tbstr.Items.Count; i++)
        {
            MenuCount += tbstr.Items[i].ChildItems.Count;
            tbstr.Items[i].Enabled = false;
        }
        // Switch the visibility based on the actions available for the selected user

        ArrayList actionsList = (ArrayList)objEmp.RoleActions;
        RoleActions rolAct;

        for (int i = 0; i < actionsList.Count; i++)
        {
            rolAct = (RoleActions)actionsList[i];

            if (rolAct.ActionId == (int)ActionName.Employees)
            {
                tbstr.Items[Convert.ToInt32(MenuNames.Employees)].Enabled = true;
                tbstr.Items[Convert.ToInt32(MenuNames.Employees)].ChildItems[0].Enabled = true;
                tbstr.Items[Convert.ToInt32(MenuNames.Employees)].ChildItems[1].Enabled = false;
                tbstr.Items[Convert.ToInt32(MenuNames.Employees)].ChildItems[2].Enabled = false;
            }
            else if (rolAct.ActionId == (int)ActionName.AddEmployees)
            {
                tbstr.Items[Convert.ToInt32(MenuNames.Employees)].ChildItems[1].Enabled = true;
            }

            else if (rolAct.ActionId == (int)ActionName.UpdateEmployee || rolAct.ActionId == (int)ActionName.DeleteEmployee)
            {
                tbstr.Items[Convert.ToInt32(MenuNames.Employees)].ChildItems[2].Enabled = true;
            }
            else if (rolAct.ActionId == (int)ActionName.Projects)
            {
                tbstr.Items[Convert.ToInt32(MenuNames.Projects)].Enabled = true;
                tbstr.Items[Convert.ToInt32(MenuNames.Projects)].ChildItems[0].Enabled = true;
                tbstr.Items[Convert.ToInt32(MenuNames.Projects)].ChildItems[1].Enabled = false;
                tbstr.Items[Convert.ToInt32(MenuNames.Projects)].ChildItems[2].Enabled = false;
            }
            else if (rolAct.ActionId == (int)ActionName.AddProjects)
            {
                tbstr.Items[Convert.ToInt32(MenuNames.Projects)].ChildItems[1].Enabled = true;
            }
            else if (rolAct.ActionId == (int)ActionName.UpdateProjects || rolAct.ActionId == (int)ActionName.DeleteProjects)
            {
                tbstr.Items[Convert.ToInt32(MenuNames.Projects)].ChildItems[2].Enabled = true;
            }
            else if (rolAct.ActionId == (int)ActionName.Clients)
            {
                tbstr.Items[Convert.ToInt32(MenuNames.Clients)].Enabled = true;
                tbstr.Items[Convert.ToInt32(MenuNames.Clients)].ChildItems[0].Enabled = true;
                tbstr.Items[Convert.ToInt32(MenuNames.Clients)].ChildItems[1].Enabled = false;
                tbstr.Items[Convert.ToInt32(MenuNames.Clients)].ChildItems[2].Enabled = false;
            }
            else if (rolAct.ActionId == (int)ActionName.AddClients)
            {
                tbstr.Items[Convert.ToInt32(MenuNames.Clients)].ChildItems[1].Enabled = true;
            }
            else if (rolAct.ActionId == (int)ActionName.UpdateClients || rolAct.ActionId == (int)ActionName.DeleteClients)
            {
                tbstr.Items[Convert.ToInt32(MenuNames.Clients)].ChildItems[2].Enabled = true;
            }
            else if (rolAct.ActionId == (int)ActionName.Tasks)
            {
                tbstr.Items[Convert.ToInt32(MenuNames.Tasks)].Enabled = true;
                tbstr.Items[Convert.ToInt32(MenuNames.Tasks)].ChildItems[0].Enabled = true;
                tbstr.Items[Convert.ToInt32(MenuNames.Tasks)].ChildItems[1].Enabled = false;
                tbstr.Items[Convert.ToInt32(MenuNames.Tasks)].ChildItems[2].Enabled = false;
            }
            else if (rolAct.ActionId == (int)ActionName.AddTasks)
            {
                tbstr.Items[Convert.ToInt32(MenuNames.Tasks)].ChildItems[1].Enabled = true;
            }
            else if (rolAct.ActionId == (int)ActionName.UpdateTasks || rolAct.ActionId == (int)ActionName.DeleteTasks)
            {
                tbstr.Items[Convert.ToInt32(MenuNames.Tasks)].ChildItems[2].Enabled = true;
            }
            else if (rolAct.ActionId == (int)ActionName.Resources)
            {
                tbstr.Items[Convert.ToInt32(MenuNames.Resources)].Enabled = true;
                tbstr.Items[Convert.ToInt32(MenuNames.Resources)].ChildItems[0].Enabled = true;
                tbstr.Items[Convert.ToInt32(MenuNames.Resources)].ChildItems[1].Enabled = false;
                tbstr.Items[Convert.ToInt32(MenuNames.Resources)].ChildItems[2].Enabled = false;
            }
            else if (rolAct.ActionId == (int)ActionName.AddResources)
            {
                tbstr.Items[Convert.ToInt32(MenuNames.Resources)].ChildItems[1].Enabled = true;
            }
            else if (rolAct.ActionId == (int)ActionName.UpdateResources || rolAct.ActionId == (int)ActionName.DeleteResources)
            {
                tbstr.Items[Convert.ToInt32(MenuNames.Resources)].ChildItems[2].Enabled = true;
            }

            /* Added by Arun on 27-Dec'07
             * To enable only those child menu items which are to be shown for the logged in user
            */
            else if (rolAct.ActionId == (int)ActionName.TimeSheets)
            {
                tbstr.Items[Convert.ToInt32(MenuNames.TimeSheets)].Enabled = true;
                tbstr.Items[Convert.ToInt32(MenuNames.TimeSheets)].ChildItems[0].Enabled = true;
                tbstr.Items[Convert.ToInt32(MenuNames.TimeSheets)].ChildItems[1].Enabled = false;
                tbstr.Items[Convert.ToInt32(MenuNames.TimeSheets)].ChildItems[2].Enabled = false;
            }
            else if (rolAct.ActionId == (int)ActionName.AddTimeSheet)
            {
                tbstr.Items[Convert.ToInt32(MenuNames.TimeSheets)].ChildItems[1].Enabled = true;
            }
            else if (rolAct.ActionId == (int)ActionName.ApproveTimeSheet)
            {
                tbstr.Items[Convert.ToInt32(MenuNames.TimeSheets)].ChildItems[2].Enabled = true;
            }
            //Added By Rita Aiyar on 17/1/2007 for the Reports
            else if (rolAct.ActionId == (int)ActionName.Reports)
            {
                tbstr.Items[Convert.ToInt32(MenuNames.Reports)].Enabled = true;
                tbstr.Items[Convert.ToInt32(MenuNames.Reports)].ChildItems[0].Enabled = false;
                tbstr.Items[Convert.ToInt32(MenuNames.Reports)].ChildItems[1].Enabled = false;
            }
            else if (rolAct.ActionId == (int)ActionName.TimeSheetDetailedReport)
            {
                tbstr.Items[Convert.ToInt32(MenuNames.Reports)].ChildItems[0].Enabled = true;
            }
            else if (rolAct.ActionId == (int)ActionName.TimesheetNonComplianceReport)
            {
                tbstr.Items[Convert.ToInt32(MenuNames.Reports)].ChildItems[1].Enabled = true;
            }
            //
            else if (rolAct.ActionId == (int)ActionName.Leaves)
            {
                tbstr.Items[Convert.ToInt32(MenuNames.Leaves)].Enabled = true;
                tbstr.Items[Convert.ToInt32(MenuNames.Leaves)].ChildItems[0].Enabled = false;
                tbstr.Items[Convert.ToInt32(MenuNames.Leaves)].ChildItems[1].Enabled = false;
                tbstr.Items[Convert.ToInt32(MenuNames.Leaves)].ChildItems[2].Enabled = false;
            }
            else if (rolAct.ActionId == (int)ActionName.ManageLeaves)
            {
                tbstr.Items[Convert.ToInt32(MenuNames.Leaves)].ChildItems[0].Enabled = true;
            }
            else if (rolAct.ActionId == (int)ActionName.ApplyLeave)
            {
                tbstr.Items[Convert.ToInt32(MenuNames.Leaves)].ChildItems[1].Enabled = true;
            }
            else if (rolAct.ActionId == (int)ActionName.ApproveLeave)
            {
                tbstr.Items[Convert.ToInt32(MenuNames.Leaves)].ChildItems[2].Enabled = true;
            }
            else if (rolAct.ActionId == (int)ActionName.Probation)
            {
                tbstr.Items[Convert.ToInt32(MenuNames.Probation)].Enabled = true;
                tbstr.Items[Convert.ToInt32(MenuNames.Probation)].ChildItems[0].Enabled = false;
                tbstr.Items[Convert.ToInt32(MenuNames.Probation)].ChildItems[1].Enabled = false;
                tbstr.Items[Convert.ToInt32(MenuNames.Probation)].ChildItems[2].Enabled = false; // Added by Praveen for UpdateProbationForm
            }
            else if (rolAct.ActionId == (int)ActionName.ManageProbationForm)
            {
                tbstr.Items[Convert.ToInt32(MenuNames.Probation)].ChildItems[0].Enabled = true;
            }
            else if (rolAct.ActionId == (int)ActionName.AddProbationForm)
            {
                tbstr.Items[Convert.ToInt32(MenuNames.Probation)].ChildItems[1].Enabled = true;
            }
            else if (rolAct.ActionId == (int)ActionName.UpdateProbationForm)
            {
                tbstr.Items[Convert.ToInt32(MenuNames.Probation)].ChildItems[1].Enabled = true;
            }        

            else if (rolAct.ActionId == (int)ActionName.Admin)
            {
                tbstr.Items[Convert.ToInt32(MenuNames.Admin)].Enabled = true;
                tbstr.Items[Convert.ToInt32(MenuNames.Admin)].ChildItems[0].Enabled = false;
                tbstr.Items[Convert.ToInt32(MenuNames.Admin)].ChildItems[1].Enabled = false;
                tbstr.Items[Convert.ToInt32(MenuNames.Admin)].ChildItems[2].Enabled = false;
                tbstr.Items[Convert.ToInt32(MenuNames.Admin)].ChildItems[3].Enabled = false;
            }
            else if (rolAct.ActionId == (int)ActionName.ViewLogs)
            {
                tbstr.Items[Convert.ToInt32(MenuNames.Admin)].ChildItems[0].Enabled = true;
            }
            else if (rolAct.ActionId == (int)ActionName.EOMSetup)
            {
                tbstr.Items[Convert.ToInt32(MenuNames.Admin)].ChildItems[1].Enabled = true;
            }
            else if (rolAct.ActionId == (int)ActionName.HolidayCalendar)
            {
                tbstr.Items[Convert.ToInt32(MenuNames.Admin)].ChildItems[2].Enabled = true;
            }
            else if (rolAct.ActionId == (int)ActionName.ManageSecurity)
            {
                tbstr.Items[Convert.ToInt32(MenuNames.Admin)].ChildItems[3].Enabled = true;
            }
        }

        Label lblUserName = (Label)myPage.Master.FindControl("lblUserName");
        lblUserName.Text = "Welcome " + objEmp.FirstName.Trim() + " " + objEmp.LastName.Trim();
    }

    public static void BuildMenu(Page myPage)
    {
        System.Web.UI.WebControls.Menu tbstr = (System.Web.UI.WebControls.Menu)myPage.Master.FindControl("Menu1");
        DataSet ds = (DataSet)myPage.Cache["SiteMapCache"];

        foreach (DataRow dr in ds.Tables[0].Rows)
        {
            int p = ds.Tables[0].Rows.Count;

            for (int k = 0; k < p; k++)
            {
                System.Web.UI.WebControls.MenuItem item = new System.Web.UI.WebControls.MenuItem();
                item.Text = dr["Text"].ToString();
                item.NavigateUrl = dr["NavigateUrl"].ToString();
                item.Value = dr["ID"].ToString();
                string Visibility = dr["visible"].ToString();
                if ((Visibility != null) && (Visibility != string.Empty))
                {
                    item.Selectable = false;
                    item.Enabled = Convert.ToBoolean(dr["visible"].ToString());
                }

                int col = (ds.Tables[0].Columns.Count) - 1;
                string strCol = dr["item_Id_0"].ToString();

                if (((dr["ID"].ToString() == "1000") || (dr["ID"].ToString() == "900") || (dr["ID"].ToString() == "800") || (dr["ID"].ToString() == "700") || (dr["ID"].ToString() == "600") || (dr["ID"].ToString() == "500") || (dr["ID"].ToString() == "400") || (dr["ID"].ToString() == "300") || (dr["ID"].ToString() == "200") || ((dr["ID"].ToString() == "100") || (dr["ID"].ToString() == string.Empty))) && (dr["Text"].ToString() != "Search"))
                {
                    tbstr.Items.Add(item);
                    break;
                }
                else if ((Convert.ToInt32(dr["ID"].ToString()) >= 100))
                {
                    if ((Convert.ToInt32(dr["ID"].ToString()) >= 200) && (Convert.ToInt32(dr["ID"].ToString()) < 300))
                    {
                        tbstr.Items[2].ChildItems.Add(item);
                        break;
                    }
                    else if ((Convert.ToInt32(dr["ID"].ToString()) >= 300) && (Convert.ToInt32(dr["ID"].ToString()) < 400))
                    {
                        tbstr.Items[3].ChildItems.Add(item);
                        break;
                    }
                    else if ((Convert.ToInt32(dr["ID"].ToString()) >= 400) && (Convert.ToInt32(dr["ID"].ToString()) < 500))
                    {
                        tbstr.Items[4].ChildItems.Add(item);
                        break;
                    }
                    else if ((Convert.ToInt32(dr["ID"].ToString()) >= 500) && (Convert.ToInt32(dr["ID"].ToString()) < 600))
                    {
                        tbstr.Items[5].ChildItems.Add(item);
                        break;
                    }
                    else if ((Convert.ToInt32(dr["ID"].ToString()) >= 600) && (Convert.ToInt32(dr["ID"].ToString()) < 700))
                    {
                        tbstr.Items[6].ChildItems.Add(item);
                        break;
                    }
                    else if ((Convert.ToInt32(dr["ID"].ToString()) >= 700) && (Convert.ToInt32(dr["ID"].ToString()) < 800))
                    {
                        tbstr.Items[7].ChildItems.Add(item);
                        break;
                    }
                    else if ((Convert.ToInt32(dr["ID"].ToString()) >= 800) && (Convert.ToInt32(dr["ID"].ToString()) < 900))
                    {
                        tbstr.Items[8].ChildItems.Add(item);
                        break;
                    }
                    else if ((Convert.ToInt32(dr["ID"].ToString()) >= 900) && (Convert.ToInt32(dr["ID"].ToString()) < 1000))
                    {
                        tbstr.Items[9].ChildItems.Add(item);
                        break;
                    }
                    else if ((Convert.ToInt32(dr["ID"].ToString()) >= 1000) && (Convert.ToInt32(dr["ID"].ToString()) < 1100))
                    {
                        tbstr.Items[10].ChildItems.Add(item);
                        break;
                    }
                    else
                    {
                        tbstr.Items[1].ChildItems.Add(item);
                        break;
                    }
                }
            }
        }
    }

    public static void ShowMenus_New(Page myPage, string userName, String AccessPages)
    {
        int MenuCount = 0;
        // Make all the tabs invisible        
        System.Web.UI.WebControls.Menu tbstr = (System.Web.UI.WebControls.Menu)myPage.Master.FindControl("Menu1");

        for (int i = 1; i < tbstr.Items.Count; i++)
        {
            MenuCount += tbstr.Items[i].ChildItems.Count;
            tbstr.Items[i].Enabled = false;
        }
        // Switch the visibility based on the actions available for the selected user


        string[] ScreenAccess_Array = AccessPages.Split(',');

        for (int i = 0; i < ScreenAccess_Array.Length; i++)
        {
            tbstr.Items[Int32.Parse(ScreenAccess_Array[i].Trim())].Enabled = true;
        }

        //Label lblUserName = (Label)myPage.Master.FindControl("lblUserName");
       // lblUserName.Text = "Welcome " + objEmp.FirstName.Trim() + " " + objEmp.LastName.Trim();
    }
}

