# https://hub.docker.com/_/microsoft-dotnet-core
FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build
WORKDIR /source

# copy csproj and restore as distinct layers
COPY *.sln .
COPY AspNetTest/*.csproj ./AspNetTest/
RUN dotnet restore -r linux-arm

# copy everything else and build app
COPY AspNetTest/. ./AspNetTest/
WORKDIR /source/AspNetTest
RUN dotnet publish -c release -o /app -r linux-arm --self-contained false --no-restore

# final stage/image
FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim-arm32v7
WORKDIR /app
COPY --from=build /app ./
ENTRYPOINT ["./AspNetTest"]
