using Models.ServiceModels.SlotModels;
using Models.ServiceModels.TrainingCourseModels;
using Models.ServiceModels.TrainingCourseModels.BirdTrainingCourse;
using Models.ServiceModels.TrainingCourseModels.BirdTrainingProgress;
using Models.ServiceModels.TrainingCourseModels.BirdTrainingReport;
using System;
using System.Collections.Generic;
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

        public async Task<IEnumerable<BirdTrainingCourseModel>> GetBirdTrainingCourse()
        {
            return await _trainingCourse.Staff.GetBirdTrainingCourse();
        }

        public async Task<IEnumerable<TrainingCourseSkillModel>> GetTrainingCourseSkill(int trainingCourseId)
        {
            return await _trainingCourse.Staff.GetTrainingCourseSkill(trainingCourseId);
        }

        public async Task<IEnumerable<TrainerModel>> GetTrainerByBirdSkillId(int birdSkillId)
        {
            return await _trainingCourse.Staff.GetTrainerByBirdSkillId(birdSkillId);
        }

        public async Task AssignTrainer(AssignTrainerToCourse assignTrainer)
        {
            var progress = await _trainingCourse.Staff.AssignTrainer(assignTrainer);

            var birdTrainingCourse = GetBirdTrainingCourse().Result.Where(m => m.Id == assignTrainer.BirdTrainingCourseId).First();
            var listSkillInCourse = GetTrainingCourseSkill(birdTrainingCourse.TrainingCourseId);
            var trainingSkill = listSkillInCourse.Result.FirstOrDefault(m => m.BirdSkillId == assignTrainer.TrainingCourseSkillId);
            
            
            DateTime start= DateTime.Now.AddDays(2);
            await ModifyActualStartTime(start, assignTrainer.BirdTrainingCourseId);
            for(int i=0; i<trainingSkill.TotalSlot; i++)
            {
                DateTime current = start;
                List<SlotModel> slotModels = _timetable.GetTrainerFreeSlotOnDate(DateOnly.FromDateTime(current), assignTrainer.TrainerId).Result.ToList();
                SlotModel autoFill = slotModels.First();

                //if(autoFill != null)
                {
                    TrainerSlotModel model = new TrainerSlotModel();
                    model.SlotId = autoFill.Id;
                    model.Date = current;
                    model.EntityTypeId = (int)Models.Enum.EntityType.TrainingCourse;
                    model.EntityId = progress.Id;
                    await ConfirmTrainerSlot(model);
                }
                start = start.AddDays(1);
            }
        }

        public async Task ConfirmTrainerSlot(TrainerSlotModel trainerSlotModel)
        {
            await _trainingCourse.Staff.ConfirmTrainerSlot(trainerSlotModel);
        }

        public async Task InitStartTime(BirdTrainingCourseStartTime birdTrainingCourse)
        {
            await _trainingCourse.Staff.InitStartTime(birdTrainingCourse);
        }

        public async Task ReceiveBird(BirdTrainingCourseReceiveBird birdTrainingCourse)
        {
            await _trainingCourse.Staff.ReceiveBird(birdTrainingCourse);
        }

        public async Task ReturnBird(BirdTrainingCourseReturnBird birdTrainingCourse)
        {
            await _trainingCourse.Staff.ReturnBird(birdTrainingCourse);
        }

        public async Task<IEnumerable<BirdTrainingCourseModel>> GetBirdTrainingCourseByBirdId(int birdId)
        {
            return await _trainingCourse.Staff.GetBirdTrainingCourseByBirdId(birdId);
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

        public async Task GenerateTrainerTimetable(InitReportTrainerSlot report)
        {
            await _trainingCourse.Staff.GenerateTrainerTimetable(report);
        }

        public async Task ModifyActualStartTime(DateTime startDate, int birdTrainingCourseId)
        {
            await _trainingCourse.Staff.ModifyActualStartTime(startDate, birdTrainingCourseId);
        }

        public async Task ModifyTrainerSlot(ModifyTrainerSlot trainerSlot)
        {
            await _trainingCourse.Staff.ModifyTrainerSlot(trainerSlot);
        }
    }
}
