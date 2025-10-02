using System.Collections.Generic;
using QPlanning.Business.UseCases.Medewerkers.Models;

namespace QPlanning.Business.UseCases.Medewerkers.Get.Dto.Response
{
    public class GetMedewerkersResponse
    {
        public IList<MedewerkerViewModel> Medewerkers { get; set; }
    }
}