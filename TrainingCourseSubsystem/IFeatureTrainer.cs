using Microsoft.Win32;
using Models.ServiceModels.TrainingCourseModels.BirdTrainingProgress;
using Models.ServiceModels.TrainingCourseModels.BirdTrainingReport;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainingCourseSubsystem
{
    public interface IFeatureTrainer : IFeatureAll
    {
        //FE32	[Trainer] check assigned [Training Course]
        //=> Query [BirdTrainingProgress] with (TrainerId, IsComplete == false) and with each matched get data (SlotId, Progress, Comment) from [BirdTrainingDetail]
        //=> Return 
        //FE33[Trainer] submit progression to[Training Course Detail] - for each training[Slot]
        //=> 

        Task<IEnumerable<BirdTrainingProgressModel>> GetBirdTrainingProgressByTrainerId(int trainerId);
        Task MarkTrainingSkillDone(MarkSkillDone markDone);
        Task<int> MarkTrainingSlotDone(int birdTrainingReportId);
        Task<TimetableReportView> GetTimetableReportView(int trainerSlotId);
    }
}
