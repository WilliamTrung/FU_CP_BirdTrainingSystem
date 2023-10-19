﻿using Models.ServiceModels.TrainingCourseModels;
using Models.ServiceModels.TrainingCourseModels.BirdTrainingCourse;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace TrainingCourseSubsystem;
//FE28[Customer] view[Training Course Detail] - of the in-training[Bird] - to check progression
public interface IFeatureCustomer
{
    Task RegisterBird(BirdModel bird);
    Task UpdateBirdProfile(BirdModel bird);
    Task<IEnumerable<BirdModel>> GetBirdByCustomerId(int customerId);
    Task<IEnumerable<TrainingCourseModel>> GetTrainingCourse();
    Task<IEnumerable<TrainingCourseModel>> GetTrainingCourseBySpeciesId(int birdSpeciesId);
    Task<TrainingCourseModel> GetTrainingCourseById(int trainingCourseId);
    Task RegisterTrainingCourse(BirdTrainingCourseRegister birdTrainingCourseRegister);
}