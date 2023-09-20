using System;
using System.Collections.Generic;
using AppCore.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

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

        public virtual DbSet<Appointment> Appointments { get; set; } = null!;
        public virtual DbSet<AppointmentBill> AppointmentBills { get; set; } = null!;
        public virtual DbSet<Bird> Birds { get; set; } = null!;
        public virtual DbSet<BirdCertificate> BirdCertificates { get; set; } = null!;
        public virtual DbSet<BirdSkill> BirdSkills { get; set; } = null!;
        public virtual DbSet<BirdSpecies> BirdSpecies { get; set; } = null!;
        public virtual DbSet<BirdTrainingCourse> BirdTrainingCourses { get; set; } = null!;
        public virtual DbSet<BirdTrainingProgressDetail> BirdTrainingProgressDetails { get; set; } = null!;
        public virtual DbSet<Certificate> Certificates { get; set; } = null!;
        public virtual DbSet<ConsultingTicket> ConsultingTickets { get; set; } = null!;
        public virtual DbSet<ConsultingType> ConsultingTypes { get; set; } = null!;
        public virtual DbSet<Customer> Customers { get; set; } = null!;
        public virtual DbSet<CustomerCertificateDetail> CustomerCertificateDetails { get; set; } = null!;
        public virtual DbSet<CustomerLessonDetail> CustomerLessonDetails { get; set; } = null!;
        public virtual DbSet<CustomerOnlineCourseDetail> CustomerOnlineCourseDetails { get; set; } = null!;
        public virtual DbSet<CustomerSectionDetail> CustomerSectionDetails { get; set; } = null!;
        public virtual DbSet<CustomerWorkshopPayment> CustomerWorkshopPayments { get; set; } = null!;
        public virtual DbSet<Day> Days { get; set; } = null!;
        public virtual DbSet<Feedback> Feedbacks { get; set; } = null!;
        public virtual DbSet<FeedbackType> FeedbackTypes { get; set; } = null!;
        public virtual DbSet<Lesson> Lessons { get; set; } = null!;
        public virtual DbSet<OnlineCourse> OnlineCourses { get; set; } = null!;
        public virtual DbSet<Role> Roles { get; set; } = null!;
        public virtual DbSet<Section> Sections { get; set; } = null!;
        public virtual DbSet<Skill> Skills { get; set; } = null!;
        public virtual DbSet<Slot> Slots { get; set; } = null!;
        public virtual DbSet<StaffBirdReceived> StaffBirdReceiveds { get; set; } = null!;
        public virtual DbSet<Trainer> Trainers { get; set; } = null!;
        public virtual DbSet<TrainerWorkshop> TrainerWorkshops { get; set; } = null!;
        public virtual DbSet<TrainingCourse> TrainingCourses { get; set; } = null!;
        public virtual DbSet<TrainingCourseBirdSkill> TrainingCourseBirdSkills { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;
        public virtual DbSet<BirdCertificateDetail> UserBirdBirdCertificates { get; set; } = null!;
        public virtual DbSet<Week> Weeks { get; set; } = null!;
        public virtual DbSet<WorkShopCategory> WorkShopCategories { get; set; } = null!;
        public virtual DbSet<Workshop> Workshops { get; set; } = null!;
        public virtual DbSet<WorkshopAttendance> WorkshopAttendances { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=(local);uid=sa;pwd=1234567890;database= BirdTrainingCenterSystem;TrustServerCertificate=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Appointment>(entity =>
            {
                entity.ToTable("Appointment");

                entity.Property(e => e.AppointmentDate).HasColumnType("date");

                entity.Property(e => e.Status)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.HasOne(d => d.AppointmentBill)
                    .WithMany(p => p.Appointments)
                    .HasForeignKey(d => d.AppointmentBillId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FKAppointmen977233");

                entity.HasOne(d => d.ConsultingTicket)
                    .WithMany(p => p.Appointments)
                    .HasForeignKey(d => d.ConsultingTicketId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FKAppointmen678768");

                entity.HasOne(d => d.Trainer)
                    .WithMany(p => p.Appointments)
                    .HasForeignKey(d => d.TrainerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FKAppointmen809396");
            });

            modelBuilder.Entity<AppointmentBill>(entity =>
            {
                entity.ToTable("AppointmentBill");

                entity.Property(e => e.TotalPrice).HasColumnType("decimal(19, 0)");
            });

            modelBuilder.Entity<Bird>(entity =>
            {
                entity.ToTable("Bird");

                entity.Property(e => e.Color)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.OrtherDescription)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.Birds)
                    .HasForeignKey(d => d.CustomerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FKBird173768");

                entity.HasOne(d => d.SystemBirdSpecies)
                    .WithMany(p => p.Birds)
                    .HasForeignKey(d => d.SystemBirdSpeciesId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FKBird925365");
            });

            modelBuilder.Entity<BirdCertificate>(entity =>
            {
                entity.ToTable("BirdCertificate");

                entity.Property(e => e.BirdCenterName)
                    .HasMaxLength(100)
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

            modelBuilder.Entity<BirdSkill>(entity =>
            {
                entity.ToTable("BirdSkill");

                entity.Property(e => e.Description)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.HasMany(d => d.Skills)
                    .WithMany(p => p.BirdSkills)
                    .UsingEntity<Dictionary<string, object>>(
                        "BirdSkillSkill",
                        l => l.HasOne<Skill>().WithMany().HasForeignKey("SkillId").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FKBirdSkill_313132"),
                        r => r.HasOne<BirdSkill>().WithMany().HasForeignKey("BirdSkillId").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FKBirdSkill_597548"),
                        j =>
                        {
                            j.HasKey("BirdSkillId", "SkillId").HasName("PK__BirdSkil__707AE50098245554");

                            j.ToTable("BirdSkill_Skill");
                        });
            });

            modelBuilder.Entity<BirdSpecies>(entity =>
            {
                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ShortDetailing)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasMany(d => d.BirdSkills)
                    .WithMany(p => p.BirdSpecies)
                    .UsingEntity<Dictionary<string, object>>(
                        "BirdBirdSkill",
                        l => l.HasOne<BirdSkill>().WithMany().HasForeignKey("BirdSkillId").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FKBird_BirdS32148"),
                        r => r.HasOne<BirdSpecies>().WithMany().HasForeignKey("BirdSpeciesId").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FKBird_BirdS645485"),
                        j =>
                        {
                            j.HasKey("BirdSpeciesId", "BirdSkillId").HasName("PK__Bird_Bir__4802579E32E38C32");

                            j.ToTable("Bird_BirdSkill");
                        });
            });

            modelBuilder.Entity<BirdTrainingCourse>(entity =>
            {
                entity.HasKey(e => new { e.BirdId, e.TrainingCourseId })
                    .HasName("PK__Bird_Tra__9B81A2E67A46410F");

                entity.ToTable("Bird_TrainingCourse");

                entity.Property(e => e.TotalPrice).HasColumnType("decimal(19, 0)");

                entity.Property(e => e.TrainingDoneDate).HasColumnType("date");

                entity.HasOne(d => d.Bird)
                    .WithMany(p => p.BirdTrainingCourses)
                    .HasForeignKey(d => d.BirdId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FKBird_Train718139");

                entity.HasOne(d => d.TrainingCourse)
                    .WithMany(p => p.BirdTrainingCourses)
                    .HasForeignKey(d => d.TrainingCourseId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FKBird_Train368802");
            });

            modelBuilder.Entity<BirdTrainingProgressDetail>(entity =>
            {
                entity.HasKey(e => new { e.TrainingCourseId, e.BirdId, e.TrainingCourseSkillId, e.TrainingDate })
                    .HasName("PK__Bird_Tra__9301C9FB4948EFF6");

                entity.ToTable("Bird_TrainingProgressDetail");

                entity.Property(e => e.TrainingCourseSkillId).HasColumnName("TrainingCourse_SkillId");

                entity.Property(e => e.TrainingDate).HasColumnType("date");

                entity.Property(e => e.Comment)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.TrainingDoneDate).HasColumnType("date");

                entity.HasOne(d => d.Trainer)
                    .WithMany(p => p.BirdTrainingProgressDetails)
                    .HasForeignKey(d => d.TrainerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FKBird_Train384902");

                entity.HasOne(d => d.BirdTrainingCourse)
                    .WithMany(p => p.BirdTrainingProgressDetails)
                    .HasForeignKey(d => new { d.BirdId, d.TrainingCourseId })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FKBird_Train887887");

                entity.HasOne(d => d.TrainingCourse)
                    .WithMany(p => p.BirdTrainingProgressDetails)
                    .HasForeignKey(d => new { d.TrainingCourseId, d.TrainingCourseSkillId })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FKBird_Train3921");
            });

            modelBuilder.Entity<Certificate>(entity =>
            {
                entity.ToTable("Certificate");

                entity.Property(e => e.BirdCenterName)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Picture)
                    .HasMaxLength(50)
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

            modelBuilder.Entity<ConsultingTicket>(entity =>
            {
                entity.ToTable("ConsultingTicket");

                entity.Property(e => e.ConsultingDetail)
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.Property(e => e.ExpectedDate).HasColumnType("date");

                entity.Property(e => e.Status)
                    .HasMaxLength(20)
                    .IsUnicode(false);

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

                entity.Property(e => e.Status)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Customers)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FKCustomer697132");
            });

            modelBuilder.Entity<CustomerCertificateDetail>(entity =>
            {
                entity.HasKey(e => new { e.CustomerId, e.CertificateId })
                    .HasName("PK__Customer__AF11EEA49A6E0156");

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
                    .HasName("PK__Customer__304EA37407243B83");

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
                    .HasName("PK__Customer__FFA1E3B7B9EC0406");

                entity.ToTable("Customer_OnlineCourseDetail");

                entity.Property(e => e.Price).HasColumnType("decimal(18, 0)");

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
                    .HasName("PK__Customer__9CA0945F6686510B");

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

            modelBuilder.Entity<CustomerWorkshopPayment>(entity =>
            {
                entity.HasKey(e => new { e.CustomerId, e.WorkshopId })
                    .HasName("PK__Customer__130E6C18194FF84B");

                entity.ToTable("Customer_WorkshopPayment");

                entity.Property(e => e.TotalPrice).HasColumnType("decimal(19, 0)");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.CustomerWorkshopPayments)
                    .HasForeignKey(d => d.CustomerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FKCustomer_W159704");

                entity.HasOne(d => d.Workshop)
                    .WithMany(p => p.CustomerWorkshopPayments)
                    .HasForeignKey(d => d.WorkshopId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FKCustomer_W948001");
            });

            modelBuilder.Entity<Day>(entity =>
            {
                entity.ToTable("Day");

                entity.HasOne(d => d.Week)
                    .WithMany(p => p.Days)
                    .HasForeignKey(d => d.WeekId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FKDay80207");
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

                entity.HasOne(d => d.FeedbackType)
                    .WithMany(p => p.Feedbacks)
                    .HasForeignKey(d => d.FeedbackTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FKFeedback625969");
            });

            modelBuilder.Entity<FeedbackType>(entity =>
            {
                entity.ToTable("FeedbackType");

                entity.Property(e => e.Name)
                    .HasMaxLength(200)
                    .IsUnicode(false);
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
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.Section)
                    .WithMany(p => p.Lessons)
                    .HasForeignKey(d => d.SectionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FKLesson170997");
            });

            modelBuilder.Entity<OnlineCourse>(entity =>
            {
                entity.ToTable("OnlineCourse");

                entity.Property(e => e.Price).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.ShortDescription)
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.Property(e => e.Status)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Title)
                    .HasMaxLength(300)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.ToTable("Role");

                entity.Property(e => e.Name)
                    .HasMaxLength(20)
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

                entity.Property(e => e.EndTime).HasColumnType("date");

                entity.Property(e => e.Reason)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.StartTime).HasColumnType("date");

                entity.HasOne(d => d.Day)
                    .WithMany(p => p.Slots)
                    .HasForeignKey(d => d.DayId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FKSlot458704");
            });

            modelBuilder.Entity<StaffBirdReceived>(entity =>
            {
                entity.ToTable("Staff_BirdReceived");

                entity.Property(e => e.ExpectedDateReturn).HasColumnType("date");

                entity.Property(e => e.FinalPrice).HasColumnType("decimal(19, 0)");

                entity.Property(e => e.ReceivedDate).HasColumnType("date");

                entity.Property(e => e.ReturnDate).HasColumnType("date");

                entity.Property(e => e.Status)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.TrainingDoneDate).HasColumnType("date");

                entity.HasOne(d => d.Bird)
                    .WithMany(p => p.StaffBirdReceiveds)
                    .HasForeignKey(d => d.BirdId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FKStaff_Bird531995");

                entity.HasOne(d => d.Staff)
                    .WithMany(p => p.StaffBirdReceiveds)
                    .HasForeignKey(d => d.StaffId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FKStaff_Bird786969");
            });

            modelBuilder.Entity<Trainer>(entity =>
            {
                entity.ToTable("Trainer");

                entity.Property(e => e.Picture)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.TotalWorktime)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Trainers)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FKTrainer76895");

                entity.HasMany(d => d.Skills)
                    .WithMany(p => p.Trainers)
                    .UsingEntity<Dictionary<string, object>>(
                        "TrainerSkill",
                        l => l.HasOne<Skill>().WithMany().HasForeignKey("SkillId").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FKTrainer_Sk368940"),
                        r => r.HasOne<Trainer>().WithMany().HasForeignKey("TrainerId").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FKTrainer_Sk733170"),
                        j =>
                        {
                            j.HasKey("TrainerId", "SkillId").HasName("PK__Trainer___5B901364C909FFE9");

                            j.ToTable("Trainer_Skill");
                        });

                entity.HasMany(d => d.Weeks)
                    .WithMany(p => p.Trainers)
                    .UsingEntity<Dictionary<string, object>>(
                        "TrainerTimetable",
                        l => l.HasOne<Week>().WithMany().HasForeignKey("WeekId").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FKTrainerTim233244"),
                        r => r.HasOne<Trainer>().WithMany().HasForeignKey("TrainerId").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FKTrainerTim272596"),
                        j =>
                        {
                            j.HasKey("TrainerId", "WeekId").HasName("PK__TrainerT__3AEB5020806E3330");

                            j.ToTable("TrainerTimetable");
                        });
            });

            modelBuilder.Entity<TrainerWorkshop>(entity =>
            {
                entity.HasKey(e => new { e.TrainerId, e.WorkshopId, e.JoinDate })
                    .HasName("PK__Trainer___2DF9DDE2553517B8");

                entity.ToTable("Trainer_Workshop");

                entity.Property(e => e.JoinDate).HasColumnType("date");

                entity.HasOne(d => d.Trainer)
                    .WithMany(p => p.TrainerWorkshops)
                    .HasForeignKey(d => d.TrainerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FKTrainer_Wo169003");

                entity.HasOne(d => d.Workshop)
                    .WithMany(p => p.TrainerWorkshops)
                    .HasForeignKey(d => d.WorkshopId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FKTrainer_Wo152749");
            });

            modelBuilder.Entity<TrainingCourse>(entity =>
            {
                entity.ToTable("TrainingCourse");

                entity.Property(e => e.Description)
                    .HasMaxLength(300)
                    .IsUnicode(false);

                entity.Property(e => e.Title)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.TotalPrice).HasColumnType("decimal(19, 0)");

                entity.HasOne(d => d.BirdSpecies)
                    .WithMany(p => p.TrainingCourses)
                    .HasForeignKey(d => d.BirdSpeciesId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FKTrainingCo245376");
            });

            modelBuilder.Entity<TrainingCourseBirdSkill>(entity =>
            {
                entity.HasKey(e => new { e.TrainingCourseId, e.BirdSkillId })
                    .HasName("PK__Training__4081104E953A6BF8");

                entity.ToTable("TrainingCourse_BirdSkill");

                entity.Property(e => e.Price).HasColumnType("decimal(19, 0)");

                entity.HasOne(d => d.BirdSkill)
                    .WithMany(p => p.TrainingCourseBirdSkills)
                    .HasForeignKey(d => d.BirdSkillId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FKTrainingCo817181");

                entity.HasOne(d => d.TrainingCourse)
                    .WithMany(p => p.TrainingCourseBirdSkills)
                    .HasForeignKey(d => d.TrainingCourseId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FKTrainingCo867576");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("User");

                entity.HasIndex(e => e.Email, "UQ__User__A9D105341D567186")
                    .IsUnique();

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

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.RoleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FKUser349727");
            });

            modelBuilder.Entity<BirdCertificateDetail>(entity =>
            {
                entity.HasKey(e => new { e.BirdId, e.BirdCertificateId })
                    .HasName("PK__UserBird__CB94077C7FDD8B75");

                entity.ToTable("UserBird_BirdCertificate");

                entity.Property(e => e.ReceiveDate).HasColumnType("date");

                entity.HasOne(d => d.BirdCertificate)
                    .WithMany(p => p.UserBirdBirdCertificates)
                    .HasForeignKey(d => d.BirdCertificateId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FKUserBird_B530426");

                entity.HasOne(d => d.Bird)
                    .WithMany(p => p.UserBirdBirdCertificates)
                    .HasForeignKey(d => d.BirdId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FKUserBird_B65788");
            });

            modelBuilder.Entity<Week>(entity =>
            {
                entity.ToTable("Week");

                entity.Property(e => e.EndDate).HasColumnType("date");

                entity.Property(e => e.StartDate).HasColumnType("date");
            });

            modelBuilder.Entity<WorkShopCategory>(entity =>
            {
                entity.ToTable("WorkShopCategory");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Workshop>(entity =>
            {
                entity.ToTable("Workshop");

                entity.Property(e => e.Description)
                    .HasMaxLength(2000)
                    .IsUnicode(false);

                entity.Property(e => e.Price).HasColumnType("decimal(19, 0)");

                entity.Property(e => e.RegisterEndDate).HasColumnType("date");

                entity.Property(e => e.StartTime).HasColumnType("date");

                entity.Property(e => e.Title)
                    .HasMaxLength(300)
                    .IsUnicode(false);

                entity.HasOne(d => d.WorkShopCategory)
                    .WithMany(p => p.Workshops)
                    .HasForeignKey(d => d.WorkShopCategoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FKWorkshop329050");
            });

            modelBuilder.Entity<WorkshopAttendance>(entity =>
            {
                entity.ToTable("WorkshopAttendance");

                entity.Property(e => e.AttendDate).HasColumnType("date");

                entity.HasOne(d => d.CustomerWorkshopPayment)
                    .WithMany(p => p.WorkshopAttendances)
                    .HasForeignKey(d => new { d.CustomerId, d.WorkshopId })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FKWorkshopAt465292");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
