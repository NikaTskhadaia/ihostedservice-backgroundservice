#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/runtime:6.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["BgSrvcDockerized/BgSrvcDockerized.csproj", "BgSrvcDockerized/"]
RUN dotnet restore "BgSrvcDockerized/BgSrvcDockerized.csproj"
COPY . .
WORKDIR "/src/BgSrvcDockerized"
RUN dotnet build "BgSrvcDockerized.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "BgSrvcDockerized.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "BgSrvcDockerized.dll"]