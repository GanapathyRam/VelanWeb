using Libraries.Entity;
using Microsoft.Practices.EnterpriseLibrary.Logging;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Web;

namespace VV
{
    public class DBUtil
    {
        SqlConnection conn;

        /// <summary>
        /// Initialises the SQL Connection & also opens the Connection
        /// </summary>
        private void init()
        {
            try
            {
                conn = new SqlConnection(ConfigurationManager.ConnectionStrings["VVConnection"].ToString());
                conn.Open();
            }
            catch (Exception ex)
            {
                Logger.Write(this.GetType().ToString() + " : init() : " + " : " + DateTime.Now + " : " + ex.Message.ToString(), Category.General, Priority.Highest);
            }
        }

        /// <summary>
        /// Checks if the User is a validUser or not
        /// </summary>
        /// <param name="UserName"></param>
        /// <param name="Password"></param>
        /// <returns></returns>
        public bool IsValidUser(String UserName, String Password)
        {
            bool isValidUser = false;
            DataSet ds = new DataSet();
            try
            {
                this.init();

                SqlCommand cmd = new SqlCommand("spGetLogin", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add(new SqlParameter("@UserName", UserName));
                cmd.Parameters.Add(new SqlParameter("@Password", Password));

                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = cmd;

                da.Fill(ds);


                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        if (ds.Tables[0].Rows[0][0].ToString().Trim().Equals("1"))
                            isValidUser = false;
                        else
                            isValidUser = true;
                    }
                }

                conn.Close();
                return isValidUser;
            }
            catch (Exception ex)
            {
                conn.Close();
                Logger.Write(this.GetType().ToString() + " : IsValidUser : " + " : " + DateTime.Now + " : " + ex.Message.ToString(), Category.General, Priority.Highest);
                throw ex;
            }
        }

        /// <summary>
        /// Gets the list of accessible screens for this User
        /// </summary>
        /// <param name="UserName"></param>
        /// <param name="Password"></param>
        /// <returns></returns>
        public DataSet GetScreenAccessInfo(String UserName)
        {
            DataSet ds = new DataSet();
            try
            {
                this.init();

                SqlCommand cmd = new SqlCommand("spGetScreenAccessInfo", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add(new SqlParameter("@UserName", UserName));

                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = cmd;

                da.Fill(ds);

                conn.Close();

                return ds;
            }
            catch (Exception ex)
            {
                conn.Close();
                Logger.Write(this.GetType().ToString() + " : GetScreenAccessInfo : " + " : " + DateTime.Now + " : " + ex.Message.ToString(), Category.General, Priority.Highest);
                throw ex;
            }
        }

        /// <summary>
        /// Does a bulk ingestion of the BaaN data into the Database
        /// </summary>
        /// <param name="ds"></param>
        public void BulkIngestIntoDatabase(DataSet ds)
        {
            try
            {
                this.init();

                using (SqlBulkCopy copy = new SqlBulkCopy(conn))
                {
                    copy.ColumnMappings.Add(0, "OrderType");
                    copy.ColumnMappings.Add(1, "OrderNo");
                    copy.ColumnMappings.Add(2, "CustomerName");
                    copy.ColumnMappings.Add(3, "CustomerOrderNo");
                    copy.ColumnMappings.Add(4, "LineNum");
                    copy.ColumnMappings.Add(5, "Pos");
                    copy.ColumnMappings.Add(6, "Item");
                    copy.ColumnMappings.Add(7, "Description");
                    copy.ColumnMappings.Add(8, "ItemGroup");
                    copy.ColumnMappings.Add(9, "ValveSpare");
                    copy.ColumnMappings.Add(10, "SalesOrderRevision");
                    copy.ColumnMappings.Add(11, "RevisionDate");
                    copy.ColumnMappings.Add(12, "Area");
                    copy.ColumnMappings.Add(13, "OrderDate");
                    copy.ColumnMappings.Add(14, "OriginalPromDate");
                    copy.ColumnMappings.Add(15, "PlannedDelDate");
                    copy.ColumnMappings.Add(16, "OrderQty");
                    copy.ColumnMappings.Add(17, "BalanceQty");
                    copy.ColumnMappings.Add(18, "Amount");
                    copy.ColumnMappings.Add(19, "InvoicedQty");
                    copy.ColumnMappings.Add(20, "FGQty");
                    copy.ColumnMappings.Add(21, "WIPQty");
                    copy.ColumnMappings.Add(22, "RelDate");
                    copy.ColumnMappings.Add(23, "ProdCompletionDate");
                    copy.ColumnMappings.Add(24, "ProdRemarks");
                    copy.ColumnMappings.Add(25, "PlanWeek");
                    copy.ColumnMappings.Add(26, "WIPWeek");
                    copy.ColumnMappings.Add(27, "FGWeek");
                    copy.ColumnMappings.Add(28, "ToReleaseQty");

                    copy.DestinationTableName = "MISOrderStatus";
                    copy.WriteToServer(ds.Tables[0]);
                }
                conn.Close();
            }
            catch (Exception ex)
            {
                conn.Close();
                Logger.Write(this.GetType().ToString() + " : BulkIngestIntoDatabase : " + " : " + DateTime.Now + " : " + ex.Message.ToString(), Category.General, Priority.Highest);
                throw ex;
            }
        }

        /// <summary>
        /// To retreive the data from MISOrderStatus table
        /// </summary>
        /// <returns></returns>
        public DataSet RetrieveBaaNData()
        {
            DataSet ds = new DataSet();
            try
            {
                this.init();

                SqlCommand cmd = new SqlCommand("spGetBaanData", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = cmd;

                da.Fill(ds);

                conn.Close();
                return ds;
            }
            catch (Exception ex)
            {
                conn.Close();
                Logger.Write(this.GetType().ToString() + " : RetrieveBaaNData() : " + " : " + DateTime.Now + " : " + ex.Message.ToString(), Category.General, Priority.Highest);
                throw ex;
            }
        }

        /// <summary>
        /// Method to Insert the Records into the Prod Rlease Data Table
        /// </summary>
        /// <param name="OrderNum"></param>
        /// <param name="LineNum"></param>
        /// <param name="Pos"></param>
        /// <param name="ProdOrderNo"></param>
        /// <param name="SerialNo"></param>
        /// <param name="ProdReleaseQty"></param>
        public void InsertProdutionReleaseData(int OrderNum, String LineNum, int Pos, String ProdOrderNo, String SerialNo, int ProdReleaseQty)
        {
            try
            {
                this.init();

                string UserName = (String)HttpContext.Current.Session["LoggedOnUser"];

                SqlCommand cmd = new SqlCommand("spInsProductionRelease", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add(new SqlParameter("@OrderNum", OrderNum));
                cmd.Parameters.Add(new SqlParameter("@LineNum", LineNum));
                cmd.Parameters.Add(new SqlParameter("@Pos", Pos));
                cmd.Parameters.Add(new SqlParameter("@ProdOrderNo", ProdOrderNo));
                cmd.Parameters.Add(new SqlParameter("@SerialNo", SerialNo));
                cmd.Parameters.Add(new SqlParameter("@ProdReleaseQty", ProdReleaseQty));
                cmd.Parameters.Add(new SqlParameter("@BalanceQty", ProdReleaseQty));
                cmd.Parameters.Add(new SqlParameter("@CreatedBy", UserName));
                cmd.Parameters.Add(new SqlParameter("@CreatedOn", DateTime.Now));
                cmd.Parameters.Add(new SqlParameter("@UpdatedBy", UserName));
                cmd.Parameters.Add(new SqlParameter("@UpdatedOn", DateTime.Now));

                cmd.ExecuteNonQuery();

                conn.Close();
            }
            catch (Exception ex)
            {
                conn.Close();
                Logger.Write(this.GetType().ToString() + " : ProdutionRelease() : " + " : " + DateTime.Now + " : " + ex.Message.ToString(), Category.General, Priority.Highest);
                throw ex;
            }
        }

        public DataSet GetMISOrderStatusForValveSpare(int OrderNo, int Pos)
        {
            DataSet ds = new DataSet();
            //var valveSpare = string.Empty;

            try
            {
                this.init();

                SqlCommand cmd = new SqlCommand("Select ValveSpare from MISOrderStatus where OrderNo = '" + OrderNo + "' and Pos = " + Pos + "", conn);
                cmd.CommandTimeout = 1000;
                cmd.CommandType = CommandType.Text;

                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = cmd;

                da.Fill(ds);

                conn.Close();
                return ds;
            }
            catch (Exception ex)
            {
                conn.Close();
                Logger.Write(this.GetType().ToString() + " : GetMISOrderStatusForValveSpare() : " + " : " + DateTime.Now + " : " + ex.Message.ToString(), Category.General, Priority.Highest);
                throw ex;
            }
        }

        /// <summary>
        /// Method to get the List of Ingested Records
        /// </summary>
        /// <param name="OrderNum"></param>
        /// <param name="LineNum"></param>
        /// <param name="Pos"></param>
        /// <param name="ProdOrderNo"></param>
        /// <returns></returns>
        public DataSet GetProductionReleasedData(int OrderNum, String LineNum, int Pos, String ProdOrderNo)
        {
            DataSet ds = new DataSet();
            try
            {
                this.init();

                SqlCommand cmd = new SqlCommand("spGetProductiionReleasedData", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add(new SqlParameter("@OrderNum", OrderNum));
                cmd.Parameters.Add(new SqlParameter("@LineNum", LineNum));
                cmd.Parameters.Add(new SqlParameter("@Pos", Pos));
                cmd.Parameters.Add(new SqlParameter("@ProdOrderNo", ProdOrderNo));

                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = cmd;

                da.Fill(ds);

                conn.Close();
                return ds;
            }
            catch (Exception ex)
            {
                conn.Close();
                Logger.Write(this.GetType().ToString() + " : GetProductionReleasedData : " + " : " + DateTime.Now + " : " + ex.Message.ToString(), Category.General, Priority.Highest);
                throw ex;
            }
        }

        /// <summary>
        /// Method to Update the ToRelease & WIP Qty in MISOrderStatus table  (Prod Release)
        /// </summary>
        /// <param name="OrderType"></param>
        /// <param name="OrderNum"></param>
        /// <param name="LineNum"></param>
        /// <param name="Pos"></param>
        /// <param name="ToReleaseQty"></param>
        /// <param name="WIPQty"></param>
        public void UpdateQtyInMISOrderStatusTableForProdRelease(String OrderType, int OrderNum, String LineNum, int Pos, int ToReleaseQty, int WIPQty)
        {
            try
            {
                this.init();

                SqlCommand cmd = new SqlCommand("spUpdateLogicForProdRelease", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add(new SqlParameter("@OrderType", OrderType)); //String
                cmd.Parameters.Add(new SqlParameter("@OrderNum", OrderNum)); // int
                cmd.Parameters.Add(new SqlParameter("@LineNum", LineNum)); // String
                cmd.Parameters.Add(new SqlParameter("@Pos", Pos)); // Int
                cmd.Parameters.Add(new SqlParameter("@ToReleaseQty", ToReleaseQty)); // int
                cmd.Parameters.Add(new SqlParameter("@WIPQty", WIPQty)); //int

                cmd.ExecuteNonQuery();

                conn.Close();
            }
            catch (Exception ex)
            {
                conn.Close();
                Logger.Write(this.GetType().ToString() + " : UpdateQtyInMISOrderStatusTableForProdRelease() : " + " : " + DateTime.Now + " : " + ex.Message.ToString(), Category.General, Priority.Highest);
                throw ex;
            }
        }

        /// <summary>
        /// Method to Update the FG & WIP Qty in MISOrderStatus table (WIP to FG)
        /// </summary>
        /// <param name="OrderType"></param>
        /// <param name="OrderNum"></param>
        /// <param name="LineNum"></param>
        /// <param name="Pos"></param>
        /// <param name="FGQty"></param>
        /// <param name="WIPQty"></param>
        public void UpdateQtyInMISOrderStatusTableForWIPToFG(String OrderType, int OrderNum, String LineNum, int Pos, int FGQty, int WIPQty)
        {
            try
            {
                // WIP = WIP - FG;
                // FG = FG + FG;

                this.init();

                SqlCommand cmd = new SqlCommand("spUpdateLogicForWIPToFG", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add(new SqlParameter("@OrderType", OrderType)); //String
                cmd.Parameters.Add(new SqlParameter("@OrderNum", OrderNum)); // int
                cmd.Parameters.Add(new SqlParameter("@LineNum", LineNum)); // String
                cmd.Parameters.Add(new SqlParameter("@Pos", Pos)); // Int
                cmd.Parameters.Add(new SqlParameter("@FGQty", FGQty)); // int
                cmd.Parameters.Add(new SqlParameter("@WIPQty", WIPQty)); //int

                cmd.ExecuteNonQuery();

                conn.Close();
            }
            catch (Exception ex)
            {
                conn.Close();
                Logger.Write(this.GetType().ToString() + " : UpdateQtyInMISOrderStatusTableForWIPToFG() : " + " : " + DateTime.Now + " : " + ex.Message.ToString(), Category.General, Priority.Highest);
                throw ex;
            }
        }

        /// <summary>
        /// Method to Update the Balance Qty in ProductionReleaseNew (WIP to FG)
        /// </summary>
        /// <param name="OrderNum"></param>
        /// <param name="LineNum"></param>
        /// <param name="Pos"></param>
        /// <param name="ProdOrderNo"></param>
        /// <param name="SerialNo"></param>
        /// <param name="BalanceQty"></param>
        public void UpdateBalanceQtyInProdOrderReleaseTableForWIPToFG(int OrderNum, String LineNum, int Pos, String ProdOrderNo, String SerialNo, int BalanceQty)
        {
            try
            {
                this.init();

                SqlCommand cmd = new SqlCommand("spUpdateProdRelease", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add(new SqlParameter("@OrderNum", OrderNum)); // int
                cmd.Parameters.Add(new SqlParameter("@LineNum", LineNum)); // String
                cmd.Parameters.Add(new SqlParameter("@Pos", Pos)); // Int
                cmd.Parameters.Add(new SqlParameter("@ProdOrderNo", ProdOrderNo)); // String

                if (!String.IsNullOrEmpty(SerialNo))
                    cmd.Parameters.Add(new SqlParameter("@SerialNo", SerialNo)); //String
                else
                    cmd.Parameters.Add(new SqlParameter("@SerialNo", string.Empty)); //String

                cmd.Parameters.Add(new SqlParameter("@BalanceQty", BalanceQty)); //int

                cmd.ExecuteNonQuery();

                conn.Close();
            }
            catch (Exception ex)
            {
                conn.Close();
                Logger.Write(this.GetType().ToString() + " : UpdateBalanceQtyInProdOrderReleaseTableForWIPToFG() : " + " : " + DateTime.Now + " : " + ex.Message.ToString(), Category.General, Priority.Highest);
                throw ex;
            }
        }

        /// <summary>
        /// To retreive the data from MISOrderStatus table
        /// </summary>
        /// <returns></returns>
        public DataSet RetrieveWIPData()
        {
            DataSet ds = new DataSet();
            try
            {
                this.init();

                SqlCommand cmd = new SqlCommand("spGetDataForWIPToFGConversion", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = cmd;

                da.Fill(ds);

                conn.Close();
                return ds;
            }
            catch (Exception ex)
            {
                conn.Close();
                Logger.Write(this.GetType().ToString() + " : RetrieveWIPData() : " + " : " + DateTime.Now + " : " + ex.Message.ToString(), Category.General, Priority.Highest);
                throw ex;
            }
        }

        /// <summary>
        /// Retrieves the Data for Prod Order Reversal
        /// </summary>
        /// <param name="ProdOrderNo"></param>
        /// <returns></returns>
        public DataSet RetrieveProdOrderReversalData(String ProdOrderNo)  //Order Reversal
        {
            DataSet ds = new DataSet();
            try
            {
                this.init();

                SqlCommand cmd = new SqlCommand("spGetDataForProdOrderReversal", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add(new SqlParameter("@ProdOrderNo", ProdOrderNo)); // String

                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = cmd;

                da.Fill(ds);

                conn.Close();
                return ds;
            }
            catch (Exception ex)
            {
                conn.Close();
                Logger.Write(this.GetType().ToString() + " : RetrieveProdOrderReversalData() : " + " : " + DateTime.Now + " : " + ex.Message.ToString(), Category.General, Priority.Highest);
                throw ex;
            }
        }

        public DataSet RetrieveProdOrderReversalDataForStores(String ProdOrderNo)  //Order Reversal
        {
            DataSet ds = new DataSet();
            try
            {
                this.init();

                SqlCommand cmd = new SqlCommand("spGetDataForProdOrderIssueForStores", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add(new SqlParameter("@ProdOrderNo", ProdOrderNo)); // String

                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = cmd;

                da.Fill(ds);

                conn.Close();
                return ds;
            }
            catch (Exception ex)
            {
                conn.Close();
                Logger.Write(this.GetType().ToString() + " : RetrieveProdOrderReversalDataForStores() : " + " : " + DateTime.Now + " : " + ex.Message.ToString(), Category.General, Priority.Highest);
                throw ex;
            }
        }

        public DataSet RetrieveProdOrderIssuesData()
        {
            DataSet ds = new DataSet();
            try
            {
                this.init();

                SqlCommand cmd = new SqlCommand("spGetDataForProdOrderIssue", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = cmd;

                da.Fill(ds);

                conn.Close();
                return ds;
            }
            catch (Exception ex)
            {
                conn.Close();
                Logger.Write(this.GetType().ToString() + " : RetrieveProdOrderIssuesData() : " + " : " + DateTime.Now + " : " + ex.Message.ToString(), Category.General, Priority.Highest);
                throw ex;
            }
        }

        public DataSet RetrieveProdOrderIssuesDataForExport()
        {
            DataSet ds = new DataSet();
            try
            {
                this.init();

                SqlCommand cmd = new SqlCommand("[spGetDataForProdOrderIssueExport]", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = cmd;

                da.Fill(ds);

                conn.Close();
                return ds;
            }
            catch (Exception ex)
            {
                conn.Close();
                Logger.Write(this.GetType().ToString() + " : RetrieveProdOrderIssuesDataForExport() : " + " : " + DateTime.Now + " : " + ex.Message.ToString(), Category.General, Priority.Highest);
                throw ex;
            }
        }

        public DataSet RetrieveProdOrderReversalDataForICSPOReversal(String ProdOrderNo)
        {
            DataSet ds = new DataSet();
            try
            {
                this.init();

                SqlCommand cmd = new SqlCommand("spGetDataForProdOrderReversalForIOCPoReversal", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add(new SqlParameter("@ProdOrderNo", ProdOrderNo)); // String

                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = cmd;

                da.Fill(ds);

                conn.Close();
                return ds;
            }
            catch (Exception ex)
            {
                conn.Close();
                Logger.Write(this.GetType().ToString() + " : RetrieveProdOrderReversalDataForICSPOReversal() : " + " : " + DateTime.Now + " : " + ex.Message.ToString(), Category.General, Priority.Highest);
                throw ex;
            }
        }

        /// <summary>
        /// Function to do the Production Order Reversal Process
        /// </summary>
        /// <param name="OrderNum"></param>
        /// <param name="LineNum"></param>
        /// <param name="Pos"></param>
        /// <param name="ProdOrderNo"></param>
        /// <param name="SerialNo"></param>
        public void ProductionOrderReversal(int OrderNum, String LineNum, int Pos, String ProdOrderNo, String SerialNo, int BalanceQty, string StoreIssued)
        {
            try
            {
                this.init();

                SqlCommand cmd = new SqlCommand("spProdOrderReversal", conn);
                cmd.CommandType = CommandType.StoredProcedure;


                cmd.Parameters.Add(new SqlParameter("@OrderNum", OrderNum)); // int
                cmd.Parameters.Add(new SqlParameter("@LineNum", LineNum)); // String
                cmd.Parameters.Add(new SqlParameter("@Pos", Pos)); // Int
                cmd.Parameters.Add(new SqlParameter("@ProdOrderNo", ProdOrderNo)); // String
                cmd.Parameters.Add(new SqlParameter("@SerialNo", SerialNo));
                cmd.Parameters.Add(new SqlParameter("@BalanceQty", BalanceQty)); // int
                cmd.Parameters.Add(new SqlParameter("@StoreIssued", StoreIssued));

                cmd.ExecuteNonQuery();

                conn.Close();
            }
            catch (Exception ex)
            {
                conn.Close();
                Logger.Write(this.GetType().ToString() + " : ProductionOrderReversal() : " + " : " + DateTime.Now + " : " + ex.Message.ToString(), Category.General, Priority.Highest);
                throw ex;
            }
        }

        public void UpdateProductionStoresIssued(int OrderNum, String LineNum, int Pos, String ProdOrderNo)
        {
            try
            {
                this.init();

                SqlCommand cmd = new SqlCommand("spUpdateProductionReleaseStoresIssued", conn);
                cmd.CommandType = CommandType.StoredProcedure;


                cmd.Parameters.Add(new SqlParameter("@OrderNum", OrderNum)); // int
                cmd.Parameters.Add(new SqlParameter("@LineNum", LineNum)); // String
                cmd.Parameters.Add(new SqlParameter("@Pos", Pos)); // Int
                cmd.Parameters.Add(new SqlParameter("@ProdOrderNo", ProdOrderNo)); // String
                //cmd.Parameters.Add(new SqlParameter("@SerialNo", SerialNo));

                cmd.ExecuteNonQuery();

                conn.Close();
            }
            catch (Exception ex)
            {
                conn.Close();
                Logger.Write(this.GetType().ToString() + " : UpdateProductionStoresIssued() : " + " : " + DateTime.Now + " : " + ex.Message.ToString(), Category.General, Priority.Highest);
                throw ex;
            }
        }

        public void ProductionOrderReversalForStores(int OrderNum, String LineNum, int Pos, String ProdOrderNo, int BalanceQty)
        {
            try
            {
                this.init();

                SqlCommand cmd = new SqlCommand("spProdOrderReversalForStores", conn);
                cmd.CommandType = CommandType.StoredProcedure;


                cmd.Parameters.Add(new SqlParameter("@OrderNum", OrderNum)); // int
                cmd.Parameters.Add(new SqlParameter("@LineNum", LineNum)); // String
                cmd.Parameters.Add(new SqlParameter("@Pos", Pos)); // Int
                cmd.Parameters.Add(new SqlParameter("@ProdOrderNo", ProdOrderNo)); // String
                cmd.Parameters.Add(new SqlParameter("@BalanceQty", BalanceQty)); // int

                cmd.ExecuteNonQuery();

                conn.Close();
            }
            catch (Exception ex)
            {
                conn.Close();
                Logger.Write(this.GetType().ToString() + " : ProductionOrderReversal() : " + " : " + DateTime.Now + " : " + ex.Message.ToString(), Category.General, Priority.Highest);
                throw ex;
            }
        }

        /// <summary>
        /// To get the Max SerialNo for the Input Combination
        /// </summary>
        /// <param name="InputNo"></param>
        /// <returns></returns>
        public String GetMaxSerialNo(String InputNo)
        {
            DataSet ds = new DataSet();
            try
            {
                this.init();

                SqlCommand cmd = new SqlCommand("spGetMaxSerialNo", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add(new SqlParameter("@SerialNo", InputNo));

                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = cmd;

                da.Fill(ds);

                conn.Close();

                if (ds.Tables[0].Rows.Count <= 0)
                    return "";
                else
                    return GetMaxSerialNoFromDataSet(ds);
            }
            catch (Exception ex)
            {
                conn.Close();
                Logger.Write(this.GetType().ToString() + " : GetMaxSerialNo() : " + " : " + DateTime.Now + " : " + ex.Message.ToString(), Category.General, Priority.Highest);
                throw ex;
            }
        }

        private string GetMaxSerialNoFromDataSet(DataSet ds)
        {
            string Output = "";
            try
            {
                ArrayList al = new ArrayList();

                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    al.Add(ds.Tables[0].Rows[i]["SerialNo"].ToString().Trim().Split('-')[1].Trim());

                al.Sort(new CustomComparer());

                Output = al[al.Count - 1].ToString();

                return Output;
            }
            catch (Exception ex)
            {
                Logger.Write(this.GetType().ToString() + " : GetMaxSerialNo() : " + " : " + DateTime.Now + " : " + ex.Message.ToString(), Category.General, Priority.Highest);
                throw ex;
            }
        }

        /// <summary>
        /// Get all the records from the ItemGroupMapping
        /// </summary>
        /// <returns></returns>
        public DataSet GetItemGroupDataMapping()
        {
            DataSet ds = new DataSet();
            try
            {
                this.init();

                SqlCommand cmd = new SqlCommand("spGetItemGroupMapping", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = cmd;

                da.Fill(ds);

                conn.Close();
                return ds;
            }
            catch (Exception ex)
            {
                conn.Close();
                Logger.Write(this.GetType().ToString() + " : GetItemGroupDataMapping() : " + " : " + DateTime.Now + " : " + ex.Message.ToString(), Category.General, Priority.Highest);
                throw ex;
            }
        }

        #region Planning
        public void InsertIntoBuyerMaster(String BuyerName, String Email)
        {
            try
            {
                this.init();

                string UserName = (String)HttpContext.Current.Session["LoggedOnUser"];

                SqlCommand cmd = new SqlCommand("spInsertBuyerMaster", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add(new SqlParameter("@BuyerName", BuyerName));
                cmd.Parameters.Add(new SqlParameter("@Email", Email));


                cmd.ExecuteNonQuery();

                conn.Close();
            }
            catch (Exception ex)
            {
                conn.Close();
                Logger.Write(this.GetType().ToString() + " : InsertIntoBuyerMaster() : " + " : " + DateTime.Now + " : " + ex.Message.ToString(), Category.General, Priority.Highest);
                throw ex;
            }
        }

        public void UpdateBuyerMaster(int Id, String BuyerName, String Email)
        {
            try
            {
                this.init();

                string UserName = (String)HttpContext.Current.Session["LoggedOnUser"];

                SqlCommand cmd = new SqlCommand("[spUpdateBuyerMaster]", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add(new SqlParameter("@Id", Id));
                cmd.Parameters.Add(new SqlParameter("@BuyerName", BuyerName));
                cmd.Parameters.Add(new SqlParameter("@Email", Email));


                cmd.ExecuteNonQuery();

                conn.Close();
            }
            catch (Exception ex)
            {
                conn.Close();
                Logger.Write(this.GetType().ToString() + " : UpdateBuyerMaster() : " + " : " + DateTime.Now + " : " + ex.Message.ToString(), Category.General, Priority.Highest);
                throw ex;
            }
        }

        public void DeleteIntoBuyerMaster(String BuyerName , int Id)
        {
            try
            {
                this.init();

                string UserName = (String)HttpContext.Current.Session["LoggedOnUser"];

                SqlCommand cmd = new SqlCommand("[spDeleteBuyerMasterDetails]", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add(new SqlParameter("@Id", Id));
                cmd.Parameters.Add(new SqlParameter("@BuyerName", BuyerName));

                cmd.ExecuteNonQuery();

                conn.Close();
            }
            catch (Exception ex)
            {
                conn.Close();
                Logger.Write(this.GetType().ToString() + " : DeleteIntoBuyerMaster() : " + " : " + DateTime.Now + " : " + ex.Message.ToString(), Category.General, Priority.Highest);
                throw ex;
            }
        }

        public DataSet RetriveByBuyerMasterDetails()
        {
            DataSet ds = new DataSet();
            try
            {
                this.init();

                SqlCommand cmd = new SqlCommand("[spGetBuyerMaster]", conn);
                cmd.CommandTimeout = 1000;
                cmd.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = cmd;

                da.Fill(ds);

                conn.Close();
                return ds;

            }
            catch (Exception ex)
            {
                conn.Close();
                Logger.Write(this.GetType().ToString() + " : RetriveByBuyerMasterDetails() : " + " : " + DateTime.Now + " : " + ex.Message.ToString(), Category.General, Priority.Highest);
                throw ex;
            }
        }

        public void InsertIntoSupplierRemarks(String SupplierRemarks)
        {
            try
            {
                this.init();

                string UserName = (String)HttpContext.Current.Session["LoggedOnUser"];

                SqlCommand cmd = new SqlCommand("spInsertSupplierRemarks", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add(new SqlParameter("@SupplierRemarks", SupplierRemarks));

                cmd.ExecuteNonQuery();

                conn.Close();
            }
            catch (Exception ex)
            {
                conn.Close();
                Logger.Write(this.GetType().ToString() + " : InsertIntoSupplierRemarks() : " + " : " + DateTime.Now + " : " + ex.Message.ToString(), Category.General, Priority.Highest);
                throw ex;
            }
        }

        public void DeleteSupplierRemarks(String SupplierRemarks, int Id)
        {
            try
            {
                this.init();

                string UserName = (String)HttpContext.Current.Session["LoggedOnUser"];

                SqlCommand cmd = new SqlCommand("[spDeleteSupplierRemarks]", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add(new SqlParameter("@SupplierRemarks", SupplierRemarks));
                cmd.Parameters.Add(new SqlParameter("@Id", Id));

                cmd.ExecuteNonQuery();

                conn.Close();
            }
            catch (Exception ex)
            {
                conn.Close();
                Logger.Write(this.GetType().ToString() + " : DeleteSupplierRemarks() : " + " : " + DateTime.Now + " : " + ex.Message.ToString(), Category.General, Priority.Highest);
                throw ex;
            }
        }

        public DataSet RetriveBySupplierRemarks()
        {
            DataSet ds = new DataSet();
            try
            {
                this.init();

                SqlCommand cmd = new SqlCommand("[spGetSupplierRemarks]", conn);
                cmd.CommandTimeout = 1000;
                cmd.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = cmd;

                da.Fill(ds);

                conn.Close();
                return ds;

            }
            catch (Exception ex)
            {
                conn.Close();
                Logger.Write(this.GetType().ToString() + " : RetriveBySupplierRemarks() : " + " : " + DateTime.Now + " : " + ex.Message.ToString(), Category.General, Priority.Highest);
                throw ex;
            }
        }

        public DataSet RetriveByShortageItems()
        {
            DataSet ds = new DataSet();

            try
            {
                this.init();

                SqlCommand cmd = new SqlCommand("[spGetShortageDetails]", conn);
                cmd.CommandTimeout = 1000;
                cmd.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = cmd;

                da.Fill(ds);

                conn.Close();
                return ds;

            }
            catch (Exception ex)
            {
                //LogError(ex, "Exception from export button click!");
                conn.Close();
                Logger.Write(this.GetType().ToString() + " : RetriveByShortageItems() : " + " : " + DateTime.Now + " : " + ex.Message.ToString(), Category.General, Priority.Highest);
                throw ex;
            }
        }

        public DataSet RetriveByUpdatedOrderStatus()
        {
            DataSet ds = new DataSet();

            try
            {
                this.init();

                SqlCommand cmd = new SqlCommand("[spGetUpdatedOrderStatus]", conn);
                cmd.CommandTimeout = 1000;
                cmd.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = cmd;

                da.Fill(ds);

                conn.Close();
                return ds;

            }
            catch (Exception ex)
            {
                //LogError(ex, "Exception from export button click!");
                conn.Close();
                Logger.Write(this.GetType().ToString() + " : RetriveByUpdatedOrderStatus() : " + " : " + DateTime.Now + " : " + ex.Message.ToString(), Category.General, Priority.Highest);
                throw ex;
            }
        }

        public void UpdateOrderStatus(string CustomerName, int OrderNo, int Pos, DateTime? MaterialReceiptDate,
            DateTime? MachiningCompletionDate, DateTime? AssemblyReleaseDate, DateTime? TPI_1Date, DateTime? TPI_2Date, string Remarks, bool ReceiptActivity,
            bool MachiningActivity, bool AssemblyActivity, bool TPI_1Activity, bool TPI_2Activity, bool ReceiptNL, bool MachiningNL, bool AssemblyNL, bool TPI_1NL,
            bool TPI_2NL, bool chkReceipt, bool chkMachine, bool chkAssembly, bool chkTPI1, bool chkTPI2, bool chkReason)
        {
            try
            {
                this.init();

                SqlCommand cmd = new SqlCommand("[spUpdateOrderStatus]", conn);
                cmd.CommandType = CommandType.StoredProcedure;


                cmd.Parameters.Add(new SqlParameter("@CustomerName", CustomerName)); // int
                cmd.Parameters.Add(new SqlParameter("@OrderNo", OrderNo)); // String
                cmd.Parameters.Add(new SqlParameter("@Pos", Pos)); // Int
                cmd.Parameters.Add(new SqlParameter("@MaterialReceiptDate", MaterialReceiptDate)); // String
                cmd.Parameters.Add(new SqlParameter("@MachiningCompletionDate", MachiningCompletionDate));
                cmd.Parameters.Add(new SqlParameter("@AssemblyReleaseDate", AssemblyReleaseDate));
                cmd.Parameters.Add(new SqlParameter("@TPI_1Date", TPI_1Date));
                cmd.Parameters.Add(new SqlParameter("@TPI_2Date", TPI_2Date));
                cmd.Parameters.Add(new SqlParameter("@Remarks", Remarks));
                cmd.Parameters.Add(new SqlParameter("@ReceiptActivity", ReceiptActivity));
                cmd.Parameters.Add(new SqlParameter("@MachiningActivity", MachiningActivity));
                cmd.Parameters.Add(new SqlParameter("@AssemblyActivity", AssemblyActivity));
                cmd.Parameters.Add(new SqlParameter("@TPI_1Activity", TPI_1Activity));
                cmd.Parameters.Add(new SqlParameter("@TPI_2Activity", TPI_2Activity));
                cmd.Parameters.Add(new SqlParameter("@ReceiptNL", ReceiptNL));
                cmd.Parameters.Add(new SqlParameter("@MachiningNL", MachiningNL));
                cmd.Parameters.Add(new SqlParameter("@AssemblyNL", AssemblyNL));
                cmd.Parameters.Add(new SqlParameter("@TPI_1NL", TPI_1NL));
                cmd.Parameters.Add(new SqlParameter("@TPI_2NL", TPI_2NL));

                cmd.Parameters.Add(new SqlParameter("@IsReceipt", chkReceipt));
                cmd.Parameters.Add(new SqlParameter("@IsMachine", chkMachine));
                cmd.Parameters.Add(new SqlParameter("@IsAssembly", chkAssembly));
                cmd.Parameters.Add(new SqlParameter("@IsTPI1Date", chkTPI1));
                cmd.Parameters.Add(new SqlParameter("@IsTPI2Date", chkTPI2));
                cmd.Parameters.Add(new SqlParameter("@IsReason", chkReason));

                cmd.ExecuteNonQuery();

                conn.Close();
            }
            catch (Exception ex)
            {
                conn.Close();
                Logger.Write(this.GetType().ToString() + " : UpdateOrderStatus() : " + " : " + DateTime.Now + " : " + ex.Message.ToString(), Category.General, Priority.Highest);
                throw ex;
            }
        }

        /// <summary>
        /// To retreive the data from MISOrderStatus table
        /// </summary>
        /// <returns></returns>
        public DataSet RetrieveBulkReleaseData(string figureNumber)
        {
            DataSet ds = new DataSet();
            try
            {
                this.init();

                SqlCommand cmd = new SqlCommand("[spGetBulkReleaseData]", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add(new SqlParameter("@FigureNumber", figureNumber)); // String

                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = cmd;

                da.Fill(ds);

                conn.Close();
                return ds;
            }
            catch (Exception ex)
            {
                conn.Close();
                Logger.Write(this.GetType().ToString() + " : RetrieveBulkReleaseData() : " + " : " + DateTime.Now + " : " + ex.Message.ToString(), Category.General, Priority.Highest);
                throw ex;
            }
        }

        public DataSet RetriveBySupplierNameForViewSCM()
        {
            DataSet ds = new DataSet();
            try
            {
                this.init();

                SqlCommand cmd = new SqlCommand("[spGetSupplierNameForViewSCM]", conn);
                cmd.CommandTimeout = 1000;
                cmd.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = cmd;

                da.Fill(ds);

                conn.Close();
                return ds;

            }
            catch (Exception ex)
            {
                conn.Close();
                Logger.Write(this.GetType().ToString() + " : RetriveBySupplierNameForViewSCM() : " + " : " + DateTime.Now + " : " + ex.Message.ToString(), Category.General, Priority.Highest);
                throw ex;
            }
        }

        public DataSet RetriveByMISViewSCMFromSuppliers(int IsDueFor, string SupplierName, int IsSelectionFor)
        {
            DataSet ds = new DataSet();

            try
            {
                this.init();

                SqlCommand cmd = new SqlCommand("[spGetMISViewSCMDetails]", conn);
                cmd.CommandTimeout = 1000;
                cmd.CommandType = CommandType.StoredProcedure;
                //string UserName = (String)HttpContext.Current.Session["LoggedOnUser"];

                cmd.Parameters.Add(new SqlParameter("@IsDueFor", IsDueFor)); // Int
                cmd.Parameters.Add(new SqlParameter("@SupplierName", SupplierName)); //String
                cmd.Parameters.Add(new SqlParameter("@IsSelectionFor", IsSelectionFor));

                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = cmd;

                da.Fill(ds);

                conn.Close();
                return ds;

            }
            catch (Exception ex)
            {
                //LogError(ex, "Exception from export button click!");
                conn.Close();
                Logger.Write(this.GetType().ToString() + " : RetriveByMISViewSCMFromSuppliers() : " + " : " + DateTime.Now + " : " + ex.Message.ToString(), Category.General, Priority.Highest);
                throw ex;
            }
        }

        public DataSet ShowWeekWiseShortageReport(int Year, int Week)
        {
            DataSet ds = new DataSet();
            try
            {
                this.init();

                SqlCommand cmd = new SqlCommand("[WeekShortage]", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add(new SqlParameter("@Week", Week)); // Int
                cmd.Parameters.Add(new SqlParameter("@Year", Year)); // Int

                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = cmd;

                da.Fill(ds);

                conn.Close();
                return ds;
            }
            catch (Exception ex)
            {
                conn.Close();
                Logger.Write(this.GetType().ToString() + " : ShowWeekWiseShortageReport() : " + " : " + DateTime.Now + " : " + ex.Message.ToString(), Category.General, Priority.Highest);
                throw ex;
            }
        }

        #endregion

        #region MIS Sales
        /// <summary>
        /// To Ingest the Record into the MISSalesInputTable
        /// </summary>
        /// <param name="OrderNum"></param>
        /// <param name="LineNum"></param>
        /// <param name="Pos"></param>
        /// <param name="SAPCode"></param>
        /// <param name="StockCode"></param>
        /// <param name="O2"></param>
        /// <param name="H2"></param>
        /// <param name="IBR"></param>
        /// <param name="ASU"></param>
        /// <param name="TAGNo"></param>
        /// <param name="GADNo"></param>
        /// <param name="QCINo"></param>
        /// <param name="ReleaseDate"></param>
        public void InsertIntoMISSalesInput(int OrderNum, String LineNum, int Pos, String SAPCode, String StockCode, String O2, String H2, String IBR, String ASU, String TAGNo, String GADNo, String QCINo, String ReleaseDate,
            String Nace, String LowEmission, String OtherRequirment, String GADDate, String PODate, String ValueType)
        {
            try
            {
                this.init();

                string UserName = (String)HttpContext.Current.Session["LoggedOnUser"];

                SqlCommand cmd = new SqlCommand("spInsertMISSalesInput", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add(new SqlParameter("@OrderNum", OrderNum));
                cmd.Parameters.Add(new SqlParameter("@LineNum", LineNum));
                cmd.Parameters.Add(new SqlParameter("@Pos", Pos));
                cmd.Parameters.Add(new SqlParameter("@SAPCode", SAPCode));
                cmd.Parameters.Add(new SqlParameter("@StockCode", StockCode));
                cmd.Parameters.Add(new SqlParameter("@O2", O2));
                cmd.Parameters.Add(new SqlParameter("@H2", H2));
                cmd.Parameters.Add(new SqlParameter("@IBR", IBR));
                cmd.Parameters.Add(new SqlParameter("@ASU", ASU));
                cmd.Parameters.Add(new SqlParameter("@TAGNo", TAGNo));
                cmd.Parameters.Add(new SqlParameter("@GADNo", GADNo));
                cmd.Parameters.Add(new SqlParameter("@QCINo", QCINo));
                cmd.Parameters.Add(new SqlParameter("@ReleaseDate", ReleaseDate));
                cmd.Parameters.Add(new SqlParameter("@UserInfo", UserName));
                cmd.Parameters.Add(new SqlParameter("@CreatedDateTime", DateTime.Now));

                cmd.Parameters.Add(new SqlParameter("@Nace", Nace));
                cmd.Parameters.Add(new SqlParameter("@LowEmission", LowEmission));
                cmd.Parameters.Add(new SqlParameter("@OtherRequirements", OtherRequirment));
                cmd.Parameters.Add(new SqlParameter("@GADDate", GADDate));
                cmd.Parameters.Add(new SqlParameter("@PODate", PODate));
                cmd.Parameters.Add(new SqlParameter("@ValueType", ValueType));


                cmd.ExecuteNonQuery();

                conn.Close();
            }
            catch (Exception ex)
            {
                conn.Close();
                Logger.Write(this.GetType().ToString() + " : InsertIntoMISSalesInput() : " + " : " + DateTime.Now + " : " + ex.Message.ToString(), Category.General, Priority.Highest);
                throw ex;
            }
        }

        /// <summary>
        /// To update the SAPCode, StatusCode, O2, H2, IBR, ASU for the chosen record in the MISSalesInput table
        /// </summary>
        /// <param name="OrderNum"></param>
        /// <param name="LineNum"></param>
        /// <param name="Pos"></param>
        /// <param name="SAPCode"></param>
        /// <param name="StockCode"></param>
        /// <param name="O2"></param>
        /// <param name="H2"></param>
        /// <param name="IBR"></param>
        /// <param name="ASU"></param>
        public void UpdateMISSalesInput(int OrderNum, String LineNum, int Pos, String SAPCode, String StockCode, String O2, String H2, String IBR, String ASU, String TAGNo, String GADNo, String QCINo, String ReleaseDate,
            String Nace, String LowEmission, String OtherRequirment, String GADDate, String PODate, String ValueType)
        {
            try
            {
                this.init();

                string UserName = (String)HttpContext.Current.Session["LoggedOnUser"];

                SqlCommand cmd = new SqlCommand("spUpdateMISSalesInput", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add(new SqlParameter("@OrderNum", OrderNum));
                cmd.Parameters.Add(new SqlParameter("@LineNum", LineNum));
                cmd.Parameters.Add(new SqlParameter("@Pos", Pos));
                cmd.Parameters.Add(new SqlParameter("@SAPCode", SAPCode));
                cmd.Parameters.Add(new SqlParameter("@StockCode", StockCode));
                cmd.Parameters.Add(new SqlParameter("@O2", O2));
                cmd.Parameters.Add(new SqlParameter("@H2", H2));
                cmd.Parameters.Add(new SqlParameter("@IBR", IBR));
                cmd.Parameters.Add(new SqlParameter("@ASU", ASU));
                cmd.Parameters.Add(new SqlParameter("@TAGNo", TAGNo));
                cmd.Parameters.Add(new SqlParameter("@GADNo", GADNo));
                cmd.Parameters.Add(new SqlParameter("@QCINo", QCINo));
                cmd.Parameters.Add(new SqlParameter("@ReleaseDate", ReleaseDate));
                cmd.Parameters.Add(new SqlParameter("@UserInfo", UserName));
                cmd.Parameters.Add(new SqlParameter("@CreatedDateTime", DateTime.Now));

                cmd.Parameters.Add(new SqlParameter("@Nace", Nace));
                cmd.Parameters.Add(new SqlParameter("@LowEmission", LowEmission));
                cmd.Parameters.Add(new SqlParameter("@OtherRequirements", OtherRequirment));
                cmd.Parameters.Add(new SqlParameter("@GADDate", GADDate));
                cmd.Parameters.Add(new SqlParameter("@PODate", PODate));
                cmd.Parameters.Add(new SqlParameter("@ValueType", ValueType));

                cmd.ExecuteNonQuery();

                conn.Close();
            }
            catch (Exception ex)
            {
                conn.Close();
                Logger.Write(this.GetType().ToString() + " : UpdateMISSalesInput() : " + " : " + DateTime.Now + " : " + ex.Message.ToString(), Category.General, Priority.Highest);
                throw ex;
            }
        }

        /// <summary>
        /// Gets the Record info from the MISSalesInput table for the chosen record
        /// </summary>
        /// <param name="OrderNum"></param>
        /// <param name="LineNum"></param>
        /// <param name="Pos"></param>
        /// <returns></returns>
        public DataSet GetMISSalesInput(int OrderNum, String LineNum, int Pos)
        {
            DataSet ds = new DataSet();
            try
            {
                this.init();

                SqlCommand cmd = new SqlCommand("spGetMISSalesInput", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add(new SqlParameter("@OrderNum", OrderNum));
                cmd.Parameters.Add(new SqlParameter("@LineNum", LineNum));
                cmd.Parameters.Add(new SqlParameter("@Pos", Pos));

                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = cmd;

                da.Fill(ds);

                conn.Close();
                return ds;
            }
            catch (Exception ex)
            {
                conn.Close();
                Logger.Write(this.GetType().ToString() + " : GetMISSalesInput : " + " : " + DateTime.Now + " : " + ex.Message.ToString(), Category.General, Priority.Highest);
                throw ex;
            }
        }

        /// <summary>
        /// Get all the Records from the MISSalesInput table
        /// </summary>
        /// <returns></returns>
        public DataSet GetAllMISSalesInput()
        {
            DataSet ds = new DataSet();
            try
            {
                this.init();

                SqlCommand cmd = new SqlCommand("spGetAllMISSalesInput", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = cmd;

                da.Fill(ds);

                conn.Close();
                return ds;
            }
            catch (Exception ex)
            {
                conn.Close();
                Logger.Write(this.GetType().ToString() + " : GetAllMISSalesInput : " + " : " + DateTime.Now + " : " + ex.Message.ToString(), Category.General, Priority.Highest);
                throw ex;
            }
        }
        #endregion

        #region MIS Finance

        /// <summary>
        /// Ingest the Record into the MISFinanceInput Table
        /// </summary>
        /// <param name="OrderNum"></param>
        /// <param name="LineNum"></param>
        /// <param name="Pos"></param>
        /// <param name="ABG"></param>
        /// <param name="PBG"></param>
        /// <param name="RP"></param>
        public void InsertIntoMISFinanceInput(int OrderNum, String LineNum, int Pos, String ABG, String PBG, String RP)
        {
            try
            {
                this.init();

                string UserName = (String)HttpContext.Current.Session["LoggedOnUser"];

                SqlCommand cmd = new SqlCommand("spInsertMISFinanceInput", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add(new SqlParameter("@OrderNum", OrderNum));
                cmd.Parameters.Add(new SqlParameter("@LineNum", LineNum));
                cmd.Parameters.Add(new SqlParameter("@Pos", Pos));
                cmd.Parameters.Add(new SqlParameter("@ABG", ABG));
                cmd.Parameters.Add(new SqlParameter("@PBG", PBG));
                cmd.Parameters.Add(new SqlParameter("@RP", RP));
                cmd.Parameters.Add(new SqlParameter("@ITP", String.Empty));
                cmd.Parameters.Add(new SqlParameter("@ApprovedITP", String.Empty));
                cmd.Parameters.Add(new SqlParameter("@GAD", String.Empty));
                cmd.Parameters.Add(new SqlParameter("@ApprovedGAD", String.Empty));
                cmd.Parameters.Add(new SqlParameter("@Inspection1", String.Empty));
                cmd.Parameters.Add(new SqlParameter("@Inspection2", String.Empty));
                cmd.Parameters.Add(new SqlParameter("@UserInfo", UserName));
                cmd.Parameters.Add(new SqlParameter("@CreatedDateTime", DateTime.Now));

                cmd.ExecuteNonQuery();

                conn.Close();
            }
            catch (Exception ex)
            {
                conn.Close();
                Logger.Write(this.GetType().ToString() + " : InsertIntoMISFinanceInput() : " + " : " + DateTime.Now + " : " + ex.Message.ToString(), Category.General, Priority.Highest);
                throw ex;
            }
        }

        /// <summary>
        /// Updates the data in the MISFinanceInput Table
        /// </summary>
        /// <param name="OrderNum"></param>
        /// <param name="LineNum"></param>
        /// <param name="Pos"></param>
        /// <param name="ABG"></param>
        /// <param name="PBG"></param>
        /// <param name="RP"></param>
        public void UpdateMISFinanceInput(int OrderNum, String LineNum, int Pos, String ABG, String PBG, String RP)
        {
            try
            {
                this.init();

                string UserName = (String)HttpContext.Current.Session["LoggedOnUser"];

                SqlCommand cmd = new SqlCommand("spUpdateMISFinanceInput", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add(new SqlParameter("@OrderNum", OrderNum));
                cmd.Parameters.Add(new SqlParameter("@LineNum", LineNum));
                cmd.Parameters.Add(new SqlParameter("@Pos", Pos));
                cmd.Parameters.Add(new SqlParameter("@ABG", ABG));
                cmd.Parameters.Add(new SqlParameter("@PBG", PBG));
                cmd.Parameters.Add(new SqlParameter("@RP", RP));
                cmd.Parameters.Add(new SqlParameter("@ITP", String.Empty));
                cmd.Parameters.Add(new SqlParameter("@ApprovedITP", String.Empty));
                cmd.Parameters.Add(new SqlParameter("@GAD", String.Empty));
                cmd.Parameters.Add(new SqlParameter("@ApprovedGAD", String.Empty));
                cmd.Parameters.Add(new SqlParameter("@Inspection1", String.Empty));
                cmd.Parameters.Add(new SqlParameter("@Inspection2", String.Empty));
                cmd.Parameters.Add(new SqlParameter("@UserInfo", UserName));
                cmd.Parameters.Add(new SqlParameter("@CreatedDateTime", DateTime.Now));

                cmd.ExecuteNonQuery();

                conn.Close();
            }
            catch (Exception ex)
            {
                conn.Close();
                Logger.Write(this.GetType().ToString() + " : UpdateMISFinanceInput() : " + " : " + DateTime.Now + " : " + ex.Message.ToString(), Category.General, Priority.Highest);
                throw ex;
            }
        }

        /// <summary>
        /// Gets the Record info from the MISFinanceInput table for the chosen record
        /// </summary>
        /// <param name="OrderNum"></param>
        /// <param name="LineNum"></param>
        /// <param name="Pos"></param>
        /// <returns></returns>
        public DataSet GetMISFinanceInput(int OrderNum, String LineNum, int Pos)
        {
            DataSet ds = new DataSet();
            try
            {
                this.init();

                SqlCommand cmd = new SqlCommand("spGetMISFinanceInput", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add(new SqlParameter("@OrderNum", OrderNum));
                cmd.Parameters.Add(new SqlParameter("@LineNum", LineNum));
                cmd.Parameters.Add(new SqlParameter("@Pos", Pos));

                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = cmd;

                da.Fill(ds);

                conn.Close();
                return ds;
            }
            catch (Exception ex)
            {
                conn.Close();
                Logger.Write(this.GetType().ToString() + " : GetMISFinanceInput : " + " : " + DateTime.Now + " : " + ex.Message.ToString(), Category.General, Priority.Highest);
                throw ex;
            }
        }

        /// <summary>
        /// To retreive the data from MISOrderStatus table
        /// </summary>
        /// <returns></returns>
        public DataSet RetrieveBaaNDataForMISFinanceInput()
        {
            DataSet ds = new DataSet();
            try
            {
                this.init();

                SqlCommand cmd = new SqlCommand("spGetBaanDataForMISFinanceInput", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = cmd;

                da.Fill(ds);

                conn.Close();
                return ds;
            }
            catch (Exception ex)
            {
                conn.Close();
                Logger.Write(this.GetType().ToString() + " : RetrieveBaaNDataForMISFinanceInput() : " + " : " + DateTime.Now + " : " + ex.Message.ToString(), Category.General, Priority.Highest);
                throw ex;
            }
        }

        /// <summary>
        /// To get the List of Distinct OrderNo from MISFinanceInput
        /// </summary>
        /// <returns></returns>
        public DataSet GetAllOrderNoFromMISFinanceInput()
        {
            DataSet ds = new DataSet();
            try
            {
                this.init();

                SqlCommand cmd = new SqlCommand("spGetAllMISFinanceInput", conn);

                cmd.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = cmd;

                da.Fill(ds);

                conn.Close();
                return ds;
            }
            catch (Exception ex)
            {
                conn.Close();
                Logger.Write(this.GetType().ToString() + " : GetAllOrderNoFromMISFinanceInput : " + " : " + DateTime.Now + " : " + ex.Message.ToString(), Category.General, Priority.Highest);
                throw ex;
            }
        }
        # endregion

        # region Invoice Related
        /// <summary>
        /// To retreive the data from MISOrderStatus table for InvoiceData
        /// </summary>
        /// <returns></returns>
        public DataSet RetrieveBaaNDataForInvoice()
        {
            DataSet ds = new DataSet();
            try
            {
                this.init();

                SqlCommand cmd = new SqlCommand("spGetBaanDataForInvoice", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = cmd;

                da.Fill(ds);

                conn.Close();
                return ds;
            }
            catch (Exception ex)
            {
                conn.Close();
                Logger.Write(this.GetType().ToString() + " : RetrieveBaaNDataForInvoice() : " + " : " + DateTime.Now + " : " + ex.Message.ToString(), Category.General, Priority.Highest);
                throw ex;
            }
        }

        public DataSet RetrieveBaaNDataForInvoiceFromOrderNoAndPos(int OrderNo, int Pos)
        {
            DataSet ds = new DataSet();
            try
            {
                this.init();

                SqlCommand cmd = new SqlCommand("[spGetBaanDataByOrderNoAndPos]", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@OrderNum", OrderNo)); // int
                cmd.Parameters.Add(new SqlParameter("@Pos", Pos)); // Int

                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = cmd;

                da.Fill(ds);

                conn.Close();
                return ds;
            }
            catch (Exception ex)
            {
                conn.Close();
                Logger.Write(this.GetType().ToString() + " : RetrieveBaaNDataForInvoiceFromOrderNoAndPos() : " + " : " + DateTime.Now + " : " + ex.Message.ToString(), Category.General, Priority.Highest);
                throw ex;
            }
        }

        public void UpdateBaanDataByOrderNoAndPos(int OrderNum, int Pos, String Item, String Description,  DateTime OriginalPromDate, DateTime PlannedDelDate)
        {
            try
            {
                this.init();

                SqlCommand cmd = new SqlCommand("[spUpdateBaanDataByOrderNoAndPos]", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add(new SqlParameter("@OrderNum", OrderNum)); // int
                cmd.Parameters.Add(new SqlParameter("@Pos", Pos)); // Int
                cmd.Parameters.Add(new SqlParameter("@Item", Item)); // String
                cmd.Parameters.Add(new SqlParameter("@OriginalPromDate", OriginalPromDate)); //String
                cmd.Parameters.Add(new SqlParameter("@PlannedDelDate", PlannedDelDate)); // String
                cmd.ExecuteNonQuery();

                conn.Close();
            }
            catch (Exception ex)
            {
                conn.Close();
                Logger.Write(this.GetType().ToString() + " : UpdateBaaNDataInMISOrderStatus() : " + " : " + DateTime.Now + " : " + ex.Message.ToString(), Category.General, Priority.Highest);
                throw ex;
            }
        }

        public void InsertIntoBaanData(int OrderNum, int Pos, String Item, String Description, DateTime OriginalPromDate, DateTime PlannedDelDate)
        {
            try
            {
                this.init();

                SqlCommand cmd = new SqlCommand("[spUpdateBaanDataByOrderNoAndPos]", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add(new SqlParameter("@OrderNum", OrderNum)); // int
                cmd.Parameters.Add(new SqlParameter("@Pos", Pos)); // Int
                cmd.Parameters.Add(new SqlParameter("@Item", Item)); // String
                cmd.Parameters.Add(new SqlParameter("@OriginalPromDate", OriginalPromDate)); //String
                cmd.Parameters.Add(new SqlParameter("@PlannedDelDate", PlannedDelDate)); // String
                cmd.ExecuteNonQuery();

                conn.Close();
            }
            catch (Exception ex)
            {
                conn.Close();
                Logger.Write(this.GetType().ToString() + " : InsertIntoBaanData() : " + " : " + DateTime.Now + " : " + ex.Message.ToString(), Category.General, Priority.Highest);
                throw ex;
            }
        }

        /// <summary>
        /// Updates the FG, Balance, Invoice Qty in MISOrderStatus
        /// </summary>
        /// <param name="OrderNum"></param>
        /// <param name="LineNum"></param>
        /// <param name="Pos"></param>
        /// <param name="FGQty"></param>
        /// <param name="BalanceQty"></param>
        /// <param name="InvoicedQty"></param>
        public void UpdateQtyInMISForInvoice(int OrderNum, String LineNum, int Pos, int FGQty, int BalanceQty, int InvoicedQty)
        {
            try
            {
                this.init();

                SqlCommand cmd = new SqlCommand("spUpdateMISForInvoice", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add(new SqlParameter("@OrderNum", OrderNum)); // int
                cmd.Parameters.Add(new SqlParameter("@LineNum", LineNum)); // String
                cmd.Parameters.Add(new SqlParameter("@Pos", Pos)); // Int
                cmd.Parameters.Add(new SqlParameter("@FGQty", FGQty)); // Int
                cmd.Parameters.Add(new SqlParameter("@BalanceQty", BalanceQty)); // Int
                cmd.Parameters.Add(new SqlParameter("@InvoicedQty", InvoicedQty)); // Int

                cmd.ExecuteNonQuery();

                conn.Close();
            }
            catch (Exception ex)
            {
                conn.Close();
                Logger.Write(this.GetType().ToString() + " : UpdateQtyInMISForInvoice() : " + " : " + DateTime.Now + " : " + ex.Message.ToString(), Category.General, Priority.Highest);
                throw ex;
            }
        }

        /// <summary>
        /// Ingest the records into the Invoice Table
        /// </summary>
        /// <param name="OrderNum"></param>
        /// <param name="LineNum"></param>
        /// <param name="Pos"></param>
        /// <param name="DelQty"></param>
        /// <param name="InvoiceDate"></param>
        /// <param name="InvoiceNo"></param>
        /// <param name="IsSuccess"></param>
        public void InsertInvoiceData(int OrderNum, String LineNum, int Pos, String DelQty, String InvoiceDate, String InvoiceNo, bool IsSuccess)
        {
            try
            {
                this.init();

                string UserName = (String)HttpContext.Current.Session["LoggedOnUser"];

                SqlCommand cmd = new SqlCommand("spInsInvoice", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add(new SqlParameter("@OrderNum", OrderNum));
                cmd.Parameters.Add(new SqlParameter("@LineNum", LineNum));
                cmd.Parameters.Add(new SqlParameter("@Pos", Pos));
                cmd.Parameters.Add(new SqlParameter("@DelQty", DelQty));
                cmd.Parameters.Add(new SqlParameter("@InvoiceDate", InvoiceDate));
                cmd.Parameters.Add(new SqlParameter("@InvoiceNo", InvoiceNo));

                if (IsSuccess)
                    cmd.Parameters.Add(new SqlParameter("@IsSuccess", 1));
                else
                    cmd.Parameters.Add(new SqlParameter("@IsSuccess", 2));

                cmd.Parameters.Add(new SqlParameter("@UserInfo", UserName));
                cmd.Parameters.Add(new SqlParameter("@CreatedDateTime", DateTime.Now));

                cmd.ExecuteNonQuery();

                conn.Close();
            }
            catch (Exception ex)
            {
                conn.Close();
                Logger.Write(this.GetType().ToString() + " : InsertInvoiceData() : " + " : " + DateTime.Now + " : " + ex.Message.ToString(), Category.General, Priority.Highest);
                throw ex;
            }
        }

        /// <summary>
        /// To retreive the data from tblInvoice table
        /// </summary>
        /// <returns></returns>
        public DataSet RetrieveInvoiceData()
        {
            DataSet ds = new DataSet();
            try
            {
                this.init();

                SqlCommand cmd = new SqlCommand("spGetInvoiceData", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = cmd;

                da.Fill(ds);

                conn.Close();
                return ds;
            }
            catch (Exception ex)
            {
                conn.Close();
                Logger.Write(this.GetType().ToString() + " : RetrieveInvoiceData() : " + " : " + DateTime.Now + " : " + ex.Message.ToString(), Category.General, Priority.Highest);
                throw ex;
            }
        }
        # endregion

        # region ITP Related
        /// <summary>
        /// To retreive the data from MISOrderStatus & MISFinanceInput table for InvoiceData
        /// </summary>
        /// <returns></returns>
        public DataSet RetrieveITPData()
        {
            DataSet ds = new DataSet();
            try
            {
                this.init();

                SqlCommand cmd = new SqlCommand("spGetITPData", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = cmd;

                da.Fill(ds);

                conn.Close();
                return ds;
            }
            catch (Exception ex)
            {
                conn.Close();
                Logger.Write(this.GetType().ToString() + " : RetrieveITPData() : " + " : " + DateTime.Now + " : " + ex.Message.ToString(), Category.General, Priority.Highest);
                throw ex;
            }
        }

        /// <summary>
        /// Updates the data in the MISFinanceTable
        /// </summary>
        /// <param name="OrderNum"></param>
        /// <param name="LineNum"></param>
        /// <param name="Pos"></param>
        /// <param name="ITP"></param>
        /// <param name="ApprovedITP"></param>
        /// <param name="GAD"></param>
        /// <param name="ApprovedGAD"></param>
        /// <param name="Inspection1"></param>
        /// <param name="Inspection2"></param>
        public void UpdateMISFinanceInputForITP(int OrderNum, String LineNum, int Pos, String ITP, String ApprovedITP, String GAD, String ApprovedGAD, String Inspection1, String Inspection2)
        {
            try
            {
                this.init();

                SqlCommand cmd = new SqlCommand("spUpdateMISFinanceInputForITP", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                string UserName = (String)HttpContext.Current.Session["LoggedOnUser"];

                cmd.Parameters.Add(new SqlParameter("@OrderNum", OrderNum)); // int
                cmd.Parameters.Add(new SqlParameter("@LineNum", LineNum)); // String
                cmd.Parameters.Add(new SqlParameter("@Pos", Pos)); // Int
                cmd.Parameters.Add(new SqlParameter("@ITP", String.IsNullOrEmpty(ITP) ? String.Empty : ITP));
                cmd.Parameters.Add(new SqlParameter("@ApprovedITP", String.IsNullOrEmpty(ApprovedITP) ? String.Empty : ApprovedITP));
                cmd.Parameters.Add(new SqlParameter("@GAD", String.IsNullOrEmpty(GAD) ? String.Empty : GAD));
                cmd.Parameters.Add(new SqlParameter("@ApprovedGAD", String.IsNullOrEmpty(ApprovedGAD) ? String.Empty : ApprovedGAD));
                cmd.Parameters.Add(new SqlParameter("@Inspection1", String.IsNullOrEmpty(Inspection1) ? String.Empty : Inspection1));
                cmd.Parameters.Add(new SqlParameter("@Inspection2", String.IsNullOrEmpty(Inspection2) ? String.Empty : Inspection2));
                cmd.Parameters.Add(new SqlParameter("@UserInfo", UserName));
                cmd.Parameters.Add(new SqlParameter("@CreatedDateTime", DateTime.Now));

                cmd.ExecuteNonQuery();

                conn.Close();
            }
            catch (Exception ex)
            {
                conn.Close();
                Logger.Write(this.GetType().ToString() + " : UpdateMISFinanceInputForITP() : " + " : " + DateTime.Now + " : " + ex.Message.ToString(), Category.General, Priority.Highest);
                throw ex;
            }
        }
        #endregion

        #region Production Work Detail

        #region Prod Completion

        /// <summary>
        /// Gets the Prod Completion Data from the MISOrderStatus & ProdReleaseNew Tables
        /// </summary>
        /// <returns></returns>
        public DataSet RetrieveProdCompletionData()
        {
            DataSet ds = new DataSet();
            try
            {
                this.init();

                SqlCommand cmd = new SqlCommand("spGetProdCompletionData", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = cmd;

                da.Fill(ds);

                conn.Close();
                return ds;
            }
            catch (Exception ex)
            {
                conn.Close();
                Logger.Write(this.GetType().ToString() + " : RetrieveProdCompletionData() : " + " : " + DateTime.Now + " : " + ex.Message.ToString(), Category.General, Priority.Highest);
                throw ex;
            }
        }

        /// <summary>
        /// Update the Prod release New Table, for the Prod Completion
        /// </summary>
        /// <param name="OrderNum"></param>
        /// <param name="LineNum"></param>
        /// <param name="Pos"></param>
        /// <param name="ProdOrderNo"></param>
        /// <param name="SerialNo"></param>
        /// <param name="ProdDeliveryDate"></param>
        /// <param name="ProdComplDate"></param>
        /// <param name="ProdRemarks"></param>
        public void UpdateProdCompletion(int OrderNum, String LineNum, int Pos, String ProdOrderNo, String SerialNo, String ProdDeliveryDate, String ProdComplDate, String ProdRemarks)
        {
            try
            {
                this.init();

                SqlCommand cmd = new SqlCommand("spUpdateProdCompletion", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                string UserName = (String)HttpContext.Current.Session["LoggedOnUser"];

                cmd.Parameters.Add(new SqlParameter("@OrderNum", OrderNum)); // int
                cmd.Parameters.Add(new SqlParameter("@LineNum", LineNum)); // String
                cmd.Parameters.Add(new SqlParameter("@Pos", Pos)); // Int
                cmd.Parameters.Add(new SqlParameter("@ProdOrderNo", ProdOrderNo)); // String
                cmd.Parameters.Add(new SqlParameter("@SerialNo", SerialNo));

                cmd.Parameters.Add(new SqlParameter("@ProdDeliveryDate", String.IsNullOrEmpty(ProdDeliveryDate) ? String.Empty : ProdDeliveryDate));
                cmd.Parameters.Add(new SqlParameter("@ProdComplDate", String.IsNullOrEmpty(ProdComplDate) ? String.Empty : ProdComplDate));
                cmd.Parameters.Add(new SqlParameter("@ProdRemarks", String.IsNullOrEmpty(ProdRemarks) ? String.Empty : ProdRemarks));

                cmd.Parameters.Add(new SqlParameter("@UpdatedBy", UserName));
                cmd.Parameters.Add(new SqlParameter("@UpdatedOn", DateTime.Now));

                cmd.ExecuteNonQuery();

                conn.Close();
            }
            catch (Exception ex)
            {
                conn.Close();
                Logger.Write(this.GetType().ToString() + " : UpdateProdCompletion() : " + " : " + DateTime.Now + " : " + ex.Message.ToString(), Category.General, Priority.Highest);
                throw ex;
            }
        }

        /// <summary>
        /// To bulk update the Prod Cmompleteion
        /// </summary>
        /// <param name="ProdOrderNo"></param>
        /// <param name="SerialNo"></param>
        /// <param name="ProdDeliveryDate"></param>
        /// <param name="ProdComplDate"></param>
        /// <param name="ProdRemarks"></param>
        public void BulkUpdateProdCompletion(String ProdOrderNo, String SerialNo, String ProdDeliveryDate, String ProdComplDate, String ProdRemarks)
        {
            try
            {
                this.init();

                SqlCommand cmd = new SqlCommand("spBulkUpdateProdCompletion", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                string UserName = (String)HttpContext.Current.Session["LoggedOnUser"];

                cmd.Parameters.Add(new SqlParameter("@ProdOrderNo", ProdOrderNo)); // String
                cmd.Parameters.Add(new SqlParameter("@SerialNo", SerialNo));

                cmd.Parameters.Add(new SqlParameter("@ProdDeliveryDate", String.IsNullOrEmpty(ProdDeliveryDate) ? String.Empty : ProdDeliveryDate));
                cmd.Parameters.Add(new SqlParameter("@ProdComplDate", String.IsNullOrEmpty(ProdComplDate) ? String.Empty : ProdComplDate));
                cmd.Parameters.Add(new SqlParameter("@ProdRemarks", String.IsNullOrEmpty(ProdRemarks) ? String.Empty : ProdRemarks));

                cmd.Parameters.Add(new SqlParameter("@UpdatedBy", UserName));
                cmd.Parameters.Add(new SqlParameter("@UpdatedOn", DateTime.Now));

                cmd.ExecuteNonQuery();

                conn.Close();
            }
            catch (Exception ex)
            {
                conn.Close();
                Logger.Write(this.GetType().ToString() + " : BulkUpdateProdCompletion() : " + " : " + DateTime.Now + " : " + ex.Message.ToString(), Category.General, Priority.Highest);
                throw ex;
            }
        }

        public DataSet FetchHeatNoControlAndSerialNoFromProdPrderNo(string ProdOrderNo)
        {
            DataSet ds = new DataSet();

            try
            {
                this.init();

                SqlCommand cmd = new SqlCommand("Select * from ProductionReleaseNew where ProdOrderNo ='"+ProdOrderNo+"'", conn);
                cmd.CommandTimeout = 1000;
                cmd.CommandType = CommandType.Text;

                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = cmd;

                da.Fill(ds);

                conn.Close();
                return ds;
            }
            catch (Exception ex)
            {
                conn.Close();
                Logger.Write(this.GetType().ToString() + " : FetchHeatNoControl() : " + " : " + DateTime.Now + " : " + ex.Message.ToString(), Category.General, Priority.Highest);
                throw ex;
            }
        }

        # endregion

        # region TPI Offering

        /// <summary>
        /// Gets the TPI Offering Data from the MISOrderStatus & ProdReleaseNew Tables
        /// </summary>
        /// <returns></returns>
        public DataSet RetrieveTPIOfferingData()
        {
            DataSet ds = new DataSet();
            try
            {
                this.init();

                SqlCommand cmd = new SqlCommand("spGetTPIOfferingData", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = cmd;

                da.Fill(ds);

                conn.Close();
                return ds;
            }
            catch (Exception ex)
            {
                conn.Close();
                Logger.Write(this.GetType().ToString() + " : RetrieveTPIOfferingData() : " + " : " + DateTime.Now + " : " + ex.Message.ToString(), Category.General, Priority.Highest);
                throw ex;
            }
        }

        #region Functionality for Schedule Process
        public DataSet RetriveByProcessedItems()
        {
            DataSet ds = new DataSet();

            try
            {
                this.init();

                SqlCommand cmd = new SqlCommand("[spGetProcessOrders]", conn);
                cmd.CommandTimeout = 1000;
                cmd.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = cmd;

                da.Fill(ds);

                conn.Close();
                return ds;

            }
            catch (Exception ex)
            {
                //LogError(ex, "Exception from export button click!");
                conn.Close();
                Logger.Write(this.GetType().ToString() + " : spGetProcessOrders() : " + " : " + DateTime.Now + " : " + ex.Message.ToString(), Category.General, Priority.Highest);
                throw ex;
            }
        }

        public void UpdateWIPBalQuantity(String ProdOrderNo, String BalQuantity, String ItemNumber, String ItemDescription,
            String OrderedQty, String DeliveredQty, String StartDate, String FinishDate, String SupplierName)
        {
            try
            {
                this.init();

                SqlCommand cmd = new SqlCommand("spUpdateWIPBalQuantity", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                string UserName = (String)HttpContext.Current.Session["LoggedOnUser"];

                cmd.Parameters.Add(new SqlParameter("@ProdOrderNo", ProdOrderNo)); // String
                cmd.Parameters.Add(new SqlParameter("@BalQuantity", BalQuantity));
                cmd.Parameters.Add(new SqlParameter("@ItemNumber", ItemNumber));
                cmd.Parameters.Add(new SqlParameter("@ItemDescription", ItemDescription));
                cmd.Parameters.Add(new SqlParameter("@OrderedQty", OrderedQty));
                cmd.Parameters.Add(new SqlParameter("@DeliveredQty", DeliveredQty));
                cmd.Parameters.Add(new SqlParameter("@RemainingStartDate", StartDate));
                cmd.Parameters.Add(new SqlParameter("@EarliestFinishDate", FinishDate));
                cmd.Parameters.Add(new SqlParameter("@SupplierName", SupplierName));

                cmd.Parameters.Add(new SqlParameter("@UpdatedBy", UserName));
                cmd.Parameters.Add(new SqlParameter("@UpdatedOn", DateTime.Now));

                cmd.ExecuteNonQuery();

                conn.Close();
            }
            catch (Exception ex)
            {
                conn.Close();
                Logger.Write(this.GetType().ToString() + " : UpdateWIPBalQuantity() : " + " : " + DateTime.Now + " : " + ex.Message.ToString(), Category.General, Priority.Highest);
                throw ex;
            }
        }

        public void UpdatePOBalanceQuantity(String OrderNo, string PoPosition, String OrderBalance, String ItemNumber, String ItemDescription,
            String OrderedQty, String DeliveredQty, String PlanDelDate)
        {
            try
            {
                this.init();

                SqlCommand cmd = new SqlCommand("[spUpdatePOOrderBalance]", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                string UserName = (String)HttpContext.Current.Session["LoggedOnUser"];

                cmd.Parameters.Add(new SqlParameter("@OrderNo", OrderNo)); // String
                cmd.Parameters.Add(new SqlParameter("@OrderBalance", OrderBalance));
                cmd.Parameters.Add(new SqlParameter("@ItemNumber", ItemNumber));
                cmd.Parameters.Add(new SqlParameter("@ItemDescription", ItemDescription));
                cmd.Parameters.Add(new SqlParameter("@OrderedQty", OrderedQty));
                cmd.Parameters.Add(new SqlParameter("@DeliveredQty", DeliveredQty));
                cmd.Parameters.Add(new SqlParameter("@PlanDelDate", PlanDelDate));

                cmd.Parameters.Add(new SqlParameter("@PoPosition", PoPosition));
                cmd.Parameters.Add(new SqlParameter("@UpdatedBy", UserName));
                cmd.Parameters.Add(new SqlParameter("@UpdatedOn", DateTime.Now));

                cmd.ExecuteNonQuery();

                conn.Close();
            }
            catch (Exception ex)
            {
                conn.Close();
                Logger.Write(this.GetType().ToString() + " : UpdatePOBalanceQuantity() : " + " : " + DateTime.Now + " : " + ex.Message.ToString(), Category.General, Priority.Highest);
                throw ex;
            }
        }

        public void InsertWIPUploadItems(string ProdOrder, string PoSeries, string RelDate, string ItemNumber, string Description, string ShopSC, string Buyer,
            string SupplierCode, string SupplierName, string QtyOrd, string QtyDlv, string BalQuantity, string Wrh, string Project, string OrderStatus, string StartDate,
            string FinishDate, string Ageing, string AgeingRemarks)
        {
            try
            {
                this.init();

                SqlCommand cmd = new SqlCommand("spInsertWIPUploadItems", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                string UserName = (String)HttpContext.Current.Session["LoggedOnUser"];

                cmd.Parameters.Add(new SqlParameter("@ProdOrderNo", ProdOrder)); // String
                cmd.Parameters.Add(new SqlParameter("@PoSeries", PoSeries));
                cmd.Parameters.Add(new SqlParameter("@DelDate", RelDate));
                cmd.Parameters.Add(new SqlParameter("@ItemNumber", ItemNumber));
                cmd.Parameters.Add(new SqlParameter("@Description", Description));
                cmd.Parameters.Add(new SqlParameter("@ShopSC", ShopSC));
                cmd.Parameters.Add(new SqlParameter("@Buyer", Buyer));
                cmd.Parameters.Add(new SqlParameter("@SupplierCode", SupplierCode));
                cmd.Parameters.Add(new SqlParameter("@SupplierName", SupplierName));

                cmd.Parameters.Add(new SqlParameter("@QtyOrd", QtyOrd));
                cmd.Parameters.Add(new SqlParameter("@QtyDlv", QtyDlv));
                cmd.Parameters.Add(new SqlParameter("@BalQuantity", BalQuantity));
                cmd.Parameters.Add(new SqlParameter("@Wrh", Wrh));
                cmd.Parameters.Add(new SqlParameter("@Project", Project));
                cmd.Parameters.Add(new SqlParameter("@OrderStatus", OrderStatus));
                cmd.Parameters.Add(new SqlParameter("@StartDate", StartDate));
                cmd.Parameters.Add(new SqlParameter("@FinishDate", FinishDate));
                cmd.Parameters.Add(new SqlParameter("@Ageing", Ageing));
                cmd.Parameters.Add(new SqlParameter("@AgeingRemarks", AgeingRemarks));
                cmd.Parameters.Add(new SqlParameter("@CreatedBy", UserName));
                cmd.Parameters.Add(new SqlParameter("@CreatedOn", DateTime.Now));

                cmd.ExecuteNonQuery();

                conn.Close();
            }
            catch (Exception ex)
            {
                conn.Close();
                Logger.Write(this.GetType().ToString() + " : InsertWIPUploadItems() : " + " : " + DateTime.Now + " : " + ex.Message.ToString(), Category.General, Priority.Highest);
                throw ex;
            }
        }

        public void InsertWIPHistory(string ProdOrder, string PoSeries, string RelDate, string ItemNumber, string Description, string ShopSC, string Buyer,
            string SupplierCode, string SupplierName, string QtyOrd, string QtyDlv, string BalQuantity, string Wrh, string Project, string OrderStatus, string StartDate,
            string FinishDate, string Ageing, string AgeingRemarks, string Remarks, string RecDate)
        {
            try
            {
                this.init();

                SqlCommand cmd = new SqlCommand("spInsertWIPHistory", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                string UserName = (String)HttpContext.Current.Session["LoggedOnUser"];

                cmd.Parameters.Add(new SqlParameter("@ProdOrderNo", ProdOrder)); // String
                cmd.Parameters.Add(new SqlParameter("@PoSeries", PoSeries));
                cmd.Parameters.Add(new SqlParameter("@DelDate", RelDate));
                cmd.Parameters.Add(new SqlParameter("@ItemNumber", ItemNumber));
                cmd.Parameters.Add(new SqlParameter("@Description", Description));
                cmd.Parameters.Add(new SqlParameter("@ShopSC", ShopSC));
                cmd.Parameters.Add(new SqlParameter("@Buyer", Buyer));
                cmd.Parameters.Add(new SqlParameter("@SupplierCode", SupplierCode));
                cmd.Parameters.Add(new SqlParameter("@SupplierName", SupplierName));

                cmd.Parameters.Add(new SqlParameter("@QtyOrd", QtyOrd));
                cmd.Parameters.Add(new SqlParameter("@QtyDlv", QtyDlv));
                cmd.Parameters.Add(new SqlParameter("@BalQuantity", BalQuantity));
                cmd.Parameters.Add(new SqlParameter("@Wrh", Wrh));
                cmd.Parameters.Add(new SqlParameter("@Project", Project));
                cmd.Parameters.Add(new SqlParameter("@OrderStatus", OrderStatus));
                cmd.Parameters.Add(new SqlParameter("@StartDate", StartDate));
                cmd.Parameters.Add(new SqlParameter("@FinishDate", FinishDate));
                cmd.Parameters.Add(new SqlParameter("@Ageing", Ageing));
                cmd.Parameters.Add(new SqlParameter("@AgeingRemarks", AgeingRemarks));
                cmd.Parameters.Add(new SqlParameter("@Remarks", Remarks));
                cmd.Parameters.Add(new SqlParameter("@RecDate", RecDate));
                cmd.Parameters.Add(new SqlParameter("@CreatedBy", UserName));
                cmd.Parameters.Add(new SqlParameter("@CreatedOn", DateTime.Now));

                cmd.ExecuteNonQuery();

                conn.Close();
            }
            catch (Exception ex)
            {
                conn.Close();
                Logger.Write(this.GetType().ToString() + " : InsertWIPHistory() : " + " : " + DateTime.Now + " : " + ex.Message.ToString(), Category.General, Priority.Highest);
                throw ex;
            }
        }

        public void InsertPOUploadItems(string CompanyNo, string PoOrder, string PoPosition, string OrderDate, string PlanDelDate, string ConfDate, string ChqBy, string ChqDate,
            string ItemNumber, string WareHouse, string Description, string IG, string EXP, string Price, string Currency, string Ordered, string Deliv, string OrderBalance,
            string amount, string BaseCurrency, string ReferenceA, string ReferenceB, string Supplier, string Name, string Project, string Description1, string MO, string PN,
            string Description2, string StandCost)
        {
            try
            {
                this.init();

                SqlCommand cmd = new SqlCommand("spInsertPOUploadItems", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                string UserName = (String)HttpContext.Current.Session["LoggedOnUser"];

                cmd.Parameters.Add(new SqlParameter("@CompanyNo", CompanyNo));
                cmd.Parameters.Add(new SqlParameter("@PoOrder", PoOrder)); // String
                cmd.Parameters.Add(new SqlParameter("@POPositione", PoPosition));
                cmd.Parameters.Add(new SqlParameter("@OrderDate", OrderDate));
                cmd.Parameters.Add(new SqlParameter("@PlanDelDate", PlanDelDate));
                cmd.Parameters.Add(new SqlParameter("@ConfDate", ConfDate));
                cmd.Parameters.Add(new SqlParameter("@ChqBy", ChqBy));
                cmd.Parameters.Add(new SqlParameter("@ChqDate", ChqDate));
                cmd.Parameters.Add(new SqlParameter("@ItemNumber", ItemNumber));
                cmd.Parameters.Add(new SqlParameter("@WareHouse", WareHouse));
                cmd.Parameters.Add(new SqlParameter("@Description", Description));
                cmd.Parameters.Add(new SqlParameter("@IG", IG));
                cmd.Parameters.Add(new SqlParameter("@Exp", EXP));
                cmd.Parameters.Add(new SqlParameter("@Price", Price));
                cmd.Parameters.Add(new SqlParameter("@Currency", Currency));
                cmd.Parameters.Add(new SqlParameter("@Ordered", Ordered));
                cmd.Parameters.Add(new SqlParameter("@Deliv", Deliv));
                cmd.Parameters.Add(new SqlParameter("@OrderBalance", OrderBalance));
                cmd.Parameters.Add(new SqlParameter("@Amount", amount));
                cmd.Parameters.Add(new SqlParameter("@BaseCurrency", BaseCurrency));
                cmd.Parameters.Add(new SqlParameter("@ReferenceA", ReferenceA));
                cmd.Parameters.Add(new SqlParameter("@ReferenceB", ReferenceB));
                cmd.Parameters.Add(new SqlParameter("@Supplier", Supplier));
                cmd.Parameters.Add(new SqlParameter("@Name", Name));
                cmd.Parameters.Add(new SqlParameter("@Project", Project));
                cmd.Parameters.Add(new SqlParameter("@Description1", Description1));
                cmd.Parameters.Add(new SqlParameter("@MO", MO));
                cmd.Parameters.Add(new SqlParameter("@PN", PN));
                cmd.Parameters.Add(new SqlParameter("@Description2", Description2));
                cmd.Parameters.Add(new SqlParameter("@StandCost", StandCost));
                cmd.Parameters.Add(new SqlParameter("@CreatedBy", UserName));
                cmd.Parameters.Add(new SqlParameter("@CreatedOn", DateTime.Now));

                cmd.ExecuteNonQuery();

                conn.Close();
            }
            catch (Exception ex)
            {
                conn.Close();
                Logger.Write(this.GetType().ToString() + " : InsertPOUploadItems() : " + " : " + DateTime.Now + " : " + ex.Message.ToString(), Category.General, Priority.Highest);
                throw ex;
            }
        }

        public void InsertPOHistory(string CompanyNo, string PoOrder, string PoPosition, string OrderDate, string PlanDelDate, string ConfDate, string ChqBy, string ChqDate,
           string ItemNumber, string WareHouse, string Description, string IG, string EXP, string Price, string Currency, string Ordered, string Deliv, string OrderBalance,
           string amount, string BaseCurrency, string ReferenceA, string ReferenceB, string Supplier, string Name, string Project, string Description1, string MO, string PN,
           string Description2, string StandCost, string Commitment, string Buyer, string Remarks)
        {
            try
            {
                this.init();

                SqlCommand cmd = new SqlCommand("spInsertPOHistory", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                string UserName = (String)HttpContext.Current.Session["LoggedOnUser"];

                cmd.Parameters.Add(new SqlParameter("@CompanyNo", CompanyNo));
                cmd.Parameters.Add(new SqlParameter("@PoOrder", PoOrder)); // String
                cmd.Parameters.Add(new SqlParameter("@POPositione", PoPosition));
                cmd.Parameters.Add(new SqlParameter("@OrderDate", OrderDate));
                cmd.Parameters.Add(new SqlParameter("@PlanDelDate", PlanDelDate));
                cmd.Parameters.Add(new SqlParameter("@ConfDate", ConfDate));
                cmd.Parameters.Add(new SqlParameter("@ChqBy", ChqBy));
                cmd.Parameters.Add(new SqlParameter("@ChqDate", ChqDate));
                cmd.Parameters.Add(new SqlParameter("@ItemNumber", ItemNumber));
                cmd.Parameters.Add(new SqlParameter("@WareHouse", WareHouse));
                cmd.Parameters.Add(new SqlParameter("@Description", Description));
                cmd.Parameters.Add(new SqlParameter("@IG", IG));
                cmd.Parameters.Add(new SqlParameter("@Exp", EXP));
                cmd.Parameters.Add(new SqlParameter("@Price", Price));
                cmd.Parameters.Add(new SqlParameter("@Currency", Currency));
                cmd.Parameters.Add(new SqlParameter("@Ordered", Ordered));
                cmd.Parameters.Add(new SqlParameter("@Deliv", Deliv));
                cmd.Parameters.Add(new SqlParameter("@OrderBalance", OrderBalance));
                cmd.Parameters.Add(new SqlParameter("@Amount", amount));
                cmd.Parameters.Add(new SqlParameter("@BaseCurrency", BaseCurrency));
                cmd.Parameters.Add(new SqlParameter("@ReferenceA", ReferenceA));
                cmd.Parameters.Add(new SqlParameter("@ReferenceB", ReferenceB));
                cmd.Parameters.Add(new SqlParameter("@Supplier", Supplier));
                cmd.Parameters.Add(new SqlParameter("@Name", Name));
                cmd.Parameters.Add(new SqlParameter("@Project", Project));
                cmd.Parameters.Add(new SqlParameter("@Description1", Description1));
                cmd.Parameters.Add(new SqlParameter("@MO", MO));
                cmd.Parameters.Add(new SqlParameter("@PN", PN));
                cmd.Parameters.Add(new SqlParameter("@Description2", Description2));
                cmd.Parameters.Add(new SqlParameter("@StandCost", StandCost));

                cmd.Parameters.Add(new SqlParameter("@Commitment", Commitment));
                cmd.Parameters.Add(new SqlParameter("@Buyers", Buyer));
                cmd.Parameters.Add(new SqlParameter("@Remarks", Remarks));
                cmd.Parameters.Add(new SqlParameter("@CreatedBy", UserName));
                cmd.Parameters.Add(new SqlParameter("@CreatedOn", DateTime.Now));

                cmd.ExecuteNonQuery();

                conn.Close();
            }
            catch (Exception ex)
            {
                conn.Close();
                Logger.Write(this.GetType().ToString() + " : spInsertPOHistory() : " + " : " + DateTime.Now + " : " + ex.Message.ToString(), Category.General, Priority.Highest);
                throw ex;
            }
        }

        public DataSet RetriveByWIPItemsFromProdOrder(string ProdOrder)
        {
            DataSet ds = new DataSet();
            try
            {
                this.init();

                SqlCommand cmd = new SqlCommand("[spGetWIPItemsFromProdOrder]", conn);
                cmd.CommandTimeout = 1000;
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add(new SqlParameter("@ProdOrderNo", ProdOrder)); // String

                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = cmd;

                da.Fill(ds);

                conn.Close();
                return ds;

            }
            catch (Exception ex)
            {
                conn.Close();
                Logger.Write(this.GetType().ToString() + " : RetriveByWIPItemsFromProdOrder() : " + " : " + DateTime.Now + " : " + ex.Message.ToString(), Category.General, Priority.Highest);
                throw ex;
            }
        }

        public DataSet RetriveByPOItemsFromOrderNo(string OrderNo, string PoPosition)
        {
            DataSet ds = new DataSet();
            try
            {
                this.init();

                SqlCommand cmd = new SqlCommand("[spGetPOItemsFromItemNumber]", conn);
                cmd.CommandTimeout = 1000;
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add(new SqlParameter("@OrderNo", OrderNo)); // String
                cmd.Parameters.Add(new SqlParameter("@PoPosition", PoPosition));

                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = cmd;

                da.Fill(ds);

                conn.Close();
                return ds;

            }
            catch (Exception ex)
            {
                conn.Close();
                Logger.Write(this.GetType().ToString() + " : RetriveByPOItemsFromOrderNo() : " + " : " + DateTime.Now + " : " + ex.Message.ToString(), Category.General, Priority.Highest);
                throw ex;
            }
        }

        public DataSet RetriveByWIPUploadItems()
        {
            DataSet ds = new DataSet();

            try
            {
                this.init();

                SqlCommand cmd = new SqlCommand("[spGetWIPUploadItems]", conn);
                cmd.CommandTimeout = 1000;
                cmd.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = cmd;

                da.Fill(ds);

                conn.Close();
                return ds;

            }
            catch (Exception ex)
            {
                //LogError(ex, "Exception from export button click!");
                conn.Close();
                Logger.Write(this.GetType().ToString() + " : spGetWIPUploadItems() : " + " : " + DateTime.Now + " : " + ex.Message.ToString(), Category.General, Priority.Highest);
                throw ex;
            }
        }

        public DataSet RetriveByWIPUploadItemsHistory()
        {
            DataSet ds = new DataSet();

            try
            {
                this.init();

                SqlCommand cmd = new SqlCommand("[spGetWIPUploadItemsHistory]", conn);
                cmd.CommandTimeout = 1000;
                cmd.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = cmd;

                da.Fill(ds);

                conn.Close();
                return ds;

            }
            catch (Exception ex)
            {
                //LogError(ex, "Exception from export button click!");
                conn.Close();
                Logger.Write(this.GetType().ToString() + " : RetriveByWIPUploadItemsHistory() : " + " : " + DateTime.Now + " : " + ex.Message.ToString(), Category.General, Priority.Highest);
                throw ex;
            }
        }

        public DataSet RetriveByViewWIPDates(int radioSelection)
        {
            DataSet ds = new DataSet();

            try
            {
                this.init();

                SqlCommand cmd = new SqlCommand("[spGetViewWIPDates]", conn);
                cmd.CommandTimeout = 1000;
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add(new SqlParameter("@RadioSelection", radioSelection)); // String

                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = cmd;

                da.Fill(ds);

                conn.Close();
                return ds;

            }
            catch (Exception ex)
            {
                //LogError(ex, "Exception from export button click!");
                conn.Close();
                Logger.Write(this.GetType().ToString() + " : RetriveByViewWIPDates() : " + " : " + DateTime.Now + " : " + ex.Message.ToString(), Category.General, Priority.Highest);
                throw ex;
            }
        }

        public DataSet RetriveByViewPODates(int radioSelection)
        {
            DataSet ds = new DataSet();

            try
            {
                this.init();

                SqlCommand cmd = new SqlCommand("[spGetViewPODates]", conn);
                cmd.CommandTimeout = 1000;
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add(new SqlParameter("@RadioSelection", radioSelection)); // String

                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = cmd;

                da.Fill(ds);

                conn.Close();
                return ds;

            }
            catch (Exception ex)
            {
                //LogError(ex, "Exception from export button click!");
                conn.Close();
                Logger.Write(this.GetType().ToString() + " : RetriveByViewPODates() : " + " : " + DateTime.Now + " : " + ex.Message.ToString(), Category.General, Priority.Highest);
                throw ex;
            }
        }

        public void RemoveWIPItems(String ProdOrderNo)
        {
            try
            {
                this.init();

                SqlCommand cmd = new SqlCommand("[spDeleteWIPItems]", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                string UserName = (String)HttpContext.Current.Session["LoggedOnUser"];

                cmd.Parameters.Add(new SqlParameter("@ProdOrderNo", ProdOrderNo)); // String
                cmd.Parameters.Add(new SqlParameter("@UpdatedBy", UserName));
                cmd.Parameters.Add(new SqlParameter("@UpdatedOn", DateTime.Now));

                cmd.ExecuteNonQuery();

                conn.Close();
            }
            catch (Exception ex)
            {
                conn.Close();
                Logger.Write(this.GetType().ToString() + " : spDeleteWIPItems() : " + " : " + DateTime.Now + " : " + ex.Message.ToString(), Category.General, Priority.Highest);
                throw ex;
            }
        }

        public void RemovePOItems(string PoOrderNo, int PoPosition)
        {
            try
            {
                this.init();

                SqlCommand cmd = new SqlCommand("[spDeletePOItems]", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                string UserName = (String)HttpContext.Current.Session["LoggedOnUser"];

                cmd.Parameters.Add(new SqlParameter("@PoOrder", PoOrderNo)); // String
                cmd.Parameters.Add(new SqlParameter("@POPosition", PoPosition));
                cmd.Parameters.Add(new SqlParameter("@UpdatedBy", UserName));
                cmd.Parameters.Add(new SqlParameter("@UpdatedOn", DateTime.Now));

                cmd.ExecuteNonQuery();

                conn.Close();
            }
            catch (Exception ex)
            {
                conn.Close();
                Logger.Write(this.GetType().ToString() + " : RemovePOItems() : " + " : " + DateTime.Now + " : " + ex.Message.ToString(), Category.General, Priority.Highest);
                throw ex;
            }
        }

        public void UpdatePOCommitmentDate()
        {
            try
            {
                this.init();

                SqlCommand cmd = new SqlCommand("UPDATE PO SET Commitment = 'To Commit' WHERE (Commitment IS NULL) OR (Commitment = '')", conn);
                cmd.CommandType = CommandType.Text;

                cmd.ExecuteNonQuery();

                conn.Close();
            }
            catch (Exception ex)
            {
                conn.Close();
                Logger.Write(this.GetType().ToString() + " : UpdatePOCommitmentDate() : " + " : " + DateTime.Now + " : " + ex.Message.ToString(), Category.General, Priority.Highest);
                throw ex;
            }
        }

        public void UpdateWIPRecDates()
        {
            try
            {
                this.init();
                SqlCommand cmd = new SqlCommand("Update WIP SET RecDate = 'To Commit' FROM wip WHERE(RecDate IS NULL) OR(RecDate = '')", conn);
                //SqlCommand cmd = new SqlCommand("Update WIP SET RecDate = CONVERT(VARCHAR(10), CAST(Cast(SUBSTRING(FinishDate, 1, 10) AS int) AS datetime) -2, 105) FROM wip WHERE (RecDate IS NULL) OR (RecDate = '')", conn);
                cmd.CommandType = CommandType.Text;

                cmd.ExecuteNonQuery();

                conn.Close();
            }
            catch (Exception ex)
            {
                conn.Close();
                Logger.Write(this.GetType().ToString() + " : UpdateWIPRecDates() : " + " : " + DateTime.Now + " : " + ex.Message.ToString(), Category.General, Priority.Highest);
                throw ex;
            }
        }

        public int GetWIPCounts()
        {
            int wipCount = 0;
            try
            {
                this.init();
                SqlCommand cmd = new SqlCommand("SELECT Count(*) AS WipCount FROM WIP", conn);
                cmd.CommandType = CommandType.Text;

                wipCount = (int)cmd.ExecuteScalar();

                conn.Close();
            }
            catch (Exception ex)
            {
                conn.Close();
                Logger.Write(this.GetType().ToString() + " : GetWIPCount() : " + " : " + DateTime.Now + " : " + ex.Message.ToString(), Category.General, Priority.Highest);
                throw ex;
            }

            return wipCount;
        }

        public int GetInventoryCounts()
        {
            int inventoryCount = 0;
            try
            {
                this.init();
                SqlCommand cmd = new SqlCommand("SELECT Count(*) FROM Inventory", conn);
                cmd.CommandType = CommandType.Text;

                inventoryCount = (int)cmd.ExecuteScalar();

                conn.Close();
            }
            catch (Exception ex)
            {
                conn.Close();
                Logger.Write(this.GetType().ToString() + " : GetInventoryCounts() : " + " : " + DateTime.Now + " : " + ex.Message.ToString(), Category.General, Priority.Highest);
                throw ex;
            }

            return inventoryCount;
        }

        public int GetBOMCounts()
        {
            int bomCount = 0;
            try
            {
                this.init();
                SqlCommand cmd = new SqlCommand("SELECT Count(*) FROM BOM", conn);
                cmd.CommandType = CommandType.Text;

                bomCount = (int)cmd.ExecuteScalar();

                conn.Close();
            }
            catch (Exception ex)
            {
                conn.Close();
                Logger.Write(this.GetType().ToString() + " : GetBOMCounts() : " + " : " + DateTime.Now + " : " + ex.Message.ToString(), Category.General, Priority.Highest);
                throw ex;
            }

            return bomCount;
        }

        public int GetPOCounts()
        {
            int poCount = 0;
            try
            {
                this.init();
                SqlCommand cmd = new SqlCommand("SELECT Count(*) FROM PO", conn);
                cmd.CommandType = CommandType.Text;

                poCount = (int)cmd.ExecuteScalar();

                conn.Close();
            }
            catch (Exception ex)
            {
                conn.Close();
                Logger.Write(this.GetType().ToString() + " : GetPOCounts() : " + " : " + DateTime.Now + " : " + ex.Message.ToString(), Category.General, Priority.Highest);
                throw ex;
            }

            return poCount;
        }

        public void UpdateWIPBuyers()
        {
            try
            {
                this.init();

                SqlCommand cmd = new SqlCommand("Update WIP SET Buyer=''", conn);
                cmd.CommandType = CommandType.Text;

                cmd.ExecuteNonQuery();

                conn.Close();
            }
            catch (Exception ex)
            {
                conn.Close();
                Logger.Write(this.GetType().ToString() + " : UpdateWIPBuyers() : " + " : " + DateTime.Now + " : " + ex.Message.ToString(), Category.General, Priority.Highest);
                throw ex;
            }
        }

        public void UpdateWIPRecDate(String ProdOrderNo, String ItemNumber, String WIPRecDate, string Buyer, string Remarks)
        {
            try
            {
                this.init();

                SqlCommand cmd = new SqlCommand("spUpdateWIPRecDate", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                string UserName = (String)HttpContext.Current.Session["LoggedOnUser"];

                cmd.Parameters.Add(new SqlParameter("@ProdOrderNo", ProdOrderNo)); // String
                cmd.Parameters.Add(new SqlParameter("@ItemNumber", ItemNumber));

                cmd.Parameters.Add(new SqlParameter("@WIPRecDate", String.IsNullOrEmpty(WIPRecDate) ? String.Empty : WIPRecDate));
                cmd.Parameters.Add(new SqlParameter("@Buyer", Buyer));
                cmd.Parameters.Add(new SqlParameter("@Remarks", Remarks));

                cmd.Parameters.Add(new SqlParameter("@UpdatedBy", UserName));
                cmd.Parameters.Add(new SqlParameter("@UpdatedOn", DateTime.Now));

                cmd.ExecuteNonQuery();

                conn.Close();
            }
            catch (Exception ex)
            {
                conn.Close();
                Logger.Write(this.GetType().ToString() + " : UpdateWIPRecDate() : " + " : " + DateTime.Now + " : " + ex.Message.ToString(), Category.General, Priority.Highest);
                throw ex;
            }
        }

        public void InsertWIPRecDateHistory(String ProdOrderNo, String ItemNumber, String WIPRecDate, string Buyer, string Remarks)
        {
            try
            {
                this.init();

                SqlCommand cmd = new SqlCommand("[spInsertWIPRecDateHistory]", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                string UserName = (String)HttpContext.Current.Session["LoggedOnUser"];

                cmd.Parameters.Add(new SqlParameter("@ProdOrderNo", ProdOrderNo)); // String
                cmd.Parameters.Add(new SqlParameter("@ItemNumber", ItemNumber));

                cmd.Parameters.Add(new SqlParameter("@RecDate", String.IsNullOrEmpty(WIPRecDate) ? String.Empty : WIPRecDate));
                cmd.Parameters.Add(new SqlParameter("@Buyer", Buyer));
                cmd.Parameters.Add(new SqlParameter("@Remarks", Remarks));

                cmd.Parameters.Add(new SqlParameter("@CreatedBy", UserName));
                cmd.Parameters.Add(new SqlParameter("@CreatedOn", DateTime.Now));

                cmd.ExecuteNonQuery();

                conn.Close();
            }
            catch (Exception ex)
            {
                conn.Close();
                Logger.Write(this.GetType().ToString() + " : InsertWIPRecDateHistory() : " + " : " + DateTime.Now + " : " + ex.Message.ToString(), Category.General, Priority.Highest);
                throw ex;
            }
        }

        public DataSet RetriveByPOUploadItems()
        {
            DataSet ds = new DataSet();

            try
            {
                this.init();

                SqlCommand cmd = new SqlCommand("[spGetPOUploadItems]", conn);
                cmd.CommandTimeout = 1000;
                cmd.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = cmd;

                da.Fill(ds);

                conn.Close();
                return ds;

            }
            catch (Exception ex)
            {
                //LogError(ex, "Exception from export button click!");
                conn.Close();
                Logger.Write(this.GetType().ToString() + " : spGetPOUploadItems() : " + " : " + DateTime.Now + " : " + ex.Message.ToString(), Category.General, Priority.Highest);
                throw ex;
            }
        }

        public DataSet RetriveByPOCommittmentFromSuppliers(int IsDueFor, string SupplierName)
        {
            DataSet ds = new DataSet();

            try
            {
                this.init();

                SqlCommand cmd = new SqlCommand("[spGetPOCommittmentFromSuppliers]", conn);
                cmd.CommandTimeout = 1000;
                cmd.CommandType = CommandType.StoredProcedure;
                //string UserName = (String)HttpContext.Current.Session["LoggedOnUser"];

                cmd.Parameters.Add(new SqlParameter("@IsDueFor", IsDueFor)); // String
                cmd.Parameters.Add(new SqlParameter("@LoginSupplierName", "INDEX AUTO"));

                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = cmd;

                da.Fill(ds);

                conn.Close();
                return ds;

            }
            catch (Exception ex)
            {
                //LogError(ex, "Exception from export button click!");
                conn.Close();
                Logger.Write(this.GetType().ToString() + " : RetriveByPOCommittmentFromSuppliers() : " + " : " + DateTime.Now + " : " + ex.Message.ToString(), Category.General, Priority.Highest);
                throw ex;
            }
        }

        public DataSet RetriveBySupplierRemarksForDropDown()
        {
            DataSet ds = new DataSet();

            try
            {
                this.init();

                SqlCommand cmd = new SqlCommand("Select * from SupplierRemarks", conn);
                cmd.CommandTimeout = 1000;
                cmd.CommandType = CommandType.Text;

                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = cmd;

                da.Fill(ds);

                conn.Close();
                return ds;

            }
            catch (Exception ex)
            {
                //LogError(ex, "Exception from export button click!");
                conn.Close();
                Logger.Write(this.GetType().ToString() + " : RetriveBySupplierRemarksForDropDown() : " + " : " + DateTime.Now + " : " + ex.Message.ToString(), Category.General, Priority.Highest);
                throw ex;
            }
        }

        public DataSet RetriveByPOHistory()
        {
            DataSet ds = new DataSet();

            try
            {
                this.init();

                SqlCommand cmd = new SqlCommand("[spGetPOUploadItemsHistory]", conn);
                cmd.CommandTimeout = 1000;
                cmd.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = cmd;

                da.Fill(ds);

                conn.Close();
                return ds;

            }
            catch (Exception ex)
            {
                //LogError(ex, "Exception from export button click!");
                conn.Close();
                Logger.Write(this.GetType().ToString() + " : RetriveByPOHistory() : " + " : " + DateTime.Now + " : " + ex.Message.ToString(), Category.General, Priority.Highest);
                throw ex;
            }
        }

        public void UpdatePOCommittment(String PoOrderNo, String PoPosition, String POCommittment, string Buyer, string Remarks, bool Urgent)
        {
            try
            {
                this.init();

                SqlCommand cmd = new SqlCommand("spUpdatePOCommittment", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                string UserName = (String)HttpContext.Current.Session["LoggedOnUser"];

                cmd.Parameters.Add(new SqlParameter("@OrderNo", PoOrderNo)); // String
                cmd.Parameters.Add(new SqlParameter("@PoPosition", PoPosition));
                cmd.Parameters.Add(new SqlParameter("@Buyer", Buyer));
                cmd.Parameters.Add(new SqlParameter("@Remarks", Remarks));
                cmd.Parameters.Add(new SqlParameter("@Urgent", Urgent));
                cmd.Parameters.Add(new SqlParameter("@POCommittment", String.IsNullOrEmpty(POCommittment) ? string.Empty : POCommittment));

                cmd.Parameters.Add(new SqlParameter("@UpdatedBy", UserName));
                cmd.Parameters.Add(new SqlParameter("@UpdatedOn", DateTime.Now));

                cmd.ExecuteNonQuery();

                conn.Close();
            }
            catch (Exception ex)
            {
                conn.Close();
                Logger.Write(this.GetType().ToString() + " : spUpdatePOCommittment() : " + " : " + DateTime.Now + " : " + ex.Message.ToString(), Category.General, Priority.Highest);
                throw ex;
            }
        }

        public void UpdatePOCommittmentFromSuppliers(String PoOrderNo, String PoPosition, String POCommittment1, String POCommittment2, String POCommittment3,
            bool Shipped, string Remarks)
        {
            try
            {
                this.init();

                SqlCommand cmd = new SqlCommand("[spUpdatePOCommittmentFromSuppliers]", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                string UserName = (String)HttpContext.Current.Session["LoggedOnUser"];

                cmd.Parameters.Add(new SqlParameter("@OrderNo", PoOrderNo)); // String
                cmd.Parameters.Add(new SqlParameter("@PoPosition", PoPosition));
                cmd.Parameters.Add(new SqlParameter("@Committment1", String.IsNullOrEmpty(POCommittment1) ? string.Empty : POCommittment1));
                cmd.Parameters.Add(new SqlParameter("@Committment2", String.IsNullOrEmpty(POCommittment2) ? string.Empty : POCommittment2));
                cmd.Parameters.Add(new SqlParameter("@Committment3", String.IsNullOrEmpty(POCommittment3) ? string.Empty : POCommittment3));
                cmd.Parameters.Add(new SqlParameter("@Shipped", Shipped));
                cmd.Parameters.Add(new SqlParameter("@SupplierRemarks", Remarks));
                cmd.Parameters.Add(new SqlParameter("@UpdatedBy", UserName));
                cmd.Parameters.Add(new SqlParameter("@UpdatedOn", DateTime.Now));

                cmd.ExecuteNonQuery();

                conn.Close();
            }
            catch (Exception ex)
            {
                conn.Close();
                Logger.Write(this.GetType().ToString() + " : spUpdatePOCommittment() : " + " : " + DateTime.Now + " : " + ex.Message.ToString(), Category.General, Priority.Highest);
                throw ex;
            }
        }

        public void InsertPOCommitmentDateHistory(String PoOrderNo, String PoPosition, String POCommittment, string Buyer, string Remarks, bool Urgent)
        {
            try
            {
                this.init();

                SqlCommand cmd = new SqlCommand("[spInsertPOCommitmentDateHistory]", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                string UserName = (String)HttpContext.Current.Session["LoggedOnUser"];

                cmd.Parameters.Add(new SqlParameter("@PoOrder", PoOrderNo)); // String
                cmd.Parameters.Add(new SqlParameter("@POPosition", PoPosition));
                cmd.Parameters.Add(new SqlParameter("@Commitment", String.IsNullOrEmpty(POCommittment) ? String.Empty : POCommittment));
                cmd.Parameters.Add(new SqlParameter("@Buyers", Buyer));
                cmd.Parameters.Add(new SqlParameter("@Remarks", Remarks));
                cmd.Parameters.Add(new SqlParameter("@Urgent", Urgent));

                cmd.Parameters.Add(new SqlParameter("@CreatedBy", UserName));
                cmd.Parameters.Add(new SqlParameter("@CreatedOn", DateTime.Now));

                cmd.ExecuteNonQuery();

                conn.Close();
            }
            catch (Exception ex)
            {
                conn.Close();
                Logger.Write(this.GetType().ToString() + " : InsertPOCommitmentDateHistory() : " + " : " + DateTime.Now + " : " + ex.Message.ToString(), Category.General, Priority.Highest);
                throw ex;
            }
        }

        #endregion

        /// <summary>
        /// Update the Prod release New Table, for the TPI Offering
        /// </summary>
        /// <param name="OrderNum"></param>
        /// <param name="LineNum"></param>
        /// <param name="Pos"></param>
        /// <param name="ProdOrderNo"></param>
        /// <param name="SerialNo"></param>
        /// <param name="TPIOfferDate"></param>
        /// <param name="QCRemarks"></param>
        /// <param name="IRNCompletionDate"></param>
        public void UpdateTPIOffering(int OrderNum, String LineNum, int Pos, String ProdOrderNo, String SerialNo, String TPIOfferDate, String QCRemarks, String IRNCompletionDate)
        {
            try
            {
                this.init();

                SqlCommand cmd = new SqlCommand("spUpdateTPIOffering", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                string UserName = (String)HttpContext.Current.Session["LoggedOnUser"];

                cmd.Parameters.Add(new SqlParameter("@OrderNum", OrderNum)); // int
                cmd.Parameters.Add(new SqlParameter("@LineNum", LineNum)); // String
                cmd.Parameters.Add(new SqlParameter("@Pos", Pos)); // Int
                cmd.Parameters.Add(new SqlParameter("@ProdOrderNo", ProdOrderNo)); // String
                cmd.Parameters.Add(new SqlParameter("@SerialNo", SerialNo));

                cmd.Parameters.Add(new SqlParameter("@TPIOfferDate", String.IsNullOrEmpty(TPIOfferDate) ? String.Empty : TPIOfferDate));
                cmd.Parameters.Add(new SqlParameter("@QCRemarks", String.IsNullOrEmpty(QCRemarks) ? String.Empty : QCRemarks));
                cmd.Parameters.Add(new SqlParameter("@IRNCompDate", String.IsNullOrEmpty(IRNCompletionDate) ? String.Empty : IRNCompletionDate));

                cmd.Parameters.Add(new SqlParameter("@UpdatedBy", UserName));
                cmd.Parameters.Add(new SqlParameter("@UpdatedOn", DateTime.Now));

                cmd.ExecuteNonQuery();

                conn.Close();
            }
            catch (Exception ex)
            {
                conn.Close();
                Logger.Write(this.GetType().ToString() + " : UpdateTPIOffering() : " + " : " + DateTime.Now + " : " + ex.Message.ToString(), Category.General, Priority.Highest);
                throw ex;
            }
        }

        /// <summary>
        /// Bulk Update the Prod release New Table, for the TPI Offering
        /// </summary>
        /// <param name="ProdOrderNo"></param>
        /// <param name="SerialNo"></param>
        /// <param name="TPIOfferDate"></param>
        /// <param name="QCRemarks"></param>
        /// <param name="IRNCompletionDate"></param>
        public void BulkUpdateTPIOffering(String ProdOrderNo, String SerialNo, String TPIOfferDate, String QCRemarks, String IRNCompletionDate)
        {
            try
            {
                this.init();

                SqlCommand cmd = new SqlCommand("spBulkUpdateTPIOffering", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                string UserName = (String)HttpContext.Current.Session["LoggedOnUser"];

                cmd.Parameters.Add(new SqlParameter("@ProdOrderNo", ProdOrderNo)); // String
                cmd.Parameters.Add(new SqlParameter("@SerialNo", SerialNo));

                cmd.Parameters.Add(new SqlParameter("@TPIOfferDate", String.IsNullOrEmpty(TPIOfferDate) ? String.Empty : TPIOfferDate));
                cmd.Parameters.Add(new SqlParameter("@QCRemarks", String.IsNullOrEmpty(QCRemarks) ? String.Empty : QCRemarks));
                cmd.Parameters.Add(new SqlParameter("@IRNCompDate", String.IsNullOrEmpty(IRNCompletionDate) ? String.Empty : IRNCompletionDate));

                cmd.Parameters.Add(new SqlParameter("@UpdatedBy", UserName));
                cmd.Parameters.Add(new SqlParameter("@UpdatedOn", DateTime.Now));

                cmd.ExecuteNonQuery();

                conn.Close();
            }
            catch (Exception ex)
            {
                conn.Close();
                Logger.Write(this.GetType().ToString() + " : BulkUpdateTPIOffering() : " + " : " + DateTime.Now + " : " + ex.Message.ToString(), Category.General, Priority.Highest);
                throw ex;
            }
        }

        # endregion

        # region SCN Input

        /// <summary>
        /// Gets the SCN Input Data from the MISOrderStatus & ProdReleaseNew Tables
        /// </summary>
        /// <returns></returns>
        public DataSet RetrieveSCNInputData()
        {
            DataSet ds = new DataSet();
            try
            {
                this.init();

                SqlCommand cmd = new SqlCommand("spGetSCNInputData", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = cmd;

                da.Fill(ds);

                conn.Close();
                return ds;
            }
            catch (Exception ex)
            {
                conn.Close();
                Logger.Write(this.GetType().ToString() + " : RetrieveSCNInputData() : " + " : " + DateTime.Now + " : " + ex.Message.ToString(), Category.General, Priority.Highest);
                throw ex;
            }
        }

        /// <summary>
        /// Update the Prod release New Table, for the SCN Input
        /// </summary>
        /// <param name="OrderNum"></param>
        /// <param name="LineNum"></param>
        /// <param name="Pos"></param>
        /// <param name="ProdOrderNo"></param>
        /// <param name="SerialNo"></param>
        /// <param name="SCNCompletionDate"></param>
        public void UpdateSCNinput(int OrderNum, String LineNum, int Pos, String ProdOrderNo, String SerialNo, String SCNCompletionDate)
        {
            try
            {
                this.init();

                SqlCommand cmd = new SqlCommand("spUpdateSCNInput", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                string UserName = (String)HttpContext.Current.Session["LoggedOnUser"];

                cmd.Parameters.Add(new SqlParameter("@OrderNum", OrderNum)); // int
                cmd.Parameters.Add(new SqlParameter("@LineNum", LineNum)); // String
                cmd.Parameters.Add(new SqlParameter("@Pos", Pos)); // Int
                cmd.Parameters.Add(new SqlParameter("@ProdOrderNo", ProdOrderNo)); // String
                cmd.Parameters.Add(new SqlParameter("@SerialNo", SerialNo));

                cmd.Parameters.Add(new SqlParameter("@SCNCompDate", String.IsNullOrEmpty(SCNCompletionDate) ? String.Empty : SCNCompletionDate));

                cmd.Parameters.Add(new SqlParameter("@UpdatedBy", UserName));
                cmd.Parameters.Add(new SqlParameter("@UpdatedOn", DateTime.Now));

                cmd.ExecuteNonQuery();

                conn.Close();
            }
            catch (Exception ex)
            {
                conn.Close();
                Logger.Write(this.GetType().ToString() + " : UpdateProdCompletion() : " + " : " + DateTime.Now + " : " + ex.Message.ToString(), Category.General, Priority.Highest);
                throw ex;
            }
        }

        # endregion

        # endregion

        /// <summary>
        /// Gets the Report Data for the required report name
        /// </summary>
        /// <param name="ReportName"></param>
        /// <returns></returns>
        public DataSet GetReportData(String ReportName)
        {
            DataSet ds = new DataSet();
            try
            {
                this.init();

                SqlCommand cmd = new SqlCommand("spGetReportData", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add(new SqlParameter("@ReportName", ReportName));

                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = cmd;

                da.Fill(ds);

                conn.Close();

                return ds;
            }
            catch (Exception ex)
            {
                conn.Close();
                Logger.Write(this.GetType().ToString() + " : GetReportData() : " + " : " + DateTime.Now + " : " + ex.Message.ToString(), Category.General, Priority.Highest);
                throw ex;
            }
        }

        #region Freeze

        /// <summary>
        /// Method to copy the data from MISOrderstatus into MISFinal
        /// </summary>
        public void FreezeOrders()
        {
            try
            {
                this.init();

                SqlCommand cmd = new SqlCommand("spFreeze", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.ExecuteNonQuery();

                conn.Close();
            }
            catch (Exception ex)
            {
                conn.Close();
                Logger.Write(this.GetType().ToString() + " : FreezeOrders() : " + " : " + DateTime.Now + " : " + ex.Message.ToString(), Category.General, Priority.Highest);
                throw ex;
            }
        }

        # endregion

        # region Plan Data

        # region Release Plan Data

        /// <summary>
        /// Gets the Reelase Plan Data for the provided weekno
        /// </summary>
        /// <param name="WeekNo"></param>
        /// <returns></returns>
        public DataSet GetReleasePlanData(int WeekNo)
        {
            DataSet ds = new DataSet();
            try
            {
                this.init();

                SqlCommand cmd = new SqlCommand("spGetReleasePlanData", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add(new SqlParameter("@WeekNo", WeekNo));

                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = cmd;

                da.Fill(ds);

                conn.Close();

                return ds;
            }
            catch (Exception ex)
            {
                conn.Close();
                Logger.Write(this.GetType().ToString() + " : GetReleasePlanData() : " + " : " + DateTime.Now + " : " + ex.Message.ToString(), Category.General, Priority.Highest);
                throw ex;
            }
        }

        /// <summary>
        /// Gets the Reelase Plan Data for the provided weekno at a macro level
        /// </summary>
        /// <param name="WeekNo"></param>
        /// <returns></returns>
        public DataSet GetMacroReleasePlanData(int WeekNo)
        {
            DataSet ds = new DataSet();
            try
            {
                this.init();

                SqlCommand cmd = new SqlCommand("spGetMacroReleasePlanData", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add(new SqlParameter("@WeekNo", WeekNo));

                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = cmd;

                da.Fill(ds);

                conn.Close();

                return ds;
            }
            catch (Exception ex)
            {
                conn.Close();
                Logger.Write(this.GetType().ToString() + " : GetMacroReleasePlanData() : " + " : " + DateTime.Now + " : " + ex.Message.ToString(), Category.General, Priority.Highest);
                throw ex;
            }
        }

        #endregion

        #region FG Plan Data

        /// <summary>
        /// Gets the FG Plan Data for the provided weekno
        /// </summary>
        /// <param name="WeekNo"></param>
        /// <returns></returns>
        public DataSet GetFGPlanData(int WeekNo)
        {
            DataSet ds = new DataSet();
            try
            {
                this.init();

                SqlCommand cmd = new SqlCommand("spGetFGPlanData", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add(new SqlParameter("@WeekNo", WeekNo));

                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = cmd;

                da.Fill(ds);

                conn.Close();

                return ds;
            }
            catch (Exception ex)
            {
                conn.Close();
                Logger.Write(this.GetType().ToString() + " : GetFGPlanData() : " + " : " + DateTime.Now + " : " + ex.Message.ToString(), Category.General, Priority.Highest);
                throw ex;
            }
        }

        /// <summary>
        /// Get the Macro Level FG Plan Data
        /// </summary>
        /// <param name="WeekNo"></param>
        /// <returns></returns>
        public DataSet GetMacroFGPlanData(int WeekNo)
        {
            DataSet ds = new DataSet();
            try
            {
                this.init();

                SqlCommand cmd = new SqlCommand("spGetMacroFGPlanData", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add(new SqlParameter("@WeekNo", WeekNo));

                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = cmd;

                da.Fill(ds);

                conn.Close();

                return ds;
            }
            catch (Exception ex)
            {
                conn.Close();
                Logger.Write(this.GetType().ToString() + " : GetMacroFGPlanData() : " + " : " + DateTime.Now + " : " + ex.Message.ToString(), Category.General, Priority.Highest);
                throw ex;
            }
        }

        #endregion

        #region Sales Plan Data

        /// <summary>
        /// Gets the Sales Plan Data for the provided weekno
        /// </summary>
        /// <param name="WeekNo"></param>
        /// <returns></returns>
        public DataSet GetSalesPlanData(int WeekNo)
        {
            DataSet ds = new DataSet();
            try
            {
                this.init();

                SqlCommand cmd = new SqlCommand("spGetSalesPlanData", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add(new SqlParameter("@WeekNo", WeekNo));

                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = cmd;

                da.Fill(ds);

                conn.Close();

                return ds;
            }
            catch (Exception ex)
            {
                conn.Close();
                Logger.Write(this.GetType().ToString() + " : GetSalesPlanData() : " + " : " + DateTime.Now + " : " + ex.Message.ToString(), Category.General, Priority.Highest);
                throw ex;
            }
        }

        /// <summary>
        /// Get Macro Level Sales Plan Data
        /// </summary>
        /// <param name="WeekNo"></param>
        /// <returns></returns>
        public DataSet GetMacroSalesPlanData(int WeekNo)
        {
            DataSet ds = new DataSet();
            try
            {
                this.init();

                SqlCommand cmd = new SqlCommand("spGetMacroSalesPlanData", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add(new SqlParameter("@WeekNo", WeekNo));

                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = cmd;

                da.Fill(ds);

                conn.Close();

                return ds;
            }
            catch (Exception ex)
            {
                conn.Close();
                Logger.Write(this.GetType().ToString() + " : GetMacroSalesPlanData() : " + " : " + DateTime.Now + " : " + ex.Message.ToString(), Category.General, Priority.Highest);
                throw ex;
            }
        }

        # endregion

        # endregion

        # region QR & QA

        /// <summary>
        /// Gets the QR & QA Data for the given week & OrderType
        /// </summary>
        /// <param name="OrderType"></param>
        /// <param name="WeekNo"></param>
        /// <returns></returns>
        public DataSet GetQRAndQAData(String OrderType, int WeekNo)
        {
            DataSet ds = new DataSet();
            try
            {
                this.init();

                SqlCommand cmd = new SqlCommand("spGetQRAndQAData", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add(new SqlParameter("@OrderType", OrderType));
                cmd.Parameters.Add(new SqlParameter("@WeekNo", WeekNo));

                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = cmd;

                da.Fill(ds);

                conn.Close();

                return ds;
            }
            catch (Exception ex)
            {
                conn.Close();
                Logger.Write(this.GetType().ToString() + " : GetQRAndQAData() : " + " : " + DateTime.Now + " : " + ex.Message.ToString(), Category.General, Priority.Highest);
                throw ex;
            }
        }

        /// <summary>
        /// Gets the QR & QA Sales Summary Data for the given week & OrderType
        /// </summary>
        /// <param name="OrderType"></param>
        /// <param name="WeekNo"></param>
        /// <returns></returns>
        public DataSet GetQRAndQASalesSummaryData(String OrderType, int WeekNo)
        {
            DataSet ds = new DataSet();
            try
            {
                this.init();

                SqlCommand cmd = new SqlCommand("spGetQRAndQASalesSummary", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add(new SqlParameter("@OrderType", OrderType));
                cmd.Parameters.Add(new SqlParameter("@WeekNo", WeekNo));

                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = cmd;

                da.Fill(ds);

                conn.Close();

                return ds;
            }
            catch (Exception ex)
            {
                conn.Close();
                Logger.Write(this.GetType().ToString() + " : GetQRAndQASalesSummaryData() : " + " : " + DateTime.Now + " : " + ex.Message.ToString(), Category.General, Priority.Highest);
                throw ex;
            }
        }

        # endregion

        # region Commercial Data

        /// <summary>
        /// Gets the Details from MISFinanceInput, grouping by Customer Name & WeekNo
        /// </summary>
        /// <param name="OrderType"></param>
        /// <param name="WeekNo"></param>
        /// <returns></returns>
        public DataSet GetCommercialData(String OrderType, int WeekNo)
        {
            DataSet ds = new DataSet();
            try
            {
                this.init();

                SqlCommand cmd = new SqlCommand("spGetCommercialData", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add(new SqlParameter("@OrderType", OrderType));
                cmd.Parameters.Add(new SqlParameter("@WeekNo", WeekNo));

                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = cmd;

                da.Fill(ds);

                conn.Close();

                return ds;
            }
            catch (Exception ex)
            {
                conn.Close();
                Logger.Write(this.GetType().ToString() + " : GetCommercialData() : " + " : " + DateTime.Now + " : " + ex.Message.ToString(), Category.General, Priority.Highest);
                throw ex;
            }
        }
        # endregion

        /// <summary>
        /// Update the BaaN data in MIS Order Status table
        /// </summary>
        /// <param name="OrderNum"></param>
        /// <param name="LineNum"></param>
        /// <param name="Pos"></param>
        /// <param name="Item"></param>
        /// <param name="Description"></param>
        /// <param name="ItemGroup"></param>
        /// <param name="DiffQtyToBeUpdated"></param>
        /// <param name="PlanWeek"></param>
        /// <param name="WIPWeek"></param>
        /// <param name="FGWeek"></param>
        public void UpdateBaaNDataInMISOrderStatus(int OrderNum, String LineNum, int Pos, String Item, String Description, String ItemGroup, int DiffQtyToBeUpdated, int PlanWeek, int WIPWeek, int FGWeek, 
            float UpdatedAmount, DateTime PlannedDelDate, DateTime OriginalPromDate, String CustomerName, String Description_2)
        {
            try
            {
                this.init();

                SqlCommand cmd = new SqlCommand("spUpdateBaanDataInMISOrderStatus", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add(new SqlParameter("@OrderNum", OrderNum)); // int
                cmd.Parameters.Add(new SqlParameter("@LineNum", LineNum)); // String
                cmd.Parameters.Add(new SqlParameter("@Pos", Pos)); // Int
                cmd.Parameters.Add(new SqlParameter("@CustomerName", CustomerName)); //String
                cmd.Parameters.Add(new SqlParameter("@Item", Item)); // String
                cmd.Parameters.Add(new SqlParameter("@Description", Description)); //String
                cmd.Parameters.Add(new SqlParameter("@ItemGroup", ItemGroup)); // String
                cmd.Parameters.Add(new SqlParameter("@DiffQtyToBeUpdated", DiffQtyToBeUpdated)); //int
                cmd.Parameters.Add(new SqlParameter("@PlanWeek", PlanWeek)); //int
                cmd.Parameters.Add(new SqlParameter("@WIPWeek", WIPWeek)); //int
                cmd.Parameters.Add(new SqlParameter("@FGWeek", FGWeek)); //int
                cmd.Parameters.Add(new SqlParameter("@UpdatedAmount", UpdatedAmount)); //float
                cmd.Parameters.Add(new SqlParameter("@OriginalPromDate", OriginalPromDate)); //DateTime
                cmd.Parameters.Add(new SqlParameter("@PlannedDelDate", PlannedDelDate)); //DateTime
                cmd.Parameters.Add(new SqlParameter("@Description_2", Description_2)); //String

                cmd.ExecuteNonQuery();

                conn.Close();
            }
            catch (Exception ex)
            {
                conn.Close();
                Logger.Write(this.GetType().ToString() + " : UpdateBaaNDataInMISOrderStatus() : " + " : " + DateTime.Now + " : " + ex.Message.ToString(), Category.General, Priority.Highest);
                throw ex;
            }
        }

        /// <summary>
        /// Method to get the Assembly Order Processing Data
        /// </summary>
        /// <param name="OrderNo"></param>
        /// <returns></returns>
        public DataSet GetAssemblyOrderProcessing(String ProdOrderNo)
        {
            DataSet ds = new DataSet();
            try
            {
                this.init();

                SqlCommand cmd = new SqlCommand("spGetAssemblyOrderProcessing", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add(new SqlParameter("@ProdOrderNo", ProdOrderNo));

                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = cmd;

                da.Fill(ds);

                conn.Close();

                return ds;
            }
            catch (Exception ex)
            {
                conn.Close();
                Logger.Write(this.GetType().ToString() + " : GetAssemblyOrderProcessing : " + " : " + DateTime.Now + " : " + ex.Message.ToString(), Category.General, Priority.Highest);
                throw ex;
            }
        }

        # region Admin Management

        # region New User Creation
        public void CreateNewUser(String LoginName, String Password)
        {
            try
            {
                this.init();

                string UserName = (String)HttpContext.Current.Session["LoggedOnUser"];

                SqlCommand cmd = new SqlCommand("spInsertUserLogin", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add(new SqlParameter("@UserName", LoginName));
                cmd.Parameters.Add(new SqlParameter("@Password", Password));
                cmd.Parameters.Add(new SqlParameter("@UserInfo", UserName));
                cmd.Parameters.Add(new SqlParameter("@CreatedDateTime", DateTime.Now));

                cmd.ExecuteNonQuery();

                conn.Close();
            }
            catch (Exception ex)
            {
                conn.Close();
                Logger.Write(this.GetType().ToString() + " : CreateNewUser() : " + " : " + DateTime.Now + " : " + ex.Message.ToString(), Category.General, Priority.Highest);
                throw ex;
            }
        }

        public bool GetLoginIsExist(string userName)
        {
            bool isUserExist = false;
            DataSet ds = new DataSet();

            try
            {
                this.init();

                SqlCommand cmd = new SqlCommand("select * from login where UserName='"+userName+"'", conn);
                cmd.CommandTimeout = 1000;
                cmd.CommandType = CommandType.Text;

                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = cmd;

                da.Fill(ds);
                conn.Close();

                if (ds.Tables[0].Rows.Count > 0)
                {
                    isUserExist = true;
                }

                return isUserExist;
            }
            catch (Exception ex)
            {
                conn.Close();
                Logger.Write(this.GetType().ToString() + " : GetLoginIsExist() : " + " : " + DateTime.Now + " : " + ex.Message.ToString(), Category.General, Priority.Highest);
                throw ex;
            }
        }
        # endregion

        # region New Screen Access Insertion
        public void InsertScreenAccess(String LoginName)
        {
            try
            {
                this.init();

                string UserName = (String)HttpContext.Current.Session["LoggedOnUser"];

                SqlCommand cmd = new SqlCommand("spInsertScreenAccess", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add(new SqlParameter("@UserName", LoginName));
                cmd.Parameters.Add(new SqlParameter("@UserInfo", UserName));
                cmd.Parameters.Add(new SqlParameter("@CreatedDateTime", DateTime.Now));

                cmd.ExecuteNonQuery();

                conn.Close();
            }
            catch (Exception ex)
            {
                conn.Close();
                Logger.Write(this.GetType().ToString() + " : InsertScreenAccess() : " + " : " + DateTime.Now + " : " + ex.Message.ToString(), Category.General, Priority.Highest);
                throw ex;
            }
        }
        # endregion

        # region Get Screen Access Info

        /// <summary>
        /// Gets the List of Screens for an user
        /// </summary>
        /// <param name="UserName"></param>
        /// <returns></returns>
        public DataSet GetScreenAccessInfoForEmployee(String UserName)
        {
            DataSet ds = new DataSet();
            try
            {
                this.init();

                SqlCommand cmd = new SqlCommand("spGetScreenAccessInfoForEmployee", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add(new SqlParameter("@UserName", UserName));

                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = cmd;

                da.Fill(ds);

                conn.Close();

                return ds;
            }
            catch (Exception ex)
            {
                conn.Close();
                Logger.Write(this.GetType().ToString() + " : GetScreenAccessInfoForEmployee : " + " : " + DateTime.Now + " : " + ex.Message.ToString(), Category.General, Priority.Highest);
                throw ex;
            }
        }

        # endregion

        # region Update screen Access
        /// <summary>
        /// Updates the access to individula screens for an User
        /// </summary>
        /// <param name="ScreenAccessID"></param>
        /// <param name="HasAccess"></param>
        public void UpdateScreenAccess(int ScreenAccessID, bool HasAccess)
        {
            try
            {
                this.init();

                SqlCommand cmd = new SqlCommand("spUpdateScreenAccess", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                string UserName = (String)HttpContext.Current.Session["LoggedOnUser"];

                cmd.Parameters.Add(new SqlParameter("@HasAccess", HasAccess));

                cmd.Parameters.Add(new SqlParameter("@ScreenAccessID", ScreenAccessID)); // Int
                cmd.Parameters.Add(new SqlParameter("@UserInfo", UserName));
                cmd.Parameters.Add(new SqlParameter("@UpdatedDateTime", DateTime.Now));

                cmd.ExecuteNonQuery();

                conn.Close();
            }
            catch (Exception ex)
            {
                conn.Close();
                Logger.Write(this.GetType().ToString() + " : UpdateScreenAccess() : " + " : " + DateTime.Now + " : " + ex.Message.ToString(), Category.General, Priority.Highest);
                throw ex;
            }
        }
        # endregion

        # region Update Password

        /// <summary>
        /// Updates the Current Password
        /// </summary>
        /// <param name="UserName"></param>
        /// <param name="NewPassword"></param>
        public void UpdatePassword(String NewPassword)
        {
            try
            {
                this.init();

                SqlCommand cmd = new SqlCommand("spUpdatePassword", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                string UserInfo = (String)HttpContext.Current.Session["LoggedOnUser"];

                cmd.Parameters.Add(new SqlParameter("@NewPassword", NewPassword));
                cmd.Parameters.Add(new SqlParameter("@UserInfo", UserInfo));
                cmd.Parameters.Add(new SqlParameter("@UpdatedDateTime", DateTime.Now));

                cmd.ExecuteNonQuery();

                conn.Close();
            }
            catch (Exception ex)
            {
                conn.Close();
                Logger.Write(this.GetType().ToString() + " : UpdatePassword() : " + " : " + DateTime.Now + " : " + ex.Message.ToString(), Category.General, Priority.Highest);
                throw ex;
            }
        }

        #endregion

        #endregion

        #region Stores

        public void InsertIntoVendorMaster(String VendorName, String Address1, String Address2, String Address3, String City,
            String State, String Pin, String TINNumber, String CSTNumber, String Email, String SupplierCode)
        {
            try
            {
                this.init();

                string UserName = (String)HttpContext.Current.Session["LoggedOnUser"];

                SqlCommand cmd = new SqlCommand("spInsertVendorMaster", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add(new SqlParameter("@VendorName", VendorName));
                cmd.Parameters.Add(new SqlParameter("@Address1", Address1));
                cmd.Parameters.Add(new SqlParameter("@Address2", Address2));
                cmd.Parameters.Add(new SqlParameter("@Address3", Address3));
                cmd.Parameters.Add(new SqlParameter("@City", City));
                cmd.Parameters.Add(new SqlParameter("@State", State));
                cmd.Parameters.Add(new SqlParameter("@Pin", Pin));
                cmd.Parameters.Add(new SqlParameter("@TINNumber", TINNumber));
                cmd.Parameters.Add(new SqlParameter("@CSTNumber", CSTNumber));
                cmd.Parameters.Add(new SqlParameter("@Email", Email));
                cmd.Parameters.Add(new SqlParameter("@SupplierCode", SupplierCode));

                cmd.ExecuteNonQuery();

                conn.Close();
            }
            catch (Exception ex)
            {
                conn.Close();
                Logger.Write(this.GetType().ToString() + " : InsertIntoVendorMaster() : " + " : " + DateTime.Now + " : " + ex.Message.ToString(), Category.General, Priority.Highest);
                throw ex;
            }
        }

        public void UpdateIntoVendorMaster(String VendorCode, String VendorName, String Address1, String Address2, String Address3, String City,
            String State, String Pin, String TINNumber, String CSTNumber, String Email, String SupplierCode)
        {
            try
            {
                this.init();

                string UserName = (String)HttpContext.Current.Session["LoggedOnUser"];

                SqlCommand cmd = new SqlCommand("spUpdateVendorMaster", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add(new SqlParameter("@VendorCode", VendorCode));
                cmd.Parameters.Add(new SqlParameter("@VendorName", VendorName));
                cmd.Parameters.Add(new SqlParameter("@Address1", Address1));
                cmd.Parameters.Add(new SqlParameter("@Address2", Address2));
                cmd.Parameters.Add(new SqlParameter("@Address3", Address3));
                cmd.Parameters.Add(new SqlParameter("@City", City));
                cmd.Parameters.Add(new SqlParameter("@State", State));
                cmd.Parameters.Add(new SqlParameter("@Pin", Pin));
                cmd.Parameters.Add(new SqlParameter("@TINNumber", TINNumber));
                cmd.Parameters.Add(new SqlParameter("@CSTNumber", CSTNumber));
                cmd.Parameters.Add(new SqlParameter("@Email", Email));
                cmd.Parameters.Add(new SqlParameter("@SupplierCode", SupplierCode));

                cmd.ExecuteNonQuery();

                conn.Close();
            }
            catch (Exception ex)
            {
                conn.Close();
                Logger.Write(this.GetType().ToString() + " : UpdateIntoVendorMaster() : " + " : " + DateTime.Now + " : " + ex.Message.ToString(), Category.General, Priority.Highest);
                throw ex;
            }
        }

        public void DeleteIntoVendorMaster(String VendorCode)
        {
            try
            {
                this.init();

                string UserName = (String)HttpContext.Current.Session["LoggedOnUser"];

                SqlCommand cmd = new SqlCommand("[spDeleteVendorMaster]", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add(new SqlParameter("@VendorCode", VendorCode));
                cmd.ExecuteNonQuery();

                conn.Close();
            }
            catch (Exception ex)
            {
                conn.Close();
                Logger.Write(this.GetType().ToString() + " : DeleteIntoVendorMaster() : " + " : " + DateTime.Now + " : " + ex.Message.ToString(), Category.General, Priority.Highest);
                throw ex;
            }
        }

        public DataSet RetriveByVendorMasterDetails()
        {
            DataSet ds = new DataSet();
            try
            {
                this.init();

                SqlCommand cmd = new SqlCommand("[spGetVendorMaster]", conn);
                cmd.CommandTimeout = 1000;
                cmd.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = cmd;

                da.Fill(ds);

                conn.Close();
                return ds;

            }
            catch (Exception ex)
            {
                conn.Close();
                Logger.Write(this.GetType().ToString() + " : RetriveByVendorMasterDetails() : " + " : " + DateTime.Now + " : " + ex.Message.ToString(), Category.General, Priority.Highest);
                throw ex;
            }
        }

        public void InsertIntoItemMaster(String ItemName, String Units)
        {
            try
            {
                this.init();

                string UserName = (String)HttpContext.Current.Session["LoggedOnUser"];

                SqlCommand cmd = new SqlCommand("spInsertItemMaster", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add(new SqlParameter("@ItemName", ItemName));
                cmd.Parameters.Add(new SqlParameter("@Units", Units));

                cmd.ExecuteNonQuery();

                conn.Close();
            }
            catch (Exception ex)
            {
                conn.Close();
                Logger.Write(this.GetType().ToString() + " : InsertIntoItemMaster() : " + " : " + DateTime.Now + " : " + ex.Message.ToString(), Category.General, Priority.Highest);
                throw ex;
            }
        }

        public void UpdateIntoItemMaster(String ItemCode, String ItemName, String Units)
        {
            try
            {
                this.init();

                string UserName = (String)HttpContext.Current.Session["LoggedOnUser"];

                SqlCommand cmd = new SqlCommand("spUpdateItemMaster", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add(new SqlParameter("@ItemCode", ItemCode));
                cmd.Parameters.Add(new SqlParameter("@ItemName", ItemName));
                cmd.Parameters.Add(new SqlParameter("@Units", Units));
                cmd.ExecuteNonQuery();

                conn.Close();
            }
            catch (Exception ex)
            {
                conn.Close();
                Logger.Write(this.GetType().ToString() + " : UpdateIntoItemMaster() : " + " : " + DateTime.Now + " : " + ex.Message.ToString(), Category.General, Priority.Highest);
                throw ex;
            }
        }

        public void DeleteIntoItemMaster(String ItemCode)
        {
            try
            {
                this.init();

                string UserName = (String)HttpContext.Current.Session["LoggedOnUser"];

                SqlCommand cmd = new SqlCommand("[spDeleteItemMaster]", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add(new SqlParameter("@ItemCode", ItemCode));
                cmd.ExecuteNonQuery();

                conn.Close();
            }
            catch (Exception ex)
            {
                conn.Close();
                Logger.Write(this.GetType().ToString() + " : DeleteIntoItemMaster() : " + " : " + DateTime.Now + " : " + ex.Message.ToString(), Category.General, Priority.Highest);
                throw ex;
            }
        }

        public DataSet RetriveByItemMasterDetails()
        {
            DataSet ds = new DataSet();
            try
            {
                this.init();

                SqlCommand cmd = new SqlCommand("[spGetItemMaster]", conn);
                cmd.CommandTimeout = 1000;
                cmd.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = cmd;

                da.Fill(ds);

                conn.Close();
                return ds;

            }
            catch (Exception ex)
            {
                conn.Close();
                Logger.Write(this.GetType().ToString() + " : RetriveByItemMasterDetails() : " + " : " + DateTime.Now + " : " + ex.Message.ToString(), Category.General, Priority.Highest);
                throw ex;
            }
        }

        public void InsertIntoEmployeeMaster(String EmployeeName, String Email, String VelanEmployeeCode, bool Dc)
        {
            try
            {
                this.init();

                string UserName = (String)HttpContext.Current.Session["LoggedOnUser"];

                SqlCommand cmd = new SqlCommand("spInsertEmployeeMaster", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add(new SqlParameter("@EmployeeName", EmployeeName));
                cmd.Parameters.Add(new SqlParameter("@Email", Email));
                cmd.Parameters.Add(new SqlParameter("@VelanEmployeeCode", VelanEmployeeCode));
                cmd.Parameters.Add(new SqlParameter("@Dc", Dc));

                cmd.ExecuteNonQuery();

                conn.Close();
            }
            catch (Exception ex)
            {
                conn.Close();
                Logger.Write(this.GetType().ToString() + " : InsertIntoEmployeeMaster() : " + " : " + DateTime.Now + " : " + ex.Message.ToString(), Category.General, Priority.Highest);
                throw ex;
            }
        }

        public void UpdateIntoEmployeeMaster(String EmployeeCode, String EmployeeName, String Email, String VelanEmployeeCode, bool Dc)
        {
            try
            {
                this.init();

                string UserName = (String)HttpContext.Current.Session["LoggedOnUser"];

                SqlCommand cmd = new SqlCommand("spUpdateEmployeeMaster", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add(new SqlParameter("@EmployeeCode", EmployeeCode));
                cmd.Parameters.Add(new SqlParameter("@EmployeeName", EmployeeName));
                cmd.Parameters.Add(new SqlParameter("@Email", Email));
                cmd.Parameters.Add(new SqlParameter("@VelanEmployeeCode", VelanEmployeeCode));
                cmd.Parameters.Add(new SqlParameter("@Dc", Dc));

                cmd.ExecuteNonQuery();

                conn.Close();
            }
            catch (Exception ex)
            {
                conn.Close();
                Logger.Write(this.GetType().ToString() + " : UpdateIntoEmployeeMaster() : " + " : " + DateTime.Now + " : " + ex.Message.ToString(), Category.General, Priority.Highest);
                throw ex;
            }
        }

        public void DeleteIntoEmployeeMaster(String EmployeeCode)
        {
            try
            {
                this.init();

                string UserName = (String)HttpContext.Current.Session["LoggedOnUser"];

                SqlCommand cmd = new SqlCommand("[spDeleteEmployeeMaster]", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add(new SqlParameter("@EmployeeCode", EmployeeCode));
                cmd.ExecuteNonQuery();

                conn.Close();
            }
            catch (Exception ex)
            {
                conn.Close();
                Logger.Write(this.GetType().ToString() + " : DeleteIntoEmployeeMaster() : " + " : " + DateTime.Now + " : " + ex.Message.ToString(), Category.General, Priority.Highest);
                throw ex;
            }
        }

        public DataSet RetriveByEmployeeMasterDetails()
        {
            DataSet ds = new DataSet();
            try
            {
                this.init();

                SqlCommand cmd = new SqlCommand("[spGetEmployeeMaster]", conn);
                cmd.CommandTimeout = 1000;
                cmd.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = cmd;

                da.Fill(ds);

                conn.Close();
                return ds;

            }
            catch (Exception ex)
            {
                conn.Close();
                Logger.Write(this.GetType().ToString() + " : RetriveByEmployeeMasterDetails() : " + " : " + DateTime.Now + " : " + ex.Message.ToString(), Category.General, Priority.Highest);
                throw ex;
            }
        }

        public DataSet GetEmailFormEmployeeName()
        {
            DataSet ds = new DataSet();
            try
            {
                this.init();

                SqlCommand cmd = new SqlCommand("[spGetEmployeeNameToSendMail]", conn);
                cmd.CommandTimeout = 1000;
                cmd.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = cmd;

                da.Fill(ds);

                conn.Close();
                return ds;
            }
            catch (Exception ex)
            {
                conn.Close();
                Logger.Write(this.GetType().ToString() + " : GetDCTypeName() : " + " : " + DateTime.Now + " : " + ex.Message.ToString(), Category.General, Priority.Highest);
                throw ex;
            }
        }

        public DataSet GetUnitsMasterDetails()
        {
            DataSet ds = new DataSet();
            try
            {
                this.init();

                SqlCommand cmd = new SqlCommand("select Id, Units from UnitsMaster", conn);
                cmd.CommandTimeout = 1000;
                cmd.CommandType = CommandType.Text;

                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = cmd;

                da.Fill(ds);

                conn.Close();
                return ds;
            }
            catch (Exception ex)
            {
                conn.Close();
                Logger.Write(this.GetType().ToString() + " : RetriveByEmployeeMasterDetails() : " + " : " + DateTime.Now + " : " + ex.Message.ToString(), Category.General, Priority.Highest);
                throw ex;
            }
        }

        public int GetItemCodeFromDescription(string ItemName)
        {
            DataSet ds = new DataSet();
            int itemCode = 0;

            try
            {
                this.init();

                SqlCommand cmd = new SqlCommand("select ItemCode from ItemMaster where ItemName = '" + ItemName + "'", conn);
                cmd.CommandTimeout = 1000;
                cmd.CommandType = CommandType.Text;

                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = cmd;

                da.Fill(ds);
                conn.Close();

                if (ds.Tables[0].Rows.Count > 0)
                {
                    itemCode = Convert.ToInt32(ds.Tables[0].Rows[0]["ItemCode"].ToString());
                }

                return itemCode;
            }
            catch (Exception ex)
            {
                conn.Close();
                Logger.Write(this.GetType().ToString() + " : GetItemCodeFromDescription() : " + " : " + DateTime.Now + " : " + ex.Message.ToString(), Category.General, Priority.Highest);
                throw ex;
            }
        }

        public string GetEmployeeNameByCode(int Employeecode)
        {
            DataSet ds = new DataSet();
            string EmployeeName = string.Empty;

            try
            {
                this.init();

                SqlCommand cmd = new SqlCommand("select EmployeeName from DCEmployeeMaster where EmployeeCode =  " + Employeecode + "", conn);
                cmd.CommandTimeout = 1000;
                cmd.CommandType = CommandType.Text;

                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = cmd;

                da.Fill(ds);
                conn.Close();

                if (ds.Tables[0].Rows.Count > 0)
                {
                    EmployeeName = Convert.ToString(ds.Tables[0].Rows[0]["EmployeeName"].ToString());
                }

                return EmployeeName;
            }
            catch (Exception ex)
            {
                conn.Close();
                Logger.Write(this.GetType().ToString() + " : GetItemCodeFromDescription() : " + " : " + DateTime.Now + " : " + ex.Message.ToString(), Category.General, Priority.Highest);
                throw ex;
            }
        }

        public DataSet GetItemName()
        {
            DataSet ds = new DataSet();
            try
            {
                this.init();

                SqlCommand cmd = new SqlCommand("select ItemName as ItemDescription from ItemMaster", conn);
                cmd.CommandTimeout = 1000;
                cmd.CommandType = CommandType.Text;

                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = cmd;

                da.Fill(ds);

                conn.Close();
                return ds;
            }
            catch (Exception ex)
            {
                conn.Close();
                Logger.Write(this.GetType().ToString() + " : RetriveByEmployeeMasterDetails() : " + " : " + DateTime.Now + " : " + ex.Message.ToString(), Category.General, Priority.Highest);
                throw ex;
            }
        }

        public DataSet RetriveByDeliveryChallanDetails()
        {
            DataSet ds = new DataSet();
            try
            {
                this.init();

                //SqlCommand cmd = new SqlCommand("[spGetItemMasterForDeliveryChallan]", conn);
                SqlCommand cmd = new SqlCommand("[spGetDeliveryChallanDetails]", conn);
                cmd.CommandTimeout = 1000;
                cmd.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = cmd;

                da.Fill(ds);

                conn.Close();
                return ds;
            }
            catch (Exception ex)
            {
                conn.Close();
                Logger.Write(this.GetType().ToString() + " : RetriveByDeliveryChallanDetails() : " + " : " + DateTime.Now + " : " + ex.Message.ToString(), Category.General, Priority.Highest);
                throw ex;
            }
        }

        public DataSet GetVendorName()
        {
            DataSet ds = new DataSet();
            try
            {
                this.init();

                SqlCommand cmd = new SqlCommand("Select VendorName, VendorCode from VendorMaster Order by VendorName", conn);
                cmd.CommandTimeout = 1000;
                cmd.CommandType = CommandType.Text;

                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = cmd;

                da.Fill(ds);

                conn.Close();
                return ds;
            }
            catch (Exception ex)
            {
                conn.Close();
                Logger.Write(this.GetType().ToString() + " : GetVendorName() : " + " : " + DateTime.Now + " : " + ex.Message.ToString(), Category.General, Priority.Highest);
                throw ex;
            }
        }

        public DataSet GetEmployeeName(int dc)
        {
            DataSet ds = new DataSet();
            try
            {
                this.init();

                SqlCommand cmd = new SqlCommand("[spGetDcPreparedAndRequestBy]", conn);
                cmd.CommandTimeout = 1000;
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add(new SqlParameter("@Dc", dc));

                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = cmd;

                da.Fill(ds);

                conn.Close();
                return ds;
            }
            catch (Exception ex)
            {
                conn.Close();
                Logger.Write(this.GetType().ToString() + " : GetEmployeeName() : " + " : " + DateTime.Now + " : " + ex.Message.ToString(), Category.General, Priority.Highest);
                throw ex;
            }
        }


        public DataSet GetDCTypeName()
        {
            DataSet ds = new DataSet();
            try
            {
                this.init();

                SqlCommand cmd = new SqlCommand("select DCType, DCCode from DCTypeMaster", conn);
                cmd.CommandTimeout = 1000;
                cmd.CommandType = CommandType.Text;

                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = cmd;

                da.Fill(ds);

                conn.Close();
                return ds;
            }
            catch (Exception ex)
            {
                conn.Close();
                Logger.Write(this.GetType().ToString() + " : GetDCTypeName() : " + " : " + DateTime.Now + " : " + ex.Message.ToString(), Category.General, Priority.Highest);
                throw ex;
            }
        }

        public DataSet GetDeliveryChallanSavedMasterDetails(string DCNumber)
        {
            DataSet ds = new DataSet();
            try
            {
                this.init();

                SqlCommand cmd = new SqlCommand("select * from DeliveryChallanMaster where DCNumber = '" + DCNumber + "'", conn);
                cmd.CommandTimeout = 1000;
                cmd.CommandType = CommandType.Text;

                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = cmd;

                da.Fill(ds);

                conn.Close();
                return ds;
            }
            catch (Exception ex)
            {
                conn.Close();
                Logger.Write(this.GetType().ToString() + " : GetDeliveryChallanSavedMasterDetails() : " + " : " + DateTime.Now + " : " + ex.Message.ToString(), Category.General, Priority.Highest);
                throw ex;
            }
        }

        public DataSet GetDeliveryChallanSavedDetails(string DCNumber)
        {
            DataSet ds = new DataSet();
            try
            {
                this.init();

                //SqlCommand cmd = new SqlCommand("select * from DeliveryChallanDetails where DCNumber = '" + DCNumber + "'", conn);
                SqlCommand cmd = new SqlCommand("select a.SlNo, a.ItemDescription, b.Units,b.Id, a.QuantityReceived, a.Quantity, a.Rate from DeliveryChallanDetails a, UnitsMaster b where a.DCNumber = '" + DCNumber + "' and a.Units = b.Units", conn);
                cmd.CommandTimeout = 1000;
                cmd.CommandType = CommandType.Text;

                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = cmd;

                da.Fill(ds);

                conn.Close();
                return ds;
            }
            catch (Exception ex)
            {
                conn.Close();
                Logger.Write(this.GetType().ToString() + " : GetDeliveryChallanSavedDetails() : " + " : " + DateTime.Now + " : " + ex.Message.ToString(), Category.General, Priority.Highest);
                throw ex;
            }
        }

        public DataSet GetDeliveryChallanReceivedQty(string DCNumber, int SlNo)
        {
            DataSet ds = new DataSet();
            try
            {
                this.init();

                SqlCommand cmd = new SqlCommand("select * from DeliveryChallanDetails where DCNumber = '" + DCNumber + "' and SlNo = " + SlNo + "", conn);
                cmd.CommandTimeout = 1000;
                cmd.CommandType = CommandType.Text;

                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = cmd;

                da.Fill(ds);

                conn.Close();
                return ds;
            }
            catch (Exception ex)
            {
                conn.Close();
                Logger.Write(this.GetType().ToString() + " : GetDeliveryChallanReceivedQty() : " + " : " + DateTime.Now + " : " + ex.Message.ToString(), Category.General, Priority.Highest);
                throw ex;
            }
        }

        public DataSet GetDCTypeSavedItems(string dctypeCode, int year)
        {
            DataSet ds = new DataSet();
            try
            {
                this.init();

                SqlCommand cmd = new SqlCommand("select top 1 DCNumber from DeliveryChallanMaster where DCTypeCode = '" + dctypeCode + "' and SUBSTRING(DCNumber,7,2) = '" + year + "' order by DCNumber desc", conn);
                cmd.CommandTimeout = 1000;
                cmd.CommandType = CommandType.Text;

                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = cmd;

                da.Fill(ds);

                conn.Close();
                return ds;
            }
            catch (Exception ex)
            {
                conn.Close();
                Logger.Write(this.GetType().ToString() + " : GetDCTypeSavedItems() : " + " : " + DateTime.Now + " : " + ex.Message.ToString(), Category.General, Priority.Highest);
                throw ex;
            }
        }

        public DataSet GetDCTypeSavedItemsForParticularYear(string dctypeCode)
        {
            DataSet ds = new DataSet();
            try
            {
                this.init();

                SqlCommand cmd = new SqlCommand("select top 1 DCNumber from DeliveryChallanMaster where DCTypeCode = '" + dctypeCode + "' order by DCNumber desc", conn);
                cmd.CommandTimeout = 1000;
                cmd.CommandType = CommandType.Text;

                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = cmd;

                da.Fill(ds);

                conn.Close();
                return ds;
            }
            catch (Exception ex)
            {
                conn.Close();
                Logger.Write(this.GetType().ToString() + " : GetDCTypeSavedItemsForParticularYear() : " + " : " + DateTime.Now + " : " + ex.Message.ToString(), Category.General, Priority.Highest);
                throw ex;
            }
        }

        public void InsertIntoDeliveryChallanMaster(string DCNumber, string DCType, string DCDate, int VendorCode, string Reason, int RequestedBy,
            int PreparedBy)
        {
            try
            {
                this.init();

                string UserName = (String)HttpContext.Current.Session["LoggedOnUser"];

                SqlCommand cmd = new SqlCommand("[spInsertDeliveryChallanMaster]", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add(new SqlParameter("@DCNumber", DCNumber));
                cmd.Parameters.Add(new SqlParameter("@DCTypeCode", DCType));
                cmd.Parameters.Add(new SqlParameter("@DCDate", DCDate));
                cmd.Parameters.Add(new SqlParameter("@VendorCode", VendorCode));
                cmd.Parameters.Add(new SqlParameter("@Reason", Reason));
                cmd.Parameters.Add(new SqlParameter("@RequestedBy", RequestedBy));
                cmd.Parameters.Add(new SqlParameter("@PreparedBy", PreparedBy));

                cmd.ExecuteNonQuery();

                conn.Close();
            }
            catch (Exception ex)
            {
                conn.Close();
                Logger.Write(this.GetType().ToString() + " : InsertIntoDeliveryChallanMaster() : " + " : " + DateTime.Now + " : " + ex.Message.ToString(), Category.General, Priority.Highest);
                throw ex;
            }
        }

        public void InsertIntoDeliveryChallanDetails(string DCNumber, int SlNo, string Units, decimal Quantity, decimal Rate, string ItemDescription, string ReceivedBy)
        {
            try
            {
                this.init();

                string UserName = (String)HttpContext.Current.Session["LoggedOnUser"];

                SqlCommand cmd = new SqlCommand("[spInsertDeliveryChallanDetails]", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add(new SqlParameter("@DCNumber", DCNumber));
                cmd.Parameters.Add(new SqlParameter("@SlNo", SlNo));
                cmd.Parameters.Add(new SqlParameter("@Units", Units));
                cmd.Parameters.Add(new SqlParameter("@Quantity", Quantity));
                cmd.Parameters.Add(new SqlParameter("@Rate", Rate));
                cmd.Parameters.Add(new SqlParameter("@ItemDescription", ItemDescription));

                cmd.ExecuteNonQuery();

                conn.Close();
            }
            catch (Exception ex)
            {
                conn.Close();
                Logger.Write(this.GetType().ToString() + " : InsertIntoDeliveryChallanDetails() : " + " : " + DateTime.Now + " : " + ex.Message.ToString(), Category.General, Priority.Highest);
                throw ex;
            }
        }

        public void UpdateIntoDeliveryChallanMaster(string DCNumber, string DCDate, int VendorCode, string Reason, int RequestedBy,
            int PreparedBy)
        {
            try
            {
                this.init();

                string UserName = (String)HttpContext.Current.Session["LoggedOnUser"];

                SqlCommand cmd = new SqlCommand("[spUpdateDeliveryChallanMaster]", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add(new SqlParameter("@DCNumber", DCNumber));
                //cmd.Parameters.Add(new SqlParameter("@DCTypeCode", DCType));
                cmd.Parameters.Add(new SqlParameter("@DCDate", DCDate));
                cmd.Parameters.Add(new SqlParameter("@VendorCode", VendorCode));
                cmd.Parameters.Add(new SqlParameter("@Reason", Reason));
                cmd.Parameters.Add(new SqlParameter("@RequestedBy", RequestedBy));
                cmd.Parameters.Add(new SqlParameter("@PreparedBy", PreparedBy));

                cmd.ExecuteNonQuery();

                conn.Close();
            }
            catch (Exception ex)
            {
                conn.Close();
                Logger.Write(this.GetType().ToString() + " : UpdateIntoDeliveryChallanMaster() : " + " : " + DateTime.Now + " : " + ex.Message.ToString(), Category.General, Priority.Highest);
                throw ex;
            }
        }

        public void UpdateIntoDeliveryChallanDetails(string DCNumber, int SlNo, string Units, decimal Quantity, decimal Rate, string ItemDescription, decimal QuantityReceived)
        {
            try
            {
                this.init();

                string UserName = (String)HttpContext.Current.Session["LoggedOnUser"];

                SqlCommand cmd = new SqlCommand("[spUpdateDeliveryChallanDetails]", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add(new SqlParameter("@DCNumber", DCNumber));
                cmd.Parameters.Add(new SqlParameter("@SlNo", SlNo));
                cmd.Parameters.Add(new SqlParameter("@Units", Units));
                cmd.Parameters.Add(new SqlParameter("@Quantity", Quantity));
                cmd.Parameters.Add(new SqlParameter("@Rate", Rate));
                cmd.Parameters.Add(new SqlParameter("@ItemDescription", ItemDescription));
                cmd.Parameters.Add(new SqlParameter("@QuantityReceived", QuantityReceived));

                cmd.ExecuteNonQuery();

                conn.Close();
            }
            catch (Exception ex)
            {
                conn.Close();
                Logger.Write(this.GetType().ToString() + " : UpdateIntoDeliveryChallanDetails() : " + " : " + DateTime.Now + " : " + ex.Message.ToString(), Category.General, Priority.Highest);
                throw ex;
            }
        }

        public bool IsVendorExist(int VendorCode)
        {
            DataSet ds = new DataSet();
            try
            {
                this.init();

                SqlCommand cmd = new SqlCommand("select * from DeliveryChallanReceipts where VendorCode = '" + VendorCode + "'", conn);
                cmd.CommandTimeout = 1000;
                cmd.CommandType = CommandType.Text;

                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = cmd;

                da.Fill(ds);

                conn.Close();

                if (ds.Tables[0].Rows.Count > 0)
                {
                    return true;
                }

                return false;
            }
            catch (Exception ex)
            {
                conn.Close();
                Logger.Write(this.GetType().ToString() + " : IsVendorExist() : " + " : " + DateTime.Now + " : " + ex.Message.ToString(), Category.General, Priority.Highest);
                throw ex;
            }
        }

        public void RemoveDeliveryChallanSavedDetails(int SlNo, string DCNumber)
        {
            try
            {
                this.init();

                SqlCommand cmd = new SqlCommand("[spDeleteDeliveryChallanDetails]", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                string UserName = (String)HttpContext.Current.Session["LoggedOnUser"];

                cmd.Parameters.Add(new SqlParameter("@SlNo", SlNo)); // String
                //cmd.Parameters.Add(new SqlParameter("@ItemCode", ItemCode));
                cmd.Parameters.Add(new SqlParameter("@DCNumber", DCNumber));

                cmd.ExecuteNonQuery();

                conn.Close();
            }
            catch (Exception ex)
            {
                conn.Close();
                Logger.Write(this.GetType().ToString() + " : RemoveDeliveryChallanSavedDetails() : " + " : " + DateTime.Now + " : " + ex.Message.ToString(), Category.General, Priority.Highest);
                throw ex;
            }
        }

        public void RemoveDeliveryChallanMasterAndDetails(string DCNumber)
        {
            try
            {
                this.init();

                SqlCommand cmd = new SqlCommand("[spDeleteDeliveryChallanMasterAndDetails]", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                string UserName = (String)HttpContext.Current.Session["LoggedOnUser"];
                cmd.Parameters.Add(new SqlParameter("@DCNumber", DCNumber));

                cmd.ExecuteNonQuery();

                conn.Close();
            }
            catch (Exception ex)
            {
                conn.Close();
                Logger.Write(this.GetType().ToString() + " : RemoveDeliveryChallanMasterAndDetails() : " + " : " + DateTime.Now + " : " + ex.Message.ToString(), Category.General, Priority.Highest);
                throw ex;
            }
        }

        public bool IsDCDetailsAvailableForSlNo(string DCNumber, int SlNo)
        {
            DataSet ds = new DataSet();
            try
            {
                this.init();

                SqlCommand cmd = new SqlCommand("select * from DeliveryChallanDetails where DCNumber = '" + DCNumber + "' and SlNo = '" + SlNo + "'", conn);
                cmd.CommandTimeout = 1000;
                cmd.CommandType = CommandType.Text;

                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = cmd;

                da.Fill(ds);

                conn.Close();

                if (ds.Tables[0].Rows.Count > 0)
                {
                    return true;
                }

                return false;
            }
            catch (Exception ex)
            {
                conn.Close();
                Logger.Write(this.GetType().ToString() + " : IsDCDetailsAvailableForSlNo() : " + " : " + DateTime.Now + " : " + ex.Message.ToString(), Category.General, Priority.Highest);
                throw ex;
            }
        }

        // Fetching Received quantity from Particular DC Number and Sl No
        public decimal GetReceivedQtyForParticularDCNumber(string DCNumber, int SlNo)
        {
            DataSet ds = new DataSet();
            decimal qtyReceived = 0;

            try
            {
                this.init();

                SqlCommand cmd = new SqlCommand("select QuantityReceived from DeliveryChallanDetails where DCNumber = '" + DCNumber + "' and SlNo = '" + SlNo + "' and QuantityReceived > 0", conn);
                cmd.CommandTimeout = 1000;
                cmd.CommandType = CommandType.Text;

                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = cmd;

                da.Fill(ds);

                conn.Close();

                if (ds.Tables[0].Rows.Count > 0)
                {
                    qtyReceived = Convert.ToDecimal(ds.Tables[0].Rows[0]["QuantityReceived"].ToString());
                }

                return qtyReceived;
            }
            catch (Exception ex)
            {
                conn.Close();
                Logger.Write(this.GetType().ToString() + " : GetReceivedQtyForParticularDCNumber() : " + " : " + DateTime.Now + " : " + ex.Message.ToString(), Category.General, Priority.Highest);
                throw ex;
            }
        }

        // Fetching Received quantity from Particular DC Number
        public decimal GetReceivedQtyFromDCNumber(string DCNumber)
        {
            DataSet ds = new DataSet();
            decimal qtyReceived = 0;

            try
            {
                this.init();

                SqlCommand cmd = new SqlCommand("select QuantityReceived from DeliveryChallanDetails where DCNumber = '" + DCNumber + "' and QuantityReceived > 0", conn);
                cmd.CommandTimeout = 1000;
                cmd.CommandType = CommandType.Text;

                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = cmd;

                da.Fill(ds);

                conn.Close();

                if (ds.Tables[0].Rows.Count > 0)
                {
                    qtyReceived = Convert.ToDecimal(ds.Tables[0].Rows[0]["QuantityReceived"].ToString());
                }

                return qtyReceived;
            }
            catch (Exception ex)
            {
                conn.Close();
                Logger.Write(this.GetType().ToString() + " : GetReceivedQtyForParticularDCNumber() : " + " : " + DateTime.Now + " : " + ex.Message.ToString(), Category.General, Priority.Highest);
                throw ex;
            }
        }

        public bool IsDCMasterAvailableForDCNo(string DCNumber)
        {
            DataSet ds = new DataSet();
            try
            {
                this.init();

                SqlCommand cmd = new SqlCommand("select * from DeliveryChallanMaster where DCNumber = '" + DCNumber + "'", conn);
                cmd.CommandTimeout = 1000;
                cmd.CommandType = CommandType.Text;

                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = cmd;

                da.Fill(ds);

                conn.Close();

                if (ds.Tables[0].Rows.Count > 0)
                {
                    return true;
                }

                return false;
            }
            catch (Exception ex)
            {
                conn.Close();
                Logger.Write(this.GetType().ToString() + " : IsDCMasterAvailableForDCNo() : " + " : " + DateTime.Now + " : " + ex.Message.ToString(), Category.General, Priority.Highest);
                throw ex;
            }
        }

        public DataSet RetriveByVendorNameForDeliveryChallan()
        {
            DataSet ds = new DataSet();
            try
            {
                this.init();

                SqlCommand cmd = new SqlCommand("[spGetVendorNameForChallanReceipts]", conn);
                cmd.CommandTimeout = 1000;
                cmd.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = cmd;

                da.Fill(ds);

                conn.Close();
                return ds;
            }
            catch (Exception ex)
            {
                conn.Close();
                Logger.Write(this.GetType().ToString() + " : RetriveByVendorNameForDeliveryChallan() : " + " : " + DateTime.Now + " : " + ex.Message.ToString(), Category.General, Priority.Highest);
                throw ex;
            }
        }

        public DataSet RetriveByDeliveryChallanReceiptsDetails(int VendorCode)
        {
            DataSet ds = new DataSet();
            try
            {
                this.init();

                SqlCommand cmd = new SqlCommand("[spGetDeliveryChallanReceiptsDetails]", conn);
                cmd.CommandTimeout = 1000;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@VendorCode", VendorCode));

                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = cmd;

                da.Fill(ds);

                conn.Close();
                return ds;
            }
            catch (Exception ex)
            {
                conn.Close();
                Logger.Write(this.GetType().ToString() + " : RetriveByDeliveryChallanReceiptsDetails() : " + " : " + DateTime.Now + " : " + ex.Message.ToString(), Category.General, Priority.Highest);
                throw ex;
            }
        }

        public void InsertIntoDeliveryChallanReceiptsDetails(int VendorCode, string ReceivedDate, string DCNumber, int SlNo,
            decimal QuantityReceived, string VendorDCNumber, string VendorDCDate, string ReceivedBy)
        {
            try
            {
                this.init();

                string UserName = (String)HttpContext.Current.Session["LoggedOnUser"];

                SqlCommand cmd = new SqlCommand("[spInsertDeliveryChallanReceiptsDetails]", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add(new SqlParameter("@VenderCode", VendorCode));
                cmd.Parameters.Add(new SqlParameter("@ReceivedDate", ReceivedDate));
                cmd.Parameters.Add(new SqlParameter("@DCNumber", DCNumber));
                cmd.Parameters.Add(new SqlParameter("@DCSlNo", SlNo));
                cmd.Parameters.Add(new SqlParameter("@QuantityReceived", QuantityReceived));
                cmd.Parameters.Add(new SqlParameter("@VendorDCNumber", VendorDCNumber));
                cmd.Parameters.Add(new SqlParameter("@VendorDCDate", VendorDCDate));
                cmd.Parameters.Add(new SqlParameter("@ReceivedBy", ReceivedBy));

                cmd.ExecuteNonQuery();

                conn.Close();
            }
            catch (Exception ex)
            {
                conn.Close();
                Logger.Write(this.GetType().ToString() + " : InsertIntoDeliveryChallanReceiptsDetails() : " + " : " + DateTime.Now + " : " + ex.Message.ToString(), Category.General, Priority.Highest);
                throw ex;
            }
        }

        public void UpdateIntoDeliveryChallanReceiptsDetails(int VendorCode, string ReceivedDate, string DCNumber, int SlNo,
            decimal QuantityReceived, string VendorDCNumber, string VendorDCDate, string ReceivedBy)
        {
            try
            {
                this.init();

                string UserName = (String)HttpContext.Current.Session["LoggedOnUser"];

                SqlCommand cmd = new SqlCommand("[spUpdateDeliveryChallanReceiptsDetails]", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add(new SqlParameter("@VenderCode", VendorCode));
                cmd.Parameters.Add(new SqlParameter("@ReceivedDate", ReceivedDate));
                cmd.Parameters.Add(new SqlParameter("@DCNumber", DCNumber));
                cmd.Parameters.Add(new SqlParameter("@DCSlNo", SlNo));
                cmd.Parameters.Add(new SqlParameter("@QuantityReceived", QuantityReceived));
                cmd.Parameters.Add(new SqlParameter("@VendorDCNumber", VendorDCNumber));
                cmd.Parameters.Add(new SqlParameter("@VendorDCDate", VendorDCDate));
                cmd.Parameters.Add(new SqlParameter("@ReceivedBy", ReceivedBy));

                cmd.ExecuteNonQuery();

                conn.Close();
            }
            catch (Exception ex)
            {
                conn.Close();
                Logger.Write(this.GetType().ToString() + " : UpdateIntoDeliveryChallanReceiptsDetails() : " + " : " + DateTime.Now + " : " + ex.Message.ToString(), Category.General, Priority.Highest);
                throw ex;
            }
        }

        public DataSet GetDeliveryChallanDetailsForPrint(string DCNumber)
        {
            DataSet ds = new DataSet();
            try
            {
                this.init();

                SqlCommand cmd = new SqlCommand("[spGetDcDetailsForPrint]", conn);
                cmd.CommandTimeout = 1000;
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add(new SqlParameter("@DCNumber", DCNumber));

                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = cmd;

                da.Fill(ds);

                conn.Close();
                return ds;
            }
            catch (Exception ex)
            {
                conn.Close();
                Logger.Write(this.GetType().ToString() + " : GetDeliveryChallanDetailsForPrint() : " + " : " + DateTime.Now + " : " + ex.Message.ToString(), Category.General, Priority.Highest);
                throw ex;
            }
        }

        public int GetDCPendings(int RequestedBy)
        {
            DataSet ds = new DataSet();
            try
            {
                this.init();
                int Count = 0;

                SqlCommand cmd = new SqlCommand("[spGetDCPending]", conn);
                cmd.CommandTimeout = 1000;
                cmd.CommandType = CommandType.StoredProcedure;

                string UserName = (String)HttpContext.Current.Session["LoggedOnUser"];

                cmd.Parameters.Add(new SqlParameter("@Requestedby", RequestedBy));

                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = cmd;

                da.Fill(ds);

                if (ds.Tables[0].Rows.Count > 0)
                {
                    Count = Convert.ToInt32(ds.Tables[0].Rows[0]["PendingDC"].ToString());
                }
                conn.Close();

                return Count;
            }
            catch (Exception ex)
            {
                conn.Close();
                Logger.Write(this.GetType().ToString() + " : GetDCPendings() : " + " : " + DateTime.Now + " : " + ex.Message.ToString(), Category.General, Priority.Highest);
                throw ex;
            }
        }


        public DataSet RetriveByDCPendingItems()
        {
            DataSet ds = new DataSet();

            try
            {
                this.init();

                SqlCommand cmd = new SqlCommand("[spGetDCPendingItems]", conn);
                cmd.CommandTimeout = 1000;
                cmd.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = cmd;

                da.Fill(ds);

                conn.Close();
                return ds;

            }
            catch (Exception ex)
            {
                //LogError(ex, "Exception from export button click!");
                conn.Close();
                Logger.Write(this.GetType().ToString() + " : RetriveByDCPendingItems() : " + " : " + DateTime.Now + " : " + ex.Message.ToString(), Category.General, Priority.Highest);
                throw ex;
            }
        }

        public DataSet RetriveByDCSentItems(string FromDate, string ToDate)
        {
            DataSet ds = new DataSet();

            try
            {
                this.init();

                SqlCommand cmd = new SqlCommand("[spGetDCSentItems]", conn);
                cmd.CommandTimeout = 1000;
                cmd.CommandType = CommandType.StoredProcedure;

                string UserName = (String)HttpContext.Current.Session["LoggedOnUser"];
                cmd.Parameters.Add(new SqlParameter("@FromDate", FromDate));
                cmd.Parameters.Add(new SqlParameter("@ToDate", ToDate));

                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = cmd;

                da.Fill(ds);

                conn.Close();
                return ds;

            }
            catch (Exception ex)
            {
                //LogError(ex, "Exception from export button click!");
                conn.Close();
                Logger.Write(this.GetType().ToString() + " : RetriveByDCSentItems() : " + " : " + DateTime.Now + " : " + ex.Message.ToString(), Category.General, Priority.Highest);
                throw ex;
            }
        }

        public DataSet RetriveByDCReceivedItems(string FromDate, string ToDate)
        {
            DataSet ds = new DataSet();

            try
            {
                this.init();

                SqlCommand cmd = new SqlCommand("[spGetDCReceivedItems]", conn);
                cmd.CommandTimeout = 1000;
                cmd.CommandType = CommandType.StoredProcedure;

                string UserName = (String)HttpContext.Current.Session["LoggedOnUser"];
                cmd.Parameters.Add(new SqlParameter("@FromDate", FromDate));
                cmd.Parameters.Add(new SqlParameter("@ToDate", ToDate));

                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = cmd;

                da.Fill(ds);

                conn.Close();
                return ds;

            }
            catch (Exception ex)
            {
                //LogError(ex, "Exception from export button click!");
                conn.Close();
                Logger.Write(this.GetType().ToString() + " : RetriveByDCReceivedItems() : " + " : " + DateTime.Now + " : " + ex.Message.ToString(), Category.General, Priority.Highest);
                throw ex;
            }
        }

        public DataSet RetriveByDCPendingItemsToSendMail(string EmailId)
        {
            DataSet ds = new DataSet();

            try
            {
                this.init();

                SqlCommand cmd = new SqlCommand("[spGetDCPendingItemsToSendMail]", conn);
                cmd.CommandTimeout = 1000;
                cmd.CommandType = CommandType.StoredProcedure;

                string UserName = (String)HttpContext.Current.Session["LoggedOnUser"];
                cmd.Parameters.Add(new SqlParameter("@EmailId", EmailId));

                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = cmd;

                da.Fill(ds);

                conn.Close();
                return ds;

            }
            catch (Exception ex)
            {
                //LogError(ex, "Exception from export button click!");
                conn.Close();
                Logger.Write(this.GetType().ToString() + " : RetriveByDCPendingItemsToSendMail() : " + " : " + DateTime.Now + " : " + ex.Message.ToString(), Category.General, Priority.Highest);
                throw ex;
            }
        }

        #endregion

        #region MIS Utility
        /// <summary>
        /// To retreive the data from MISOrderStatus table
        /// </summary>
        /// <returns></returns>
        public DataSet RetrievesSalesOrderLineItemForDeletion()
        {
            DataSet ds = new DataSet();
            try
            {
                this.init();

                SqlCommand cmd = new SqlCommand("[spGetSalesOrderLineItemForDeletion]", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = cmd;

                da.Fill(ds);

                conn.Close();
                return ds;
            }
            catch (Exception ex)
            {
                conn.Close();
                Logger.Write(this.GetType().ToString() + " : RetrievesSalesOrderLineItemForDeletion() : " + " : " + DateTime.Now + " : " + ex.Message.ToString(), Category.General, Priority.Highest);
                throw ex;
            }
        }

        public DataSet RetriveBySerialNoDetails(string SerialNo)
        {
            DataSet ds = new DataSet();
            try
            {
                this.init();

                SqlCommand cmd = new SqlCommand("[spGetSerialNoDetails]", conn);
                cmd.CommandTimeout = 1000;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@SerialNo", SerialNo));

                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = cmd;

                da.Fill(ds);

                conn.Close();
                return ds;

            }
            catch (Exception ex)
            {
                conn.Close();
                Logger.Write(this.GetType().ToString() + " : RetriveBySerialNoDetails() : " + " : " + DateTime.Now + " : " + ex.Message.ToString(), Category.General, Priority.Highest);
                throw ex;

            }
        }

        public DataSet RetriveByProdOrderNoFromMisUtility(string ProdOrerNo)
        {
            DataSet ds = new DataSet();
            try
            {
                this.init();

                SqlCommand cmd = new SqlCommand("[spGetProdOrderNoFromMISUtility]", conn);
                cmd.CommandTimeout = 1000;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@ProdOrderNo", ProdOrerNo));

                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = cmd;

                da.Fill(ds);

                conn.Close();
                return ds;

            }
            catch (Exception ex)
            {
                conn.Close();
                Logger.Write(this.GetType().ToString() + " : RetriveByProdOrderNoFromMisUtility() : " + " : " + DateTime.Now + " : " + ex.Message.ToString(), Category.General, Priority.Highest);
                throw ex;

            }
        }

        public DataSet RetriveBySaleOrderNoAndPosDetails(int OrderNo, int Pos)
        {
            DataSet ds = new DataSet();
            try
            {
                this.init();

                SqlCommand cmd = new SqlCommand("[spGetSaleOrderNoAndPosFromMISUtility]", conn);
                cmd.CommandTimeout = 1000;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@OrderNo", OrderNo));
                cmd.Parameters.Add(new SqlParameter("@Pos", Pos));

                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = cmd;

                da.Fill(ds);

                conn.Close();
                return ds;

            }
            catch (Exception ex)
            {
                conn.Close();
                Logger.Write(this.GetType().ToString() + " : RetriveBySerialNoDetails() : " + " : " + DateTime.Now + " : " + ex.Message.ToString(), Category.General, Priority.Highest);
                throw ex;

            }
        }

        public DataSet RetriveBySaleOrderQtyDecrement()
        {
            DataSet ds = new DataSet();
            try
            {
                this.init();

                SqlCommand cmd = new SqlCommand("[spGetSaleOrderQtyDecrement]", conn);
                cmd.CommandTimeout = 1000;
                cmd.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = cmd;

                da.Fill(ds);

                conn.Close();
                return ds;

            }
            catch (Exception ex)
            {
                conn.Close();
                Logger.Write(this.GetType().ToString() + " : RetriveBySaleOrderQtyDecrement() : " + " : " + DateTime.Now + " : " + ex.Message.ToString(), Category.General, Priority.Highest);
                throw ex;

            }
        }

        public DataSet RetriveBySerialNoDetails()
        {
            DataSet ds = new DataSet();
            try
            {
                this.init();

                SqlCommand cmd = new SqlCommand("[spGetMISUtilitySerialNoDetails]", conn);
                cmd.CommandTimeout = 1000;
                cmd.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = cmd;

                da.Fill(ds);

                conn.Close();
                return ds;

            }
            catch (Exception ex)
            {
                conn.Close();
                Logger.Write(this.GetType().ToString() + " : RetriveBySerialNoDetails() : " + " : " + DateTime.Now + " : " + ex.Message.ToString(), Category.General, Priority.Highest);
                throw ex;

            }
        }

        public void UpdateSaleOrderQtyDecrement(int QtyToBeReduced, int OrderNo, int Pos)
        {
            try
            {
                this.init();

                SqlCommand cmd = new SqlCommand("[spUpdateSaleOrderQtyDecrement]", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add(new SqlParameter("@QtyToBeReduced", QtyToBeReduced));
                cmd.Parameters.Add(new SqlParameter("@OrderNo", OrderNo)); 
                cmd.Parameters.Add(new SqlParameter("@Pos", Pos));
                cmd.ExecuteNonQuery();

                conn.Close();
            }
            catch (Exception ex)
            {
                conn.Close();
                Logger.Write(this.GetType().ToString() + " : UpdateSaleOrderQtyDecrement() : " + " : " + DateTime.Now + " : " + ex.Message.ToString(), Category.General, Priority.Highest);
                throw ex;
            }
        }

        public void UpdateSalesOrderLineItemDeletion(int OrderNo, int Pos)
        {
            try
            {
                this.init();

                SqlCommand cmd = new SqlCommand("[spUpdateSalesOrderLineItemDeletion]", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@OrderNo", OrderNo));
                cmd.Parameters.Add(new SqlParameter("@Pos", Pos));

                cmd.ExecuteNonQuery();

                conn.Close();
            }
            catch (Exception ex)
            {
                conn.Close();
                Logger.Write(this.GetType().ToString() + " : UpdateSalesOrderLineItemDeletion() : " + " : " + DateTime.Now + " : " + ex.Message.ToString(), Category.General, Priority.Highest);
                throw ex;
            }
        }

        public DataSet RetrieveBaaNDataForFGOrderChangeFromGrid()
        {
            DataSet ds = new DataSet();
            try
            {
                this.init();

                SqlCommand cmd = new SqlCommand("spGetBaanDataFGOrderChangeForFromGrid", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = cmd;

                da.Fill(ds);

                conn.Close();
                return ds;
            }
            catch (Exception ex)
            {
                conn.Close();
                Logger.Write(this.GetType().ToString() + " : RetrieveBaaNDataForFGOrderChangeFromGrid() : " + " : " + DateTime.Now + " : " + ex.Message.ToString(), Category.General, Priority.Highest);
                throw ex;
            }
        }

        public DataSet RetrieveBaaNDataForFGOrderChangeToGrid(int QtyToConvert)
        {
            DataSet ds = new DataSet();
            try
            {
                this.init();

                SqlCommand cmd = new SqlCommand("[spGetBaanDataFGOrderChangeForToGrid]", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@QtyToConvert", QtyToConvert));

                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = cmd;

                da.Fill(ds);

                conn.Close();
                return ds;
            }
            catch (Exception ex)
            {
                conn.Close();
                Logger.Write(this.GetType().ToString() + " : RetrieveBaaNDataForFGOrderChangeToGrid() : " + " : " + DateTime.Now + " : " + ex.Message.ToString(), Category.General, Priority.Highest);
                throw ex;
            }
        }

        public void UpdateBaaNDataInMISOrderStatusFromOrder(int OrderNum, int Pos, int ToReleaseQty, int FGQty, int QtyToConvert)
        {
            try
            {
                this.init();

                SqlCommand cmd = new SqlCommand("spUpdateLogicForFGOrderChangeFromOrder", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add(new SqlParameter("@OrderNum", OrderNum)); // int
                cmd.Parameters.Add(new SqlParameter("@Pos", Pos)); // Int
                cmd.Parameters.Add(new SqlParameter("@ToReleaseQty", ToReleaseQty)); // int
                cmd.Parameters.Add(new SqlParameter("@FGQty", FGQty)); //String
                cmd.Parameters.Add(new SqlParameter("@QtyToConvert", QtyToConvert)); // int

                cmd.ExecuteNonQuery();

                conn.Close();
            }
            catch (Exception ex)
            {
                conn.Close();
                Logger.Write(this.GetType().ToString() + " : UpdateBaaNDataInMISOrderStatusFromOrder() : " + " : " + DateTime.Now + " : " + ex.Message.ToString(), Category.General, Priority.Highest);
                throw ex;
            }
        }

        public void UpdateBaaNDataInMISOrderStatusToOrder(int OrderNum, int Pos, int ToReleaseQty, int FGQty, int QtyToConvert)
        {
            try
            {
                this.init();

                SqlCommand cmd = new SqlCommand("spUpdateLogicForFGOrderChangeToOrder", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add(new SqlParameter("@OrderNum", OrderNum)); // int
                cmd.Parameters.Add(new SqlParameter("@Pos", Pos)); // Int
                cmd.Parameters.Add(new SqlParameter("@ToReleaseQty", ToReleaseQty)); // int
                cmd.Parameters.Add(new SqlParameter("@FGQty", FGQty)); //Int
                cmd.Parameters.Add(new SqlParameter("@QtyToConvert", QtyToConvert)); // int

                cmd.ExecuteNonQuery();

                conn.Close();
            }
            catch (Exception ex)
            {
                conn.Close();
                Logger.Write(this.GetType().ToString() + " : UpdateBaaNDataInMISOrderStatusToOrder() : " + " : " + DateTime.Now + " : " + ex.Message.ToString(), Category.General, Priority.Highest);
                throw ex;
            }
        }

        public void InsertFGConvert(int FromOrderNum, int FromPos, int QtyToConvert, int ToOrderNum, int ToPos)
        {
            try
            {
                this.init();

                string UserName = (String)HttpContext.Current.Session["LoggedOnUser"];

                SqlCommand cmd = new SqlCommand("[spInsertFGConvert]", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add(new SqlParameter("@FromOrderNum", FromOrderNum)); // int
                cmd.Parameters.Add(new SqlParameter("@FromPos", FromPos)); // Int
                cmd.Parameters.Add(new SqlParameter("@ToOrderNum", ToOrderNum)); // int
                cmd.Parameters.Add(new SqlParameter("@ToPos", ToPos)); //Int
                cmd.Parameters.Add(new SqlParameter("@Quantity", QtyToConvert)); // int
                cmd.Parameters.Add(new SqlParameter("@CreatedBy", UserName)); // String
                cmd.Parameters.Add(new SqlParameter("@CreatedOn", DateTime.Now)); // DateTime

                cmd.ExecuteNonQuery();

                conn.Close();
            }
            catch (Exception ex)
            {
                conn.Close();
                Logger.Write(this.GetType().ToString() + " : InsertFGConvert() : " + " : " + DateTime.Now + " : " + ex.Message.ToString(), Category.General, Priority.Highest);
                throw ex;
            }
        }

        public DataSet RetrieveFGToWIReversalItems(int OrderNo, int Pos, int Flag)
        {
            DataSet ds = new DataSet();
            try
            {
                this.init();

                SqlCommand cmd = new SqlCommand("[spGetFGToWIPReversal]", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@OrderNum", OrderNo));
                cmd.Parameters.Add(new SqlParameter("@Pos", Pos));
                cmd.Parameters.Add(new SqlParameter("@IsCount", Flag));

                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = cmd;

                da.Fill(ds);

                conn.Close();
                return ds;
            }
            catch (Exception ex)
            {
                conn.Close();
                Logger.Write(this.GetType().ToString() + " : RetrieveFGToWIReversalItems() : " + " : " + DateTime.Now + " : " + ex.Message.ToString(), Category.General, Priority.Highest);
                throw ex;
            }
        }

        public void UpdateFGToWIReversalItems(int OrderNum, int Pos, string SerialNo)
        {
            try
            {
                this.init();

                string UserName = (String)HttpContext.Current.Session["LoggedOnUser"];

                SqlCommand cmd = new SqlCommand("[spUpdateFGToWIPReversal]", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add(new SqlParameter("@OrderNo", OrderNum)); // int
                cmd.Parameters.Add(new SqlParameter("@Pos", Pos)); // Int
                cmd.Parameters.Add(new SqlParameter("@SerialNo", SerialNo)); // String
                cmd.Parameters.Add(new SqlParameter("@UpdatedBy", UserName)); // int
                cmd.Parameters.Add(new SqlParameter("@UpdatedOn", DateTime.Now)); //Int

                cmd.ExecuteNonQuery();

                conn.Close();
            }
            catch (Exception ex)
            {
                conn.Close();
                Logger.Write(this.GetType().ToString() + " : UpdateFGToWIReversalItems() : " + " : " + DateTime.Now + " : " + ex.Message.ToString(), Category.General, Priority.Highest);
                throw ex;
            }
        }


        public DataSet RetriveBySupplierNameDetails()
        {
            DataSet ds = new DataSet();
            try
            {
                this.init();

                SqlCommand cmd = new SqlCommand("[spGetSupplierNameDetails]", conn);
                cmd.CommandTimeout = 1000;
                cmd.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = cmd;

                da.Fill(ds);

                conn.Close();
                return ds;

            }
            catch (Exception ex)
            {
                conn.Close();
                Logger.Write(this.GetType().ToString() + " : RetriveBySupplierNameDetails() : " + " : " + DateTime.Now + " : " + ex.Message.ToString(), Category.General, Priority.Highest);
                throw ex;
            }
        }

        public void UpdateSupplierNameDetails(int UserId, string UserName, string SupplierName)
        {
            try
            {
                this.init();

                string _LoggedUserName = (String)HttpContext.Current.Session["LoggedOnUser"];

                SqlCommand cmd = new SqlCommand("[spUpdateSupplierName]", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add(new SqlParameter("@UserID", UserId)); // int
                cmd.Parameters.Add(new SqlParameter("@UserName", UserName)); // String
                cmd.Parameters.Add(new SqlParameter("@SupplierName", SupplierName)); // String
                cmd.Parameters.Add(new SqlParameter("@UpdatedBy", UserName)); // int
                cmd.Parameters.Add(new SqlParameter("@UpdatedOn", DateTime.Now)); //Int

                cmd.ExecuteNonQuery();

                conn.Close();
            }
            catch (Exception ex)
            {
                conn.Close();
                Logger.Write(this.GetType().ToString() + " : UpdateFGToWIReversalItems() : " + " : " + DateTime.Now + " : " + ex.Message.ToString(), Category.General, Priority.Highest);
                throw ex;
            }
        }

        public DataSet RetriveByMISReadyToReleaseDetails()
        {
            DataSet ds = new DataSet();
            try
            {
                this.init();

                SqlCommand cmd = new SqlCommand("[spGetMISUtilityReadyToRelease]", conn);
                cmd.CommandTimeout = 1000;
                cmd.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = cmd;

                da.Fill(ds);

                conn.Close();
                return ds;

            }
            catch (Exception ex)
            {
                conn.Close();
                Logger.Write(this.GetType().ToString() + " : RetriveByMISReadyToReleaseDetails() : " + " : " + DateTime.Now + " : " + ex.Message.ToString(), Category.General, Priority.Highest);
                throw ex;
            }
        }

        public DataSet RetriveByEmployeesNameForUtilityRequest()
        {
            DataSet ds = new DataSet();

            try
            {
                this.init();

                SqlCommand cmd = new SqlCommand("select EmployeeCode, EmployeeName, * from DCEmployeeMaster Order by DCEmployeeMaster.EmployeeName", conn);
                cmd.CommandTimeout = 1000;
                cmd.CommandType = CommandType.Text;

                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = cmd;

                da.Fill(ds);

                conn.Close();
                return ds;

            }
            catch (Exception ex)
            {
                //LogError(ex, "Exception from export button click!");
                conn.Close();
                Logger.Write(this.GetType().ToString() + " : RetriveByEmployeesNameForUtilityRequest() : " + " : " + DateTime.Now + " : " + ex.Message.ToString(), Category.General, Priority.Highest);
                throw ex;
            }
        }

        public DataSet RetrieveByItemNumberFromInventory(string ItemNumber)
        {
            DataSet ds = new DataSet();
            try
            {
                this.init();

                SqlCommand cmd = new SqlCommand("[spValidateItemNumberFromInventory]", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@ItemNumber", ItemNumber));
                
                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = cmd;

                da.Fill(ds);

                conn.Close();
                return ds;
            }
            catch (Exception ex)
            {
                conn.Close();
                Logger.Write(this.GetType().ToString() + " : RetrieveByItemNumberFromInventory() : " + " : " + DateTime.Now + " : " + ex.Message.ToString(), Category.General, Priority.Highest);
                throw ex;
            }
        }

        public void InsertStockTransferRequest(int RequestedBy, DateTime RequestDate, string ItemcodeFrom, string ItemcodeTo, int OrderNo, int Pos, float Quantity,
            string Remarks)
        {
            try
            {
                this.init();

                string UserName = (String)HttpContext.Current.Session["LoggedOnUser"];

                SqlCommand cmd = new SqlCommand("[spInsertStockTransferRequest]", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add(new SqlParameter("@RequestedBy", RequestedBy)); // int
                cmd.Parameters.Add(new SqlParameter("@RequestDate", RequestDate)); // Int
                cmd.Parameters.Add(new SqlParameter("@ItemcodeFrom", ItemcodeFrom)); // int
                cmd.Parameters.Add(new SqlParameter("@ItemcodeTo", ItemcodeTo)); //Int
                cmd.Parameters.Add(new SqlParameter("@OrderNo", OrderNo)); // int
                cmd.Parameters.Add(new SqlParameter("@pos", Pos)); // String
                cmd.Parameters.Add(new SqlParameter("@Quantity", Quantity)); // DateTime
                cmd.Parameters.Add(new SqlParameter("@RequestRemarks", Remarks)); // String

                cmd.ExecuteNonQuery();

                conn.Close();
            }
            catch (Exception ex)
            {
                conn.Close();
                Logger.Write(this.GetType().ToString() + " : InsertStockTransferRequest() : " + " : " + DateTime.Now + " : " + ex.Message.ToString(), Category.General, Priority.Highest);
                throw ex;
            }
        }

        public DataSet RetriveByMISUtilityQualityEmployee()
        {
            DataSet ds = new DataSet();
            try
            {
                this.init();

                SqlCommand cmd = new SqlCommand("SELECT EmployeeCode, EmployeeName FROM DCEmployeeMaster WHERE (stocktransferapproval = 1) ORDER BY EmployeeName", conn);
                cmd.CommandTimeout = 1000;
                cmd.CommandType = CommandType.Text;

                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = cmd;

                da.Fill(ds);

                conn.Close();
                return ds;

            }
            catch (Exception ex)
            {
                conn.Close();
                Logger.Write(this.GetType().ToString() + " : RetriveByMISUtilityQualityEmployee() : " + " : " + DateTime.Now + " : " + ex.Message.ToString(), Category.General, Priority.Highest);
                throw ex;
            }
        }

        public DataSet RetriveByMISUtilityQualityDisposition()
        {
            DataSet ds = new DataSet();

            try
            {
                this.init();

                SqlCommand cmd = new SqlCommand("SELECT Disposition FROM  Disposition WHERE(QC = 1) ORDER BY Disposition", conn);
                cmd.CommandTimeout = 1000;
                cmd.CommandType = CommandType.Text;

                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = cmd;

                da.Fill(ds);

                conn.Close();
                return ds;

            }
            catch (Exception ex)
            {
                conn.Close();
                Logger.Write(this.GetType().ToString() + " : RetriveByMISUtilityQualityDisposition() : " + " : " + DateTime.Now + " : " + ex.Message.ToString(), Category.General, Priority.Highest);
                throw ex;
            }
        }

        public DataSet RetriveByMISUtilityQualityDetails()
        {
            DataSet ds = new DataSet();
            try
            {
                this.init();

                SqlCommand cmd = new SqlCommand("[spGetStockTransferRequestForQuality]", conn);
                cmd.CommandTimeout = 1000;
                cmd.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = cmd;

                da.Fill(ds);

                conn.Close();
                return ds;

            }
            catch (Exception ex)
            {
                conn.Close();
                Logger.Write(this.GetType().ToString() + " : RetriveByMISUtilityQualityDetails() : " + " : " + DateTime.Now + " : " + ex.Message.ToString(), Category.General, Priority.Highest);
                throw ex;
            }
        }

        public void UpdateMISUtilityQuality(int QcBy, DateTime QcOn, string QcDisposition, int Id, string Remarks)
        {
            try
            {
                this.init();

                SqlCommand cmd = new SqlCommand("Update StockTransferRequest SET QCBy = '"+ QcBy + "', QCOn = '"+ QcOn.ToString("yyyy-MM-dd") + "', QCDisposition = '"+ QcDisposition + "', QCRemarks ='"+Remarks+"' where Id = '" + Id + "'", conn);
                cmd.CommandType = CommandType.Text;

                cmd.ExecuteNonQuery();

                conn.Close();
            }
            catch (Exception ex)
            {
                conn.Close();
                Logger.Write(this.GetType().ToString() + " : UpdateMISUtilityQuality() : " + " : " + DateTime.Now + " : " + ex.Message.ToString(), Category.General, Priority.Highest);
                throw ex;
            }
        }

        public DataSet RetriveByMISUtilityStores()
        {
            DataSet ds = new DataSet();

            try
            {
                this.init();

                SqlCommand cmd = new SqlCommand("SELECT Disposition FROM Disposition WHERE (Stores = 1) ORDER BY Disposition", conn);
                cmd.CommandTimeout = 1000;
                cmd.CommandType = CommandType.Text;

                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = cmd;

                da.Fill(ds);

                conn.Close();
                return ds;

            }
            catch (Exception ex)
            {
                conn.Close();
                Logger.Write(this.GetType().ToString() + " : RetriveByMISUtilityStores() : " + " : " + DateTime.Now + " : " + ex.Message.ToString(), Category.General, Priority.Highest);
                throw ex;
            }
        }

        public DataSet RetriveByMISUtilityStoresDetails()
        {
            DataSet ds = new DataSet();
            try
            {
                this.init();

                SqlCommand cmd = new SqlCommand("[spGetStockTransferRequestForMISStores]", conn);
                cmd.CommandTimeout = 1000;
                cmd.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = cmd;

                da.Fill(ds);

                conn.Close();
                return ds;

            }
            catch (Exception ex)
            {
                conn.Close();
                Logger.Write(this.GetType().ToString() + " : RetriveByMISUtilityStoresDetails() : " + " : " + DateTime.Now + " : " + ex.Message.ToString(), Category.General, Priority.Highest);
                throw ex;
            }
        }

        public void UpdateMISUtilityStores(DateTime StoresOn, string StoresDisposition, int Id, string Remarks)
        {
            try
            {
                this.init();

                SqlCommand cmd = new SqlCommand("Update StockTransferRequest SET StoresOn = '" + StoresOn.ToString("yyyy-MM-dd") + "', StoresDisposition = '" + StoresDisposition + "', StoresRemarks ='"+ Remarks + "' where Id = '" + Id + "'", conn);
                cmd.CommandType = CommandType.Text;

                cmd.ExecuteNonQuery();

                conn.Close();
            }
            catch (Exception ex)
            {
                conn.Close();
                Logger.Write(this.GetType().ToString() + " : UpdateMISUtilityStores() : " + " : " + DateTime.Now + " : " + ex.Message.ToString(), Category.General, Priority.Highest);
                throw ex;
            }
        }

        public DataSet RetrieveByUtilityPendingReportDetails()
        {
            DataSet ds = new DataSet();
            try
            {
                this.init();

                SqlCommand cmd = new SqlCommand("[spGetStockTransferPendingReport]", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = cmd;

                da.Fill(ds);

                conn.Close();
                return ds;
            }
            catch (Exception ex)
            {
                conn.Close();
                Logger.Write(this.GetType().ToString() + " : RetrieveByUtilityPendingReportDetails() : " + " : " + DateTime.Now + " : " + ex.Message.ToString(), Category.General, Priority.Highest);
                throw ex;
            }
        }

        public DataSet RetrieveByUtilityCompletedReportDetails()
        {
            DataSet ds = new DataSet();
            try
            {
                this.init();

                SqlCommand cmd = new SqlCommand("[spGetStockTransferCompletedReport]", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = cmd;

                da.Fill(ds);

                conn.Close();
                return ds;
            }
            catch (Exception ex)
            {
                conn.Close();
                Logger.Write(this.GetType().ToString() + " : RetrieveByUtilityCompletedReportDetails() : " + " : " + DateTime.Now + " : " + ex.Message.ToString(), Category.General, Priority.Highest);
                throw ex;
            }
        }

        public void UpdateWIPAgingProcess()
        {
            DataSet ds = new DataSet();
            try
            {
                this.init();

                SqlCommand cmd = new SqlCommand("[WIPAgingProcess]", conn);
                cmd.CommandTimeout = 1000;
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.ExecuteNonQuery();

                conn.Close();
            }
            catch (Exception ex)
            {
                conn.Close();
                Logger.Write(this.GetType().ToString() + " : UpdateWIPAgingProcess() : " + " : " + DateTime.Now + " : " + ex.Message.ToString(), Category.General, Priority.Highest);
                throw ex;
            }
        }

        public DataSet RetriveByWIPAging()
        {
            DataSet ds = new DataSet();

            try
            {
                this.init();

                SqlCommand cmd = new SqlCommand("SELECT * FROM WIPAging Order by POSeries", conn);
                cmd.CommandTimeout = 1000;
                cmd.CommandType = CommandType.Text;

                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = cmd;

                da.Fill(ds);

                conn.Close();
                return ds;

            }
            catch (Exception ex)
            {
                //LogError(ex, "Exception from export button click!");
                conn.Close();
                Logger.Write(this.GetType().ToString() + " : RetriveByWIPAging() : " + " : " + DateTime.Now + " : " + ex.Message.ToString(), Category.General, Priority.Highest);
                throw ex;
            }
        }

        public DataSet RetriveByWIPAgingDetails(int FromDate, int ToDate)
        {
            DataSet ds = new DataSet();

            try
            {
                this.init();

                SqlCommand cmd = new SqlCommand("[spGetWIPAgingReportDetails]", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@From", FromDate));
                cmd.Parameters.Add(new SqlParameter("@To", ToDate));

                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = cmd;

                da.Fill(ds);

                conn.Close();
                return ds;

            }
            catch (Exception ex)
            {
                //LogError(ex, "Exception from export button click!");
                conn.Close();
                Logger.Write(this.GetType().ToString() + " : RetriveByWIPAgingDetails() : " + " : " + DateTime.Now + " : " + ex.Message.ToString(), Category.General, Priority.Highest);
                throw ex;
            }
        }

        public void InsertHeatNoControl(bool IsHeatNoControlFor)
        {
            try
            {
                this.init();

                SqlCommand cmd = new SqlCommand("[spInsertHeatNoControl]", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add(new SqlParameter("@IsHeadNoControlFor", IsHeatNoControlFor)); // bool
                cmd.ExecuteNonQuery();

                conn.Close();
            }
            catch (Exception ex)
            {
                conn.Close();
                Logger.Write(this.GetType().ToString() + " : InsertHeatNoControl() : " + " : " + DateTime.Now + " : " + ex.Message.ToString(), Category.General, Priority.Highest);
                throw ex;
            }
        }

        public void UpdateHeatNoControl(bool IsHeatNoControlFor)
        {
            try
            {
                this.init();

                SqlCommand cmd = new SqlCommand("[spUpdateHeatNoControl]", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add(new SqlParameter("@IsHeadNoControlFor", IsHeatNoControlFor)); // bool
                cmd.ExecuteNonQuery();

                conn.Close();
            }
            catch (Exception ex)
            {
                conn.Close();
                Logger.Write(this.GetType().ToString() + " : InsertHeatNoControl() : " + " : " + DateTime.Now + " : " + ex.Message.ToString(), Category.General, Priority.Highest);
                throw ex;
            }
        }

        public DataSet FetchHeatNoControl()
        {
            DataSet ds = new DataSet();

            try
            {
                this.init();

                SqlCommand cmd = new SqlCommand("Select * from General", conn);
                cmd.CommandTimeout = 1000;
                cmd.CommandType = CommandType.Text;

                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = cmd;

                da.Fill(ds);

                conn.Close();
                return ds;
            }
            catch (Exception ex)
            {
                conn.Close();
                Logger.Write(this.GetType().ToString() + " : FetchHeatNoControl() : " + " : " + DateTime.Now + " : " + ex.Message.ToString(), Category.General, Priority.Highest);
                throw ex;
            }
        }

        #endregion

        #region Sales
        public DataSet RetriveByCustomerNameForBranchReport()
        {
            DataSet ds = new DataSet();
            try
            {
                this.init();

                SqlCommand cmd = new SqlCommand("[spGetCustomerNameForBranchReport]", conn);
                cmd.CommandTimeout = 1000;
                cmd.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = cmd;

                da.Fill(ds);

                conn.Close();
                return ds;

            }
            catch (Exception ex)
            {
                conn.Close();
                Logger.Write(this.GetType().ToString() + " : RetriveByCustomerNameForBranchReport() : " + " : " + DateTime.Now + " : " + ex.Message.ToString(), Category.General, Priority.Highest);
                throw ex;
            }
        }

        public DataSet RetriveByOrderNoForBranchReport(string customerName)
        {
            DataSet ds = new DataSet();
            try
            {
                this.init();

                SqlCommand cmd = new SqlCommand("[spGetOrderNoForBranchReport]", conn);
                cmd.CommandTimeout = 1000;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@CustomerName", customerName));

                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = cmd;

                da.Fill(ds);

                conn.Close();
                return ds;

            }
            catch (Exception ex)
            {
                conn.Close();
                Logger.Write(this.GetType().ToString() + " : RetriveByOrderNoForBranchReport() : " + " : " + DateTime.Now + " : " + ex.Message.ToString(), Category.General, Priority.Highest);
                throw ex;
            }
        }

        public DataSet RetriveByBranchReportTypes()
        {
            DataSet ds = new DataSet();
            try
            {
                this.init();

                SqlCommand cmd = new SqlCommand("[spGetBranchReportTypes]", conn);
                cmd.CommandTimeout = 1000;
                cmd.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = cmd;

                da.Fill(ds);

                conn.Close();
                return ds;

            }
            catch (Exception ex)
            {
                conn.Close();
                Logger.Write(this.GetType().ToString() + " : RetriveByBranchReportTypes() : " + " : " + DateTime.Now + " : " + ex.Message.ToString(), Category.General, Priority.Highest);
                throw ex;
            }
        }

        public DataSet RetriveByDetailedReport(int OrderNo)
        {
            DataSet ds = new DataSet();
            try
            {
                this.init();

                SqlCommand cmd = new SqlCommand("[spGetDetailedReportForOrderNo]", conn);
                cmd.CommandTimeout = 1000;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@OrderNo", OrderNo));

                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = cmd;

                da.Fill(ds);

                conn.Close();
                return ds;

            }
            catch (Exception ex)
            {
                conn.Close();
                Logger.Write(this.GetType().ToString() + " : RetriveByDetailedReport() : " + " : " + DateTime.Now + " : " + ex.Message.ToString(), Category.General, Priority.Highest);
                throw ex;
            }
        }

        public DataSet RetriveBySummaryReport(string CustomerName)
        {
            DataSet ds = new DataSet();
            try
            {
                this.init();

                SqlCommand cmd = new SqlCommand("[spGetSummaryReportFromCustomerName]", conn);
                cmd.CommandTimeout = 1000;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@CustomerName", CustomerName));

                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = cmd;

                da.Fill(ds);

                conn.Close();
                return ds;

            }
            catch (Exception ex)
            {
                conn.Close();
                Logger.Write(this.GetType().ToString() + " : RetriveBySummaryReport() : " + " : " + DateTime.Now + " : " + ex.Message.ToString(), Category.General, Priority.Highest);
                throw ex;
            }
        }

        #endregion

        #region Quality

        public void UpdateProductionReleaseNewQcRemarks()
        {
            try
            {
                this.init();

                SqlCommand cmd = new SqlCommand("[spUpdateProductionReleaseNewQCRemarks]", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.ExecuteNonQuery();

                conn.Close();
            }
            catch (Exception ex)
            {
                conn.Close();
                Logger.Write(this.GetType().ToString() + " : UpdateProductionReleaseNewQcRemarks() : " + " : " + DateTime.Now + " : " + ex.Message.ToString(), Category.General, Priority.Highest);
                throw ex;
            }
        }

        #region Patrol Master's Screen

        public void InsertFromOperatorMaster(String OperatorCode, String OperatorName)
        {
            try
            {
                this.init();

                string UserName = (String)HttpContext.Current.Session["LoggedOnUser"];

                SqlCommand cmd = new SqlCommand("[spInsertOperatorMaster]", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add(new SqlParameter("@OperatorCode", OperatorCode));
                cmd.Parameters.Add(new SqlParameter("@OperatorName", OperatorName));

                cmd.ExecuteNonQuery();

                conn.Close();
            }
            catch (Exception ex)
            {
                conn.Close();
                Logger.Write(this.GetType().ToString() + " : InsertFromOperatorMaster() : " + " : " + DateTime.Now + " : " + ex.Message.ToString(), Category.General, Priority.Highest);
                throw ex;
            }
        }

        public void UpdateFormOperatorMaster(String OperatorCode, String OperatorName)
        {
            try
            {
                this.init();

                string UserName = (String)HttpContext.Current.Session["LoggedOnUser"];

                SqlCommand cmd = new SqlCommand("[spUpdateOperatorMaster]", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add(new SqlParameter("@OperatorCode", OperatorCode));
                cmd.Parameters.Add(new SqlParameter("@OperatorName", OperatorName));
              
                cmd.ExecuteNonQuery();

                conn.Close();
            }
            catch (Exception ex)
            {
                conn.Close();
                Logger.Write(this.GetType().ToString() + " : UpdateFormOperatorMaster() : " + " : " + DateTime.Now + " : " + ex.Message.ToString(), Category.General, Priority.Highest);
                throw ex;
            }
        }

        public void DeleteFromOperatorMaster(String OperatorCode)
        {
            try
            {
                this.init();

                string UserName = (String)HttpContext.Current.Session["LoggedOnUser"];

                SqlCommand cmd = new SqlCommand("[spDeleteOperatorMaster]", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add(new SqlParameter("@OperatorCode", OperatorCode));
                cmd.ExecuteNonQuery();

                conn.Close();
            }
            catch (Exception ex)
            {
                conn.Close();
                Logger.Write(this.GetType().ToString() + " : DeleteIntoEmployeeMaster() : " + " : " + DateTime.Now + " : " + ex.Message.ToString(), Category.General, Priority.Highest);
                throw ex;
            }
        }

        public DataSet RetriveByOperatorMasterDetails()
        {
            DataSet ds = new DataSet();
            try
            {
                this.init();

                SqlCommand cmd = new SqlCommand("[spGetOperatorMaster]", conn);
                cmd.CommandTimeout = 1000;
                cmd.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = cmd;

                da.Fill(ds);

                conn.Close();
                return ds;

            }
            catch (Exception ex)
            {
                conn.Close();
                Logger.Write(this.GetType().ToString() + " : RetriveByOperatorMasterDetails() : " + " : " + DateTime.Now + " : " + ex.Message.ToString(), Category.General, Priority.Highest);
                throw ex;
            }
        }

        public bool IsOperatorCodeExist(string operatorCode)
        {
            bool isUserExist = false;
            DataSet ds = new DataSet();

            try
            {
                this.init();

                SqlCommand cmd = new SqlCommand(" select * from OperatorMaster where OperatorCode ='" + operatorCode.Trim() + "'", conn);
                cmd.CommandTimeout = 1000;
                cmd.CommandType = CommandType.Text;

                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = cmd;

                da.Fill(ds);
                conn.Close();

                if (ds.Tables[0].Rows.Count > 0)
                {
                    isUserExist = true;
                }

                return isUserExist;
            }
            catch (Exception ex)
            {
                conn.Close();
                Logger.Write(this.GetType().ToString() + " : GetLoginIsExist() : " + " : " + DateTime.Now + " : " + ex.Message.ToString(), Category.General, Priority.Highest);
                throw ex;
            }
        }

        public void InsertFromIPLocationMaster(String LocationCode, String LocationName)
        {
            try
            {
                this.init();

                string UserName = (String)HttpContext.Current.Session["LoggedOnUser"];

                SqlCommand cmd = new SqlCommand("[spInsertIPLocationMaster]", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add(new SqlParameter("@IPLocationCode", LocationCode));
                cmd.Parameters.Add(new SqlParameter("@IPLocationName", LocationName));

                cmd.ExecuteNonQuery();

                conn.Close();
            }
            catch (Exception ex)
            {
                conn.Close();
                Logger.Write(this.GetType().ToString() + " : InsertFromOperatorMaster() : " + " : " + DateTime.Now + " : " + ex.Message.ToString(), Category.General, Priority.Highest);
                throw ex;
            }
        }

        public void UpdateFormIPLocationMaster(String LocationCode, String LocationName)
        {
            try
            {
                this.init();

                string UserName = (String)HttpContext.Current.Session["LoggedOnUser"];

                SqlCommand cmd = new SqlCommand("[spUpdateIPLocationMaster]", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add(new SqlParameter("@IPLocationCode", LocationCode));
                cmd.Parameters.Add(new SqlParameter("@IPLocationName", LocationName));

                cmd.ExecuteNonQuery();

                conn.Close();
            }
            catch (Exception ex)
            {
                conn.Close();
                Logger.Write(this.GetType().ToString() + " : UpdateFormIPLocationMaster() : " + " : " + DateTime.Now + " : " + ex.Message.ToString(), Category.General, Priority.Highest);
                throw ex;
            }
        }

        public void DeleteFromIPLocationMaster(String LocationCode, String LocationName)
        {
            try
            {
                this.init();

                string UserName = (String)HttpContext.Current.Session["LoggedOnUser"];

                SqlCommand cmd = new SqlCommand("[spDeleteIPLocationMaster]", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add(new SqlParameter("@IPLocationCode", LocationCode));
                cmd.Parameters.Add(new SqlParameter("@IPLocationName", LocationName));

                cmd.ExecuteNonQuery();

                conn.Close();
            }
            catch (Exception ex)
            {
                conn.Close();
                Logger.Write(this.GetType().ToString() + " : DeleteIntoEmployeeMaster() : " + " : " + DateTime.Now + " : " + ex.Message.ToString(), Category.General, Priority.Highest);
                throw ex;
            }
        }

        public DataSet RetriveByIPLocationMasterDetails()
        {
            DataSet ds = new DataSet();
            try
            {
                this.init();

                SqlCommand cmd = new SqlCommand("[spGetIPLocationMaster]", conn);
                cmd.CommandTimeout = 1000;
                cmd.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = cmd;

                da.Fill(ds);

                conn.Close();
                return ds;

            }
            catch (Exception ex)
            {
                conn.Close();
                Logger.Write(this.GetType().ToString() + " : RetriveByIPLocationMasterDetails() : " + " : " + DateTime.Now + " : " + ex.Message.ToString(), Category.General, Priority.Highest);
                throw ex;
            }
        }

        public bool IsLocationCodeExist(string LocationCode)
        {
            bool isUserExist = false;
            DataSet ds = new DataSet();

            try
            {
                this.init();

                SqlCommand cmd = new SqlCommand("select * from IPLocationMaster where LocationCode ='" + LocationCode.Trim() + "'", conn);
                cmd.CommandTimeout = 1000;
                cmd.CommandType = CommandType.Text;

                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = cmd;

                da.Fill(ds);
                conn.Close();

                if (ds.Tables[0].Rows.Count > 0)
                {
                    isUserExist = true;
                }

                return isUserExist;
            }
            catch (Exception ex)
            {
                conn.Close();
                Logger.Write(this.GetType().ToString() + " : GetLoginIsExist() : " + " : " + DateTime.Now + " : " + ex.Message.ToString(), Category.General, Priority.Highest);
                throw ex;
            }
        }

        public void InsertFromIPSubLocationMaster(String LocationCode, String SubLocationCode, String SubLocationName)
        {
            try
            {
                this.init();

                string UserName = (String)HttpContext.Current.Session["LoggedOnUser"];

                SqlCommand cmd = new SqlCommand("[spInsertIPSubLocationMaster]", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add(new SqlParameter("@IPLocationCode", LocationCode));
                cmd.Parameters.Add(new SqlParameter("@IPSubLocationCode", SubLocationCode));
                cmd.Parameters.Add(new SqlParameter("@IPSubLocationName", SubLocationName));

                cmd.ExecuteNonQuery();

                conn.Close();
            }
            catch (Exception ex)
            {
                conn.Close();
                Logger.Write(this.GetType().ToString() + " : InsertFromIPSubLocationMaster() : " + " : " + DateTime.Now + " : " + ex.Message.ToString(), Category.General, Priority.Highest);
                throw ex;
            }
        }

        public void UpdateFormIPSubLocationMaster(String LocationCode, String SubLocationCode, String SubLocationName)
        {
            try
            {
                this.init();

                string UserName = (String)HttpContext.Current.Session["LoggedOnUser"];

                SqlCommand cmd = new SqlCommand("[spUpdateIPSubLocationMaster]", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add(new SqlParameter("@IPLocationCode", LocationCode));
                cmd.Parameters.Add(new SqlParameter("@IPSubLocationCode", SubLocationCode));
                cmd.Parameters.Add(new SqlParameter("@IPSubLocationName", SubLocationName));

                cmd.ExecuteNonQuery();

                conn.Close();
            }
            catch (Exception ex)
            {
                conn.Close();
                Logger.Write(this.GetType().ToString() + " : UpdateFormIPSubLocationMaster() : " + " : " + DateTime.Now + " : " + ex.Message.ToString(), Category.General, Priority.Highest);
                throw ex;
            }
        }

        public void DeleteFromIPSubLocationMaster(String SubLocationCode, String SubLocationName)
        {
            try
            {
                this.init();

                string UserName = (String)HttpContext.Current.Session["LoggedOnUser"];

                SqlCommand cmd = new SqlCommand("[spDeleteIPSubLocationMaster]", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add(new SqlParameter("@IPSubLocationCode", SubLocationCode));
                cmd.Parameters.Add(new SqlParameter("@IPSubLocationName", SubLocationName));

                cmd.ExecuteNonQuery();

                conn.Close();
            }
            catch (Exception ex)
            {
                conn.Close();
                Logger.Write(this.GetType().ToString() + " : DeleteFromIPSubLocationMaster() : " + " : " + DateTime.Now + " : " + ex.Message.ToString(), Category.General, Priority.Highest);
                throw ex;
            }
        }

        public DataSet RetriveByIPSubLocationMasterDetails()
        {
            DataSet ds = new DataSet();
            try
            {
                this.init();

                SqlCommand cmd = new SqlCommand("[spGetIPSubLocationMaster]", conn);
                cmd.CommandTimeout = 1000;
                cmd.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = cmd;

                da.Fill(ds);

                conn.Close();
                return ds;

            }
            catch (Exception ex)
            {
                conn.Close();
                Logger.Write(this.GetType().ToString() + " : RetriveByIPSubLocationMasterDetails() : " + " : " + DateTime.Now + " : " + ex.Message.ToString(), Category.General, Priority.Highest);
                throw ex;
            }
        }

        public bool IsSubLocationCodeExist(string SubLocationCode)
        {
            bool isUserExist = false;
            DataSet ds = new DataSet();

            try
            {
                this.init();

                SqlCommand cmd = new SqlCommand("select * from IPSubLocationMaster where SubLocationCode ='" + SubLocationCode.Trim() + "'", conn);
                cmd.CommandTimeout = 1000;
                cmd.CommandType = CommandType.Text;

                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = cmd;

                da.Fill(ds);
                conn.Close();

                if (ds.Tables[0].Rows.Count > 0)
                {
                    isUserExist = true;
                }

                return isUserExist;
            }
            catch (Exception ex)
            {
                conn.Close();
                Logger.Write(this.GetType().ToString() + " : GetLoginIsExist() : " + " : " + DateTime.Now + " : " + ex.Message.ToString(), Category.General, Priority.Highest);
                throw ex;
            }
        }

        public DataSet RetriveByLocationCode()
        {
            DataSet ds = new DataSet();

            try
            {
                this.init();

                SqlCommand cmd = new SqlCommand("SELECT distinct LocationCode from IPLocationMaster", conn);
                cmd.CommandTimeout = 1000;
                cmd.CommandType = CommandType.Text;

                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = cmd;

                da.Fill(ds);
                conn.Close();

                return ds;
            }
            catch (Exception ex)
            {
                conn.Close();
                Logger.Write(this.GetType().ToString() + " : FillDropDownLocationCode() : " + " : " + DateTime.Now + " : " + ex.Message.ToString(), Category.General, Priority.Highest);
                throw ex;
            }
        }

        public void InsertFromCheckListMaster(int Serial, String Description)
        {
            try
            {
                this.init();

                string UserName = (String)HttpContext.Current.Session["LoggedOnUser"];

                SqlCommand cmd = new SqlCommand("[spInsertCheckListMaster]", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add(new SqlParameter("@CheckListSerial", Serial));
                cmd.Parameters.Add(new SqlParameter("@CheckListDescription", Description));

                cmd.ExecuteNonQuery();

                conn.Close();
            }
            catch (Exception ex)
            {
                conn.Close();
                Logger.Write(this.GetType().ToString() + " : InsertFromCheckListMaster() : " + " : " + DateTime.Now + " : " + ex.Message.ToString(), Category.General, Priority.Highest);
                throw ex;
            }
        }

        public void UpdateFormCheckListMaster(int Serial, String Description)
        {
            try
            {
                this.init();

                string UserName = (String)HttpContext.Current.Session["LoggedOnUser"];

                SqlCommand cmd = new SqlCommand("[spUpdateCheckListMaster]", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add(new SqlParameter("@CheckListSerial", Serial));
                cmd.Parameters.Add(new SqlParameter("@CheckListDescription", Description));

                cmd.ExecuteNonQuery();

                conn.Close();
            }
            catch (Exception ex)
            {
                conn.Close();
                Logger.Write(this.GetType().ToString() + " : UpdateFormCheckListMaster() : " + " : " + DateTime.Now + " : " + ex.Message.ToString(), Category.General, Priority.Highest);
                throw ex;
            }
        }

        public void DeleteFromCheckListMaster(int Serial, String Description)
        {
            try
            {
                this.init();

                string UserName = (String)HttpContext.Current.Session["LoggedOnUser"];

                SqlCommand cmd = new SqlCommand("[spDeleteCheckListMaster]", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add(new SqlParameter("@CheckListSerial", Serial));
                cmd.Parameters.Add(new SqlParameter("@CheckListDescription", Description));

                cmd.ExecuteNonQuery();

                conn.Close();
            }
            catch (Exception ex)
            {
                conn.Close();
                Logger.Write(this.GetType().ToString() + " : DeleteFromCheckListMaster() : " + " : " + DateTime.Now + " : " + ex.Message.ToString(), Category.General, Priority.Highest);
                throw ex;
            }
        }

        public DataSet RetriveByCheckListMasterDetails()
        {
            DataSet ds = new DataSet();
            try
            {
                this.init();

                SqlCommand cmd = new SqlCommand("[spGetCheckListMaster]", conn);
                cmd.CommandTimeout = 1000;
                cmd.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = cmd;

                da.Fill(ds);

                conn.Close();
                return ds;

            }
            catch (Exception ex)
            {
                conn.Close();
                Logger.Write(this.GetType().ToString() + " : RetriveByCheckListMasterDetails() : " + " : " + DateTime.Now + " : " + ex.Message.ToString(), Category.General, Priority.Highest);
                throw ex;
            }
        }

        public bool IsCheckListSerialExist(int Serial)
        {
            bool isUserExist = false;
            DataSet ds = new DataSet();

            try
            {
                this.init();

                SqlCommand cmd = new SqlCommand("Select * from CheckListMaster where CheckListSerial =" + Serial + "", conn);
                cmd.CommandTimeout = 1000;
                cmd.CommandType = CommandType.Text;

                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = cmd;

                da.Fill(ds);
                conn.Close();

                if (ds.Tables[0].Rows.Count > 0)
                {
                    isUserExist = true;
                }

                return isUserExist;
            }
            catch (Exception ex)
            {
                conn.Close();
                Logger.Write(this.GetType().ToString() + " : IsCheckListSerialExist() : " + " : " + DateTime.Now + " : " + ex.Message.ToString(), Category.General, Priority.Highest);
                throw ex;
            }
        }

        #endregion


        #endregion


    }

    public class CustomComparer : IComparer
    {
        Comparer _comparer = new Comparer(System.Globalization.CultureInfo.CurrentCulture);

        public int Compare(object x, object y)
        {
            // Convert string comparisons to int
            return _comparer.Compare(Convert.ToInt32(x), Convert.ToInt32(y));
        }
    }
}