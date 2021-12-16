using System.Net;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace DemoApiTesting.DZPostReqresTests
{
    public class DZDemoApiTesting
    {
        private const string Host = "https://reqres.in";
        private const string Api = "/api/users";

        [Test]
        public async Task CheckPostReqresTesting()
        {
            var baseAddress = Host + Api;
            var client = new HttpClient();
            var strBody = "{\"name\": \"mortheus\", \"job\": \"leader\"}";
            var contentBody = new StringContent(strBody, Encoding.UTF8, "application/json");
            var response = await client.PostAsync(baseAddress, contentBody);

            var statusCode = response.StatusCode;
           Assert.AreEqual(HttpStatusCode.Created, statusCode, $"Ответ от api {Api} не соответствует ожидаемому");
        }
       [Test]
        public async Task CheckPostReqresByJsonTesting()
        {
            var baseAddress = Host + Api;
            var client = new HttpClient();
            var request = new ReqresRequest()
            {
                Name = "mortheus",
                Job = "leader"
            };

            var response = await client.PostAsJsonAsync(baseAddress, request);

            var statusCode = response.StatusCode;
            Assert.AreEqual(HttpStatusCode.Created, statusCode, $"Ответ от api {Api} не соответствует ожидаемому");
        }
    }
}