using WebTrade.Entities;

namespace WebTrade.Repositories
{
    public interface ICacheRepository
    {
        // Trade
        Task<IEnumerable<Trade>> GetTrades(string filters = null);
        // User
        Task<IEnumerable<User>> GetUsers(string filters = null);
        Task<User> GetUser(Guid id);
        // Security
        Task<IEnumerable<Security>> GetSecurities(string filters = null);
        Task<Security> GetSecurity(Guid id);
    }
}
