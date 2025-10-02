using System.Collections.Generic;
using QPlanning.Business.Domain.Models.Dropdown;

namespace QPlanning.Business.UseCases.Boeking.Get.Dto
{
    public class BoekingDropDownResponse
    {
        public List<DropDown> IndirecteUrenDropDown { get; set; }
        public List<DropDown> KlantDropDown { get; set; }
        public List<DropDown> MedewerkerDropDown { get; set; }
        public List<DropDown> OpdrachtDropDown { get; set; }

        public List<DropDown> TeamDropDown { get; set; }

        public int InitialSelectedTeam { get; set; }
    }
}