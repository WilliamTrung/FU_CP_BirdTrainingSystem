using Models.ServiceModels.TrainingCourseModels.Bird;
using Models.ServiceModels.TrainingCourseModels.BirdCertificate.BirdCertificateDetail;
using Models.ServiceModels.TrainingCourseModels.BirdCertificate;
using Models.ServiceModels.TrainingCourseModels.TrainingCourse;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.ServiceModels.TrainingCourseModels.BirdSkill;
using Models.ServiceModels.TrainingCourseModels.TrainerSkill;

namespace AppService.TrainingCourseService
{
    public interface IServiceAll
    {
        Task<IEnumerable<BirdSpeciesViewModel>> GetBirdSpecies();
        Task<BirdSpeciesViewModel> GetBirdSpeciesById(int birdSpeciesId);
        Task<IEnumerable<TrainingCourseViewModel>> GetTrainingCourses();
        Task<TrainingCourseViewModel> GetTrainingCoursesById(int courseId);
        //Task<IEnumerable<TrainingSkillViewModel>> GetTrainingSkillByCourseId(int courseId);
        IEnumerable<Models.Enum.BirdTrainingProgress.Status> GetEnumBirdTrainingProgressStatuses();

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
    }
}
