using System;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;
using NUnit.Framework;

namespace DemoApiTesting
{
    public class GetReqresTests
    {
        private const string Host = "https://reqres.in";
            private const string Api = "/api/users";
            private ReqresResponse reqresResponse;
        
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
                reqresResponse = JsonConvert.DeserializeObject<ReqresResponse>(stringResponse);
            }

            [Test]
            public void CheckPer_pageFromReqresApiTesting()
            {
                Assert.AreEqual(6, reqresResponse.Per_page, "Количество персон не совпадает");
            }
        
            [Test]
            public void CheckResponseIsNotEmptyFromReqresApiTesting()
            {
                Assert.IsNotNull(reqresResponse, "Ответ от api вернул пустое значение");
            }
        
            [Test]
            public void CheckDataIsNotEmptyFromReqresApiTesting()
            {
                Assert.IsNotNull(reqresResponse.Data, "Поле data в ответе от api вернуло пустое значение");
            }
        
            [Test]
            public void CheckFirst_NameFromPersonsApiTesting()
            {
                Assert.AreEqual("Janet", reqresResponse.Data[1].First_name, "Поле name в ответе от api не соответствует ожидаемому");
            }
        }
    }