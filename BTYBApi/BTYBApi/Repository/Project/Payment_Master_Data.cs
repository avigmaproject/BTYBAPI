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

namespace BTYBApi.Repository.Avigma
{
    public class Payment_Master_Data : IPayment_Master_Data
    {
        Log log = new Log();
        SecurityHelper securityHelper = new SecurityHelper();
        ObjectConvert obj = new ObjectConvert();
        private readonly IConfiguration _configuration;
        public string ConnectionString { get; }
        public Payment_Master_Data()
        {
        }
        public Payment_Master_Data(IConfiguration configuration)
        {
            _configuration = configuration;
            ConnectionString = _configuration.GetConnectionString("Conn_dBcon");
        }


        public IDbConnection Connection
        {
            get { return new SqlConnection(ConnectionString); }
        }


        public List<dynamic> AddUpdatePayment_Master_Data(Payment_Master_DTO model)
        {
            string msg = string.Empty;

            List<dynamic> objData = new List<dynamic>();

            using (IDbConnection con = Connection)
            {
                if (Connection.State == ConnectionState.Closed) con.Open();

                try
                {
                    SqlCommand cmd = new SqlCommand("CreateUpdate_Payment_Master", (SqlConnection)con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@PAYM_PKeyID", model.PAYM_PKeyID);
                    cmd.Parameters.AddWithValue("@PAYM_ORDM_PkeyID", model.PAYM_ORDM_PkeyID);
                    cmd.Parameters.AddWithValue("@PAYM_User_PkeyID", model.PAYM_User_PkeyID);
                    cmd.Parameters.AddWithValue("@PAYM_No_IP", model.PAYM_No_IP);
                    cmd.Parameters.AddWithValue("@PAYM_No_Stripe_ProductID", model.PAYM_No_Stripe_ProductID);
                    cmd.Parameters.AddWithValue("@PAYM_No_Stripe_PriceID", model.PAYM_No_Stripe_PriceID);
                    cmd.Parameters.AddWithValue("@PAYM_No_Stripe_UserID", model.PAYM_No_Stripe_UserID);
                    cmd.Parameters.AddWithValue("@PAYM_Net_Amount", model.PAYM_Net_Amount);
                    cmd.Parameters.AddWithValue("@PAYM_IsStatus", model.PAYM_IsStatus);

                    cmd.Parameters.AddWithValue("@PAYM_IsActive", model.PAYM_IsActive);
                    cmd.Parameters.AddWithValue("@PAYM_IsDelete", model.PAYM_IsDelete);
                    cmd.Parameters.AddWithValue("@Type", model.Type);
                    cmd.Parameters.AddWithValue("@UserID", model.UserID);
                    //cmd.Parameters.AddWithValue("@PAYM_Pkey_Out", 0).Direction = ParameterDirection.Output;
                    //cmd.Parameters.AddWithValue("@ReturnValue", 0).Direction = ParameterDirection.Output;

                    SqlParameter PAYM_Pkey_Out = cmd.Parameters.AddWithValue("@PAYM_Pkey_Out", 0);
                    PAYM_Pkey_Out.Direction = ParameterDirection.Output;
                    SqlParameter ReturnValue = cmd.Parameters.AddWithValue("@ReturnValue", 0);
                    ReturnValue.Direction = ParameterDirection.Output;


                    cmd.ExecuteNonQuery();
                    objData.Add(PAYM_Pkey_Out.Value);
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

        private DataSet Get_UserMaster(Payment_Master_DTO_Input model)
        {
            DataSet ds = new DataSet();
            try
            {
                SqlCommand cmd = new SqlCommand("Get_Payment_Master", (SqlConnection)Connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@PAYM_PkeyID", model.PAYM_PkeyID);
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


        public List<dynamic> Get_Payment_MasterDetailsDTO(Payment_Master_DTO_Input model)
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