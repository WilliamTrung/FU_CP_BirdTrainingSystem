using AppRepository.UnitOfWork;
using AutoMapper;
using Models.Entities;
using Models.ServiceModels.TrainingCourseModels;
using Models.ServiceModels.TrainingCourseModels.BirdTrainingCourse;
using Models.ServiceModels.TrainingCourseModels.BirdTrainingProgress;
using Models.ServiceModels.TrainingCourseModels.BirdTrainingReport;
using Models.ServiceModels.TrainingCourseModels.TrainerSkill;
using Models.ServiceModels.TrainingCourseModels.TrainerSlot;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace TrainingCourseSubsystem.Implementation
{
    public class FeatureStaff : FeatureAll, IFeatureStaff
    {
        public FeatureStaff(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
        }
        public async Task<IEnumerable<BirdTrainingCourseModel>> GetBirdTrainingCourse()
        {
            var entities = await _unitOfWork.BirdTrainingCourseRepository.Get();
            var models = _mapper.Map<IEnumerable<BirdTrainingCourseModel>>(entities);
            return models.OrderByDescending(e => e.Status);
        }

        public async Task<IEnumerable<BirdTrainingCourseModel>> GetBirdTrainingCourseByBirdId(int birdId)
        {
            var entities = await _unitOfWork.BirdTrainingCourseRepository.Get(e => e.BirdId == birdId);
            var models = _mapper.Map<IEnumerable<BirdTrainingCourseModel>>(entities);
            return models.OrderByDescending(e => e.Status);
        }

        public async Task<IEnumerable<BirdTrainingCourseListView>> GetBirdTrainingCourseByCustomerId(int customerId)
        {
            var entities = await _unitOfWork.BirdTrainingCourseRepository.Get(e => e.CustomerId == customerId
                                                                                , nameof(BirdTrainingCourse.TrainingCourse)
                                                                                , nameof(BirdTrainingCourse.Bird)
                                                                                , nameof(BirdTrainingCourse.Customer)
                                                                                , $"{nameof(BirdTrainingCourse.Customer)}.{nameof(BirdTrainingCourse.Customer.User)}");
            var models = _mapper.Map<IEnumerable<BirdTrainingCourseListView>>(entities);
            return models;
        }

        public async Task ConfirmBirdTrainingCourse(int birdTrainingCourseId)
        {
            var birdTrainingCourse = await _unitOfWork.BirdTrainingCourseRepository.GetFirst(e => e.Id == birdTrainingCourseId);
            var trainingSkill = await _unitOfWork.TrainingCourseSkillRepository.Get(e => e.TrainingCourseId == birdTrainingCourse.TrainingCourseId);
            if (trainingSkill != null && trainingSkill.Count() > 0)
            {
                foreach (var skill in trainingSkill.ToList())
                {
                    if (skill != null)
                    {
                        GenerateCourseProgress newClass = new GenerateCourseProgress
                        {
                            BirdTrainingCourseId = birdTrainingCourseId,
                            TrainingCourseSkillId = skill.BirdSkillId
                        };
                        var entity = _mapper.Map<BirdTrainingProgress>(newClass);
                        entity.TotalTrainingSlot = skill.TotalSlot;
                        entity.Status = (int)Models.Enum.BirdTrainingProgress.Status.WaitingForAssign;
                        await _unitOfWork.BirdTrainingProgressRepository.Add(entity);
                    }
                }
                //birdTrainingCourse.Status = (int)Models.Enum.BirdTrainingCourse.Status.Confirmed;
                //await _unitOfWork.BirdTrainingCourseRepository.Update(birdTrainingCourse);
            }
        }

        public async Task<IEnumerable<BirdTrainingProgressViewModel>> GetTrainingCourseSkill(int birdTrainingCourseId)
        {
            var entities = await _unitOfWork.BirdTrainingProgressRepository.Get(e => e.BirdTrainingCourseId == birdTrainingCourseId);
            var models = _mapper.Map<IEnumerable<BirdTrainingProgressViewModel>>(entities);
            return models;
        }

        public async Task<IEnumerable<TrainerModel>> GetTrainer()
        {
            var entities = await _unitOfWork.TrainerRepository.Get(expression: null, nameof(User), nameof(TrainerSkill));
            List<TrainerModel> models = new List<TrainerModel>();
            foreach (Models.Entities.Trainer entity in entities)
            {
                var skills = _mapper.Map<List<TrainerSkillViewModel>>(entity.TrainerSkills);
                TrainerModel model = new TrainerModel()
                {
                    Id = entity.Id,
                    Name = entity.User.Name,
                    Email = entity.User.Email,
                    Avatar = entity.User.Avatar,
                    TrainerSkillModels = skills
                };
                models.Add(model);
            }
            return models;
        }

        public async Task<IEnumerable<TrainerModel>> GetTrainerByBirdSkillId(int birdSkillId)
        {
            var trainableSkills = await _unitOfWork.TrainableSkillRepository.Get(e => e.BirdSkillId == birdSkillId);
            var trainerSkills = await _unitOfWork.TrainerSkillRepository.Get(e => trainableSkills.Any(c => c.SkillId == e.SkillId));
            var trainers = _unitOfWork.TrainerRepository.Get(e => trainerSkills.Any(c => c.TrainerId == e.Id)).Result.ToList();
            var models = _mapper.Map<IEnumerable<TrainerModel>>(trainers);
            //List<TrainerModel> models = new List<TrainerModel>();
            //foreach (var trainableSkill in trainableSkills)
            //{
            //    var trainerSkillId = trainableSkill.SkillId;
            //    List<TrainerModel> trainers = GetTrainerByTrainerSkillId(trainerSkillId).Result.ToList();
            //    foreach (var trainer in trainers)
            //    {
            //        if (trainer != null)
            //        {
            //            models.Add(trainer);
            //        }
            //    }
            //}
            //models.DistinctBy(m => m.Id).ToList();
            return models;
        }

        public async Task<TrainerModel> GetTrainerById(int trainerId)
        {
            var entity = await _unitOfWork.TrainerRepository.GetFirst(e => e.Id == trainerId, "User", "Skill");
            var skills = _mapper.Map<List<TrainerSkillViewModel>>(entity.TrainerSkills);
            TrainerModel model = new TrainerModel()
            {
                Id = entity.Id,
                Name = entity.User.Name,
                Email = entity.User.Email,
                Avatar = entity.User.Avatar,
                TrainerSkillModels = skills
            };
            return model;
        }

        public async Task<IEnumerable<TrainerModel>> GetTrainerByTrainerSkillId(int trainerSkillId)
        {
            var trainerSkills = await _unitOfWork.TrainerSkillRepository.Get(e => e.SkillId == trainerSkillId, nameof(Trainer));
            List<Trainer> trainerEntities = new List<Trainer>();
            foreach (var trainerSkill in trainerSkills)
            {
                if (trainerSkill.Trainer != null)
                {
                    trainerEntities.Add(trainerSkill.Trainer);
                }
            }
            var models = _mapper.Map<IEnumerable<TrainerModel>>(trainerEntities);
            return models;
        }

        public async Task<BirdTrainingProgressModel> AssignTrainer(AssignTrainerToCourse assignTrainer)
        {
            if (assignTrainer == null)
            {
                throw new Exception("Client send null models");
            }
            else
            {
                var birdTrainingClass = await _unitOfWork.BirdTrainingProgressRepository.GetFirst(e => e.Id == assignTrainer.Id
                                                                                                  , nameof(BirdTrainingProgress.BirdTrainingCourse));
                if (birdTrainingClass.TrainerId != null)
                {
                    var reports = _unitOfWork.BirdTrainingReportRepository.Get(e => e.BirdTrainingProgressId == birdTrainingClass.Id).Result.ToList();
                    foreach (var report in reports)
                    {
                        var trainerSlot = _unitOfWork.TrainerSlotRepository.GetFirst(e => e.Id == report.TrainerSlotId).Result;
                        if(trainerSlot != null)
                        {
                            await _unitOfWork.TrainerSlotRepository.Delete(trainerSlot);
                        }
                        await _unitOfWork.BirdTrainingReportRepository.Delete(report);
                    }
                }
                //var bird = _unitOfWork.BirdRepository.GetFirst(e => e.Id == birdTrainingClass.BirdTrainingCourse.BirdId).Result;
                //if (bird.Status == (int)Models.Enum.Bird.Status.NotReady)
                //{
                //    throw new Exception("Bird is not ready for training");
                //}
                //else
                birdTrainingClass.TrainerId = assignTrainer.TrainerId;
                birdTrainingClass.Status = (int)Models.Enum.BirdTrainingProgress.Status.WaitingForAssign;
                await _unitOfWork.BirdTrainingProgressRepository.Update(birdTrainingClass);

                if (IsAssignForAllClass(birdTrainingClass.BirdTrainingCourse.Id))
                {
                    birdTrainingClass.BirdTrainingCourse.Status = (int)Models.Enum.BirdTrainingCourse.Status.Confirmed;
                }
                return _mapper.Map<BirdTrainingProgressModel>(birdTrainingClass);
            }
        }
        private bool IsAssignForAllClass(int birdTrainingCourseId)
        {
            var progresses = _unitOfWork.BirdTrainingProgressRepository.Get(e => e.BirdTrainingCourseId == birdTrainingCourseId).Result.ToList();
            return !progresses.Any(e => e.Status == (int)Models.Enum.BirdTrainingProgress.Status.WaitingForAssign);
        }

        public async Task GenerateTrainerTimetable(InitReportTrainerSlot report)
        {
            if (report == null)
            {
                throw new Exception("Null param from client" + nameof(report));
            }
            var entity = _mapper.Map<BirdTrainingReport>(report);
            if (entity == null)
            {
                throw new Exception("Mapping failed between " + nameof(InitReportTrainerSlot) + " and " + nameof(BirdTrainingReport));
            }
            else
            {
                entity.Status = (int)Models.Enum.BirdTrainingReport.Status.NotYet;
                await _unitOfWork.BirdTrainingReportRepository.Add(entity);

                var birdTrainingClass = _unitOfWork.BirdTrainingProgressRepository.GetFirst(e => e.Id == report.BirdTrainingProgressId).Result;
                var reports = _unitOfWork.BirdTrainingReportRepository.Get(e => e.Id == report.BirdTrainingProgressId).Result.ToList();

                if(birdTrainingClass.TotalTrainingSlot == reports.Count())
                {
                    birdTrainingClass.Status = (int)Models.Enum.BirdTrainingProgress.Status.Assigned;
                    await _unitOfWork.BirdTrainingProgressRepository.Update(birdTrainingClass);
                }
            }
        }

        public async Task<IEnumerable<BirdTrainingProgressModel>> GetBirdTrainingProgress()
        {
            var entities = await _unitOfWork.BirdTrainingProgressRepository.Get();
            var models = _mapper.Map<IEnumerable<BirdTrainingProgressModel>>(entities);
            return models;
        }

        public async Task ModifyTrainerSlot(ModifyTrainerSlot trainerSlot)
        {
            var entity = await _unitOfWork.BirdTrainingReportRepository.GetFirst(e => e.Id == trainerSlot.BirdTrainingReportId
                                                                                   , nameof(BirdTrainingReport.TrainerSlot));
            if (entity == null || entity.TrainerSlot == null)
            {
                throw new Exception("Not found entity or trainer slot");
            }
            else
            {
                entity.TrainerSlot.SlotId = trainerSlot.SlotId;
                entity.TrainerSlot.Date = trainerSlot.Date;
                await _unitOfWork.BirdTrainingReportRepository.Update(entity);
            }

            var trainingSkillSlot = await _unitOfWork.TrainerSlotRepository.Get(e => e.EntityTypeId == (int)Models.Enum.EntityType.TrainingCourse
                                                                                  && e.EntityId == entity.BirdTrainingProgressId);
            trainingSkillSlot = trainingSkillSlot.OrderBy(e => e.Date);
            DateTime startTraining = trainingSkillSlot.First().Date;

            var birdTrainingProgress = await _unitOfWork.BirdTrainingProgressRepository.GetFirst(e => e.Id == entity.BirdTrainingProgressId);
            await ModifyActualStartTime(startTraining, birdTrainingProgress.BirdTrainingCourseId);
        }

        public async Task<TrainerSlotModel> CreateTrainerSlot(TrainerSlotModel trainerSlotModel)
        {
            var entity = _mapper.Map<TrainerSlot>(trainerSlotModel);
            entity.Status = (int)Models.Enum.TrainerSlotStatus.Enabled;
            await _unitOfWork.TrainerSlotRepository.Add(entity);

            return _mapper.Map<TrainerSlotModel>(entity);
        }

        public async Task InitStartTime(BirdTrainingCourseStartTime birdTrainingCourse)
        {
            if (birdTrainingCourse == null)
            {
                throw new Exception("Client send null param");
            }
            else
            {
                var entity = await _unitOfWork.BirdTrainingCourseRepository.GetFirst(e => e.Id == birdTrainingCourse.Id, nameof(TrainingCourse));
                if (entity == null)
                {
                    throw new Exception("Entity not found");
                }
                else
                {
                    entity.StaffId = birdTrainingCourse.StaffId;
                    //entity.ExpectedStartDate = DateTime.Now;
                    //DateTime expectDoneDate = DateTime.Now.AddDays(entity.TrainingCourse.TotalSlot);
                    //entity.ExpectedTrainingDoneDate = expectDoneDate;
                    //entity.ExpectedDateReturn = expectDoneDate;
                    //entity.LastestUpdate = DateTime.Now;

                    var assignedSkills = _unitOfWork.BirdTrainingProgressRepository.Get(e => e.BirdTrainingCourseId == entity.Id).Result.ToList();
                    if (assignedSkills.Any(e => e.TrainerId != null))
                    {
                        entity.Status = (int)Models.Enum.BirdTrainingCourse.Status.Registered;
                    }
                    else
                    {
                        entity.Status = (int)Models.Enum.BirdTrainingCourse.Status.Confirmed;
                    }

                    await _unitOfWork.BirdTrainingCourseRepository.Update(entity);
                }
            }
        }

        public async Task ModifyActualStartTime(DateTime startDate, int birdTrainingCourseId)
        {
            var entity = await _unitOfWork.BirdTrainingCourseRepository.GetFirst(e => e.Id == birdTrainingCourseId);
            if (entity == null)
            {
                throw new Exception("Not found entity");
            }
            else
            {
                entity.StartTrainingDate = startDate;
                await _unitOfWork.BirdTrainingCourseRepository.Update(entity);
            }
        }

        public async Task ReceiveBird(BirdTrainingCourseReceiveBird birdTrainingCourse)
        {
            if (birdTrainingCourse == null)
            {
                throw new Exception("Client send null param");
            }
            else
            {
                var entity = await _unitOfWork.BirdTrainingCourseRepository.GetFirst(e => e.Id == birdTrainingCourse.Id);
                if (entity == null)
                {
                    throw new Exception("Entity not found");
                }
                else
                {
                    entity.ReceiveStaffId = birdTrainingCourse.ReceiveStaffId;
                    entity.DateReceived = DateTime.Now;
                    entity.ReceiveNote = birdTrainingCourse.ReceiveNote;
                    entity.ReceivePicture = birdTrainingCourse.ReceivePicture;
                    entity.Status = (int)Models.Enum.BirdTrainingCourse.Status.CheckIn; //enum birdtrainingcourse status

                    var bird = _unitOfWork.BirdRepository.GetFirst(e => e.Id == entity.BirdId).Result;
                    bird.Status = (int)Models.Enum.Bird.Status.NotReady;

                    await _unitOfWork.BirdTrainingCourseRepository.Update(entity);
                    await _unitOfWork.BirdRepository.Update(bird);
                }
            }
        }

        public async Task ReturnBird(BirdTrainingCourseReturnBird birdTrainingCourse)
        {
            if (birdTrainingCourse == null)
            {
                throw new Exception("Client send null param");
            }
            else
            {
                var entity = await _unitOfWork.BirdTrainingCourseRepository.GetFirst(e => e.Id == birdTrainingCourse.Id);
                if (entity == null)
                {
                    throw new Exception("Entity not found");
                }
                else if (entity.Status != (int)Models.Enum.BirdTrainingCourse.Status.TrainingDone)
                {
                    throw new Exception("Bird is training. Not ready to return");
                }
                else
                {
                    entity.ReturnStaffId = birdTrainingCourse.ReturnStaffId;
                    entity.DateReceived = DateTime.Now;
                    entity.ReturnNote = birdTrainingCourse.ReturnNote;
                    entity.ReturnPicture = birdTrainingCourse.ReturnPicture;
                    entity.Status = (int)Models.Enum.BirdTrainingCourse.Status.CheckOut;
                    await _unitOfWork.BirdTrainingCourseRepository.Update(entity);
                }
            }
        }
    }
}
