using B3.CalculoRendimentos.Api.Apis;
using B3.CalculoRendimentos.Api.Config;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.RegisterServices();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.MapRendimentoApiV1();

app.Run();