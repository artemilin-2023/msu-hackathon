FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
EXPOSE 8080
WORKDIR /App
COPY . /App

RUN dotnet restore && dotnet publish -c Release -o out --no-restore

FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /App
COPY --from=build App/out .

ENTRYPOINT [ "dotnet", "./WorkShare.API.dll"]