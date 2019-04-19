FROM mcr.microsoft.com/dotnet/core/aspnet:2.1
WORKDIR /app2
COPY artifacts ./

ENTRYPOINT ["dotnet", "UltimateTicTacToe.Api.dll"]

# Make port 80 available to the world outside this container
EXPOSE 80
