using System.Threading.Tasks;
using NetTestFramework.Services;
using NLog;
using NUnit.Framework;
using RestSharp;
using RestSharp.Authenticators;
using Logger = NLog.Logger;

namespace NetTestFramework.Tests.Api;

public class SimpleApiTest
{
    private readonly Logger _logger = LogManager.GetCurrentClassLogger();  
    
    [Test]
    public async Task GetProjectsTest()
    {
        var client = new RestClient(Configurator.AppSettings.BaseUrl);
        client.Authenticator = new HttpBasicAuthenticator(Configurator.Admin.Username, Configurator.Admin.Password);

        var request = new RestRequest("https://api.github.com/repositories", Method.Get);
        var response = await client.GetAsync(request);
        _logger.Info(response.StatusCode);
        _logger.Info(response.Content);
    }
}