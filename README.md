# Cálculo de Rendimentos 💹

Esta é uma aplicação simples que calcula o rendimento de um CDB baseado em um valor inicial e um prazo informado pelo usuário.

## Executando o serviço ✔️

Para rodar o serviço no seu ambiente local você pode utilizar o Docker ou diretamente da sua IDE de preferência.

### Requisitos 🔴

- .NET 8 - Para rodar na IDE de sua preferência.
- Docker - Para rodar a aplicação em um container.

### Passo a passo 👣

### IDE 🪛



### Docker 🐳

Certifique-se de que o Docker esteja rodando em sua máquina. Na raiz do projeto, abra um terminal e siga os passos abaixo.

1 - Faça o build da imagem Docker:

```bash
docker build --no-cache -t api_calculo_rendimentos -f ./src/B3.CalculoRendimentos.Api/Dockerfile .
```

2 - Execute o container:

```bash
docker run -d -p 8080:8080 --name api_calculo_rendimentos api_calculo_rendimentos
```

Se tudo correr bem você poderá acessar a aplicação em `http://localhost:8080/swagger`.

## Testes 🧪
Os testes são executados automaticamente no pipeline de CI/CD a cada integração com a branch principal `(main)`.

### Back-end
Para executar os testes no seu ambiente local, basta executar o seguinte comando na raiz do projeto:

```bash
dotnet test
```

### Front-end TODO
Para executar os testes no seu ambiente local, basta executar o seguinte comando na raiz do projeto:

```bash
jest
```

### Cobertura de Testes

A cobertura de testes foi realizada utilizando **Coverlet** e **Report Generator** para uma exibição dos resultados.
Você pode acessar o relatório de cobertura de testes no [GitHub Pages](https://pedrobarao.github.io/fiap.5nett.contatos/) do projeto. 

Se preferir, você pode gerar o relatório de cobertura de testes executando localmente o seguinte comando na raiz do projeto:

```bash
dotnet test --collect:"XPlat Code Coverage" --results-directory ./test/results/coverlet/ && reportgenerator -reports:test/results/coverlet/**/coverage.cobertura.xml -targetdir:test/results/coverage-report -reporttypes:Html
```
