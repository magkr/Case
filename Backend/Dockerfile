# Use the official ASP.NET Core runtime as a base image
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80

# Copy the published output of your ASP.NET Core app into the container
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app

# Copy the .csproj and restore as distinct layers
COPY Backend/*.csproj .
RUN dotnet restore

# Copy everything else and build the application
COPY ./Backend .
RUN dotnet publish -c Release -o /app -p:PublishWithAspNetCoreTargetManifest=false -p:OutputType=Exe

# Build runtime image
FROM base AS final
WORKDIR /app
COPY --from=build /app .
ENTRYPOINT ["dotnet", "backend.dll"]