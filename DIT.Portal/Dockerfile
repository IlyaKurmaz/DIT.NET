FROM mcr.microsoft.com/dotnet/core/aspnet:3.0-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.0-buster AS build
WORKDIR /src
COPY ["DIT.Portal.csproj", ""]
RUN dotnet restore "./DIT.Portal.csproj"
COPY . .
WORKDIR "/src/."
RUN dotnet build "DIT.Portal.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "DIT.Portal.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "DIT.Portal.dll"]