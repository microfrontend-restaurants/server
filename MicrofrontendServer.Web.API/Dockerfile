#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["MicrofrontendServer.Web.API/MicrofrontendServer.Web.API.csproj", "MicrofrontendServer.Web.API/"]
COPY ["MicrofrontendServer.Services/MicrofrontendServer.Services.csproj", "MicrofrontendServer.Services/"]
COPY ["MicrofrontendServer.DAL/MicrofrontendServer.DAL.csproj", "MicrofrontendServer.DAL/"]
COPY ["MicrofrontendServier.Resources/MicrofrontendServier.Resources.csproj", "MicrofrontendServier.Resources/"]
COPY ["MicrofrontendServer.Domain/MicrofrontendServer.Domain.csproj", "MicrofrontendServer.Domain/"]
RUN dotnet restore "MicrofrontendServer.Web.API/MicrofrontendServer.Web.API.csproj"
COPY . .
WORKDIR "/src/MicrofrontendServer.Web.API"
RUN dotnet build "MicrofrontendServer.Web.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "MicrofrontendServer.Web.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "MicrofrontendServer.Web.API.dll"]