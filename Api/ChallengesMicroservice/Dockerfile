FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["ChallengesMicroservice/ChallengesMicroservice.csproj", "ChallengesMicroservice/"]
RUN dotnet restore "ChallengesMicroservice/ChallengesMicroservice.csproj"
COPY . .
WORKDIR "/src/ChallengesMicroservice"
RUN dotnet build "ChallengesMicroservice.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ChallengesMicroservice.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ChallengesMicroservice.dll"]
