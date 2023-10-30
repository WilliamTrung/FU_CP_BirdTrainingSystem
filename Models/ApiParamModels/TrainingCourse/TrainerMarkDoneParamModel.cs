using Microsoft.AspNetCore.Http;
using Models.ServiceModels.TrainingCourseModels.BirdTrainingProgress;
using SP_Validator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.ApiParamModels.TrainingCourse
{
    public class TrainerMarkDoneParamModel
    {
        public int Id { get; set; }
        [FileImageValidator]
        public List<IFormFile>? Evidences { get; set; }

        public MarkSkillDone ToMarkSkill(string evidence)
        {
            return new MarkSkillDone
            {
                Id= Id,
                Evidence = evidence
            };
        }
    }
}
