using Models.ApiParamModels.TrainingCourse;
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

namespace AppService.TrainingCourseService.Implement
{
    public class ServiceStaff : ServiceAll, IServiceStaff
    {
        public ServiceStaff(ITrainingCourseFeature trainingCourse, ITimetableFeature timetable) : base(trainingCourse, timetable)
        {
        }
        public async Task<IEnumerable<BirdTrainingCourseListView>> GetBirdTrainingCourse()
        {
            return await _trainingCourse.Staff.GetBirdTrainingCourse();
        }

        public Task<IEnumerable<BirdTrainingCourseListView>> GetBirdTrainingCourseByCustomerId(int customerId)
        {
            return _trainingCourse.Staff.GetBirdTrainingCourseByCustomerId(customerId);
        }

        public async Task<IEnumerable<BirdTrainingCourseListView>> GetBirdTrainingCourseByBirdId(int birdId)
        {
            return await _trainingCourse.Staff.GetBirdTrainingCourseByBirdId(birdId);
        }
        public async Task<IEnumerable<BirdTrainingProgressViewModel>> ConfirmBirdTrainingCourse(BirdTrainingCourseConfirm confirmModel)
        {
            List<int> progresses = _trainingCourse.Staff.ConfirmBirdTrainingCourse(confirmModel).Result.ToList();
            DateTime startDate = DateTime.Now;
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
        public async Task<IEnumerable<BirdTrainingProgressViewModel>> GetTrainingCourseSkill(int trainingCourseId)
        {
            return await _trainingCourse.Staff.GetTrainingCourseSkill(trainingCourseId);
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

        public async Task<IEnumerable<TrainerModel>> GetTrainerByBirdSkillId(int birdSkillId)
        {
            return await _trainingCourse.Staff.GetTrainerByBirdSkillId(birdSkillId);
        }

        public async Task<IEnumerable<TrainerModel>> GetTrainer()
        {
            return await _trainingCourse.Staff.GetTrainer();
        }

        public async Task<TrainerModel> GetTrainerById(int trainerId)
        {
            return await _trainingCourse.Staff.GetTrainerById(trainerId);
        }

        public async Task<IEnumerable<TrainerModel>> GetTrainerByTrainerSkillId(int trainerSkillId)
        {
            return await _trainingCourse.Staff.GetTrainerByTrainerSkillId(trainerSkillId);
        }

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
        }

        public async Task<IEnumerable<ReportModifyViewModel>> GetReportByProgressId(int progressId)
        {
            return await _trainingCourse.Staff.GetReportByProgressId(progressId);
        }

        public async Task<BirdTrainingProgressViewModel> AssignTrainer(int progressId, int trainerId)
        {
            var reports = GetReportByProgressId(progressId).Result;
            bool IsAssignable = true;
            List<string> busySlot = new List<string>();
            if(reports != null)
            {
                foreach(var report in reports)
                {
                    var trainerFree = _timetable.CheckTrainerFree(trainerId, report.Date, report.SlotId).Result;
                    if (!trainerFree)
                    {
                        string busyString = $"/n slot {report.SlotId}, date {report.Date}";
                        busySlot.Add(busyString);
                        IsAssignable = false;
                    }
                }
            }
            if(IsAssignable)
            {
                return await _trainingCourse.Staff.AssignTrainer(progressId, trainerId);
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
                bool IsBusy = await _timetable.CheckTrainerFree(reportModModel.TrainerId, reportModModel.Date, reportModModel.SlotId);
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
                throw new Exception("Client send null param.");
            }
        }

        //public async Task CreateBirdCertificateDetail(BirdCertificateDetailAddModel birdCertificateDetailAdd)
        //{
        //    await _trainingCourse.Staff.CreateBirdCertificateDetail(birdCertificateDetailAdd);
        //}
    }
}
