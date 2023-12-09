using AppRepository.UnitOfWork;
using AutoMapper;
using Models.Entities;
using Models.ServiceModels;
using Models.ServiceModels.SlotModels;
using Models.ServiceModels.TrainingCourseModels;
using Models.ServiceModels.TrainingCourseModels.BirdCertificate;
using Models.ServiceModels.TrainingCourseModels.BirdCertificate.BirdCertificateDetail;
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
        private async Task DeleteReportTrainerSlot(BirdTrainingCourse birdTrainingCourse, int reportStatus)
        {
            var progresses = await _unitOfWork.BirdTrainingProgressRepository.Get(e => e.BirdTrainingCourseId == birdTrainingCourse.Id);
            if (progresses != null)
            {
                if (progresses.Count() > 0)
                {
                    foreach (var progress in progresses)
                    {
                        var reports = _unitOfWork.BirdTrainingReportRepository.Get(e => e.BirdTrainingProgressId == progress.Id
                                                                                    , nameof(BirdTrainingReport.TrainerSlot)).Result.ToList();
                        if (reportStatus == (int)Models.Enum.BirdTrainingReport.Status.NotYet)
                        {
                            reports = reports.Where(e => e.Status == reportStatus).ToList();
                        }
                        if (reports != null)
                        {
                            if (reports.Count() > 0)
                            {
                                foreach (var report in reports)
                                {
                                    await _unitOfWork.BirdTrainingReportRepository.Delete(report);
                                    await _unitOfWork.TrainerSlotRepository.Delete(report.TrainerSlot);
                                }
                            }
                        }
                        progress.Status = (int)Models.Enum.BirdTrainingProgress.Status.Cancel;
                        await _unitOfWork.BirdTrainingProgressRepository.Update(progress);
                    }
                }
            }
        }
        public async Task<IEnumerable<BirdTrainingCourseListView>> GetBirdTrainingCourse()
        {
            var entities = await _unitOfWork.BirdTrainingCourseRepository.Get(expression: null
                                                                                , nameof(BirdTrainingCourse.TrainingCourse)
                                                                                , nameof(BirdTrainingCourse.Bird)
                                                                                , nameof(BirdTrainingCourse.Customer)
                                                                                , $"{nameof(BirdTrainingCourse.Customer)}.{nameof(BirdTrainingCourse.Customer.User)}");
            var models = _mapper.Map<IEnumerable<BirdTrainingCourseListView>>(entities);
            return models.OrderByDescending(e => e.Status);
        }

        public async Task<IEnumerable<BirdTrainingCourseListView>> GetBirdTrainingCourseByBirdId(int birdId)
        {
            var entities = await _unitOfWork.BirdTrainingCourseRepository.Get(e => e.BirdId == birdId
                                                                                , nameof(BirdTrainingCourse.TrainingCourse)
                                                                                , nameof(BirdTrainingCourse.Bird)
                                                                                , nameof(BirdTrainingCourse.Customer)
                                                                                , $"{nameof(BirdTrainingCourse.Customer)}.{nameof(BirdTrainingCourse.Customer.User)}");
            var models = _mapper.Map<IEnumerable<BirdTrainingCourseListView>>(entities);
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

        public async Task<IEnumerable<int>> ConfirmBirdTrainingCourse(BirdTrainingCourseConfirm confirmModel)
        {
            var birdTrainingCourse = await _unitOfWork.BirdTrainingCourseRepository.GetFirst(e => e.Id == confirmModel.BirdTrainingCourseId);
            var trainingSkill = await _unitOfWork.TrainingCourseSkillRepository.Get(e => e.TrainingCourseId == birdTrainingCourse.TrainingCourseId);

            List<int> progressIds = new List<int>();

            var birdTrainingProgress = _unitOfWork.BirdTrainingProgressRepository.Get(e => e.BirdTrainingCourseId == confirmModel.BirdTrainingCourseId).Result.ToList();
            if (birdTrainingProgress != null)
            {
                if (birdTrainingProgress.Count() == trainingSkill.Count())
                {
                    foreach (var progress in birdTrainingProgress)
                    {
                        progressIds.Add(progress.Id);
                    }
                }
                else
                {

                    if (trainingSkill != null && trainingSkill.Count() > 0)
                    {
                        foreach (var skill in trainingSkill.ToList())
                        {
                            if (skill != null)
                            {
                                GenerateCourseProgress newClass = new GenerateCourseProgress
                                {
                                    BirdTrainingCourseId = confirmModel.BirdTrainingCourseId,
                                    TrainingCourseSkillId = skill.Id
                                };
                                var entity = _mapper.Map<BirdTrainingProgress>(newClass);
                                entity.TotalTrainingSlot = skill.TotalSlot;
                                entity.Status = (int)Models.Enum.BirdTrainingProgress.Status.WaitingForTimetable;
                                await _unitOfWork.BirdTrainingProgressRepository.Add(entity);
                                progressIds.Add(entity.Id);
                            }
                        }
                        //birdTrainingCourse.Status = (int)Models.Enum.BirdTrainingCourse.Status.Confirmed;
                        //await _unitOfWork.BirdTrainingCourseRepository.Update(birdTrainingCourse);
                    }
                }
                birdTrainingCourse.StaffId = confirmModel.StaffId;
                await _unitOfWork.BirdTrainingCourseRepository.Update(birdTrainingCourse);
            }

            return progressIds;
        }

        public async Task CancelBirdTrainingCourse(int birdTrainingCourseId)
        {
            var entity = _unitOfWork.BirdTrainingCourseRepository.GetFirst(e => e.Id == birdTrainingCourseId).Result;
            if (entity == null)
            {
                throw new Exception(nameof(BirdTrainingCourse) + " is not found.");
            }
            else
            {
                if (entity.Status == (int)Models.Enum.BirdTrainingCourse.Status.Registered || entity.Status == (int)Models.Enum.BirdTrainingCourse.Status.Confirmed)
                {
                    entity.Status = (int)Models.Enum.BirdTrainingCourse.Status.Cancel;
                    await _unitOfWork.BirdTrainingCourseRepository.Update(entity);

                    await DeleteReportTrainerSlot(entity, -1);
                    //var progresses = await _unitOfWork.BirdTrainingProgressRepository.Get(e => e.BirdTrainingCourseId == entity.Id);
                    //if(progresses != null)
                    //{
                    //    if(progresses.Count() > 0)
                    //    {
                    //        foreach(var progress in progresses)
                    //        {
                    //            var reports = _unitOfWork.BirdTrainingReportRepository.Get(e => e.BirdTrainingProgressId == progress.Id
                    //                                                                        , nameof(BirdTrainingReport.TrainerSlot)).Result.ToList();
                    //            if(reports != null)
                    //            {
                    //                if(reports.Count() > 0)
                    //                {
                    //                    foreach(var report in reports)
                    //                    {
                    //                        await _unitOfWork.BirdTrainingReportRepository.Delete(report);
                    //                        await _unitOfWork.TrainerSlotRepository.Delete(report.TrainerSlot);
                    //                    }
                    //                }
                    //            }
                    //            progress.Status = (int)Models.Enum.BirdTrainingProgress.Status.Cancel;
                    //            await _unitOfWork.BirdTrainingProgressRepository.Update(progress);
                    //        } 
                    //    }
                    //}
                }
                else
                {
                    throw new Exception(nameof(BirdTrainingCourse) + " cannot be cancelled after check in state.");
                }
            }
        }

        public async Task<IEnumerable<BirdTrainingProgressViewModel>> GetTrainingCourseSkill(int birdTrainingCourseId)
        {
            var entities = await _unitOfWork.BirdTrainingProgressRepository.Get(e => e.BirdTrainingCourseId == birdTrainingCourseId);
            var models = _mapper.Map<IEnumerable<BirdTrainingProgressViewModel>>(entities);

            //foreach (var entity in entities)
            //{
            //    await _unitOfWork.BirdTrainingProgressRepository.Delete(entity);
            //}

            return models;
        }
        public async Task<IEnumerable<ReportModifyViewModel>> GetReportByProgressId(int progressId)
        {
            var entities = await _unitOfWork.BirdTrainingReportRepository.Get(e => e.BirdTrainingProgressId == progressId
                                                                               , nameof(BirdTrainingReport.TrainerSlot));
            var models = _mapper.Map<IEnumerable<ReportModifyViewModel>>(entities);
            return models;
        }

        public async Task CreateTrainingReport(InitReportTrainerSlot report)
        {
            if (report == null)
            {
                throw new Exception("Null param from client" + nameof(report));
            }
            var entity = _mapper.Map<BirdTrainingReport>(report);
            if (entity == null)
            {
                throw new Exception("Mapping failed");
            }
            else
            {
                entity.Status = (int)Models.Enum.BirdTrainingReport.Status.NotYet;
                await _unitOfWork.BirdTrainingReportRepository.Add(entity);

                var birdTrainingClass = _unitOfWork.BirdTrainingProgressRepository.GetFirst(e => e.Id == report.BirdTrainingProgressId).Result;
                var reports = _unitOfWork.BirdTrainingReportRepository.Get(e => e.Id == report.BirdTrainingProgressId).Result.ToList();

                if (birdTrainingClass.TotalTrainingSlot == reports.Count())
                {
                    birdTrainingClass.Status = (int)Models.Enum.BirdTrainingProgress.Status.WaitingForAssign;
                    await _unitOfWork.BirdTrainingProgressRepository.Update(birdTrainingClass);
                }
            }
        }

        public async Task<IEnumerable<BirdTrainingProgressViewModel>> GetBirdTrainingProgress()
        {
            var entities = await _unitOfWork.BirdTrainingProgressRepository.Get();
            var models = _mapper.Map<IEnumerable<BirdTrainingProgressViewModel>>(entities);
            return models;
        }

        public async Task ModifyTrainingSlot(ReportModifyModel reportModModel)
        {
            var entity = await _unitOfWork.BirdTrainingReportRepository.GetFirst(e => e.Id == reportModModel.ReportId
                                                                                   , nameof(BirdTrainingReport.TrainerSlot));
            if (entity == null || entity.TrainerSlot == null)
            {
                throw new Exception("Not found entity or trainer slot");
            }
            else
            {
                if (reportModModel.TrainerId != null)
                {
                    if (entity.TrainerSlot.TrainerId == null || entity.TrainerSlot.TrainerId != reportModModel.TrainerId)
                    {
                        entity.TrainerSlot.TrainerId = reportModModel.TrainerId;
                    }
                }

                entity.TrainerSlot.SlotId = reportModModel.SlotId;
                entity.TrainerSlot.Date = reportModModel.Date;

                await _unitOfWork.BirdTrainingReportRepository.Update(entity);
            }

            var progress = _unitOfWork.BirdTrainingProgressRepository.GetFirst(e => e.Id == entity.BirdTrainingProgressId).Result;
            var progresses = _unitOfWork.BirdTrainingProgressRepository.Get(e => e.BirdTrainingCourseId == progress.BirdTrainingCourseId).Result.ToList();

            var trainingSkillSlot = await _unitOfWork.TrainerSlotRepository.Get(e => e.EntityTypeId == (int)Models.Enum.EntityType.TrainingCourse);
            trainingSkillSlot = trainingSkillSlot.Where(e => progresses.Any(p => p.Id == e.EntityId));


            trainingSkillSlot = trainingSkillSlot.OrderBy(e => e.Date);
            DateTime startTraining = trainingSkillSlot.First().Date;

            var birdTrainingProgress = await _unitOfWork.BirdTrainingProgressRepository.GetFirst(e => e.Id == entity.BirdTrainingProgressId);
            await ModifyActualStartTime(startTraining, birdTrainingProgress.BirdTrainingCourseId);
        }

        public async Task<BirdTrainingProgressViewModel> AssignTrainer(int progressId, int trainerId)
        {
            var birdTrainingClass = await _unitOfWork.BirdTrainingProgressRepository.GetFirst(e => e.Id == progressId
                                                                                                  , nameof(BirdTrainingProgress.BirdTrainingCourse));
            var reports = await _unitOfWork.BirdTrainingReportRepository.Get(e => e.BirdTrainingProgressId == birdTrainingClass.Id
                                                                             , nameof(BirdTrainingReport.TrainerSlot));
            if (birdTrainingClass == null)
            {
                throw new Exception(nameof(BirdTrainingProgress) + " is not found.");
            }
            else
            {
                foreach (var item in reports.ToList())
                {
                    if (item != null)
                    {
                        item.TrainerSlot.TrainerId = trainerId;
                        await _unitOfWork.BirdTrainingReportRepository.Update(item);
                    }
                }
                birdTrainingClass.TrainerId = trainerId;
                birdTrainingClass.Status = (int)Models.Enum.BirdTrainingProgress.Status.Assigned;
                await _unitOfWork.BirdTrainingProgressRepository.Update(birdTrainingClass);

                if (IsAssignForAllClass(birdTrainingClass.BirdTrainingCourse.Id))
                {
                    birdTrainingClass.BirdTrainingCourse.Status = (int)Models.Enum.BirdTrainingCourse.Status.Confirmed;
                    await _unitOfWork.BirdTrainingProgressRepository.Update(birdTrainingClass);
                }
                return _mapper.Map<BirdTrainingProgressViewModel>(birdTrainingClass);
            }
        }
        private bool IsAssignForAllClass(int birdTrainingCourseId)
        {
            var progresses = _unitOfWork.BirdTrainingProgressRepository.Get(e => e.BirdTrainingCourseId == birdTrainingCourseId).Result.ToList();
            return !progresses.Any(e => e.Status == (int)Models.Enum.BirdTrainingProgress.Status.WaitingForAssign);
        }

        public async Task<TrainingCourseTrainerSlotModel> CreateTrainerSlot(TrainerSlotAddModel trainerSlotModel)
        {
            var entity = _mapper.Map<TrainerSlot>(trainerSlotModel);
            entity.Status = (int)Models.Enum.TrainerSlotStatus.Enabled;
            entity.Reason = "Training bird at the center.";
            await _unitOfWork.TrainerSlotRepository.Add(entity);

            var model = _mapper.Map<TrainingCourseTrainerSlotModel>(entity);

            return model;
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
        //private async Task CreateTransaction(TransactionAddModel transactionAddModel)
        //{
        //    if (transactionAddModel == null)
        //    {
        //        throw new Exception("Client send null param");
        //    }
        //    else
        //    {
        //        var entity = _mapper.Map<Transaction>(transactionAddModel);
        //        if (entity != null)
        //        {
        //            await _unitOfWork.TransactionRepository.Add(entity);
        //        }
        //    }
        //}
        //private TransactionAddModel OfflineGenerateBill(BirdTrainingCourse entity)
        //{
        //    var model = _mapper.Map<BirdTrainingCourseListView>(entity);
        //    if (model != null)
        //    {
        //        TransactionAddModel transactionAddModel = new TransactionAddModel()
        //        {
        //            CustomerId = model.CustomerId,
        //            Title = $"Offline payment at center requestedId = {model.Id}",
        //            Detail = $"Offline payment at center requestedId = {model.Id}",
        //            EntityTypeId = (int)Models.Enum.EntityType.TrainingCourse,
        //            EntityId = model.Id,
        //            TotalPayment = model.ActualPrice,
        //            PaymentCode = "Pay offline at center",
        //            Status = (int)Models.Enum.Transaction.Status.Paid,
        //        };
        //        return transactionAddModel;
        //    }
        //    else
        //    {
        //        throw new Exception("Mapping error");
        //    }
        //}
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
                //else if (entity.Status != (int)Models.Enum.BirdTrainingCourse.Status.TrainingDone)
                //{
                //    throw new Exception("Bird is training. Not ready to return");
                //}
                else
                {
                    var policy = _unitOfWork.TrainingCourseCheckOutPolicyRepository.GetFirst(e => e.Id == birdTrainingCourse.TrainingPricePolicyId
                                                                                                  && e.Status == (int)Models.Enum.TCCheckOutPolicy.Status.Active);
                    if(policy == null)
                    {
                        throw new InvalidOperationException("Training Price Policy is not valid or active");
                    }

                    entity.TrainingCourseCheckOutPolicyId = birdTrainingCourse.TrainingPricePolicyId;
                    await _unitOfWork.BirdTrainingCourseRepository.Update(entity);

                    entity.ReturnStaffId = birdTrainingCourse.ReturnStaffId;
                    entity.DateReturn = DateTime.UtcNow.AddHours(7);
                    entity.ReturnNote = birdTrainingCourse.ReturnNote;
                    entity.ReturnPicture = birdTrainingCourse.ReturnPicture;
                    if (entity.Status != (int)Models.Enum.BirdTrainingCourse.Status.TrainingDone)
                    {
                        await DeleteReportTrainerSlot(entity, (int)Models.Enum.BirdTrainingReport.Status.NotYet);
                    }
                    entity.Status = (int)Models.Enum.BirdTrainingCourse.Status.Complete;

                    //var transactionAddModel = OfflineGenerateBill(entity);
                    //await CreateTransaction(transactionAddModel);

                    await _unitOfWork.BirdTrainingCourseRepository.Update(entity);
                }
            }
        }

        //public async Task CreateBirdCertificateDetail(BirdCertificateDetailAddModel birdCertificateDetailAdd)
        //{
        //    if (birdCertificateDetailAdd == null)
        //    {
        //        throw new Exception("Client send null param.");
        //    }
        //    else
        //    {
        //        var entity = _mapper.Map<BirdCertificateDetail>(birdCertificateDetailAdd);
        //        await _unitOfWork.BirdCertificateDetailRepository.Add(entity);

        //        var birdTrainingCourse = _unitOfWork.BirdTrainingCourseRepository.GetFirst(e => e.Id == entity.BirdTrainingCourseId).Result;
        //        if (birdTrainingCourse != null)
        //        {
        //            var passedSkill = _unitOfWork.BirdTrainingProgressRepository.Get(e => e.BirdTrainingCourseId == birdTrainingCourse.Id
        //                                                                              && e.Status == (int)Models.Enum.BirdTrainingProgress.Status.Pass).Result.ToList();
        //            if (passedSkill != null && passedSkill.Count() > 0)
        //            {
        //                foreach (var skill in passedSkill)
        //                {
        //                    if (skill != null)
        //                    {
        //                        BirdSkillReceivedAddDeleteModel birdSkillReceivedAddModel = new BirdSkillReceivedAddDeleteModel()
        //                        {
        //                            BirdId = entity.BirdId,
        //                            BirdSkillId = skill.TrainingCourseSkillId,
        //                        };
        //                        var birdSkillReceivedAdd = _mapper.Map<BirdSkillReceived>(birdSkillReceivedAddModel);
        //                        await _unitOfWork.BirdSkillReceivedRepository.Add(birdSkillReceivedAdd);
        //                    }
        //                }
        //            }
        //        }
        //    }
        //}

        public async Task GenerateTrainerTimetable(DateTime startTrainingDate, int startTrainingSlot, IEnumerable<int> progressId)
        {
            var progresses = _unitOfWork.BirdTrainingProgressRepository.Get(e => progressId.Any(p => p == e.Id)).Result.OrderBy(e => e.Id).ToList();

            var firstClass = progresses.First();
            var birdTrainingCourse = GetBirdTrainingCourse().Result.Where(m => m.Id == firstClass.BirdTrainingCourseId).First();
            DateTime start = startTrainingDate;
            await ModifyActualStartTime(start, firstClass.BirdTrainingCourseId);

            foreach (var progress in progresses)
            {
                var reports = _unitOfWork.BirdTrainingReportRepository.Get(e => e.BirdTrainingProgressId == progress.Id).Result.ToList();
                if (reports.Count() != progress.TotalTrainingSlot)
                {
                    var listTrainerSlot = AutoCreateTimetable(ref start, startTrainingSlot, progress).ToList();
                    if (listTrainerSlot.Count > 0)
                    {
                        foreach (var trainerSlot in listTrainerSlot)
                        {
                            InitReportTrainerSlot report = new InitReportTrainerSlot
                            {
                                BirdTrainingProgressId = progress.Id,
                                TrainerSlotId = trainerSlot.Id
                            };
                            await CreateTrainingReport(report);
                        }
                        progress.Status = (int)Models.Enum.BirdTrainingProgress.Status.WaitingForAssign;
                        await _unitOfWork.BirdTrainingProgressRepository.Update(progress);
                    }
                }
            }
            //await _trainingCourse.Staff.GenerateTrainerTimetable(report);
        }

        private IEnumerable<TrainingCourseTrainerSlotModel> AutoCreateTimetable(ref DateTime start, int slotStart, BirdTrainingProgress progress)
        {
            List<TrainingCourseTrainerSlotModel> trainerSlots = new List<TrainingCourseTrainerSlotModel>(); //day1
            var totalSlot = progress.TotalTrainingSlot; //10
            while (totalSlot > 0)
            {
                DateTime current = start; //day1
                //List<Slot> slotModels = _unitOfWork.SlotRepository.Get().Result.ToList();
                //Slot autoFill = slotModels.First();
                var autoFill = _unitOfWork.SlotRepository.GetFirst(e => e.Id == slotStart).Result;
                if (autoFill == null)
                {
                    throw new Exception("Selected slot is out of the center.");
                }

                if (autoFill != null)
                {
                    TrainerSlotAddModel model = new TrainerSlotAddModel();
                    model.SlotId = autoFill.Id;
                    model.Date = current;
                    model.EntityTypeId = (int)Models.Enum.EntityType.TrainingCourse;
                    model.EntityId = progress.Id;
                    var entityModel = CreateTrainerSlot(model).Result;
                    trainerSlots.Add(entityModel);
                    totalSlot--;
                }
                start = start.AddDays(1);
            }
            return trainerSlots;
        }
    }
}
