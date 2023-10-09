using AppRepository.Generic;
using Models.Entities;

namespace AppRepository.Repository
{
    public interface ITransactionRepository : IGenericRepository<Transaction>
    {
    }
}
