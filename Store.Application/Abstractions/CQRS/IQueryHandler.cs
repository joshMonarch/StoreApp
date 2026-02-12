using Store.Domain.Commons;

namespace Store.Application.Abstractions.CQRS
{
    public interface IQueryHandler<TQuery, TResult>
        where TQuery: IQuery<TResult>
    {
        public Task<Result<TResult>> Handle(TQuery query, CancellationToken ct);
    }
}
