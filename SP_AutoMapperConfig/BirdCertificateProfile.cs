﻿using AppRepository.UnitOfWork;
using AutoMapper;
using Models.Entities;
using Models.ServiceModels.TrainingCourseModels.BirdCertificate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SP_AutoMapperConfig
{
    public class BirdCertificateProfile : Profile
    {
        public BirdCertificateProfile()
        {
            Map_BirdCertificate_BirdCertificateViewModel();
            Map_BirdCertificateAddModel_BirdCertificate();
            Map_BirdCertificateSkillModifyModel_BirdCertificateSkill();
        }

        private void Map_BirdCertificateSkillModifyModel_BirdCertificateSkill()
        {
            CreateMap<BirdCertificateSkillModifyModel, BirdCertificateSkill>()
                .ForMember(m => m.BirdSkillId, opt => opt.MapFrom(e => e.BirdSkillId))
                .ForMember(m => m.BirdCertificateId, opt => opt.MapFrom(e => e.BirdCertificateId))
                .ForMember(m => m.ReceivedDate, opt => opt.MapFrom(e => DateTime.Now));
        }

        private void Map_BirdCertificateAddModel_BirdCertificate()
        {
            CreateMap<BirdCertificateAddModel, BirdCertificate>()
                .AfterMap<MapAction_BirdCertificateAddModel_BirdCertificate>();
        }

        private void Map_BirdCertificate_BirdCertificateViewModel()
        {
            CreateMap<BirdCertificate, BirdCertificateViewModel>()
                .AfterMap<MappingAction_BirdCertificate_BirdCertificateViewModel>();
        }

        public class MappingAction_BirdCertificate_BirdCertificateViewModel : IMappingAction<BirdCertificate, BirdCertificateViewModel>
        {
            private readonly IUnitOfWork _unitOfWork;
            public MappingAction_BirdCertificate_BirdCertificateViewModel(IUnitOfWork unitOfWork)
            {
                _unitOfWork = unitOfWork;
            }

            public void Process(BirdCertificate source, BirdCertificateViewModel destination, ResolutionContext context)
            {
                destination.Id = source.Id;
                destination.TrainingCourseId = source.TrainingCourseId;
                destination.BirdCenterName = source.BirdCenterName;
                destination.Title = source.Title;
                destination.ShortDescrption = source.ShortDescrption;
                destination.Picture = source.Picture;
                var listSkills = _unitOfWork.BirdCertificateSkillRepository.Get(e => e.BirdCertificateId == source.Id
                                                                                , nameof(BirdCertificateSkill.BirdSkill)).Result.ToList();
                if (listSkills != null && listSkills.Count() > 0)
                {
                    foreach (var skill in listSkills)
                    {
                        if (skill != null && skill.BirdSkill != null)
                        {
                            destination.BirdCertificateSkillNames.Add(skill.BirdSkill.Name);
                        }
                    }
                }
            }
        }

        public class MapAction_BirdCertificateAddModel_BirdCertificate : IMappingAction<BirdCertificateAddModel, BirdCertificate>
        {
            private readonly IUnitOfWork _unitOfWork;
            public MapAction_BirdCertificateAddModel_BirdCertificate(IMapper mapper, IUnitOfWork unitOfWork)
            {
                _unitOfWork = unitOfWork;
            }
            public void Process(BirdCertificateAddModel source, BirdCertificate destination, ResolutionContext context)
            {
                destination.TrainingCourseId = source.TrainingCourseId;
                destination.BirdCenterName = source.BirdCenterName;
                var trainingCourse = _unitOfWork.TrainingCourseRepository.GetFirst(e => e.Id == source.TrainingCourseId).Result;
                if (trainingCourse != null)
                {
                    destination.Title = trainingCourse.Title;
                }
                destination.ShortDescrption = source.ShortDescrption;
                destination.Picture = source.Picture;
            }
        }
    }
}
