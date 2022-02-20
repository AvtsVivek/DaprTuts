using Dapr.Client;

const string storeName = "statestore";
const string key = "counter";

Console.WriteLine("You need to run this app with dapr and not directly.");
Console.WriteLine("Do the following.");
Console.WriteLine("First start docker");
Console.WriteLine("Then initialize dapr with the following command");
Console.WriteLine("dapr init");
Console.WriteLine("Ensure state store is running as a docker container.");
Console.WriteLine("Once it is initialized, now run the following command.");
Console.WriteLine("This will ask dapr to run this app.");
Console.WriteLine("dapr run --app-id DaprCounter dotnet run");



var daprClient = new DaprClientBuilder().Build();

var daprSideCarIsHealthy = await daprClient.CheckHealthAsync();

if (!daprSideCarIsHealthy)
{
  Console.WriteLine("The dapr side care does not seem to be healthy. ");
  Console.WriteLine("Ensure docker is running.");
  Console.WriteLine("Then verify that dapr is running.");
  Console.WriteLine("Start dapr by running dapr init command. Then try again.");
  Console.WriteLine("Also you need to run this app with dapr and not directly.");
  Console.WriteLine("Do not execute this app directly.");
  Console.WriteLine("Exiting...");
  //return;
}


var counter = await daprClient.GetStateAsync<int>(storeName, key);


Console.WriteLine("Once the app is running, to view the state of the app, get into the container.");
Console.WriteLine("https://docs.dapr.io/getting-started/get-started-api/#step-4-see-how-the-state-is-stored-in-redis");
Console.WriteLine("docker exec -it dapr_redis redis-cli");
Console.WriteLine("Here redis-cli is the command name that you need to execute inside of the container.");
Console.WriteLine("Once you are the redis cli, type 'keys *' to see the keys.");
Console.WriteLine(@"hgetall ""DaprCounter || counter""");


while (true)
{
  Console.WriteLine($"Counter = {counter++}");

  daprSideCarIsHealthy = await daprClient.CheckHealthAsync();

  if(daprSideCarIsHealthy)
    Console.WriteLine("Dapr side car is healthy. !!!");
  else
  {
    Console.WriteLine("Alas, Alas, Dapr side car is NOT healthy !!");
    Console.WriteLine("I am not sure why the the state store is running fine when side car is not healthy ");
    Console.WriteLine("Need to find out.");
  }
  await daprClient.SaveStateAsync(storeName, key, counter);
  await Task.Delay(1000);
}
