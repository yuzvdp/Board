FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
COPY . .
WORKDIR src/Hosts/Board.Hosts.Api
RUN dotnet restore
RUN dotnet publish -c $BUILD_CONFIGURATION -o out

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app
COPY --from=build /src/Hosts/Board.Hosts.Api/out ./
ENTRYPOINT ["dotnet", "Board.Hosts.Api.dll"]