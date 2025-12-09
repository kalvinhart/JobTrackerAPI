FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["JobTrackerAPI/JobTrackerAPI.csproj", "JobTrackerAPI/"]
COPY ["JobTrackerAPI.DataAccess/JobTrackerAPI.DataAccess.csproj", "JobTrackerAPI.DataAccess/"]
COPY ["JobTrackerAPI.Business/JobTrackerAPI.Business.csproj", "JobTrackerAPI.Business/"]
RUN dotnet restore "JobTrackerAPI/JobTrackerAPI.csproj"
COPY . .
WORKDIR "/src/JobTrackerAPI"
RUN dotnet build "JobTrackerAPI.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "JobTrackerAPI.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "JobTrackerAPI.dll"]
