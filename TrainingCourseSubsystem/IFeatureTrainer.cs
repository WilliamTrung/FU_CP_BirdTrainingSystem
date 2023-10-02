using Models.ServiceModels.TrainingCourseModels;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace TrainingCourseSubsystem
{
    public interface IFeatureTrainer
    {
        //FE32	[Trainer] check assigned [Training Course]
        //=> Query [BirdTrainingProgress] with (TrainerId, IsComplete == false) and with each matched get data (SlotId, Progress, Comment) from [BirdTrainingDetail]
        //=> Return 
        //FE33[Trainer] submit progression to[Training Course Detail] - for each training[Slot]
        //=> 

        Task<IEnumerable<BirdTrainingProgress>> GetBirdTrainingProgressByTrainerId(int trainerId);
    }
}
