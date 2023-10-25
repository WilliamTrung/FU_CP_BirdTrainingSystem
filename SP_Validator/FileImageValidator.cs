using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SP_Validator
{
    public class FileImageValidator : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            if (value is IFormFile file)
            {
                // Define a list of image content types
                string[] allowedImageTypes = { "image/jpeg", "image/png", "image/gif", "image/bmp" };

                // Check if the content type of the file is in the list of allowed image types
                return file != null && allowedImageTypes.Contains(file.ContentType);
            } else if(value is List<IFormFile> list)
            {
                string[] allowedImageTypes = { "image/jpeg", "image/png", "image/gif", "image/bmp" };

                // Check if the content type of the file is in the list of allowed image types
                return list != null && list.Any(e => allowedImageTypes.Contains(e.ContentType));
            }
            return false;
        }
    }
}
