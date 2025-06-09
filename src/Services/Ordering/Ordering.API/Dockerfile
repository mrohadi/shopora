#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

# build the base runtime image
FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base
USER root
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

# copy csproj and restore as distinct layers
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["src/Services/Ordering/Ordering.API/Ordering.API.csproj", "Services/Ordering/Ordering.API/"]
COPY ["src/Services/Ordering/Ordering.Application/Ordering.Application.csproj", "Services/Ordering/Ordering.Application/"]
COPY ["src/BuildingBlocks/BuildingBlocks.Messaging/BuildingBlocks.Messaging.csproj", "BuildingBlocks/BuildingBlocks.Messaging/"]
COPY ["src/BuildingBlocks/BuildingBlocks/BuildingBlocks.csproj", "BuildingBlocks/BuildingBlocks/"]
COPY ["src/Services/Ordering/Ordering.Domain/Ordering.Domain.csproj", "Services/Ordering/Ordering.Domain/"]
COPY ["src/Services/Ordering/Ordering.Infrastructure/Ordering.Infrastructure.csproj", "Services/Ordering/Ordering.Infrastructure/"]
RUN dotnet restore "./Services/Ordering/Ordering.API/./Ordering.API.csproj"

# copy app dependencies and build app
COPY src/Services/Ordering/Ordering.API/. ./Services/Ordering/Ordering.API/
COPY src/Services/Ordering/Ordering.Application/. Services/Ordering/Ordering.Application/
COPY src/Services/Ordering/Ordering.Domain/. Services/Ordering/Ordering.Domain/
COPY src/Services/Ordering/Ordering.Infrastructure/. Services/Ordering/Ordering.Infrastructure/
COPY src/BuildingBlocks/BuildingBlocks/. ./BuildingBlocks/BuildingBlocks/
COPY src/BuildingBlocks/BuildingBlocks.Messaging/. BuildingBlocks/BuildingBlocks.Messaging/
WORKDIR "/src/Services/Ordering/Ordering.API"
RUN dotnet build "./Ordering.API.csproj" -c $BUILD_CONFIGURATION -o /app/build

# publish image
FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./Ordering.API.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

# final stage/image
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Ordering.API.dll"]