using MediatR;
using Store.Application.Abstractions;
using Store.Application.DTOs;
using Store.Application.MediatRHandlers.Requests.UserRequests;
using Store.Domain.Commons;
using System.Collections.ObjectModel;

namespace Store.Application.MediatRHandlers.RequestHandlers.UserHandlers
{
    public class GetUsersHandler : IRequestHandler<GetUsersRequest, Result<ReadOnlyCollection<ResponseUserDto>>>
    {
        private readonly IUserRepository _userRepository;
        public GetUsersHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task<Result<ReadOnlyCollection<ResponseUserDto>>> Handle(GetUsersRequest request, CancellationToken ct)
        {

            ReadOnlyCollection<ResponseUserDto> users = await _userRepository.GetFilteredAsync(request, ct);

            return Result<ReadOnlyCollection<ResponseUserDto>>.Ok(users);
        }
    }
}
