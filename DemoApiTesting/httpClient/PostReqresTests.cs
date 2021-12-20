using System.Net;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using DemoApiTesting.CustomAssert;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using NUnit.Framework;
using RestSharp;

namespace DemoApiTesting.PostReqresTests
{
    public class PostReqresTesting:TestBase

    {
    private const string Host = "https://reqres.in";
    private const string Api = "/api/users";
    private static string userName = "mortheus";
    private static string userJob = "leader";
    
    ReqresRequest user = new ReqresRequest()
    {
        Name = userName,
        Job = userJob
    };
    
    [Test]
    public async Task CheckPostReqresByStatusCodeTesting()
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
    public async Task CheckPostReqresByStatusCodeByJsonTesting()
    {
        var baseAddress = Host + Api;
        var client = new HttpClient();
        var request = user;
        var response = await client.PostAsJsonAsync(baseAddress, request);

        var statusCode = response.StatusCode;
        Assert.AreEqual(HttpStatusCode.Created, statusCode, $"Ответ от api {Api} не соответствует ожидаемому");
        }
    
    [Test]
    public void CheckPostReqresByRestSharpTesting()
    {
        var client = new RestClient(Host);
        var request = new RestRequest(Api, Method.POST);
        request.AddJsonBody(user);
        
        var response = client.Execute(request);
        var result = JsonConvert.DeserializeObject<ReqresRequest>(response.Content);
        CustomAssertAreEqual(userName, result.Name, $" Name, ожидалось {userName}, а получено {result.Name}" );
        CustomAssertAreEqual(userJob, result.Job, $" Job, ожидалось {userJob}, а получено {result.Job}");
        CustomAssertIsNotEmpty(result.Id, $" Id, ожидалось наличие Id, а получено {result.Id}");
        CustomAssertIsNotEmpty(result.CreatedAt, $" CreatedAt, ожидалось наличие CreatedAt, а получено {result.CreatedAt}");
        }
    }
}