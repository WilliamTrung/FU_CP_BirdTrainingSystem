using AppRepository.Generic;
using AppRepository.UnitOfWork;
using Models.Entities;

namespace AppRepository.Repository.Implement
{
    public class TransactionRepository : GenericRepository<Transaction>, ITransactionRepository
    {
        public TransactionRepository(AppCore.Context.BirdTrainingCenterSystemContext context, IUnitOfWork unitOfWork) : base(context, unitOfWork)
        {
        }
        public override Task Add(Transaction entity)
        {
            entity.DateCreate = DateTime.Now;
            entity.PaymentDate = DateTime.Now.Date;
            entity.Status = (int)Models.Enum.Transaction.Status.Unpaid;
            return base.Add(entity);
        }
    }
}
