using System.Collections.Generic;

namespace QPlanning.Business.UseCases.Boeking.Get.Models
{
    public class PlanningTableViewModel
    {
        public int TotalAmountOfWeeks { get; set; }
        public List<YearModel> Years { get; set; }
        public List<TopRowModel> TopRows { get; set; }
    }
}