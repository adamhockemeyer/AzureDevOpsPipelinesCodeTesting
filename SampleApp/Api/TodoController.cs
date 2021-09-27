
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

public class TodoController : Controller
{

    [HttpGet]
    [Route("api/Todo")]
    public async Task<ActionResult<List<string>>> Get()
    {
        List<string> results = new List<string>();
        Random rand = new Random();

        var count = rand.Next(5, 50);

        for (int i = 0; i < count; i++)
        {

            results.Add(i.ToString());
            await System.Threading.Tasks.Task.Delay(10);
        }

        return results;
    }
}