using AppCore.Context;
using AppRepository.Repository;
using AppRepository.Repository.Implement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppRepository.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        public IUserRepository UserRepository { get; private set; } = null!;

        public IAppointmentRepository AppointmentRepository { get; private set; } = null!;

        public IAppointmentBillRepository AppointmentBillRepository { get; private set; } = null!;

        public IBirdRepository BirdRepository { get; private set; } = null!;

        public IBirdCertificateRepository BirdCertificateRepository { get; private set; } = null!;

        public IBirdCertificateDetailRepository BirdCertificateDetailRepository { get; private set; } = null!;

        public IBirdSkillRepository BirdSkillRepository { get; private set; } = null!;

        public IBirdSpeciesRepository BirdSpeciesRepository { get; private set; } = null!;

        public IBirdTrainingCourseRepository BirdTrainingCourseRepository { get; private set; } = null!;

        public ICertificateRepository CertificateRepository { get; private set; } = null!;

        public IConsultingTicketRepository ConsultingTicketRepository { get; private set; } = null!;

        public IConsultingTypeRepository ConsultingTypeRepository { get; private set; } = null!;

        public ICustomerRepository CustomerRepository { get; private set; } = null!;

        public ICustomerCertificateDetailRepository CustomerCertificateDetailRepository { get; private set; } = null!;

        public ICustomerLessonDetailRepository CustomerLessonDetailRepository { get; private set; } = null!;

        public ICustomerOnlineCourseDetailRepository CustomerOnlineCourseDetailRepository { get; private set; } = null!;

        public ICustomerSectionDetailRepository CustomerSectionDetailRepository { get; private set; } = null!;

        public IDayRepository DayRepository { get; private set; } = null!;

        public IFeedbackRepository FeedbackRepository { get; private set; } = null!;

        public IFeedbackTypeRepository FeedbackTypeRepository { get; private set; } = null!;

        public ILessonRepository LessonRepository { get; private set; } = null!;

        public IOnlineCourseRepository OnlineCourseRepository { get; private set; } = null!;

        public IRoleRepository RoleRepository { get; private set; } = null!;

        public ISectionRepository SectionRepository { get; private set; } = null!;

        public ISkillRepository SkillRepository { get; private set; } = null!;

        public ISlotRepository SlotRepository { get; private set; } = null!;

        public IStaffBirdReceivedRepository StaffBirdReceivedRepository { get; private set; } = null!;

        public ITrainerRepository TrainerRepository { get; private set; } = null!;

        public ITrainingCourseRepository TrainingCourseRepository { get; private set; } = null!;

        public ITrainingCourseBirdSkillRepository TrainingCourseBirdSkillRepository { get; private set; } = null!;

        public IWeekRepository WeekRepository { get; private set; } = null!;

        public IWorkshopRepository WorkshopRepository { get; private set; } = null!;

        public IWorkshopAttendanceRepository WorkshopAttendanceRepository { get; private set; } = null!;

        public IBirdCaringPricePolicyRepository BirdCaringPricePolicyRepository { get; private set; } = null!;

        public IBirdReceiveSheetRepository BirdReceiveSheetRepository { get; private set; } = null!;

        public IBirdReturnSheetRepository BirdReturnSheetRepository { get; private set; } = null!;

        public IBirdTrainingDetailRepository BirdTrainingDetailRepository { get; private set; } = null!;

        public IBirdTrainingProgressRepository BirdTrainingProgressRepository { get; private set; } = null!;

        public IConsultingPricePolicyRepository ConsultingPricePolicyRepository { get; private set; } = null!;

        public ICustomerWorkshopClassRepository CustomerWorkshopClassRepository { get; private set; } = null!;

        public IDistancePriceRepository DistancePriceRepository { get; private set; } = null!;

        public IWorkshopClassRepository WorkshopClassRepository { get; private set; } = null!;

        public IWorkshopClassDetailRepository WorkshopClassDetailRepository { get; private set; } = null!;

        public IWorkshopPricePolicyRepository WorkshopPricePolicyRepository { get; private set; } = null!;

        public IWorkshopRefundPolicyRepository WorkshopRefundPolicyRepository { get; private set; } = null!;

        private readonly BirdTrainingCenterSystemContext _context;

        public UnitOfWork(BirdTrainingCenterSystemContext context)
        {
            _context = context;
            InitRepositories();
        }

        private void InitRepositories()
        {
            AppointmentRepository = new AppointmentRepository(_context, this);
            AppointmentBillRepository = new AppointmentBillRepository(_context, this);
            BirdRepository = new BirdRepository(_context, this);
            BirdCaringPricePolicyRepository = new BirdCaringPricePolicyRepository(_context, this);
            BirdCertificateRepository = new BirdCertificateRepository(_context, this);
            BirdCertificateDetailRepository = new BirdCertificateDetailRepository(_context, this);
            BirdReceiveSheetRepository = new BirdReceiveSheetRepository(_context, this);
            BirdReturnSheetRepository = new BirdReturnSheetRepository(_context, this);
            BirdSkillRepository = new BirdSkillRepository(_context, this);
            BirdSpeciesRepository = new BirdSpeciesRepository(_context, this);
            BirdTrainingCourseRepository = new BirdTrainingCourseRepository(_context, this);
            BirdTrainingDetailRepository = new BirdTrainingDetailRepository(_context, this);
            BirdTrainingProgressRepository = new BirdTrainingProgressRepository(_context, this);
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
            DayRepository = new DayRepository(_context, this);
            DistancePriceRepository = new DistancePriceRepository(_context, this);
            FeedbackRepository = new FeedbackRepository(_context, this);
            FeedbackTypeRepository = new FeedbackTypeRepository(_context, this);
            LessonRepository = new LessonRepository(_context, this);
            OnlineCourseRepository = new OnlineCourseRepository(_context, this);
            RoleRepository = new RoleRepository(_context, this);
            SectionRepository = new SectionRepository(_context, this);
            SkillRepository = new SkillRepository(_context, this);
            SlotRepository = new SlotRepository(_context, this);
            StaffBirdReceivedRepository = new StaffBirdReceivedRepository(_context, this);
            TrainerRepository = new TrainerRepository(_context, this);
            TrainingCourseRepository = new TrainingCourseRepository(_context, this);
            TrainingCourseBirdSkillRepository = new TrainingCourseBirdSkillRepository(_context, this);
            UserRepository = new UserRepository(_context, this);
            WeekRepository = new WeekRepository(_context, this);
            WorkshopRepository = new WorkshopRepository(_context, this);
            WorkshopAttendanceRepository = new WorkshopAttendanceRepository(_context, this);
            WorkshopClassRepository = new WorkshopClassRepository(_context, this);
            WorkshopClassDetailRepository = new WorkshopClassDetailRepository(_context, this);
            WorkshopPricePolicyRepository = new WorkshopPricePolicyRepository(_context, this);
            WorkshopRefundPolicyRepository = new WorkshopRefundPolicyRepository(_context, this);
        }
    }
}
