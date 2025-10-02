using System.Collections.Generic;
using QPlanning.Business.Domain.Models.Dropdown;

namespace QPlanning.Business.UseCases.Klanten.Get.Dto.Responses
{
    public class GetKlantDropDownResponse
    {
        /// <summary>
        /// Medewerker dropdown can only be filled with users that have the function (Partner)
        /// </summary>
        public List<DropDown> MedewerkerDropDown { get; set; }
        public List<DropDown> TeamDropDown { get; set; }
        public List<DropDown> OpdrachtDropDown { get; set; }
    }
}