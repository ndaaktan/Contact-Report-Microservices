using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using ReportService.Dtos;
using ReportService.Http.Abstract;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace ReportService.Http.Concrete
{
    public class ContactClient : IContactClient
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;

        public ContactClient(HttpClient client, IConfiguration configuration)
        {
            _configuration = configuration;
            _httpClient = client;
        }
        public async Task<IEnumerable<ContactInformation>> GetAllInformations()
        {
            List<ContactInformation> contactInformationList = new List<ContactInformation>();
            var response = await _httpClient.GetAsync($"{_configuration["ContactService"]}/api/ContactInformation/GetAll");
            if (response.IsSuccessStatusCode)
            {
                var responseData = await response.Content.ReadAsStringAsync();
                contactInformationList = JsonConvert.DeserializeObject<List<ContactInformation>>(responseData);
            }
            return contactInformationList;
        }
    }
}
