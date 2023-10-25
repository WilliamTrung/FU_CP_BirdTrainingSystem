using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SP_Extension
{
    public static class CustomFileFunctions
    {
        public static bool IsImage(this IFormFile file)
        {
            string contentType = "image";
            return file.ContentType.Contains(contentType);
        }

        public static bool IsVideo(this IFormFile file)
        {
            string contentType = "video";
            return file.ContentType.Contains(contentType);
        }
    }
}
