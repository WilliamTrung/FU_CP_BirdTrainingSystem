using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Enum.BirdTrainingCourse
{
    public enum Status
    {
        Registered = 0, //dang ki tren mobile
        AssignedTrainerToCourse = 1, //da tao lich cho trainer
        ReceivedBirdFromCustomer = 2, //start training
        TrainingDone = 3, //All skill progress complete
        ReturnedBirdToCustomer = 4, //tra chim khi da training xong
        Complete = 5 //da tra chim va thanh toan
    }
}
