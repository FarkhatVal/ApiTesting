using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json.Schema;
using NUnit.Framework;

namespace DemoApiTesting.ContractTests
{
    public class GetPlanetsContractNegativeTests: ContractBase
    {
        private const string Host = "https://swapi.dev/api";
 
        [Test]
        [TestCase("one")]
        [TestCase("-1")]
        [TestCase("7")]
        [TestCase("")]
        [TestCase(" ")]
        [TestCase(".")]
        [TestCase(",")]
        [TestCase("'")]
        [TestCase(";")]
        [TestCase(":")]
        [TestCase("-")]
        [TestCase("=")]
        [TestCase("+")]
        [TestCase("!")]
        [TestCase("@")]
        [TestCase("#")]
        [TestCase("%")]
        [TestCase("^")]
        [TestCase("&")]
        [TestCase("*")]
        [TestCase("(")]
        [TestCase(")")]
        [TestCase("_")]
        [TestCase("`")]
        [TestCase("~")]
       
        public async Task  CheckContractGetPlanetNegativeOnPageNumberIncorrectNumberTesting(string page)
        {
            string Api = $"/planets/?page={page}";
            var client = new HttpClient() ;
            var response = await client.GetAsync(new Uri(Host + Api), new CancellationToken());
            
            JSchema schema = JSchema.Parse(GetFileAsString("getPlanets.Negative.json"));
            await CheckValidationResponseMessageBySchemaIncorrectPageAsync(response, schema);
        }
        
        [Test]
        [TestCase("one")]
        [TestCase("-1")]
        [TestCase("7")]
        [TestCase("")]
        [TestCase(" ")]
        [TestCase(".")]
        [TestCase(",")]
        [TestCase("'")]
        [TestCase(";")]
        [TestCase(":")]
        [TestCase("-")]
        [TestCase("=")]
        [TestCase("+")]
        [TestCase("!")]
        [TestCase("@")]
        [TestCase("#")]
        [TestCase("%")]
        [TestCase("^")]
        [TestCase("&")]
        [TestCase("*")]
        [TestCase("(")]
        [TestCase(")")]
        [TestCase("_")]
        [TestCase("`")]
        [TestCase("~")]
        
        public async Task  CheckContractGetPlanetNegativeOnPageNumberIncorrectNumberByStatusCodeTesting(string page)
        {
            string Api = $"/planets/?page={page}";
            var client = new HttpClient() ;
            var response = await client.GetAsync(new Uri(Host + Api), new CancellationToken());
            
            JSchema schema = JSchema.Parse(GetFileAsString("getPlanets.Negative.json"));
            await CheckValidationResponseMessageBySchemaIncorrectPageByStatusCodeAsync(response, schema); 
        }
        
    }
}