using MediatR;
using Store.Application.Abstractions;
using Store.Application.Abstractions.Messaging;
using Store.Application.Events.CategoryEvents;
using Store.Application.Events.UserEvents;
using Store.Application.Mappers.UserMapper;
using Store.Application.MediatRHandlers.Requests.UserRequests;
using Store.Domain.Commons;
using Store.Domain.Entities;

namespace Store.Application.MediatRHandlers.RequestHandlers.UserHandlers
{
    public class CreateUserHandler : IRequestHandler<CreateUserRequest, Result<int>>
    {
        private readonly IUserRepository _userRepository;
        private readonly IEventBus _eventBus;
        private readonly List<IDomainEvent> _events = new();
        public IReadOnlyList<IDomainEvent> DomainEvents => _events.AsReadOnly();
        public CreateUserHandler(IUserRepository userRepository, IEventBus eventBus)
        {
            _userRepository = userRepository;
            _eventBus = eventBus;
        }
        public async Task<Result<int>> Handle(CreateUserRequest request, CancellationToken ct)
        {
            var user = UserToEntity.ToEntity(request);

            if (!user.IsSuccess)
                return Result<int>.Fail($"Invalid user data: {user.Error}");

            var result = await _userRepository.CreateAsync(user.Data, ct);

            if (result == 0)
                return Result<int>.Fail("Failed to create user.");

            _events.Add(new UserCreatedEvent(
                result,
                user.Data.Username,
                user.Data.Email,
                user.Data.Password,
                user.Data.BirthDate));

            foreach (var evt in DomainEvents)
            {
                await _eventBus.PublishAsync(evt, ct);
            }

            return Result<int>.Ok(result);
        }
    }
}
