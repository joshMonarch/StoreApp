using Store.Application.Abstractions;
using Store.Application.Abstractions.CQRS;
using Store.Application.DTOs;
using Store.Application.Mappers.UserMapper;
using Store.Domain.Commons;
using Store.Domain.Entities;
using System.Collections.ObjectModel;

namespace Store.Application.Queries.GetUser
{
    public class GetUsersQueryHandler : IQueryHandler<GetUsersQuery, ReadOnlyCollection<ResponseUserDto>>
    {
        private readonly IUserRepository _userRepository;
        public GetUsersQueryHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task<Result<ReadOnlyCollection<ResponseUserDto>>> Handle(GetUsersQuery query, CancellationToken ct)
        {
            var spec = new GetUsersSpecification(query.FromBirthDate, query.ToBirthDate, query.FromDate, query.ToDate);

            ReadOnlyCollection<User> users = await _userRepository.GetFilteredAsync(spec, ct);

            return Result<ReadOnlyCollection<ResponseUserDto>>.Ok(UserToDto.ToDtoList(users));
        }
    }
}
