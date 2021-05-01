# Tyle.Nft Server example

This is an example for [Tyle.Nft](https://www.nuget.org/packages/Tyle.Nft/) NuGet package .Net Core.

## Summary

Tyle.Nft is simply a library to work with nft and real-time database.
In this example I built a grpc service to communicate with the client and rotate a cube.
The rotation is stored in a nft , the token uri redirects to the api interfacing with rethinkdb.

## Usage

### Start Tyle.Nft
First install the NuGet package.
Then create a client to Tyle and connect to the db (you have to have rethinkdb up and running):  
```c#
var Tyle = new Client();
Tyle.DbConnect("localhost");
```
Now you can start Web3 :
```c#
Tyle.StartWeb3("Your api key (i.e. infuria)", "your wallet secret");
### Deploy the contract
```
If you do not have a contract you can deploy it :
```c#
var address = Tyle.DeployContract().Result;
### Mint the nft
```
Now that you have a smart contract you can mint all the nft you want , like this :
```c#
var modelUri = Tyle.ss.StoreModel("c:/Users/Pc/Desktop/cube.fbx");
var token = new nft_token()
        {
            name = "Cube",
            description = "An awesome cube!",
            volume = 123.456f,
            model = modelUri,
            rotation = new nft_token.quaternion { x = 0, y = 0, z = 0, w = 0 }
        };

Tyle.Mint(address, token,"http://localhost:5000").Wait();
#### Web api controller
```
In this case I store also the model of the cube in ipfs (you have to run it locally)
The apihost of the Mint function is the url to the api , you can make the controller 
in your web api like this :
```c#
using Tyle.Nft.Api;
namespace MyService
{
    [ApiController]
    [Route("api/")]
    public class Token1Controller : TokenController
    {


    }
}
```
At this point you can have your grpc service up and running and call all the procedures remotely , like rotating the cube for example.
If you don't want to have real-time data you can omit the db and use the StoreJson method to save the token data off-chain (still with ipfs).

Also if you want to serialize/deserialize data you can call ToByteArray and FromByteArray from Tyle.Nft.Byte (Note that not all the objects are serializable).
