using B3.CalculoRendimentos.Api.Apis;
using B3.CalculoRendimentos.Api.Config;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.RegisterServices();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAllOrigins", b => b.AllowAnyOrigin()
        .AllowAnyMethod()
        .AllowAnyHeader());
});

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseCors("AllowAllOrigins");

app.MapRendimentoApiV1();

app.Run();