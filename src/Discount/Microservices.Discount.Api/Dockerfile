FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
COPY ["src/Discount/Microservices.Discount.Api/Microservices.Discount.Api.csproj", "Discount/Microservices.Discount.Api/"]
COPY ["src/Discount/Microservices.Discount.Domain/Microservices.Discount.Domain.csproj", "Discount/Microservices.Discount.Domain/"]
COPY ["src/Discount/Microservices.Discount.Data/Microservices.Discount.Data.csproj", "Discount/Microservices.Discount.Data/"]
COPY ["src/Microservices.Settings/Microservices.Settings.csproj", "Microservices.Settings/"]
COPY ./src .
RUN dotnet restore "Discount/Microservices.Discount.Api/Microservices.Discount.Api.csproj"
RUN dotnet build "Discount/Microservices.Discount.Api/Microservices.Discount.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Discount/Microservices.Discount.Api/Microservices.Discount.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Microservices.Discount.Api.dll"]
