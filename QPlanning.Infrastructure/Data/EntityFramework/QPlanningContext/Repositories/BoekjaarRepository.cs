using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using QPlanning.Business.Dto.Base.UseCaseResponses;
using QPlanning.Business.Interfaces.Repositories.Gateway;

namespace QPlanning.Infrastructure.Data.EntityFramework.QPlanningContext.Repositories
{
    public class BoekjaarRepository : IBoekjaarRepository
    {
        private readonly IMapper _mapper;
        private readonly QPlanningApplicationContext _qDbContext;

        public BoekjaarRepository(IMapper mapper, QPlanningApplicationContext qDbContext)
        {
            _mapper = mapper;
            _qDbContext = qDbContext;
        }
        
        public async Task<BaseResponse> AddBoekjarenRawSql(int jaar, int bedrag)
        {
            try
            {
                var result = await _qDbContext.Boekjaar.FromSqlRaw(
                    $@"INSERT INTO Boekjaar
                       SELECT GETDATE(), 'AutoFill', GETDATE(), 'AutoFill',k.id, {jaar}, {bedrag} 
                       FROM Klant k
                       LEFT JOIN Boekjaar b ON b.KlantId = k.Id and jaar =  {jaar}
                       WHERE b.Id IS NULL and  k.Einddatum IS NULL OR k.Einddatum >= GETDATE();").ToListAsync();
                return new BaseResponse(result.ToString(), true, null);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return new BaseResponse(e.Message.ToString(), true, null);
            }
          
        }

        public Task<List<int>> GetUniqueBoekjaren()
        {
            throw new NotImplementedException();
        }
    }
}