FROM mcr.microsoft.com/dotnet/runtime:7.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["TCB.Aplication/TCB.Aplication.csproj", "TCB.Aplication/"]
RUN dotnet restore "TCB.Aplication/TCB.Aplication.csproj"
COPY . .
WORKDIR "/src/TCB.Aplication"
RUN dotnet build "TCB.Aplication.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "TCB.Aplication.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "TCB.Aplication.dll"]
