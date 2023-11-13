using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Enum.BirdTrainingCourse
{
    public enum Status
    {
        Complete = 0, //da tra chim va thanh toan
        Cancel = 1,
        Registered = 2, //dang ki tren mobile
        Confirmed = 3, //da tao lich cho trainer, UI pending receive bird
        CheckIn = 4, //start training
        Training = 5,
        TrainingDone = 6, //All skill progress complete, UI pending return bird
        //CheckOut = 5, //tra chim khi da training xong
    }
}