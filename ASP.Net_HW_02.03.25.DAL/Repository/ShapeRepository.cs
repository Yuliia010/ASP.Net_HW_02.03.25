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
    public class ShapeRepository : IShapeRepository
    {
        private readonly AppDbContext _context;
        public ShapeRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task AddAsync(Shape shape)
        {
            _context.Shapes.Add(shape);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var shape = await _context.Shapes.FindAsync(id);
            if (shape != null)
            {
                _context.Shapes.Remove(shape);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Shape>> GetAllAsync()
        {
            return await _context.Shapes.ToListAsync();
        }

        public async Task<Shape> GetByIdAsync(int id)
        {
            return await _context.Shapes.FindAsync(id);
        }
        public async Task UpdateAsync(Shape shape)
        {
            _context.Shapes.Update(shape);
            await _context.SaveChangesAsync();

        }
    }
}
