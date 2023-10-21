using AutoMapper;
using Models.Entities;
using Models.ServiceModels.TrainingCourseModels.BirdTrainingProgress;
using Models.ServiceModels.TrainingCourseModels.BirdTrainingReport;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SP_AutoMapperConfig
{
    public class BirdTrainingReportProfile : Profile
    {
        public BirdTrainingReportProfile()
        {
            Map_BirdTrainingReport_BirdTrainingReportModel();
        }
        private void Map_BirdTrainingReport_BirdTrainingReportModel()
        {
            CreateMap<BirdTrainingReport, BirdTrainingReportViewModel>()
                .ForMember(m => m.Status, opt => opt.MapFrom(e => e.Status))
                .ForMember(m => m.TrainingDate, opt => {
                    opt.PreCondition(e => e.TrainerSlot != null);
                    opt.MapFrom(e => e.TrainerSlot.Date);
                });
        }
    }
}
