using API.NorwayTides.Configuration;
using API.NorwayTides.Services;
using System.Net.Http;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddHttpClient();
builder.Services.AddScoped<TidalDataService>();

builder.Services.AddSingleton<TidalDataParser>();

builder.Services.Configure<APISettings>(
    builder.Configuration.GetSection("APISettings"));

var app = builder.Build();



if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
