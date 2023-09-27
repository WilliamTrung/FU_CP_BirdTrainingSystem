using AppRepository.Repository;
using AppRepository.Repository.Implement;
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
        public IBirdCaringPricePolicyRepository BirdCaringPricePolicyRepository { get; }
        public IBirdCertificateRepository BirdCertificateRepository { get; }
        public IBirdCertificateDetailRepository BirdCertificateDetailRepository { get; }
        public IBirdReceiveSheetRepository BirdReceiveSheetRepository { get; }
        public IBirdReturnSheetRepository BirdReturnSheetRepository { get; }
        public IBirdSkillRepository BirdSkillRepository { get; }
        public IBirdSpeciesRepository BirdSpeciesRepository { get; }
        public IBirdTrainingCourseRepository BirdTrainingCourseRepository { get; }
        public IBirdTrainingDetailRepository BirdTrainingDetailRepository { get; }
        public IBirdTrainingProgressRepository BirdTrainingProgressRepository { get; }
        public ICertificateRepository CertificateRepository { get; }
        public IConsultingPricePolicyRepository ConsultingPricePolicyRepository { get; }
        public IConsultingTicketRepository ConsultingTicketRepository { get; }
        public IConsultingTypeRepository ConsultingTypeRepository { get; }
        public ICustomerRepository CustomerRepository { get; }
        public ICustomerCertificateDetailRepository CustomerCertificateDetailRepository { get; }
        public ICustomerLessonDetailRepository CustomerLessonDetailRepository { get; }
        public ICustomerOnlineCourseDetailRepository CustomerOnlineCourseDetailRepository { get; }
        public ICustomerSectionDetailRepository CustomerSectionDetailRepository { get; }
        public ICustomerWorkshopClassRepository CustomerWorkshopClassRepository { get; }
        public IDayRepository DayRepository { get; }
        public IDistancePriceRepository DistancePriceRepository { get; }
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
        public ITrainingCourseRepository TrainingCourseRepository { get; }
        public ITrainingCourseBirdSkillRepository TrainingCourseBirdSkillRepository { get; }
        public IUserRepository UserRepository { get; }
        public IWeekRepository WeekRepository { get; }
        public IWorkshopRepository WorkshopRepository { get; }
        public IWorkshopAttendanceRepository WorkshopAttendanceRepository { get; }
        public  IWorkshopClassRepository WorkshopClassRepository { get; }
        public IWorkshopClassDetailRepository WorkshopClassDetailRepository { get; }
        public IWorkshopPricePolicyRepository WorkshopPricePolicyRepository { get; }
        public IWorkshopRefundPolicyRepository WorkshopRefundPolicyRepository { get; }
    }
}
