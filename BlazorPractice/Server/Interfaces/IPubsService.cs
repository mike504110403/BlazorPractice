using BlazorPractice.Server.Dto;

namespace BlazorPractice.Server.Interfaces
{
    public interface IPubsService
    {
        Task<List<SalesInfoViewModel>> GetAsync();
    }
}
