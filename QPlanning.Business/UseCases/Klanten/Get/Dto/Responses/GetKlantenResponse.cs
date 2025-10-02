using System.Collections.Generic;
using QPlanning.Business.Domain.Entities;
using QPlanning.Business.UseCases.Klanten.Get.Models;

namespace QPlanning.Business.UseCases.Klanten.Get.Dto.Responses
{
    public class GetKlantenResponse
    {
        public List<KlantDisplayModel> Klanten { get; set; }
    }
}