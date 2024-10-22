# Use the official ASP.NET Core runtime image as the base
FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80

# Use the official .NET SDK image for building the app
FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src

# Copy everything to the container
COPY . .

# Restore the dependencies
RUN dotnet restore

# Build the app
RUN dotnet publish -c Release -o /app/publish

# Use the ASP.NET Core runtime to run the app
FROM base AS final
WORKDIR /app
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "ChatAPI.dll"]
