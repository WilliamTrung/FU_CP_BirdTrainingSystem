using AppRepository.UnitOfWork;
using AutoMapper;
using Models.Entities;
using Models.ServiceModels.MembershipModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MembershipSubSystem.Implementation
{
    public class FeatureAdministrator : IFeatureAdministrator
    {
        internal readonly IUnitOfWork _unitOfWork;
        internal readonly IMapper _mapper;
        public FeatureAdministrator(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task CreateMembershipRank(MembershipCreateNewServiceModel membership)
        {
            var entity = _mapper.Map<MembershipRank>(membership);
            await _unitOfWork.MembershipRankRepository.Add(entity);

            //Update CustomerRank
            var customers = await _unitOfWork.CustomerRepository.Get(expression: null, nameof(MembershipRank));
            foreach (var customer in customers)
            {
                if (customer.TotalPayment >= entity.Requirement && customer.MembershipRank.Requirement < entity.Requirement)
                {
                    customer.MembershipRankId = entity.Id;
                    await _unitOfWork.CustomerRepository.Update(customer);
                }
            }
        }

        public async Task DeleteMembershipRank(int id)
        {
            var deleted = await _unitOfWork.MembershipRankRepository.GetFirst(c => c.Id == id);
            if (deleted == null)
            {
                throw new KeyNotFoundException("Membership rank not found!");
            }
            var memberShip = await _unitOfWork.MembershipRankRepository.Get(c => c.Requirement < deleted.Requirement);
            var target = memberShip.OrderByDescending(c => c.Requirement).FirstOrDefault();
            if (target == null)
            {
                throw new InvalidOperationException("Cannot delete standard rank!");
            }
            var customers = await _unitOfWork.CustomerRepository.Get(c => c.MembershipRankId == id);
            foreach (var customer in customers)
            {
                customer.MembershipRankId = target.Id;
                await _unitOfWork.CustomerRepository.Update(customer);
            }
            await _unitOfWork.MembershipRankRepository.Delete(deleted);
        }

        public async Task<IEnumerable<MembershipServiceModel>> GetListMembershipRank()
        {
            var entites = await _unitOfWork.MembershipRankRepository.Get();
            var models = _mapper.Map<IEnumerable<MembershipServiceModel>>(entites);

            return models;
        }

        public async Task<MembershipServiceModel> GetMembershipRankDetail(int id)
        {
            var entity = await _unitOfWork.MembershipRankRepository.GetFirst(x => x.Id == id);
            var model = _mapper.Map<MembershipServiceModel>(entity);
            return model;
        }

        public async Task UpdateMembershipRank(MembershipUpdateServiceModel membership)
        {
            var entity = await _unitOfWork.MembershipRankRepository.GetFirst(x => x.Id == membership.Id);
            entity.Name = membership.Name;
            entity.Requirement = membership.Requirement;
            entity.Discount = membership.Discount;
            await _unitOfWork.MembershipRankRepository.Update(entity);

            var memberShips = _unitOfWork.MembershipRankRepository.Get().Result.OrderByDescending(x => x.Requirement);
            var customers = await _unitOfWork.CustomerRepository.Get(x => x.MembershipRankId == entity.Id);
            foreach (var customer in customers)
            {
                if (customer.TotalPayment >= entity.Requirement)
                {
                    customer.MembershipRankId = entity.Id;
                    await _unitOfWork.CustomerRepository.Update(customer);
                }
            }
        }
    }
}
