using BTYBApi.Repository.Lib;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using BTYBApi.Repository.Lib.Security;
using BTYBApi.IRepository.Avigma;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using System.Data.SqlClient;
using BTYBApi.Models.Avigma;
using BTYBApi.Data;
using System.Security.Claims;
using BTYBApi.Models.Project;
using BTYBApi.IRepository.Project;

namespace BTYBApi.Repository.Avigma
{
    public class User_Subscription_Data : IUser_Subscription_Data
    {
        Log log = new Log();
        SecurityHelper securityHelper = new SecurityHelper();
        ObjectConvert obj = new ObjectConvert();
        private readonly IConfiguration _configuration;
        public string ConnectionString { get; }
        public User_Subscription_Data()
        {
        }
        public User_Subscription_Data(IConfiguration configuration)
        {
            _configuration = configuration;
            ConnectionString = _configuration.GetConnectionString("Conn_dBcon");
        }


        public IDbConnection Connection
        {
            get { return new SqlConnection(ConnectionString); }
        }


        public List<dynamic> AddUpdateUser_Subscription_Data(User_Subscription_DTO model)
        {
            string msg = string.Empty;

            List<dynamic> objData = new List<dynamic>();

            using (IDbConnection con = Connection)
            {
                if (Connection.State == ConnectionState.Closed) con.Open();

                try
                {
                    SqlCommand cmd = new SqlCommand("CreateUpdate_User_Subscription", (SqlConnection)con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@SUB_PKeyID", model.SUB_PKeyID);
                    //cmd.Parameters.AddWithValue("@SUB_User_PkeyID", model.SUB_User_PkeyID);
                    cmd.Parameters.AddWithValue("@SUB_Name", model.SUB_Name);
                    cmd.Parameters.AddWithValue("@SUB_Description", model.SUB_Description);
                    cmd.Parameters.AddWithValue("@SUB_Status", model.SUB_Status);

                    cmd.Parameters.AddWithValue("@SUB_Period", model.SUB_Period);
                    cmd.Parameters.AddWithValue("@SUB_CurrentDate", model.SUB_CurrentDate);
                    cmd.Parameters.AddWithValue("@SUB_ExpiryDate", model.SUB_ExpiryDate);
                    cmd.Parameters.AddWithValue("@SUB_Offer", model.SUB_Offer);
                    cmd.Parameters.AddWithValue("@SUB_Amount", model.SUB_Amount);
                    cmd.Parameters.AddWithValue("@SUB_No_Stripe_ProductID", model.SUB_No_Stripe_ProductID);
                    cmd.Parameters.AddWithValue("@SUB_No_Stripe_PriceID", model.SUB_No_Stripe_PriceID);
                    cmd.Parameters.AddWithValue("@SUB_No_Stripe_UserID", model.SUB_No_Stripe_UserID);
                    cmd.Parameters.AddWithValue("@SUB_No_IP", model.SUB_No_IP);

                    cmd.Parameters.AddWithValue("@SUB_IsActive", model.SUB_IsActive);
                    cmd.Parameters.AddWithValue("@SUB_IsDelete", model.SUB_IsDelete);
                    cmd.Parameters.AddWithValue("@Type", model.Type);
                    cmd.Parameters.AddWithValue("@UserID", model.UserID);

                    //cmd.Parameters.AddWithValue("@SUB_Pkey_Out", 0).Direction = ParameterDirection.Output;
                    //cmd.Parameters.AddWithValue("@ReturnValue", 0).Direction = ParameterDirection.Output;

                    SqlParameter SUB_Pkey_Out = cmd.Parameters.AddWithValue("@SUB_Pkey_Out", 0);
                    SUB_Pkey_Out.Direction = ParameterDirection.Output;
                    SqlParameter ReturnValue = cmd.Parameters.AddWithValue("@ReturnValue", 0);
                    ReturnValue.Direction = ParameterDirection.Output;


                    cmd.ExecuteNonQuery();
                    objData.Add(SUB_Pkey_Out.Value);
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

        private DataSet Get_UserMaster(User_Subscription_DTO_Input model)
        {
            DataSet ds = new DataSet();
            try
            {
                SqlCommand cmd = new SqlCommand("Get_User_Subscription", (SqlConnection)Connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@SUB_PkeyID", model.SUB_PkeyID);
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


        public List<dynamic> Get_User_SubscriptionDetailsDTO(User_Subscription_DTO_Input model)
        {
            List<dynamic> objDynamic = new List<dynamic>(); try
            {


                DataSet ds = Get_UserMaster(model);

                if (ds.Tables.Count > 0)
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