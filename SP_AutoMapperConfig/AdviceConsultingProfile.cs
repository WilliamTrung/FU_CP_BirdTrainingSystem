using AppRepository.UnitOfWork;
using AutoMapper;
using Models.Entities;
using Models.ServiceModels.AdviceConsultantModels;
using Models.ServiceModels.AdviceConsultantModels.ConsultingTicket;
using Models.ServiceModels.WorkshopModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SP_AutoMapperConfig
{
    public class AdviceConsultingProfile : Profile
    {
        public AdviceConsultingProfile()
        {
            Map_DistancePrice_DistancePriceServieModel();
            Map_ConsultingPricePolicy_ConsultingPricePolicyServiceModel();
            Map_ConsultingType_ConsultingTypeServiceModel();
            Map_ConsultingTicketCreateNewModel_ConsultingTicket();
            Map_ConsultingTicket_ConsultingTicketDetailViewModel();
            Map_ConsultingTicket_ConsultingTicketListViewModel();
            Map_AdviceConsultingTrainerSlotServiceModel_TrainerSlot();
            Map_CreateNewAddressServiceModel_Address();
            Map_Address_AddressServiceModel();
        }

        private void Map_DistancePrice_DistancePriceServieModel()
        {
            CreateMap<DistancePrice, DistancePriceServiceModel>();
        }

        private void Map_ConsultingPricePolicy_ConsultingPricePolicyServiceModel()
        {
            CreateMap<ConsultingPricePolicy, ConsultingPricePolicyServiceModel>()
                .ForMember(e => e.Price, opt => opt.MapFrom(c => c.Price));
        }

        private void Map_ConsultingType_ConsultingTypeServiceModel()
        {
            CreateMap<ConsultingType, ConsultingTypeServiceModel>()
                .ForMember(e => e.Name, opt => opt.MapFrom(c => c.Name));
        }

        private void Map_ConsultingTicketCreateNewModel_ConsultingTicket()
        {
            CreateMap<ConsultingTicketCreateNewModel, ConsultingTicket>()
                .ForMember(e => e.Address, opt => opt.Ignore())
                .AfterMap<MappingAction_ConsultingTicketCreateNewModel_ConsultingTicket>();
        }

        private void Map_ConsultingTicket_ConsultingTicketDetailViewModel()
        {
            CreateMap<ConsultingTicket, ConsultingTicketDetailViewModel>()
                .AfterMap<MappingAction_ConsultingTicket_ConsultingTicketDetailViewModel>();
        }

        private void Map_ConsultingTicket_ConsultingTicketListViewModel()
        {
            CreateMap<ConsultingTicket, ConsultingTicketListViewModel>()
                .AfterMap<  MappingAction_ConsultingTicket_ConsultingTicketListView>();
        }
        private void Map_AdviceConsultingTrainerSlotServiceModel_TrainerSlot()
        {
            CreateMap<AdviceConsultingTrainerSlotServiceModel, TrainerSlot>()
                .ForMember(e => e.SlotId, opt => opt.MapFrom(m => m.SlotId))
                .ForMember(e => e.Date, opt => opt.MapFrom(m => m.Date.ToDateTime(new TimeOnly())))
                .ForMember(e => e.TrainerId, opt => opt.MapFrom(m => m.TrainerId))
                .ForMember(e => e.Status, opt => opt.MapFrom(m => (int)Models.Enum.ConsultingTicket.Status.Approved))
                .ForMember(e => e.EntityId, opt => opt.MapFrom(m => m.EntityId))
                .ForMember(e => e.EntityTypeId, opt => opt.MapFrom(m => m.EntityTypeId))
                .ForMember(e => e.Reason, opt => opt.MapFrom(m => "Consulting Customer"));
        }

        private void Map_CreateNewAddressServiceModel_Address()
        {
            CreateMap<CreateNewAddressServiceModel, Address>();
        }

        private void Map_Address_AddressServiceModel()
        {
            CreateMap<Address, CreateNewAddressServiceModel>();
        }

        public class MappingAction_ConsultingTicket_ConsultingTicketListView : IMappingAction<ConsultingTicket, ConsultingTicketListViewModel>
        {
            private readonly IUnitOfWork _uow;
            private readonly IMapper _mapper;

            public MappingAction_ConsultingTicket_ConsultingTicketListView(IUnitOfWork uow, IMapper mapper)
            {
                _uow = uow;
                _mapper = mapper;
            }

            public void Process(ConsultingTicket source, ConsultingTicketListViewModel destination, ResolutionContext context)
            {
                var slotStart = _uow.SlotRepository.GetFirst(x => x.Id == source.ActualSlotStart).Result;
                var endSlot = _uow.SlotRepository.GetFirst(x => x.Id == source.ActualEndSlot).Result;

                destination.Id = source.Id;
                destination.OnlineOrOffline = source.OnlineOrOffline;
                destination.AppointmentDate = source.AppointmentDate;
                destination.ActualSlotStart = slotStart.StartTime + " - " + slotStart.EndTime;
                if (endSlot != null)
                {
                    destination.ActualEndSlot = endSlot.StartTime + " - " + endSlot.EndTime;
                }
                else
                {
                    destination.ActualEndSlot = null;
                }
            }
        }

        public class MappingAction_ConsultingTicketCreateNewModel_ConsultingTicket : IMappingAction<ConsultingTicketCreateNewModel, ConsultingTicket>
        {
            private readonly IUnitOfWork _uow;
            private readonly IMapper _mapper;

            public MappingAction_ConsultingTicketCreateNewModel_ConsultingTicket(IUnitOfWork uow, IMapper mapper)
            {
                _uow = uow;
                _mapper = mapper;
            }

            public void Process(ConsultingTicketCreateNewModel source, ConsultingTicket destination, ResolutionContext context)
            {
                destination.CustomerId = source.CustomerId;
                destination.TrainerId = source.TrainerId;
                if (source.AddressDetail != null)
                {
                    var address = _uow.AddressRepository.GetFirst(x => x.CustomerId == source.CustomerId && x.AddressDetail == source.AddressDetail).Result;
                    if (address != null)
                    {
                        destination.AddressId = address.Id;
                    }
                    else
                    {
                        var newAddress = new Address()
                        {
                            CustomerId = source.CustomerId,
                            AddressDetail = source.AddressDetail
                        };

                        _uow.AddressRepository.Add(newAddress).Wait();

                        destination.AddressId = newAddress.Id;
                    }
                }
                destination.ConsultingTypeId = source.ConsultingTypeId;
                destination.ConsultingDetail = source.ConsultingDetail;
                destination.OnlineOrOffline = source.OnlineOrOffline;
                destination.AppointmentDate = source.AppointmentDate;
                destination.ActualSlotStart = source.ActualSlotStart;
            }
        }

        public class MappingAction_ConsultingTicket_ConsultingTicketDetailViewModel : IMappingAction<ConsultingTicket, ConsultingTicketDetailViewModel>
        {
            private readonly IUnitOfWork _uow;
            private readonly IMapper _mapper;

            public MappingAction_ConsultingTicket_ConsultingTicketDetailViewModel (IUnitOfWork uow, IMapper mapper)
            {
                _uow = uow;
                _mapper = mapper;
            }
            
            private string FormatTimeSpan(TimeSpan timeSpan)
            {
                return timeSpan.ToString(@"hh\:mm");
            } 

            private string FormatSlotTime(TimeSpan startTime, TimeSpan endTime)
            {
                return $"{FormatTimeSpan(startTime)}-{FormatTimeSpan(endTime)}";
            }
            public void Process (ConsultingTicket source, ConsultingTicketDetailViewModel destination, ResolutionContext context)
            {
                var customer = _uow.CustomerRepository.GetFirst(x => x.Id == source.CustomerId, nameof(Customer.User)).Result;
                var address = _uow.AddressRepository.GetFirst(x => x.Id == source.AddressId).Result;
                var consultingType = _uow.ConsultingTypeRepository.GetFirst(x => x.Id == source.ConsultingTypeId).Result;
                var trainer = _uow.TrainerRepository.GetFirst(x => x.Id == source.TrainerId, nameof(User)).Result;
                var slotstart = _uow.SlotRepository.GetFirst(x => x.Id == source.ActualSlotStart).Result;
                var endSLot = _uow.SlotRepository.GetFirst(x => x.Id == source.ActualEndSlot).Result;

                destination.Id = source.Id;
                destination.CustomerName = customer.User.Name;
                destination.AddressDetail = address.AddressDetail;
                destination.ConsultingType = consultingType.Name;
                destination.TrainerName = trainer.User.Name;
                destination.ConsultingDetail = source.ConsultingDetail;
                destination.Distance = source.Distance;
                destination.OnlineOrOffline = source.OnlineOrOffline;
                destination.GgMeetLink = source.GgMeetLink;
                destination.AppointmentDate = (DateTime)source.AppointmentDate;
                destination.SlotStartId = source.ActualSlotStart;
                destination.ActualSlotStart = FormatSlotTime((TimeSpan)slotstart.StartTime, (TimeSpan)slotstart.EndTime);
                if (endSLot != null)
                {
                    destination.ActualEndSlot = FormatSlotTime((TimeSpan)endSLot.StartTime, (TimeSpan)endSLot.EndTime);
                }
                else
                {
                    destination.ActualEndSlot = null; 
                }
                destination.Evidence = source.Evidence;
                destination.Price = source.Price;
                destination.Status = (Models.Enum.ConsultingTicket.Status)source.Status;
                destination.CustomerEmail = customer.User.Email;
                destination.CustomerPhone = customer.User.PhoneNumber;
            }
        }
    }
}
