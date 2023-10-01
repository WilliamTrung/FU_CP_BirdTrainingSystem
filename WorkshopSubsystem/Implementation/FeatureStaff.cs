using AppRepository.UnitOfWork;
using AutoMapper;
using Microsoft.Extensions.Options;
using Models.ConfigModels;
using Models.ServiceModels.WorkshopModels;
using Models.ServiceModels.WorkshopModels.WorkshopClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkshopSubsystem.Implementation
{
    public class FeatureStaff : FeatureUser, IFeatureStaff
    {
        private readonly BR_WorkshopConstant _br;
        public FeatureStaff(IUnitOfWork unitOfWork, IMapper mapper, IOptions<BR_WorkshopConstant> br) : base(unitOfWork, mapper)
        {
            _br = br.Value;
        }
        public async Task CreateWorkshopClass(ClassAddModel classAddModel)
        {
            //classAddModel with given WorkshopId and StartTime
            try
            {
                var starttime = classAddModel.StartTime;                

                var workshop = await _unitOfWork.WorkshopRepository.GetFirst(c => c.Id == classAddModel.WorkshopId);
                if (workshop == null)
                {
                    throw new TaskCanceledException("Workshop is not found for ID: " + classAddModel.WorkshopId);
                }

                var entity = _mapper.Map<Models.Entities.WorkshopClass>(classAddModel);
                int daySumToRegistrationEnd = workshop.RegisterEnd == null ? _br.StartDateDeadlineAfterRegistrationEnd : workshop.RegisterEnd.Value;

                entity.Status = (int)Models.Enum.Workshop.Class.Status.Registration;
                entity.RegisterEndDate = starttime.AddDays(daySumToRegistrationEnd);
                await _unitOfWork.WorkshopClassRepository.Add(entity);
            }
            catch (Exception ex)
            {
                throw new TaskCanceledException($"{ex.Message} at {ex.StackTrace}");
            }
        }

        public async Task<IEnumerable<ClassViewModel>> GetClassByWorkshopId(int workshopId)
        {
            var entities = await _unitOfWork.WorkshopClassRepository.Get(c => c.WorkshopId == workshopId);

        }

        public Task<IEnumerable<Workshop>> GetWorkshops()
        {
            throw new NotImplementedException();
        }
    }
}
