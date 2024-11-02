using B3.CalculoRendimentos.Api.Inputs;
using B3.CalculoRendimentos.Api.Outputs;
using B3.CalculoRendimentos.Domain.Services;

namespace B3.CalculoRendimentos.Api.Application;

public class CalculoRendimentoUseCase(ICalculoRendimentoService service) : ICalculoRendimentoUseCase
{
    public CalculoRendimentoOutput Execute(CalculoRendimentoInput input)
    {
        var rendimentoBruto = service.CalcularRendimentoBruto(input.ValorInicial, input.PrazoMeses);
        var rendimentoLiquido =
            service.CalcularRendimentoLiquido(rendimentoBruto, input.ValorInicial, input.PrazoMeses);

        return new CalculoRendimentoOutput
        {
            RendimentoBruto = rendimentoBruto,
            RendimentoLiquido = rendimentoLiquido
        };
    }
}