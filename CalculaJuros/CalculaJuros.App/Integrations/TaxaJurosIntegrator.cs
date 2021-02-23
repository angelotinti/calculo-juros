using RestSharp;

namespace CalculaJuros.App.Integrations
{
    public class TaxaJurosIntegrator : ITaxaJurosIntegrator
    {
        private readonly IRestClient _restClient;
        private readonly string _taxaJurosServiceUrl;

        public TaxaJurosIntegrator(IRestClient restClient, string taxaJurosServiceUrl)
        {
            _restClient = restClient;
            _taxaJurosServiceUrl = taxaJurosServiceUrl;
        }

        public ReadTaxaJurosResult ReadTaxaJuros()
        {
            var request = new RestRequest(_taxaJurosServiceUrl);
            var response = _restClient.Get<float>(request);
            if (response.IsSuccessful)
            {
                return ReadTaxaJurosResult.IsSuccess(float.Parse(response.Content));
            }
            return ReadTaxaJurosResult.IsError(response.ErrorMessage);
        }
    }
}
