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
    private readonly ILogger<TradeService> _logger;

    public TradeService(
        IWebTradeRepository webTradeRepository,
        ICacheRepository cacheRepository, 
        ICacheService cacheService,
        IMapper mapper,
        ILogger<TradeService> logger)
    {
        _webTradeRepository = webTradeRepository;
        _cacheRepository = cacheRepository;
        _cacheService = cacheService;
        _mapper = mapper;
        _logger = logger;
    }

    public async Task<IEnumerable<TradeDto>> GetAll(TradesFilterDto filters)
    {
        try
        {
            string filtersString = string.Empty;
            if (filters != null && filters.UserId.HasValue) filtersString += $"UserId={filters.UserId.Value}&";
            return _mapper.Map<IEnumerable<TradeDto>>(await _cacheRepository.GetTrades(filtersString));
        }
        catch(Exception ex)
        {
            _logger.LogError(ex, "{Message}", ex.Message);
            throw;
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
            _logger.LogError(ex, "{Message}", ex.Message);
            throw;
        }
    }

    public async Task<TradeDto> Add(AddTradeDto input)
    {
        try
        {
            Security security = await _cacheRepository.GetSecurity(input.SecurityId);
            Trade newTrade = _mapper.Map<Trade>(input, opt => { opt.Items["Price"] = security.MarketPrice; });
            Trade trade = await _webTradeRepository.AddTrade(newTrade);
            // Invalidate cache
            _cacheService.InvalidateByPatterns(CacheKey.Trades);
            return _mapper.Map<TradeDto>(trade);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "{Message}", ex.Message);
            throw;
        }
    }

    public async Task<TradeDto> Delete(Guid id)
    {
        try
        {
            Trade trade = await _webTradeRepository.DeleteTrade(id);
            // Invalidate cache
            _cacheService.InvalidateByPatterns(CacheKey.Trades);
            return _mapper.Map<TradeDto>(trade);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "{Message}", ex.Message);
            throw;
        }
    }
}
