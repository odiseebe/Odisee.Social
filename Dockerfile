# Build stage
FROM microsoft/aspnetcore-build:2.0 as build
WORKDIR /src

#   Copy only .csproj and restore
COPY ./Odisee.Social.Entities/Odisee.Social.Entities.csproj ./Odisee.Social.Entities/
RUN dotnet restore ./Odisee.Social.Entities/

COPY ./Odisee.Social.DAL/Odisee.Social.DAL.csproj ./Odisee.Social.DAL/
RUN dotnet restore ./Odisee.Social.DAL/

COPY ./Odisee.Social.Api/Odisee.Social.Api.csproj ./Odisee.Social.Api/
RUN dotnet restore ./Odisee.Social.Api/

#   Copy everything else and build
COPY ./Odisee.Social.Entities/ ./Odisee.Social.Entities/
RUN dotnet build ./Odisee.Social.Entities/

COPY ./Odisee.Social.DAL/ ./Odisee.Social.DAL/
RUN dotnet build ./Odisee.Social.DAL/

COPY ./Odisee.Social.Api/ ./Odisee.Social.Api/
RUN dotnet build ./Odisee.Social.Api/

#   publish
RUN dotnet publish ./Odisee.Social.Api/ -o /publish --configuration Release

# Publish Stage
FROM microsoft/aspnetcore:2.0
WORKDIR /app
COPY --from=build /publish .
ENTRYPOINT ["dotnet", "Odisee.Social.Api.dll"]