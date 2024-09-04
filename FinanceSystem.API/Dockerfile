# Dockerfile para FinanceSystem.API
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app

# Copie o arquivo .sln e os arquivos .csproj
COPY *.sln ./
COPY FinanceSystem.API/*.csproj FinanceSystem.API/
COPY FinanceSystem.Core/*.csproj FinanceSystem.Core/
COPY FinanceSystem.Data/*.csproj FinanceSystem.Data/
COPY FinanceSystem.WebApp/*.csproj FinanceSystem.WebApp/

# Restaura as dependências
RUN dotnet restore

# Copie todo o código-fonte e compile
COPY . ./
WORKDIR /app/FinanceSystem.API
RUN dotnet publish -c Release -o out

# Imagem de produção
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app
COPY --from=build /app/FinanceSystem.API/out ./
ENTRYPOINT ["dotnet", "FinanceSystem.API.dll"]
