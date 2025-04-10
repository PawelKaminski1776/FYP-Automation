# Stage 1: Build the application and tests
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build

# Set the working directory
WORKDIR /app

# Copy the project files
COPY FYP-Automation.Process.sln ./  
COPY FYP-Automation/*.csproj ./FYP-Automation/

# Restore dependencies (via NuGet)
RUN dotnet restore

# Copy the rest of the application
COPY . ./

# Build the project
RUN dotnet build --configuration Release

# Run the tests
RUN dotnet test --configuration Release

# Stage 2: Optional
# FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
# WORKDIR /app
# COPY --from=build /app ./
# ENTRYPOINT ["dotnet", "FYP-Automation.dll"]
