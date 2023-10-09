using AppRepository.Repository;
using AppRepository.Repository.Implement;
using Models.Entities;

namespace AppRepository.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly BirdTrainingCenterSystemContext _context;

        public UnitOfWork(BirdTrainingCenterSystemContext context)
        {
            _context = context;
            InitRepositories();
        }

        public IAcquirableSkillRepository AcquirableSkillRepository { get; private set; } = null!;

        public IAdditionalConsultingBillRepository AdditionalConsultingBillRepository { get; private set; } = null!;

        public IAddressRepository AddressRepository { get; private set; } = null!;

        public IBirdRepository BirdRepository { get; private set; } = null!;

        public IBirdCertificateRepository BirdCertificateRepository { get; private set; } = null!;

        public IBirdCertificateDetailRepository BirdCertificateDetailRepository { get; private set; } = null!;

        public IBirdCertificateSkillRepository BirdCertificateSkillRepository { get; private set; } = null!;

        public IBirdSkillRepository BirdSkillRepository { get; private set; } = null!;

        public IBirdSpeciesRepository BirdSpeciesRepository { get; private set; } = null!;

        public IBirdTrainingCourseRepository BirdTrainingCourseRepository { get; private set; } = null!;

        public IBirdTrainingProgressRepository BirdTrainingProgressRepository { get; private set; } = null!;

        public IBirdTrainingReportRepository BirdTrainingReportRepository { get; private set; } = null!;

        public ICenterSlotRepository CenterSlotRepository { get; private set; } = null!;

        public ICertificateRepository CertificateRepository { get; private set; } = null!;

        public IConsultingPricePolicyRepository ConsultingPricePolicyRepository { get; private set; } = null!;

        public IConsultingTicketRepository ConsultingTicketRepository { get; private set; } = null!;

        public IConsultingTypeRepository ConsultingTypeRepository { get; private set; } = null!;

        public ICustomerRepository CustomerRepository { get; private set; } = null!;

        public ICustomerCertificateDetailRepository CustomerCertificateDetailRepository { get; private set; } = null!;

        public ICustomerLessonDetailRepository CustomerLessonDetailRepository { get; private set; } = null!;

        public ICustomerOnlineCourseDetailRepository CustomerOnlineCourseDetailRepository { get; private set; } = null!;

        public ICustomerSectionDetailRepository CustomerSectionDetailRepository { get; private set; } = null!;

        public ICustomerWorkshopClassRepository CustomerWorkshopClassRepository { get; private set; } = null!;

        public IDistancePriceRepository DistancePriceRepository { get; private set; } = null!;

        public IFeedbackRepository FeedbackRepository { get; private set; } = null!;

        public IFeedbackTypeRepository FeedbackTypeRepository { get; private set; } = null!;

        public ILessonRepository LessonRepository { get; private set; } = null!;
        public IMembershipRankRepository MembershipRankRepository { get; private set; } = null!;

        public IOnlineCourseRepository OnlineCourseRepository { get; private set; } = null!;

        public ISectionRepository SectionRepository { get; private set; } = null!;

        public ISkillRepository SkillRepository { get; private set; } = null!;

        public ISlotRepository SlotRepository { get; private set; } = null!;

        public ITrainableSkillRepository TrainableSkillRepository { get; private set; } = null!;

        public ITrainerRepository TrainerRepository { get; private set; } = null!;

        public ITrainerSkillRepository TrainerSkillRepository { get; private set; } = null!;

        public ITrainerSlotRepository TrainerSlotRepository { get; private set; } = null!;

        public ITrainingCourseRepository TrainingCourseRepository { get; private set; } = null!;

        public ITrainingCourseSkillRepository TrainingCourseSkillRepository { get; private set; } = null!;

        public ITransactionRepository TransactionRepository { get; private set; } = null!;

        public IUserRepository UserRepository { get; private set; } = null!;

        public IWorkshopRepository WorkshopRepository { get; private set; } = null!;

        public IWorkshopAttendanceRepository WorkshopAttendanceRepository { get; private set; } = null!;

        public IWorkshopClassRepository WorkshopClassRepository { get; private set; } = null!;

        public IWorkshopClassDetailRepository WorkshopClassDetailRepository { get; private set; } = null!;

        public IWorkshopRefundPolicyRepository WorkshopRefundPolicyRepository { get; private set; } = null!;

        private void InitRepositories()
        {
            AcquirableSkillRepository = new AcquirableSkillRepository(_context, this);
            AdditionalConsultingBillRepository = new AdditionalConsultingBillRepository(_context, this);
            AddressRepository = new AddressRepository(_context, this);
            BirdRepository = new BirdRepository(_context, this);
            BirdCertificateRepository = new BirdCertificateRepository(_context, this);
            BirdCertificateDetailRepository = new BirdCertificateDetailRepository(_context, this);
            BirdCertificateSkillRepository = new BirdCertificateSkillRepository(_context, this);
            BirdSkillRepository = new BirdSkillRepository(_context, this);
            BirdSpeciesRepository = new BirdSpeciesRepository(_context, this);
            BirdTrainingCourseRepository = new BirdTrainingCourseRepository(_context, this);
            BirdTrainingProgressRepository = new BirdTrainingProgressRepository(_context, this);
            BirdTrainingReportRepository = new BirdTrainingReportRepository(_context, this);
            CenterSlotRepository = new CenterSlotRepository(_context, this);
            CertificateRepository = new CertificateRepository(_context, this);
            ConsultingPricePolicyRepository = new ConsultingPricePolicyRepository(_context, this);
            ConsultingTicketRepository = new ConsultingTicketRepository(_context, this);
            ConsultingTypeRepository = new ConsultingTypeRepository(_context, this);
            CustomerRepository = new CustomerRepository(_context, this);
            CustomerCertificateDetailRepository = new CustomerCertificateDetailRepository(_context, this);
            CustomerLessonDetailRepository = new CustomerLessonDetailRepository(_context, this);
            CustomerOnlineCourseDetailRepository = new CustomerOnlineCourseDetailRepository(_context, this);
            CustomerSectionDetailRepository = new CustomerSectionDetailRepository(_context, this);
            CustomerWorkshopClassRepository = new CustomerWorkshopClassRepository(_context, this);
            DistancePriceRepository = new DistancePriceRepository(_context, this);
            FeedbackRepository = new FeedbackRepository(_context, this);
            FeedbackTypeRepository = new FeedbackTypeRepository(_context, this);
            LessonRepository = new LessonRepository(_context, this);
            MembershipRankRepository = new MembershipRankRepository(_context, this);
            OnlineCourseRepository = new OnlineCourseRepository(_context, this);
            SectionRepository = new SectionRepository(_context, this);
            SkillRepository = new SkillRepository(_context, this);
            SlotRepository = new SlotRepository(_context, this);
            TrainableSkillRepository = new TrainableSkillRepository(_context, this);
            TrainerRepository = new TrainerRepository(_context, this);
            TrainerSkillRepository = new TrainerSkillRepository(_context, this);
            TrainerSlotRepository = new TrainerSlotRepository(_context, this);
            TrainingCourseRepository = new TrainingCourseRepository(_context, this);
            TrainingCourseSkillRepository = new TrainingCourseSkillRepository(_context, this);
            TransactionRepository = new TransactionRepository(_context, this);
            UserRepository = new UserRepository(_context, this);
            WorkshopRepository = new WorkshopRepository(_context, this);
            WorkshopAttendanceRepository = new WorkshopAttendanceRepository(_context, this);
            WorkshopClassRepository = new WorkshopClassRepository(_context, this);
            WorkshopClassDetailRepository = new WorkshopClassDetailRepository(_context, this);
            WorkshopRefundPolicyRepository = new WorkshopRefundPolicyRepository(_context, this);
        }
    }
}
