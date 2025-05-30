# Build da aplicação
FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /app

COPY *.csproj ./
RUN dotnet restore

COPY . ./
RUN dotnet publish -c Release -o out

# Runtime
FROM mcr.microsoft.com/dotnet/aspnet:7.0
WORKDIR /app
COPY --from=build /app/out .

# Expõe a porta da API
EXPOSE 80

# Roda as migrations antes de iniciar a aplicação
ENTRYPOINT ["dotnet", "LojaDoManoel.dll", "migrate"]

CMD ["dotnet", "LojaDoManoel.dll"]
