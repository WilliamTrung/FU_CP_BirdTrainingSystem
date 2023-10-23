﻿using AppService.TrainingCourseService;
using BirdTrainingCenterAPI.Controllers.Endpoints.TrainingCourse;
using Microsoft.AspNetCore.Mvc;
using Models.ServiceModels.TrainingCourseModels;
using Models.ServiceModels.TrainingCourseModels.BirdTrainingCourse;

namespace BirdTrainingCenterAPI.Controllers.TrainingCourse
{
    [Route("api/trainingcourse-customer")]
    [ApiController]
    public class TrainingCourseCustomerController : TrainingCourseBaseController, ITrainingCourseCustomer
    {
        public TrainingCourseCustomerController(ITrainingCourseService trainingCourseService) : base(trainingCourseService)
        {
        }
        [HttpPost]
        [Route("register-bird")]
        public async Task<IActionResult> RegisterBird([FromBody] BirdModel bird)
        {
            await _trainingCourseService.Customer.RegisterBird(bird);
            return Ok(bird);
        }
        [HttpPut]
        [Route("update-bird")]
        public async Task<IActionResult> UpdateBirdProfile(BirdModel bird)
        {
            await _trainingCourseService.Customer.UpdateBirdProfile(bird);
            return Ok();
        }
        [HttpGet]
        [Route("customer-bird")]
        public async Task<IActionResult> GetBirdByCustomerId([FromQuery] int customerId)
        {
            var result = await _trainingCourseService.Customer.GetBirdByCustomerId(customerId);
            return Ok(result);
        }
        [HttpGet]
        [Route("trainingcourse")]
        public async Task<IActionResult> GetTrainingCourse()
        {
            var result = await _trainingCourseService.Customer.GetTrainingCourse();
            return Ok(result);
        }
        [HttpGet]
        [Route("trainingcourse-species")]
        public async Task<IActionResult> GetTrainingCourseBySpeciesId([FromQuery] int birdSpeciesId)
        {
            var result = await _trainingCourseService.Customer.GetTrainingCourseBySpeciesId(birdSpeciesId);
            return Ok(result);
        }
        [HttpGet]
        [Route("trainingcourse-id")]
        public async Task<IActionResult> GetTrainingCourseById([FromQuery] int trainingCourseId)
        {
            var result = await _trainingCourseService.Customer.GetTrainingCourseById(trainingCourseId);
            return Ok(result);
        }
        [HttpPost]
        [Route("register-trainingcourse")]
        public async Task<IActionResult> RegisterTrainingCourse(BirdTrainingCourseRegister birdTrainingCourseRegister)
        {
            await _trainingCourseService.Customer.RegisterTrainingCourse(birdTrainingCourseRegister);
            return Ok();
        }
        [HttpGet]
        [Route("registered-trainingcourse")]
        public async Task<IActionResult> GetRegisteredBirdTrainingCourseProgress([FromQuery] int birdTrainingCourseId)
        {
            var result = await _trainingCourseService.Customer.ViewBirdTrainingCourseProgress(birdTrainingCourseId);
            return Ok(result);
        }
        [HttpGet]
        [Route("registered-birdtrainingcourseprogress")]
        public async Task<IActionResult> GetRegisteredBirdTrainingCourseReport([FromQuery] int birdTrainingProgressId)
        {
            var result = await _trainingCourseService.Customer.ViewBirdTrainingCourseReport(birdTrainingProgressId);
            return Ok(result);
        }
        [HttpGet]
        [Route("registered-birdtrainingcoursereport")]
        public async Task<IActionResult> GetRegisteredTrainingCourse([FromQuery] int birdId, [FromQuery] int customerId)
        {
            var result = await _trainingCourseService.Customer.ViewRegisteredTrainingCourse(birdId: birdId, customerId: customerId);
            return Ok(result);
        }
    }
}
