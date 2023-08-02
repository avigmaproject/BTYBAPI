using Amazon;
using Amazon.Runtime.Internal.Endpoints.StandardLibrary;
using Amazon.Runtime.SharedInterfaces;
using Amazon.S3;
using Amazon.S3.Model;
using Amazon.S3.Transfer;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BTYBApi.Models.Lib;
using BTYBApi.Repository.Lib;

namespace BTYBApi.Repository.Lib
{
    public class FileUploadAwsBukcet
    {
        Log log = new Log();
        public AmazonBucketDTO UploadFileAmazonBuket(AmazonBucketDTO amazonBucketDTO)
        {
            try
            {


                using (var client = new AmazonS3Client(amazonBucketDTO.AccessKey, amazonBucketDTO.SecretKey, RegionEndpoint.APSouth1))
                {
                    var request = new PutObjectRequest
                    {
                        BucketName = amazonBucketDTO.BucketName,
                        Key = amazonBucketDTO.FileName,
                        FilePath = amazonBucketDTO.FilePath
                    };

                    var expiryUrlRequest = new GetPreSignedUrlRequest()
                    {
                        BucketName = amazonBucketDTO.BucketName,
                        Key = amazonBucketDTO.FileName,
                        Expires = DateTime.UtcNow.AddHours(1)
                    };


                    var response = client.PutObjectAsync(request).Result;
                    var s3Url = client.GetPreSignedURL(expiryUrlRequest);
                    amazonBucketDTO.ReturnURL = s3Url;


                }

            }
            catch (Exception ex)
            {
                log.logErrorMessage(ex.Message);
                log.logErrorMessage(ex.StackTrace);
            }

            return amazonBucketDTO;

        }

    }
}