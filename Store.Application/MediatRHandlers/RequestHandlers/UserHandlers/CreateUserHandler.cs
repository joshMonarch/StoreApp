using MediatR;
using Store.Application.Abstractions;
using Store.Application.Mappers.UserMapper;
using Store.Application.MediatRHandlers.Requests.UserRequests;
using Store.Domain.Commons;

namespace Store.Application.MediatRHandlers.RequestHandlers.UserHandlers
{
    public class CreateUserHandler : IRequestHandler<CreateUserRequest, Result<int>>
    {
        private readonly IUserRepository _userRepository;
        public CreateUserHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task<Result<int>> Handle(CreateUserRequest request, CancellationToken ct)
        {
            var user = UserToEntity.ToEntity(request);

            if (!user.IsSuccess)
                return Result<int>.Fail($"Invalid user data: {user.Error}");

            var result = await _userRepository.CreateAsync(user.Data, ct);

            if (result == 0)
                return Result<int>.Fail("Failed to create user.");

            return Result<int>.Ok(result);
        }
    }
}
