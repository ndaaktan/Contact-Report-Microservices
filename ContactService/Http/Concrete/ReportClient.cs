using ContactService.Dtos;
using ContactService.Http.Abstract;
using ContactService.Model;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ContactService.Http.Concrete
{
    public class ReportClient : IReportClient
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;

        public ReportClient(IConfiguration configuration, HttpClient client)
        {
            _configuration = configuration;
            _httpClient = client;
        }
        public async Task<ReportResponse<string>> SendReportRequest(ReportRequest request)
        {
            var httpContent = new StringContent(
              JsonConvert.SerializeObject(request),
              Encoding.UTF8,
              "application/json"
          );

            var response = await _httpClient.PostAsync($"{_configuration["ReportService"]}/api/Report", httpContent);
            if (response.IsSuccessStatusCode)
            {
                var data = await response.Content.ReadAsStringAsync();
                var genericData = JsonConvert.DeserializeObject<ReportResponse<string>>(data);
                return genericData;
            }
            else
            {
                return null;
            }

        }
    }
}
