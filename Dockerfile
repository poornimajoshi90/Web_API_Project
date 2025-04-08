FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build-env
WORKDIR /app

COPY ./E-com/*.csproj ./E-com/
RUN dotnet restore ./E-com/EcomAPI.csproj

COPY . ./
RUN dotnet publish ./E-com/EcomAPI.csproj -c Release -o out

FROM mcr.microsoft.com/dotnet/aspnet:6.0
WORKDIR /app
COPY --from=build-env /app/out .

EXPOSE 80
ENTRYPOINT ["dotnet", "EcomAPI.dll"]


