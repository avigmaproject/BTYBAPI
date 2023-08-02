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
    public class User_Like_Data : IUser_Like_Data
    {
        Log log = new Log();
        SecurityHelper securityHelper = new SecurityHelper();
        ObjectConvert obj = new ObjectConvert();
        private readonly IConfiguration _configuration;
        public string ConnectionString { get; }
        public User_Like_Data()
        {
        }
        public User_Like_Data(IConfiguration configuration)
        {
            _configuration = configuration;
            ConnectionString = _configuration.GetConnectionString("Conn_dBcon");
        }


        public IDbConnection Connection
        {
            get { return new SqlConnection(ConnectionString); }
        }

        private List<dynamic> CreateUpdateUserLike(User_Like_DTO model)
        {
            string msg = string.Empty;
            List<dynamic> objData = new List<dynamic>();

            using (IDbConnection con = Connection)
            {
                if (Connection.State == ConnectionState.Closed) con.Open();

                try
                {
                    SqlCommand cmd = new SqlCommand("CreateUpdate_User_Like", (SqlConnection)con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@UL_PKeyID", model.UL_PKeyID);
                    cmd.Parameters.AddWithValue("@UL_Name", model.UL_Name);
                    cmd.Parameters.AddWithValue("@UL_UP_PKeyID", model.UL_UP_PKeyID);
                    cmd.Parameters.AddWithValue("@UL_User_PkeyID", model.UL_User_PkeyID);


                    cmd.Parameters.AddWithValue("@UL_IsActive", model.UL_IsActive);
                    cmd.Parameters.AddWithValue("@UL_IsDelete", model.UL_IsDelete);
                    cmd.Parameters.AddWithValue("@Type", model.Type);
                    cmd.Parameters.AddWithValue("@UserID", model.UserID);

                    SqlParameter UL_Pkey_Out = cmd.Parameters.AddWithValue("@UL_Pkey_Out", 0);
                    UL_Pkey_Out.Direction = ParameterDirection.Output;
                    SqlParameter ReturnValue = cmd.Parameters.AddWithValue("@ReturnValue", 0);
                    ReturnValue.Direction = ParameterDirection.Output;


                    cmd.ExecuteNonQuery();
                    objData.Add(UL_Pkey_Out.Value);
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

        public List<dynamic> AddUpdateUser_Like_Data(User_Like_DTO model)
        {

            List<dynamic> objData = new List<dynamic>();
            try
            {
                objData = CreateUpdateUserLike(model);

                if (model.Type == 1 && model.UL_IsActive == true)
                //if (model.Type == 1)
                    {
                    User_Post_Data user_Post_Data = new User_Post_Data(_configuration);
                    User_Notification_DTO user_Notification_DTO = new User_Notification_DTO();
                    if (model.UL_UP_PKeyID != null)
                    {
                        user_Notification_DTO.NT_UP_PKeyID = Convert.ToInt64(model.UL_UP_PKeyID);
                        user_Notification_DTO.NT_UL_PKeyID = objData[0];
                        user_Notification_DTO.NT_C_L = 2;
                        user_Notification_DTO.UserID = model.UserID;
                        user_Post_Data.SendNotification(user_Notification_DTO);
                    }
                }

            }
            catch (Exception ex)
            {
                log.logErrorMessage(ex.StackTrace);
                log.logErrorMessage(ex.Message);
            }

            return objData;
        }

        private DataSet Get_UserMaster(User_Like_DTO_Input model)
        {
            DataSet ds = new DataSet();
            try
            {
                SqlCommand cmd = new SqlCommand("Get_User_Like", (SqlConnection)Connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@UL_PkeyID", model.UL_PkeyID);
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


        public List<dynamic> Get_User_LikeDetailsDTO(User_Like_DTO_Input model)
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