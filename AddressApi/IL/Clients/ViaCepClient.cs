using System.Text.Json;
using AddressApi.IL.Clients.Interfaces;
using AddressApi.IL.Responses;
using Newtonsoft.Json;

namespace AddressApi.IL.Clients
{
    public class ViaCepClient : IViaCepClient
    {
        private readonly IHttpClientFactory _clientFactory;
        private readonly IConfiguration _configuration;

        public ViaCepClient(IHttpClientFactory clientFactory, IConfiguration configuration)
        {
            _clientFactory = clientFactory;
            _configuration = configuration;
        }

        public async Task<AddressResponse> GetAddressAsync(string postalCode)
        {
            var url = $"{_configuration.GetValue<string>("AddressApi:ViaCepUrl")}/ws/{postalCode}/json";
            var request = new HttpRequestMessage(HttpMethod.Get, url);

            var httpClient = _clientFactory.CreateClient();
            var response = await httpClient.SendAsync(request);

            if (!response.IsSuccessStatusCode)
                throw new Exception("Não foi possível consultar o endereço. Por favor, tente novamente mais tarde.");

            var content = await response.Content.ReadAsStringAsync();
            var address = JsonConvert.DeserializeObject<AddressResponse>(content);

            if (address.Erro)
                throw new Exception("Endereço não encontrado.");

            return address;
        }
    }
}