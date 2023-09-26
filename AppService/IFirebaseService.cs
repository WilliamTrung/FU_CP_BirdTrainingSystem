using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppService
{
    public interface IFirebaseService
    {
        Task<string> UploadFile(IFormFile file,string fileName, string saveFolder, string bucketName);
    }
}
