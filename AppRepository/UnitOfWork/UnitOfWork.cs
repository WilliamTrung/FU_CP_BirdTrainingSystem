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

        public IBirdTrainingProgressDetailRepository BirdTrainingProgressDetailRepository { get; private set; } = null!;

        public ICertificateRepository CertificateRepository { get; private set; } = null!;

        public IConsultingTicketRepository ConsultingTicketRepository { get; private set; } = null!;

        public IConsultingTypeRepository ConsultingTypeRepository { get; private set; } = null!;

        public ICustomerRepository CustomerRepository { get; private set; } = null!;

        public ICustomerCertificateDetailRepository CustomerCertificateDetailRepository { get; private set; } = null!;

        public ICustomerLessonDetailRepository CustomerLessonDetailRepository { get; private set; } = null!;

        public ICustomerOnlineCourseDetailRepository CustomerOnlineCourseDetailRepository { get; private set; } = null!;

        public ICustomerSectionDetailRepository CustomerSectionDetailRepository { get; private set; } = null!;

        public ICustomerWorkshopPaymentRepository CustomerWorkshopPaymentRepository { get; private set; } = null!;

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

        public ITrainerWorkshopRepository TrainerWorkshopRepository { get; private set; } = null!;

        public ITrainingCourseRepository TrainingCourseRepository { get; private set; } = null!;

        public ITrainingCourseBirdSkillRepository TrainingCourseBirdSkillRepository { get; private set; } = null!;

        public IWeekRepository WeekRepository { get; private set; } = null!;

        public IWorkshopRepository WorkshopRepository { get; private set; } = null!;

        public IWorkshopAttendanceRepository WorkshopAttendanceRepository { get; private set; } = null!;

        public IWorkShopCategoryRepository WorkShopCategoryRepository { get; private set; } = null! ;

        private readonly BirdTrainingSystemContext _context;

        public UnitOfWork(BirdTrainingSystemContext context)
        {
            _context = context;
            InitRepositories();
        }

        private void InitRepositories()
        {
            AppointmentRepository = new AppointmentRepository(_context, this);
            AppointmentBillRepository = new AppointmentBillRepository(_context, this);
            BirdRepository = new BirdRepository(_context, this);
            BirdCertificateRepository = new BirdCertificateRepository(_context, this);
            BirdCertificateDetailRepository = new BirdCertificateDetailRepository(_context, this);
            BirdSkillRepository = new BirdSkillRepository(_context, this);
            BirdSpeciesRepository = new BirdSpeciesRepository(_context, this);
            BirdTrainingCourseRepository = new BirdTrainingCourseRepository(_context, this);
            BirdTrainingProgressDetailRepository = new BirdTrainingProgressDetailRepository(_context, this);
            CertificateRepository = new CertificateRepository(_context, this);
            ConsultingTicketRepository = new ConsultingTicketRepository(_context, this);
            ConsultingTypeRepository = new ConsultingTypeRepository(_context, this);
            CustomerRepository = new CustomerRepository(_context, this);
            CustomerCertificateDetailRepository = new CustomerCertificateDetailRepository(_context, this);
            CustomerLessonDetailRepository = new CustomerLessonDetailRepository(_context, this);
            CustomerOnlineCourseDetailRepository = new CustomerOnlineCourseDetailRepository(_context, this);
            CustomerSectionDetailRepository = new CustomerSectionDetailRepository(_context, this);
            CustomerWorkshopPaymentRepository = new CustomerWorkshopPaymentRepository(_context, this);
            DayRepository = new DayRepository(_context, this);
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
            TrainerWorkshopRepository = new TrainerWorkshopRepository(_context, this);
            TrainingCourseRepository = new TrainingCourseRepository(_context, this);
            TrainingCourseBirdSkillRepository = new TrainingCourseBirdSkillRepository(_context, this);
            UserRepository = new UserRepository(_context, this);
            WeekRepository = new WeekRepository(_context, this);
            WorkshopRepository = new WorkshopRepository(_context, this);
            WorkshopAttendanceRepository = new WorkshopAttendanceRepository(_context, this);
            WorkShopCategoryRepository = new WorkShopCategoryRepository(_context, this);
        }
    }
}
