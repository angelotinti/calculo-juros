#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0-buster-slim AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:5.0-buster-slim AS build
WORKDIR /src
COPY ["/CalculaJuros.Domain/CalculaJuros.Domain.csproj", "./CalculaJuros.Domain"]
COPY ["/CalculaJuros.App/CalculaJuros.App.csproj", "./CalculaJuros.App"]

RUN dotnet restore "/src/CalculaJuros.Domain"
RUN dotnet restore "/src/CalculaJuros.App"

COPY . .

WORKDIR "/src/CalculaJuros.Domain"
RUN dotnet build -c Release -o /app

WORKDIR "/src/CalculaJuros.App"
RUN dotnet build -c Release -o /app

FROM build AS publish
RUN dotnet publish -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "CalculaJuros.App.dll"]