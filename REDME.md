# KlirTechChallenge

## Getting Started

To run the project on your machine you will need [Docker](https://www.docker.com/)

To run the app in development mode use:

```sh
docker-compose -f .docker/docker-compose-dev.yml build --no-cache

docker-compose -f .docker/docker-compose-dev.yml up
```

To run the app in production mode use:

```sh
docker-compose -f .docker/docker-compose.yml build --no-cache

docker-compose -f .docker/docker-compose.yml up
```

Open your browser on [http://localhost:80](http://localhost:3000)

To run the *Unit Tests* use:

```sh
  npm run test
```

To run *End to end Tests* use:

```sh
  npm run test:e2e
```