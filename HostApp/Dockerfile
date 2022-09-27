FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["HostApp/HostApp.csproj", "HostApp/"]
RUN dotnet restore "HostApp/HostApp.csproj"
COPY . .
WORKDIR "/src/HostApp"
RUN dotnet build "HostApp.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "HostApp.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "HostApp.dll"]