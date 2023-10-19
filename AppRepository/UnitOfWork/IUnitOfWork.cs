using AppRepository.Repository;
using AppRepository.Repository.Implement;

namespace AppRepository.UnitOfWork
{
    public interface IUnitOfWork
    {
        
        public IAcquirableSkillRepository AcquirableSkillRepository { get; }
        public IAdditionalConsultingBillRepository AdditionalConsultingBillRepository { get; }
        public IAddressRepository AddressRepository { get; }
        public IBirdRepository BirdRepository { get; }
        public IBirdCertificateRepository BirdCertificateRepository { get; }
        public IBirdCertificateDetailRepository BirdCertificateDetailRepository { get; }
        public IBirdCertificateSkillRepository BirdCertificateSkillRepository { get; }
        public IBirdSkillRepository BirdSkillRepository { get; }
        public IBirdSpeciesRepository BirdSpeciesRepository { get; }
        public IBirdTrainingCourseRepository BirdTrainingCourseRepository { get; }
        public IBirdTrainingProgressRepository BirdTrainingProgressRepository { get; }
        public IBirdTrainingReportRepository BirdTrainingReportRepository { get; }
        public ICenterSlotRepository CenterSlotRepository { get; }
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
        public IDistancePriceRepository DistancePriceRepository { get; }
        public IFeedbackRepository FeedbackRepository { get; }
        public IFeedbackTypeRepository FeedbackTypeRepository { get; }
        public ILessonRepository LessonRepository { get; }
        public IMembershipRankRepository MembershipRankRepository { get; }
        public IOnlineCourseRepository OnlineCourseRepository { get; }
        public ISectionRepository SectionRepository { get; }
        public ISkillRepository SkillRepository { get; }
        public ISlotRepository SlotRepository { get; }
        public ITrainableSkillRepository TrainableSkillRepository { get; }
        public ITrainerRepository TrainerRepository { get; }
        public ITrainerSkillRepository TrainerSkillRepository { get; }
        public ITrainerSlotRepository TrainerSlotRepository { get; }
        public ITrainingCourseRepository TrainingCourseRepository { get; }
        public ITrainingCourseSkillRepository TrainingCourseSkillRepository { get; }
        public ITransactionRepository TransactionRepository { get; }
        public IUserRepository UserRepository { get; }
        public IWorkshopRepository WorkshopRepository { get; }
        public IWorkshopAttendanceRepository WorkshopAttendanceRepository { get; }
        public IWorkshopClassRepository WorkshopClassRepository { get; }
        public IWorkshopClassDetailRepository WorkshopClassDetailRepository { get; }
        public IWorkshopDetailTemplateRepository WorkshopDetailTemplateRepository { get; }
        public IWorkshopRefundPolicyRepository WorkshopRefundPolicyRepository { get; }
    }
}
