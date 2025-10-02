using System.Threading.Tasks;
using QPlanning.Business.Dto.Base.UseCaseResponses;

namespace QPlanning.Business.Interfaces.Services
{
    public interface IBoekjaarService
    {
        Task<BaseResponse> AddBoekjarenRawSql(int jaar, int bedrag);
    }
}