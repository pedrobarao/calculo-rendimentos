using B3.CalculoRendimentos.Domain.Communication;
using B3.CalculoRendimentos.Domain.Exceptions;

namespace B3.CalculoRendimentos.Domain.Services;

public class CalculoRendimentoCdbService : ICalculoRendimentoService
{
    private const decimal Cdi = 0.009m;
    private const decimal Tb = 1.08m;

    public decimal CalcularRendimentoBruto(decimal valorInicial, int prazoMeses)
    {
        if (valorInicial <= 0) throw new DomainException(ErrorMessage.ValorInicialInvalido);
        if (prazoMeses <= 1) throw new DomainException(ErrorMessage.PrazoMezesInvalido);

        for (var i = 0; i < prazoMeses; i++) valorInicial *= 1 + Cdi * Tb;

        return Math.Round(valorInicial, 2);
    }

    public decimal CalcularRendimentoLiquido(decimal rendimentoBruto, decimal valorInicial, int prazoMeses)
    {
        if (valorInicial <= 0) throw new DomainException(ErrorMessage.ValorInicialInvalido);
        if (prazoMeses <= 1) throw new DomainException(ErrorMessage.PrazoMezesInvalido);
        if (rendimentoBruto <= 0) throw new DomainException(ErrorMessage.RendimentoBrutoInvalido);

        var rendimento = rendimentoBruto - valorInicial;
        var taxaImposto = ObterTaxaImposto(prazoMeses);
        var valorImposto = rendimento * taxaImposto;
        return Math.Round(rendimentoBruto - valorImposto, 2);
    }

    private decimal ObterTaxaImposto(int prazoMeses)
    {
        return prazoMeses switch
        {
            <= 6 => 0.225m,
            <= 12 => 0.20m,
            <= 24 => 0.175m,
            _ => 0.15m
        };
    }
}