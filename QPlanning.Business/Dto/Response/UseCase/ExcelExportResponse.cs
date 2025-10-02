using System.IO;

namespace QPlanning.Business.Dto.Response.UseCase
{
    public class ExcelExportResponse
    {
        public FileInfo FileInfo { get; set; }

        public byte[] Bytes { get; set; }
    }
}