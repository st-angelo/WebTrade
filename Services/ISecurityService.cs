using WebTrade.Dtos;

namespace WebTrade.Services;

public interface ISecurityService
{
    Task<IEnumerable<SecurityDto>> GetAll();
    Task<SecurityDto> Update(UpdateSecurityDto input);
}
