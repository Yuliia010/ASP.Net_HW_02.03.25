using ASP.Net_HW_02._03._25.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASP.Net_HW_02._03._25.DAL.Abstract
{
    public interface IShapeRepository
    {
        Task<IEnumerable<Shape>> GetAllAsync();
        Task<Shape> GetByIdAsync(int id);
        Task AddAsync(Shape shape);
        Task DeleteAsync(Guid id);
        Task UpdateAsync(Shape shape);
    }
}
