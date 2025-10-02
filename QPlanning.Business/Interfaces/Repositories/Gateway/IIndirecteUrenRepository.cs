using System.Collections.Generic;
using System.Threading.Tasks;
using QPlanning.Business.Domain.Entities;

namespace QPlanning.Business.Interfaces.Repositories.Gateway
{
    public interface IIndirecteUrenRepository
    {
        Task<List<DomainModelIndirecteUren>> GetIndirecteUren();
    }
}