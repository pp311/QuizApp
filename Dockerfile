FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 5000
EXPOSE 5001

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["QuizApp.csproj", "./"]
RUN dotnet restore "QuizApp.csproj"
COPY . .
WORKDIR "/src/"
RUN dotnet build "QuizApp.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "QuizApp.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "QuizApp.dll"]
