using AppRepository.UnitOfWork;
using AutoMapper;
using Models.Entities;
using Models.ServiceModels.TrainingCourseModels.BirdCertificate;
using Models.ServiceModels.TrainingCourseModels.BirdCertificate.BirdCertificateDetail;
using Models.ServiceModels.TrainingCourseModels.BirdTrainingCourse;
using Models.ServiceModels.TrainingCourseModels.BirdTrainingProgress;
using Models.ServiceModels.TrainingCourseModels.BirdTrainingReport;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainingCourseSubsystem.Implementation
{
    public class FeatureTrainer : FeatureAll, IFeatureTrainer
    {
        public FeatureTrainer(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
        }

        public async Task<IEnumerable<BirdTrainingProgressViewModel>> GetBirdTrainingProgressByTrainerId(int trainerId)
        {
            var entities = await _unitOfWork.BirdTrainingProgressRepository.Get(e => e.TrainerId == trainerId);
            var models = _mapper.Map<IEnumerable<BirdTrainingProgressViewModel>>(entities);
            return models;
        }

        public async Task<TimetableReportView> GetTimetableReportView(int trainerSlotId)
        {
            var entity = await _unitOfWork.TrainerSlotRepository.GetFirst(e => e.Id == trainerSlotId);
            if (entity == null)
            {
                throw new Exception($"{nameof(TrainerSlot)} is not found");
            }
            else
            {
                if (entity.EntityTypeId == (int)Models.Enum.EntityType.TrainingCourse)
                {
                    var report = _unitOfWork.BirdTrainingReportRepository.GetFirst(e => e.TrainerSlotId == entity.Id
                                                                                    , nameof(BirdTrainingReport.TrainerSlot)).Result;
                    var model = _mapper.Map<TimetableReportView>(report);
                    return model;
                }
                else
                {
                    Models.Enum.EntityType enumValue = (Models.Enum.EntityType)Enum.Parse(typeof(Models.Enum.EntityType), entity.EntityTypeId.ToString());
                    throw new Exception($"{enumValue} is not suitable for query");
                }
            }
        }

        public async Task<BirdTrainingCourseListView> MarkTrainingSkillDone(MarkSkillDone markDone)
        {
            var entity = _unitOfWork.BirdTrainingProgressRepository.GetFirst(e => e.Id == markDone.Id).Result;
            if (entity == null)
            {
                throw new Exception("Entity not found");
            }
            else
            {
                entity.Evidence = markDone.Evidence;
                entity.TrainingDoneDate = DateTime.UtcNow.AddHours(7);
                if (Enum.TryParse(markDone.Status, out Models.Enum.BirdTrainingProgress.Status result))
                {
                    entity.Status = (int)result;
                }
                else
                {
                    throw new Exception("Could not parse the string to the enum.");
                }
                await _unitOfWork.BirdTrainingProgressRepository.Update(entity);

                var birdTrainingProgressAll = _unitOfWork.BirdTrainingProgressRepository.Get(e => e.BirdTrainingCourseId == entity.BirdTrainingCourseId).Result.ToList();
                bool allDone = true;
                foreach (BirdTrainingProgress progress in birdTrainingProgressAll)
                {
                    if (progress.Status != (int)Models.Enum.BirdTrainingProgress.Status.Pass && progress.Status != (int)Models.Enum.BirdTrainingProgress.Status.NotPass)
                    {
                        allDone = false;
                    }
                }
                var birdTrainingCourse = _unitOfWork.BirdTrainingCourseRepository.GetFirst(e => e.Id == entity.BirdTrainingCourseId
                                                                                               , nameof(BirdTrainingCourse.TrainingCourse)).Result;
                if (allDone)
                {
                    birdTrainingCourse.TrainingDoneDate = DateTime.UtcNow.AddHours(7);
                    birdTrainingCourse.Status = (int)Models.Enum.BirdTrainingCourse.Status.TrainingDone;

                    var bird = _unitOfWork.BirdRepository.GetFirst(e => e.Id == birdTrainingCourse.BirdId).Result;
                    bird.Status = (int)Models.Enum.Bird.Status.Ready;

                    var pricePolicy = _unitOfWork.TrainingCourseCheckOutPolicyRepository.GetFirst(e => e.Name.ToLower().Contains("success requested")).Result;
                    if (pricePolicy == null)
                    {
                        throw new InvalidOperationException("Can not found price policy.");
                    }
                    else
                    {
                        birdTrainingCourse.TrainingCourseCheckOutPolicyId = pricePolicy.Id;
                    }

                    await _unitOfWork.BirdTrainingCourseRepository.Update(birdTrainingCourse);
                    await _unitOfWork.BirdRepository.Update(bird);

                    var birdCertificate = _unitOfWork.BirdCertificateRepository.GetFirst(e => e.TrainingCourseId == birdTrainingCourse.TrainingCourse.Id).Result;
                    if (birdCertificate != null)
                    {
                        BirdCertificateDetailAddModel birdCertificateDetailAdd = new BirdCertificateDetailAddModel()
                        {
                            BirdId = birdTrainingCourse.BirdId,
                            BirdTrainingCourseId = birdTrainingCourse.Id,
                            BirdCertificateId = birdCertificate.Id,
                        };
                        await CreateBirdCertificateDetail(birdCertificateDetailAdd);
                    }
                }

                return _mapper.Map<BirdTrainingCourseListView>(birdTrainingCourse);
            }
        }

        private async Task CreateBirdCertificateDetail(BirdCertificateDetailAddModel birdCertificateDetailAdd)
        {
            if (birdCertificateDetailAdd == null)
            {
                throw new Exception("Client send null param.");
            }
            else
            {
                var checkCertificate = _unitOfWork.BirdCertificateDetailRepository.Get(e => e.BirdTrainingCourseId == birdCertificateDetailAdd.BirdTrainingCourseId).Result;
                if (checkCertificate != null && checkCertificate.Count() > 0)
                {
                    //throw new InvalidOperationException($"Bird certificate already given.");
                }
                else
                {
                    var entity = _mapper.Map<BirdCertificateDetail>(birdCertificateDetailAdd);
                    await _unitOfWork.BirdCertificateDetailRepository.Add(entity);

                    var birdTrainingCourse = _unitOfWork.BirdTrainingCourseRepository.GetFirst(e => e.Id == entity.BirdTrainingCourseId).Result;
                    if (birdTrainingCourse != null)
                    {
                        var passedSkill = _unitOfWork.BirdTrainingProgressRepository.Get(e => e.BirdTrainingCourseId == birdTrainingCourse.Id
                                                                                          && e.Status == (int)Models.Enum.BirdTrainingProgress.Status.Pass
                                                                                          , nameof(BirdTrainingProgress.TrainingCourseSkill)
                                                                                          , $"{nameof(BirdTrainingProgress.TrainingCourseSkill)}.{nameof(BirdTrainingProgress.TrainingCourseSkill.BirdSkill)}").Result.ToList();
                        if (passedSkill != null && passedSkill.Count() > 0)
                        {
                            foreach (var skill in passedSkill)
                            {
                                if (skill != null)
                                {
                                    BirdSkillReceivedAddDeleteModel birdSkillReceivedAddModel = new BirdSkillReceivedAddDeleteModel()
                                    {
                                        BirdId = entity.BirdId,
                                        BirdSkillId = skill.TrainingCourseSkill.BirdSkill.Id,
                                    };
                                    await CreateBirdSkillReceived(birdSkillReceivedAddModel);
                                }
                            }
                        }
                    }
                }
            }
        }

        public async Task<int> MarkTrainingSlotDone(int birdTrainingReportId)//status 206 de chuyen qua trang
        {
            int result = (int)Models.Enum.BirdTrainingReport.FirstOrEnd.MidSlot;
            var entity = await _unitOfWork.BirdTrainingReportRepository.GetFirst(e => e.Id == birdTrainingReportId
                                              , nameof(BirdTrainingReport.TrainerSlot)
                                              , $"{nameof(BirdTrainingReport.TrainerSlot)}.{nameof(BirdTrainingReport.TrainerSlot.Slot)}");
            if (entity == null)
            {
                throw new Exception("Entity not found");
            }
            else
            {
                DateTime currentDate = DateTime.UtcNow.AddHours(7);
                DateTime trainDate = (DateTime)(entity.TrainerSlot.Date + entity.TrainerSlot.Slot.StartTime);

                int tmpRes = currentDate.CompareTo(trainDate);
                if (tmpRes < 0)
                {
                    throw new InvalidOperationException($"Can not mark this training slot as done please wait until " +
                                $"{entity.TrainerSlot.Slot.StartTime} {entity.TrainerSlot.Date:dd/MM/yyyy}");
                }


                var birdProgress = _unitOfWork.BirdTrainingProgressRepository.GetFirst(e => e.Id == entity.BirdTrainingProgressId
                                                                                        , nameof(BirdTrainingProgress.BirdTrainingCourse)).Result;
                if (birdProgress != null)
                {
                    int firstOrEnd = FirstOrEndSlot(entity);
                    if (firstOrEnd == result)
                    {
                        result = (int)Models.Enum.BirdTrainingReport.FirstOrEnd.MidSlot;
                    }
                    else if (firstOrEnd == (int)Models.Enum.BirdTrainingReport.FirstOrEnd.FirstSlot)
                    {
                        birdProgress.Status = (int)Models.Enum.BirdTrainingProgress.Status.Training;
                        birdProgress.BirdTrainingCourse.Status = (int)Models.Enum.BirdTrainingCourse.Status.Training;
                        result = (int)Models.Enum.BirdTrainingReport.FirstOrEnd.FirstSlot;
                    }
                    else
                    {
                        result = (int)Models.Enum.BirdTrainingReport.FirstOrEnd.EndSlot;
                        birdProgress.Status = (int)Models.Enum.BirdTrainingProgress.Status.Pass;
                    }
                    await _unitOfWork.BirdTrainingProgressRepository.Update(birdProgress);

                    if (result == (int)Models.Enum.BirdTrainingReport.FirstOrEnd.EndSlot)
                    {
                        MarkSkillDone allSlotDone = new MarkSkillDone()
                        {
                            Id = birdProgress.Id,
                            Evidence = "",
                            Status = "Pass",
                        };
                        await MarkTrainingSkillDone(allSlotDone);
                    }

                    entity.Status = (int)Models.Enum.BirdTrainingReport.Status.Done;
                    await _unitOfWork.BirdTrainingReportRepository.Update(entity);
                }
            }
            return result;
        }
        private int FirstOrEndSlot(BirdTrainingReport birdTrainingReport)
        {
            if (birdTrainingReport == null)
            {
                return (int)Models.Enum.BirdTrainingReport.FirstOrEnd.MidSlot;
            }
            else
            {
                var birdReports = _unitOfWork.BirdTrainingReportRepository.Get(e => e.BirdTrainingProgressId == birdTrainingReport.BirdTrainingProgressId
                                                                               , nameof(BirdTrainingReport.TrainerSlot)).Result.ToList();
                if (!birdReports.Any(e => e.Status == (int)Models.Enum.BirdTrainingReport.Status.Done))
                {
                    return (int)Models.Enum.BirdTrainingReport.FirstOrEnd.FirstSlot;
                }
                else
                {
                    var endSlot = birdReports.Where(e => e.Status == (int)Models.Enum.BirdTrainingReport.Status.NotYet).ToList();
                    if (endSlot == null || endSlot.Count() == 0 || endSlot.Count() == 1)
                    {
                        return (int)Models.Enum.BirdTrainingReport.FirstOrEnd.EndSlot;
                    }
                }
                return (int)Models.Enum.BirdTrainingReport.FirstOrEnd.MidSlot;
            }
        }
    }
}