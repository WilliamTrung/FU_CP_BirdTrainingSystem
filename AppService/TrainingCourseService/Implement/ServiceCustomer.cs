﻿using Models.ServiceModels.TrainingCourseModels;
using Models.ServiceModels.TrainingCourseModels.BirdTrainingCourse;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimetableSubsystem;
using TrainingCourseSubsystem;

namespace AppService.TrainingCourseService.Implement
{
    public class ServiceCustomer : ServiceAll, IServiceCustomer
    {
        public ServiceCustomer(ITrainingCourseFeature trainingCourse, ITimetableFeature timetable) : base(trainingCourse, timetable)
        {
        }

        public async Task<IEnumerable<BirdModel>> GetBirdByCustomerId(int customerId)
        {
            return await _trainingCourse.Customer.GetBirdByCustomerId(customerId);
        }

        public async Task<IEnumerable<TrainingCourseModel>> GetTrainingCourse()
        {
            return await _trainingCourse.Customer.GetTrainingCourse();
        }

        public async Task<TrainingCourseModel> GetTrainingCourseById(int trainingCourseId)
        {
            return await _trainingCourse.Customer.GetTrainingCourseById(trainingCourseId);
        }

        public async Task<IEnumerable<TrainingCourseModel>> GetTrainingCourseBySpeciesId(int birdSpeciesId)
        {
            return await _trainingCourse.Customer.GetTrainingCourseBySpeciesId(birdSpeciesId);
        }

        public async Task RegisterBird(BirdModel bird)
        {
            await _trainingCourse.Customer.RegisterBird(bird);
        }

        public async Task RegisterTrainingCourse(BirdTrainingCourseRegister birdTrainingCourseRegister)
        {
            await _trainingCourse.Customer.RegisterTrainingCourse(birdTrainingCourseRegister);
        }

        public async Task UpdateBirdProfile(BirdModel bird)
        {
            await UpdateBirdProfile(bird);
        }
    }
}