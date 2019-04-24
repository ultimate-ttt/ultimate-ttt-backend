# Ultimate TicTacToe Backend

[![contributions welcome](https://img.shields.io/badge/contributions-welcome-brightgreen.svg?style=flat)](https://github.com/ultimate-ttt/ultimate-ttt-backend/issues)
[![Build Status](https://dev.azure.com/ultimate-ttt/ultimate-ttt/_apis/build/status/ultimate-ttt-Build-master?branchName=master)](https://dev.azure.com/ultimate-ttt/ultimate-ttt/_build/latest?definitionId=4&branchName=master)
[![Quality Gate Status](https://sonarcloud.io/api/project_badges/measure?project=ultimate-ttt-backend&metric=alert_status)](https://sonarcloud.io/dashboard?id=ultimate-ttt-backend)
[![Coverage](https://sonarcloud.io/api/project_badges/measure?project=ultimate-ttt-backend&metric=coverage)](https://sonarcloud.io/dashboard?id=ultimate-ttt-backend)

# Public API
TODO Visit [#10](https://github.com/ultimate-ttt/ultimate-ttt-backend/issues/10) to see Progress

# Local Testing

## Using the latest release of the Docker image

To use the latest release for local testing run the following steps. dotnet doesn't need to be installed on your local computer.

**Prerequisites**
- Docker is installed

**Setup**

1. Open command-line and navigate to the root of the repository
2. run `docker-compose up`
3. Access the API from your browser [http://localhost:5003/playground](http://localhost:5003/playground)

## using the dotnet command-line tools

**Prerequisites**
- dotnet core 2.1 SDK installed
  
**Setup**

1. Open command-line and navigate to the root of the repository
2. Open `/src/Api/appsettings.json` and verify that `Database:ConnectionString` has a valid Connectionstring for a MongoDB according to your system setup
3. run `cd ./src/Api; dotnet watch run`

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
