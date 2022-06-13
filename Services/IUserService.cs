using WebTrade.Dtos;

namespace WebTrade.Services
{
    public interface IUserService
    {
        Task<IEnumerable<UserDto>> GetAll();
    }
}
