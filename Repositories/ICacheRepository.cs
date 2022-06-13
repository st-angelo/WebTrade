using WebTrade.Entities;

namespace WebTrade.Repositories
{
    public interface ICacheRepository
    {
        // Trade
        Task<IEnumerable<Trade>> GetTrades(Guid? userId = null);
        // User
        Task<IEnumerable<User>> GetUsers();
        Task<User> GetUser(Guid id);
        // Security
        Task<IEnumerable<Security>> GetSecurities();
        Task<Security> GetSecurity(Guid id);
    }
}
