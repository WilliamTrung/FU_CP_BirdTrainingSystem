namespace AppCore.Models
{
    public partial class BirdCertificateSkill
    {
        public int BirdSkillId { get; set; }
        public int BirdCertificateId { get; set; }
        public DateTime? ReceivedDate { get; set; }

        public virtual BirdCertificate BirdCertificate { get; set; } = null!;
        public virtual BirdSkill BirdSkill { get; set; } = null!;
    }
}
