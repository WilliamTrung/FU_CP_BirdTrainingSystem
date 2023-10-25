using AppService;
using Microsoft.AspNetCore.Mvc;
using Org.BouncyCastle.Asn1.Ocsp;
using System.Security.Claims;

namespace BirdTrainingCenterAPI.Helper
{
    public static class CustomRequestAddon
    {
        public static List<Claim>? DeserializeToken(this HttpRequest request, in IAuthService authService)
        {
            var authHeader = request.Headers["Authorization"];
            if (authHeader.Count == 0 || !authHeader[0].StartsWith("Bearer "))
            {
                return null;
            }
            string accessToken = authHeader[0].Split(' ')[1];
            return authService.DeserializedToken(accessToken);
        }
        public static bool IsImage(this IFormFile file)
        {
            // Define a list of image content types
            string[] allowedImageTypes = { "image/jpeg", "image/png", "image/gif", "image/bmp" };

            // Check if the content type of the file is in the list of allowed image types
            return file != null && allowedImageTypes.Contains(file.ContentType);
        }
    }
}
