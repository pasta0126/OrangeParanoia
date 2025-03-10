FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copy the project files (adjust paths as needed)
COPY ["project/OrangeParanoia/src/OrangeParanoia.Api/OrangeParanoia.Api.csproj", "OrangeParanoia.Api/"]
COPY ["project/OrangeParanoia/src/OrangeParanoia.Services/OrangeParanoia.Services.csproj", "OrangeParanoia.Services/"]

# Restore dependencies for the API project
RUN dotnet restore "OrangeParanoia.Api/OrangeParanoia.Api.csproj"

# Copy the rest of the source code
COPY project/OrangeParanoia/src/ .

WORKDIR "/src/OrangeParanoia.Api"
RUN dotnet publish "OrangeParanoia.Api.csproj" -c Release -o /app/publish

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "OrangeParanoia.Api.dll"]
