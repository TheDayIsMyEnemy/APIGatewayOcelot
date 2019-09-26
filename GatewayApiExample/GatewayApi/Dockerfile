FROM mcr.microsoft.com/dotnet/core/sdk:2.2 AS build
EXPOSE 80
WORKDIR /app

COPY ./GatewayApi/. ./GatewayApi
WORKDIR /app/GatewayApi
RUN dotnet publish -c Release -o out

FROM mcr.microsoft.com/dotnet/core/aspnet:2.2
WORKDIR /app/GatewayApi
COPY --from=build /app/GatewayApi/out ./
ENTRYPOINT ["dotnet", "GatewayApi.dll"]



