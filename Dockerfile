FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copia os arquivos .csproj e restaura as dependências
COPY ["Fina.Api/Api.csproj", "Api/"]
COPY ["Fina.Core/Core.csproj", "Core/"]
RUN dotnet restore "Api/Api.csproj"

# Copia todo o código-fonte e compila a aplicação
COPY . .
WORKDIR "/src/Api"
RUN dotnet build "Api.csproj" -c Release -o /app/build

# Publica a aplicação
RUN dotnet publish "Api.csproj" -c Release -o /app/publish

# Estágio 2: Runtime da aplicação
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app

# Copia apenas os arquivos publicados do estágio de build
COPY --from=build /app/publish .

# Define o comando de entrada para rodar a aplicação
ENTRYPOINT ["dotnet", "Api.dll"]