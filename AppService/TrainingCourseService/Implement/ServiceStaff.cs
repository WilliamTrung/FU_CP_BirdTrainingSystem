using Models.ApiParamModels.OnlineCourse;
using Models.ApiParamModels.TrainingCourse;
using Models.ServiceModels;
using Models.ServiceModels.SlotModels;
using Models.ServiceModels.TrainingCourseModels;
using Models.ServiceModels.TrainingCourseModels.BirdCertificate.BirdCertificateDetail;
using Models.ServiceModels.TrainingCourseModels.BirdTrainingCourse;
using Models.ServiceModels.TrainingCourseModels.BirdTrainingProgress;
using Models.ServiceModels.TrainingCourseModels.BirdTrainingReport;
using Models.ServiceModels.TrainingCourseModels.TrainerSlot;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimetableSubsystem;
using TrainingCourseSubsystem;
using TransactionSubsystem;

namespace AppService.TrainingCourseService.Implement
{
    public class ServiceStaff : ServiceAll, IServiceStaff
    {
        private readonly IFeatureTransaction _transaction;
        public ServiceStaff(ITrainingCourseFeature trainingCourse, ITimetableFeature timetable, IFeatureTransaction transaction, IMailService mail) : base(trainingCourse, timetable, mail)
        {
            _transaction = transaction;
        }
        public async Task<IEnumerable<BirdTrainingProgressViewModel>> ConfirmBirdTrainingCourse(BirdTrainingCourseConfirm confirmModel)
        {
            List<int> progresses = _trainingCourse.Staff.ConfirmBirdTrainingCourse(confirmModel).Result.ToList();
            DateTime startDate = DateTime.Now.AddDays(4);
            int slotId = 1;
            await GenerateTrainerTimetable(startDate, slotId, progresses);

            List<BirdTrainingProgressViewModel> progressModels = new List<BirdTrainingProgressViewModel>();
            if(progresses != null)
            {
                if(progresses.Count > 0)
                {
                    List<BirdTrainingProgressViewModel> query = _trainingCourse.Staff.GetBirdTrainingProgress().Result
                                                                 .Where(e => progresses.Any(c => c == e.Id)).ToList();
                    if(query != null)
                    {
                        progressModels = query;
                    }
                }
            }
            return progressModels;
        }
        public async Task CancelBirdTrainingCourse(int birdTrainingCourseId)
        {
            await _trainingCourse.Staff.CancelBirdTrainingCourse(birdTrainingCourseId);
        }
        public async Task GenerateTrainerTimetable(DateTime startTrainingDate, int startTrainingSlot, IEnumerable<int> progressId)
        {
            await _trainingCourse.Staff.GenerateTrainerTimetable(startTrainingDate, startTrainingSlot, progressId);
        }

        //public async Task GenerateTrainingTimetable(SelectedSlotInProgress selectedSlot)
        //{
        //    var progresses = _trainingCourse.Staff.GetBirdTrainingProgress().Result;
        //    var progress = progresses.FirstOrDefault(e => e.Id == selectedSlot.ProgressId);
        //    if (progress != null)
        //    {
        //        if(progress.TotalTrainingSlot == selectedSlot.TrainerSlotParams.Count())
        //        {
        //            foreach(var slot in selectedSlot.TrainerSlotParams)
        //            {
        //                TrainerSlotAddModel model = new TrainerSlotAddModel();
        //                model.SlotId = slot.SlotId;
        //                model.Date = slot.Date;
        //                model.EntityTypeId = (int)Models.Enum.EntityType.TrainingCourse;
        //                model.EntityId = progress.Id;
        //                var entityModel = _trainingCourse.Staff.CreateTrainerSlot(model).Result;
        //                InitReportTrainerSlot report = new InitReportTrainerSlot()
        //                {
        //                    BirdTrainingProgressId = progress.Id,
        //                    TrainerSlotId = entityModel.Id,
        //                };
        //                await _trainingCourse.Staff.CreateTrainingReport(report);
        //            }
        //        }
        //        else
        //        {
        //            throw new Exception("Total select slot must equal total training slot.");
        //        }
        //    }
        //}

        //public async Task AssignTrainer(AssignTrainerToCourse assignTrainer)
        //{
        //    var progress = await _trainingCourse.Staff.AssignTrainer(assignTrainer);

        //    //var birdTrainingCourse = GetBirdTrainingCourse().Result.Where(m => m.Id == progress.BirdTrainingCourseId).First();

        //    //DateTime start = DateTime.Now.AddDays(2);
        //    //await ModifyActualStartTime(start, progress.BirdTrainingCourseId);
        //    //for (int i = 0; i < trainingSkill.TotalSlot; i++)
        //    //{
        //    //    DateTime current = start;
        //    //    List<SlotModel> slotModels = _timetable.GetTrainerFreeSlotOnDate(DateOnly.FromDateTime(current), assignTrainer.TrainerId).Result.ToList();
        //    //    SlotModel autoFill = slotModels.First();

        //    //    //if(autoFill != null)
        //    //    {
        //    //        TrainerSlotModel model = new TrainerSlotModel();
        //    //        model.SlotId = autoFill.Id;
        //    //        model.Date = current;
        //    //        model.EntityTypeId = (int)Models.Enum.EntityType.TrainingCourse;
        //    //        model.EntityId = progress.Id;
        //    //        model.Status = (int)Models.Enum.TrainerSlotStatus.Enabled;
        //    //        await ConfirmTrainerSlot(model);
        //    //    }
        //    //    start = start.AddDays(1);
        //    //}
        //}

        
        public async Task<IEnumerable<BirdTrainingProgressViewModel>> GetBirdTrainingProgress()
        {
            return await _trainingCourse.Staff.GetBirdTrainingProgress();
        }

        public async Task ReceiveBird(BirdTrainingCourseReceiveBird birdTrainingCourse)
        {
            await _trainingCourse.Staff.ReceiveBird(birdTrainingCourse);
        }

        public async Task ReturnBird(BirdTrainingCourseReturnBird birdTrainingCourse)
        {
            await _trainingCourse.Staff.ReturnBird(birdTrainingCourse);

            var requests = _trainingCourse.Staff.GetBirdTrainingCourse().Result.ToList();
            var request = requests.FirstOrDefault(e => e.Id == birdTrainingCourse.Id);

            string paymentCode = "offline";
            string formattedDateTime = DateTime.UtcNow.AddHours(7).ToString("ddMMMyyyyhhmm");
            var transactionAddModel = new TransactionAddModel()
            {
                CustomerId = request.CustomerId,
                EntityId = request.Id,
                EntityTypeId = (int)Models.Enum.EntityType.TrainingCourse,
                PaymentCode = paymentCode,
                Detail = $"{paymentCode}:{request.CustomerId}:{request.CustomerEmail}-" +
                    $"check out training course {request.TrainingCourseId}:{request.TrainingCourseTitle}-at:{formattedDateTime}",
                Status = (int)Models.Enum.Transaction.Status.Paid,
                Title = "Training course check out",
                TotalPayment = request.ActualPrice,
            };
            await _transaction.AddTransaction(transactionAddModel);
        }

        public async Task<BirdTrainingProgressViewModel> AssignTrainer(int progressId, int trainerId)
        {
            //check trainer is adapt to this progress
            var check = await _trainingCourse.Staff.CheckTrainerInProgressAdaptable(progressId, trainerId);
            if (!check)
            {
                throw new InvalidOperationException("This trainer is not qualified for this skill!");
            }
            //check previous progress
            var allProgressId = await _trainingCourse.Staff.GetAllCourseProgressIdByProgressId(progressId);
            allProgressId = allProgressId.OrderBy(c => c);
            int prevProgressId = 0;
            foreach (var progress in allProgressId)
            {                
                if(progress == progressId)
                {
                    break;
                }
                prevProgressId = progress;
                var reports = await GetReportByProgressId(progress);
                if(reports.Any(c => c.TrainerId == null))
                {
                    throw new InvalidOperationException("Previous skill must be assigned!");
                }
            }   
            
            var reportsAtSelectedProgress = GetReportByProgressId(progressId).Result;
            //old
            bool IsAssignable = true;
            //end old
            List<string> busySlot = new List<string>();

            if(reportsAtSelectedProgress != null)
            {
                DateTime lastDate = reportsAtSelectedProgress.First().Date;
                if (prevProgressId == 0)
                {
                    //progressId is the first progress of skill
                    //do thing
                }
                else
                {
                    //get last day of previous report 
                    //then current progress start at get date add(1) day
                    var prevReports = await GetReportByProgressId(prevProgressId);
                    prevReports = prevReports.OrderByDescending(c => c.Date);
                    var lastExecution = prevReports.FirstOrDefault();
                    if (lastExecution != null)
                    {
                        lastDate = lastExecution.Date.AddDays(1);
                    }
                    else
                    {
                        throw new Exception("An error has occured!");
                    }
                }

                //check assigned slot of each report in list reports                
                foreach (var report in reportsAtSelectedProgress)
                {
                    report.Date = lastDate;
                    //new
                    bool isFree = false;
                    //find free slot of trainer
                    while(!isFree)
                    {
                        isFree = _timetable.CheckTrainerFree(trainerId, report.Date, report.SlotId).Result;
                        if (!isFree)
                        {
                            if(report.SlotId < 8)
                            {
                                report.SlotId++;
                            }                                
                            else
                            {
                                report.Date = report.Date.AddDays(1);
                                report.SlotId = 1;
                            }
                        }
                    }
                    lastDate = report.Date.AddDays(1);
                    var modifyModel = new ReportModifyModel
                    {
                        ReportId = report.ReportId,
                        Date = report.Date,
                        SlotId = report.SlotId,
                        TrainerId = trainerId,
                    };
                    await _trainingCourse.Staff.ModifyTrainingSlot(modifyModel);
                    //end new
                    //old
                    //var trainerFree = _timetable.CheckTrainerFree(trainerId, report.Date, report.SlotId).Result;
                    //if (!trainerFree)
                    //{
                    //    string busyString = $"/n slot {report.SlotId}, date {report.Date}";
                    //    busySlot.Add(busyString);
                    //    IsAssignable = false;
                    //}
                    //end old
                }
            }
            if(IsAssignable)
            {
                var rs = await _trainingCourse.Staff.AssignTrainer(progressId, trainerId);

                //var requesteds = _trainingCourse.All.GetBirdTrainingCourse().Result.ToList();
                //var requested = requesteds.FirstOrDefault(e => e.Id == rs.BirdTrainingCourseId);
                //if (requested == null)
                //{
                //    throw new KeyNotFoundException("BirdTrainingCourse not found");
                //}
                //else
                //{
                //    if(requested.Status == Models.Enum.BirdTrainingCourse.Status.Confirmed)
                //    {
                //        await SendNotiSendBirdToCenter(requested);
                //    }
                //}

                return rs;
            }
            else
            {
                throw new Exception($"Trainer is not free to assign at {busySlot}");
            }
        }

        public async Task ModifyTrainingSlot(ReportModifyModel reportModModel)
        {
            if(reportModModel != null)
            {
                if(reportModModel.TrainerId != null)
                {
                    bool IsBusy = await _timetable.CheckTrainerFree((int)reportModModel.TrainerId, reportModModel.Date, reportModModel.SlotId);
                    if (IsBusy)
                    {
                        await _trainingCourse.Staff.ModifyTrainingSlot(reportModModel);
                    }
                    else
                    {
                        throw new Exception("Trainer is busy at this time.");
                    }
                }
                else
                {
                    await _trainingCourse.Staff.ModifyTrainingSlot(reportModModel);
                }
            }
            else
            {
                throw new Exception("Client send null param.");
            }
        }

        //public async Task CreateBirdCertificateDetail(BirdCertificateDetailAddModel birdCertificateDetailAdd)
        //{
        //    await _trainingCourse.Staff.CreateBirdCertificateDetail(birdCertificateDetailAdd);
        //}
    }
}
