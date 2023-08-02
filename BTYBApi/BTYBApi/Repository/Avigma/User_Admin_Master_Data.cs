using BTYBApi.Repository.Lib;
using BTYBApi.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using BTYBApi.Repository.Lib.Security;
using System.Data.SqlClient;
using BTYBApi.Models.Avigma;
using BTYBApi.IRepository.Avigma;

namespace BTYBApi.Repository.Avigma
{
    public class User_Admin_Master_Data : IUser_Admin_Master_Data
    {
        Log log = new Log();
        SecurityHelper securityHelper = new SecurityHelper();
        private readonly IConfiguration _configuration;
        public string ConnectionString { get; }


        public User_Admin_Master_Data(IConfiguration configuration)
        {
            _configuration = configuration;
            ConnectionString = _configuration.GetConnectionString("Conn_dBcon");
        }

        public IDbConnection Connection
        {
            get { return new SqlConnection(ConnectionString); }
        }


        private List<dynamic> CreateUpdate_User_Admin_Master(User_Admin_Master_DTO model)
        {
            string msg = string.Empty;

            List<dynamic> objData = new List<dynamic>();

            //string insertProcedure = "[CreateUpdate_User_Admin_Master]";

            //Dictionary<string, string> input_parameters = new Dictionary<string, string>();
            using (IDbConnection con = Connection)
            {
                if (Connection.State == ConnectionState.Closed) con.Open();

                try
                {
                    SqlCommand cmd = new SqlCommand("CreateUpdate_User_Admin_Master", (SqlConnection)con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Ad_User_PkeyID", model.Ad_User_PkeyID);
                    cmd.Parameters.AddWithValue("@Ad_User_First_Name", model.Ad_User_First_Name);
                    cmd.Parameters.AddWithValue("@Ad_User_Last_Name", model.Ad_User_Last_Name);
                    cmd.Parameters.AddWithValue("@Ad_User_Address", model.Ad_User_Address);
                    cmd.Parameters.AddWithValue("@Ad_User_City", model.Ad_User_City);
                    cmd.Parameters.AddWithValue("@Ad_User_State", model.Ad_User_State);
                    cmd.Parameters.AddWithValue("@Ad_User_Mobile", model.Ad_User_Mobile);
                    cmd.Parameters.AddWithValue("@Ad_User_Login_Name", model.Ad_User_Login_Name);
                    cmd.Parameters.AddWithValue("@Ad_User_Password", model.Ad_User_Password);
                    cmd.Parameters.AddWithValue("@Ad_User_UserVal", model.Ad_User_UserVal);
                    cmd.Parameters.AddWithValue("@Ad_User_Email", model.Ad_User_Email);
                    cmd.Parameters.AddWithValue("@Ad_User_IsActive", model.Ad_User_IsActive);
                    cmd.Parameters.AddWithValue("@Ad_User_IsDelete", model.Ad_User_IsDelete);
                    cmd.Parameters.AddWithValue("@Ad_User_Type", model.Ad_User_Type);
                    cmd.Parameters.AddWithValue("@Type", model.Type);
                    cmd.Parameters.AddWithValue("@UserID", model.UserID);
                    cmd.Parameters.AddWithValue("@Ad_User_Pkey_Out", 0).Direction = ParameterDirection.Output;
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

        private DataSet Get_User_Admin_Master(long? Ad_User_PkeyID, long? UserID, int? Type)
        {
            DataSet ds = new DataSet();

            //DataSet ds = new DataSet();
            try
            {
                //string selectProcedure = "[Get_User_Admin_Master]";
                //Dictionary<string, string> input_parameters = new Dictionary<string, string>();
                SqlCommand cmd = new SqlCommand("Get_User_Admin_Master", (SqlConnection)Connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Ad_User_PkeyID", Ad_User_PkeyID);
                cmd.Parameters.AddWithValue("@UserID", UserID);
                cmd.Parameters.AddWithValue("@Type", Type);

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

        public List<dynamic> CreateUpdate_User_Admin_Master_DataDetails(User_Admin_Master_DTO model)
        {
            List<dynamic> objData = new List<dynamic>();
            try
            {
                objData = CreateUpdate_User_Admin_Master(model);
            }
            catch (Exception ex)
            {
                log.logErrorMessage(ex.Message);
                log.logErrorMessage(ex.StackTrace);
            }
            return objData;
        }

        public List<dynamic> Get_User_Admin_MasterDetails(long? Ad_User_PkeyID, long? UserID, int? Type)
        {
            List<dynamic> objDynamic = new List<dynamic>();
            try
            {

                DataSet ds = Get_User_Admin_Master(Ad_User_PkeyID, UserID, Type);

                var myEnumerableFeaprd = ds.Tables[0].AsEnumerable();
                List<User_Admin_Master_DTO> Get_details =
                   (from item in myEnumerableFeaprd
                    select new User_Admin_Master_DTO
                    {
                        Ad_User_PkeyID = item.Field<long>("Ad_User_PkeyID"),
                        Ad_User_First_Name = item.Field<string>("Ad_User_First_Name"),
                        Ad_User_Last_Name = item.Field<string>("Ad_User_Last_Name"),
                        Ad_User_Address = item.Field<string>("Ad_User_Address"),
                        Ad_User_City = item.Field<string>("Ad_User_City"),
                        Ad_User_State = item.Field<string>("Ad_User_State"),
                        Ad_User_Mobile = item.Field<string>("Ad_User_Mobile"),
                        Ad_User_Login_Name = item.Field<string>("Ad_User_Login_Name"),
                        Ad_User_Password = item.Field<string>("Ad_User_Password"),
                        Ad_User_UserVal = item.Field<string>("Ad_User_UserVal"),
                        Ad_User_Email = item.Field<string>("Ad_User_Email"),
                        Ad_User_Type = item.Field<int?>("Ad_User_Type"),
                        Ad_User_IsActive = item.Field<bool?>("Ad_User_IsActive"),

                    }).ToList();

                objDynamic.Add(Get_details);
            }
            catch (Exception ex)
            {
                log.logErrorMessage(ex.Message);
                log.logErrorMessage(ex.StackTrace);
            }

            return objDynamic;

        }

    }
}