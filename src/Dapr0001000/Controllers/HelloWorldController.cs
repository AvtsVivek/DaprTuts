using Microsoft.AspNetCore.Mvc;
using System;

namespace Dapr0001000.Controllers
{
  [ApiController]
  public class HelloWorldController : ControllerBase
  {
    [HttpGet("hello")]
    public ActionResult<string> Get()
    {
      Console.WriteLine("Hello, World.");
      return "Hello, World";
    }
  }
}