FROM mcr.microsoft.com/dotnet/core/sdk:3.1-alpine AS builder
WORKDIR /source
COPY . .
RUN dotnet publish Akka_1_4.csproj -c Release --output /app/

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-alpine
WORKDIR /app
COPY --from=builder /app .

ENTRYPOINT ["dotnet", "Akka_1_4.dll"]