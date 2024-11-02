using B3.CalculoRendimentos.Domain.Communication;
using B3.CalculoRendimentos.Domain.Exceptions;
using B3.CalculoRendimentos.Domain.Test.Fixtures;
using FluentAssertions;

namespace B3.CalculoRendimentos.Domain.Test.Services;

public class CalculoRendimentoCdbServiceTest : IClassFixture<CalculoRendimentoCdbServiceFixture>
{
    private readonly CalculoRendimentoCdbServiceFixture _fixture;

    public CalculoRendimentoCdbServiceTest(CalculoRendimentoCdbServiceFixture fixture)
    {
        _fixture = fixture;
    }

    [Theory(DisplayName = "Calcular rendimento bruto com valor inicial inválido deve retornar erro")]
    [Trait("Category", "Domain Services - Unit Tests")]
    [InlineData(0)]
    [InlineData(-1)]
    public void CalcularRendimentoBruto_ValorInicialInvalido_DeveRetornarErro(decimal valorInicial)
    {
        // Arrange
        var service = _fixture.GetService();

        // Act
        var func = () => service.CalcularRendimentoBruto(valorInicial, 2);

        // Assert
        func.Should()
            .Throw<DomainException>("o valor inicial deve ser um número positivo")
            .WithMessage(ErrorMessage.ValorInicialInvalido);
    }

    [Theory(DisplayName = "Calcular rendimento bruto com prazo inválido deve retornar erro")]
    [Trait("Category", "Domain Services - Unit Tests")]
    [InlineData(1)]
    [InlineData(0)]
    [InlineData(-1)]
    public void CalcularRendimentoBruto_PrazoInvalido_DeveRetornarErro(int prazoMeses)
    {
        // Arrange
        var service = _fixture.GetService();

        // Act
        var func = () => service.CalcularRendimentoBruto(1000, prazoMeses);

        // Assert
        func.Should()
            .Throw<DomainException>("o prazo deve ser maior que 1 mês")
            .WithMessage(ErrorMessage.PrazoMezesInvalido);
    }

    [Theory(DisplayName = "Calcular rendimento bruto com com valores válidos deve retornar o valor correto")]
    [Trait("Category", "Domain Services - Unit Tests")]
    [InlineData(10000, 6, 10597.56)]
    [InlineData(15000, 12, 16846.23)]
    [InlineData(20000, 18, 23803.85)]
    [InlineData(25000, 24, 31532.83)]
    [InlineData(30000, 30, 40100.52)]
    public void CalcularRendimentoBruto_ValoresValidos_DeveRetornarRendimentoBruto(decimal valorInicial, int prazoMeses,
        decimal rendimentoEsperado)
    {
        // Arrange
        var service = _fixture.GetService();

        // Act
        var rendimento = service.CalcularRendimentoBruto(valorInicial, prazoMeses);

        // Assert
        rendimento.Should().Be(rendimentoEsperado, "deve retornar o rendimento bruto esperado");
    }

    [Theory(DisplayName = "Calcular rendimento líquido com valor inicial inválido deve retornar erro")]
    [Trait("Category", "Domain Services - Unit Tests")]
    [InlineData(0)]
    [InlineData(-1)]
    public void CalcularRendimentoLiquido_ValorInicialInvalido_DeveRetornarErro(decimal valorInicial)
    {
        // Arrange
        var service = _fixture.GetService();

        // Act
        var func = () => service.CalcularRendimentoLiquido(1, valorInicial, 12);

        // Assert
        func.Should()
            .Throw<DomainException>("o valor inicial deve ser um número positivo")
            .WithMessage(ErrorMessage.ValorInicialInvalido);
    }

    [Theory(DisplayName = "Calcular rendimento líquido com prazo inválido deve retornar erro")]
    [Trait("Category", "Domain Services - Unit Tests")]
    [InlineData(0)]
    [InlineData(-1)]
    public void CalcularRendimentoLiquido_PrazoInvalido_DeveRetornarErro(int prazoMeses)
    {
        // Arrange
        var service = _fixture.GetService();

        // Act
        var func = () => service.CalcularRendimentoLiquido(500, 1000, prazoMeses);

        // Assert
        func.Should()
            .Throw<DomainException>("o prazo deve ser maior que 1 mês")
            .WithMessage(ErrorMessage.PrazoMezesInvalido);
    }

    [Theory(DisplayName = "Calcular rendimento líquido com rendimento bruto inválido deve retornar erro")]
    [Trait("Category", "Domain Services - Unit Tests")]
    [InlineData(0)]
    [InlineData(-1)]
    public void CalcularRendimentoLiquido_RendimentoBrutoInvalido_DeveRetornarErro(decimal rendimentoBruto)
    {
        // Arrange
        var service = _fixture.GetService();

        // Act
        var func = () => service.CalcularRendimentoLiquido(rendimentoBruto, 1000, 12);

        // Assert
        func.Should()
            .Throw<DomainException>("o rendimento bruto deve ser maior do que 0")
            .WithMessage(ErrorMessage.RendimentoBrutoInvalido);
    }

    [Theory(DisplayName = "Calcular rendimento bruto com com valores válidos deve retornar o valor correto")]
    [Trait("Category", "Domain Services - Unit Tests")]
    [InlineData(10597.56, 10000, 6, 10463.11)]
    [InlineData(16846.23, 15000, 12, 16476.98)]
    [InlineData(23803.85, 20000, 18, 23138.18)]
    [InlineData(31532.83, 25000, 24, 30389.58)]
    [InlineData(40100.52, 30000, 30, 38585.44)]
    public void CalcularRendimentoLiquido_ValoresValidos_DeveRetornarRendimentoLiquido(decimal rendimentoBruto,
        decimal valorInicial,
        int prazoMeses,
        decimal rendimentoEsperado)
    {
        // Arrange
        var service = _fixture.GetService();

        // Act
        var rendimento = service.CalcularRendimentoLiquido(rendimentoBruto, valorInicial, prazoMeses);

        // Assert
        rendimento.Should().Be(rendimentoEsperado, "deve retornar o rendimento líquido esperado");
    }
}