FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["com.project.parcel/com.project.parcel.csproj", "com.project.parcel/"]
RUN dotnet restore "com.project.parcel/com.project.parcel.csproj"
COPY . .
WORKDIR "/src/com.project.parcel"
RUN dotnet build "com.project.parcel.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "com.project.parcel.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "com.project.parcel.dll"]
