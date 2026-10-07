using Microsoft.EntityFrameworkCore;
using SistesisUni.Core.Domain.Entities;

namespace SistesisUni.Infrastructure.Persistence
{
    public class ThesisDbContext : DbContext
    {
        public ThesisDbContext(DbContextOptions<ThesisDbContext> options) : base(options) { }

        public DbSet<Thesis> Theses { get; set; }
    }
}