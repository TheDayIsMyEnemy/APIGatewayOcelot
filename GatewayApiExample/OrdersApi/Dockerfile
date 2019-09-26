FROM mcr.microsoft.com/dotnet/core/sdk:2.2 AS build
EXPOSE 80
WORKDIR /app

COPY . .
RUN dotnet publish -c Release -o out

FROM mcr.microsoft.com/dotnet/core/aspnet:2.2
WORKDIR /app
COPY --from=build /app/out ./
ENTRYPOINT ["dotnet", "OrdersApi.dll"]



