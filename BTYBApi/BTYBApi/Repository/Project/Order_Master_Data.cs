using BTYBApi.Repository.Lib;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using BTYBApi.Repository.Lib.Security;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using System.Data.SqlClient;
using BTYBApi.Data;
using System.Security.Claims;
using BTYBApi.Models.Project;
using BTYBApi.IRepository.Project;
using Newtonsoft.Json;

namespace BTYBApi.Repository.Avigma
{
    public class Order_Master_Data : IOrder_Master_Data
    {
        Log log = new Log();
        SecurityHelper securityHelper = new SecurityHelper();
        ObjectConvert obj = new ObjectConvert();
        private readonly IConfiguration _configuration;
        public string ConnectionString { get; }
        public Order_Master_Data()
        {
        }
        public Order_Master_Data(IConfiguration configuration)
        {
            _configuration = configuration;
            ConnectionString = _configuration.GetConnectionString("Conn_dBcon");
        }


        public IDbConnection Connection
        {
            get { return new SqlConnection(ConnectionString); }
        }


        public List<dynamic> AddUpdateOrder_Master_Data(Order_Master_DTO model)
        {
            string msg = string.Empty;

            List<dynamic> objData = new List<dynamic>();
            Payment_Master_DTO payment_Master_DTO = new Payment_Master_DTO();
            Payment_Master_Data payment_Master_Data = new Payment_Master_Data(_configuration);
            Order_Master_Child_DTO order_Master_Child_DTO = new Order_Master_Child_DTO();
            Order_Master_Child_Data order_Master_Child_Data = new Order_Master_Child_Data(_configuration);

            using (IDbConnection con = Connection)
            {
                if (Connection.State == ConnectionState.Closed) con.Open();

                try
                {
                    SqlCommand cmd = new SqlCommand("CreateUpdate_Order_Master", (SqlConnection)con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ORDM_PKeyID", model.ORDM_PKeyID);
                    cmd.Parameters.AddWithValue("@ORDM_UP_PkeyID", model.ORDM_UP_PkeyID);
                    cmd.Parameters.AddWithValue("@ORDM_OrderID", model.ORDM_OrderID);
                    cmd.Parameters.AddWithValue("@ORDM_Discount_Pers", model.ORDM_Discount_Pers);
                    cmd.Parameters.AddWithValue("@ORDM_Discount_Total", model.ORDM_Discount_Total);
                    cmd.Parameters.AddWithValue("@ORDM_Tot_Amount", model.ORDM_Tot_Amount);
                    //cmd.Parameters.AddWithValue("@ORDM_Pro_Data", model.ORDM_Pro_Data);
                    cmd.Parameters.AddWithValue("@ORDM_IsStatus", model.ORDM_IsStatus);


                    cmd.Parameters.AddWithValue("@ORDM_IsActive", model.ORDM_IsActive);
                    cmd.Parameters.AddWithValue("@ORDM_IsDelete", model.ORDM_IsDelete);
                    cmd.Parameters.AddWithValue("@Type", model.Type);
                    cmd.Parameters.AddWithValue("@UserID", model.UserID);
                    //cmd.Parameters.AddWithValue("@ORDM_Pkey_Out", 0).Direction = ParameterDirection.Output;
                    //cmd.Parameters.AddWithValue("@ReturnValue", 0).Direction = ParameterDirection.Output;

                    SqlParameter ORDM_Pkey_Out = cmd.Parameters.AddWithValue("@ORDM_Pkey_Out", 0);
                    ORDM_Pkey_Out.Direction = ParameterDirection.Output;
                    SqlParameter ReturnValue = cmd.Parameters.AddWithValue("@ReturnValue", 0);
                    ReturnValue.Direction = ParameterDirection.Output;


                    cmd.ExecuteNonQuery();
                    //var data = JsonConvert.DeserializeObject<List<Order_Master_Child_DTO>>(model.OrderMasterChild_DTO);

                    //for (int i = 0; i < data.Count; i++)
                    //{
                    //    data[i].ORD_UP_User_PkeyID
                    //}

                    if (model.ORDM_Pro_Detail != null)
                    {
                        //OutPayment = convert_Json_Array.ConvertJsonArray(Data);
                        for (int i = 0; i < model.ORDM_Pro_Detail.Count; i++)
                        {
                            order_Master_Child_DTO.Type = 1;
                            order_Master_Child_DTO.UserID = model.UserID;
                            order_Master_Child_DTO.ORD_ORDM_PKeyID = Int64.Parse(ORDM_Pkey_Out.Value.ToString());

                            order_Master_Child_DTO.ORD_UP_PkeyID = model.ORDM_Pro_Detail[i].ORD_UP_PkeyID;
                            order_Master_Child_DTO.ORD_Pro_PkeyID = model.ORDM_Pro_Detail[i].ORD_Pro_PkeyID;
                            order_Master_Child_DTO.ORD_No_IP = model.ORDM_Pro_Detail[i].ORD_No_IP;
                            order_Master_Child_DTO.ORD_No_Stripe_ProductID = model.ORDM_Pro_Detail[i].ORD_No_Stripe_ProductID;
                            order_Master_Child_DTO.ORD_No_Stripe_PriceID = model.ORDM_Pro_Detail[i].ORD_No_Stripe_PriceID;
                            order_Master_Child_DTO.ORD_No_Stripe_UserID = model.ORDM_Pro_Detail[i].ORD_No_Stripe_UserID;
                            order_Master_Child_DTO.ORD_Net_Amount = model.ORDM_Pro_Detail[i].ORD_Net_Amount;
                            order_Master_Child_DTO.ORD_IsActive = model.ORDM_Pro_Detail[i].ORD_IsActive;
                            order_Master_Child_DTO.ORD_IsDelete = model.ORDM_Pro_Detail[i].ORD_IsDelete;

                            var OutputOrderChild = order_Master_Child_Data.AddUpdateOrder_Master_Child_Data(order_Master_Child_DTO);

                        }
                    }

                    if (model.ORDM_Payment_Detail != null)
                    {
                        //OutPayment = convert_Json_Array.ConvertJsonArray(Data);
                        for (int i = 0; i < model.ORDM_Payment_Detail.Count; i++)
                        {
                            payment_Master_DTO.Type = 1;
                            payment_Master_DTO.UserID = model.UserID;
                            payment_Master_DTO.PAYM_ORDM_PkeyID = Int64.Parse(ORDM_Pkey_Out.Value.ToString());

                            payment_Master_DTO.PAYM_User_PkeyID = model.ORDM_Payment_Detail[i].PAYM_User_PkeyID;
                            payment_Master_DTO.PAYM_No_IP = model.ORDM_Payment_Detail[i].PAYM_No_IP;
                            payment_Master_DTO.PAYM_No_Stripe_ProductID = model.ORDM_Payment_Detail[i].PAYM_No_Stripe_ProductID;
                            payment_Master_DTO.PAYM_No_Stripe_PriceID = model.ORDM_Payment_Detail[i].PAYM_No_Stripe_PriceID;
                            payment_Master_DTO.PAYM_No_Stripe_UserID = model.ORDM_Payment_Detail[i].PAYM_No_Stripe_UserID;
                            payment_Master_DTO.PAYM_Net_Amount = model.ORDM_Payment_Detail[i].PAYM_Net_Amount;
                            payment_Master_DTO.PAYM_IsStatus = model.ORDM_Payment_Detail[i].PAYM_IsStatus;
                            payment_Master_DTO.PAYM_IsActive = model.ORDM_Payment_Detail[i].PAYM_IsActive;
                            payment_Master_DTO.PAYM_IsDelete = model.ORDM_Payment_Detail[i].PAYM_IsDelete;

                            var OutputPayment = payment_Master_Data.AddUpdatePayment_Master_Data(payment_Master_DTO);

                        }
                    }

                    objData.Add(ORDM_Pkey_Out.Value);
                    objData.Add(ReturnValue.Value);

                }
                catch (Exception ex)
                {
                    log.logErrorMessage(ex.StackTrace);
                    log.logErrorMessage(ex.Message);
                }
                finally
                {
                    if (con.State == ConnectionState.Open)
                    {
                        con.Close();
                    }
                }
            }
            return objData;
        }

        private DataSet Get_UserMaster(Order_Master_DTO_Input model)
        {
            DataSet ds = new DataSet();
            try
            {
                SqlCommand cmd = new SqlCommand("Get_Order_Master", (SqlConnection)Connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ORDM_PkeyID", model.ORDM_PkeyID);
                cmd.Parameters.AddWithValue("@Type", model.Type);
                cmd.Parameters.AddWithValue("@UserID", model.UserID);

                cmd.Parameters.AddWithValue("@WhereClause", model.WhereClause);
                cmd.Parameters.AddWithValue("@PageNumber", model.PageNumber);
                cmd.Parameters.AddWithValue("@NoofRows", model.NoofRows);
                cmd.Parameters.AddWithValue("@Orderby", model.Orderby);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(ds);
            }
            catch (Exception ex)
            {
                log.logErrorMessage(ex.Message);
                log.logErrorMessage(ex.StackTrace);

            }
            return ds;

        }


        public List<dynamic> Get_Order_MasterDetailsDTO(Order_Master_DTO_Input model)
        {
            string msg = string.Empty;
            List<dynamic> objDynamic = new List<dynamic>();
            try
            {


                DataSet ds = Get_UserMaster(model);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    for (int i = 0; i < ds.Tables.Count; i++)
                    {
                        objDynamic.Add(obj.AsDynamicEnumerable(ds.Tables[i]));
                    }

                }

            }
            catch (Exception ex)
            {
                log.logErrorMessage(ex.StackTrace);
                log.logErrorMessage(ex.Message);
            }

            return objDynamic;
        }

    }
}