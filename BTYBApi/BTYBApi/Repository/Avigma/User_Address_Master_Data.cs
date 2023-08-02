using BTYBApi.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using BTYBApi.Repository.Lib.Security;
using System.Data.SqlClient;
using BTYBApi.Repository.Lib;
using BTYBApi.Models.Avigma;

namespace BTYBApi.Repository.Avigma
{
    public class User_Address_Master_Data
    {
        Log log = new Log();
        SecurityHelper securityHelper = new SecurityHelper();
        private readonly IConfiguration _configuration;
        public string ConnectionString { get; }

        public User_Address_Master_Data(IConfiguration configuration)
        {
            _configuration = configuration;
            ConnectionString = _configuration.GetConnectionString("Conn_dBcon");
        }

        public IDbConnection Connection
        {
            get { return new SqlConnection(ConnectionString); }
        }

        private List<dynamic> CreateUpdate_User_Address_Master(User_Address_Master_DTO model)
        {

            //string insertProcedure = "[CreateUpdate_User_Address_Master]";

            //Dictionary<string, string> input_parameters = new Dictionary<string, string>();
            string msg = string.Empty;

            List<dynamic> objData = new List<dynamic>();

            using (IDbConnection con = Connection)
            {
                if (Connection.State == ConnectionState.Closed) con.Open();

                try
                {
                    SqlCommand cmd = new SqlCommand("CreateUpdate_User_Address_Master", (SqlConnection)con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@UAM_PkeyID", model.UAM_PkeyID);
                    cmd.Parameters.AddWithValue("@UAM_User_PkeyID", model.UAM_User_PkeyID);
                    cmd.Parameters.AddWithValue("@UAM_Company_Name", model.UAM_Company_Name);
                    cmd.Parameters.AddWithValue("@UAM_Shipping_Address1", model.UAM_Shipping_Address1);
                    cmd.Parameters.AddWithValue("@UAM_Shipping_Address2", model.UAM_Shipping_Address2);
                    cmd.Parameters.AddWithValue("@UAM_Shipping_Pincode", model.UAM_Shipping_Pincode);
                    cmd.Parameters.AddWithValue("@UAM_Shipping_City", model.UAM_Shipping_City);
                    cmd.Parameters.AddWithValue("@UAM_Shipping_State", model.UAM_Shipping_State);
                    cmd.Parameters.AddWithValue("@UAM_Shipping_Country", model.UAM_Shipping_Country);
                    cmd.Parameters.AddWithValue("@UAM_Lat", model.UAM_Lat);
                    cmd.Parameters.AddWithValue("@UAM_Long", model.UAM_Long);
                    cmd.Parameters.AddWithValue("@UAM_Billing_Address1", model.UAM_Billing_Address1);
                    cmd.Parameters.AddWithValue("@UAM_Billing_Address2", model.UAM_Billing_Address2);
                    cmd.Parameters.AddWithValue("@UAM_Billing_Pincode", model.UAM_Billing_Pincode);
                    cmd.Parameters.AddWithValue("@UAM_Billing_City", model.UAM_Billing_City);
                    cmd.Parameters.AddWithValue("@UAM_Billing_State", model.UAM_Billing_State);
                    cmd.Parameters.AddWithValue("@UAM_Billing_Country", model.UAM_Billing_Country);
                    cmd.Parameters.AddWithValue("@UAM_IsActive", 1 + "#bit#" + model.UAM_IsActive);
                    cmd.Parameters.AddWithValue("@UAM_IsDelete", 1 + "#bit#" + model.UAM_IsDelete);
                    cmd.Parameters.AddWithValue("@Type", model.Type);
                    cmd.Parameters.AddWithValue("@UserID", model.UserID);
                    cmd.Parameters.AddWithValue("@UAM_Pkey_Out", 0).Direction = ParameterDirection.Output;
                    cmd.Parameters.AddWithValue("@ReturnValue", 0).Direction = ParameterDirection.Output;

                    cmd.ExecuteNonQuery();
                    msg = "Add Success";

                }
                catch (Exception ex)
                {
                    log.logErrorMessage(ex.StackTrace);
                    log.logErrorMessage(ex.Message);
                }
                return objData;

            }

        }

        private DataSet Get_User_Address_Master(User_Address_Master_DTO model)
        {
            DataSet ds = new DataSet();
            try
            {
                //string selectProcedure = "[Get_User_Address_Master]";
                //Dictionary<string, string> input_parameters = new Dictionary<string, string>();

                SqlCommand cmd = new SqlCommand("Get_User_Address_Master", (SqlConnection)Connection);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@UAM_PkeyID", model.UAM_PkeyID);

                cmd.Parameters.AddWithValue("@Type", model.Type);

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

        public List<dynamic> CreateUpdate_User_Address_Master_DataDetails(User_Address_Master_DTO model)
        {
            List<dynamic> objData = new List<dynamic>();
            try
            {
                objData = CreateUpdate_User_Address_Master(model);
            }
            catch (Exception ex)
            {
                log.logErrorMessage(ex.Message);
                log.logErrorMessage(ex.StackTrace);
            }
            return objData;
        }

        public List<dynamic> Get_User_Address_MasterDetails(User_Address_Master_DTO model)
        {
            List<dynamic> objDynamic = new List<dynamic>();
            try
            {

                DataSet ds = Get_User_Address_Master(model);

                var myEnumerableFeaprd = ds.Tables[0].AsEnumerable();
                List<User_Address_Master_DTO> Get_details =
                   (from item in myEnumerableFeaprd
                    select new User_Address_Master_DTO
                    {
                        UAM_PkeyID = item.Field<long>("UAM_PkeyID"),
                        UAM_User_PkeyID = item.Field<long?>("UAM_User_PkeyID"),
                        UAM_Company_Name = item.Field<string>("UAM_Company_Name"),
                        UAM_Shipping_Address1 = item.Field<string>("UAM_Shipping_Address1"),
                        UAM_Shipping_Address2 = item.Field<string>("UAM_Shipping_Address2"),
                        UAM_Shipping_Pincode = item.Field<string>("UAM_Shipping_Pincode"),
                        UAM_Shipping_City = item.Field<string>("UAM_Shipping_City"),
                        UAM_Shipping_State = item.Field<string>("UAM_Shipping_State"),
                        UAM_Shipping_Country = item.Field<string>("UAM_Shipping_Country"),
                        UAM_Lat = item.Field<string>("UAM_Lat"),
                        UAM_Long = item.Field<string>("UAM_Long"),
                        UAM_Billing_Address1 = item.Field<string>("UAM_Billing_Address1"),
                        UAM_Billing_Address2 = item.Field<string>("UAM_Billing_Address2"),
                        UAM_Billing_Pincode = item.Field<string>("UAM_Billing_Pincode"),
                        UAM_Billing_City = item.Field<string>("UAM_Billing_City"),
                        UAM_Billing_State = item.Field<string>("UAM_Billing_State"),
                        UAM_Billing_Country = item.Field<string>("UAM_Billing_Country"),
                        UAM_IsActive = item.Field<bool?>("UAM_IsActive"),
                    }).ToList();

                objDynamic.Add(Get_details);
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