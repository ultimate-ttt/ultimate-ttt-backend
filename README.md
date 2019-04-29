# Ultimate TicTacToe Backend

[![contributions welcome](https://img.shields.io/badge/contributions-welcome-brightgreen.svg?style=flat)](https://github.com/ultimate-ttt/ultimate-ttt-backend/issues)
[![Build Status](https://dev.azure.com/ultimate-ttt/ultimate-ttt/_apis/build/status/ultimate-ttt-Build-master?branchName=master)](https://dev.azure.com/ultimate-ttt/ultimate-ttt/_build/latest?definitionId=4&branchName=master)
[![Quality Gate Status](https://sonarcloud.io/api/project_badges/measure?project=ultimate-ttt-backend&metric=alert_status)](https://sonarcloud.io/dashboard?id=ultimate-ttt-backend)
[![Coverage](https://sonarcloud.io/api/project_badges/measure?project=ultimate-ttt-backend&metric=coverage)](https://sonarcloud.io/dashboard?id=ultimate-ttt-backend)
[![GitHub release](https://img.shields.io/github/release/ultimate-ttt/ultimate-ttt-backend.svg)](https://github.com/ultimate-ttt/ultimate-ttt-backend/releases)
[![Docker Pulls](https://img.shields.io/docker/pulls/ultimatettt/ultimate-ttt-server.svg)](https://hub.docker.com/r/ultimatettt/ultimate-ttt-server)

# Public API
TODO Visit [#10](https://github.com/ultimate-ttt/ultimate-ttt-backend/issues/10) to see Progress

# Running the Api on your system

## Using the latest release of the Docker image

To use the latest release for local testing run the following steps. dotnet doesn't need to be installed on your local computer.

**Prerequisites**
- Docker is installed & running

**Setup**

1. Open command-line and navigate to the root of the repository
2. run `docker-compose up`
3. Access the API from your browser [http://localhost:5023/playground](http://localhost:5023/playground)

## Localy Build and Test
If you have done some work on the code you probably want to check if your changes break the build or the tests. This can be done locally.

**Prerequisites**
- dotnet core 2.1 SDK installed. (for specific version see [global.json](./global.json))

### Using the Cake Tool

This solution works on all operation system on which you can run dotnet core.

**Prerequisites**
  
  - Cake Tool installed(min. Version 0.33.0). To install run `dotnet tool install -g Cake.Tool`

**Build and Test the Api**

1. Open command-line and navigate to the root of the repository
2. run `dotnet cake build.cake`

Now the entire solution is built and the tests are executed.

### Using Windows Powershell on Windows
  
This solution does not require Cake.Tool to be installed on your system. Sadly it only works on Windows.

**Build and Test the Api**

1. Open command-line and navigate to the root of the repository
2. run `.\build.ps1`

Now the entire solution is built and the tests are executed.

### Running the Api on your local system

1. Open command-line and navigate to the root of the repository
2. Open `/src/Api/appsettings.json` and verify that `Database:ConnectionString` has a valid Connectionstring for a MongoDB according to your system setup
3. run `cd ./src/Api; dotnet watch run`

### Creating an new Image Version

After you finished developing you probably want to check if the changes behave correctly in the container environment. Therefore you can build the docker image locally.

1. Open command-line and navigate to the root of the repository
2. run `.\build.ps1 -target "PublishApi"` with Powershell or `dotnet cake --target=PublishApi` using the cake tool. This build the Api in Release Mode
3. run `docker build -t ultimatettt/ultimate-ttt-server:localtesting`. this creates a local image of the previously built api.
4. run `docker-compose -f "docker-compose-localtesting.yml" up`. This starts the local testing image.

# Examples

## Create a new game

```graphql
mutation CreateNewGame{
   createGame{
    id
  }
}
```

## Make a Move

```graphql
mutation Move{
  move(
    input: {
      gameId: "abcdef"
      boardPosition: {x: 0, y:0}
      tilePosition: {x: 0, y:0}
      player:CROSS
    }
  ){
    isValid
  }
}
```

## Get game status

```graphql
query GameStatus{
  game(id: "abcdef"){
    id
    moves{
      moveNumber
      boardPosition{
        x
        y
      }
      tilePosition{
        x
        y
      }
      player
    }
    winner
  }
}
```

## Live updates

Subscriptions are not implemented yet. Visit [#5](https://github.com/ultimate-ttt/ultimate-ttt-backend/issues/5) for more information.
