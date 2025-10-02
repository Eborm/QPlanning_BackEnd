using System.Collections.Generic;
using QPlanning.Business.Domain.Models.Dropdown;

namespace QPlanning.Business.UseCases.Teams.Get.Dto.Response
{
    public class TeamDropDownResponse
    {
        public int InitialSelectedTeamId { get; set; }
        public List<DropDown> TeamDropDown { get; set; }
        
        public List<DropDown> KlantDropDown { get; set; }

        public List<DropDown> MedewerkerDropDown { get; set; }
    }
}