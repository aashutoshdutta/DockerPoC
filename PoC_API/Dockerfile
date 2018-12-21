#Depending on the operating system of the host machines(s) that will build or run the containers, the image specified in the FROM statement may need to be changed.
#For more information, please see https://aka.ms/containercompat

FROM microsoft/dotnet:2.1-aspnetcore-runtime-nanoserver-sac2016 AS base
WORKDIR /app
EXPOSE 64900
EXPOSE 44376

FROM microsoft/dotnet:2.1-sdk-nanoserver-sac2016 AS build
WORKDIR /PoC_API
COPY ["/PoC_API.csproj", "PoC_API/"]
RUN dotnet restore "PoC_API/PoC_API.csproj"
COPY . .
WORKDIR "/PoC_API"
RUN dotnet build "PoC_API.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "PoC_API.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "PoC_API.dll"]