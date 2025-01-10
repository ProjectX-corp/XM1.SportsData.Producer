using Amazon;
using Amazon.SecretsManager;
using Amazon.SecretsManager.Model;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System.Text.Json;
using XM1.SportsData.Producer.Application.Interface;

namespace XM1.SportsData.Producer.API.Configuration
{
    public class SecretsManager : ISecretsManager
    {
        private readonly IAmazonSecretsManager _secretsManager;
        private readonly IConfiguration _configuration;

        public SecretsManager(IConfiguration configuration)
        {
            _configuration = configuration;
            _secretsManager = new AmazonSecretsManagerClient(RegionEndpoint.USEast2);
        }

        public T GetSecret<T>(string secretName)
        {
            var response = _secretsManager.GetSecretValueAsync(new GetSecretValueRequest
            {
                SecretId = secretName
            }).GetAwaiter().GetResult();

            if (response.SecretString is null)
            {
                throw new Exception($"Secret {secretName} not found");
            }

            return JsonConvert.DeserializeObject<T>(response.SecretString);
        }

        public string GetConnectionString(string secretName)
        {
            var dbCredentials = GetSecret<String>(secretName);
            return dbCredentials;
        }
    }

    public class DbCredentials
    {
        public string Host { get; set; }
        public string Database { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
    }
}