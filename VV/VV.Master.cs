using Libraries.Entity;
using Microsoft.Practices.EnterpriseLibrary.Logging;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;

namespace VV
{
    public partial class VV : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //string UserName = (String)HttpContext.Current.Session["LoggedOnUser"];
            //Label lblUserName = (Label)this.Page.Master.FindControl("lblUserName");
            //lblUserName.Text = "Welcome " + UserName;


        }

        protected void lnkBtnMyProfile_Click(object sender, EventArgs e)
        {
            Response.Redirect("MyProfile.aspx");
        }

        protected void lnkBtnLogout_Click(object sender, EventArgs e)
        {
            HttpContext.Current.Session.Abandon();
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            //Session.Abandon(); //- See more at: http://codeverge.com/asp.net.state-management/kill-session-and-clear-local-browser/309617#sthash.L1F3U5J6.dpuf

            Response.Redirect("Login.aspx");
        }

        protected void NavigationMenu_MenuItemClick(Object sender, MenuEventArgs e)
        {
            try
            {
                DBUtil _dbObj = new DBUtil();

                DataSet ds;

                if (e.Item.Value.Equals("Order status Report"))
                {
                    ds = _dbObj.GetReportData("ORDERSTATUS");
                    Convert(ds, "Order_Status_Report");
                }
                else if (e.Item.Value.Equals("WIP Report"))
                {
                    ds = _dbObj.GetReportData("WIP");
                    Convert(ds, "WIP_Report");
                }
                else if (e.Item.Value.Equals("ToRelease Report"))
                {
                    ds = _dbObj.GetReportData("TORELEASE");
                    Convert(ds, "ToRelease_Report");
                }
                else if (e.Item.Value.Equals("TPI Pending Report"))
                {
                    ds = _dbObj.GetReportData("TPIPENDING");
                    Convert(ds, "TPIPending_Report");
                }
                else if (e.Item.Value.Equals("SO BackLog Report"))
                {
                    ds = _dbObj.GetReportData("SOBACKLOG");
                    Convert(ds, "SO_BackLog_Report");
                }
                else if (e.Item.Value.Equals("Ready To Release Report"))
                {
                    ds = _dbObj.GetReportData("SOREADYTORELEASE");
                    Convert(ds, "SO_ReadyToRelease_Report");
                }
                else if (e.Item.Value.Equals("Shortage Report"))
                {
                    ds = _dbObj.GetReportData("SOSHORTAGE");
                    Convert(ds, "SO_SHORTAGE_Report");
                }

                //// Display the selected menu item.
                //if (e.Item.Parent != null)
                //{
                //   // Message.Text = "You selected " + e.Item.Value + " from " + e.Item.Parent.Value + ".";
                //}
                //else
                //{
                //  //  Message.Text = "You selected " + e.Item.Value + ".";
                //}
            }
            catch (Exception ex)
            {
                Logger.Write(this.GetType().ToString() + " NavigationMenu_MenuItemClick : " + " : " + DateTime.Now + " : " + ex.Message.ToString(), Category.General, Priority.Highest);
                throw ex;
            }
        }

        public void Convert(DataSet ds, string fileName)
        {
            Convert(ds.Tables, fileName);
        }
        
        public void Convert(IEnumerable tables, string fileName)
        {
            try
            {
                Response.ClearContent();
                Response.ClearHeaders();
                Response.Buffer = true;
                Response.Charset = "";
                Response.ContentType = "application/vnd.ms-excel";
                Response.AddHeader("content-disposition",
                         "attachment; filename=" + fileName + ".xls");

                using (XmlTextWriter x = new XmlTextWriter(Response.OutputStream, Encoding.UTF8))
                {
                    int sheetNumber = 0;
                    x.WriteRaw("<?xml version=\"1.0\"?><?mso-application progid=\"Excel.Sheet\"?>");
                    x.WriteRaw("<Workbook xmlns=\"urn:schemas-microsoft-com:office:spreadsheet\" ");
                    x.WriteRaw("xmlns:o=\"urn:schemas-microsoft-com:office:office\" ");
                    x.WriteRaw("xmlns:x=\"urn:schemas-microsoft-com:office:excel\">");
                    x.WriteRaw("<Styles><Style ss:ID='sText'>" +
                               "<NumberFormat ss:Format='@'/></Style>");
                    x.WriteRaw("<Style ss:ID='sDate'><NumberFormat" +
                               " ss:Format='[$-409]m/d/yy\\ h:mm\\ AM/PM;@'/>");
                    x.WriteRaw("</Style></Styles>");
                    foreach (DataTable dt in tables)
                    {
                        sheetNumber++;
                        string sheetName = !string.IsNullOrEmpty(dt.TableName) ?
                               dt.TableName : "Sheet" + sheetNumber.ToString();
                        x.WriteRaw("<Worksheet ss:Name='" + sheetName + "'>");
                        x.WriteRaw("<Table>");
                        string[] columnTypes = new string[dt.Columns.Count];

                        for (int i = 0; i < dt.Columns.Count; i++)
                        {
                            string colType = dt.Columns[i].DataType.ToString().ToLower();

                            if (colType.Contains("datetime"))
                            {
                                columnTypes[i] = "DateTime";
                                x.WriteRaw("<Column ss:StyleID='sDate'/>");

                            }
                            else if (colType.Contains("string"))
                            {
                                columnTypes[i] = "String";
                                x.WriteRaw("<Column ss:StyleID='sText'/>");

                            }
                            else
                            {
                                x.WriteRaw("<Column />");

                                if (colType.Contains("boolean"))
                                {
                                    columnTypes[i] = "Boolean";
                                }
                                else
                                {
                                    //default is some kind of number.
                                    columnTypes[i] = "Number";
                                }

                            }
                        }
                        //column headers
                        x.WriteRaw("<Row>");
                        foreach (DataColumn col in dt.Columns)
                        {
                            x.WriteRaw("<Cell ss:StyleID='sText'><Data ss:Type='String'>");
                            x.WriteRaw(col.ColumnName);
                            x.WriteRaw("</Data></Cell>");
                        }
                        x.WriteRaw("</Row>");
                        //data
                        bool missedNullColumn = false;
                        foreach (DataRow row in dt.Rows)
                        {
                            x.WriteRaw("<Row>");
                            for (int i = 0; i < dt.Columns.Count; i++)
                            {
                                if (!row.IsNull(i))
                                {
                                    if (missedNullColumn)
                                    {
                                        int displayIndex = i + 1;
                                        x.WriteRaw("<Cell ss:Index='" + displayIndex.ToString() +
                                                   "'><Data ss:Type='" +
                                                   columnTypes[i] + "'>");
                                        missedNullColumn = false;
                                    }
                                    else
                                    {
                                        x.WriteRaw("<Cell><Data ss:Type='" +
                                                   columnTypes[i] + "'>");
                                    }

                                    switch (columnTypes[i])
                                    {
                                        case "DateTime":
                                            x.WriteRaw(((DateTime)row[i]).ToString("s"));
                                            break;
                                        case "Boolean":
                                            x.WriteRaw(((bool)row[i]) ? "1" : "0");
                                            break;
                                        case "String":
                                            x.WriteString(row[i].ToString());
                                            break;
                                        default:
                                            x.WriteString(row[i].ToString());
                                            break;
                                    }

                                    x.WriteRaw("</Data></Cell>");
                                }
                                else
                                {
                                    missedNullColumn = true;
                                }
                            }
                            x.WriteRaw("</Row>");
                        }
                        x.WriteRaw("</Table></Worksheet>");
                    }
                    x.WriteRaw("</Workbook>");
                }
                Response.End();
            }
            catch(Exception ex)
            {
                Logger.Write(this.GetType().ToString() + " : Convert - Report Generation : " + " : " + DateTime.Now + " : " + ex.Message.ToString(), Category.General, Priority.Highest);
                throw ex;
            }
        }
    }
}