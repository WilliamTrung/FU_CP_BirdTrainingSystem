using Models.ApiParamModels.TrainingCourse;
using Models.ServiceModels.SlotModels;
using Models.ServiceModels.TrainingCourseModels;
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
        private bool IsTrainerFree(int trainerSlotId, int trainerId)
        {
            var trainerSlot = _timetable.GetTrainerSlotDetail(trainerSlotId).Result;
            var freeSlot = _timetable.GetTrainerFreeSlotOnDate(DateOnly.FromDateTime((DateTime)trainerSlot.Date), trainerId).Result;
            bool result = freeSlot.Any(e => e.StartTime == trainerSlot.StartTime);
            return result;
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
        public async Task<IEnumerable<int>> ConfirmBirdTrainingCourse(int birdTrainingCourseId)
        {
            List<int> progresses = _trainingCourse.Staff.ConfirmBirdTrainingCourse(birdTrainingCourseId).Result.ToList();
            await GenerateTrainerTimetable(progresses);
            return progresses;
        }
        private async Task GenerateTrainerTimetable(IEnumerable<int> progressId)
        {
            var progresses = await GetBirdTrainingProgress();
            progresses = progresses.Where(e => progressId.Any(d => d == e.Id));

            var firstClass = progresses.First();
            var birdTrainingCourse = GetBirdTrainingCourse().Result.Where(m => m.Id == firstClass.BirdTrainingCourseId).First();
            DateTime start = DateTime.Now.AddDays(3);
            await _trainingCourse.Staff.ModifyActualStartTime(start, firstClass.BirdTrainingCourseId);

            foreach (var progress in progresses)
            {
                //progress.StartTrainingDate = start;
                var listTrainerSlot = AutoCreateTimetable(ref start, progress).ToList();
                if (listTrainerSlot.Count > 0)
                {
                    foreach (var trainerSlot in listTrainerSlot)
                    {
                        InitReportTrainerSlot report = new InitReportTrainerSlot
                        {
                            BirdTrainingProgressId = progress.Id,
                            TrainerSlotId = trainerSlot.Id
                        };
                        await _trainingCourse.Staff.CreateTrainingReport(report);
                    }
                }
            }
            //await _trainingCourse.Staff.GenerateTrainerTimetable(report);
        }

        private IEnumerable<TrainerSlotModel> AutoCreateTimetable(ref DateTime start, BirdTrainingProgressModel progress)
        {
            List<TrainerSlotModel> trainerSlots = new List<TrainerSlotModel>(); //day1
            var totalSlot = progress.TotalTrainingSlot; //10
            while (totalSlot > 0)
            {
                DateTime current = start; //day1
                List<SlotModel> slotModels = _timetable.GetTrainerFreeSlotOnDate(DateOnly.FromDateTime(current), (int)progress.TrainerId).Result.ToList();
                SlotModel autoFill = slotModels.First();

                if (autoFill != null)
                {
                    TrainerSlotAddModel model = new TrainerSlotAddModel();
                    model.SlotId = autoFill.Id;
                    model.Date = current;
                    model.EntityTypeId = (int)Models.Enum.EntityType.TrainingCourse;
                    model.EntityId = progress.Id;
                    var entityModel = _trainingCourse.Staff.CreateTrainerSlot(model).Result;
                    trainerSlots.Add(entityModel);
                    totalSlot--;
                }
                start = start.AddDays(1);
            }
            return trainerSlots;
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

        
        public async Task<IEnumerable<BirdTrainingProgressModel>> GetBirdTrainingProgress()
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
    }
}
