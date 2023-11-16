using Models.ServiceModels.TrainingCourseModels.BirdTrainingCourse;
using Models.ServiceModels.TrainingCourseModels.BirdTrainingProgress;
using Models.ServiceModels.TrainingCourseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.ServiceModels.TrainingCourseModels.BirdTrainingReport;
using Models.ServiceModels.TrainingCourseModels.TrainerSlot;
using Models.ServiceModels.SlotModels;
using Models.ApiParamModels.TrainingCourse;
using Models.ServiceModels.TrainingCourseModels.BirdCertificate.BirdCertificateDetail;

namespace AppService.TrainingCourseService
{
    public interface IServiceStaff : IServiceAll
    {
        //Task<IEnumerable<BirdTrainingCourseModel>> GetBirdTrainingCourse(); //xem tat ca request
        //Task<IEnumerable<BirdTrainingProgressViewModel>> GetTrainingCourseSkill(int birdTrainingCourseId); //lay danh sach ki nang theo course
        //Task<IEnumerable<TrainerModel>> GetTrainerByBirdSkillId(int birdSkillId); //lay danh sach trainer theo ki nang Bird
        //Task AssignTrainer(AssignTrainerToCourse assignTrainer); //gan trainer vao ki nang can train
        //Task GenerateTrainerTimetable(IEnumerable<int> progressId);//gan lich
        //Task<IEnumerable<BirdTrainingProgressModel>> GetBirdTrainingProgress();
        //Task InitStartTime(BirdTrainingCourseStartTime birdTrainingCourse); //set lich training
        //Task<TrainerSlotModel> CreateTrainerSlot(TrainerSlotModel trainerSlotModel);
        //Task ModifyActualStartTime(DateTime startDate, int birdTrainingCourseId);
        //Task ModifyTrainerSlot(ModifyTrainerSlot trainerSlot);
        //Task ReceiveBird(BirdTrainingCourseReceiveBird birdTrainingCourse); //nhan chim => chim is not ready => ko the set lich moi
        //Task ReturnBird(BirdTrainingCourseReturnBird birdTrainingCourse); //tra chim => chim ready => co the set lich moi neu muon
        //Task<IEnumerable<BirdTrainingCourseModel>> GetBirdTrainingCourseByBirdId(int birdId); //xem request theo chim
        //Task ConfirmBirdTrainingCourse(int birdTrainingCourseId);
        //Task<IEnumerable<BirdTrainingCourseListView>> GetBirdTrainingCourseByCustomerId(int customerId);
        //Task<IEnumerable<TrainerModel>> GetTrainer();//lay tat ca trainer
        //Task<TrainerModel> GetTrainerById(int trainerId);//lay trainer theo id
        //Task<IEnumerable<TrainerModel>> GetTrainerByTrainerSkillId(int trainerSkillId);//lay danh sach trainer theo ki nang Trainer

        Task<IEnumerable<BirdTrainingCourseListView>> GetBirdTrainingCourse();
        Task<IEnumerable<BirdTrainingCourseListView>> GetBirdTrainingCourseByCustomerId(int customerId);
        Task<IEnumerable<BirdTrainingCourseListView>> GetBirdTrainingCourseByBirdId(int birdId);

        Task<IEnumerable<int>> ConfirmBirdTrainingCourse(int birdTrainingCourseId);//return list of progress
        //Task<TrainerSlotModel> CreateTrainerSlot(TrainerSlotAddModel trainerSlotModel);//non api
        //Task CreateTrainingReport(InitReportTrainerSlot report);//non api
        Task CancelBirdTrainingCourse(int birdTrainingCourseId);
        Task<IEnumerable<BirdTrainingProgressViewModel>> GetTrainingCourseSkill(int birdTrainingCourseId);
        Task<IEnumerable<ReportModifyViewModel>> GetReportByProgressId(int progressId);
        Task<BirdTrainingProgressModel> AssignTrainer(int progressId, int trainerId);
        Task ModifyTrainingSlot(ReportModifyModel reportModModel);


        Task<IEnumerable<TrainerModel>> GetTrainer();
        Task<IEnumerable<TrainerModel>> GetTrainerByBirdSkillId(int birdSkillId);
        Task<IEnumerable<TrainerModel>> GetTrainerByTrainerSkillId(int trainerSkillId);
        Task<TrainerModel> GetTrainerById(int trainerId);


        //Task<IEnumerable<BirdTrainingProgressModel>> GetBirdTrainingProgress();//non api
        //Task ModifyActualStartTime(DateTime startDate, int birdTrainingCourseId);// non api

        Task ReceiveBird(BirdTrainingCourseReceiveBird birdTrainingCourse);
        Task ReturnBird(BirdTrainingCourseReturnBird birdTrainingCourse);
        Task CreateBirdCertificateDetail(BirdCertificateDetailAddModel birdCertificateDetailAdd);

        Task GenerateTrainerTimetable(IEnumerable<int> progressId);
    }
}
