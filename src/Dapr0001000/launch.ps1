# launch Dapr
dapr run --app-id "hello-world" --app-port "5000" --dapr-grpc-port "50010" --dapr-http-port "5010" -- dotnet run --project ./Dapr0001000.csproj --urls="http://+:5000"
