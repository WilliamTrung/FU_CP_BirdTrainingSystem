using AppRepository.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppRepository.UnitOfWork
{
    public interface IUnitOfWork
    {
        public IAppointmentRepository AppointmentRepository { get; }
        public IAppointmentBillRepository AppointmentBillRepository { get; }
        public IBirdRepository BirdRepository { get; }
        public IBirdCertificateRepository BirdCertificateRepository { get; }
        public IBirdCertificateDetailRepository BirdCertificateDetailRepository { get; }
        public IBirdSkillRepository BirdSkillRepository { get; }
        public IBirdSpeciesRepository BirdSpeciesRepository { get; }
        public IBirdTrainingCourseRepository BirdTrainingCourseRepository { get; }
        public IBirdTrainingProgressDetailRepository BirdTrainingProgressDetailRepository { get; }
        public ICertificateRepository CertificateRepository { get; }
        public IConsultingTicketRepository ConsultingTicketRepository { get; }
        public IConsultingTypeRepository ConsultingTypeRepository { get; }
        public ICustomerRepository CustomerRepository { get; }
        public ICustomerCertificateDetailRepository CustomerCertificateDetailRepository { get; }
        public ICustomerLessonDetailRepository CustomerLessonDetailRepository { get; }
        public ICustomerOnlineCourseDetailRepository CustomerOnlineCourseDetailRepository { get; }
        public ICustomerSectionDetailRepository CustomerSectionDetailRepository { get; }
        public ICustomerWorkshopPaymentRepository CustomerWorkshopPaymentRepository { get; }
        public IDayRepository DayRepository { get; }
        public IFeedbackRepository FeedbackRepository { get; }
        public IFeedbackTypeRepository FeedbackTypeRepository { get; }
        public ILessonRepository LessonRepository { get; }
        public IOnlineCourseRepository OnlineCourseRepository { get; }
        public IRoleRepository RoleRepository { get; }
        public ISectionRepository SectionRepository { get; }
        public ISkillRepository SkillRepository { get; }
        public ISlotRepository SlotRepository { get; }
        public IStaffBirdReceivedRepository StaffBirdReceivedRepository { get; }
        public ITrainerRepository TrainerRepository { get; }
        public ITrainerWorkshopRepository TrainerWorkshopRepository { get; }
        public ITrainingCourseRepository TrainingCourseRepository { get; }
        public ITrainingCourseBirdSkillRepository TrainingCourseBirdSkillRepository { get; }
        public IUserRepository UserRepository { get; }
        public IWeekRepository WeekRepository { get; }
        public IWorkshopRepository WorkshopRepository { get; }
        public IWorkshopAttendanceRepository WorkshopAttendanceRepository { get; }
        public IWorkShopCategoryRepository WorkShopCategoryRepository { get; }
    }
}
