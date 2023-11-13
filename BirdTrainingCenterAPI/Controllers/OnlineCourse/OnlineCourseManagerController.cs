﻿using AppService;
using AppService.Implementation;
using AppService.OnlineCourseService;
using BirdTrainingCenterAPI.Controllers.Endpoints.OnlineCourse;
using BirdTrainingCenterAPI.Helper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Models.ApiParamModels.OnlineCourse;
using Models.ConfigModels;
using Models.ServiceModels.OnlineCourseModels.Operation;

namespace BirdTrainingCenterAPI.Controllers.OnlineCourse
{
    [Route("api/online-course/management")]
    [ApiController]
    public class OnlineCourseManagerController : OnlineCourseBaseController, IOnlineCourseManager
    {
        private readonly IFirebaseService _firebaseService;
        private readonly FirebaseBucket _bucket;
        public OnlineCourseManagerController(IOnlineCourseService onlineCourseService, IAuthService authService, IFirebaseService firebaseService, IOptions<FirebaseBucket> bucket) : base(onlineCourseService, authService)
        {
            _firebaseService = firebaseService;
            _bucket = bucket.Value;
        }
        [HttpPost]
        [Route("add-course")]
        public async Task<IActionResult> CreateOnlineCourse([FromForm] OnlineCourseAddParamModel model)
        {
            if (!model.Picture.IsImage())
            {
                return BadRequest("Upload image only!");
            }
            var picture = await _firebaseService.UploadFile(model.Picture, $"{model.Picture.FileName}_{DateTime.Now.ToString("yyyyMMddHHmmss")}", FirebaseFolder.WOKRSHOP, _bucket.General);            
            var courseAdd = model.ToOnlineCourseAddModel(picture);
            await _onlineCourseService.Manager.CreateOnlineCourse(courseAdd);
            return Ok();
        }
        [HttpPost]
        [Route("add-section")]
        public async Task<IActionResult> AddSection([FromForm] OnlineCourseSectionAddModel model)
        {
            await _onlineCourseService.Manager.AddSection(model);
            return Ok();
        }
        [HttpPost]
        [Route("add-lesson")]
        public async Task<IActionResult> AddLesson([FromForm] OnlineCourseLessonAddParamModel model)
        {
            string? video = null;
            if(model.Video != null)
            {
                video = await _firebaseService.UploadFile(model.Video, $"{model.Video.FileName}_{DateTime.Now.ToString("yyyyMMddHHmmss")}", FirebaseFolder.VIDEO, _bucket.General);
            } 
            var lessonAdd = model.ToOnlineCourseLessonAddModel(video);
            await _onlineCourseService.Manager.AddLesson(lessonAdd);
            return Ok();
        }
        [HttpPut]
        [Route("modify-section")]
        public async Task<IActionResult> ModifySection([FromForm] OnlineCourseSectionModifyModel model)
        {
            await _onlineCourseService.Manager.ModifySection(model);
            return Ok();
        }
        [HttpPut]
        [Route("modify-lesson")]
        public async Task<IActionResult> ModifyLesson([FromForm] OnlineCourseLessonModifyParamModel model)
        {
            string? video = null;
            if (model.Video != null)
            {
                video = await _firebaseService.UploadFile(model.Video, $"{model.Video.FileName}_{DateTime.Now.ToString("yyyyMMddHHmmss")}", FirebaseFolder.VIDEO, _bucket.General);
            }
            var lessonModify = model.ToOnlineCourseLessonModifyModel(video);
            await _onlineCourseService.Manager.ModifyLesson(lessonModify);
            return Ok();
        }
        [HttpDelete]
        [Route("delete-section")]
        public async Task<IActionResult> DeleteSection([FromBody] int sectionId)
        {
            await _onlineCourseService.Manager.DeleteSection(sectionId);
            return Ok();
        }
        [HttpDelete]
        [Route("delete-lesson")]
        public async Task<IActionResult> DeleteLesson([FromBody] int lessonId)
        {
            await _onlineCourseService.Manager.DeleteLesson(lessonId);
            return Ok();
        }
        [HttpPut]
        [Route("activate")]
        public async Task<IActionResult> ActivateCourse([FromBody] int courseId)
        {
            await _onlineCourseService.Manager.ChangeCourseStatus(courseId, Models.Enum.OnlineCourse.Status.ACTIVE);
            return Ok();
        }
        [HttpPut]
        [Route("deactivate")]
        public async Task<IActionResult> DeactivateCourse([FromBody] int courseId)
        {
            await _onlineCourseService.Manager.ChangeCourseStatus(courseId, Models.Enum.OnlineCourse.Status.INACTIVE);
            return Ok();
        }
        [HttpPut]
        [Route("cancel")]
        public async Task<IActionResult> CancelCourse([FromBody] int courseId)
        {
            await _onlineCourseService.Manager.ChangeCourseStatus(courseId, Models.Enum.OnlineCourse.Status.CANCELLED);
            return Ok();
        }
    }
}