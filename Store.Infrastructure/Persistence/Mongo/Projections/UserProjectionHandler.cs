using MediatR;
using MongoDB.Driver;
using Store.Application.Events.UserEvents;
using Store.Infrastructure.Persistence.Mongo;
using Store.Infrastructure.Persistence.Mongo.ReadModels;

public class UserProjectionHandler :
    INotificationHandler<UserCreatedEvent>,
    INotificationHandler<UserUpdatedEvent>
{
    private readonly IMongoCollection<UserReadModel> _collection;

    public UserProjectionHandler(MongoDbContext context)
    {
        _collection = context.GetCollection<UserReadModel>("users");
    }

    public async Task Handle(
        UserCreatedEvent notification,
        CancellationToken ct)
    {
        var readModel = new UserReadModel
        (
            notification.Id,
            notification.Username,
            notification.Email,
            notification.Password,
            notification.BirthDate,
            notification.CreatedAt,
            notification.UpdatedAt
        );

        await _collection.InsertOneAsync(readModel, cancellationToken: ct);
    }

    public async Task Handle(
        UserUpdatedEvent notification,
        CancellationToken ct)
    {
        /*
        var update = Builders<UserReadModel>.Update
            .Set(x => x.FullName,
                 notification.FirstName + " " + notification.LastName)
            .Set(x => x.Email, notification.Email)
            .Set(x => x.Password, notification.Password)
            .Set(x => x.UpdatedAt, notification.UpdatedAt);

        await _collection.UpdateOneAsync(
            x => x.Id == notification.Id,
            update);
        */
    }
}