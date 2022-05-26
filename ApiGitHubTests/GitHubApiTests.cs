using System.Collections.Generic;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;
using NUnit.Framework;
using RestSharp;

namespace ApiGitHubTests
{
    public class GitHubApiTests
    {
        private RestClient client;
        private RestRequest request;
        private RestResponse response;
        [SetUp]
        public async Task Setup()
        {
            this.client = new RestClient("https://api.github.com");
            request = new RestRequest("/repos/trifonjordanov/phoneshop/issues");
            response = await client.ExecuteAsync(request);
        }

        [Test]
        public void ValidateAPI_ReturnCorrectlyStatusCode()
        {
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
        }

        [Test]
        public void ValidateAPI_ReturnCorrectlyAllIssuesTitle()
        {
            var issues = JsonSerializer.Deserialize<List<Issue>>(response.Content);

            foreach (var issue in issues)
            {
                Assert.IsNotNull(issue.title);
            }
        }

        [Test]
        public void ValidateAPI_ReturnCorrectlyAllIssuesId()
        {
            var issues = JsonSerializer.Deserialize<List<Issue>>(response.Content);

            foreach (var issue in issues)
            {
                Assert.IsNotNull(issue.id);
            }
        }

        [Test]
        public void ValidateAPI_ReturnCorrectlyAllIssuesNumber()
        {
            var issues = JsonSerializer.Deserialize<List<Issue>>(response.Content);

            foreach (var issue in issues)
            {
                Assert.IsNotNull(issue.number);
            }
        }

        [Test]
        public void ValidateAPI_ReturnCorrectlyAllIssuesUrl()
        {
            var issues = JsonSerializer.Deserialize<List<Issue>>(response.Content);

            foreach (var issue in issues)
            {
                Assert.IsNotNull(issue.url);
            }
        }

        [Test]
        public void ValidateAPI_ReturnCorrectlyFirstIssue()
        {
            var issues = JsonSerializer.Deserialize<List<Issue>>(response.Content);
            var actual = issues[^1].title;
            string expectedTitle = "First Issue";
            Assert.AreEqual(expectedTitle, actual);
        }

        [Test]
        public void ValidateAPI_ReturnCorrectlyLastIssue()
        {
            var issues = JsonSerializer.Deserialize<List<Issue>>(response.Content);
            var actual = issues[0].title;
            string expectedTitle = "Issue 2";
            Assert.AreEqual(expectedTitle, actual);
        }
    }
}