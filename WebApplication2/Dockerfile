FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build-env

WORKDIR /app

EXPOSE 8000

COPY *.csproj ./
RUN dotnet restore

COPY . ./
RUN dotnet publish -c Release -o out

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS buil-env
WORKDIR /app
COPY --from=build-env /app/out .

ENTRYPOINT ["dotnet", "WebApplication2.dll"]
