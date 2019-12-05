FROM mcr.microsoft.com/dotnet/core/aspnet:3.0-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.0-buster AS build
WORKDIR /src
COPY ["DIT.Portal2/DIT.Portal2.csproj", "DIT.Portal2/"]
RUN dotnet restore "DIT.Portal2/DIT.Portal2.csproj"
COPY . .
WORKDIR "/src/DIT.Portal2"
RUN dotnet build "DIT.Portal2.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "DIT.Portal2.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "DIT.Portal2.dll"]