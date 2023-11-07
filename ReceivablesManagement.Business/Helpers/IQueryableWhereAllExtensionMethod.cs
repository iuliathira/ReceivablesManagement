using ReceivablesManagement.Business.DTOs;
using ReceivablesManagement.Data.Entities;

namespace ReceivablesManagement.Business.Helpers
{
    public static class IQueryableWhereAllExtensionMethod
    {
        public static IQueryable<Receivable> WhereAll(this IQueryable<Receivable> receivables, ReceivableFilterDTO filter)
        {
            if (!string.IsNullOrWhiteSpace(filter.IssueDate))
                receivables = receivables.Where(r => r.IssueDate.Equals(filter.IssueDate));

            if (!string.IsNullOrWhiteSpace(filter.ClosedDate))
                receivables = receivables.Where(r => r.ClosedDate != null && r.ClosedDate.Equals(filter.ClosedDate));

            if (!string.IsNullOrWhiteSpace(filter.DebtorName))
                receivables = receivables.Where(r => r.DebtorName.Equals(filter.DebtorName));

            return receivables;
        }
    }
}