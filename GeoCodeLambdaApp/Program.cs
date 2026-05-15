using GeoCodeLambdaApp.Percistance.Configuration;
using GeoCodeLambdaApp.Percistance.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.ConfigureCloaudServices();

builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(GeoCodeLambdaApp.Application.Features.GeoCode.GeoCodeQueryHandler).Assembly));

builder.Services.AddHttpClient<GoogleGeocodeService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
