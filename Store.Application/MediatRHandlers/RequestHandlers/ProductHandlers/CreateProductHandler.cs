using MediatR;
using Store.Application.Abstractions;
using Store.Application.Abstractions.Messaging;
using Store.Application.Events.CategoryEvents;
using Store.Application.Events.ProductEvents;
using Store.Application.Mappers.ProductMapper;
using Store.Application.MediatRHandlers.Requests.ProductRequest;
using Store.Domain.Commons;
using Store.Domain.Entities;

namespace Store.Application.MediatRHandlers.RequestHandlers.ProductHandlers
{
    public class CreateProductHandler : IRequestHandler<CreateProductRequest, Result<int>>
    {
        private readonly IProductRepository _productRepository;
        private readonly IEventBus _eventBus;
        private readonly List<IDomainEvent> _events = new();
        public IReadOnlyList<IDomainEvent> DomainEvents => _events.AsReadOnly();
        public CreateProductHandler(IProductRepository productRepository, IEventBus eventBus)
        {
            _productRepository = productRepository;
            _eventBus = eventBus;
        }
        public async Task<Result<int>> Handle(CreateProductRequest request, CancellationToken ct)
        {
            var product = ProductToEntity.ToEntity(request);

            if (!product.IsSuccess)
                return Result<int>.Fail($"Invalid product data: {product.Error}");

            var result = await _productRepository.CreateAsync(product.Data, ct);

            if (result <= 0)
                return Result<int>.Fail("Failed to create product.");

            _events.Add(new ProductCreatedEvent(
                result,
                product.Data.UserId,
                product.Data.CategoryId,
                product.Data.Name,
                product.Data.Stock.Value));

            foreach (var evt in DomainEvents)
            {
                await _eventBus.PublishAsync(evt, ct);
            }

            return Result<int>.Ok(result);
        }
    }
}
