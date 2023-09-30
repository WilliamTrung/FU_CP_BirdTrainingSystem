namespace Models.Entities
{
    public partial class BirdTrainingProgress
    {
        public int Id { get; set; }
        public int TrainingCourseId { get; set; }
        public int TrainingCourseSkillId { get; set; }
        public int TrainerId { get; set; }
        public int BirdId { get; set; }
        public DateTime? TrainingDoneDate { get; set; }
        public bool? IsComplete { get; set; }

        public virtual BirdTrainingCourse BirdTrainingCourse { get; set; } = null!;
        public virtual Trainer Trainer { get; set; } = null!;
        public virtual TrainingCourseSkill TrainingCourse { get; set; } = null!;
    }
}
