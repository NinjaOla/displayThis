#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Vanir.Website/Vanir.Website.csproj", "Vanir.Website/"]
RUN dotnet restore "Vanir.Website/Vanir.Website.csproj"
COPY . .
WORKDIR "/src/Vanir.Website"
RUN dotnet build "Vanir.Website.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Vanir.Website.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Vanir.Website.dll"]