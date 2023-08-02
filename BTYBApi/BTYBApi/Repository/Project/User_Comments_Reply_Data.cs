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
    public class User_Comments_Reply_Data : IUser_Comments_Reply_Data
    {
        Log log = new Log();
        SecurityHelper securityHelper = new SecurityHelper();
        ObjectConvert obj = new ObjectConvert();
        private readonly IConfiguration _configuration;
        public string ConnectionString { get; }
        public User_Comments_Reply_Data()
        {
        }
        public User_Comments_Reply_Data(IConfiguration configuration)
        {
            _configuration = configuration;
            ConnectionString = _configuration.GetConnectionString("Conn_dBcon");
        }


        public IDbConnection Connection
        {
            get { return new SqlConnection(ConnectionString); }
        }

        private List<dynamic> CreateUpdateUserPostCommentReply(User_Comments_Reply_DTO model)
        {
            List<dynamic> objData = new List<dynamic>();
            using (IDbConnection con = Connection)
            {
                if (Connection.State == ConnectionState.Closed) con.Open();

                try
                {
                    SqlCommand cmd = new SqlCommand("CreateUpdate_User_Comments_Reply", (SqlConnection)con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@UPR_PkeyID", model.UPR_PkeyID);
                    cmd.Parameters.AddWithValue("@UPR_UPC_PkeyID", model.UPR_UPC_PkeyID);
                    cmd.Parameters.AddWithValue("@UPR_User_PkeyID", model.UPR_User_PkeyID);
                    cmd.Parameters.AddWithValue("@UPR_Like", model.UPR_Like);
                    cmd.Parameters.AddWithValue("@UPR_Comments", model.UPR_Comments);
                    cmd.Parameters.AddWithValue("@UPR_Location", model.UPR_Location);
                    cmd.Parameters.AddWithValue("@UPR_Latitude", model.UPR_Latitude);
                    cmd.Parameters.AddWithValue("@UPR_Longitude", model.UPR_Longitude);
                    cmd.Parameters.AddWithValue("@UPR_Rating", model.UPR_Rating);
                    cmd.Parameters.AddWithValue("@UPC_Rating", model.UPC_Rating);
                    cmd.Parameters.AddWithValue("@UPR_CR_PkeyID", model.UPR_CR_PkeyID);


                    cmd.Parameters.AddWithValue("@UPR_IsActive", model.UPR_IsActive);
                    cmd.Parameters.AddWithValue("@UPR_IsDelete", model.UPR_IsDelete);
                    cmd.Parameters.AddWithValue("@Type", model.Type);
                    cmd.Parameters.AddWithValue("@UserID", model.UserID);
                    //cmd.Parameters.AddWithValue("@UPR_PkeyID_Out", 0).Direction = ParameterDirection.Output;
                    //cmd.Parameters.AddWithValue("@ReturnValue", 0).Direction = ParameterDirection.Output;

                    SqlParameter UPR_PkeyID_Out = cmd.Parameters.AddWithValue("@UPR_PkeyID_Out", 0);
                    UPR_PkeyID_Out.Direction = ParameterDirection.Output;
                    SqlParameter ReturnValue = cmd.Parameters.AddWithValue("@ReturnValue", 0);
                    ReturnValue.Direction = ParameterDirection.Output;


                    cmd.ExecuteNonQuery();
                    objData.Add(UPR_PkeyID_Out.Value);
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
        public List<dynamic> AddUpdateUser_Comments_Reply_Data(User_Comments_Reply_DTO model)
        {
            string msg = string.Empty;

            List<dynamic> objData = new List<dynamic>();
            try
            {

                objData = CreateUpdateUserPostCommentReply(model);

                if (model.Type == 1)
                {
                    User_Post_Data user_Post_Data = new User_Post_Data(_configuration);
                    User_Notification_DTO user_Notification_DTO = new User_Notification_DTO();
                    if (model.UPR_UPC_PkeyID != null)
                    {
                        user_Notification_DTO.NT_UPC_PkeyID = Convert.ToInt64(model.UPR_UPC_PkeyID);
                        user_Notification_DTO.NT_UPR_PkeyID = objData[0];
                        user_Notification_DTO.NT_C_L = 3;
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

        private DataSet Get_UserMaster(User_Comments_Reply_DTO_Input model)
        {
            DataSet ds = new DataSet();
            try
            {
                SqlCommand cmd = new SqlCommand("Get_User_Comments_Reply", (SqlConnection)Connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@UPR_PkeyID", model.UPR_PkeyID);
                cmd.Parameters.AddWithValue("@UPR_User_PkeyID", model.UPR_User_PkeyID);
                cmd.Parameters.AddWithValue("@UPR_UPC_PkeyID", model.UPR_UPC_PkeyID);
                cmd.Parameters.AddWithValue("@UserID", model.UserID);
                
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


        public List<dynamic> Get_User_Comments_ReplyDetailsDTO(User_Comments_Reply_DTO_Input model)
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