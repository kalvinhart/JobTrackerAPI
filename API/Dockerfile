# --------------------
# Runtime base
# --------------------
FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS base
WORKDIR /app

# --------------------
# Build stage
# --------------------
FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src

# Copy solution and project files first (for layer caching)
COPY *.sln .

COPY API/API.csproj API/
COPY Application/Application.csproj Application/
COPY Domain/Domain.csproj Domain/
COPY Infrastructure/Infrastructure.csproj Infrastructure/

# Restore dependencies
RUN dotnet restore

# Copy the remaining source code
COPY . .

# Build API (this builds all referenced projects)
WORKDIR /src/API
RUN dotnet build API.csproj \
    -c $BUILD_CONFIGURATION \
    -o /app/build

# --------------------
# Publish stage
# --------------------
FROM build AS publish
ARG BUILD_CONFIGURATION=Release

RUN dotnet publish API.csproj \
    -c $BUILD_CONFIGURATION \
    -o /app/publish \
    /p:UseAppHost=false

# --------------------
# Final runtime image
# --------------------
FROM base AS final
WORKDIR /app

COPY --from=publish /app/publish .

EXPOSE 8080
ENTRYPOINT ["dotnet", "API.dll"]