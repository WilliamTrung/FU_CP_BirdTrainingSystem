using Models.ServiceModels.TrainingCourseModels.Bird;
using Models.ServiceModels.TrainingCourseModels.BirdCertificate.BirdCertificateDetail;
using Models.ServiceModels.TrainingCourseModels.BirdTrainingCourse;
using Models.ServiceModels.TrainingCourseModels.BirdTrainingProgress;
using Models.ServiceModels.TrainingCourseModels.BirdTrainingReport;
using Models.ServiceModels.TrainingCourseModels.TrainingCourse;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace TrainingCourseSubsystem;
//FE28[Customer] view[Training Course Detail] - of the in-training[Bird] - to check progression
public interface IFeatureCustomer : IFeatureAll
{
    Task RegisterBird(BirdAddModel bird);
    Task UpdateBirdProfile(BirdModifyModel bird);
    Task<IEnumerable<BirdViewModel>> GetBirdByCustomerId(int customerId);
    Task<IEnumerable<TrainingCourseViewModel>> GetTrainingCourse();
    Task<IEnumerable<TrainingCourseViewModel>> GetTrainingCourseBySpeciesId(int birdSpeciesId);
    Task<IEnumerable<TrainingCourseViewModel>> GetTrainingCourseByBirdSkillId(int birdSkillId);
    Task<IEnumerable<TrainingCourseViewModel>> GetTrainingCourseBySpeciesIdBirdSkillId(int birdSpeciesId, int birdSkillId);
    Task<TrainingCourseViewModel> GetTrainingCourseById(int trainingCourseId);
    Task RegisterTrainingCourse(BirdTrainingCourseRegister birdTrainingCourseRegister);
    Task<IEnumerable<BirdTrainingCourseViewModel>> ViewRegisteredTrainingCourse(int birdId, int customerId);
    Task<IEnumerable<BirdTrainingProgressViewModel>> ViewBirdTrainingCourseProgress(int birdTrainingCourseId);
    Task<IEnumerable<BirdTrainingReportViewModel>> ViewBirdTrainingCourseReport(int birdTrainingProgressId);
    Task<BirdCertificateDetailViewModel> ViewCertificateByBirdTrainingCourseId(int birdTrainingCourseId);
    Task<IEnumerable<BirdCertificateDetailViewModel>> ViewCertificateByBirdCertificateId(int birdId);
}