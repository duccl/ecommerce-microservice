
FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
COPY ["src/ApiGatways/OcelotApiGatway", "ApiGatways/OcelotApiGatway/"]
RUN dotnet restore "ApiGatways/OcelotApiGatway/OcelotApiGatway.csproj"
RUN dotnet build "ApiGatways/OcelotApiGatway/OcelotApiGatway.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ApiGatways/OcelotApiGatway/OcelotApiGatway.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "OcelotApiGatway.dll"]