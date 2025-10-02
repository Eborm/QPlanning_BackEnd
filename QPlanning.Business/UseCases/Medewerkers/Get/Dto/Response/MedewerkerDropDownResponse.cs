using System.Collections.Generic;
using QPlanning.Business.Domain.Models.Dropdown;

namespace QPlanning.Business.UseCases.Medewerkers.Get.Dto.Response
{
    public class MedewerkerDropDownResponse
    {
        public List<DropDown> MedewerkerFunctieDropDown { get; set; }
        public List<DropDown> TeamDropDown { get; set; }
    }
}