#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["src/Core/Becoming.Core.Storage/Becoming.Core.Storage.Service/Becoming.Core.Storage.Service.csproj", "src/Core/Becoming.Core.Storage/Becoming.Core.Storage.Service/"]
RUN dotnet restore "./src/Core/Becoming.Core.Storage/Becoming.Core.Storage.Service/Becoming.Core.Storage.Service.csproj"
COPY . .
WORKDIR "/src/src/Core/Becoming.Core.Storage/Becoming.Core.Storage.Service"
RUN dotnet build "./Becoming.Core.Storage.Service.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./Becoming.Core.Storage.Service.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Becoming.Core.Storage.Service.dll"]