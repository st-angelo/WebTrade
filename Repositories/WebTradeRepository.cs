using WebTrade.Entities;

namespace WebTrade.Repositories;

public class WebTradeRepository : IWebTradeRepository
{
    #region Data
    private class MockDb
    {
        public readonly List<Trade> Trades = PopulateTrades();
        public readonly List<User> Users = PopulateUsers();
        public readonly List<Security> Securities = PopulateSecurities();

        #region Mock values
        private static List<Trade> PopulateTrades() => new()
        {
            new()
            {
                Id = Guid.Parse("80dffc08-ab7c-4b02-b808-5f35e0df9e66"),
                Price = 2229.76m,
                Quantity = 0.15m,
                Date = DateTime.Now.AddMonths(-10),
                UserId = Guid.Parse("06a49934-115f-48c1-8f2e-103e728b941b"),
                SecurityId = Guid.Parse("1a82410b-5313-4c53-90bb-8632320b07fc")
            },
            new()
            {
                Id = Guid.Parse("af8aa757-7b18-439c-858d-8c72edf2fc4d"),
                Price = 2232.76m,
                Quantity = 0.2m,
                Date = DateTime.Now.AddMonths(-9),
                UserId = Guid.Parse("06a49934-115f-48c1-8f2e-103e728b941b"),
                SecurityId = Guid.Parse("1a82410b-5313-4c53-90bb-8632320b07fc")
            },
            new()
            {
                Id = Guid.Parse("bedf19cd-a9fe-4e9f-b1fd-2f4059e57080"),
                Price = 2227.51m,
                Quantity = 0.2m,
                Date = DateTime.Now.AddMonths(-5),
                UserId = Guid.Parse("06a49934-115f-48c1-8f2e-103e728b941b"),
                SecurityId = Guid.Parse("1a82410b-5313-4c53-90bb-8632320b07fc")
            },
            new()
            {
                Id = Guid.Parse("e74ebe3d-1c41-4f63-bfdd-771ff544a39e"),
                Price = 138.2m,
                Quantity = 4m,
                Date = DateTime.Now.AddMonths(-3),
                UserId = Guid.Parse("06a49934-115f-48c1-8f2e-103e728b941b"),
                SecurityId = Guid.Parse("3cd68abd-4f1d-4e8e-a72d-85b17c3972ab")
            },
            new()
            {
                Id = Guid.Parse("8f4a59b5-b972-4425-956c-f10437c7fe30"),
                Price = 136.8m,
                Quantity = 10m,
                Date = DateTime.Now.AddMonths(-10),
                UserId = Guid.Parse("2b5e3153-56fd-4b79-adfd-10342cb0a31f"),
                SecurityId = Guid.Parse("3cd68abd-4f1d-4e8e-a72d-85b17c3972ab")
            },
            new()
            {
                Id = Guid.Parse("25d11ec4-602b-4a9f-841e-c210c5538f09"),
                Price = 138.97m,
                Quantity = 20m,
                Date = DateTime.Now.AddMonths(-8),
                UserId = Guid.Parse("2b5e3153-56fd-4b79-adfd-10342cb0a31f"),
                SecurityId = Guid.Parse("3cd68abd-4f1d-4e8e-a72d-85b17c3972ab")
            },
            new()
            {
                Id = Guid.Parse("87a78757-3b17-418d-aec3-dbf4a7f55ea0"),
                Price = 38.34m,
                Quantity = 30m,
                Date = DateTime.Now.AddMonths(-5),
                UserId = Guid.Parse("2b5e3153-56fd-4b79-adfd-10342cb0a31f"),
                SecurityId = Guid.Parse("bc005b4d-6085-4edb-a525-b7ee4b33b389")
            },
            new()
            {
                Id = Guid.Parse("54e2f2e9-6ee6-4ae5-912d-177a9d421ad1"),
                Price = 39.55m,
                Quantity = 20m,
                Date = DateTime.Now.AddMonths(-4),
                UserId = Guid.Parse("2b5e3153-56fd-4b79-adfd-10342cb0a31f"),
                SecurityId = Guid.Parse("bc005b4d-6085-4edb-a525-b7ee4b33b389")
            },
            new()
            {
                Id = Guid.Parse("c8f5344c-d6a7-4b20-b9b6-b0ddd5986aa3"),
                Price = 250.06m,
                Quantity = 10m,
                Date = DateTime.Now.AddMonths(-1),
                UserId = Guid.Parse("2b5e3153-56fd-4b79-adfd-10342cb0a31f"),
                SecurityId = Guid.Parse("d703e0ad-67b3-402b-95b6-6bbbf7cb48d5")
            },
            new()
            {
                Id = Guid.Parse("20c3ec37-8892-465a-9cda-4e04b6fee608"),
                Price = 1032.94m,
                Quantity = 2m,
                Date = DateTime.Now.AddMonths(-4),
                UserId = Guid.Parse("fc84c027-be74-48e7-9c25-24b280c9654d"),
                SecurityId = Guid.Parse("702b6387-67e2-46f0-8916-fcae4a00a3ff")
            },
        };
        private static List<User> PopulateUsers() => new()
        {
            new()
            {
                Id = Guid.Parse("06a49934-115f-48c1-8f2e-103e728b941b"),
                Name = "Ellis Sharp"
            },
            new()
            {
                Id = Guid.Parse("2b5e3153-56fd-4b79-adfd-10342cb0a31f"),
                Name = "Norman Legge"
            },
            new()
            {
                Id = Guid.Parse("fc84c027-be74-48e7-9c25-24b280c9654d"),
                Name = "Emma Zhang"
            }
        };
        private static List<Security> PopulateSecurities() => new()
        {
            new()
            {
                Id = Guid.Parse("3cd68abd-4f1d-4e8e-a72d-85b17c3972ab"),
                Code = "AAPL",
                MarketPrice = 137.13m
            },
            new()
            {
                Id = Guid.Parse("1a82410b-5313-4c53-90bb-8632320b07fc"),
                Code = "GOOG",
                MarketPrice = 2228.55m
            },
            new()
            {
                Id = Guid.Parse("702b6387-67e2-46f0-8916-fcae4a00a3ff"),
                Code = "TSLA",
                MarketPrice = 696.69m
            },
            new()
            {
                Id = Guid.Parse("bc005b4d-6085-4edb-a525-b7ee4b33b389"),
                Code = "INTC",
                MarketPrice = 39.18m
            },
            new()
            {
                Id = Guid.Parse("d703e0ad-67b3-402b-95b6-6bbbf7cb48d5"),
                Code = "MSFT",
                MarketPrice = 252.99m
            },
            new()
            {
                Id = Guid.Parse("2bfca82c-335a-4771-816a-7a07fab255ad"),
                Code = "XOM",
                MarketPrice = 100.46m
            },
            new()
            {
                Id = Guid.Parse("28555f94-21e0-4f70-9e82-ff8ea995c08a"),
                Code = "WOOF",
                MarketPrice = 15.69m
            },
            new()
            {
                Id = Guid.Parse("e88426ed-1ade-42f9-afa1-885224fd2a0b"),
                Code = "WMT",
                MarketPrice = 121.7m
            },
            new()
            {
                Id = Guid.Parse("7be85834-71d1-4f2f-896e-ddd74531a8d9"),
                Code = "LUV",
                MarketPrice = 40.14m
            },
            new()
            {
                Id = Guid.Parse("4e7aabdf-5f0b-40c1-b007-f7f21123ff43"),
                Code = "T",
                MarketPrice = 20.69m
            }
        };
        #endregion
    }

    private readonly static MockDb _db = new();
    #endregion

    #region Trade
    public async Task<IEnumerable<Trade>> GetAllTrades(Guid? userId)
    {
        await Utils.SimulateDbQuery();

        return _db.Trades.Where(trade => !userId.HasValue || (userId.HasValue && trade.UserId == userId.Value))
                         .Select(trade => GetFullTrade(trade));
    }

    public async Task<Trade> AddTrade(Trade trade)
    {
        await Utils.SimulateDbQuery();

        Trade newTrade = new(trade);
        _db.Trades.Add(newTrade);

        return GetFullTrade(newTrade);
    }

    public async Task<Trade> DeleteTrade(Guid id)
    {
        await Utils.SimulateDbQuery();

        Trade trade = _db.Trades.FirstOrDefault(trade => trade.Id == id);
        if (trade == null)
            throw new Exception($"Trade with Id {id} was not found!");

        _db.Trades.Remove(trade);
        return GetFullTrade(trade);
    }
    #endregion

    #region User
    public async Task<IEnumerable<User>> GetAllUsers()
    {
        await Utils.SimulateDbQuery();
        return _db.Users;
    }

    public async Task<User> GetUser(Guid id)
    {
        await Utils.SimulateDbQuery();
        return _db.Users.FirstOrDefault(user => user.Id == id);
    }
    #endregion

    #region Security
    public async Task<IEnumerable<Security>> GetAllSecurities()
    {
        await Utils.SimulateDbQuery();
        return _db.Securities;
    }
    public async Task<Security> GetSecurity(Guid id)
    {
        await Utils.SimulateDbQuery();
        return _db.Securities.FirstOrDefault(security => security.Id == id);
    }

    public async Task<Security> UpdateSecurity(Security security)
    {
        await Utils.SimulateDbQuery();

        int idx = _db.Securities.FindIndex(sec => sec.Id == security.Id);
        if (idx == -1)
            throw new Exception($"Security with Id {security.Id} was not found!");

        _db.Securities[idx] = security;

        return security;
    }
    #endregion

    #region Private functions

    private static Trade GetFullTrade(Trade trade)
    {
        // Get a copy of a trade, not the "database" entity
        Trade copy = trade.DeepCopy();
        // Include related entities
        copy.User = _db.Users.FirstOrDefault(user => user.Id == trade.UserId);
        copy.Security = _db.Securities.FirstOrDefault(security => security.Id == trade.SecurityId);
        return copy;
    }

    #endregion
}
