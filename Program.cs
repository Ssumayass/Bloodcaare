using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

// Lägg till tjänster i behållaren (services container).

builder.Services.AddControllers();
// Läs mer om Swagger/OpenAPI-konfiguration på https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Konfigurera HTTP-request-pipelinen.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    //var getRequest = new GetRequest();
    //var searchResponse = getRequest.search();
    //divtitle.text = searchResponse;
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
