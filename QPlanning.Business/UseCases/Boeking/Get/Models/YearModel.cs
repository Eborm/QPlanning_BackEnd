using System.Collections.Generic;

namespace QPlanning.Business.UseCases.Boeking.Get.Models
{
    public class YearModel
    {
        public int Year { get; set; }
        public List<WeekModel> Weeks { get; set; }
    }
}