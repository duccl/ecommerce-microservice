FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
COPY ["src/Catalog/Microservices.Catalog.Api/Microservices.Catalog.Api.csproj", "Catalog/Microservices.Catalog.Api/"]
COPY ["src/Catalog/Microservices.Catalog.Data/Microservices.Catalog.Data.csproj", "Catalog/Microservices.Catalog.Data/"]
COPY ["src/Catalog/Microservices.Catalog.Domain/Microservices.Catalog.Domain.csproj", "Catalog/Microservices.Catalog.Domain/"]
COPY ["src/Microservices.Settings/Microservices.Settings.csproj", "Microservices.Settings/"]
COPY ./src .
RUN dotnet restore "Catalog/Microservices.Catalog.Api/Microservices.Catalog.Api.csproj"
RUN dotnet build "Catalog/Microservices.Catalog.Api/Microservices.Catalog.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Catalog/Microservices.Catalog.Api/Microservices.Catalog.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Microservices.Catalog.Api.dll"]