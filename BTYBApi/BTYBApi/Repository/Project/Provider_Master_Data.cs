using BTYBApi.Models.Project;
using BTYBApi.Models;
using BTYBApi.Repository.Lib;
using BTYBApi.Repository.Lib.Security;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using BTYBApi.Models.Avigma;
using System.Data.SqlClient;
using BTYBApi.IRepository.Project;

namespace API.Repository.Project
{
    public class Provider_Master_Data : IProvider_Master_Data
    {
        //MyDataSourceFactory obj = new MyDataSourceFactory();
        Log log = new Log();
        SecurityHelper securityHelper = new SecurityHelper();
        ObjectConvert obj = new ObjectConvert();

        private readonly IConfiguration _configuration;
        public string ConnectionString { get; }
        public Provider_Master_Data()
        {
        }
        public Provider_Master_Data(IConfiguration configuration)
        {
            _configuration = configuration;
            ConnectionString = _configuration.GetConnectionString("Conn_dBcon");
        }


        public IDbConnection Connection
        {
            get { return new SqlConnection(ConnectionString); }
        }


        public List<dynamic> CreateUpdate_Provider_Master_DataDetails(Provider_Master_DTO model)
        {
            List<dynamic> objData = new List<dynamic>();
            //Clinic_AdminMaster_DTO clinic_AdminMaster_DTO = new Clinic_AdminMaster_DTO();
            //Clinic_AdminMaster_Data clinic_AdminMaster_Data = new Clinic_AdminMaster_Data();
            try
            {
                UserVerificationMaster_Data userVerificationMaster_Data = new UserVerificationMaster_Data(_configuration);
                UserUserVerificationMaster_Details userUserVerificationMaster_Details = new UserUserVerificationMaster_Details();
                string sendEmailUrl = _configuration["sendEmailUrl"].ToString();//["sendEmailUrl"].ToString();

                userUserVerificationMaster_Details.User_Email = model.PD_Email;
                userUserVerificationMaster_Details.User_FirstName = model.PD_Name;
                userUserVerificationMaster_Details.User_pkeyID = model.UserID;
                userUserVerificationMaster_Details.Device = 1;
                userUserVerificationMaster_Details.Email_Url = sendEmailUrl;
                //userUserVerificationMaster_Details.UserOtp = model.PD_Mobile_OTP;
                userVerificationMaster_Data.GeneratePasswordLink(userUserVerificationMaster_Details, 1);

            }
            catch (Exception ex)
            {
                log.logErrorMessage(ex.Message);
                log.logErrorMessage(ex.StackTrace);
            }
            return objData;
        }

    }
}