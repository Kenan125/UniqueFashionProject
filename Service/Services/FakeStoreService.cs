using Entity.Dtos.FakeStoreDto;
using Entity.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services
{
    public class FakeStoreService : IFakeStoreService
    {
        private readonly HttpClient _httpClient;

        public FakeStoreService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<FakeStoreProductDto>> GetProductsAsync()
        {
            var response = await _httpClient.GetAsync("https://fakestoreapi.com/products");
            response.EnsureSuccessStatusCode();
            var jsonString = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<List<FakeStoreProductDto>>(jsonString);
        }
    }
}
