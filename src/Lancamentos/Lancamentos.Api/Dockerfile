FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copia tudo (solution inteira)
COPY . .

# Restaura usando o caminho CORRETO
RUN dotnet restore Lancamentos/Lancamentos.Api/Lancamentos.Api.csproj

# Build
RUN dotnet publish Lancamentos/Lancamentos.Api/Lancamentos.Api.csproj \
    -c Release \
    -o /app/publish \
    --no-restore

# Runtime
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build /app/publish .

EXPOSE 8080
ENTRYPOINT ["dotnet", "Lancamentos.Api.dll"]
