FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src

COPY server_qirao/server_qirao.csproj server_qirao/
RUN dotnet restore server_qirao/server_qirao.csproj

COPY server_qirao/ server_qirao/
RUN dotnet publish server_qirao/server_qirao.csproj -c Release -o /app/publish

FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS runtime
WORKDIR /app
COPY --from=build /app/publish .

EXPOSE 8080
ENV ASPNETCORE_URLS=http://+:8080

ENTRYPOINT ["dotnet", "server_qirao.dll"]
