namespace B3.CalculoRendimentos.Domain.Services;

public interface ICalculoRendimentoService
{
    decimal CalcularRendimentoBruto(decimal valorInicial, int prazoMeses);
    decimal CalcularRendimentoLiquido(decimal rendimentoBruto, decimal valorInicial, int prazoMeses);
}