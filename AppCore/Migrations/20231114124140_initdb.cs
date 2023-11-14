using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace AppCore.Migrations
{
    public partial class initdb : Migration
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
                    Picture = table.Column<string>(type: "character varying(255)", unicode: false, maxLength: 255, nullable: true),
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
                    Avatar = table.Column<string>(type: "character varying(255)", unicode: false, maxLength: 255, nullable: true),
                    Password = table.Column<string>(type: "character varying(255)", unicode: false, maxLength: 255, nullable: false),
                    RoleId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Workshop",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Title = table.Column<string>(type: "character varying(300)", unicode: false, maxLength: 300, nullable: false),
                    Description = table.Column<string>(type: "character varying(1000)", unicode: false, maxLength: 1000, nullable: true),
                    Picture = table.Column<string>(type: "character varying(255)", unicode: false, maxLength: 255, nullable: true),
                    RegisterEnd = table.Column<int>(type: "integer", nullable: true),
                    Price = table.Column<decimal>(type: "money", nullable: false),
                    TotalSlot = table.Column<int>(type: "integer", nullable: false),
                    Status = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Workshop", x => x.Id);
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
                    Condition = table.Column<string>(type: "character varying(255)", unicode: false, maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Acquirab__4802579EB257E655", x => new { x.BirdSpeciesId, x.BirdSkillId });
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
                    Picture = table.Column<string>(type: "character varying(255)", unicode: false, maxLength: 255, nullable: true),
                    TotalSlot = table.Column<int>(type: "integer", nullable: false),
                    TotalPrice = table.Column<decimal>(type: "money", nullable: false),
                    Status = table.Column<int>(type: "integer", nullable: false)
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
                    Picture = table.Column<string>(type: "character varying(255)", unicode: false, maxLength: 255, nullable: true)
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
                    table.PrimaryKey("PK__Trainabl__707AE50061373685", x => new { x.BirdSkillId, x.SkillId });
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
                    Category = table.Column<int>(type: "integer", nullable: false),
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
                name: "WorkshopClass",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    WorkshopId = table.Column<int>(type: "integer", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "date", nullable: true),
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
                name: "WorkshopDetailTemplate",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    WorkshopId = table.Column<int>(type: "integer", nullable: false),
                    Detail = table.Column<string>(type: "character varying(500)", unicode: false, maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkshopDetailTemplate", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WorkshopDetailTemplate_Workshop_WorkshopId",
                        column: x => x.WorkshopId,
                        principalTable: "Workshop",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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
                    Picture = table.Column<string>(type: "character varying(255)", unicode: false, maxLength: 255, nullable: true)
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
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    BirdSkillId = table.Column<int>(type: "integer", nullable: false),
                    TrainingCourseId = table.Column<int>(type: "integer", nullable: false),
                    TotalSlot = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrainingCourseSkill", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TrainingCourseSkill_BirdSkill_BirdSkillId",
                        column: x => x.BirdSkillId,
                        principalTable: "BirdSkill",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_TrainingCourseSkill_TrainingCourse_TrainingCourseId",
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
                    Video = table.Column<string>(type: "character varying(255)", unicode: false, maxLength: 255, nullable: true)
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
                    AddressDetail = table.Column<string>(type: "character varying(255)", unicode: false, maxLength: 255, nullable: false)
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
                    Picture = table.Column<string>(type: "character varying(255)", unicode: false, maxLength: 255, nullable: true),
                    Description = table.Column<string>(type: "character varying(255)", unicode: false, maxLength: 255, nullable: true),
                    IsDefault = table.Column<bool>(type: "boolean", nullable: true),
                    Status = table.Column<int>(type: "integer", nullable: false)
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
                    table.PrimaryKey("PK__Customer__AF11EEA4FDA02E2A", x => new { x.CustomerId, x.CertificateId });
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
                    table.PrimaryKey("PK__Customer__FFA1E3B76AF51E89", x => new { x.CustomerId, x.OnlineCourseId });
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
                    table.PrimaryKey("PK__Customer__9CA0945F8CBB2D34", x => new { x.CustomerId, x.SectionId });
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
                    CustomerId = table.Column<int>(type: "integer", nullable: false),
                    EntityTypeId = table.Column<int>(type: "integer", nullable: false),
                    EntityId = table.Column<int>(type: "integer", nullable: true),
                    FeedbackDetail = table.Column<string>(type: "character varying(200)", unicode: false, maxLength: 200, nullable: true),
                    Rating = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Feedback", x => x.Id);
                    table.ForeignKey(
                        name: "FKFeedback245587",
                        column: x => x.CustomerId,
                        principalTable: "Customer",
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
                    table.PrimaryKey("PK__Trainer___5B90136408FD50B7", x => new { x.TrainerId, x.SkillId });
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
                    TrainerId = table.Column<int>(type: "integer", nullable: true),
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
                name: "Customer_WorkshopClass",
                columns: table => new
                {
                    CustomerId = table.Column<int>(type: "integer", nullable: false),
                    WorkshopClassId = table.Column<int>(type: "integer", nullable: false),
                    WorkshopRefundPolicyId = table.Column<int>(type: "integer", nullable: true),
                    Price = table.Column<decimal>(type: "money", nullable: true),
                    DiscountedPrice = table.Column<decimal>(type: "money", nullable: true),
                    RefundRate = table.Column<float>(type: "real", nullable: true),
                    Status = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Customer__7EEF8348DE684159", x => new { x.CustomerId, x.WorkshopClassId });
                    table.ForeignKey(
                        name: "FK_Customer_WorkshopClass_WorkshopRefundPolicy_WorkshopRefundP~",
                        column: x => x.WorkshopRefundPolicyId,
                        principalTable: "WorkshopRefundPolicy",
                        principalColumn: "Id");
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
                name: "BirdCertificateSkill",
                columns: table => new
                {
                    BirdSkillId = table.Column<int>(type: "integer", nullable: false),
                    BirdCertificateId = table.Column<int>(type: "integer", nullable: false),
                    ReceivedDate = table.Column<DateTime>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__BirdCert__A080D86A58420E37", x => new { x.BirdSkillId, x.BirdCertificateId });
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
                    table.PrimaryKey("PK__Customer__304EA374D16199C5", x => new { x.CustomerId, x.LessionId });
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
                    TrainerId = table.Column<int>(type: "integer", nullable: true),
                    AddressId = table.Column<int>(type: "integer", nullable: false),
                    ConsultingTypeId = table.Column<int>(type: "integer", nullable: false),
                    ConsultingDetail = table.Column<string>(type: "character varying(1000)", unicode: false, maxLength: 1000, nullable: true),
                    Distance = table.Column<int>(type: "integer", nullable: true),
                    OnlineOrOffline = table.Column<bool>(type: "boolean", nullable: false),
                    GgMeetLink = table.Column<string>(type: "character varying(255)", unicode: false, maxLength: 255, nullable: true),
                    AppointmentDate = table.Column<DateTime>(type: "date", nullable: true),
                    ActualSlotStart = table.Column<int>(type: "integer", nullable: false),
                    ActualEndSlot = table.Column<int>(type: "integer", nullable: true),
                    Evidence = table.Column<string>(type: "character varying(255)", unicode: false, maxLength: 255, nullable: true),
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
                    StaffId = table.Column<int>(type: "integer", nullable: true),
                    CustomerId = table.Column<int>(type: "integer", nullable: false),
                    RegisteredDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    TotalPrice = table.Column<decimal>(type: "money", nullable: true),
                    DiscountedPrice = table.Column<decimal>(type: "money", nullable: true),
                    ReceiveStaffId = table.Column<int>(type: "integer", nullable: true),
                    DateReceived = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    ReceiveNote = table.Column<string>(type: "character varying(255)", unicode: false, maxLength: 255, nullable: true),
                    ReceivePicture = table.Column<string>(type: "character varying(255)", unicode: false, maxLength: 255, nullable: true),
                    ReturnStaffId = table.Column<int>(type: "integer", nullable: true),
                    DateReturn = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    ReturnNote = table.Column<string>(type: "character varying(255)", unicode: false, maxLength: 255, nullable: true),
                    ReturnPicture = table.Column<string>(type: "character varying(255)", unicode: false, maxLength: 255, nullable: true),
                    StartTrainingDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    TrainingDoneDate = table.Column<DateTime>(type: "date", nullable: true),
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
                        name: "FKBird_Train678526",
                        column: x => x.CustomerId,
                        principalTable: "Customer",
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
                name: "BirdSkillReceived",
                columns: table => new
                {
                    BirdSkillId = table.Column<int>(type: "integer", nullable: false),
                    BirdId = table.Column<int>(type: "integer", nullable: false),
                    ReceivedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BirdSkillReceived", x => new { x.BirdSkillId, x.BirdId });
                    table.ForeignKey(
                        name: "FK_BirdSkillReceived_Bird_BirdId",
                        column: x => x.BirdId,
                        principalTable: "Bird",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_BirdSkillReceived_BirdSkill_BirdSkillId",
                        column: x => x.BirdSkillId,
                        principalTable: "BirdSkill",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "WorkshopClassDetail",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    WorkshopClassId = table.Column<int>(type: "integer", nullable: false),
                    DetailId = table.Column<int>(type: "integer", nullable: false),
                    DaySlotId = table.Column<int>(type: "integer", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "date", nullable: true)
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
                        name: "FKWorkshopCl382995",
                        column: x => x.DaySlotId,
                        principalTable: "TrainerSlot",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FKWorkshopCl957106",
                        column: x => x.DetailId,
                        principalTable: "WorkshopDetailTemplate",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Bird_TrainingProgress",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Bird_TrainingCourseId = table.Column<int>(type: "integer", nullable: false),
                    TrainingCourse_SkillId = table.Column<int>(type: "integer", nullable: false),
                    TotalTrainingSlot = table.Column<int>(type: "integer", nullable: false),
                    TrainerId = table.Column<int>(type: "integer", nullable: true),
                    TrainingDoneDate = table.Column<DateTime>(type: "date", nullable: true),
                    Evidence = table.Column<string>(type: "character varying(255)", unicode: false, maxLength: 255, nullable: true),
                    Status = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bird_TrainingProgress", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Bird_TrainingProgress_TrainingCourseSkill_TrainingCourse_Sk~",
                        column: x => x.TrainingCourse_SkillId,
                        principalTable: "TrainingCourseSkill",
                        principalColumn: "Id");
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
                name: "BirdCertificateDetail",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    BirdId = table.Column<int>(type: "integer", nullable: false),
                    BirdTrainingCourseId = table.Column<int>(type: "integer", nullable: false),
                    BirdCertificateId = table.Column<int>(type: "integer", nullable: false),
                    ReceiveDate = table.Column<DateTime>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BirdCertificateDetail", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BirdCertificateDetail_Bird_TrainingCourse_BirdTrainingCours~",
                        column: x => x.BirdTrainingCourseId,
                        principalTable: "Bird_TrainingCourse",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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
                name: "WorkshopAttendance",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CustomerId = table.Column<int>(type: "integer", nullable: false),
                    WorkshopClassDetailId = table.Column<int>(type: "integer", nullable: false),
                    Status = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkshopAttendance", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WorkshopAttendance_WorkshopClassDetail_WorkshopClassDetailId",
                        column: x => x.WorkshopClassDetailId,
                        principalTable: "WorkshopClassDetail",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FKWorkshopAt124181",
                        column: x => x.CustomerId,
                        principalTable: "Customer",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "BirdTrainingReport",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Bird_TrainingProgressId = table.Column<int>(type: "integer", nullable: false),
                    TrainerSlotId = table.Column<int>(type: "integer", nullable: false),
                    Comment = table.Column<string>(type: "character varying(200)", unicode: false, maxLength: 200, nullable: true),
                    Evidence = table.Column<string>(type: "character varying(255)", unicode: false, maxLength: 255, nullable: true),
                    Status = table.Column<int>(type: "integer", nullable: true),
                    TrainerId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BirdTrainingReport", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BirdTrainingReport_Trainer_TrainerId",
                        column: x => x.TrainerId,
                        principalTable: "Trainer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FKBirdTraini259515",
                        column: x => x.Bird_TrainingProgressId,
                        principalTable: "Bird_TrainingProgress",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FKBirdTraini696869",
                        column: x => x.TrainerSlotId,
                        principalTable: "TrainerSlot",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "BirdSkill",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { 1, "Teaches controlled flight and landing", "Flight training" },
                    { 2, "Develops vocabulary and mimicking", "Speech training" },
                    { 3, "Modifies behaviors through positive reinforcement", "Behavior training" },
                    { 4, "Imitates noises like doorbells and phones", "Sound imitation" },
                    { 5, "Improves coordination through obstacle courses", "Agility training" },
                    { 6, "Identifies colors when named", "Color recognition" },
                    { 7, "Assumes specific poses on command", "Pose training" },
                    { 8, "Learns dance routines to music", "Choreographed dances" },
                    { 9, "Performs athletic tricks like hanging upside down", "Acrobatics" },
                    { 10, "Plays games like basketball or bowling", "Games" }
                });

            migrationBuilder.InsertData(
                table: "MembershipRank",
                columns: new[] { "Id", "Discount", "Name", "Requirement" },
                values: new object[,]
                {
                    { 1, 0f, "Standard", 0m },
                    { 2, 0.1f, "Gold", 50000000m },
                    { 3, 0.2f, "Platinum", 100000000m }
                });

            migrationBuilder.InsertData(
                table: "Skill",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { 1, "Modifies bird behaviors through positive reinforcement", "Behavioral Training" },
                    { 2, "Develops bird speech and imitation abilities", "Vocal Training" },
                    { 3, "Prepares birds for stage performances", "Showmanship" },
                    { 4, "Teaches birds to chain multiple behaviors", "Complex Routines" },
                    { 5, "Provides proper bird nutrition, healthcare, etc.", "Husbandry" }
                });

            migrationBuilder.InsertData(
                table: "Slot",
                columns: new[] { "Id", "EndTime", "StartTime" },
                values: new object[,]
                {
                    { 1, new TimeSpan(0, 8, 45, 0, 0), new TimeSpan(0, 8, 0, 0, 0) },
                    { 2, new TimeSpan(0, 9, 45, 0, 0), new TimeSpan(0, 9, 0, 0, 0) },
                    { 3, new TimeSpan(0, 10, 45, 0, 0), new TimeSpan(0, 10, 0, 0, 0) },
                    { 4, new TimeSpan(0, 11, 45, 0, 0), new TimeSpan(0, 11, 0, 0, 0) },
                    { 5, new TimeSpan(0, 13, 45, 0, 0), new TimeSpan(0, 13, 0, 0, 0) },
                    { 6, new TimeSpan(0, 14, 45, 0, 0), new TimeSpan(0, 14, 0, 0, 0) },
                    { 7, new TimeSpan(0, 15, 45, 0, 0), new TimeSpan(0, 15, 0, 0, 0) },
                    { 8, new TimeSpan(0, 16, 45, 0, 0), new TimeSpan(0, 16, 0, 0, 0) }
                });

            migrationBuilder.InsertData(
                table: "WorkshopRefundPolicy",
                columns: new[] { "Id", "RefundRate", "TotalDayBeforeStart" },
                values: new object[,]
                {
                    { 1, 0f, 13 },
                    { 2, 0.5f, 29 },
                    { 3, 0.75f, 30 },
                    { 4, 1f, -1 }
                });

            migrationBuilder.InsertData(
                table: "TrainableSkill",
                columns: new[] { "BirdSkillId", "SkillId", "ShortDescription" },
                values: new object[,]
                {
                    { 1, 5, "Proper flight training for exercise" },
                    { 2, 2, "Develop speech through vocal training" },
                    { 3, 1, "Use positive reinforcement for behavior training" },
                    { 4, 2, "Imitate sounds through vocal training" },
                    { 5, 1, "Build agility through positive reinforcement" },
                    { 6, 4, "Chain behaviors for complex routines" },
                    { 7, 4, "Pose routines require chaining multiple behaviors" },
                    { 8, 3, "Choreographed dances for shows" },
                    { 9, 3, "Acrobatic tricks for shows" },
                    { 10, 3, "Games and skits for shows" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AcquirableSkill_BirdSkillId",
                table: "AcquirableSkill",
                column: "BirdSkillId");

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
                name: "IX_Bird_TrainingCourse_CustomerId",
                table: "Bird_TrainingCourse",
                column: "CustomerId");

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
                name: "IX_BirdCertificateDetail_BirdId",
                table: "BirdCertificateDetail",
                column: "BirdId");

            migrationBuilder.CreateIndex(
                name: "IX_BirdCertificateDetail_BirdTrainingCourseId",
                table: "BirdCertificateDetail",
                column: "BirdTrainingCourseId");

            migrationBuilder.CreateIndex(
                name: "IX_BirdCertificateSkill_BirdCertificateId",
                table: "BirdCertificateSkill",
                column: "BirdCertificateId");

            migrationBuilder.CreateIndex(
                name: "IX_BirdSkillReceived_BirdId",
                table: "BirdSkillReceived",
                column: "BirdId");

            migrationBuilder.CreateIndex(
                name: "IX_BirdTrainingReport_Bird_TrainingProgressId",
                table: "BirdTrainingReport",
                column: "Bird_TrainingProgressId");

            migrationBuilder.CreateIndex(
                name: "IX_BirdTrainingReport_TrainerId",
                table: "BirdTrainingReport",
                column: "TrainerId");

            migrationBuilder.CreateIndex(
                name: "IX_BirdTrainingReport_TrainerSlotId",
                table: "BirdTrainingReport",
                column: "TrainerSlotId");

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
                name: "IX_Customer_WorkshopClass_WorkshopRefundPolicyId",
                table: "Customer_WorkshopClass",
                column: "WorkshopRefundPolicyId");

            migrationBuilder.CreateIndex(
                name: "IX_Feedback_CustomerId",
                table: "Feedback",
                column: "CustomerId");

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
                name: "IX_TrainingCourseSkill_BirdSkillId",
                table: "TrainingCourseSkill",
                column: "BirdSkillId");

            migrationBuilder.CreateIndex(
                name: "IX_TrainingCourseSkill_TrainingCourseId",
                table: "TrainingCourseSkill",
                column: "TrainingCourseId");

            migrationBuilder.CreateIndex(
                name: "IX_Transaction_CustomerId",
                table: "Transaction",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "UQ__User__85FB4E386F560942",
                table: "User",
                column: "PhoneNumber",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "UQ__User__A9D10534EE377C20",
                table: "User",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_WorkshopAttendance_CustomerId",
                table: "WorkshopAttendance",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkshopAttendance_WorkshopClassDetailId",
                table: "WorkshopAttendance",
                column: "WorkshopClassDetailId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkshopClass_WorkshopId",
                table: "WorkshopClass",
                column: "WorkshopId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkshopClassDetail_DaySlotId",
                table: "WorkshopClassDetail",
                column: "DaySlotId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkshopClassDetail_DetailId",
                table: "WorkshopClassDetail",
                column: "DetailId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkshopClassDetail_WorkshopClassId",
                table: "WorkshopClassDetail",
                column: "WorkshopClassId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkshopDetailTemplate_WorkshopId",
                table: "WorkshopDetailTemplate",
                column: "WorkshopId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AcquirableSkill");

            migrationBuilder.DropTable(
                name: "BirdCertificateDetail");

            migrationBuilder.DropTable(
                name: "BirdCertificateSkill");

            migrationBuilder.DropTable(
                name: "BirdSkillReceived");

            migrationBuilder.DropTable(
                name: "BirdTrainingReport");

            migrationBuilder.DropTable(
                name: "CenterSlot");

            migrationBuilder.DropTable(
                name: "ConsultingTicket");

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
                name: "BirdCertificate");

            migrationBuilder.DropTable(
                name: "Bird_TrainingProgress");

            migrationBuilder.DropTable(
                name: "ConsultingPricePolicy");

            migrationBuilder.DropTable(
                name: "Address");

            migrationBuilder.DropTable(
                name: "ConsultingType");

            migrationBuilder.DropTable(
                name: "DistancePrice");

            migrationBuilder.DropTable(
                name: "Certificate");

            migrationBuilder.DropTable(
                name: "Lesson");

            migrationBuilder.DropTable(
                name: "WorkshopRefundPolicy");

            migrationBuilder.DropTable(
                name: "Skill");

            migrationBuilder.DropTable(
                name: "WorkshopClassDetail");

            migrationBuilder.DropTable(
                name: "TrainingCourseSkill");

            migrationBuilder.DropTable(
                name: "Bird_TrainingCourse");

            migrationBuilder.DropTable(
                name: "Section");

            migrationBuilder.DropTable(
                name: "WorkshopClass");

            migrationBuilder.DropTable(
                name: "TrainerSlot");

            migrationBuilder.DropTable(
                name: "WorkshopDetailTemplate");

            migrationBuilder.DropTable(
                name: "BirdSkill");

            migrationBuilder.DropTable(
                name: "TrainingCourse");

            migrationBuilder.DropTable(
                name: "Bird");

            migrationBuilder.DropTable(
                name: "OnlineCourse");

            migrationBuilder.DropTable(
                name: "Trainer");

            migrationBuilder.DropTable(
                name: "Slot");

            migrationBuilder.DropTable(
                name: "Workshop");

            migrationBuilder.DropTable(
                name: "Customer");

            migrationBuilder.DropTable(
                name: "BirdSpecies");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "MembershipRank");
        }
    }
}
