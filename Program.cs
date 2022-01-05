using AspNetApi.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<ICoinClient, CoinClient>();
builder.Services.AddControllers();

var app = builder.Build();

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();