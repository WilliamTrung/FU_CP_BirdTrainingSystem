using Microsoft.AspNetCore.Http;
using Models.Entities;
using Models.ServiceModels.TrainingCourseModels.Bird;
using Models.ServiceModels.TrainingCourseModels.BirdCertificate;
using SP_Validator;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Models.ApiParamModels.TrainingCourse
{
    public class BirdCertificateAddParamModel
    {
        public int TrainingCourseId { get; set; }
        public string? BirdCenterName { get; set; } //Dunno can set static 
        //public string Title { get; set; } = null!; auto get from query
        public string? ShortDescrption { get; set; }
        [FileImageValidator]
        public List<IFormFile>? Pictures { get; set; }
        public BirdCertificateAddModel ToBirdCertificateAddModel(string? picture)
        {
            return new BirdCertificateAddModel
            {
                TrainingCourseId = TrainingCourseId,
                BirdCenterName = BirdCenterName,
                ShortDescrption = ShortDescrption,
                Picture = picture
            };
        }
    }
}
