using ASP.Net_HW_02._03._25.DAL.Abstract;
using ASP.Net_HW_02._03._25.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASP.Net_HW_02._03._25.DAL.Repository
{
    public class AnimalRepository :IAnimalRepository
    {
        private readonly AppDbContext _context;
        public AnimalRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task AddAsync(Animal animal)
        {
            _context.Animals.Add(animal);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var animal = await _context.Animals.FindAsync(id);
            if (animal != null)
            {
                _context.Animals.Remove(animal);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Animal>> GetAllAsync()
        {
            return await _context.Animals.ToListAsync();
        }

        public async Task<Animal> GetByIdAsync(int id)
        {
            return await _context.Animals.FindAsync(id);
        }
        public async Task UpdateAsync(Animal animal)
        {
            _context.Animals.Update(animal);
            await _context.SaveChangesAsync();

        }
    }
}
