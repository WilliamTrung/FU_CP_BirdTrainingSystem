using Models.ServiceModels.TrainingCourseModels;
using Models.ServiceModels.TrainingCourseModels.BirdCertificate.BirdCertificateDetail;
using Models.ServiceModels.TrainingCourseModels.BirdTrainingCourse;
using Models.ServiceModels.TrainingCourseModels.BirdTrainingProgress;
using Models.ServiceModels.TrainingCourseModels.BirdTrainingReport;
using Models.ServiceModels.TrainingCourseModels.TrainerSlot;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace TrainingCourseSubsystem
{
    public interface IFeatureStaff : IFeatureAll
    {
        //FE29	[Staff] confirm [Bird] registration to [Training Course] - confirming [Customer] has charged the amount of [Training Course]
        //Note: "confirming [Customer] has charged the amount of [Training Course]" UC is not relevant to system
        //=>
        //FE30[Staff] receive[Bird] from[Customer] - [Customer] must be at the center to send[Bird]
        //FE31[Staff] assign[Trainer] by[Slot] - to train the[Bird] for each[Skill] in [Training Course] - [Trainer] must have relevant[Skill] to train
        //FE34[Staff] confirm[Bird] completing the[Training Course] - by checking all the progression in each[Training Course Detail]
        //FE36[Staff] notify[Customer] - to receive[Bird] - [Customer] must be at the center to receive[Bird]

        Task<IEnumerable<BirdTrainingCourseListView>> GetBirdTrainingCourse();
        Task<IEnumerable<BirdTrainingCourseListView>> GetBirdTrainingCourseByCustomerId(int customerId);
        Task<IEnumerable<BirdTrainingCourseListView>> GetBirdTrainingCourseByBirdId(int birdId);

        Task<IEnumerable<int>> ConfirmBirdTrainingCourse(int birdTrainingCourseId);//return list of progress
        Task<TrainerSlotModel> CreateTrainerSlot(TrainerSlotAddModel trainerSlotModel);//non api
        Task CreateTrainingReport(InitReportTrainerSlot report);//non api

        Task<IEnumerable<BirdTrainingProgressViewModel>> GetTrainingCourseSkill(int birdTrainingCourseId);
        Task<IEnumerable<ReportModifyViewModel>> GetReportByProgressId(int progressId);
        Task ModifyTrainingSlot(ReportModifyModel reportModModel);


        Task<IEnumerable<TrainerModel>> GetTrainer();
        Task<IEnumerable<TrainerModel>> GetTrainerByBirdSkillId(int birdSkillId);
        Task<IEnumerable<TrainerModel>> GetTrainerByTrainerSkillId(int trainerSkillId);
        Task<TrainerModel> GetTrainerById(int trainerId);


        Task<IEnumerable<BirdTrainingProgressModel>> GetBirdTrainingProgress();//non api
        Task ModifyActualStartTime(DateTime startDate, int birdTrainingCourseId);// non api

        Task ReceiveBird(BirdTrainingCourseReceiveBird birdTrainingCourse);
        Task ReturnBird(BirdTrainingCourseReturnBird birdTrainingCourse);
        //Task Update(BirdTrainingProgressModel birdTrainingProgress);

        Task CreateBirdCertificateDetail(BirdCertificateDetailAddModel birdCertificateDetailAdd);
    }
}