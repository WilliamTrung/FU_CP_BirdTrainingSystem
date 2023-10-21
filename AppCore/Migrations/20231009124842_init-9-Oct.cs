using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace AppCore.Migrations
{
    public partial class init9Oct : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BirdSkill",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "character varying(200)", unicode: false, maxLength: 200, nullable: false),
                    Description = table.Column<string>(type: "character varying(200)", unicode: false, maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BirdSkill", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BirdSpecies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "character varying(50)", unicode: false, maxLength: 50, nullable: false),
                    ShortDetail = table.Column<string>(type: "character varying(100)", unicode: false, maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BirdSpecies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ConsultingPricePolicy",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Price = table.Column<decimal>(type: "money", nullable: false),
                    OnlineOrOffline = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConsultingPricePolicy", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ConsultingType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "character varying(200)", unicode: false, maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConsultingType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DistancePrice",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ConsultingPricePolicyId = table.Column<int>(type: "integer", nullable: false),
                    From = table.Column<int>(type: "integer", nullable: true),
                    To = table.Column<int>(type: "integer", nullable: true),
                    PricePerKm = table.Column<decimal>(type: "money", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DistancePrice", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FeedbackType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "character varying(100)", unicode: false, maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FeedbackType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MembershipRank",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "character varying(50)", unicode: false, maxLength: 50, nullable: true),
                    Discount = table.Column<float>(type: "real", nullable: true),
                    Requirement = table.Column<decimal>(type: "money", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MembershipRank", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OnlineCourse",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Title = table.Column<string>(type: "character varying(300)", unicode: false, maxLength: 300, nullable: true),
                    ShortDescription = table.Column<string>(type: "character varying(1000)", unicode: false, maxLength: 1000, nullable: true),
                    Picture = table.Column<string>(type: "character varying(50)", unicode: false, maxLength: 50, nullable: true),
                    Price = table.Column<decimal>(type: "money", nullable: true),
                    Status = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OnlineCourse", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Skill",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "character varying(200)", unicode: false, maxLength: 200, nullable: false),
                    Description = table.Column<string>(type: "character varying(200)", unicode: false, maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Skill", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Slot",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    StartTime = table.Column<TimeSpan>(type: "interval", nullable: true),
                    EndTime = table.Column<TimeSpan>(type: "interval", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Slot", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "character varying(100)", unicode: false, maxLength: 100, nullable: true),
                    Email = table.Column<string>(type: "character varying(100)", unicode: false, maxLength: 100, nullable: false),
                    PhoneNumber = table.Column<decimal>(type: "numeric(18,0)", nullable: true),
                    Avatar = table.Column<string>(type: "character varying(20)", unicode: false, maxLength: 20, nullable: true),
                    Password = table.Column<string>(type: "character varying(255)", unicode: false, maxLength: 255, nullable: false),
                    RoleId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WorkshopRefundPolicy",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    TotalDayBeforeStart = table.Column<int>(type: "integer", nullable: false),
                    RefundRate = table.Column<float>(type: "real", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkshopRefundPolicy", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AcquirableSkill",
                columns: table => new
                {
                    BirdSpeciesId = table.Column<int>(type: "integer", nullable: false),
                    BirdSkillId = table.Column<int>(type: "integer", nullable: false),
                    Condition = table.Column<string>(type: "character varying(30)", unicode: false, maxLength: 30, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Acquirab__4802579ED65DE48A", x => new { x.BirdSpeciesId, x.BirdSkillId });
                    table.ForeignKey(
                        name: "FKAcquirable305826",
                        column: x => x.BirdSkillId,
                        principalTable: "BirdSkill",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FKAcquirable80836",
                        column: x => x.BirdSpeciesId,
                        principalTable: "BirdSpecies",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "TrainingCourse",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    BirdSpeciesId = table.Column<int>(type: "integer", nullable: false),
                    Title = table.Column<string>(type: "character varying(100)", unicode: false, maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "character varying(300)", unicode: false, maxLength: 300, nullable: true),
                    Picture = table.Column<string>(type: "character varying(50)", unicode: false, maxLength: 50, nullable: true),
                    TotalSlot = table.Column<int>(type: "integer", nullable: false),
                    TotalPrice = table.Column<decimal>(type: "money", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrainingCourse", x => x.Id);
                    table.ForeignKey(
                        name: "FKTrainingCo245376",
                        column: x => x.BirdSpeciesId,
                        principalTable: "BirdSpecies",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Certificate",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    OnlineCourseId = table.Column<int>(type: "integer", nullable: false),
                    BirdCenterName = table.Column<string>(type: "character varying(100)", unicode: false, maxLength: 100, nullable: false),
                    Title = table.Column<string>(type: "character varying(300)", unicode: false, maxLength: 300, nullable: true),
                    ShortDescrption = table.Column<string>(type: "character varying(500)", unicode: false, maxLength: 500, nullable: true),
                    Picture = table.Column<string>(type: "character varying(50)", unicode: false, maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Certificate", x => x.Id);
                    table.ForeignKey(
                        name: "FKCertificat555329",
                        column: x => x.OnlineCourseId,
                        principalTable: "OnlineCourse",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Section",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    OnlineCourseId = table.Column<int>(type: "integer", nullable: false),
                    Title = table.Column<string>(type: "character varying(300)", unicode: false, maxLength: 300, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Section", x => x.Id);
                    table.ForeignKey(
                        name: "FKSection929188",
                        column: x => x.OnlineCourseId,
                        principalTable: "OnlineCourse",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "TrainableSkill",
                columns: table => new
                {
                    BirdSkillId = table.Column<int>(type: "integer", nullable: false),
                    SkillId = table.Column<int>(type: "integer", nullable: false),
                    ShortDescription = table.Column<string>(type: "character varying(100)", unicode: false, maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Trainabl__707AE500702FFB55", x => new { x.BirdSkillId, x.SkillId });
                    table.ForeignKey(
                        name: "FKTrainableS485101",
                        column: x => x.BirdSkillId,
                        principalTable: "BirdSkill",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FKTrainableS574420",
                        column: x => x.SkillId,
                        principalTable: "Skill",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "CenterSlot",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    SlotId = table.Column<int>(type: "integer", nullable: false),
                    Date = table.Column<DateTime>(type: "date", nullable: false),
                    Status = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CenterSlot", x => x.Id);
                    table.ForeignKey(
                        name: "FKCenterSlot412931",
                        column: x => x.SlotId,
                        principalTable: "Slot",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Customer",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<int>(type: "integer", nullable: false),
                    MembershipRankId = table.Column<int>(type: "integer", nullable: false),
                    BirthDay = table.Column<DateTime>(type: "date", nullable: true),
                    Gender = table.Column<bool>(type: "boolean", nullable: true),
                    TotalPayment = table.Column<decimal>(type: "money", nullable: true),
                    Status = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customer", x => x.Id);
                    table.ForeignKey(
                        name: "FKCustomer697132",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FKCustomer774542",
                        column: x => x.MembershipRankId,
                        principalTable: "MembershipRank",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Trainer",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<int>(type: "integer", nullable: false),
                    BirthDay = table.Column<DateTime>(type: "date", nullable: true),
                    Gender = table.Column<bool>(type: "boolean", nullable: true),
                    IsFullTime = table.Column<bool>(type: "boolean", nullable: false),
                    Status = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trainer", x => x.Id);
                    table.ForeignKey(
                        name: "FKTrainer76895",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Workshop",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    WorkshopRefundPolicyId = table.Column<int>(type: "integer", nullable: false),
                    Title = table.Column<string>(type: "character varying(300)", unicode: false, maxLength: 300, nullable: false),
                    Description = table.Column<string>(type: "character varying(2000)", unicode: false, maxLength: 2000, nullable: true),
                    Picture = table.Column<string>(type: "character varying(50)", unicode: false, maxLength: 50, nullable: true),
                    RegisterEnd = table.Column<int>(type: "integer", nullable: true),
                    Price = table.Column<decimal>(type: "money", nullable: false),
                    TotalSlot = table.Column<int>(type: "integer", nullable: false),
                    Status = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Workshop", x => x.Id);
                    table.ForeignKey(
                        name: "FKWorkshop234277",
                        column: x => x.WorkshopRefundPolicyId,
                        principalTable: "WorkshopRefundPolicy",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "BirdCertificate",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    TrainingCourseId = table.Column<int>(type: "integer", nullable: false),
                    BirdCenterName = table.Column<string>(type: "character varying(100)", unicode: false, maxLength: 100, nullable: true),
                    Title = table.Column<string>(type: "character varying(300)", unicode: false, maxLength: 300, nullable: false),
                    ShortDescrption = table.Column<string>(type: "character varying(500)", unicode: false, maxLength: 500, nullable: true),
                    Picture = table.Column<string>(type: "character varying(50)", unicode: false, maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BirdCertificate", x => x.Id);
                    table.ForeignKey(
                        name: "FKBirdCertif231604",
                        column: x => x.TrainingCourseId,
                        principalTable: "TrainingCourse",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "TrainingCourseSkill",
                columns: table => new
                {
                    BirdSkillId = table.Column<int>(type: "integer", nullable: false),
                    TrainingCourseId = table.Column<int>(type: "integer", nullable: false),
                    Status = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Training__1D80EC1800FBBDDE", x => x.BirdSkillId);
                    table.ForeignKey(
                        name: "FKTrainingCo551235",
                        column: x => x.BirdSkillId,
                        principalTable: "BirdSkill",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FKTrainingCo866476",
                        column: x => x.TrainingCourseId,
                        principalTable: "TrainingCourse",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Lesson",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    SectionId = table.Column<int>(type: "integer", nullable: false),
                    Title = table.Column<string>(type: "character varying(300)", unicode: false, maxLength: 300, nullable: false),
                    Description = table.Column<string>(type: "character varying(1000)", unicode: false, maxLength: 1000, nullable: true),
                    Detail = table.Column<string>(type: "character varying(1000)", unicode: false, maxLength: 1000, nullable: true),
                    Video = table.Column<string>(type: "character varying(100)", unicode: false, maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lesson", x => x.Id);
                    table.ForeignKey(
                        name: "FKLesson170997",
                        column: x => x.SectionId,
                        principalTable: "Section",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Address",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CustomerId = table.Column<int>(type: "integer", nullable: false),
                    AddressDetail = table.Column<string>(type: "character varying(50)", unicode: false, maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Address", x => x.Id);
                    table.ForeignKey(
                        name: "FKAddress64774",
                        column: x => x.CustomerId,
                        principalTable: "Customer",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Bird",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CustomerId = table.Column<int>(type: "integer", nullable: false),
                    BirdSpeciesId = table.Column<int>(type: "integer", nullable: false),
                    Name = table.Column<string>(type: "character varying(50)", unicode: false, maxLength: 50, nullable: true),
                    Color = table.Column<string>(type: "character varying(30)", unicode: false, maxLength: 30, nullable: true),
                    Picture = table.Column<string>(type: "character varying(50)", unicode: false, maxLength: 50, nullable: true),
                    Description = table.Column<string>(type: "character varying(255)", unicode: false, maxLength: 255, nullable: true),
                    IsDefault = table.Column<bool>(type: "boolean", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bird", x => x.Id);
                    table.ForeignKey(
                        name: "FKBird173768",
                        column: x => x.CustomerId,
                        principalTable: "Customer",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FKBird650663",
                        column: x => x.BirdSpeciesId,
                        principalTable: "BirdSpecies",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Customer_CertificateDetail",
                columns: table => new
                {
                    CustomerId = table.Column<int>(type: "integer", nullable: false),
                    CertificateId = table.Column<int>(type: "integer", nullable: false),
                    ReceiveDate = table.Column<DateTime>(type: "date", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Customer__AF11EEA4285B300D", x => new { x.CustomerId, x.CertificateId });
                    table.ForeignKey(
                        name: "FKCustomer_C508581",
                        column: x => x.CertificateId,
                        principalTable: "Certificate",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FKCustomer_C859755",
                        column: x => x.CustomerId,
                        principalTable: "Customer",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Customer_OnlineCourseDetail",
                columns: table => new
                {
                    CustomerId = table.Column<int>(type: "integer", nullable: false),
                    OnlineCourseId = table.Column<int>(type: "integer", nullable: false),
                    Price = table.Column<decimal>(type: "money", nullable: true),
                    DiscountedPrice = table.Column<decimal>(type: "money", nullable: true),
                    Status = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Customer__FFA1E3B752290968", x => new { x.CustomerId, x.OnlineCourseId });
                    table.ForeignKey(
                        name: "FKCustomer_O139976",
                        column: x => x.CustomerId,
                        principalTable: "Customer",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FKCustomer_O181189",
                        column: x => x.OnlineCourseId,
                        principalTable: "OnlineCourse",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Customer_SectionDetail",
                columns: table => new
                {
                    CustomerId = table.Column<int>(type: "integer", nullable: false),
                    SectionId = table.Column<int>(type: "integer", nullable: false),
                    IsComplete = table.Column<bool>(type: "boolean", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Customer__9CA0945FD7808FAD", x => new { x.CustomerId, x.SectionId });
                    table.ForeignKey(
                        name: "FKCustomer_S58540",
                        column: x => x.CustomerId,
                        principalTable: "Customer",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FKCustomer_S977222",
                        column: x => x.SectionId,
                        principalTable: "Section",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Feedback",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    FeedbackTypeId = table.Column<int>(type: "integer", nullable: false),
                    CustomerId = table.Column<int>(type: "integer", nullable: false),
                    EntityTypeId = table.Column<int>(type: "integer", nullable: false),
                    EntityId = table.Column<int>(type: "integer", nullable: true),
                    FeedbackDetail = table.Column<string>(type: "character varying(200)", unicode: false, maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Feedback", x => x.Id);
                    table.ForeignKey(
                        name: "FKFeedback245587",
                        column: x => x.CustomerId,
                        principalTable: "Customer",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FKFeedback625969",
                        column: x => x.FeedbackTypeId,
                        principalTable: "FeedbackType",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Transaction",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CustomerId = table.Column<int>(type: "integer", nullable: false),
                    Title = table.Column<string>(type: "character varying(50)", unicode: false, maxLength: 50, nullable: true),
                    Detail = table.Column<string>(type: "character varying(100)", unicode: false, maxLength: 100, nullable: true),
                    DateCreate = table.Column<DateTime>(type: "date", nullable: false),
                    PaymentDate = table.Column<DateTime>(type: "date", nullable: true),
                    EntityTypeId = table.Column<int>(type: "integer", nullable: true),
                    EntityId = table.Column<int>(type: "integer", nullable: true),
                    TotalPayment = table.Column<decimal>(type: "money", nullable: true),
                    PaymentCode = table.Column<string>(type: "character varying(100)", unicode: false, maxLength: 100, nullable: true),
                    Status = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transaction", x => x.Id);
                    table.ForeignKey(
                        name: "FKTransactio250053",
                        column: x => x.CustomerId,
                        principalTable: "Customer",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Trainer_Skill",
                columns: table => new
                {
                    TrainerId = table.Column<int>(type: "integer", nullable: false),
                    SkillId = table.Column<int>(type: "integer", nullable: false),
                    Description = table.Column<string>(type: "character varying(50)", unicode: false, maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Trainer___5B9013647216435F", x => new { x.TrainerId, x.SkillId });
                    table.ForeignKey(
                        name: "FKTrainer_Sk368940",
                        column: x => x.SkillId,
                        principalTable: "Skill",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FKTrainer_Sk733170",
                        column: x => x.TrainerId,
                        principalTable: "Trainer",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "TrainerSlot",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    TrainerId = table.Column<int>(type: "integer", nullable: false),
                    SlotId = table.Column<int>(type: "integer", nullable: false),
                    Date = table.Column<DateTime>(type: "date", nullable: false),
                    Reason = table.Column<string>(type: "character varying(100)", unicode: false, maxLength: 100, nullable: true),
                    EntityTypeId = table.Column<int>(type: "integer", nullable: false),
                    EntityId = table.Column<int>(type: "integer", nullable: true),
                    Status = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrainerSlot", x => x.Id);
                    table.ForeignKey(
                        name: "FKTrainerSlo815026",
                        column: x => x.TrainerId,
                        principalTable: "Trainer",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FKTrainerSlo833189",
                        column: x => x.SlotId,
                        principalTable: "Slot",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "WorkshopClass",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    WorkshopId = table.Column<int>(type: "integer", nullable: false),
                    RegisterEndDate = table.Column<DateTime>(type: "date", nullable: true),
                    StartTime = table.Column<DateTime>(type: "date", nullable: true),
                    Status = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkshopClass", x => x.Id);
                    table.ForeignKey(
                        name: "FKWorkshopCl950556",
                        column: x => x.WorkshopId,
                        principalTable: "Workshop",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "BirdCertificateSkill",
                columns: table => new
                {
                    BirdSkillId = table.Column<int>(type: "integer", nullable: false),
                    BirdCertificateId = table.Column<int>(type: "integer", nullable: false),
                    ReceivedDate = table.Column<DateTime>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__BirdCert__A080D86A13A8CDEA", x => new { x.BirdSkillId, x.BirdCertificateId });
                    table.ForeignKey(
                        name: "FKBirdCertif163982",
                        column: x => x.BirdSkillId,
                        principalTable: "BirdSkill",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FKBirdCertif72357",
                        column: x => x.BirdCertificateId,
                        principalTable: "BirdCertificate",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Customer_LessonDetail",
                columns: table => new
                {
                    CustomerId = table.Column<int>(type: "integer", nullable: false),
                    LessionId = table.Column<int>(type: "integer", nullable: false),
                    IsComplete = table.Column<bool>(type: "boolean", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Customer__304EA374D2BD3A0D", x => new { x.CustomerId, x.LessionId });
                    table.ForeignKey(
                        name: "FKCustomer_L582869",
                        column: x => x.LessionId,
                        principalTable: "Lesson",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FKCustomer_L809461",
                        column: x => x.CustomerId,
                        principalTable: "Customer",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ConsultingTicket",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CustomerId = table.Column<int>(type: "integer", nullable: false),
                    AddressId = table.Column<int>(type: "integer", nullable: false),
                    ConsultingTypeId = table.Column<int>(type: "integer", nullable: false),
                    TrainerId = table.Column<int>(type: "integer", nullable: false),
                    ExpectedDate = table.Column<DateTime>(type: "date", nullable: true),
                    ExpectedSlotStart = table.Column<int>(type: "integer", nullable: true),
                    ExpectedSlotEnd = table.Column<int>(type: "integer", nullable: true),
                    ConsultingDetail = table.Column<string>(type: "character varying(1000)", unicode: false, maxLength: 1000, nullable: true),
                    Distance = table.Column<int>(type: "integer", nullable: true),
                    OnlineOrOffline = table.Column<bool>(type: "boolean", nullable: false),
                    GgMeetLink = table.Column<string>(type: "character varying(20)", unicode: false, maxLength: 20, nullable: true),
                    AppointmentDate = table.Column<DateTime>(type: "date", nullable: true),
                    ActualSlotStart = table.Column<int>(type: "integer", nullable: true),
                    ActualEndSlot = table.Column<int>(type: "integer", nullable: true),
                    Evidence = table.Column<string>(type: "character varying(50)", unicode: false, maxLength: 50, nullable: true),
                    Price = table.Column<decimal>(type: "money", nullable: true),
                    DiscountedPrice = table.Column<decimal>(type: "money", nullable: true),
                    Status = table.Column<int>(type: "integer", nullable: false),
                    ConsultingPricePolicyId = table.Column<int>(type: "integer", nullable: false),
                    DistancePriceId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConsultingTicket", x => x.Id);
                    table.ForeignKey(
                        name: "FKConsulting154539",
                        column: x => x.CustomerId,
                        principalTable: "Customer",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FKConsulting196354",
                        column: x => x.ConsultingPricePolicyId,
                        principalTable: "ConsultingPricePolicy",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FKConsulting220553",
                        column: x => x.AddressId,
                        principalTable: "Address",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FKConsulting31098",
                        column: x => x.TrainerId,
                        principalTable: "Trainer",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FKConsulting521439",
                        column: x => x.ConsultingTypeId,
                        principalTable: "ConsultingType",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FKConsulting564465",
                        column: x => x.DistancePriceId,
                        principalTable: "DistancePrice",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Bird_TrainingCourse",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    BirdId = table.Column<int>(type: "integer", nullable: false),
                    TrainingCourseId = table.Column<int>(type: "integer", nullable: false),
                    StaffId = table.Column<int>(type: "integer", nullable: false),
                    CustomerId = table.Column<int>(type: "integer", nullable: false),
                    TotalPrice = table.Column<decimal>(type: "money", nullable: true),
                    DiscountedPrice = table.Column<decimal>(type: "money", nullable: true),
                    ExpectedStartDate = table.Column<DateTime>(type: "date", nullable: true),
                    ActualStartDate = table.Column<DateTime>(type: "date", nullable: true),
                    DateReceivedBird = table.Column<DateTime>(type: "date", nullable: true),
                    ReceiveNote = table.Column<string>(type: "character varying(255)", unicode: false, maxLength: 255, nullable: true),
                    ReceivePicture = table.Column<string>(type: "character varying(20)", unicode: false, maxLength: 20, nullable: true),
                    ExpectedDateReturn = table.Column<DateTime>(type: "date", nullable: true),
                    TrainingDoneDate = table.Column<DateTime>(type: "date", nullable: true),
                    ActualDateReturn = table.Column<DateTime>(type: "date", nullable: true),
                    ReturnNote = table.Column<string>(type: "character varying(255)", unicode: false, maxLength: 255, nullable: true),
                    ReturnPicture = table.Column<string>(type: "character varying(20)", unicode: false, maxLength: 20, nullable: true),
                    LastestUpdate = table.Column<DateTime>(type: "date", nullable: true),
                    Status = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bird_TrainingCourse", x => x.Id);
                    table.ForeignKey(
                        name: "FKBird_Train368802",
                        column: x => x.TrainingCourseId,
                        principalTable: "TrainingCourse",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FKBird_Train718139",
                        column: x => x.BirdId,
                        principalTable: "Bird",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FKBird_Train934485",
                        column: x => x.StaffId,
                        principalTable: "User",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "BirdCertificateDetail",
                columns: table => new
                {
                    BirdId = table.Column<int>(type: "integer", nullable: false),
                    BirdCertificateId = table.Column<int>(type: "integer", nullable: false),
                    ReceiveDate = table.Column<DateTime>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__BirdCert__CB94077C4F80D508", x => new { x.BirdId, x.BirdCertificateId });
                    table.ForeignKey(
                        name: "FKBirdCertif464427",
                        column: x => x.BirdCertificateId,
                        principalTable: "BirdCertificate",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FKBirdCertif999788",
                        column: x => x.BirdId,
                        principalTable: "Bird",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Customer_WorkshopClass",
                columns: table => new
                {
                    CustomerId = table.Column<int>(type: "integer", nullable: false),
                    WorkshopClassId = table.Column<int>(type: "integer", nullable: false),
                    Price = table.Column<decimal>(type: "money", nullable: true),
                    DiscountedPrice = table.Column<decimal>(type: "money", nullable: true),
                    RefundRate = table.Column<float>(type: "real", nullable: true),
                    Status = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Customer__7EEF8348F780826E", x => new { x.CustomerId, x.WorkshopClassId });
                    table.ForeignKey(
                        name: "FKCustomer_W257990",
                        column: x => x.WorkshopClassId,
                        principalTable: "WorkshopClass",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FKCustomer_W416862",
                        column: x => x.CustomerId,
                        principalTable: "Customer",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "WorkshopAttendance",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    AttendDate = table.Column<DateTime>(type: "date", nullable: true),
                    CustomerId = table.Column<int>(type: "integer", nullable: false),
                    WorkshopClassId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkshopAttendance", x => x.Id);
                    table.ForeignKey(
                        name: "FKWorkshopAt124181",
                        column: x => x.CustomerId,
                        principalTable: "Customer",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FKWorkshopAt172557",
                        column: x => x.WorkshopClassId,
                        principalTable: "WorkshopClass",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "WorkshopClassDetail",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    WorkshopClassId = table.Column<int>(type: "integer", nullable: false),
                    DaySlotId = table.Column<int>(type: "integer", nullable: true),
                    Detail = table.Column<string>(type: "character varying(500)", unicode: false, maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkshopClassDetail", x => x.Id);
                    table.ForeignKey(
                        name: "FKWorkshopCl141743",
                        column: x => x.WorkshopClassId,
                        principalTable: "WorkshopClass",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FKWorkshopCl467642",
                        column: x => x.DaySlotId,
                        principalTable: "TrainerSlot",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "AdditionalConsultingBill",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ConsultingTicketId = table.Column<int>(type: "integer", nullable: false),
                    TotalPrice = table.Column<decimal>(type: "money", nullable: true),
                    Evidence = table.Column<string>(type: "character varying(50)", unicode: false, maxLength: 50, nullable: true),
                    DiscountedPrice = table.Column<decimal>(type: "money", nullable: true),
                    Status = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdditionalConsultingBill", x => x.Id);
                    table.ForeignKey(
                        name: "FKAdditional256950",
                        column: x => x.ConsultingTicketId,
                        principalTable: "ConsultingTicket",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Bird_TrainingProgress",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Bird_TrainingCourseId = table.Column<int>(type: "integer", nullable: false),
                    TrainingCourse_SkillId = table.Column<int>(type: "integer", nullable: false),
                    TrainerId = table.Column<int>(type: "integer", nullable: false),
                    TrainingDoneDate = table.Column<DateTime>(type: "date", nullable: true),
                    IsComplete = table.Column<bool>(type: "boolean", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bird_TrainingProgress", x => x.Id);
                    table.ForeignKey(
                        name: "FKBird_Train174512",
                        column: x => x.TrainingCourse_SkillId,
                        principalTable: "TrainingCourseSkill",
                        principalColumn: "BirdSkillId");
                    table.ForeignKey(
                        name: "FKBird_Train409415",
                        column: x => x.Bird_TrainingCourseId,
                        principalTable: "Bird_TrainingCourse",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FKBird_Train934988",
                        column: x => x.TrainerId,
                        principalTable: "Trainer",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "BirdTrainingReport",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Bird_TrainingCourseId = table.Column<int>(type: "integer", nullable: false),
                    TrainerId = table.Column<int>(type: "integer", nullable: false),
                    Comment = table.Column<string>(type: "character varying(200)", unicode: false, maxLength: 200, nullable: true),
                    Progress = table.Column<float>(type: "real", nullable: true),
                    DateCreate = table.Column<DateTime>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BirdTrainingReport", x => x.Id);
                    table.ForeignKey(
                        name: "FKBirdTraini11695",
                        column: x => x.Bird_TrainingCourseId,
                        principalTable: "Bird_TrainingCourse",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FKBirdTraini332709",
                        column: x => x.TrainerId,
                        principalTable: "Trainer",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_AcquirableSkill_BirdSkillId",
                table: "AcquirableSkill",
                column: "BirdSkillId");

            migrationBuilder.CreateIndex(
                name: "IX_AdditionalConsultingBill_ConsultingTicketId",
                table: "AdditionalConsultingBill",
                column: "ConsultingTicketId");

            migrationBuilder.CreateIndex(
                name: "IX_Address_CustomerId",
                table: "Address",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Bird_BirdSpeciesId",
                table: "Bird",
                column: "BirdSpeciesId");

            migrationBuilder.CreateIndex(
                name: "IX_Bird_CustomerId",
                table: "Bird",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Bird_TrainingCourse_BirdId",
                table: "Bird_TrainingCourse",
                column: "BirdId");

            migrationBuilder.CreateIndex(
                name: "IX_Bird_TrainingCourse_StaffId",
                table: "Bird_TrainingCourse",
                column: "StaffId");

            migrationBuilder.CreateIndex(
                name: "IX_Bird_TrainingCourse_TrainingCourseId",
                table: "Bird_TrainingCourse",
                column: "TrainingCourseId");

            migrationBuilder.CreateIndex(
                name: "IX_Bird_TrainingProgress_Bird_TrainingCourseId",
                table: "Bird_TrainingProgress",
                column: "Bird_TrainingCourseId");

            migrationBuilder.CreateIndex(
                name: "IX_Bird_TrainingProgress_TrainerId",
                table: "Bird_TrainingProgress",
                column: "TrainerId");

            migrationBuilder.CreateIndex(
                name: "IX_Bird_TrainingProgress_TrainingCourse_SkillId",
                table: "Bird_TrainingProgress",
                column: "TrainingCourse_SkillId");

            migrationBuilder.CreateIndex(
                name: "IX_BirdCertificate_TrainingCourseId",
                table: "BirdCertificate",
                column: "TrainingCourseId");

            migrationBuilder.CreateIndex(
                name: "IX_BirdCertificateDetail_BirdCertificateId",
                table: "BirdCertificateDetail",
                column: "BirdCertificateId");

            migrationBuilder.CreateIndex(
                name: "IX_BirdCertificateSkill_BirdCertificateId",
                table: "BirdCertificateSkill",
                column: "BirdCertificateId");

            migrationBuilder.CreateIndex(
                name: "IX_BirdTrainingReport_Bird_TrainingCourseId",
                table: "BirdTrainingReport",
                column: "Bird_TrainingCourseId");

            migrationBuilder.CreateIndex(
                name: "IX_BirdTrainingReport_TrainerId",
                table: "BirdTrainingReport",
                column: "TrainerId");

            migrationBuilder.CreateIndex(
                name: "IX_CenterSlot_SlotId",
                table: "CenterSlot",
                column: "SlotId");

            migrationBuilder.CreateIndex(
                name: "IX_Certificate_OnlineCourseId",
                table: "Certificate",
                column: "OnlineCourseId");

            migrationBuilder.CreateIndex(
                name: "IX_ConsultingTicket_AddressId",
                table: "ConsultingTicket",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_ConsultingTicket_ConsultingPricePolicyId",
                table: "ConsultingTicket",
                column: "ConsultingPricePolicyId");

            migrationBuilder.CreateIndex(
                name: "IX_ConsultingTicket_ConsultingTypeId",
                table: "ConsultingTicket",
                column: "ConsultingTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_ConsultingTicket_CustomerId",
                table: "ConsultingTicket",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_ConsultingTicket_DistancePriceId",
                table: "ConsultingTicket",
                column: "DistancePriceId");

            migrationBuilder.CreateIndex(
                name: "IX_ConsultingTicket_TrainerId",
                table: "ConsultingTicket",
                column: "TrainerId");

            migrationBuilder.CreateIndex(
                name: "IX_Customer_MembershipRankId",
                table: "Customer",
                column: "MembershipRankId");

            migrationBuilder.CreateIndex(
                name: "IX_Customer_UserId",
                table: "Customer",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Customer_CertificateDetail_CertificateId",
                table: "Customer_CertificateDetail",
                column: "CertificateId");

            migrationBuilder.CreateIndex(
                name: "IX_Customer_LessonDetail_LessionId",
                table: "Customer_LessonDetail",
                column: "LessionId");

            migrationBuilder.CreateIndex(
                name: "IX_Customer_OnlineCourseDetail_OnlineCourseId",
                table: "Customer_OnlineCourseDetail",
                column: "OnlineCourseId");

            migrationBuilder.CreateIndex(
                name: "IX_Customer_SectionDetail_SectionId",
                table: "Customer_SectionDetail",
                column: "SectionId");

            migrationBuilder.CreateIndex(
                name: "IX_Customer_WorkshopClass_WorkshopClassId",
                table: "Customer_WorkshopClass",
                column: "WorkshopClassId");

            migrationBuilder.CreateIndex(
                name: "IX_Feedback_CustomerId",
                table: "Feedback",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Feedback_FeedbackTypeId",
                table: "Feedback",
                column: "FeedbackTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Lesson_SectionId",
                table: "Lesson",
                column: "SectionId");

            migrationBuilder.CreateIndex(
                name: "IX_Section_OnlineCourseId",
                table: "Section",
                column: "OnlineCourseId");

            migrationBuilder.CreateIndex(
                name: "IX_TrainableSkill_SkillId",
                table: "TrainableSkill",
                column: "SkillId");

            migrationBuilder.CreateIndex(
                name: "IX_Trainer_UserId",
                table: "Trainer",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Trainer_Skill_SkillId",
                table: "Trainer_Skill",
                column: "SkillId");

            migrationBuilder.CreateIndex(
                name: "IX_TrainerSlot_SlotId",
                table: "TrainerSlot",
                column: "SlotId");

            migrationBuilder.CreateIndex(
                name: "IX_TrainerSlot_TrainerId",
                table: "TrainerSlot",
                column: "TrainerId");

            migrationBuilder.CreateIndex(
                name: "IX_TrainingCourse_BirdSpeciesId",
                table: "TrainingCourse",
                column: "BirdSpeciesId");

            migrationBuilder.CreateIndex(
                name: "IX_TrainingCourseSkill_TrainingCourseId",
                table: "TrainingCourseSkill",
                column: "TrainingCourseId");

            migrationBuilder.CreateIndex(
                name: "IX_Transaction_CustomerId",
                table: "Transaction",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "UQ__User__85FB4E38D8923EE1",
                table: "User",
                column: "PhoneNumber",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "UQ__User__A9D1053429005A0E",
                table: "User",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Workshop_WorkshopRefundPolicyId",
                table: "Workshop",
                column: "WorkshopRefundPolicyId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkshopAttendance_CustomerId",
                table: "WorkshopAttendance",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkshopAttendance_WorkshopClassId",
                table: "WorkshopAttendance",
                column: "WorkshopClassId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkshopClass_WorkshopId",
                table: "WorkshopClass",
                column: "WorkshopId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkshopClassDetail_DaySlotId",
                table: "WorkshopClassDetail",
                column: "DaySlotId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkshopClassDetail_WorkshopClassId",
                table: "WorkshopClassDetail",
                column: "WorkshopClassId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AcquirableSkill");

            migrationBuilder.DropTable(
                name: "AdditionalConsultingBill");

            migrationBuilder.DropTable(
                name: "Bird_TrainingProgress");

            migrationBuilder.DropTable(
                name: "BirdCertificateDetail");

            migrationBuilder.DropTable(
                name: "BirdCertificateSkill");

            migrationBuilder.DropTable(
                name: "BirdTrainingReport");

            migrationBuilder.DropTable(
                name: "CenterSlot");

            migrationBuilder.DropTable(
                name: "Customer_CertificateDetail");

            migrationBuilder.DropTable(
                name: "Customer_LessonDetail");

            migrationBuilder.DropTable(
                name: "Customer_OnlineCourseDetail");

            migrationBuilder.DropTable(
                name: "Customer_SectionDetail");

            migrationBuilder.DropTable(
                name: "Customer_WorkshopClass");

            migrationBuilder.DropTable(
                name: "Feedback");

            migrationBuilder.DropTable(
                name: "TrainableSkill");

            migrationBuilder.DropTable(
                name: "Trainer_Skill");

            migrationBuilder.DropTable(
                name: "Transaction");

            migrationBuilder.DropTable(
                name: "WorkshopAttendance");

            migrationBuilder.DropTable(
                name: "WorkshopClassDetail");

            migrationBuilder.DropTable(
                name: "ConsultingTicket");

            migrationBuilder.DropTable(
                name: "TrainingCourseSkill");

            migrationBuilder.DropTable(
                name: "BirdCertificate");

            migrationBuilder.DropTable(
                name: "Bird_TrainingCourse");

            migrationBuilder.DropTable(
                name: "Certificate");

            migrationBuilder.DropTable(
                name: "Lesson");

            migrationBuilder.DropTable(
                name: "FeedbackType");

            migrationBuilder.DropTable(
                name: "Skill");

            migrationBuilder.DropTable(
                name: "WorkshopClass");

            migrationBuilder.DropTable(
                name: "TrainerSlot");

            migrationBuilder.DropTable(
                name: "ConsultingPricePolicy");

            migrationBuilder.DropTable(
                name: "Address");

            migrationBuilder.DropTable(
                name: "ConsultingType");

            migrationBuilder.DropTable(
                name: "DistancePrice");

            migrationBuilder.DropTable(
                name: "BirdSkill");

            migrationBuilder.DropTable(
                name: "TrainingCourse");

            migrationBuilder.DropTable(
                name: "Bird");

            migrationBuilder.DropTable(
                name: "Section");

            migrationBuilder.DropTable(
                name: "Workshop");

            migrationBuilder.DropTable(
                name: "Trainer");

            migrationBuilder.DropTable(
                name: "Slot");

            migrationBuilder.DropTable(
                name: "Customer");

            migrationBuilder.DropTable(
                name: "BirdSpecies");

            migrationBuilder.DropTable(
                name: "OnlineCourse");

            migrationBuilder.DropTable(
                name: "WorkshopRefundPolicy");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "MembershipRank");
        }
    }
}
