
FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["src/Ordering/Microservices.Ordering.Api/Microservices.Ordering.Api.csproj", "Ordering/Microservices.Ordering.Api/"]
COPY ["src/Ordering/Microservices.Ordering.Application/Microservices.Ordering.Application.csproj", "Ordering/Microservices.Ordering.Application/"]
COPY ["src/Ordering/Microservices.Ordering.Domain/Microservices.Ordering.Domain.csproj", "Ordering/Microservices.Ordering.Domain/"]
COPY ["src/Ordering/Microservices.Ordering.Infraestructure/Microservices.Ordering.Infraestructure.csproj", "Ordering/Microservices.Ordering.Infraestructure/"]
COPY ./src .
RUN dotnet restore "Ordering/Microservices.Ordering.Api/Microservices.Ordering.Api.csproj"
RUN dotnet build "Ordering/Microservices.Ordering.Api/Microservices.Ordering.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Ordering/Microservices.Ordering.Api/Microservices.Ordering.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Microservices.Ordering.Api.dll"]