﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.ServiceModels.TrainingCourseModels.BirdCertificate.BirdCertificateDetail
{
    public class BirdCertificateDetailViewModel
    {
        public int Id { get; set; }
        public int BirdId { get; set; }
        public string BirdName { get; set; } = null!;
        public int BirdTrainingCourseId { get; set; }
        public int BirdCertificateId { get; set; }
        public DateTime ReceiveDate { get; set; }
        public int PassedSkill { get; set; } = 0;
        public int AllSkill { get; set; } = 0;
        public BirdCertificateViewModel BirdCertificateViewModel { get; set; } = null!;
        //so luong skill pass
    }
}
