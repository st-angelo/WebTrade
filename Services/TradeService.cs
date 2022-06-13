using AutoMapper;
using WebTrade.Dtos;
using WebTrade.Entities;
using WebTrade.Repositories;

namespace WebTrade.Services;

public class TradeService : ITradeService
{
    private readonly IWebTradeRepository _webTradeRepository;
    private readonly ICacheRepository _cacheRepository;
    private readonly ICacheService _cacheService;
    private readonly IMapper _mapper;

    public TradeService(
        IWebTradeRepository webTradeRepository,
        ICacheRepository cacheRepository, 
        ICacheService cacheService,
        IMapper mapper)
    {
        _webTradeRepository = webTradeRepository;
        _cacheRepository = cacheRepository;
        _cacheService = cacheService;
        _mapper = mapper;
    }

    public async Task<IEnumerable<TradeDto>> GetAll(Guid? userId)
    {
        try
        {
            return _mapper.Map<IEnumerable<TradeDto>>(await _cacheRepository.GetTrades(userId));
        }
        catch(Exception ex)
        {
            // TODO implement handling/logging
            throw new Exception(ex.Message);
        }
    }

    public async Task<IEnumerable<PortfolioDto>> GetPortfolios()
    {
        try
        {
            List<PortfolioDto> portfolios = new();

            IEnumerable<Trade> trades = await _cacheRepository.GetTrades();
            IEnumerable<User> users = await _cacheRepository.GetUsers();

            foreach(User user in users)
            {
                decimal purchaseValue = 0m;
                decimal marketValue = 0m;

                foreach(Trade trade in trades.Where(trade => trade.UserId == user.Id))
                {
                    Security security = await _cacheRepository.GetSecurity(trade.SecurityId);

                    purchaseValue += trade.Price * trade.Quantity;
                    marketValue += security.MarketPrice * trade.Quantity;
                }

                portfolios.Add(new()
                {
                    HolderName = user.Name,
                    PurchaseValue = purchaseValue,
                    MarketValue = marketValue,
                    PL = marketValue - purchaseValue
                });
            }

            return portfolios;
        }
        catch (Exception ex)
        {
            // TODO implement handling/logging
            throw new Exception(ex.Message);
        }
    }

    public async Task<TradeDto> Add(AddTradeDto input)
    {
        try
        {
            Security security = await _cacheRepository.GetSecurity(input.SecurityId);
            Trade newTrade = new()
            {
                Price = security.MarketPrice,
                Quantity = input.Quantity,
                UserId = input.UserId,
                SecurityId = input.SecurityId
            };

            Trade trade = await _webTradeRepository.AddTrade(newTrade);

            _cacheService.InvalidateKeys(CacheKey.Trades, Utils.GetCachePrefix(CacheKey.Trades, trade.UserId.ToString()));

            return _mapper.Map<TradeDto>(trade);
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    public async Task<TradeDto> Delete(Guid id)
    {
        try
        {
            Trade trade = await _webTradeRepository.DeleteTrade(id);

            _cacheService.InvalidateKeys(CacheKey.Trades, Utils.GetCachePrefix(CacheKey.Trades, trade.UserId.ToString()));

            return _mapper.Map<TradeDto>(trade);
        }
        catch (Exception ex)
        {
            // TODO implement handling/logging
            throw new Exception(ex.Message);
        }
    }
}
