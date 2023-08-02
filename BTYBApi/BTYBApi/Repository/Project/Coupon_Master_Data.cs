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
    public class Coupon_Master_Data : ICoupon_Master_Data
    {
        Log log = new Log();
        SecurityHelper securityHelper = new SecurityHelper();
        ObjectConvert obj = new ObjectConvert();
        private readonly IConfiguration _configuration;
        public string ConnectionString { get; }
        public Coupon_Master_Data()
        {
        }
        public Coupon_Master_Data(IConfiguration configuration)
        {
            _configuration = configuration;
            ConnectionString = _configuration.GetConnectionString("Conn_dBcon");
        }


        public IDbConnection Connection
        {
            get { return new SqlConnection(ConnectionString); }
        }


        public List<dynamic> AddUpdateCoupon_Master_Data(Coupon_Master_DTO model)
        {
            string msg = string.Empty;

            List<dynamic> objData = new List<dynamic>();

            using (IDbConnection con = Connection)
            {
                if (Connection.State == ConnectionState.Closed) con.Open();

                try
                {
                    SqlCommand cmd = new SqlCommand("CreateUpdate_Coupon_Master", (SqlConnection)con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@CM_PkeyID", model.CM_PkeyID);
                    cmd.Parameters.AddWithValue("@CM_Name", model.CM_Name);
                    cmd.Parameters.AddWithValue("@CM_Description", model.CM_Description);
                    cmd.Parameters.AddWithValue("@CM_Code", model.CM_Code);
                    cmd.Parameters.AddWithValue("@CM_Discount_Perc", model.CM_Discount_Perc);
                    cmd.Parameters.AddWithValue("@CM_Discount_Flat", model.CM_Discount_Flat);
                    cmd.Parameters.AddWithValue("@CM_Expiry_Date", model.CM_Expiry_Date);
                    cmd.Parameters.AddWithValue("@CM_Expiry_Days", model.CM_Expiry_Days);


                    cmd.Parameters.AddWithValue("@CM_IsActive", model.CM_IsActive);
                    cmd.Parameters.AddWithValue("@CM_IsDelete", model.CM_IsDelete);
                    cmd.Parameters.AddWithValue("@Type", model.Type);
                    cmd.Parameters.AddWithValue("@UserID", model.UserID);
                    //cmd.Parameters.AddWithValue("@CM_Pkey_Out", 0).Direction = ParameterDirection.Output;
                    //cmd.Parameters.AddWithValue("@ReturnValue", 0).Direction = ParameterDirection.Output;

                    SqlParameter CM_Pkey_Out = cmd.Parameters.AddWithValue("@CM_Pkey_Out", 0);
                    CM_Pkey_Out.Direction = ParameterDirection.Output;
                    SqlParameter ReturnValue = cmd.Parameters.AddWithValue("@ReturnValue", 0);
                    ReturnValue.Direction = ParameterDirection.Output;


                    cmd.ExecuteNonQuery();
                    objData.Add(CM_Pkey_Out.Value);
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

        private DataSet Get_UserMaster(Coupon_Master_DTO_Input model)
        {
            DataSet ds = new DataSet();
            try
            {
                SqlCommand cmd = new SqlCommand("Get_Coupon_Master", (SqlConnection)Connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@CM_PkeyID", model.CM_PkeyID);
                cmd.Parameters.AddWithValue("@Promo_Code", model.Promo_Code);
                cmd.Parameters.AddWithValue("@Type", model.Type);

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


        public List<dynamic> Get_Coupon_MasterDetailsDTO(Coupon_Master_DTO_Input model)
        {
            string msg = string.Empty;
            List<dynamic> objDynamic = new List<dynamic>();
            try
            {


                DataSet ds = Get_UserMaster(model);
                if (model.Type == 3 && ds.Tables[0].Rows.Count == 0)
                {
                    msg = "This Coupon has been Expire!, Please Use Valid Coupon Code.";
                    objDynamic.Add(msg);
                }
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