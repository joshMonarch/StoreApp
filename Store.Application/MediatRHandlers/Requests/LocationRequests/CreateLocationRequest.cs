using MediatR;
using Store.Domain.Commons;

namespace Store.Application.MediatRHandlers.Requests.LocationRequests
{
    public class CreateLocationRequest: IRequest<Result<int>>
    {
        public string? LocationType { get; }

        public CreateLocationRequest(string? locationType)
        {
            LocationType = locationType;
        }
    }
}
