using ASP.Net_HW_02._03._25.Models.Animals;
using ASP.Net_HW_02._03._25.Models.Shapes;

namespace ASP.Net_HW_02._03._25.Abstract
{
    public interface IShapeService
    {
        Task<List<ShapeBaseDto>> GetAllAsync();
        Task AddAsync(ShapeBaseDto shape);
        Task UpdateAsync(ShapeBaseDto shape);
        Task DeleteAsync(Guid id);
    }
}
