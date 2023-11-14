using Models.Enum.BirdTrainingProgress;
using Models.ServiceModels.TrainingCourseModels.Bird;
using Models.ServiceModels.TrainingCourseModels.BirdCertificate;
using Models.ServiceModels.TrainingCourseModels.BirdCertificate.BirdCertificateDetail;
using Models.ServiceModels.TrainingCourseModels.BirdSkill;
using Models.ServiceModels.TrainingCourseModels.TrainerSkill;
using Models.ServiceModels.TrainingCourseModels.TrainingCourse;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimetableSubsystem;
using TrainingCourseSubsystem;

namespace AppService.TrainingCourseService.Implement
{
    public class ServiceAll : IServiceAll
    {
        internal readonly ITrainingCourseFeature _trainingCourse;
        internal readonly ITimetableFeature _timetable;
        public ServiceAll(ITrainingCourseFeature trainingCourse, ITimetableFeature timetable)
        {
            _timetable = timetable;
            _trainingCourse = trainingCourse;
        }

        public async Task CreateBirdSkillReceived(BirdSkillReceivedAddDeleteModel addDeleteModel)
        {
            await _trainingCourse.All.CreateBirdSkillReceived(addDeleteModel);
        }

        public async Task DeleteBirdSkillReceived(BirdSkillReceivedAddDeleteModel addDeleteModel)
        {
            await _trainingCourse.All.DeleteBirdSkillReceived(addDeleteModel);
        }

        public async Task<IEnumerable<AcquirableSkillViewModel>> GetAccquirableBirdSkill()
        {
            return await _trainingCourse.All.GetAccquirableBirdSkill();
        }

        public async Task<IEnumerable<AcquirableSkillViewModel>> GetAccquirableBirdSkillByBirdSpeciesId(int birdSpeciesId)
        {
            return await _trainingCourse.All.GetAccquirableBirdSkillByBirdSpeciesId(birdSpeciesId);
        }

        public async Task<IEnumerable<BirdCertificateDetailViewModel>> GetBirdCertificatesDetail()
        {
            return await _trainingCourse.All.GetBirdCertificatesDetail();
        }

        public async Task<IEnumerable<BirdCertificateDetailViewModel>> GetBirdCertificatesDetailByBirdId(int birdId)
        {
            return await _trainingCourse.All.GetBirdCertificatesDetailByBirdId(birdId);
        }

        public async Task<IEnumerable<BirdSkillReceivedViewModel>> GetBirdSkillReceiveds()
        {
            return await _trainingCourse.All.GetBirdSkillReceiveds();
        }

        public async Task<IEnumerable<BirdSkillReceivedViewModel>> GetBirdSkillReceivedsByBirdId(int birdId)
        {
            return await _trainingCourse.All.GetBirdSkillReceivedsByBirdId(birdId);
        }

        public async Task<IEnumerable<BirdSkillViewModel>> GetBirdSkills()
        {
            return await _trainingCourse.All.GetBirdSkills();
        }

        public async Task<BirdSkillViewModel> GetBirdSkillsById(int birdSkillId)
        {
            return await _trainingCourse.All.GetBirdSkillsById(birdSkillId);
        }

        public async Task<IEnumerable<BirdSpeciesViewModel>> GetBirdSpecies()
        {
            return await _trainingCourse.All.GetBirdSpecies();
        }

        public async Task<BirdSpeciesViewModel> GetBirdSpeciesById(int birdSpeciesId)
        {
            return await _trainingCourse.All.GetBirdSpeciesById(birdSpeciesId);
        }

        public IEnumerable<Status> GetEnumBirdTrainingProgressStatuses()
        {
            return _trainingCourse.Staff.GetEnumBirdTrainingProgressStatuses();
        }

        public async Task<SkillViewModModel> GetSkillById(int skillId)
        {
            return await _trainingCourse.All.GetSkillById(skillId);
        }

        public async Task<IEnumerable<SkillViewModModel>> GetSkills()
        {
            return await _trainingCourse.All.GetSkills();
        }

        public async Task<IEnumerable<TrainableViewSkillModel>> GetTrainableSkills()
        {
            return await _trainingCourse.All.GetTrainableSkills();
        }

        public async Task<IEnumerable<TrainerSkillViewModel>> GetTrainerSkills()
        {
            return await _trainingCourse.All.GetTrainerSkills();
        }

        public async Task<IEnumerable<TrainerSkillViewModel>> GetTrainerSkillsByTrainerId(int trainerId)
        {
            return await _trainingCourse.All.GetTrainerSkillsByTrainerId(trainerId);
        }

        public Task<IEnumerable<TrainingCourseViewModel>> GetTrainingCourses()
        {
            return _trainingCourse.All.GetTrainingCourses();
        }

        public Task<TrainingCourseViewModel> GetTrainingCoursesById(int courseId)
        {
            return _trainingCourse.All.GetTrainingCoursesById(courseId);
        }
    }
}
