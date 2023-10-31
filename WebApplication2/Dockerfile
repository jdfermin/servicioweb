FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build-env
WORKDIR /app

COPY *.csproj ./
RUN dotnet restore

COPY . ./
#ENV HTTP_PROXY http://proxylab.ucab.edu.ve:3128
#ENV HTTPS_PROXY http://proxylab.ucab.edu.ve:3128
RUN dotnet publish -c Release -o out

FROM mcr.microsoft.com/dotnet/aspnet:7.0
WORKDIR /app
EXPOSE 8000
COPY --from=build-env /app/out .
ENTRYPOINT ["dotnet", "WebApplication2.dll"]
