using AspNetApi.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<ICoinClient, CoinClient>();
// Allow cors for localhost in development mode
builder.Services.AddCors(options => {
    // Get if we are in development mode
    var isDevelopment = builder.Configuration["ASPNETCORE_ENVIRONMENT"] == "Development";
    if(isDevelopment) {
        options.AddDefaultPolicy(
            builder => builder.AllowAnyOrigin()
                .AllowAnyHeader()
                .AllowAnyMethod()
        );
    } else {
        // Production mode add front end urls here
    }
});

builder.Services.AddControllers();


var app = builder.Build();

app.UseHttpsRedirection();
app.UseAuthorization();
app.UseCors();
app.MapControllers();

app.Run();