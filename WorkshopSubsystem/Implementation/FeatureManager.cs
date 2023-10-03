using AppRepository.UnitOfWork;
using AutoMapper;
using Microsoft.Extensions.Options;
using Models.ConfigModels;
using Models.ServiceModels.WorkshopModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkshopSubsystem.Implementation
{
    public class FeatureManager : FeatureStaff, IFeatureManager
    {
        public FeatureManager(IUnitOfWork unitOfWork, IMapper mapper, IOptions<BR_WorkshopConstant> br) : base(unitOfWork, mapper, br)
        {
        }

        private async Task<int> GetWorkshopPricePolicyId(WorkshopPricePolicy pricePolicy)
        {          
            try
            {
                var entity_pricePolicy = await _unitOfWork.WorkshopPricePolicyRepository.GetFirst(c => c.TotalWorkshop == pricePolicy.TotalWorkshop && c.Discount == pricePolicy.Discount);
                if (entity_pricePolicy != null)
                {
                    //existing record
                    return entity_pricePolicy.Id;
                }
                else
                {
                    //new policy
                    var entity_addPolicy = _mapper.Map<Models.Entities.WorkshopPricePolicy>(pricePolicy);
                    await _unitOfWork.WorkshopPricePolicyRepository.Add(entity_addPolicy);
                    return entity_addPolicy.Id;
                }
            } catch (Exception ex)
            {
                return -1;
            }
            
        }
        private async Task<int> GetWorkshopRefundPolicyId(WorkshopRefundPolicy refundPolicy)
        {
            try
            {
                var entity_refundPolicy = await _unitOfWork.WorkshopRefundPolicyRepository.GetFirst(c => c.TotalDayBeforeStart == refundPolicy.TotalDayBeforeStart && c.RefundRate == refundPolicy.RefundRate);
                if (entity_refundPolicy != null)
                {
                    //existing record
                    return entity_refundPolicy.Id;
                }
                else
                {
                    //new policy
                    var entity_addPolicy = _mapper.Map<Models.Entities.WorkshopRefundPolicy>(refundPolicy);
                    await _unitOfWork.WorkshopRefundPolicyRepository.Add(entity_addPolicy);
                    return entity_addPolicy.Id;
                }
            } catch (Exception ex)
            {
                return -1;
            }            
        }
        public async Task AddWorkshop(WorkshopAddModel workshop)
        {
            try
            {
                //check workshop policy if add new
                var ws_pricePolicy = await GetWorkshopPricePolicyId(workshop.PricePolicy);
                var ws_refundPolicy = await GetWorkshopRefundPolicyId(workshop.RefundPolicy);
                if (ws_pricePolicy == -1 || ws_refundPolicy == -1)
                {
                    throw new InvalidDataException("INVALID POLICY DUE TO FAIL TO ADD NEW POLICY");
                }
                var entity = _mapper.Map<Models.Entities.Workshop>(workshop);
                entity.WorkshopPricePolicyId = ws_pricePolicy;
                entity.WorkshopRefundPolicyId = ws_refundPolicy;
                await _unitOfWork.WorkshopRepository.Add(entity);
            } catch (Exception ex)
            {
                throw new TaskCanceledException($"{ex.Message} at {ex.StackTrace}");
            }            
        }

        public async Task ChangeWorkshopStatus(int workshopId)
        {
            try
            {
                var entity = await _unitOfWork.WorkshopRepository.GetFirst(c => c.Id == workshopId);
                if (entity == null)
                {
                    throw new NullReferenceException("NOT FOUND");
                }
                if (entity.Status.HasValue)
                {
                    if (entity.Status.Value == (int)Models.Enum.Workshop.Status.Inactive)
                    {
                        entity.Status = (int)Models.Enum.Workshop.Status.Active;
                    }
                    else
                    {
                        entity.Status = (int)Models.Enum.Workshop.Status.Inactive;
                    }
                }
                else
                {
                    entity.Status = (int)Models.Enum.Workshop.Status.Active;
                }
                await _unitOfWork.WorkshopRepository.Update(entity);
            } catch (Exception ex)
            {
                throw new TaskCanceledException($"{ex.Message} at {ex.StackTrace}");
            }
            
        }

        public async Task EditWorkshop(Workshop workshop)
        {
            try
            {
                var entity = _mapper.Map<Models.Entities.Workshop>(workshop);
                var ws_pricePolicy = await GetWorkshopPricePolicyId(workshop.PricePolicy);
                var ws_refundPolicy = await GetWorkshopRefundPolicyId(workshop.RefundPolicy);
                if (ws_pricePolicy == -1 || ws_refundPolicy == -1)
                {
                    throw new InvalidDataException("INVALID POLICY DUE TO FAIL TO ADD NEW POLICY");
                }
                entity.WorkshopPricePolicyId = ws_pricePolicy;
                entity.WorkshopRefundPolicyId = ws_refundPolicy;
                await _unitOfWork.WorkshopRepository.Update(entity);
            }
            catch (Exception ex)
            {

                throw new TaskCanceledException($"{ex.Message} at {ex.StackTrace}");
            }
        }

        public async Task<IEnumerable<WorkshopRefundPolicy>> GetWorkshopRefundPoliciesAsync()
        {
            var entities = await _unitOfWork.WorkshopRefundPolicyRepository.Get();
            entities = entities.OrderBy(key => key.TotalDayBeforeStart);
            var models = _mapper.Map<IEnumerable<WorkshopRefundPolicy>>(entities);
            return models;
        }

        public async Task<IEnumerable<WorkshopPricePolicy>> GetWorshopPricePoliciesAsync()
        {
            var entities = await _unitOfWork.WorkshopPricePolicyRepository.Get();
            entities = entities.OrderBy(key => key.TotalWorkshop);
            var models = _mapper.Map<IEnumerable<WorkshopPricePolicy>>(entities);
            return models;
        }
    }
}
