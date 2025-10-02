using System.Threading.Tasks;
using Moq;
using Xunit;
using QPlanning.Business.Domain.Entities.Logging;
using QPlanning.Business.Dto.Base.UseCaseResponses;
using QPlanning.Business.Interfaces.Repositories.Gateway;
using QPlanning.Business.Services;

namespace QPlanning.Business.UnitTests.Services
{
    public class LoggerServiceUnitTests
    {
        [Fact]
        public async void PersistLog_Should_Succeed()
        {
            // arrange
            var moqLogRepository = new Mock<ILogRepository>();

            moqLogRepository.Setup(repo => repo.AddCustomLog(It.IsAny<DomainModelCustomLog>()))
                .Returns(Task.FromResult(new BaseResponse("", true)));

           var loggerService = new LoggerService(moqLogRepository.Object);
         
            // act
            var response = await loggerService.PersistLogging(new DomainModelCustomLog());

            // assert
            Assert.True(response.Success);
        }
        
        [Fact]
        public async void PersistExceptionLog_Should_Succeed()
        {
            // arrange
            var moqLogRepository = new Mock<ILogRepository>();

            moqLogRepository.Setup(repo => repo.AddExceptionLog(It.IsAny<DomainModelExceptionLog>()))
                .Returns(Task.FromResult(new BaseResponse("", true)));

            var loggerService = new LoggerService(moqLogRepository.Object);
         
            // act
            var response = await loggerService.PersistException(new DomainModelExceptionLog());

            // assert
            Assert.True(response.Success);
        }
    }
}