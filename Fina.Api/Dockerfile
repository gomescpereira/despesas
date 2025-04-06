FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app
COPY . /app

# Copia os arquivos .csproj e restaura as dependências
#COPY ["Fina.Api/Fina.Api.csproj", "Api/"]
#COPY ["Fina.Core/Fina.Core.csproj", "Core/"]



#WORKDIR "./Fina.Core"


WORKDIR "./Fina.Api"
RUN dotnet restore "Fina.Api.csproj"
RUN dotnet build "Fina.Api.csproj" -c Release -o /app/build

# Publica a aplicação
RUN dotnet publish "Fina.Api.csproj" -c Release -o /app/publish


# Estágio 2: Runtime da aplicação
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app

#ENV ASPNETCORE_URLS http://*:5250
EXPOSE 8080

# Copia apenas os arquivos publicados do estágio de build
COPY --from=build /app/publish .

# Define o comando de entrada para rodar a aplicação
ENTRYPOINT ["dotnet", "Fina.Api.dll"]
