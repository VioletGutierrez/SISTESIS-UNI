using SistesisUni.Core.Domain.Entities;

namespace SistesisUni.Core.Application.Interfaces
{
    public interface IThesisRepository
    {
        Task<Thesis?> GetByIdAsync(Guid id);
        Task<IEnumerable<Thesis>> GetAllAsync();
        Task AddAsync(Thesis thesis);
        Task UpdateAsync(Thesis thesis);
    }
}