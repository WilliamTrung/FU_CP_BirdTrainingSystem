using ApplicationService.MailSettings;
using Models.Enum.BirdTrainingProgress;
using Models.ServiceModels.TrainingCourseModels;
using Models.ServiceModels.TrainingCourseModels.Bird;
using Models.ServiceModels.TrainingCourseModels.BirdCertificate;
using Models.ServiceModels.TrainingCourseModels.BirdCertificate.BirdCertificateDetail;
using Models.ServiceModels.TrainingCourseModels.BirdSkill;
using Models.ServiceModels.TrainingCourseModels.BirdTrainingCourse;
using Models.ServiceModels.TrainingCourseModels.BirdTrainingProgress;
using Models.ServiceModels.TrainingCourseModels.BirdTrainingReport;
using Models.ServiceModels.TrainingCourseModels.TrainerSkill;
using Models.ServiceModels.TrainingCourseModels.TrainingCourse;
using Models.ServiceModels.TrainingCourseModels.TrainingCourseCheckOutPolicy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimetableSubsystem;
using TrainingCourseSubsystem;
using TransactionSubsystem;

namespace AppService.TrainingCourseService.Implement
{
    public class ServiceAll : IServiceAll
    {
        internal readonly ITrainingCourseFeature _trainingCourse;
        internal readonly ITimetableFeature _timetable;
        internal readonly IMailService _mail;
        public ServiceAll(ITrainingCourseFeature trainingCourse, ITimetableFeature timetable, IMailService mail)
        {
            _timetable = timetable;
            _trainingCourse = trainingCourse;
            _mail = mail;
        }
        public async Task<IEnumerable<BirdTrainingCourseListView>> GetBirdTrainingCourse()
        {
            return await _trainingCourse.All.GetBirdTrainingCourse();
        }

        public Task<IEnumerable<BirdTrainingCourseListView>> GetBirdTrainingCourseByCustomerId(int customerId)
        {
            return _trainingCourse.All.GetBirdTrainingCourseByCustomerId(customerId);
        }

        public async Task<IEnumerable<BirdTrainingCourseListView>> GetBirdTrainingCourseByBirdId(int birdId)
        {
            return await _trainingCourse.All.GetBirdTrainingCourseByBirdId(birdId);
        }
        public async Task<IEnumerable<BirdTrainingProgressViewModel>> GetTrainingCourseSkill(int trainingCourseId)
        {
            return await _trainingCourse.All.GetTrainingCourseSkill(trainingCourseId);
        }

        public async Task<IEnumerable<ReportModifyViewModel>> GetReportByProgressId(int progressId)
        {
            return await _trainingCourse.All.GetReportByProgressId(progressId);
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

        public Task<IEnumerable<TrainingCourseManagementViewModel>> GetTrainingCourses()
        {
            return _trainingCourse.All.GetTrainingCourses();
        }

        public Task<TrainingCourseManagementViewModel> GetTrainingCoursesById(int courseId)
        {
            return _trainingCourse.All.GetTrainingCoursesById(courseId);
        }

        public async Task<IEnumerable<BirdSkillReceivedViewModel>> ViewBirdSkillReceived(int birdId)
        {
            return await _trainingCourse.All.ViewBirdSkillReceived(birdId);
        }

        public async Task<IEnumerable<TrainerModel>> GetTrainerByBirdSkillId(int birdSkillId)
        {
            return await _trainingCourse.All.GetTrainerByBirdSkillId(birdSkillId);
        }

        public async Task<IEnumerable<TrainerModel>> GetTrainer()
        {
            return await _trainingCourse.All.GetTrainer();
        }

        public async Task<TrainerModel> GetTrainerById(int trainerId)
        {
            return await _trainingCourse.All.GetTrainerById(trainerId);
        }

        public async Task<IEnumerable<TrainerModel>> GetTrainerByTrainerSkillId(int trainerSkillId)
        {
            return await _trainingCourse.All.GetTrainerByTrainerSkillId(trainerSkillId);
        }

        public async Task<IEnumerable<BirdSkillReceivedViewModel>> GetBirdSkillReceivedByBirdId(int birdId)
        {
            return await _trainingCourse.All.GetBirdSkillReceivedByBirdId(birdId);
        }
        public async Task<IEnumerable<CustomerModel>> GetCustomerModels()
        {
            return await _trainingCourse.All.GetCustomerModels();
        }

        public async Task<IEnumerable<TrainingCourseCheckOutPolicyModel>> GetTrainingCoursePricePolicies()
        {
            return await _trainingCourse.All.GetTrainingCoursePricePolicies();
        }

        public async Task SendNotiSendBirdToCenter(BirdTrainingCourseListView course)
        {
            if (course != null)
            {
                if (course.Status == Models.Enum.BirdTrainingCourse.Status.Confirmed)
                {
                    MailContent mailContent = new MailContent()
                    {
                        Subject = "Your registered course for bird have been confirm",
                        //    HtmlMessage = $"Dear Mr /Mrs.{course.CustomerName},\r\n" +
                        //$"Your request register at {course.RegisteredDate} Training course: {course.TrainingCourseTitle} for Bird: {course.BirdName} have been confirmed.\n" +
                        //$"Please take your bird to center before {course.StartTrainingDate} to start training at the center.\r\n" +
                        //$"Thanks and regards,\n" +
                        //$"BIRD TRAINING CENTER AV Buddy."
                        HtmlMessage = $"<p>Dear Mr/Mrs.{course.CustomerName},</p>\r\n" +
                        $"\r\n<p>Your request registered on {course.RegisteredDate} for the Training Course: {course.TrainingCourseTitle} for Bird: {course.BirdName} has been confirmed.</p>\r\n" +
                        $"\r\n<p>Please take your bird to the center before {course.StartTrainingDate} to start training at the center.</p>\r\n" +
                        $"\r\n<p>Thanks and regards,</p>" +
                        $"\r\n<p>BIRD TRAINING CENTER AV Buddy.</p>"
                    };
                    await _mail.SendEmailAsync(course.CustomerEmail, mailContent);
                }
            }
            else
            {
                throw new KeyNotFoundException("BirdTrainingCourse not found");
            }
        }

        public async Task SendNotiReceiveBirdFromCenter(BirdTrainingCourseListView course)
        {
            if (course != null)
            {
                if (course.Status == Models.Enum.BirdTrainingCourse.Status.TrainingDone)
                {
                    MailContent mailContent = new MailContent()
                    {
                        Subject = "Your training course for bird have done",
                        //HtmlMessage = $"Dear Mr /Mrs.{course.CustomerName},\r\n" +
                        //$"Your request register at {course.RegisteredDate} Training course: {course.TrainingCourseTitle} for Bird: {course.BirdName} have done at {course.TrainingDoneDate}.\n" +
                        //$"Please go to center to receive bird and check out.\r\n" +
                        //$"Thanks and regards,\n" +
                        //$"BIRD TRAINING CENTER AV Buddy"
                        HtmlMessage = $"<p>Dear Mr/Mrs.{course.CustomerName},</p>\r\n" +
                    $"\r\n<p>Your request registered on {course.RegisteredDate} for the Training Course: {course.TrainingCourseTitle} for Bird: {course.BirdName} has been completed on {course.TrainingDoneDate}.</p>\r\n" +
                    $"\r\n<p>Please go to the center to receive the bird and complete the check-out process.</p>\r\n" +
                    $"\r\n<p>Thanks and regards,</p>\r\n" +
                    $"<p>BIRD TRAINING CENTER AV Buddy</p>"
                    };
                    await _mail.SendEmailAsync(course.CustomerEmail, mailContent);
                }
            }
            else
            {
                throw new KeyNotFoundException("BirdTrainingCourse not found");
            }
        }
    }
}
