using Models.ServiceModels.TrainingCourseModels.BirdTrainingCourse;
using Models.ServiceModels.TrainingCourseModels.BirdTrainingProgress;
using Models.ServiceModels.TrainingCourseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.ServiceModels.TrainingCourseModels.BirdTrainingReport;

namespace AppService.TrainingCourseService
{
    public interface IServiceStaff
    {
        Task<IEnumerable<BirdTrainingCourseModel>> GetBirdTrainingCourse(); //xem tat ca request
        Task<IEnumerable<TrainingCourseSkillModel>> GetTrainingCourseSkill(int trainingCourseId); //lay danh sach ki nang theo course
        Task<IEnumerable<TrainerModel>> GetTrainerByBirdSkillId(int birdSkillId); //lay danh sach trainer theo ki nang Bird
        Task AssignTrainer(AssignTrainerToCourse assignTrainer); //gan trainer vao ki nang can train
        Task GenerateTrainerTimetable(InitReportTrainerSlot report);//gan lich
        Task InitStartTime(BirdTrainingCourseStartTime birdTrainingCourse); //set lich training
        Task ConfirmTrainerSlot(TrainerSlotModel trainerSlotModel);
        Task ModifyActualStartTime(DateTime startDate, int birdTrainingCourseId);
        Task ModifyTrainerSlot(ModifyTrainerSlot trainerSlot);
        Task ReceiveBird(BirdTrainingCourseReceiveBird birdTrainingCourse); //nhan chim => chim is not ready => ko the set lich moi
        Task ReturnBird(BirdTrainingCourseReturnBird birdTrainingCourse); //tra chim => chim ready => co the set lich moi neu muon
        Task<IEnumerable<BirdTrainingCourseModel>> GetBirdTrainingCourseByBirdId(int birdId); //xem request theo chim
        Task<IEnumerable<TrainerModel>> GetTrainer();//lay tat ca trainer
        Task<TrainerModel> GetTrainerById(int trainerId);//lay trainer theo id
        Task<IEnumerable<TrainerModel>> GetTrainerByTrainerSkillId(int trainerSkillId);//lay danh sach trainer theo ki nang Trainer
    }
}
