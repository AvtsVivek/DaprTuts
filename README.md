# Introduction 

This repo has step by step tuts for dapr from various sources

>For [Dapr Dashboard](https://docs.dapr.io/reference/cli/dapr-dashboard/)

Open new command prompt and type
```sh
dapr dashboard -p 9999
```

Now browse to the following for dashboard

http://localhost:9999/overview



>Launching [Vs Code Dapr Extension](https://docs.dapr.io/developing-applications/ides/vscode/vscode-dapr-extension/)

1. [Install the extension](https://marketplace.visualstudio.com/items?itemName=ms-azuretools.vscode-dapr)

2. ![Dapr Extension for Visual Studio Code](src/images/VsCodeDaprExtension.jpg "Dapr Extension for Visual Studio Code").

>The dapr end point in general is as follows

```sh
http://localhost:<port-no>/v1.0/invoke/<app-id>/method/<method-name>
```

> Use [VS Code Rest Client](https://marketplace.visualstudio.com/items?itemName=humao.rest-client) for sending requests.

> To uninstall dapr
```sh
dapr --uninstall --all
```