# ---------- Build Stage ----------
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

COPY . .
RUN dotnet restore
RUN dotnet publish -c Release -o /app/publish

# ---------- Runtime Stage ----------
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app

COPY --from=build /app/publish .

# IMPORTANT: use PORT from Render
ENV ASPNETCORE_URLS=http://+:${PORT}

ENTRYPOINT ["dotnet", "publish/Backend-Noted.dll"]