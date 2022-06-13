using WebTrade;
using WebTrade.Repositories;
using WebTrade.Schema;
using WebTrade.Services;

var builder = WebApplication.CreateBuilder(args);

{
    var services = builder.Services;
    services.AddAutoMapper(typeof(MappingProfile).Assembly);
    services.AddTransient<IWebTradeRepository, WebTradeRepository>();
    services.AddTransient<ITradeService, TradeService>();
    services.AddTransient<ISecurityService, SecurityService>();
    services.AddGraphQLServer()
            .RegisterService<ITradeService>()
            .RegisterService<ISecurityService>()
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