# Stage 1: Build the application and tests
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build

# Set the working directory
WORKDIR /app

# Install Google Chrome
RUN apt-get update && apt-get install -y wget gnupg2 && \
    wget https://dl.google.com/linux/direct/google-chrome-stable_current_amd64.deb && \
    apt-get install -y ./google-chrome-stable_current_amd64.deb && \
    rm google-chrome-stable_current_amd64.deb

# Copy the project files
COPY FYP-Automation.sln ./  
COPY FYP-Automation/*.csproj ./FYP-Automation/

# Restore dependencies (via NuGet)
RUN dotnet restore

# Copy the rest of the application
COPY . ./

# Build the project
RUN dotnet build --configuration Release

# Run the tests
RUN dotnet test --filter "FullyQualifiedName=FYPAutomation.End_To_End_Tests.FullApplicationTest" --configuration Release

