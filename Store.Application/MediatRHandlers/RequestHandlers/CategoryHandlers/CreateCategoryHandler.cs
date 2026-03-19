using MediatR;
using Store.Application.Abstractions;
using Store.Application.Abstractions.Messaging;
using Store.Application.Events.CategoryEvents;
using Store.Application.Mappers.CategoryMapper;
using Store.Application.MediatRHandlers.Requests.CategoryRequests;
using Store.Domain.Commons;

namespace Store.Application.MediatRHandlers.RequestHandlers.CategoryHandlers
{
    public class CreateCategoryHandler : IRequestHandler<CreateCategoryRequest, Result<int>>
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IEventBus _eventBus;
        private readonly List<IDomainEvent> _events = new();
        public IReadOnlyList<IDomainEvent> DomainEvents => _events.AsReadOnly();
        public CreateCategoryHandler(ICategoryRepository categoryRepository, IEventBus eventBus)
        {
            _categoryRepository = categoryRepository;
            _eventBus = eventBus;
        }

        public async Task<Result<int>> Handle(CreateCategoryRequest request, CancellationToken ct)
        {
            var category = CategoryToEntity.ToEntity(request);

            if (!category.IsSuccess)
                return Result<int>.Fail($"Invalid address data: {category.Error}");

            var result = await _categoryRepository.CreateAsync(category.Data, ct);

            if (result <= 0)
                return Result<int>.Fail("Failed to create address.");

            _events.Add(new CategoryCreatedEvent(
                result,
                category.Data.CategoryName));

            foreach (var evt in DomainEvents)
            {
                await _eventBus.PublishAsync(evt, ct);
            }

            return Result<int>.Ok(result);
        }
    }
}
