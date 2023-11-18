using AppRepository.UnitOfWork;
using AutoMapper;
using Models.Entities;
using Models.ServiceModels.TrainingCourseModels.BirdCertificate;
using Models.ServiceModels.TrainingCourseModels.BirdCertificate.BirdCertificateDetail;
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

        public async Task<IEnumerable<BirdTrainingProgressModel>> GetBirdTrainingProgressByTrainerId(int trainerId)
        {
            var entities = await _unitOfWork.BirdTrainingProgressRepository.Get(e => e.TrainerId == trainerId);
            var models = _mapper.Map<IEnumerable<BirdTrainingProgressModel>>(entities);
            return models;
        }

        public async Task<TimetableReportView> GetTimetableReportView(int birdTrainingReportId)
        {
            var entity = await _unitOfWork.BirdTrainingReportRepository.GetFirst(e => e.Id == birdTrainingReportId);
            var model = _mapper.Map<TimetableReportView>(entity);
            return model;
        }

        public async Task MarkTrainingSkillDone(MarkSkillDone markDone)
        {
            var entity = _unitOfWork.BirdTrainingProgressRepository.GetFirst(e => e.Id == markDone.Id).Result;
            if (entity == null)
            {
                throw new Exception("Entity not found");
            }
            else
            {
                entity.Evidence = markDone.Evidence;
                entity.TrainingDoneDate = DateTime.Now;
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
                if (allDone)
                {
                    var birdTrainingCourse = _unitOfWork.BirdTrainingCourseRepository.GetFirst(e => e.Id == entity.BirdTrainingCourseId
                                                                                               , nameof(BirdTrainingCourse.TrainingCourse)).Result;
                    birdTrainingCourse.TrainingDoneDate = DateTime.Now;
                    birdTrainingCourse.Status = (int)Models.Enum.BirdTrainingCourse.Status.TrainingDone;

                    var bird = _unitOfWork.BirdRepository.GetFirst(e => e.Id == birdTrainingCourse.BirdId).Result;
                    bird.Status = (int)Models.Enum.Bird.Status.Ready;

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
                    throw new Exception($"Bird certificate already given.");
                }

                var entity = _mapper.Map<BirdCertificateDetail>(birdCertificateDetailAdd);
                await _unitOfWork.BirdCertificateDetailRepository.Add(entity);

                var birdTrainingCourse = _unitOfWork.BirdTrainingCourseRepository.GetFirst(e => e.Id == entity.BirdTrainingCourseId).Result;
                if (birdTrainingCourse != null)
                {
                    var passedSkill = _unitOfWork.BirdTrainingProgressRepository.Get(e => e.BirdTrainingCourseId == birdTrainingCourse.Id
                                                                                      && e.Status == (int)Models.Enum.BirdTrainingProgress.Status.Pass
                                                                                      , nameof(BirdTrainingProgress.TrainingCourseSkill)
                                                                                      ,$"{nameof(BirdTrainingProgress.TrainingCourseSkill)}.{nameof(BirdTrainingProgress.TrainingCourseSkill.BirdSkill)}").Result.ToList();
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
                                var birdSkillReceivedAdd = _mapper.Map<BirdSkillReceived>(birdSkillReceivedAddModel);
                                await _unitOfWork.BirdSkillReceivedRepository.Add(birdSkillReceivedAdd);
                            }
                        }
                    }
                }
            }
        }

        public async Task<int> MarkTrainingSlotDone(int birdTrainingReportId)//status 206 de chuyen qua trang khac
        {
            int result = (int)Models.Enum.BirdTrainingReport.FirstOrEnd.MidSlot;
            var entity = await _unitOfWork.BirdTrainingReportRepository.GetFirst(e => e.Id == birdTrainingReportId);
            if (entity == null)
            {
                throw new Exception("Entity not found");
            }
            else
            {
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
                    }
                    await _unitOfWork.BirdTrainingProgressRepository.Update(birdProgress);

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
                    if(endSlot == null)
                    {
                        return (int)Models.Enum.BirdTrainingReport.FirstOrEnd.EndSlot;
                    }else if(endSlot.Count() == 1)
                    {
                        return (int)Models.Enum.BirdTrainingReport.FirstOrEnd.EndSlot;
                    }
                }
                return (int)Models.Enum.BirdTrainingReport.FirstOrEnd.MidSlot;
            }
        }
    }
}