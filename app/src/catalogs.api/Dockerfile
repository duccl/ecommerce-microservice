FROM mcr.microsoft.com/dotnet/sdk:5.0 as base
WORKDIR /app
COPY . .
RUN dotnet publish . -c Release -o out

FROM mcr.microsoft.com/dotnet/aspnet:5.0 as final
WORKDIR /app

COPY --from=base /app/out .
CMD ["dotnet","/app/catalogs.api.dll"]