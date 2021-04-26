#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["MainView/Telegram.csproj", "MainView/"]
COPY ["TelegramLib/TelegramLib.csproj", "TelegramLib/"]
RUN dotnet restore "MainView/Telegram.csproj"
COPY . .
WORKDIR "/src/MainView"
RUN dotnet build "Telegram.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Telegram.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Telegram.dll"]