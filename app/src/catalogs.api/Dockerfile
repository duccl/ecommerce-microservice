FROM mcr.microsoft.com/dotnet/aspnet:5.0 as final
WORKDIR /app

COPY ./bin/Release/net5.0/publish/ catalogs.api/
COPY entrypoint.sh .
ENTRYPOINT ["/app/entrypoint.sh"]