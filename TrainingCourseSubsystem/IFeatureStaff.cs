﻿using Models.ServiceModels.TrainingCourseModels;
using Models.ServiceModels.TrainingCourseModels.BirdTrainingCourse;
using Models.ServiceModels.TrainingCourseModels.BirdTrainingProgress;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace TrainingCourseSubsystem
{
    public interface IFeatureStaff
    {
        //FE29	[Staff] confirm [Bird] registration to [Training Course] - confirming [Customer] has charged the amount of [Training Course]
        //Note: "confirming [Customer] has charged the amount of [Training Course]" UC is not relevant to system
        //=>
        //FE30[Staff] receive[Bird] from[Customer] - [Customer] must be at the center to send[Bird]
        //FE31[Staff] assign[Trainer] by[Slot] - to train the[Bird] for each[Skill] in [Training Course] - [Trainer] must have relevant[Skill] to train
        //FE34[Staff] confirm[Bird] completing the[Training Course] - by checking all the progression in each[Training Course Detail]
        //FE36[Staff] notify[Customer] - to receive[Bird] - [Customer] must be at the center to receive[Bird]

        Task<IEnumerable<BirdTrainingCourseModel>> GetBirdTrainingCourse();
        Task<IEnumerable<TrainingCourseSkillModel>> GetTrainingCourseSkill(int trainingCourseId);
        Task<IEnumerable<TrainerModel>> GetTrainerByBirdSkillId(int birdSkillId);
        Task AssignTrainer(AssignTrainerToCourse assignTrainer);
        Task InitStartTime(BirdTrainingCourseStartTime birdTrainingCourse);
        Task ReceiveBird(BirdTrainingCourseReceiveBird birdTrainingCourse);
        Task ReturnBird(BirdTrainingCourseReturnBird birdTrainingCourse);
        Task Update(BirdTrainingProgressModel birdTrainingProgress);
        Task<IEnumerable<BirdTrainingCourseModel>> GetBirdTrainingCourseByBirdId(int birdId);
        Task<IEnumerable<TrainerModel>> GetTrainer();
        Task<TrainerModel> GetTrainerById(int trainerId);
        Task<IEnumerable<TrainerModel>> GetTrainerByTrainerSkillId(int trainerSkillId);
    }
}