namespace B3.CalculoRendimentos.Domain.Communication;

public static class ErrorMessage
{
    public const string ValorInicialInvalido = "O valor inicial deve ser um número positivo";
    public const string PrazoMezesInvalido = "O prazo deve ser maior que 1 mês";
    public const string RendimentoBrutoInvalido = "O rendimento bruto deve ser maior do que 0";
}