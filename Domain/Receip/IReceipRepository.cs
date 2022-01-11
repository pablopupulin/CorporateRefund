namespace Domain.Receip;

public interface IReceipRepository
{
    Task CreateAsync(Receip receip);
    Task<IEnumerable<Receip>> ListAsync(Guid clientId);
    Task<Receip> GetAsync(Guid clientId, string id);
}