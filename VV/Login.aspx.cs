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
using System.Security.Principal;
using System.IO;
using Libraries.Entity;
using Libraries.Manager;
using System.Drawing;
using System.Web.Configuration;
using Microsoft.Practices.EnterpriseLibrary.Logging;
using System.Text;
using System.Collections.Generic;


namespace VV
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        //string userName1;
        //string UserLoginName;
        //int UserBadgeNumber;
        //DateTime DTime;
        string strDates = string.Empty;
        DataTable dt = new DataTable();
        DataSet newDS = new DataSet();

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                System.Web.UI.WebControls.Menu tbstr = (System.Web.UI.WebControls.Menu)Master.FindControl("Menu1");
                tbstr.Visible = false;

                txtUserName.Focus();

                //int imageID = 0;
                //imageID = 1000 + Convert.ToInt32(Math.Floor(50 * ((Random)Application["Random"]).NextDouble()));

                //FileInfo homeFileInfo = new FileInfo(Server.MapPath("Home.aspx"));
                //DirectoryInfo dinfoEmployee = new DirectoryInfo(homeFileInfo.Directory + @"\images\employees\");

                /* Added by Arun on 03-Jan'08
                 * This funtion will encrypt the connection string values,so that the user can't see the actual values
                 * Comment out the function, once it's encrypted & build the application again
                 */
                //EncryptAppSettings();

                /* Added by Arun on 03-Jan'08
                 * This funtion will Decrypt the encrypted connection string values,so that the Developer can see the actual values & change if he wants to do.
                 * Comment out the function, once it's Decrypted & build the application again
                 */
                //DecryptAppSettings();

                //if (!IsPostBack)
                //{
                //    WindowsPrincipal Pr = (WindowsPrincipal)HttpContext.Current.User;

                //    if (Pr.Identity.IsAuthenticated)
                //    {
                //        try
                //        {
                //            EmployeeManager objEmpMgr = new EmployeeManager();
                //            string strUs = "In-Increv\\Arun";       
                //           // Employee objEmpDetails = objEmpMgr.GetEmployeeForNTLogin(Pr.Identity.Name.ToString().Replace("\\", "\\\\").ToUpper());
                //            Employee objEmpDetails = objEmpMgr.GetEmployeeForNTLogin(strUs.ToString().Replace("\\", "\\\\").ToUpper());


                //            Session["LoggedOnUser"] = objEmpDetails;
                //            string userName = "Welcome " + objEmpDetails.FirstName.Trim() + " " + objEmpDetails.LastName.Trim();
                //            userName1 = objEmpDetails.FirstName.Trim() + " " + objEmpDetails.LastName.Trim();
                //            UserLoginName = "IN-INCREV" + @"\" + objEmpDetails.FirstName.Trim() + "." + objEmpDetails.LastName.Trim();
                //            UserBadgeNumber = objEmpDetails.BadgeNumber;

                //            //hidBadgeNumber.Value = objEmpDetails.BadgeNumber.ToString();

                //            System.Web.UI.WebControls.Menu tbstr = (System.Web.UI.WebControls.Menu)this.Page.Master.FindControl("Menu1");



                //            SecurityCheck.BuildMenu(this.Page);

                //            SecurityCheck.ShowMenus(this.Page, userName);
                //            DataSet proj = new DataSet();

                //            //Added by Rita Aiyar on 11/03/2008 
                //            ArrayList raList = (ArrayList)objEmpDetails.RoleActions;
                //            string strRole = String.Empty;

                //            for (int i = 0; i < raList.Count; i++)
                //            {
                //                if (((RoleActions)raList[i]).RoleId.Equals("4")) //Only the Admin can see all the records
                //                    strRole = "Admin";
                //                else if (((RoleActions)raList[i]).RoleId.Equals("2"))
                //                    strRole = "PM";
                //                else if (((RoleActions)raList[i]).RoleId.Equals("1"))
                //                    strRole = "Employee";
                //                else if (((RoleActions)raList[i]).RoleId.Equals("3"))
                //                    strRole = "HR";
                //            }

                //            //getToDoList(strRole);


                //        }
                //        catch (Exception ex)
                //        {
                //            throw ex;
                //        }
                //    }
                //    else
                //    {
                //        Exception ex = new Exception("User not authenticated, please check the IIS configuration");
                //        throw ex;
                //    }
                //}
            }
            catch (Exception ex)
            {
                Logger.Write(this.GetType().ToString() + " : Home - Page_Load() : " + " : " + DateTime.Now + " : " + ex.Message.ToString(), Category.General, Priority.Highest);
            }

        }

        /* Added by Arun on 03-Jan'08
         * This funtion will encrypt the connection string values,so that the user can't see the actual values
         */
        private void EncryptAppSettings()
        {
            try
            {
                Configuration objConfig = WebConfigurationManager.OpenWebConfiguration(Request.ApplicationPath);

                ConnectionStringsSection objAppsettings = (ConnectionStringsSection)objConfig.GetSection("connectionStrings");

                if (!objAppsettings.SectionInformation.IsProtected)
                {
                    objAppsettings.SectionInformation.ProtectSection("RsaProtectedConfigurationProvider");
                    objAppsettings.SectionInformation.ForceSave = true;
                    objConfig.Save(ConfigurationSaveMode.Modified);
                }
            }
            catch (Exception ex)
            {
                Logger.Write(this.GetType().ToString() + " : Home - EncryptAppSettings() : " + " : " + DateTime.Now + " : " + ex.Message.ToString(), Category.General, Priority.Highest);
            }
        }

        /* Added by Arun on 03-Jan'08
         * This funtion will Decrypt the encrypted connection string values,so that the Developer can see the actual values & change if he wants to do.
         */
        private void DecryptAppSettings()
        {
            try
            {
                Configuration objConfig = WebConfigurationManager.OpenWebConfiguration(Request.ApplicationPath);

                ConnectionStringsSection objAppsettings = (ConnectionStringsSection)objConfig.GetSection("connectionStrings");
                if (objAppsettings.SectionInformation.IsProtected)
                {
                    objAppsettings.SectionInformation.UnprotectSection();
                    objAppsettings.SectionInformation.ForceSave = true;
                    objConfig.Save(ConfigurationSaveMode.Modified);
                }
            }
            catch (Exception ex)
            {
                Logger.Write(this.GetType().ToString() + " : Home - DecryptAppSettings() : " + " : " + DateTime.Now + " : " + ex.Message.ToString(), Category.General, Priority.Highest);
            }
        }

        // Get the first day of the month for a month passed by it's integer value
        /* Changed by Arun on 13-Feb'08
         * The year was not getting populated correctly.
         * Say we are in year 2008, if we traverse to Dec'07, the year was still getting passed as 2008 only. 
         * Hence the Calendar was not poplutaed with correct data
         */
        private DateTime GetFirstDayOfMonth(int iMonth)
        {
            DateTime dtFrom = new DateTime(DateTime.Now.Year, iMonth, 1);
            try
            {
                int year = DateTime.Now.Year;

                if (iMonth > DateTime.Now.Month)
                {
                    dtFrom = dtFrom.AddYears(-1);
                }
            }
            catch (Exception ex)
            {
                Logger.Write(this.GetType().ToString() + " : Home - GetFirstDayOfMonth() : " + " : " + DateTime.Now + " : " + ex.Message.ToString(), Category.General, Priority.Highest);
            }
            return dtFrom;

        }

        // Get the last day of a month expressed by it's integer value
        private DateTime GetLastDayOfMonth(int iMonth)
        {
            // set return value to the last day of the month for any date passed in to the method create a datetime variable set to the passed in date
            DateTime dtTo = new DateTime(DateTime.Now.Year, iMonth, 1);
            try
            {
                // overshoot the date by a month
                dtTo = dtTo.AddMonths(1);
                // remove all of the days in the next month  to get bumped down to the last day of the previous month
                dtTo = dtTo.AddDays(-(dtTo.Day));
            }
            catch (Exception ex)
            {
                Logger.Write(this.GetType().ToString() + " : Home - GetLastDayOfMonth() : " + " : " + DateTime.Now + " : " + ex.Message.ToString(), Category.General, Priority.Highest);
            }
            // return the last day of the month
            return dtTo;
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {

            try
            {
                DBUtil _dbObj = new DBUtil();

                if (_dbObj.IsValidUser(txtUserName.Text.Trim(), txtPassword.Text.Trim()))
                {
                    Session["LoggedOnUser"] = txtUserName.Text.Trim();

                    DataSet ds_Menu = _dbObj.GetScreenAccessInfo(txtUserName.Text.Trim());

                    Session["ds_AccessPages"] = ds_Menu;

                    GenerateDictinoaryForYearAlphabetMapping();

                    DataSet ds_temp = _dbObj.GetItemGroupDataMapping();
                    Session["ItemGroupDataMapping"] = ds_temp;

                    Response.Redirect("~/Home.aspx");
                }
                else
                {
                    lblMessage.Visible = true;
                    lblMessage.Text = "Invalid Credentials";
                    txtPassword.Text = "";
                    txtUserName.Text = "";
                    //Response.Redirect("Login.aspx");
                }
            }
            catch(Exception ex)
            {
                lblMessage.Visible = true;
                lblMessage.Text = ex.Message.ToString();
                txtPassword.Text = "";
                txtUserName.Text = "";
            }
        }

        protected void btnCancell_Click(object sender, EventArgs e)
        {

        }

        protected void GenerateDictinoaryForYearAlphabetMapping()
        {
            Dictionary<int, string> dictionary_Year_Alphabet = new Dictionary<int, string>();
            dictionary_Year_Alphabet.Add(2015, "D");
            dictionary_Year_Alphabet.Add(2016, "E");
            dictionary_Year_Alphabet.Add(2017, "F");
            dictionary_Year_Alphabet.Add(2018, "G");
            dictionary_Year_Alphabet.Add(2019, "H");
            dictionary_Year_Alphabet.Add(2020, "I");
            dictionary_Year_Alphabet.Add(2021, "J");
            dictionary_Year_Alphabet.Add(2022, "K");
            dictionary_Year_Alphabet.Add(2023, "L");
            dictionary_Year_Alphabet.Add(2024, "M");

            Session["YearAlphabetDictionary"] = dictionary_Year_Alphabet;
        }

    }
}