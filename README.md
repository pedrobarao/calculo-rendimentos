# Cálculo de Rendimentos 💹

Esta é uma aplicação simples que calcula o rendimento de um CDB baseado em um valor inicial e um prazo informado pelo usuário.

## Executando o serviço ✔️

### Requisitos 🔴

- .NET 8
- Angular 17

### Back-end
Para rodar o serviço no seu ambiente local basta seguir os seguintes passos:

1 - Restaurar as dependências do projeto:

```bash
dotnet restore
```

2 - Fazer o build do projeto:

```bash
dotnet build --no-restore
```

3 - Executar o projeto:

```bash
dotnet run --project .\src\Services\B3.CalculoRendimentos.Api\B3.CalculoRendimentos.Api.csproj
```

4 - Verifique a porta na qual a aplicação está rodando e acesse o Swagger para testar a API:

![img.png](img.png)

No exemplo da imagem a seguir, a aplicação está rodando na porta `5240`. Neste caso, acesse o Swagger através do link `http://localhost:5240/swagger/index.html`.

### Front-end

Para rodar o front-end no seu ambiente local basta seguir os seguintes passos:

1 - No terminal, navegue até a pasta `./src/Web/B3.CalculoRendimentos.Web`.

2 - Altere a url base da API no arquivo `./src/Web/B3.CalculoRendimentos.Web/src/app/app.service` para a url da API que está rodando no seu ambiente local:

![img_2.png](img_2.png)

3 - Instale as dependências do projeto:

```bash
npm install
```

4 - Faça o build do projeto:

```bash
npm run build
```

5 - Rode o projeto:

```bash
npm run start
```

6 - Verifique a porta na qual a aplicação está rodando e acesse o endereço no navegador:

![img_1.png](img_1.png)

## Testes 🧪
Os testes são executados automaticamente no pipeline de CI/CD a cada integração com a branch principal `(main)`.

### Back-end
Para executar os testes no seu ambiente local, basta executar o seguinte comando na raiz do projeto:

```bash
dotnet test
```

### Front-end TODO
Para executar os testes no seu ambiente local, basta executar o seguinte comando na pasta `./src/Web/B3.CalculoRendimentos.Web`:

```bash
npm run test
```

### Cobertura de Testes

A cobertura de testes do backend foi realizada utilizando **Coverlet** e **Report Generator** para uma exibição dos resultados.
Você pode acessar o relatório de cobertura de testes no [GitHub Pages](https://pedrobarao.github.io/fiap.5nett.contatos/) do projeto. 

Se preferir, você pode gerar o relatório de cobertura de testes executando localmente o seguinte comando na raiz do projeto:

```bash
dotnet test --collect:"XPlat Code Coverage" --results-directory ./test/results/coverlet/ && reportgenerator -reports:test/results/coverlet/**/coverage.cobertura.xml -targetdir:test/results/coverage-report -reporttypes:Html
```
