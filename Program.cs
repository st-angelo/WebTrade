using WebTrade;
using WebTrade.Repositories;
using WebTrade.Schema;
using WebTrade.Services;

var builder = WebApplication.CreateBuilder(args);
builder.Logging.ClearProviders();
builder.Logging.AddConsole();

{
    var services = builder.Services;
    services.AddAutoMapper(typeof(MappingProfile).Assembly);
    services.AddDistributedMemoryCache();
    services.AddLogging();
    services.AddTransient<IWebTradeRepository, WebTradeRepository>();
    services.AddTransient<ICacheRepository, WebTradeRepository>();
    services.AddTransient<ITradeService, TradeService>();
    services.AddTransient<IUserService, UserService>();
    services.AddTransient<ISecurityService, SecurityService>();
    services.AddTransient<ICacheService, CacheService>();
    services.Decorate<ICacheRepository, CacheRepository>();
    services.AddGraphQLServer()
            .RegisterService<ITradeService>()
            .RegisterService<IUserService>()
            .RegisterService<ISecurityService>()
            .AddErrorFilter<GraphQLErrorFilter>()
            .AddQueryType<Query>()
            .AddMutationType<Mutation>();
}

var app = builder.Build();

{
    app.UseRouting();

    app.UseEndpoints(endpoints =>
    {
        endpoints.MapGraphQL("/api/1.0");
    });
}

app.Run();