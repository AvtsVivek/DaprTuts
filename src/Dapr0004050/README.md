# Hello World

cd into node folder.

then do npm install.

Ensure docker deskop is started

Initialize dapr. 

dapr init

Now run the following command from the node folder

cd node

dapr run --app-id nodeapp --app-port 3000 --dapr-http-port 3500 node app.js

To see the list of running apps

dapr list

Run the following command to start the dashboard

dapr dashboard -p 9999

This will make the dasboard available on http://localhost:9999/.

Ensure, you are in the directory where the sample.json file is present and run the following command

dapr invoke --app-id nodeapp --method neworder --data-file sample.json

The order is persisted. Verify that using the following get request

dapr invoke --app-id nodeapp --method order --verb GET

Now cd into python folder

cd ..

cd ./python

Install dependencies

pip3 install requests

# dapr run --app-id pythonapp python3 app.py

It should be python and not python3

dapr run --app-id pythonapp python app.py

Observe the output. In one of the powershell you should see 'Got a new order.

Finally run the followng command few times.

dapr invoke --app-id nodeapp --method order --verb GET

To stop the apps

dapr stop --app-id nodeapp
dapr stop --app-id pythonapp

To see the list of running apps

dapr list

https://github.com/dapr/quickstarts/tree/v1.5.0/hello-world

dapr uninstall

dapr uninstall --all
