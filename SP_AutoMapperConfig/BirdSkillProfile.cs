using AutoMapper;
using Models.Entities;
using Models.ServiceModels.TrainingCourseModels.BirdCertificate;
using Models.ServiceModels.TrainingCourseModels.BirdSkill;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SP_AutoMapperConfig
{
    public class BirdSkillProfile : Profile
    {
        public BirdSkillProfile()
        {
            Map_BirdSkillAddModel_BirdSkill();
            Map_BirdSkill_BirdSkillViewModel();
            Map_BirdSkillReceivedAddDeleteModel_BirdSkillReceived();
            Map_BirdSkillReceived_BirdSkillReceivedViewModel();
        }

        private void Map_BirdSkillReceived_BirdSkillReceivedViewModel()
        {
            CreateMap<BirdSkillReceived, BirdSkillReceivedViewModel>()
                .ForMember(m => m.BirdId, opt => opt.MapFrom(e => e.BirdId))
                .ForMember(m => m.BirdName, opt => {
                    opt.PreCondition(e => e.Bird != null);
                    opt.MapFrom(e => e.Bird.Name);
                })
                .ForMember(m => m.BirdSkillId, opt => opt.MapFrom(e => e.BirdSkillId))
                .ForMember(m => m.BirdSkillName, opt => {
                    opt.PreCondition(e => e.BirdSkill != null);
                    opt.MapFrom(e => e.BirdSkill.Name);
                })
                .ForMember(m => m.BirdSkillDescription, opt => {
                    opt.PreCondition(e => e.BirdSkill != null);
                    opt.MapFrom(e => e.BirdSkill.Description);
                })
                .ForMember(m => m.BirdSkillPicture, opt => {
                    opt.PreCondition(e => e.BirdSkill != null);
                    opt.MapFrom(e => e.BirdSkill.Picture);
                })
                .ForMember(m => m.ReceivedDate, opt => opt.MapFrom(e => e.ReceivedDate));
        }

        private void Map_BirdSkillReceivedAddDeleteModel_BirdSkillReceived()
        {
            CreateMap<BirdSkillReceivedAddDeleteModel, BirdSkillReceived>()
                .ForMember(m => m.BirdSkillId, opt => opt.MapFrom(e => e.BirdSkillId))
                .ForMember(m => m.BirdId, opt => opt.MapFrom(e => e.BirdId))
                .ForMember(m => m.ReceivedDate, opt => opt.MapFrom(e => DateTime.Now));
        }

        private void Map_AcquirableSkill_AcquirableSkillViewModel()
        {
            CreateMap<AcquirableSkill, AcquirableSkillViewModel>()
                .ForMember(m => m.BirdSpeciesId, opt => opt.MapFrom(e => e.BirdSpeciesId))
                .ForMember(m => m.BirdSpeciesName, opt => {
                    opt.PreCondition(e => e.BirdSpecies != null);
                    opt.MapFrom(e => e.BirdSpecies.Name);
                })
                .ForMember(m => m.BirdSkillId, opt => opt.MapFrom(e => e.BirdSkillId))
                .ForMember(m => m.BirdSkillName, opt => {
                    opt.PreCondition(e => e.BirdSkill!= null);
                    opt.MapFrom(e => e.BirdSkill.Name);
                })
                .ForMember(m => m.Condition, opt => opt.MapFrom(e => e.Condition));
        }

        private void Map_AccquirableAddModBirdSkill_AcquirableSkill()
        {
            CreateMap<AcquirableAddModBirdSkill, AcquirableSkill>()
                .ForMember(m => m.BirdSpeciesId, opt => opt.MapFrom(e => e.BirdSpeciesId))
                .ForMember(m => m.BirdSkillId, opt => opt.MapFrom(e => e.BirdSkillId))
                .ForMember(m => m.Condition, opt => opt.MapFrom(e => e.Condition));
        }

        private void Map_BirdSkill_BirdSkillViewModel()
        {
            CreateMap<BirdSkill, BirdSkillViewModel>()
                .ForMember(m => m.Id, opt => opt.MapFrom(e => e.Id))
                .ForMember(m => m.Name, opt => opt.MapFrom(e => e.Name))
                .ForMember(m => m.Description, opt => opt.MapFrom(e => e.Description))
                .ForMember(m => m.Picture, opt => opt.MapFrom(e => e.Picture));
        }

        private void Map_BirdSkillAddModel_BirdSkill()
        {
            CreateMap<BirdSkillAddModel, BirdSkill>()
                .ForMember(m => m.Name, opt => opt.MapFrom(e => e.Name))
                .ForMember(m => m.Description, opt => opt.MapFrom(e => e.Description))
                .ForMember(m => m.Picture, opt => opt.MapFrom(e => e.Picture));
        }
    }
}
