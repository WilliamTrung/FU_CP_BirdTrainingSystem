using Models.Entities;
using AppRepository.Generic;

namespace AppRepository.Repository
{
    public interface ITransactionRepository : IGenericRepository<Transaction>
    {
    }
}
