> This is based on the following example.

https://github.com/dapr/samples/tree/master/hello-dapr-slim

# Slim mode. #

0. First read the [Readme.md file given here](https://github.com/dapr/samples/tree/master/hello-dapr-slim/README.md). 

1. dapr uninstall

2. dapr uninstall --all

3. dapr init --slim

4. npm install

5. dapr run --app-id nodeapp --app-port 3000 --dapr-http-port 3500 node app.js

6. Ensure the command prompt is powershell and run the following

7. dapr invoke --verb POST --app-id nodeapp --method neworder --data '{\"data\": { \"orderId\": \"41\" } }'

8. dapr stop --app-id nodeapp

# Slim mode using dapr extension. #

1. First read the [Readme.md file given here](https://github.com/dapr/samples/tree/master/hello-dapr-slim/README.md). 

2. Ensure you are in the right directory. Must be in package.json and app.js directory.

```sh
cd hello-dapr-slim
```

3. Open Vs code in that directory and then open a terminal.

```sh
code . -r 
```

4. Open command platte(Ctrl + Shift + P). Type dapr scafold task and add the launch configuration.

5. You can now debug that launch config. 

![Dapr Invoke App post](/hello-dapr-slim/DaprInvoke.jpg "Dapr Invoke App post").

```js
{"data": { "orderId": "41" } }
```

