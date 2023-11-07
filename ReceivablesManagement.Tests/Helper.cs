using System.Diagnostics.CodeAnalysis;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;
using ReceivablesManagement.Business.DTOs;

namespace ReceivablesManagement.Tests
{
    public class ReceivableDTOEqualityComparer : IEqualityComparer<ReceivableDTO>
    {
        public bool Equals(ReceivableDTO x, ReceivableDTO y)
        {
            return x.Reference.Equals(y.Reference) &&
                x.CurrencyCode.Equals(y.CurrencyCode) &&
                x.IssueDate.Equals(y.IssueDate) &&
                x.OpeningValue == y.OpeningValue &&
                x.PaidValue == y.PaidValue &&
                x.DueDate.Equals(y.DueDate) &&
                x.ClosedDate == y.ClosedDate &&
                x.Cancelled == y.Cancelled &&
                x.DebtorReference.Equals(y.DebtorReference) &&
                x.DebtorName.Equals(y.DebtorName) &&
                x.DebtorAddress1 == y.DebtorAddress1 &&
                x.DebtorAddress2 == y.DebtorAddress2 &&
                x.DebtorTown == y.DebtorTown &&
                x.DebtorState == y.DebtorState &&
                x.DebtorZip == y.DebtorZip &&
                x.DebtorCountryCode.Equals(y.DebtorCountryCode) &&
                x.DebtorRegistrationNumber == y.DebtorRegistrationNumber;
        }

        public int GetHashCode([DisallowNull] ReceivableDTO obj)
        {
            return obj.GetHashCode();
        }
    }

    public static class AsyncQueryable
    {
        /// <summary>
        /// Returns the input typed as IQueryable that can be queried asynchronously
        /// </summary>
        /// <typeparam name="TEntity">The item type</typeparam>
        /// <param name="source">The input</param>
        public static IQueryable<TEntity> AsAsyncQueryable<TEntity>(this IEnumerable<TEntity> source)
            => new AsyncQueryable<TEntity>(source ?? throw new ArgumentNullException(nameof(source)));
    }

    public class AsyncQueryable<TEntity> : EnumerableQuery<TEntity>, IAsyncEnumerable<TEntity>, IQueryable<TEntity>
    {
        public AsyncQueryable(IEnumerable<TEntity> enumerable) : base(enumerable) { }
        public AsyncQueryable(Expression expression) : base(expression) { }
        public IAsyncEnumerator<TEntity> GetEnumerator() => new AsyncEnumerator(this.AsEnumerable().GetEnumerator());
        public IAsyncEnumerator<TEntity> GetAsyncEnumerator(CancellationToken cancellationToken = default) => new AsyncEnumerator(this.AsEnumerable().GetEnumerator());
        IQueryProvider IQueryable.Provider => new AsyncQueryProvider(this);

        class AsyncEnumerator : IAsyncEnumerator<TEntity>
        {
            private readonly IEnumerator<TEntity> inner;
            public AsyncEnumerator(IEnumerator<TEntity> inner) => this.inner = inner;
            public void Dispose() => inner.Dispose();
            public TEntity Current => inner.Current;
            public ValueTask<bool> MoveNextAsync() => new ValueTask<bool>(inner.MoveNext());
#pragma warning disable CS1998 // Nothing to await
            public async ValueTask DisposeAsync() => inner.Dispose();
#pragma warning restore CS1998
        }

        class AsyncQueryProvider : IAsyncQueryProvider
        {
            private readonly IQueryProvider inner;
            internal AsyncQueryProvider(IQueryProvider inner) => this.inner = inner;
            public IQueryable CreateQuery(Expression expression) => new AsyncQueryable<TEntity>(expression);
            public IQueryable<TElement> CreateQuery<TElement>(Expression expression) => new AsyncQueryable<TElement>(expression);
            public object Execute(Expression expression) => inner.Execute(expression);
            public TResult Execute<TResult>(Expression expression) => inner.Execute<TResult>(expression);
            public IAsyncEnumerable<TResult> ExecuteAsync<TResult>(Expression expression) => new AsyncQueryable<TResult>(expression);
            TResult IAsyncQueryProvider.ExecuteAsync<TResult>(Expression expression, CancellationToken cancellationToken) => Execute<TResult>(expression);
        }
    }

}