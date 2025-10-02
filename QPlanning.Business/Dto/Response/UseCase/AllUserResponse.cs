using System.Collections.Generic;
using QPlanning.Business.Domain.Entities;

namespace QPlanning.Business.Dto.Response.UseCase
{
    public class AllUserResponse
    {
        public IList<DetailDomainModelUser> Users { get; set; }
    }
}