using AutoMapper;
using WebTrade.Dtos;
using WebTrade.Entities;
using WebTrade.Repositories;

namespace WebTrade.Services;

public class SecurityService : ISecurityService
{
    private readonly IWebTradeRepository _webTradeRepository;
    private readonly ICacheRepository _cacheRepository;
    private readonly ICacheService _cacheService;
    private readonly IMapper _mapper;
    private readonly ILogger<SecurityService> _logger;

    public SecurityService(
        IWebTradeRepository webTradeRepository, 
        ICacheRepository cacheRepository, 
        ICacheService cacheService, 
        IMapper mapper, 
        ILogger<SecurityService> logger)
    {
        _webTradeRepository = webTradeRepository;
        _cacheRepository = cacheRepository;
        _cacheService = cacheService;
        _mapper = mapper;
        _logger = logger;
    }

    public async Task<IEnumerable<SecurityDto>> GetAll()
    {
        try
        { 
            return _mapper.Map<IEnumerable<SecurityDto>>(await _cacheRepository.GetSecurities());
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "{Message}", ex.Message);
            throw;
        }
    }

    public async Task<SecurityDto> Update(UpdateSecurityDto input)
    {
        try
        {
            Security security = await _webTradeRepository.UpdateSecurity(_mapper.Map<Security>(input));
            _cacheService.InvalidateKeys(CacheKey.Securities, Utils.GetCachePrefix(CacheKey.Security, security.Id.ToString()));
            return _mapper.Map<SecurityDto>(security);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "{Message}", ex.Message);
            throw;
        }
    }
}
