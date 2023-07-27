## Этап сборки
#FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
#WORKDIR /app
#
#COPY MeetingApplication.csproj ./
#RUN dotnet restore
#
#COPY . ./
#RUN dotnet publish -c Release -o out
#
#