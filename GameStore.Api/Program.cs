using GameStore.Api.Data;
using GameStore.Api.Endpoints;
using GameStore.Api.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddSingleton<IGamesRepository, InMemGamesRepository>();

var connstring = builder.Configuration.GetConnectionString("GameStoreContext");
builder.Services.AddSqlServer<GameStoreContext>(connstring);

var app = builder.Build();

app.Services.InitializedDb();

app.MapGamesEndpoints();

app.Run();
