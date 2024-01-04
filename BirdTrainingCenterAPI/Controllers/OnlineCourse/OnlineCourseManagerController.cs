using AppService;
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
using SP_Middleware;

namespace BirdTrainingCenterAPI.Controllers.OnlineCourse
{
    [Route("api/online-course/management")]
    [ApiController]
    [CustomAuthorize(roles: "Manager")]
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
            var id = await _onlineCourseService.Manager.CreateOnlineCourse(courseAdd);
            return Ok(id);
        }
        [HttpPost]
        [Route("add-section")]
        public async Task<IActionResult> AddSection([FromForm] OnlineCourseSectionAddParamModel model)
        {
            string? files = null;
            if (model.ResourceFiles != null && model.ResourceFiles.Count > 0)
            {
                foreach (var file in model.ResourceFiles)
                {
                    var temp = await _firebaseService.UploadFile(file, file.FileName, FirebaseFolder.ONLINECOURSE_RESOURCE, _bucket.General);
                    files += $"{temp},";
                }
                files = files.Substring(0, files.Length - 1);
            }
            await _onlineCourseService.Manager.AddSection(model.ToOnlineCourseLessonModifyModel(files));
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
        public async Task<IActionResult> ModifySection([FromForm] OnlineCourseSectionModifyParamModel model)
        {
            string? files = null;
            if (model.ResourceFiles != null && model.ResourceFiles.Count > 0)
            {
                foreach (var file in model.ResourceFiles)
                {
                    var extension = Path.GetExtension(file.FileName);
                    var temp = await _firebaseService.UploadFile(file, $"{Guid.NewGuid().ToString()}{extension}", FirebaseFolder.ONLINECOURSE_RESOURCE, _bucket.General);
                    files += $"{temp},";
                }
                files = files.Substring(0, files.Length - 1);
                var section = await _onlineCourseService.Manager.GetSectionById(model.Id);
                if (section.ResourceFiles != null)
                {
                    foreach (var link in section.ResourceFiles.Split(","))
                    {
                        await _firebaseService.DeleteFile(link, _bucket.General);
                    }
                }
            }            
            await _onlineCourseService.Manager.ModifySection(model.ToOnlineCourseLessonModifyModel(files));
         
            return Ok();
        }
        [HttpDelete]
        [Route("delete-resource")]
        public async Task<IActionResult> DeleteResourcesInSection([FromBody] int sectionId)
        {
            var section = await _onlineCourseService.Manager.GetSectionById(sectionId);
            if(section.ResourceFiles != null)
            {
                foreach (var link in section.ResourceFiles.Split(","))
                {
                    await _firebaseService.DeleteFile(link, _bucket.General);
                }
            }
            return Ok();
        }
        [HttpPut]
        [Route("modify-lesson")]
        public async Task<IActionResult> ModifyLesson([FromForm] OnlineCourseLessonModifyParamModel model)
        {
            string? video = null;
            if (model.Video != null)
            {
                var extension = Path.GetExtension(model.Video.FileName);
                video = await _firebaseService.UploadFile(model.Video, $"{Guid.NewGuid().ToString()}{extension}", FirebaseFolder.VIDEO, _bucket.General);
                var lesson = await _onlineCourseService.Manager.GetLessonById(model.Id);
                if (lesson.Video != null)
                {
                    foreach (var link in lesson.Video.Split(","))
                    {
                        await _firebaseService.DeleteFile(link, _bucket.General);
                    }
                }
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
        [HttpPut]
        [Route("/modify-course")]
        public async Task<IActionResult> Modify([FromForm] OnlineCourseModifyParamModel model)
        {
            string? picture = null;
            if(model.Picture != null)
            {
                if (!model.Picture.IsImage())
                {
                    return BadRequest("Upload image only!");
                }
                picture = await _firebaseService.UploadFile(model.Picture, $"{model.Picture.FileName}_{DateTime.Now.ToString("yyyyMMddHHmmss")}", FirebaseFolder.WOKRSHOP, _bucket.General);
                var course = await _onlineCourseService.Manager.GetCourseById(model.Id);
                if (course.Picture != null) {
                    foreach (var link in course.Picture.Split(","))
                    {
                        await _firebaseService.DeleteFile(link, _bucket.General);
                    }
                }
            }
            var courseModify = model.ToOnlineCourseModifyModel(picture);
            await _onlineCourseService.Manager.ModifyOnlineCourse(courseModify);
            return Ok();
        }
    }
}
