using MediatR;
using MongoDB.Driver;
using Store.Application.Events.AddressEvents;
using Store.Infrastructure.Persistence.Mongo;
using Store.Infrastructure.Persistence.ReadModels;

public class AddressProjectionHandler :
    INotificationHandler<AddressCreatedEvent>,
    INotificationHandler<AddressUpdatedEvent>
{
    private readonly IMongoCollection<AddressReadModel> _collection;

    public AddressProjectionHandler(MongoDbContext context)
    {
        _collection = context.GetCollection<AddressReadModel>("Addresss");
    }

    public async Task Handle(
        AddressCreatedEvent notification,
        CancellationToken ct)
    {
        var readModel = new AddressReadModel
        (
            notification.Id,
            notification.UserId,
            notification.LocationId,
            notification.Country,
            notification.Region,
            notification.City,
            notification.Name,
            notification.Number,
            notification.Floor,
            notification.Door,
            notification.CreatedAt,
            notification.UpdatedAt
        );

        await _collection.InsertOneAsync(readModel, cancellationToken: ct);
    }

    public async Task Handle(
        AddressUpdatedEvent notification,
        CancellationToken ct)
    {
        /*
        var update = Builders<AddressReadModel>.Update
            .Set(x => x.FullName,
                 notification.FirstName + " " + notification.LastName)
            .Set(x => x.Email, notification.Email)
            .Set(x => x.City, notification.City)
            .Set(x => x.UpdatedAt, notification.UpdatedAt);

        await _collection.UpdateOneAsync(
            x => x.Id == notification.Id,
            update);
        */
    }
}