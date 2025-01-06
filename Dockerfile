# Stage 1: Build the application
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copy csproj and restore any dependencies (via nuget)
COPY ["alsagro.microservice.csproj", "./"]
RUN dotnet restore "./alsagro.microservice.csproj"

# Copy the entire source code
COPY . .
RUN dotnet build "alsagro.microservice.csproj" -c Release -o /app/build

# Publish the application (produce the final output)
FROM build AS publish
RUN dotnet publish "alsagro.microservice.csproj" -c Release -o /app/publish

# Stage 2: Configure the runtime environment
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

# Copy the build output into the final image
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .

# Entry point for the application
ENTRYPOINT ["dotnet", "alsagro.microservice.dll"]