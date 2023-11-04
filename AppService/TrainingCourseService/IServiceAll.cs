﻿using Models.ServiceModels.TrainingCourseModels.Bird;
using Models.ServiceModels.TrainingCourseModels.TrainingCourse;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppService.TrainingCourseService
{
    public interface IServiceAll
    {
        Task<IEnumerable<BirdSpeciesViewModel>> GetBirdSpecies();
        Task<BirdSpeciesViewModel> GetBirdSpeciesById(int birdSpeciesId);
        Task<IEnumerable<TrainingCourseViewModel>> GetTrainingCourses();
        Task<TrainingCourseViewModel> GetTrainingCoursesById(int courseId);
        //Task<IEnumerable<TrainingSkillViewModel>> GetTrainingSkillByCourseId(int courseId);
        IEnumerable<Models.Enum.BirdTrainingProgress.Status> GetEnumBirdTrainingProgressStatuses();
    }
}