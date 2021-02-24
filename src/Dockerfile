
FROM mcr.microsoft.com/dotnet/sdk:3.1 AS build
WORKDIR /src
COPY service.csproj .
RUN dotnet restore service.csproj
COPY . .
RUN dotnet build -c Release -o /app

FROM build AS publish
RUN dotnet publish -c Release -o /app

FROM mcr.microsoft.com/dotnet/aspnet:3.1 AS final
ARG DB_HOST
ARG DB_USER
ARG DB_PASSWORD
WORKDIR /app
COPY --from=publish /app .
ENV DB_HOST ${DB_HOST:-db}
ENV DB_USER ${DB_USER:-sa}
ENV DB_PASSWORD ${DB_PASSWORD:-P@ssw0rd}
EXPOSE 80
ENTRYPOINT ["dotnet", "service.dll"]