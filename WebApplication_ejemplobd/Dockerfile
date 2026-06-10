# Imagen base para runtime
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 7180
ENV ASPNETCORE_URLS=http://+:7180

# Imagen para build
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copiamos todo el proyecto
COPY . .

# Restauramos dependencias
RUN dotnet restore "WebApplication_ejemplobd.csproj"

# Publicamos en modo Release
RUN dotnet publish "WebApplication_ejemplobd.csproj" -c Release -o /app/publish /p:UseAppHost=false

# Imagen final
FROM base AS final
WORKDIR /app
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "WebApplication_ejemplobd.dll"]
