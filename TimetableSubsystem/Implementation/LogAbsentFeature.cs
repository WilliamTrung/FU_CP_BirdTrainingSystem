using AppRepository.UnitOfWork;
using AutoMapper;
using Models.Entities;
using Models.Enum;
using Models.ServiceModels.TimetableModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimetableSubsystem.Implementation
{
    public class LogAbsentFeature : ILogAbsentFeature
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;
        public LogAbsentFeature(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }
        //Manager log Trainer nghỉ
        //+ chọn ngày:
        //- 1 ngày: * cả ngày
        //               * nửa buổi
        //- Nếu có lịch bận trong duration --> báo lỗi
        public async Task LogAbsentDateRange(AbsentDateRangeModel absentLog)
        {
            var listAbsentLogInDay = _mapper.Map<List<AbsentInDayModel>>(absentLog);
            foreach (var absentLogInDay in listAbsentLogInDay)
            {
                await LogAbsentInDay(absentLogInDay);
            }
        }
        //Manager log Trainer nghỉ
        //+ chọn ngày:
        //- nhiều ngày: *from - *to 
        //- Nếu có lịch bận trong duration --> báo lỗi
        public async Task LogAbsentInDay(AbsentInDayModel absentLog)
        {
            List<TrainerSlot> appendSlots = new List<TrainerSlot>();
            TrainerSlot trainerSlot = _mapper.Map<TrainerSlot>(absentLog);

            int slotStart = 0;
            int slotEnd = 0;
            if (absentLog.Option == Models.Enum.Timetable.AbsentOption.HalfDayBeforeNoon)
            {
                slotStart = 1;
                slotEnd = 4;
            } else if(absentLog.Option == Models.Enum.Timetable.AbsentOption.HalfDayAfterNoon)
            {
                slotStart = 5;
                slotEnd = 8;
            } else
            {
                slotStart = 1;
                slotEnd = 8;
            }
            
            for (int i = slotStart; i <= slotEnd; i++)
            {
                var loggedSlot = new TrainerSlot()
                {
                    Date = trainerSlot.Date,
                    Reason = trainerSlot.Reason,
                    EntityTypeId = trainerSlot.EntityTypeId,
                    SlotId = i,
                    Status = trainerSlot.Status,
                    TrainerId = trainerSlot.TrainerId,
                };
                appendSlots.Add(loggedSlot);
            }

            bool isValid = await CheckOccupied(appendSlots);
            if (!isValid)
            {
                throw new InvalidOperationException("Busy slot encountered");
            }

            foreach (var loggedSlot in appendSlots)
            {
                await _uow.TrainerSlotRepository.Add(loggedSlot);
            }
        }
        private async Task<bool> CheckOccupied(List<TrainerSlot> absentSlots)
        {
            bool isValid = true;
            foreach (var absentSlot in absentSlots)
            {
                var checkedSlot = await _uow.TrainerSlotRepository.GetFirst(c => c.Date == absentSlot.Date
                                                                                && c.SlotId == absentSlot.SlotId
                                                                                && c.TrainerId == absentSlot.TrainerId
                                                                                && c.Status == (int)TrainerSlotStatus.Enabled);
                if (checkedSlot != null)
                {
                    isValid = false;
                    break;
                }
            }
            return isValid;
        }
    }
}
