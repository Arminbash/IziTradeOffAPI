#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:3.1 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:3.1 AS build
WORKDIR /src
COPY ["IziTradeOff.API/IziTradeOff.API.csproj", "IziTradeOff.API/"]
COPY ["IziTradeOff.Application/IziTradeOff.Application.csproj", "IziTradeOff.Application/"]
COPY ["IziTradeOff.Domain/IziTradeOff.Domain.csproj", "IziTradeOff.Domain/"]
COPY ["IziTradeOff.Persistence/IziTradeOff.Persistence.csproj", "IziTradeOff.Persistence/"]
COPY ["IziTradeOff.Service/IziTradeOff.Service.csproj", "IziTradeOff.Service/"]
RUN dotnet restore "IziTradeOff.API/IziTradeOff.API.csproj"
COPY . .
WORKDIR "/src/IziTradeOff.API"
RUN dotnet build "IziTradeOff.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "IziTradeOff.API.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "IziTradeOff.API.dll"]