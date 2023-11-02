using AutoMapper;
using Models.Entities;
using Models.ServiceModels.TrainingCourseModels.Bird;
using Models.ServiceModels.TrainingCourseModels.BirdTrainingCourse;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SP_AutoMapperConfig
{
    public class BirdProfile : Profile
    {
        public BirdProfile()
        {
            Map_Bird_BirdAddModel();
            Map_Bird_BirdViewModel();
        }

        private void Map_Bird_BirdViewModel()
        {
            CreateMap<Bird, BirdViewModel>()
                .ForMember(m => m.CustomerId, opt => opt.MapFrom(e => e.CustomerId))
                .ForMember(m => m.CustomerName, opt =>
                {
                    opt.PreCondition(e => e.Customer != null);
                    opt.PreCondition(e => e.Customer.User != null);
                    opt.MapFrom(e => e.Customer.User.Name);
                })
                .ForMember(m => m.BirdSpeciesId, opt => opt.MapFrom(e => e.BirdSpeciesId))
                .ForMember(m => m.BirdSpeciesName, opt =>
                {
                    opt.PreCondition(e => e.BirdSpecies != null);
                    opt.MapFrom(e => e.BirdSpecies.Name);
                })
                .ForMember(m => m.Name, opt => opt.MapFrom(e => e.Name))
                .ForMember(m => m.Color, opt => opt.MapFrom(e => e.Color))
                .ForMember(m => m.Picture, opt => opt.MapFrom(e => e.Picture))
                .ForMember(m => m.Description, opt => opt.MapFrom(e => e.Description))
                .ForMember(m => m.IsDefault, opt => opt.MapFrom(e => e.IsDefault));
            //.ForMember(m => m.Bird, opt => {
            //    opt.PreCondition(e => e.Bird != null);
            //    opt.MapFrom(e => e.Bird);
            //})
            //.ForMember(m => m.TrainingCourse, opt => {
            //    opt.PreCondition(e => e.TrainingCourse != null);
            //    opt.MapFrom(e => e.TrainingCourse);
            //});
        }

        private void Map_Bird_BirdAddModel()
        {
            CreateMap<Bird, BirdAddModel>()
                .ForMember(m => m.CustomerId, opt => opt.MapFrom(e => e.CustomerId))
                .ForMember(m => m.BirdSpeciesId, opt => opt.MapFrom(e => e.BirdSpeciesId))
                .ForMember(m => m.Name, opt => opt.MapFrom(e => e.Name))
                .ForMember(m => m.Color, opt => opt.MapFrom(e => e.Color))
                .ForMember(m => m.Picture, opt => opt.MapFrom(e => e.Picture))
                .ForMember(m => m.Description, opt => opt.MapFrom(e => e.Description))
                .ForMember(m => m.IsDefault, opt => opt.MapFrom(e => e.IsDefault));
                //.ForMember(m => m.Bird, opt => {
                //    opt.PreCondition(e => e.Bird != null);
                //    opt.MapFrom(e => e.Bird);
                //})
                //.ForMember(m => m.TrainingCourse, opt => {
                //    opt.PreCondition(e => e.TrainingCourse != null);
                //    opt.MapFrom(e => e.TrainingCourse);
                //});
        }
    }
}
