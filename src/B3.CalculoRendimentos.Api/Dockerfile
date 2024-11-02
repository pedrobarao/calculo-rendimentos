FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["src/B3.CalculoRendimentos.Api/B3.CalculoRendimentos.Api.csproj", "src/B3.CalculoRendimentos.Api/"]
COPY ["src/B3.CalculoRendimentos.Domain/B3.CalculoRendimentos.Domain.csproj", "src/B3.CalculoRendimentos.Domain/"]
RUN dotnet restore "src/B3.CalculoRendimentos.Api/B3.CalculoRendimentos.Api.csproj"
COPY . .
WORKDIR "/src/src/B3.CalculoRendimentos.Api"
RUN dotnet build "B3.CalculoRendimentos.Api.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "B3.CalculoRendimentos.Api.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "B3.CalculoRendimentos.Api.dll"]
