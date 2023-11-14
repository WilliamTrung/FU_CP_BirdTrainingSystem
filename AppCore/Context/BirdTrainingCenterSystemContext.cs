using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Models.Entities;

namespace AppCore.Context
{
    public partial class BirdTrainingCenterSystemContext : DbContext
    {
        public BirdTrainingCenterSystemContext()
        {
        }

        public BirdTrainingCenterSystemContext(DbContextOptions<BirdTrainingCenterSystemContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AcquirableSkill> AcquirableSkills { get; set; } = null!;
        public virtual DbSet<Address> Addresses { get; set; } = null!;
        public virtual DbSet<Bird> Birds { get; set; } = null!;
        public virtual DbSet<BirdCertificate> BirdCertificates { get; set; } = null!;
        public virtual DbSet<BirdCertificateDetail> BirdCertificateDetails { get; set; } = null!;
        public virtual DbSet<BirdCertificateSkill> BirdCertificateSkills { get; set; } = null!;
        public virtual DbSet<BirdSkill> BirdSkills { get; set; } = null!;
        public virtual DbSet<BirdSkillReceived> BirdSkillReceiveds { get; set; } = null!;
        public virtual DbSet<BirdSpecies> BirdSpecies { get; set; } = null!;
        public virtual DbSet<BirdTrainingCourse> BirdTrainingCourses { get; set; } = null!;
        public virtual DbSet<BirdTrainingProgress> BirdTrainingProgresses { get; set; } = null!;
        public virtual DbSet<BirdTrainingReport> BirdTrainingReports { get; set; } = null!;
        public virtual DbSet<CenterSlot> CenterSlots { get; set; } = null!;
        public virtual DbSet<Certificate> Certificates { get; set; } = null!;
        public virtual DbSet<ConsultingPricePolicy> ConsultingPricePolicies { get; set; } = null!;
        public virtual DbSet<ConsultingTicket> ConsultingTickets { get; set; } = null!;
        public virtual DbSet<ConsultingType> ConsultingTypes { get; set; } = null!;
        public virtual DbSet<Customer> Customers { get; set; } = null!;
        public virtual DbSet<CustomerCertificateDetail> CustomerCertificateDetails { get; set; } = null!;
        public virtual DbSet<CustomerLessonDetail> CustomerLessonDetails { get; set; } = null!;
        public virtual DbSet<CustomerOnlineCourseDetail> CustomerOnlineCourseDetails { get; set; } = null!;
        public virtual DbSet<CustomerSectionDetail> CustomerSectionDetails { get; set; } = null!;
        public virtual DbSet<CustomerWorkshopClass> CustomerWorkshopClasses { get; set; } = null!;
        public virtual DbSet<DistancePrice> DistancePrices { get; set; } = null!;
        public virtual DbSet<Feedback> Feedbacks { get; set; } = null!;
        public virtual DbSet<Lesson> Lessons { get; set; } = null!;
        public virtual DbSet<MembershipRank> MembershipRanks { get; set; } = null!;
        public virtual DbSet<OnlineCourse> OnlineCourses { get; set; } = null!;
        public virtual DbSet<Section> Sections { get; set; } = null!;
        public virtual DbSet<Skill> Skills { get; set; } = null!;
        public virtual DbSet<Slot> Slots { get; set; } = null!;
        public virtual DbSet<TrainableSkill> TrainableSkills { get; set; } = null!;
        public virtual DbSet<Trainer> Trainers { get; set; } = null!;
        public virtual DbSet<TrainerSkill> TrainerSkills { get; set; } = null!;
        public virtual DbSet<TrainerSlot> TrainerSlots { get; set; } = null!;
        public virtual DbSet<TrainingCourse> TrainingCourses { get; set; } = null!;
        //public virtual DbSet<TrainingCourseSkill> TrainingCourseSkills { get; set; } = null!;
        public virtual DbSet<Transaction> Transactions { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;
        public virtual DbSet<Workshop> Workshops { get; set; } = null!;
        public virtual DbSet<WorkshopAttendance> WorkshopAttendances { get; set; } = null!;
        public virtual DbSet<WorkshopClass> WorkshopClasses { get; set; } = null!;
        public virtual DbSet<WorkshopClassDetail> WorkshopClassDetails { get; set; } = null!;
        public virtual DbSet<WorkshopDetailTemplate> WorkshopDetailTemplates { get; set; } = null!;
        public virtual DbSet<WorkshopRefundPolicy> WorkshopRefundPolicies { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                //optionsBuilder.UseSqlServer("Server=(local);uid=sa;pwd=1234567890;database= BirdTrainingCenterSystem;TrustServerCertificate=True;");
                optionsBuilder.UseNpgsql($"Server={Connection.Server};Port={Connection.Port};Database={Connection.Database};User Id={Connection.UID};Password={Connection.Password};SSL Mode=Require;Trust Server Certificate=True;\r\n");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.AddMinimalCompareString();
            //modelBuilder.AddDateEquallyCompare();
            //modelBuilder.AddDateCompare();
            modelBuilder.AddMembershipModels();
            modelBuilder.AddSlots();
            modelBuilder.AddTrainerSkills();
            modelBuilder.AddWorkshopRefundPolicies();
            modelBuilder.Entity<AcquirableSkill>(entity =>
            {
                entity.HasKey(e => new { e.BirdSpeciesId, e.BirdSkillId })
                    .HasName("PK__Acquirab__4802579EB257E655");

                entity.ToTable("AcquirableSkill");

                entity.Property(e => e.Condition)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.HasOne(d => d.BirdSkill)
                    .WithMany(p => p.AcquirableSkills)
                    .HasForeignKey(d => d.BirdSkillId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FKAcquirable305826");

                entity.HasOne(d => d.BirdSpecies)
                    .WithMany(p => p.AcquirableSkills)
                    .HasForeignKey(d => d.BirdSpeciesId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FKAcquirable80836");
            });

            modelBuilder.Entity<Address>(entity =>
            {
                entity.ToTable("Address");

                entity.Property(e => e.AddressDetail)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.Addresses)
                    .HasForeignKey(d => d.CustomerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FKAddress64774");
            });

            modelBuilder.Entity<Bird>(entity =>
            {
                entity.ToTable("Bird");

                entity.Property(e => e.Color)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Description)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Picture)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.HasOne(d => d.BirdSpecies)
                    .WithMany(p => p.Birds)
                    .HasForeignKey(d => d.BirdSpeciesId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FKBird650663");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.Birds)
                    .HasForeignKey(d => d.CustomerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FKBird173768");
            });

            modelBuilder.Entity<BirdCertificate>(entity =>
            {
                entity.ToTable("BirdCertificate");

                entity.Property(e => e.BirdCenterName)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Picture)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.ShortDescrption)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.Title)
                    .HasMaxLength(300)
                    .IsUnicode(false);

                entity.HasOne(d => d.TrainingCourse)
                    .WithMany(p => p.BirdCertificates)
                    .HasForeignKey(d => d.TrainingCourseId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FKBirdCertif231604");
            });

            modelBuilder.Entity<BirdCertificateDetail>(entity =>
            {
                entity.HasKey(e => new { e.Id });

                entity.ToTable("BirdCertificateDetail");

                entity.Property(e => e.ReceiveDate).HasColumnType("date");

                entity.HasOne(d => d.BirdCertificate)
                    .WithMany(p => p.BirdCertificateDetails)
                    .HasForeignKey(d => d.BirdCertificateId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FKBirdCertif464427");

                entity.HasOne(d => d.Bird)
                    .WithMany(p => p.BirdCertificateDetails)
                    .HasForeignKey(d => d.BirdId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FKBirdCertif999788");
            });

            modelBuilder.Entity<BirdCertificateSkill>(entity =>
            {
                entity.HasKey(e => new { e.BirdSkillId, e.BirdCertificateId })
                    .HasName("PK__BirdCert__A080D86A58420E37");

                entity.ToTable("BirdCertificateSkill");

                entity.Property(e => e.ReceivedDate).HasColumnType("date");

                entity.HasOne(d => d.BirdCertificate)
                    .WithMany(p => p.BirdCertificateSkills)
                    .HasForeignKey(d => d.BirdCertificateId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FKBirdCertif72357");

                entity.HasOne(d => d.BirdSkill)
                    .WithMany(p => p.BirdCertificateSkills)
                    .HasForeignKey(d => d.BirdSkillId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FKBirdCertif163982");
            });

            modelBuilder.Entity<BirdSkill>(entity =>
            {
                entity.ToTable("BirdSkill");

                entity.Property(e => e.Description)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .HasMaxLength(200)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<BirdSkillReceived>(entity =>
            {
                entity.HasKey(e => new { e.BirdSkillId, e.BirdId });

                entity.ToTable("BirdSkillReceived");

                entity.HasOne(d => d.Bird)
                    .WithMany(p => p.BirdSkillReceiveds)
                    .HasForeignKey(d => d.BirdId)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.BirdSkill)
                    .WithMany(p => p.BirdSkillReceiveds)
                    .HasForeignKey(d => d.BirdSkillId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<BirdSpecies>(entity =>
            {
                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ShortDetail)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<BirdTrainingCourse>(entity =>
            {
                entity.ToTable("Bird_TrainingCourse");

                entity.Property(e => e.DiscountedPrice).HasColumnType("money");

                entity.Property(e => e.ReceiveNote)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.ReceivePicture)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.ReturnNote)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.ReturnPicture)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.TotalPrice).HasColumnType("money");

                entity.Property(e => e.TrainingDoneDate).HasColumnType("date");

                entity.HasOne(d => d.Bird)
                    .WithMany(p => p.BirdTrainingCourses)
                    .HasForeignKey(d => d.BirdId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FKBird_Train718139");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.BirdTrainingCourses)
                    .HasForeignKey(d => d.CustomerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FKBird_Train678526");

                entity.HasOne(d => d.Staff)
                    .WithMany(p => p.BirdTrainingCourses)
                    .HasForeignKey(d => d.StaffId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FKBird_Train934485");

                entity.HasOne(d => d.TrainingCourse)
                    .WithMany(p => p.BirdTrainingCourses)
                    .HasForeignKey(d => d.TrainingCourseId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FKBird_Train368802");
            });

            modelBuilder.Entity<BirdTrainingProgress>(entity =>
            {
                entity.ToTable("Bird_TrainingProgress");

                entity.Property(e => e.BirdTrainingCourseId).HasColumnName("Bird_TrainingCourseId");

                entity.Property(e => e.Evidence)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                //entity.Property(e => e.TrainingCourseSkillId).HasColumnName("TrainingCourse_SkillId");

                entity.Property(e => e.TrainingDoneDate).HasColumnType("date");

                entity.HasOne(d => d.BirdTrainingCourse)
                    .WithMany(p => p.BirdTrainingProgresses)
                    .HasForeignKey(d => d.BirdTrainingCourseId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FKBird_Train409415");

                entity.HasOne(d => d.Trainer)
                    .WithMany(p => p.BirdTrainingProgresses)
                    .HasForeignKey(d => d.TrainerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FKBird_Train934988");

                //entity.HasOne(d => d.TrainingCourseSkill)
                //    .WithMany(p => p.BirdTrainingProgresses)
                //    .HasForeignKey(d => d.TrainingCourseSkillId)
                //    .OnDelete(DeleteBehavior.ClientSetNull)
                //    .HasConstraintName("FKBird_Train174512");
            });

            modelBuilder.Entity<BirdTrainingReport>(entity =>
            {
                entity.ToTable("BirdTrainingReport");

                entity.Property(e => e.BirdTrainingProgressId).HasColumnName("Bird_TrainingProgressId");

                entity.Property(e => e.Comment)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Evidence)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.HasOne(d => d.BirdTrainingProgress)
                    .WithMany(p => p.BirdTrainingReports)
                    .HasForeignKey(d => d.BirdTrainingProgressId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FKBirdTraini259515");

                entity.HasOne(d => d.TrainerSlot)
                    .WithMany(p => p.BirdTrainingReports)
                    .HasForeignKey(d => d.TrainerSlotId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FKBirdTraini696869");
            });

            modelBuilder.Entity<CenterSlot>(entity =>
            {
                entity.ToTable("CenterSlot");

                entity.Property(e => e.Date).HasColumnType("date");

                entity.HasOne(d => d.Slot)
                    .WithMany(p => p.CenterSlots)
                    .HasForeignKey(d => d.SlotId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FKCenterSlot412931");
            });

            modelBuilder.Entity<Certificate>(entity =>
            {
                entity.ToTable("Certificate");

                entity.Property(e => e.BirdCenterName)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Picture)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.ShortDescrption)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.Title)
                    .HasMaxLength(300)
                    .IsUnicode(false);

                entity.HasOne(d => d.OnlineCourse)
                    .WithMany(p => p.Certificates)
                    .HasForeignKey(d => d.OnlineCourseId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FKCertificat555329");
            });

            modelBuilder.Entity<ConsultingPricePolicy>(entity =>
            {
                entity.ToTable("ConsultingPricePolicy");

                entity.Property(e => e.Price).HasColumnType("money");
            });

            modelBuilder.Entity<ConsultingTicket>(entity =>
            {
                entity.ToTable("ConsultingTicket");

                entity.Property(e => e.AppointmentDate).HasColumnType("date");

                entity.Property(e => e.ConsultingDetail)
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.Property(e => e.DiscountedPrice).HasColumnType("money");

                entity.Property(e => e.Evidence)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.GgMeetLink)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Price).HasColumnType("money");

                entity.HasOne(d => d.Address)
                    .WithMany(p => p.ConsultingTickets)
                    .HasForeignKey(d => d.AddressId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FKConsulting220553");

                entity.HasOne(d => d.ConsultingPricePolicy)
                    .WithMany(p => p.ConsultingTickets)
                    .HasForeignKey(d => d.ConsultingPricePolicyId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FKConsulting196354");

                entity.HasOne(d => d.ConsultingType)
                    .WithMany(p => p.ConsultingTickets)
                    .HasForeignKey(d => d.ConsultingTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FKConsulting521439");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.ConsultingTickets)
                    .HasForeignKey(d => d.CustomerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FKConsulting154539");

                entity.HasOne(d => d.DistancePrice)
                    .WithMany(p => p.ConsultingTickets)
                    .HasForeignKey(d => d.DistancePriceId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FKConsulting564465");

                entity.HasOne(d => d.Trainer)
                    .WithMany(p => p.ConsultingTickets)
                    .HasForeignKey(d => d.TrainerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FKConsulting31098");
            });

            modelBuilder.Entity<ConsultingType>(entity =>
            {
                entity.ToTable("ConsultingType");

                entity.Property(e => e.Name)
                    .HasMaxLength(200)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.ToTable("Customer");

                entity.Property(e => e.BirthDay).HasColumnType("date");

                entity.Property(e => e.TotalPayment).HasColumnType("money");

                entity.HasOne(d => d.MembershipRank)
                    .WithMany(p => p.Customers)
                    .HasForeignKey(d => d.MembershipRankId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FKCustomer774542");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Customers)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FKCustomer697132");
            });

            modelBuilder.Entity<CustomerCertificateDetail>(entity =>
            {
                entity.HasKey(e => new { e.CustomerId, e.CertificateId })
                    .HasName("PK__Customer__AF11EEA4FDA02E2A");

                entity.ToTable("Customer_CertificateDetail");

                entity.Property(e => e.ReceiveDate).HasColumnType("date");

                entity.HasOne(d => d.Certificate)
                    .WithMany(p => p.CustomerCertificateDetails)
                    .HasForeignKey(d => d.CertificateId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FKCustomer_C508581");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.CustomerCertificateDetails)
                    .HasForeignKey(d => d.CustomerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FKCustomer_C859755");
            });

            modelBuilder.Entity<CustomerLessonDetail>(entity =>
            {
                entity.HasKey(e => new { e.CustomerId, e.LessionId })
                    .HasName("PK__Customer__304EA374D16199C5");

                entity.ToTable("Customer_LessonDetail");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.CustomerLessonDetails)
                    .HasForeignKey(d => d.CustomerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FKCustomer_L809461");

                entity.HasOne(d => d.Lession)
                    .WithMany(p => p.CustomerLessonDetails)
                    .HasForeignKey(d => d.LessionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FKCustomer_L582869");
            });

            modelBuilder.Entity<CustomerOnlineCourseDetail>(entity =>
            {
                entity.HasKey(e => new { e.CustomerId, e.OnlineCourseId })
                    .HasName("PK__Customer__FFA1E3B76AF51E89");

                entity.ToTable("Customer_OnlineCourseDetail");

                entity.Property(e => e.DiscountedPrice).HasColumnType("money");

                entity.Property(e => e.Price).HasColumnType("money");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.CustomerOnlineCourseDetails)
                    .HasForeignKey(d => d.CustomerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FKCustomer_O139976");

                entity.HasOne(d => d.OnlineCourse)
                    .WithMany(p => p.CustomerOnlineCourseDetails)
                    .HasForeignKey(d => d.OnlineCourseId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FKCustomer_O181189");
            });

            modelBuilder.Entity<CustomerSectionDetail>(entity =>
            {
                entity.HasKey(e => new { e.CustomerId, e.SectionId })
                    .HasName("PK__Customer__9CA0945F8CBB2D34");

                entity.ToTable("Customer_SectionDetail");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.CustomerSectionDetails)
                    .HasForeignKey(d => d.CustomerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FKCustomer_S58540");

                entity.HasOne(d => d.Section)
                    .WithMany(p => p.CustomerSectionDetails)
                    .HasForeignKey(d => d.SectionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FKCustomer_S977222");
            });

            modelBuilder.Entity<CustomerWorkshopClass>(entity =>
            {
                entity.HasKey(e => new { e.CustomerId, e.WorkshopClassId })
                    .HasName("PK__Customer__7EEF8348DE684159");

                entity.ToTable("Customer_WorkshopClass");

                entity.Property(e => e.DiscountedPrice).HasColumnType("money");

                entity.Property(e => e.Price).HasColumnType("money");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.CustomerWorkshopClasses)
                    .HasForeignKey(d => d.CustomerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FKCustomer_W416862");

                entity.HasOne(d => d.WorkshopClass)
                    .WithMany(p => p.CustomerWorkshopClasses)
                    .HasForeignKey(d => d.WorkshopClassId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FKCustomer_W257990");
                entity.HasOne(d => d.WorkshopRefundPolicy)
                    .WithMany(p => p.CustomerWorkshopClasses)
                    .HasForeignKey(d => d.WorkshopRefundPolicyId)
                    .OnDelete(DeleteBehavior.NoAction);
                    //.HasConstraintName("FKWorkshop234277");
            });

            modelBuilder.Entity<DistancePrice>(entity =>
            {
                entity.ToTable("DistancePrice");

                entity.Property(e => e.PricePerKm).HasColumnType("money");
            });

            modelBuilder.Entity<Feedback>(entity =>
            {
                entity.ToTable("Feedback");

                entity.Property(e => e.FeedbackDetail)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.Feedbacks)
                    .HasForeignKey(d => d.CustomerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FKFeedback245587");
            });

            modelBuilder.Entity<Lesson>(entity =>
            {
                entity.ToTable("Lesson");

                entity.Property(e => e.Description)
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.Property(e => e.Detail)
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.Property(e => e.Title)
                    .HasMaxLength(300)
                    .IsUnicode(false);

                entity.Property(e => e.Video)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.HasOne(d => d.Section)
                    .WithMany(p => p.Lessons)
                    .HasForeignKey(d => d.SectionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FKLesson170997");
            });

            modelBuilder.Entity<MembershipRank>(entity =>
            {
                entity.ToTable("MembershipRank");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Requirement).HasColumnType("money");
            });

            modelBuilder.Entity<OnlineCourse>(entity =>
            {
                entity.ToTable("OnlineCourse");

                entity.Property(e => e.Picture)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Price).HasColumnType("money");

                entity.Property(e => e.ShortDescription)
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.Property(e => e.Title)
                    .HasMaxLength(300)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Section>(entity =>
            {
                entity.ToTable("Section");

                entity.Property(e => e.Title)
                    .HasMaxLength(300)
                    .IsUnicode(false);

                entity.HasOne(d => d.OnlineCourse)
                    .WithMany(p => p.Sections)
                    .HasForeignKey(d => d.OnlineCourseId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FKSection929188");
            });

            modelBuilder.Entity<Skill>(entity =>
            {
                entity.ToTable("Skill");

                entity.Property(e => e.Description)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .HasMaxLength(200)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Slot>(entity =>
            {
                entity.ToTable("Slot");
            });

            modelBuilder.Entity<TrainableSkill>(entity =>
            {
                entity.HasKey(e => new { e.BirdSkillId, e.SkillId })
                    .HasName("PK__Trainabl__707AE50061373685");

                entity.ToTable("TrainableSkill");

                entity.Property(e => e.ShortDescription)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.BirdSkill)
                    .WithMany(p => p.TrainableSkills)
                    .HasForeignKey(d => d.BirdSkillId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FKTrainableS485101");

                entity.HasOne(d => d.Skill)
                    .WithMany(p => p.TrainableSkills)
                    .HasForeignKey(d => d.SkillId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FKTrainableS574420");
            });

            modelBuilder.Entity<Trainer>(entity =>
            {
                entity.ToTable("Trainer");

                entity.Property(e => e.BirthDay).HasColumnType("date");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Trainers)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FKTrainer76895");
                //entity.HasMany(d => d.TrainerSkills)
                //    .WithOne(p => p.Trainer)
                //    .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<TrainerSkill>(entity =>
            {
                entity.HasKey(e => new { e.TrainerId, e.SkillId })
                    .HasName("PK__Trainer___5B90136408FD50B7");

                entity.ToTable("Trainer_Skill");

                entity.Property(e => e.Description)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.Skill)
                    .WithMany(p => p.TrainerSkills)
                    .HasForeignKey(d => d.SkillId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FKTrainer_Sk368940");

                entity.HasOne(d => d.Trainer)
                    .WithMany(p => p.TrainerSkills)
                    .HasForeignKey(d => d.TrainerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FKTrainer_Sk733170");
            });

            modelBuilder.Entity<TrainerSlot>(entity =>
            {
                entity.ToTable("TrainerSlot");

                entity.Property(e => e.Date).HasColumnType("date");

                entity.Property(e => e.Reason)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.Slot)
                    .WithMany(p => p.TrainerSlots)
                    .HasForeignKey(d => d.SlotId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FKTrainerSlo833189");

                entity.HasOne(d => d.Trainer)
                    .WithMany(p => p.TrainerSlots)
                    .HasForeignKey(d => d.TrainerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FKTrainerSlo815026");
            });

            modelBuilder.Entity<TrainingCourse>(entity =>
            {
                entity.ToTable("TrainingCourse");

                entity.Property(e => e.Description)
                    .HasMaxLength(300)
                    .IsUnicode(false);

                entity.Property(e => e.Picture)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Title)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.TotalPrice).HasColumnType("money");

                entity.HasOne(d => d.BirdSpecies)
                    .WithMany(p => p.TrainingCourses)
                    .HasForeignKey(d => d.BirdSpeciesId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FKTrainingCo245376");
            });

            //modelBuilder.Entity<TrainingCourseSkill>(entity =>
            //{
            //    entity.HasKey(e => e.Id);

            //    entity.ToTable("TrainingCourseSkillDetail");

            //    entity.HasOne(d => d.BirdSkill)
            //        .WithMany(p => p.TrainingCourseSkills)
            //        .HasForeignKey(d => d.BirdSkillId)
            //        .OnDelete(DeleteBehavior.ClientSetNull);

            //    entity.HasOne(d => d.TrainingCourse)
            //        .WithMany(p => p.TrainingCourseSkills)
            //        .HasForeignKey(d => d.TrainingCourseId)
            //        .OnDelete(DeleteBehavior.ClientSetNull);
            //});

            modelBuilder.Entity<Transaction>(entity =>
            {
                entity.ToTable("Transaction");

                entity.Property(e => e.DateCreate).HasColumnType("date");

                entity.Property(e => e.Detail)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.PaymentCode)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.PaymentDate).HasColumnType("date");

                entity.Property(e => e.Title)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.TotalPayment).HasColumnType("money");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.Transactions)
                    .HasForeignKey(d => d.CustomerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FKTransactio250053");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("User");

                entity.HasIndex(e => e.PhoneNumber, "UQ__User__85FB4E386F560942")
                    .IsUnique();

                entity.HasIndex(e => e.Email, "UQ__User__A9D10534EE377C20")
                    .IsUnique();

                entity.Property(e => e.Avatar)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Email)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.PhoneNumber).HasColumnType("numeric(18, 0)");
            });

            modelBuilder.Entity<Workshop>(entity =>
            {
                entity.ToTable("Workshop");

                entity.Property(e => e.Description)
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.Property(e => e.Picture)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Price).HasColumnType("money");

                entity.Property(e => e.Title)
                    .HasMaxLength(300)
                    .IsUnicode(false);
                entity.HasMany(d => d.WorkshopClasses)
                    .WithOne(p => p.Workshop)
                    .OnDelete(DeleteBehavior.Cascade);
                entity.HasMany(d => d.WorkshopDetailTemplates)
                    .WithOne(p => p.Workshop)
                    .OnDelete(DeleteBehavior.Cascade);
                //entity.HasOne(d => d.WorkshopRefundPolicy)
                //    .WithMany(p => p.Workshops)
                //    .HasForeignKey(d => d.WorkshopRefundPolicyId)
                //    .OnDelete(DeleteBehavior.ClientSetNull)
                //    .HasConstraintName("FKWorkshop234277");
            });

            modelBuilder.Entity<WorkshopAttendance>(entity =>
            {
                entity.ToTable("WorkshopAttendance");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.WorkshopAttendances)
                    .HasForeignKey(d => d.CustomerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FKWorkshopAt124181");

                entity.HasOne(d => d.WorkshopClassDetail)
                    .WithMany(p => p.WorkshopAttendances)
                    .HasForeignKey(d => d.WorkshopClassDetailId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<WorkshopClass>(entity =>
            {
                entity.ToTable("WorkshopClass");

                entity.Property(e => e.CreateDate).HasColumnType("date");

                entity.Property(e => e.RegisterEndDate).HasColumnType("date");

                entity.Property(e => e.StartTime).HasColumnType("date");

                entity.HasOne(d => d.Workshop)
                    .WithMany(p => p.WorkshopClasses)
                    .HasForeignKey(d => d.WorkshopId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FKWorkshopCl950556");
            });

            modelBuilder.Entity<WorkshopClassDetail>(entity =>
            {
                entity.ToTable("WorkshopClassDetail");

                entity.Property(e => e.UpdateDate).HasColumnType("date");

                entity.HasOne(d => d.WorkshopDetailTemplate)
                    .WithMany(p => p.WorkshopClassDetails)
                    .HasForeignKey(d => d.DetailId)
                    .OnDelete(DeleteBehavior.NoAction)
                    .HasConstraintName("FKWorkshopCl957106");

                entity.HasOne(d => d.DaySlot)
                    .WithMany(p => p.WorkshopClassDetails)
                    .HasForeignKey(d => d.DaySlotId)
                    .HasConstraintName("FKWorkshopCl382995");

                entity.HasOne(d => d.WorkshopClass)
                    .WithMany(p => p.WorkshopClassDetails)
                    .HasForeignKey(d => d.WorkshopClassId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FKWorkshopCl141743");
                entity.HasMany(d => d.WorkshopAttendances)
                    .WithOne(p => p.WorkshopClassDetail)
                    .OnDelete(DeleteBehavior.Cascade);
                    
            });
            modelBuilder.Entity<WorkshopRefundPolicy>(entity =>
            {
                entity.ToTable("WorkshopRefundPolicy");
            });
            modelBuilder.AddWorkshopDetailTemplate();
            OnModelCreatingPartial(modelBuilder);
        }
        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
