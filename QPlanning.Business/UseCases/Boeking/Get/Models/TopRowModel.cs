using System.Collections.Generic;

namespace QPlanning.Business.UseCases.Boeking.Get.Models
{
    public class TopRowModel
    {
        public bool Expanded { get; set; } = false;
        public string Naam { get; set; }
        public string Opdrachtleider { get; set; }
        public string Functie { get; set; }
        public string Total { get; set; }
        public List<UrenModel> Planning { get; set; }
        public List<DetailRowModel> DetailRows { get; set; }
    }
}