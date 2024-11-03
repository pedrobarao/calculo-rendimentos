namespace B3.CalculoRendimentos.Api.Inputs;

public class CalculoRendimentoInput
{
    public required decimal ValorInicial { get; set; }
    public required int PrazoMeses { get; set; }

    public bool IsValid()
    {
        return ValorInicial > 0 && PrazoMeses > 1;
    }
}