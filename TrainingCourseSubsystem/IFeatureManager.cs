using Models.ServiceModels.TrainingCourseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainingCourseSubsystem
{
    public interface IFeatureManager
    {
        //FE37	[Manager] manage [Training Course] - view, create, edit, archive [Training Course]
        //Can create new training course
        //Can edit training course
        //Can archive training course
        Task CreateCourse(TrainingCourse trainingCourse);
        Task EditCourse(TrainingCourse trainingCourse);
        Task ArchiveCourse(TrainingCourse trainingCourse);
    }
}
