using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;
using ApiGitHubTests;
using RestSharp;

namespace TestConsoleApp
{
    class Program
    {
        static async Task Main(string[] args)
        {
            RestClient client = new RestClient("https://api.github.com");
            var request = new RestRequest("/repos/trifonjordanov/phoneshop/issues");
            var response = await client.ExecuteAsync(request);

            var issues = JsonSerializer.Deserialize<List<Issue>>(response.Content);

            Console.WriteLine(string.Join("***********",response.Content));
        }
    }
}
