#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
COPY ["src/ApiGatways/Shopping.Aggregator/", "ApiGatways/Shopping.Aggregator/"]
RUN dotnet restore "ApiGatways/Shopping.Aggregator/Shopping.Aggregator.csproj"
RUN dotnet build "ApiGatways/Shopping.Aggregator/Shopping.Aggregator.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ApiGatways/Shopping.Aggregator/Shopping.Aggregator.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Shopping.Aggregator.dll"]