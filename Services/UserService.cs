using AutoMapper;
using WebTrade.Dtos;
using WebTrade.Repositories;

namespace WebTrade.Services
{
    public class UserService : IUserService
    {
        private readonly ICacheRepository _cacheRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<UserService> _logger;

        public UserService(
            ICacheRepository cacheRepository,
            IMapper mapper,
            ILogger<UserService> logger)
        {
            _cacheRepository = cacheRepository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<IEnumerable<UserDto>> GetAll()
        {
            try
            {
                return _mapper.Map<IEnumerable<UserDto>>(await _cacheRepository.GetUsers());
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "{Message}", ex.Message);
                throw;
            }
        }
    }
}
