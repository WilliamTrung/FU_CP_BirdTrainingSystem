﻿using Models.Skills;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.ServiceModels
{
    //[Trainer]:
    //+ id : int
    //+ name : string
    //+ email : string
    //+ avatar : string

    public class TrainerModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Avatar { get; set; } = null!;
        public string PhoneNumber { get; set; } = null!;
        public bool ConsultantAble { get; set; }
        public Models.Enum.Trainer.Status? Status { get; set; }
        public List<TrainerSkillModel> Skills { get; set; } = null!;
    }
}
