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
        Confirmed = 1, //da tao lich cho trainer, UI pending receive bird
        CheckIn = 2, //start training
        Training = 3,
        TrainingDone = 4, //All skill progress complete, UI pending return bird
        //CheckOut = 5, //tra chim khi da training xong
        Complete = 5 //da tra chim va thanh toan
    }
}