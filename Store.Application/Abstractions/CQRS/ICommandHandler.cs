using Store.Domain.Commons;

namespace Store.Application.Abstractions.CQRS
{
    public interface ICommandHandler<TCommand>
    {
        public Task<Result<int>> Handle(TCommand command, CancellationToken ct);
    }
}
