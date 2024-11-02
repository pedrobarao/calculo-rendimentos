using B3.CalculoRendimentos.Api.Inputs;
using B3.CalculoRendimentos.Api.Outputs;

namespace B3.CalculoRendimentos.Api.Application;

public interface ICalculoRendimentoUseCase
{
    public CalculoRendimentoOutput Execute(CalculoRendimentoInput input);
}