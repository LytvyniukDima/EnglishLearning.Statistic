FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build
ARG NUGET_PASS

COPY . /app
WORKDIR /app/src/EnglishLearning.Statistic.Host
RUN dotnet nuget update source github -u LytvyniukDima -p $NUGET_PASS --store-password-in-clear-text
RUN dotnet publish -c Release -o /app/output

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1 AS runtime
COPY --from=build /app/output /app/host
WORKDIR /app/host

ENV ASPNETCORE_ENVIRONMENT=Docker
ENV ASPNETCORE_URLS="http://*:8700"

ENTRYPOINT ["dotnet", "EnglishLearning.Statistic.Host.dll"]
