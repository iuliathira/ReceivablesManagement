using Microsoft.EntityFrameworkCore;
using ReceivablesManagement.Data.Entities;

namespace ReceivablesManagement.Data.Repositories
{
    public interface IReceivablesRepository
	{
        public Task<List<Receivable>> ReadAllAsync();
        public Task<Guid> CreateAsync(Receivable receivable);
        public IQueryable<Receivable> ReadAll();
    }

    public class ReceivablesRepository: IReceivablesRepository
	{
        private readonly ReceivableDbContext _receivableDbContext;

        public ReceivablesRepository(ReceivableDbContext receivableDbContext)
		{
            _receivableDbContext = receivableDbContext;
        }

        public async Task<Guid> CreateAsync(Receivable receivable)
        {
            receivable.Id = new Guid();
            await _receivableDbContext.Receivables.AddAsync(receivable);
            await _receivableDbContext.SaveChangesAsync();
            return receivable.Id;
        }

        public async Task<List<Receivable>> ReadAllAsync()
        {
            return await _receivableDbContext.Receivables.ToListAsync();
        }

        public IQueryable<Receivable>ReadAll()
        {
            return _receivableDbContext.Receivables.AsQueryable();
        }
    }
}

