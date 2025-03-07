﻿FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src

RUN dotnet tool install --global dotnet-ef
ENV PATH=$PATH:/root/.dotnet/tools

COPY ["JewelryApp.csproj", "./"]
RUN dotnet restore "JewelryApp.csproj"

COPY . .
WORKDIR "/src/"
RUN dotnet ef database update
RUN dotnet build "JewelryApp.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "JewelryApp.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app

COPY --from=publish src/app.db .
COPY --from=publish /app/publish .

ENTRYPOINT ["dotnet", "JewelryApp.dll"]
