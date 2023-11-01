﻿using AppService;
using AppService.AdministrativeService;
using AppService.Implementation;
using BirdTrainingCenterAPI.Controllers.Endpoints.Administrative;
using BirdTrainingCenterAPI.Helper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using Microsoft.Extensions.Options;
using Models.AuthModels;
using Models.ConfigModels;
using Models.ServiceModels.UserModels;
using SP_Middleware;
using System;

namespace BirdTrainingCenterAPI.Controllers.Administrative
{
    [Route("api/profile")]
    [ApiController]
    [CustomAuthorize(roles: null)]
    public class ProfileController : ODataController, IProfileManagement
    {
        private readonly IAdministrativeService _admin;
        private readonly IAuthService _auth;
        private readonly IFirebaseService _firebaseService;
        private readonly FirebaseBucket _bucket;
        public ProfileController(IAdministrativeService admin, IAuthService auth, IFirebaseService firebase, IOptions<FirebaseBucket> bucket)
        {
            _admin = admin;
            _auth = auth;
            _firebaseService = firebase;
            _bucket = bucket.Value;
        }
        [HttpGet]
        public async Task<IActionResult> GetProfile()
        {
            var accessToken = Request.DeserializeToken(_auth);
            if (accessToken == null)
            {
                return Unauthorized();
            }
           
            try
            {
                var id = accessToken.First(c => c.Type == CustomClaimTypes.Id);
                var role = accessToken.First(c => c.Type == CustomClaimTypes.Role);
                Models.Enum.Role roleEnum = (Models.Enum.Role)Enum.Parse(typeof(Models.Enum.Role), role.Value);
                var result = await _admin.Profile.GetProfile(Int32.Parse(id.Value), roleEnum);
                return Ok(result);
            } catch (KeyNotFoundException ex)
            {
                return Unauthorized(ex.Message);
            } 
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status400BadRequest, ex.Message);
            }
        }
        [HttpPut]
        [Route("update-information")]
        public async Task<IActionResult> UpdateInformation(AdditionalUpdateModel model)
        {
            var accessToken = Request.DeserializeToken(_auth);
            if (accessToken == null)
            {
                return Unauthorized();
            }

            try
            {
                var id = accessToken.First(c => c.Type == CustomClaimTypes.Id);
                var role = accessToken.First(c => c.Type == CustomClaimTypes.Role);
                Models.Enum.Role roleEnum = (Models.Enum.Role)Enum.Parse(typeof(Models.Enum.Role), role.Value);
                await _admin.Profile.UpdateInformation(Int32.Parse(id.Value), roleEnum, model);
                return Ok();
            }
            catch (KeyNotFoundException ex)
            {
                return Unauthorized(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status400BadRequest, ex.Message);
            }
        }
        [HttpPut]
        [Route("update-avatar")]
        public async Task<IActionResult> UpdateAvatar(IFormFile avatar)
        {
            var accessToken = Request.DeserializeToken(_auth);
            if (accessToken == null)
            {
                return Unauthorized();
            }
            string avatarUrl = "";
            try
            {
                var id = accessToken.First(c => c.Type == CustomClaimTypes.Id);
                var role = accessToken.First(c => c.Type == CustomClaimTypes.Role);
                Models.Enum.Role roleEnum = (Models.Enum.Role)Enum.Parse(typeof(Models.Enum.Role), role.Value);

                var pictures = string.Empty;
                if (!avatar.IsImage())
                {
                    return BadRequest("Upload image only!");
                }
                avatarUrl = await _firebaseService.UploadFile(avatar, $"{avatar.FileName}_{DateTime.Now.ToString("yyyyMMddHHmmss")}", FirebaseFolder.PROFILE_USER, _bucket.General);                

                await _admin.Profile.UpdateAvatar(Int32.Parse(id.Value), roleEnum, avatarUrl);
                return Ok();
            }
            catch (KeyNotFoundException ex)
            {
                await _firebaseService.DeleteFile(avatarUrl, _bucket.General);
                return Unauthorized(ex.Message);
            }
            catch (Exception ex)
            {
                await _firebaseService.DeleteFile(avatarUrl, _bucket.General);
                return StatusCode(StatusCodes.Status400BadRequest, ex.Message);
            }
        }
    }
}
