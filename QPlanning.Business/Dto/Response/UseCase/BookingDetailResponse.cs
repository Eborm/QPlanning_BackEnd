using System.Collections.Generic;
using QPlanning.Business.Domain.Entities;

namespace QPlanning.Business.Dto.Response.UseCase
{
    public class BookingDetailResponse
    {
        public List<BookingDetailViewModel> BookingsDetail { get; set; }
    }
}