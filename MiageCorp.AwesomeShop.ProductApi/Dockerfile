#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["MiageCorp.AwesomeShop.ProductApi/MiageCorp.AwesomeShop.ProductApi.csproj", "MiageCorp.AwesomeShop.ProductApi/"]
RUN dotnet restore "./MiageCorp.AwesomeShop.ProductApi/MiageCorp.AwesomeShop.ProductApi.csproj"
COPY . .
WORKDIR "/src/MiageCorp.AwesomeShop.ProductApi"
RUN dotnet build "./MiageCorp.AwesomeShop.ProductApi.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./MiageCorp.AwesomeShop.ProductApi.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "MiageCorp.AwesomeShop.ProductApi.dll"]