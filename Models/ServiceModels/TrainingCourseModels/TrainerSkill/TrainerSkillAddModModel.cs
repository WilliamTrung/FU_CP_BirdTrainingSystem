﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.ServiceModels.TrainingCourseModels.TrainerSkill
{
    public class TrainerSkillAddModModel
    {
        public int TrainerId { get; set; }
        public int SkillId { get; set; }
        public string? Description { get; set; }
    }
}