FROM microsoft/dotnet:2.1-aspnetcore-runtime
WORKDIR /app2
COPY artifacts ./

ENTRYPOINT ["dotnet", "UltimateTicTacToe.Api.dll"]

# Make port 80 available to the world outside this container
EXPOSE 80
