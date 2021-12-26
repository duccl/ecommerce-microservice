#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/runtime:6.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["src/Ordering/Microservices.Ordering.Consumer/Microservices.Ordering.Consumer.csproj", "Ordering/Microservices.Ordering.Consumer/"]
COPY ["src/Ordering/Microservices.Ordering.Application/Microservices.Ordering.Application.csproj", "Ordering/Microservices.Ordering.Application/"]
COPY ["src/Ordering/Microservices.Ordering.Domain/Microservices.Ordering.Domain.csproj", "Ordering/Microservices.Ordering.Domain/"]
COPY ["src/Ordering/Microservices.Ordering.Infraestructure/Microservices.Ordering.Infraestructure.csproj", "Ordering/Microservices.Ordering.Infraestructure/"]
COPY ["src/BuildingBlocks/Microservices.EventBus.Messages/Microservices.EventBus.Messages.csproj", "Microservices.EventBus.Messages/"]
COPY ./src .
RUN dotnet restore "Ordering/Microservices.Ordering.Consumer/Microservices.Ordering.Consumer.csproj"
RUN dotnet build "Ordering/Microservices.Ordering.Consumer/Microservices.Ordering.Consumer.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Ordering/Microservices.Ordering.Consumer/Microservices.Ordering.Consumer.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Microservices.Ordering.Consumer.dll"]