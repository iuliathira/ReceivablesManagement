using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ReceivablesManagement.Business.DTOs;
using ReceivablesManagement.Business.Helpers;
using ReceivablesManagement.Data.Entities;
using ReceivablesManagement.Data.Repositories;

namespace ReceivablesManagement.Business.Services
{
    public interface IReceivablesServices
    {
        public Task<List<ReceivableDTO>> GetAllAsync();
        public Task<Guid> AddAsync(ReceivableDTO receivableDTO);
        public Task<ReceivableSummaryDTO> GetSummaryAsync(ReceivableFilterDTO filter);
    }

    public class ReceivablesServices: IReceivablesServices
	{
        private readonly IMapper _mapper;
        private readonly IReceivablesRepository _receivablesRepository;

        public ReceivablesServices(IMapper mapper, IReceivablesRepository receivablesRepository)
		{
            _mapper = mapper;
            _receivablesRepository = receivablesRepository;
        }

        public async Task<List<ReceivableDTO>> GetAllAsync()
        {
            var receivables = await _receivablesRepository.ReadAllAsync();
            var dtos = _mapper.Map<List<ReceivableDTO>>(receivables);
            return dtos;
        }

        public async Task<Guid> AddAsync(ReceivableDTO receivableDTO)
        {
            var receivable = _mapper.Map<Receivable>(receivableDTO);
            var id = await _receivablesRepository.CreateAsync(receivable);
            return id;
        }

        public async Task<ReceivableSummaryDTO> GetSummaryAsync(ReceivableFilterDTO filter)
        {
            var queryable = _receivablesRepository
                .ReadAll();

            var receivables = await queryable
                .WhereAll(filter)
                .ToListAsync();

            var openReceivables = receivables.Where(r => (r.Cancelled == null || !r.Cancelled.Value) && string.IsNullOrEmpty(r.ClosedDate));
            var closedReceivables = receivables.Where(r => (r.Cancelled == null || !r.Cancelled.Value) && !string.IsNullOrEmpty(r.ClosedDate));
            var cancelledReceivables = receivables.Where(r => r.Cancelled.HasValue && r.Cancelled.Value == true);

            var summary = new ReceivableSummaryDTO
            {
                NumberOfOpenReceivables = openReceivables.Count(),
                NumberOfClosedReceivables = closedReceivables.Count(),
                NumberOfCancelledReceivables = cancelledReceivables.Count(),
                ValueOfOpenReceivables = openReceivables.Sum(r => r.OpeningValue),
                ValueOfClosedReceivables = closedReceivables.Sum(r => r.OpeningValue),
                ValueOfCancelledReceivables = cancelledReceivables.Sum(r => r.OpeningValue),
                ValueOfPaidOpenReceivables = openReceivables.Sum(r => r.PaidValue),
                ValueOfPaidClosedReceivables = closedReceivables.Sum(r => r.PaidValue),
                ValueOfPaidCancelledReceivables = cancelledReceivables.Sum(r => r.PaidValue),
                NumberOfDebtors = receivables.Select(r => r.DebtorName).Distinct().Count()
            };

            return summary;
        }
    }
}