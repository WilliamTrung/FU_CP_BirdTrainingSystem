using AppRepository.UnitOfWork;
using AutoMapper;
using Models.Entities;
using Models.ServiceModels.TrainingCourseModels;
using Models.ServiceModels.TrainingCourseModels.BirdSkill;
using Models.ServiceModels.TrainingCourseModels.TrainingCourse;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SP_AutoMapperConfig
{
    public class TrainingCourseProfile : Profile
    {
        public TrainingCourseProfile()
        {
            Map_TrainingCourseAddModel_TrainingCourse();
            Map_TrainingCourse_TrainingCourseViewModel();
            Map_AddTrainingSkillModel_TrainingSkillModel();
            Map_Customer_CustomerModel();//training course
        }

        private void Map_Customer_CustomerModel()
        {
            CreateMap<Customer, CustomerModel>()
                .ForMember(m => m.Id, opt => opt.MapFrom(e => e.Id))
                .ForMember(m => m.Name, opt => {
                    opt.PreCondition(m => m.User != null);
                    opt.MapFrom(e => e.User.Name);
                })
                .ForMember(m => m.Email, opt => {
                    opt.PreCondition(m => m.User != null);
                    opt.MapFrom(e => e.User.Email);
                })
                .ForMember(m => m.PhoneNumber, opt => {
                    opt.PreCondition(m => m.User != null);
                    opt.MapFrom(e => e.User.PhoneNumber);
                })
                .ForMember(m => m.Avatar, opt => {
                    opt.PreCondition(m => m.User != null);
                    opt.MapFrom(e => e.User.Avatar);
                });
        }

        private void Map_AddTrainingSkillModel_TrainingSkillModel()
        {
            CreateMap<AddTrainingSkillModel, TrainingCourseSkill>()
                .ForMember(m => m.BirdSkillId, opt => opt.MapFrom(e => e.BirdSkillId))
                .ForMember(m => m.TotalSlot, opt => opt.MapFrom(e => e.TotalSlot))
                .ForMember(m => m.TrainingCourseId, opt => opt.MapFrom(e => e.TrainingCourseId));
        }

        private void Map_TrainingCourse_TrainingCourseViewModel()
        {
            CreateMap<TrainingCourse, TrainingCourseViewModel>()
                .AfterMap<MapAction_TrainingCourse_TrainingCourseViewModel>();
                //.ForMember(m => m.Id, opt => opt.MapFrom(e => e.Id))
                //.ForMember(m => m.BirdSpeciesId, opt => opt.MapFrom(e => e.BirdSpeciesId))
                //.ForMember(m => m.BirdSpeciesName, opt => {
                //    opt.PreCondition(m => m.BirdSpecies != null);
                //    opt.MapFrom(e => e.BirdSpecies.Name); 
                //})
                //.ForMember(m => m.Title, opt => opt.MapFrom(e => e.Title))
                //.ForMember(m => m.Description, opt => opt.MapFrom(e => e.Description))
                //.ForMember(m => m.Picture, opt => opt.MapFrom(e => e.Picture))
                //.ForMember(m => m.TotalSlot, opt => opt.MapFrom(e => e.TotalSlot))
                //.ForMember(m => m.TotalPrice, opt => opt.MapFrom(e => e.TotalPrice));
        }

        private void Map_TrainingCourseAddModel_TrainingCourse()
        {
            CreateMap<TrainingCourseAddModel, TrainingCourse>()
                .ForMember(m => m.BirdSpeciesId, opt => opt.MapFrom(e => e.BirdSpeciesId))
                .ForMember(m => m.Title, opt => opt.MapFrom(e => e.Title))
                .ForMember(m => m.Description, opt => opt.MapFrom(e => e.Description))
                .ForMember(m => m.Picture, opt => opt.MapFrom(e => e.Picture))
                .ForMember(m => m.TotalPrice, opt => opt.MapFrom(e => e.TotalPrice))
                .ForMember(m => m.Status, opt => opt.MapFrom(e => (int)Models.Enum.TrainingCourse.Status.Modifying))
                .ForMember(m => m.TotalSlot, opt => opt.MapFrom(e => 0));
        }

        public class MapAction_TrainingCourse_TrainingCourseViewModel : IMappingAction<TrainingCourse, TrainingCourseViewModel>
        {
            private readonly IMapper _mapper;
            private readonly IUnitOfWork _unitOfWork;
            public MapAction_TrainingCourse_TrainingCourseViewModel(IUnitOfWork unitOfWork, IMapper mapper)
            {
                _unitOfWork = unitOfWork;
                _mapper = mapper;
            }

            public void Process(TrainingCourse source, TrainingCourseViewModel destination, ResolutionContext context)
            {
                destination.Id = source.Id;
                destination.BirdSpeciesId = source.BirdSpeciesId;
                destination.Title = source.Title;
                destination.Description = source.Description;
                destination.Picture = source.Picture;
                destination.TotalSlot = source.TotalSlot;
                destination.TotalPrice = source.TotalPrice;

                var birdSpecies = _unitOfWork.BirdSpeciesRepository.GetFirst(e => e.Id == source.BirdSpeciesId).Result;
                if(birdSpecies != null )
                {
                    destination.BirdSpeciesName = birdSpecies.Name;
                }
                var trainingSkills = _unitOfWork.TrainingCourseSkillRepository.Get(e => e.TrainingCourseId == source.Id
                                                                                    , nameof(TrainingCourseSkill.BirdSkill)).Result.ToList();
                foreach( var skill in trainingSkills )
                {
                    if(skill != null)
                    {
                        if(skill.BirdSkill != null)
                        {
                            destination.BirdSkills.Add(_mapper.Map<BirdSkillViewModel>(skill.BirdSkill));
                        }
                    }
                }

                var registeredCourses = _unitOfWork.BirdTrainingCourseRepository.Get(e => e.TrainingCourseId == source.Id
                                                                                      && e.Status != (int)Models.Enum.BirdTrainingCourse.Status.Cancel).Result.ToList();
                foreach (var registeredCourse in registeredCourses)
                {
                    if (registeredCourse != null)
                    {
                        destination.RegisteredBird.Add(registeredCourse.BirdId);
                        destination.RegisteredBird = destination.RegisteredBird.Distinct().ToList();
                    }
                }
            }
        }
    }
}
