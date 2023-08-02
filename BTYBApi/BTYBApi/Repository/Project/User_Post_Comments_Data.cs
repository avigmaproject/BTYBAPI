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
    public class User_Post_Comments_Data : IUser_Post_Comments_Data
    {
        Log log = new Log();
        SecurityHelper securityHelper = new SecurityHelper();
        ObjectConvert obj = new ObjectConvert();
        private readonly IConfiguration _configuration;
        public string ConnectionString { get; }
        public User_Post_Comments_Data()
        {
        }
        public User_Post_Comments_Data(IConfiguration configuration)
        {
            _configuration = configuration;
            ConnectionString = _configuration.GetConnectionString("Conn_dBcon");
        }


        public IDbConnection Connection
        {
            get { return new SqlConnection(ConnectionString); }
        }

        private List<dynamic> CreateUpdateUserPostComment(User_Post_Comments_DTO model)
        {
            List<dynamic> objData = new List<dynamic>();

            using (IDbConnection con = Connection)
            {
                if (Connection.State == ConnectionState.Closed) con.Open();

                try
                {
                    SqlCommand cmd = new SqlCommand("CreateUpdate_User_Post_Comments", (SqlConnection)con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@UPC_PkeyID", model.UPC_PkeyID);
                    cmd.Parameters.AddWithValue("@UPC_User_PkeyID", model.UPC_User_PkeyID);
                    cmd.Parameters.AddWithValue("@UPC_UP_PKeyID", model.UPC_UP_PKeyID);
                    cmd.Parameters.AddWithValue("@UPC_Comments", model.UPC_Comments);
                    cmd.Parameters.AddWithValue("@UPC_Location", model.UPC_Location);
                    cmd.Parameters.AddWithValue("@UPC_Latitude", model.UPC_Latitude);
                    cmd.Parameters.AddWithValue("@UPC_Longitude", model.UPC_Longitude);

                    cmd.Parameters.AddWithValue("@UPC_Like", model.UPC_Like);
                    cmd.Parameters.AddWithValue("@UPC_Rating", model.UPC_Rating);
                    cmd.Parameters.AddWithValue("@UPC_Comment_PkeyID", model.UPC_Comment_PkeyID);


                    cmd.Parameters.AddWithValue("@UPC_IsActive", model.UPC_IsActive);
                    cmd.Parameters.AddWithValue("@UPC_IsDelete", model.UPC_IsDelete);
                    cmd.Parameters.AddWithValue("@Type", model.Type);
                    cmd.Parameters.AddWithValue("@UserID", model.UserID);
                    //cmd.Parameters.AddWithValue("@UPC_PkeyID_Out", 0).Direction = ParameterDirection.Output;
                    //cmd.Parameters.AddWithValue("@ReturnValue", 0).Direction = ParameterDirection.Output;

                    SqlParameter UPC_PkeyID_Out = cmd.Parameters.AddWithValue("@UPC_PkeyID_Out", 0);
                    UPC_PkeyID_Out.Direction = ParameterDirection.Output;
                    SqlParameter ReturnValue = cmd.Parameters.AddWithValue("@ReturnValue", 0);
                    ReturnValue.Direction = ParameterDirection.Output;


                    cmd.ExecuteNonQuery();
                    objData.Add(UPC_PkeyID_Out.Value);
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
        public List<dynamic> AddUpdateUser_Post_Comments_Data(User_Post_Comments_DTO model)
        {
            string msg = string.Empty;

            List<dynamic> objData = new List<dynamic>();
            try
            {

                objData = CreateUpdateUserPostComment(model);

                if (model.Type == 1)
                {
                    User_Post_Data user_Post_Data = new User_Post_Data(_configuration);
                    User_Notification_DTO user_Notification_DTO = new User_Notification_DTO();
                    if (model.UPC_UP_PKeyID != null)
                    {
                        user_Notification_DTO.NT_UP_PKeyID = Convert.ToInt64(model.UPC_UP_PKeyID);
                        user_Notification_DTO.NT_UPC_PkeyID = objData[0];
                        user_Notification_DTO.NT_C_L = 1;
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

        private DataSet Get_UserMaster(User_Post_Comments_DTO_Input model)
        {
            DataSet ds = new DataSet();
            try
            {
                SqlCommand cmd = new SqlCommand("Get_User_Post_Comments", (SqlConnection)Connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@UPC_PkeyID", model.UPC_PkeyID);
                cmd.Parameters.AddWithValue("@UPC_User_PkeyID", model.UPC_User_PkeyID);
                cmd.Parameters.AddWithValue("@UPC_UP_PKeyID", model.UPC_UP_PKeyID);
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


        public List<dynamic> Get_User_Post_CommentsDetailsDTO(User_Post_Comments_DTO_Input model)
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