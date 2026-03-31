# 1. Change SDK from 8.0 to 9.0
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src

# Copy and restore
COPY ["Backend-Noted.csproj", "./"]
RUN dotnet restore "Backend-Noted.csproj"

# Build and publish
COPY . .
RUN dotnet publish "Backend-Noted.csproj" -c Release -o /app/publish

# 2. Change Runtime from 8.0 to 9.0
FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS final
WORKDIR /app
COPY --from=build /app/publish .

# Port binding for Render
ENV PORT=8080
EXPOSE 8080

ENTRYPOINT ["dotnet", "Backend-Noted.dll"]