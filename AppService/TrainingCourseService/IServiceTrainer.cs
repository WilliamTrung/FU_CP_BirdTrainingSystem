using Models.ServiceModels.TrainingCourseModels.BirdTrainingProgress;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppService.TrainingCourseService
{
    public interface IServiceTrainer
    {
        Task<IEnumerable<BirdTrainingProgressModel>> GetBirdTrainingProgressByTrainerId(int trainerId);
        Task MarkTrainingSkillDone(MarkSkillDone markDone);
    }
}
