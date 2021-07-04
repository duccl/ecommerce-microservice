FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
COPY ["src/Basket/Microservices.Basket.Api/Microservices.Basket.Api.csproj", "Basket/Microservices.Basket.Api/"]
COPY ["src/Basket/Microservices.Basket.Domain/Microservices.Basket.Domain.csproj", "Basket/Microservices.Basket.Domain/"]
COPY ["src/Microservices.Settings/Microservices.Settings.csproj", "Microservices.Settings/"]
COPY ./src .
RUN dotnet restore "Basket/Microservices.Basket.Api/Microservices.Basket.Api.csproj"
RUN dotnet build "Basket/Microservices.Basket.Api/Microservices.Basket.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Basket/Microservices.Basket.Api/Microservices.Basket.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Microservices.Basket.Api.dll"]
