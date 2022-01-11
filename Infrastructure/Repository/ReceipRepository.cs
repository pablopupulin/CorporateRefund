using Domain.Receip;
using Infrastructure.Settings;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace Infrastructure.Repository;

public class ReceipRepository : IReceipRepository
{
    private readonly IMongoDatabase _database;

    public ReceipRepository(IOptions<DatabaseSettings> options)
    {
        var databaseSettings = options.Value;
        var client = new MongoClient(databaseSettings.ConnectionString);
        _database = client.GetDatabase(databaseSettings.DatabaseName);
    }

    public async Task CreateAsync(Receip receip)
    {
        var collection = _database.GetCollection<Receip>(receip.ClientId.ToString());

        await collection.InsertOneAsync(receip);
    }

    public async Task<IEnumerable<Receip>> ListAsync(Guid clientId)
    {
        var collection = _database.GetCollection<Receip>(clientId.ToString());
        var findResult = await collection.FindAsync(Builders<Receip>.Filter.Empty);
        return await findResult.ToListAsync();
    }

    public async Task<Receip> GetAsync(Guid clientId, string id)
    {
        var collection = _database.GetCollection<Receip>(clientId.ToString());
        var findResult = await collection.FindAsync(c=> c.Id == id);
        return await findResult.FirstOrDefaultAsync();
    }
}