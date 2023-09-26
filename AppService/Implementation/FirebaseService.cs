using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Pipes;
using System.Linq;
using System.Net.Mime;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

using FirebaseAdmin;
using Google.Apis.Auth.OAuth2;
using Google.Cloud.Storage.V1;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using Models;
using Models.ConfigModels;
using static Google.Cloud.Storage.V1.UrlSigner;
//using Models.ServiceModels;

namespace AppService.Implementation
{
    public class FirebaseService : IFirebaseService
    {
        private readonly StorageClient _storageClient;
        private readonly FirebaseConfig _firebaseConfig;
        public FirebaseService(StorageClient storageClient, IOptions<FirebaseConfig> firebaseConfig)
        {
            _storageClient = storageClient;
            _firebaseConfig = firebaseConfig.Value;
        }

        public async Task<bool> DeleteFile(string fileUrl, string bucketName)
        {         
            try
            {
                var fileName = fileUrl.Split(bucketName)[1].Substring(1);
                await _storageClient.DeleteObjectAsync(
                                    bucketName,
                                    fileName
                                    );                
                return true;
            } catch {
                return false;
            }                       
        }

        public async Task<string> UploadFile(IFormFile file, string fileName, string saveFolder, string bucketName)
        {                  
            //Set public read action
            UploadObjectOptions options = new UploadObjectOptions
            {
                PredefinedAcl = PredefinedObjectAcl.PublicRead
            };
            var fileSavePath = $@"{saveFolder}/{fileName}";
            
            using (var fileStream = file.OpenReadStream())
            {
                var task = _storageClient.UploadObjectAsync(
                                bucketName,
                                fileSavePath,
                                contentType: file.ContentType,
                                fileStream,
                                options: options
                                );
                var uploaded = await task;
                var url = @$"{_firebaseConfig.Storage}{uploaded.Bucket}/{uploaded.Name}";
                return url;
            }            
        }
    }
}
