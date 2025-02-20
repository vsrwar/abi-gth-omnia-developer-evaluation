# Ambev Developer Evaluation Web API

This repository contains the source code for the Ambev Developer Evaluation Web API, built with C# and ASP.NET Core. The API can be run in three different ways: locally, using Docker Compose, or directly from a Docker container.

![.NET Core CI](https://github.com/vsrwar/abi-gth-omnia-developer-evaluation/actions/workflows/tests.yml/badge.svg)

## Prerequisites

Before running the application, ensure you have the following installed:

- **Option 1 (Local Execution)**: [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
- **Option 2 & 3 (Docker Execution)**: [Docker](https://www.docker.com/get-started)

## Running the API

### 1. Running Locally

To run the API locally, follow these steps:

1. Clone the repository:
   ```sh
   ~ git clone https://github.com/vsrwar/abi-gth-omnia-developer-evaluation.git
   ```
2. Configure the database connection strings in `appsettings.json`.
3. Run the application using an IDE such as Visual Studio **or** using the .NET CLI:
   ```sh
   ~ cd abi-gth-omnia-developer-evaluation/template/backend/src/Ambev.DeveloperEvaluation.WebApi
   ~ dotnet run
   ```

### 2. Running with Docker Compose

To run the API using Docker Compose:

1. Clone the repository:
   ```sh
   ~ git clone https://github.com/vsrwar/abi-gth-omnia-developer-evaluation.git
   ```
2. Copy the `.env.example` file and rename it to `.env`:
3. Configure the `.env` file with your database connection details.
4. Start the containers:
   ```sh
   ~ cd abi-gth-omnia-developer-evaluation/template/backend
   ~ docker compose up -d
   ```

### 3. Running Directly from Docker Hub

You can pull and run the pre-built Docker image directly from Docker Hub:

```sh
   docker container run -d -it -p <host-port>:8080 \
   -e ASPNETCORE_ENVIRONMENT=Development \
   -e ASPNETCORE_HTTP_PORTS=8080 \
   -e POSTGRES_CONNECTION_STRING=<postgres-connection> \
   -e MONGO_CONNECTION_STRING=<mongodb-connection> \
   --name ambev_developer_evaluation_webapi \
   vsrwar/ambevdeveloperevaluationwebapi:1.1
```

Replace `<host-port>`, `<postgres-connection>`, and `<mongodb-connection>` with appropriate values.

## API Endpoints

For details on available API endpoints and how to interact with the service, after runing the application, checkout **localhost:8080/swagger** endpoint.

## License

This project is licensed under the [MIT License](LICENSE).

## Contact

For any questions or support, reach out via email [rochavini@outlook.com](mailto\:rochavini@outlook.com)
