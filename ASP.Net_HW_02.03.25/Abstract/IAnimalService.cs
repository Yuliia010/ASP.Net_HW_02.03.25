using ASP.Net_HW_02._03._25.Models;

namespace ASP.Net_HW_02._03._25.Abstract
{
    public interface IAnimalService
    {
        Task<List<AnimalDto>> GetAllAsync();
        Task AddAsync(AnimalDto animal);
        Task UpdateAsync(AnimalDto animal);
        Task DeleteAsync(Guid id);
    }
}
