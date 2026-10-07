using Microsoft.EntityFrameworkCore;
using SistesisUni.Core.Application.Interfaces;
using SistesisUni.Core.Domain.Entities;

namespace SistesisUni.Infrastructure.Persistence.Repositories
{
    public class ThesisRepository : IThesisRepository
    {
        private readonly ThesisDbContext _context;
        public ThesisRepository(ThesisDbContext context) => _context = context;

        public async Task<Thesis?> GetByIdAsync(Guid id)
            => await _context.Theses.FindAsync(id);

        public async Task<IEnumerable<Thesis>> GetAllAsync()
            => await _context.Theses.ToListAsync();

        public async Task AddAsync(Thesis thesis)
        {
            await _context.Theses.AddAsync(thesis);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Thesis thesis)
        {
            _context.Theses.Update(thesis);
            await _context.SaveChangesAsync();
        }
    }
}