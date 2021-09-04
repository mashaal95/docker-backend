# syntax=docker/dockerfile:1
FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build-env
WORKDIR /backend

# Copy csproj and restore as distinct layers
COPY *.csproj ./
RUN dotnet restore

# Copy everything else and build
COPY ./*.cs ./
COPY ./appsettings.json ./
COPY ./Controllers ./
COPY ./Migrations ./
RUN dotnet publish -c Release -f net5.0 -o pub

# Build runtime image
FROM mcr.microsoft.com/dotnet/aspnet:5.0
WORKDIR /backend
COPY --from=build-env /backend/pub .
EXPOSE 8000
ENV ASPNETCORE_URLS=http://localhost:8000
ENTRYPOINT ["dotnet", "Backend-KubesProject-DotNet.dll"]
