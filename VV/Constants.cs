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
using System.Web.Caching;
using System.Data.SqlClient;
using VV.ServiceGateway;

namespace VV
{
    public class Constants
    {
        static string CommandText = string.Empty;

        public void MenuAccess(Page myPage)
        {
            try
            {
                DataSet ds_Menu = (DataSet)HttpContext.Current.Session["ds_AccessPages"];

                System.Web.UI.WebControls.Menu tbstr = (System.Web.UI.WebControls.Menu)myPage.Master.FindControl("Menu1");

                for (int i = 0; i < ds_Menu.Tables[0].Rows.Count; i++)
                {
                    String MenuName = ds_Menu.Tables[0].Rows[i]["MenuName"].ToString().Trim();
                    int MenuID = Int32.Parse(ds_Menu.Tables[0].Rows[i]["MenuID"].ToString().Trim());

                    String ParentMenuName = ds_Menu.Tables[0].Rows[i]["ParentMenuName"].ToString().Trim();
                    int ParentMenuID = Int32.Parse(ds_Menu.Tables[0].Rows[i]["ParentMenuID"].ToString().Trim());

                    if (ParentMenuID == 1) // Planning
                    {
                        tbstr.Items[ParentMenuID].Enabled = true;

                        if (MenuID == 0) // Import from BaaN to be changed as Import SO Backlog
                            tbstr.Items[ParentMenuID].ChildItems[MenuID].Enabled = true;
                        else if (MenuID == 1) // Production Release
                            tbstr.Items[ParentMenuID].ChildItems[MenuID].Enabled = true;
                        else if (MenuID == 2) // Invoiced Data Import
                            tbstr.Items[ParentMenuID].ChildItems[MenuID].Enabled = true;
                    }
                }
                
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static string GetExtension(string Extension)
        {
            string excelConnection = string.Empty;

            switch (Extension)
            {
                case ".xls": //Excel 97-03
                    excelConnection = BaseConfig.excelFor03;
                    CommandText = "spx_ImportFromExcel03";
                    break;
                case ".xlsx": //Excel 07
                    excelConnection = BaseConfig.excelFor07;
                    CommandText = "spx_ImportFromExcel07";
                    break;
            }

            return excelConnection;
        }
    }
}
