using BlazorPractice.Server.Dto;
using BlazorPractice.Server.Interfaces;

namespace BlazorPractice.Server.Services
{
    public class PubsService : IPubsService
    {

        Task<List<SalesInfoViewModel>> IPubsService.GetAsync()
        {
            throw new NotImplementedException();
        }
    }
}
