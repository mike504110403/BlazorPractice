using BlazorPractice.Server.Dto;
using BlazorPractice.Server.Interfaces;

namespace BlazorPractice.Server.Services
{
    public class PubsService : IPubsService
    {
        public Task CreateAsync(SalesInfoViewModel saleInfo)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(string orderNum)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(SalesInfoViewModel saleInfo)
        {
            throw new NotImplementedException();
        }

        Task<List<SalesInfoViewModel>> IPubsService.GetAsync()
        {
            throw new NotImplementedException();
        }
    }
}
