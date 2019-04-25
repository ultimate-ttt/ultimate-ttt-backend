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
- Docker is installed

**Setup**

1. Open command-line and navigate to the root of the repository
2. run `docker-compose up`
3. Access the API from your browser [http://localhost:5023/playground](http://localhost:5023/playground)

## Work on the code

If you work on the code you probably want to run the Api and check if your changes work as expected.

**Prerequisites**
- dotnet core 2.1 SDK installed
  
**Build and Test the Api**

1. Open command-line and navigate to the root of the repository
2. run `build .ps1` on a windows system or `build.sh` on linux

Now the entire solution is built and the tests are executed.

**Run the Api**

1. Open command-line and navigate to the root of the repository
2. Open `/src/Api/appsettings.json` and verify that `Database:ConnectionString` has a valid Connectionstring for a MongoDB according to your system setup
3. run `cd ./src/Api; dotnet watch run`

**Creating an new Image Version**

After you finished developing you probably want to check if the changes behave correctly in the container environment. Therefore you can build the docker image locally.

1. Open command-line and navigate to the root of the repository
2. run `build.ps1 -target "PublishApi"` on a Windows system or `build.sh -target=PublishApi` on Linux. This build the Api in Release Mode
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
