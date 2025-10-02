using System.Collections.Generic;

namespace QPlanning.Business.UseCases.Boeking.Get.Models
{
    public class DetailRowModel
    {
        public string Naam { get; set; }
        public List<UrenModel> Planning { get; set; }
    }
}