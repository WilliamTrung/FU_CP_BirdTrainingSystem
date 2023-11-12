using Models.ServiceModels.TrainingCourseModels.Bird;
using Models.ServiceModels.TrainingCourseModels.BirdCertificate;
using Models.ServiceModels.TrainingCourseModels.BirdCertificate.BirdCertificateDetail;
using Models.ServiceModels.TrainingCourseModels.TrainingCourse;
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
        Task<IEnumerable<TrainingCourseViewModel>> GetTrainingCourses();
        Task<TrainingCourseViewModel> GetTrainingCoursesById(int courseId);
        //Task<IEnumerable<TrainingSkillViewModel>> GetTrainingSkillByCourseId(int courseId);
        IEnumerable<Models.Enum.BirdTrainingProgress.Status> GetEnumBirdTrainingProgressStatuses();
        Task<IEnumerable<BirdCertificateViewModel>> GetBirdCertificates();
        Task CreateBirdSkillReceived(BirdSkillReceivedAddDeleteModel addDeleteModel);
        Task DeleteBirdSkillReceived(BirdSkillReceivedAddDeleteModel addDeleteModel);
        Task<IEnumerable<BirdCertificateDetailViewModel>> GetBirdCertificatesDetail();
        Task<IEnumerable<BirdCertificateDetailViewModel>> GetBirdCertificatesDetailByBirdId(int birdId);
    }
}
