using System;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;
using NUnit.Framework;

namespace DemoApiTesting.httpClient
{
    public class GetPlanetsTests
    {

        private const string Host = "https://swapi.dev/api";
        private const string Api = "/planets";
        private PlanetsResponse planetsResponse;
        
        [OneTimeSetUp]
        public async Task Setup()
        {
            var baseAddress = new Uri(Host + Api);
            var client = new HttpClient() { BaseAddress = baseAddress } ;
            var response = await client.GetAsync(baseAddress, new CancellationToken());
            
            var stringResponse = await response.Content.ReadAsStringAsync();
            if (response.StatusCode != HttpStatusCode.OK)
            {
                Assert.Fail($"{Api} отработала некорректно, дальнейшие проверки бессмысленны!");
            }
            planetsResponse = JsonConvert.DeserializeObject<PlanetsResponse>(stringResponse);
        }

        [Test]
        public void CheckCountFromPlanetsApiTesting()
        {
            Assert.AreEqual(60, planetsResponse.Count, "Количество планет не совпадает");
        }
        
        [Test]
        public void CheckResponseIsNotEmptyFromPlanetsApiTesting()
        {
            Assert.IsNotNull(planetsResponse, "Ответ от api вернул пустое значение");
        }
        
        [Test]
        public void CheckResultsIsNotEmptyFromPlanetsApiTesting()
        {
            Assert.IsNotNull(planetsResponse.Result, "Поле result в ответе от api вернуло пустое значение");
        }
        
        [Test]
        public void CheckNameFromPlanetsApiTesting()
        {
            Assert.AreEqual("Hoth", planetsResponse.Result[3].Name, "Поле name в ответе от api не соответствует ожидаемому");
        }
    }
}