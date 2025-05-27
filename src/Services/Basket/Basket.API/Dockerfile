#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

# build the base runtime image
FROM mcr.microsoft.com/dotnet/aspnet:9.0-alpine AS base
USER app
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

# copy csproj and restore as distinct layers
FROM mcr.microsoft.com/dotnet/sdk:9.0-alpine AS build
RUN apk add --no-cache libc6-compat 
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["src/Services/Basket/Basket.API/Basket.API.csproj", "Services/Basket/Basket.API/"]
COPY ["src/BuildingBlocks/BuildingBlocks/BuildingBlocks.csproj", "BuildingBlocks/BuildingBlocks/"]
RUN dotnet restore "./Services/Basket/Basket.API/./Basket.API.csproj"

# copy app dependencies and build app
COPY src/Services/Basket/Basket.API/. ./Services/Basket/Basket.API/
COPY src/BuildingBlocks/BuildingBlocks/. ./BuildingBlocks/BuildingBlocks/
WORKDIR "/src/Services/Basket/Basket.API"
RUN dotnet build "./Basket.API.csproj" -c $BUILD_CONFIGURATION -o /app/build

# publish image
FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./Basket.API.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

# final stage/image
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Basket.API.dll"]