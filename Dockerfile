# Use the official image as a parent image.
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build-env

# Set the working directory.
WORKDIR /app

# Copy csproj and restore as distinct layers.
COPY *.csproj ./
RUN dotnet restore

# Copy everything else and build.
COPY . ./
RUN dotnet publish -c Release -o /app/out

# Build runtime image.
FROM mcr.microsoft.com/dotnet/aspnet:6.0
WORKDIR /app
COPY --from=build-env /app/out .

# Make port 80 available to the world outside this container.
EXPOSE 80

# Define environment variable.
ENV ASPNETCORE_URLS=http://+:80

# Run the app.
ENTRYPOINT ["dotnet", "case_study.dll"]
