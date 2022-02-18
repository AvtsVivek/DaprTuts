# Introduction 

Dapr Example

## Dpr0001000
This is taken from 
https://github.com/PacktPublishing/Practical-Microservices-with-Dapr-and-.NET/tree/main/chapter01

This is a simple web app.
Run the following commands from folder containing csproj file

1. dotnet restore
2. dotnet build
3. dotnet run

To access the app

1. http://localhost:5000/hello

Now to daparise it do the following code changes.
1. Ensure docker is running
2. do **dapr init**
3. Run the powershell **launch.ps1** or the following command

```sh
dapr run --app-id "hello-world" --app-port "5000" --dapr-grpc-port "50010" --dapr-http-port "5010" -- dotnet run --project ./Dapr0001000.csproj --urls="http://+:5000"
```

Now to access the app

1. http://localhost:5000/hello
2. http://localhost:5010/v1.0/invoke/hello-world/method/hello

To send those reqwuets, use can use the start.http file.

With the dapr command that we just ran, all that we are doing is ask dapr to run our app.
Then dapr will provide us with an end point that looks as follows.
http://localhost:5010/v1.0/invoke/hello-world/method/hello


For this example, we dont need to do any changes to our app. 
