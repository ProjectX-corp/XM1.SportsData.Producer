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
        private readonly ILogger<SecretsManager> _logger;


        public SecretsManager(IConfiguration configuration, IAmazonSecretsManager secretsManager, ILogger<SecretsManager> logger)
        {
            _configuration = configuration;
            _secretsManager = secretsManager;
            _logger = logger;
        }

        public T GetSecret<T>(string nomeDoSegredo)
        {
            try
            {
                _logger.LogInformation($"Tentando recuperar o segredo: {nomeDoSegredo}");

                var requisicao = new GetSecretValueRequest { SecretId = nomeDoSegredo };
                var resposta = _secretsManager.GetSecretValueAsync(requisicao).Result;

                if (string.IsNullOrEmpty(resposta.SecretString))
                {
                    _logger.LogWarning($"O segredo {nomeDoSegredo} está vazio");
                    throw new InvalidOperationException($"O segredo {nomeDoSegredo} está vazio");
                }

                _logger.LogInformation($"Segredo {nomeDoSegredo} recuperado com sucesso");

                return DeserializarSegredo<T>(resposta.SecretString, nomeDoSegredo);
            }
            catch (AmazonSecretsManagerException ex)
            {
                _logger.LogError(ex, $"Erro ao acessar o AWS Secrets Manager para o segredo {nomeDoSegredo}");
                throw new InvalidOperationException($"Erro ao acessar o segredo {nomeDoSegredo}", ex);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Erro inesperado ao recuperar o segredo {nomeDoSegredo}");
                throw new InvalidOperationException($"Erro inesperado ao recuperar o segredo {nomeDoSegredo}", ex);
            }
        }

        private T DeserializarSegredo<T>(string conteudoDoSegredo, string nomeDoSegredo)
        {
            if (typeof(T) == typeof(string))
            {
                return (T)(object)conteudoDoSegredo;
            }

            try
            {
                return JsonConvert.DeserializeObject<T>(conteudoDoSegredo);
            }
            catch (System.Text.Json.JsonException ex)
            {
                _logger.LogError(ex, $"Erro ao desserializar o segredo {nomeDoSegredo}");
                throw new InvalidOperationException($"Erro ao desserializar o segredo {nomeDoSegredo}", ex);
            }
        }
    }
}