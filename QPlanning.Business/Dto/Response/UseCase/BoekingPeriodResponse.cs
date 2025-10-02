using System.Collections.Generic;
using QPlanning.Business.Domain.Entities;
using QPlanning.Business.UseCases.Boeking.Get.Models;

namespace QPlanning.Business.Dto.Response.UseCase
{
    public class BoekingPeriodResponse
    {
        public PlanningTableViewModel PersonalPlanningViewModel { get; set; }
    }
}