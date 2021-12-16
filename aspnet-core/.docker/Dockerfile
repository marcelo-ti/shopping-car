FROM mcr.microsoft.com/dotnet/sdk:3.1 AS build-env

WORKDIR /usr/src/app
COPY ./Klir.TechChallenge.Web.Api .

RUN dotnet restore
RUN dotnet publish -c Release -o out

FROM mcr.microsoft.com/dotnet/aspnet:3.1
EXPOSE 5000
WORKDIR /usr/src/app

COPY --from=build-env /usr/src/app/out .
ENTRYPOINT ["dotnet", "Klir.TechChallenge.Web.Api.dll"]