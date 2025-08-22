FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["src/Services/AppointmentService/AppointmentService.csproj", "src/Services/AppointmentService/"]
COPY ["src/Shared/Models/Models.csproj", "src/Shared/Models/"]
RUN dotnet restore "src/Services/AppointmentService/AppointmentService.csproj"
COPY . .
WORKDIR "/src/src/Services/AppointmentService"
RUN dotnet build "AppointmentService.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "AppointmentService.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "AppointmentService.dll"]