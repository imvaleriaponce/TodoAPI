FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base

WORKDIR /app

EXPOSE 7180

ENV ASPNETCORE_URLS=http://+:7180

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build

ARG BUILD_CONFIGURATION=Release

WORKDIR /src

COPY ["WebApplication_ejemplobd/WebApplication_ejemplobd.csproj", "WebApplication_ejemplobd/"]

RUN dotnet restore "WebApplication_ejemplobd/WebApplication_ejemplobd.csproj"

COPY . .

WORKDIR "/src/WebApplication_ejemplobd"

RUN dotnet publish "WebApplication_ejemplobd.csproj" \
    -c $BUILD_CONFIGURATION \
    -o /app/publish \
    /p:UseAppHost=false

FROM base AS final

WORKDIR /app

COPY --from=build /app/publish .

ENTRYPOINT ["dotnet", "WebApplication_ejemplobd.dll"]