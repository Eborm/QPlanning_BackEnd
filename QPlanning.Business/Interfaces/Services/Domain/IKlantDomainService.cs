using System.Threading.Tasks;
using QPlanning.Business.Dto.Base.UseCaseResponses;
using QPlanning.Business.UseCases.Klanten.Add.Dto.Commands;
using QPlanning.Business.UseCases.Klanten.Edit.Dto.Commands;

namespace QPlanning.Business.Interfaces.Services.Domain
{
    public interface IKlantDomainService
    {
        Task<BaseResponse> AddKlant(AddKlantCommand klant);
        Task<BaseResponse> EditKlant(EditKlantCommand klant);

    }
}