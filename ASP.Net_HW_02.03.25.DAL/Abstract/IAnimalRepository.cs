using ASP.Net_HW_02._03._25.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASP.Net_HW_02._03._25.DAL.Abstract
{
    public interface IAnimalRepository
    {
        Task<IEnumerable<Animal>> GetAllAsync();
        Task<Animal> GetByIdAsync(int id);
        Task AddAsync(Animal animal);
        Task DeleteAsync(Guid id);
        Task UpdateAsync(Animal animal);
    }
}
