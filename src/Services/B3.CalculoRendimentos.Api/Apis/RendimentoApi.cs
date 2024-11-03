using B3.CalculoRendimentos.Api.Application;
using B3.CalculoRendimentos.Api.Inputs;
using B3.CalculoRendimentos.Api.Outputs;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace B3.CalculoRendimentos.Api.Apis;

public static class RendimentoApi
{
    public static IEndpointRouteBuilder MapRendimentoApiV1(this IEndpointRouteBuilder app)
    {
        var api = app.MapGroup("api/rendimentos");

        // Routes
        api.MapPost("/", CalcularRendimento);

        return app;
    }

    public static Results<Ok<CalculoRendimentoOutput>, BadRequest<string>> CalcularRendimento(
        [FromServices] ICalculoRendimentoUseCase useCase,
        [AsParameters] CalculoRendimentoInput input)
    {
        if (!input.IsValid())
            return TypedResults.BadRequest(
                "Requisição inválida. Verifique se o valor inicial é um número positivo e o prazo é maior que um mês.");

        var result = useCase.Execute(input);

        return TypedResults.Ok(result);
    }
}