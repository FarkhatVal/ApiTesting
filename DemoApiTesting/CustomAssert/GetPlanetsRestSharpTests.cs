using System.Reflection;
using Microsoft.VisualStudio.TestPlatform.CommunicationUtilities;
using Newtonsoft.Json.Linq;
using NUnit.Framework;
using RestSharp;

namespace DemoApiTesting.CustomAssert
{
    public class GetPlanetTests
    {
        private const string Host = "https://swapi.dev/api";
        private const string Api = "/planets";
        
        [Test]
        [TestCase(1)]
        [TestCase(2)]
        
        public void CheckGetPlanetsByPgeTesting(int page)
        {
            var client = new RestClient(Host);
            var request = new RestRequest(Api, Method.GET);
            request.AddParameter("page", page);
            var response = client.Execute(request);
            var result = JObject.Parse(response.Content);
            
            Assert.AreEqual("60", result["count"]?.ToString(), "Количество планет не соответствует ожидаемому");
            
        }
    }
}