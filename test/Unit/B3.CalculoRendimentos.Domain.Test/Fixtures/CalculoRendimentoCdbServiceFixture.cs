using B3.CalculoRendimentos.Domain.Services;
using Moq.AutoMock;

namespace B3.CalculoRendimentos.Domain.Test.Fixtures;

public class CalculoRendimentoCdbServiceFixture : IDisposable
{
    public void Dispose()
    {
    }

    public ICalculoRendimentoService GetService()
    {
        var mocker = new AutoMocker();
        return mocker.CreateInstance<CalculoRendimentoCdbService>();
    }
}