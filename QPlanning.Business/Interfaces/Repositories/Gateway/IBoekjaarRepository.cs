using System.Collections.Generic;
using System.Threading.Tasks;
using QPlanning.Business.Dto.Base.UseCaseResponses;

namespace QPlanning.Business.Interfaces.Repositories.Gateway
{
    public interface IBoekjaarRepository
    {
        Task<List<int>> GetUniqueBoekjaren();

        Task<BaseResponse> AddBoekjarenRawSql(int jaar, int bedrag);
    }
}