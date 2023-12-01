using Models.ServiceModels.TrainingCourseModels;
using Models.ServiceModels.TrainingCourseModels.Bird;
using Models.ServiceModels.TrainingCourseModels.BirdCertificate;
using Models.ServiceModels.TrainingCourseModels.BirdCertificate.BirdCertificateDetail;
using Models.ServiceModels.TrainingCourseModels.BirdSkill;
using Models.ServiceModels.TrainingCourseModels.TrainerSkill;
using Models.ServiceModels.TrainingCourseModels.TrainingCourse;
using Models.ServiceModels.TrainingCourseModels.TrainingCourseCheckOutPolicy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainingCourseSubsystem
{
    public interface IFeatureAll
    {
        Task<IEnumerable<BirdSpeciesViewModel>> GetBirdSpecies();
        Task<BirdSpeciesViewModel> GetBirdSpeciesById(int birdSpeciesId);
        Task<IEnumerable<TrainingCourseManagementViewModel>> GetTrainingCourses();
        Task<TrainingCourseManagementViewModel> GetTrainingCoursesById(int courseId);
        //Task<IEnumerable<TrainingSkillViewModel>> GetTrainingSkillByCourseId(int courseId);
        IEnumerable<Models.Enum.BirdTrainingProgress.Status> GetEnumBirdTrainingProgressStatuses();
        Task<IEnumerable<BirdCertificateViewModel>> GetBirdCertificates();
        Task CreateBirdSkillReceived(BirdSkillReceivedAddDeleteModel addDeleteModel);
        Task DeleteBirdSkillReceived(BirdSkillReceivedAddDeleteModel addDeleteModel);
        Task<IEnumerable<BirdCertificateDetailViewModel>> GetBirdCertificatesDetail();
        Task<IEnumerable<BirdCertificateDetailViewModel>> GetBirdCertificatesDetailByBirdId(int birdId);
        Task<IEnumerable<BirdSkillReceivedViewModel>> GetBirdSkillReceiveds();
        Task<IEnumerable<BirdSkillReceivedViewModel>> GetBirdSkillReceivedsByBirdId(int birdId);
        Task<IEnumerable<AcquirableSkillViewModel>> GetAccquirableBirdSkill();
        Task<IEnumerable<AcquirableSkillViewModel>> GetAccquirableBirdSkillByBirdSpeciesId(int birdSpeciesId);
        Task<IEnumerable<TrainerSkillViewModel>> GetTrainerSkills();
        Task<IEnumerable<TrainerSkillViewModel>> GetTrainerSkillsByTrainerId(int trainerId);
        Task<IEnumerable<TrainableViewSkillModel>> GetTrainableSkills();
        Task<IEnumerable<BirdSkillViewModel>> GetBirdSkills();
        Task<BirdSkillViewModel> GetBirdSkillsById(int birdSkillId);
        Task<IEnumerable<SkillViewModModel>> GetSkills();
        Task<SkillViewModModel> GetSkillById(int skillId);
        Task<IEnumerable<BirdSkillReceivedViewModel>> ViewBirdSkillReceived(int birdId);

        Task<IEnumerable<TrainerModel>> GetTrainer();
        Task<IEnumerable<TrainerModel>> GetTrainerByBirdSkillId(int birdSkillId);
        Task<IEnumerable<TrainerModel>> GetTrainerByTrainerSkillId(int trainerSkillId);
        Task<TrainerModel> GetTrainerById(int trainerId);

        Task<IEnumerable<BirdSkillReceivedViewModel>> GetBirdSkillReceivedByBirdId(int birdId);
        Task<IEnumerable<CustomerModel>> GetCustomerModels();
        Task<IEnumerable<TrainingCourseCheckOutPolicyModel>> GetTrainingCoursePricePolicies();
    }
}
