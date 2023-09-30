namespace AppCore.Models
{
    public partial class TrainingCourseSkill
    {
        public TrainingCourseSkill()
        {
            BirdTrainingProgresses = new HashSet<BirdTrainingProgress>();
        }

        public int TrainingCourseId { get; set; }
        public int BirdSkillId { get; set; }
        public decimal? Price { get; set; }

        public virtual BirdSkill BirdSkill { get; set; } = null!;
        public virtual TrainingCourse TrainingCourse { get; set; } = null!;
        public virtual ICollection<BirdTrainingProgress> BirdTrainingProgresses { get; set; }
    }
}
