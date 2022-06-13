using WebTrade.Dtos;

namespace WebTrade.Services;

public interface ITradeService
{
    Task<IEnumerable<TradeDto>> GetAll(Guid? userId);
    Task<IEnumerable<PortfolioDto>> GetPortfolios();
    Task<TradeDto> Add(AddTradeDto input);
    Task<TradeDto> Delete(Guid id);
}
