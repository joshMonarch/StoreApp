using MediatR;
using Store.Application.Abstractions;
using Store.Application.DTOs;
using Store.Application.Mappers.UserMapper;
using Store.Application.MediatRHandlers.Requests;
using Store.Application.MediatRHandlers.Specifications;
using Store.Domain.Commons;
using Store.Domain.Entities;
using System.Collections.ObjectModel;

namespace Store.Application.MediatRHandlers.RequestHandlers
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
            var spec = new GetUsersSpecification(request.FromBirthDate, request.ToBirthDate, request.FromDate, request.ToDate);

            ReadOnlyCollection<User> users = await _userRepository.GetFilteredAsync(spec, ct);

            return Result<ReadOnlyCollection<ResponseUserDto>>.Ok(UserToDto.ToDtoList(users));
        }
    }
}
