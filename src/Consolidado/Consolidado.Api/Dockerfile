FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copia tudo (solution inteira)
COPY . .

# Restaura usando o caminho CORRETO
RUN dotnet restore Consolidado/Consolidado.Api/Consolidado.Api.csproj

# Build
RUN dotnet publish Consolidado/Consolidado.Api/Consolidado.Api.csproj \
    -c Release \
    -o /app/publish \
    --no-restore

# Runtime
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build /app/publish .

EXPOSE 8080
ENTRYPOINT ["dotnet", "Consolidado.Api.dll"]
