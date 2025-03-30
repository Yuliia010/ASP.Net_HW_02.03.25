using ASP.Net_HW_02._03._25.Models.Animals;

namespace ASP.Net_HW_02._03._25.Abstract
{
    public interface IAnimalService
    {
        Task<List<AnimalBaseDto>> GetAllAsync();
        Task AddAsync(AnimalBaseDto animal);
        Task UpdateAsync(AnimalBaseDto animal);
        Task DeleteAsync(Guid id);
    }
}
