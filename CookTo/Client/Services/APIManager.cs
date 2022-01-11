using System.Net.Http.Json;
using System.Text.Json;

namespace CookTo.Client.Services
{
    public class APIManager<TEntity> : IManager<TEntity> where TEntity : class
    {
        private readonly HttpClient _httpClient;
        readonly string _url;

        public APIManager(HttpClient client, string controller)
        {
            _httpClient = client;
            _url = $"api/{controller}";
        }
        public async Task<IEnumerable<TEntity>> GetAll()
        {
            try
            {
                var result = await _httpClient.GetAsync(_url);
                result.EnsureSuccessStatusCode();
                string responseBody = await result.Content.ReadAsStringAsync();
                var response = JsonSerializer.Deserialize<IEnumerable<TEntity>>(responseBody);
                return response;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public async Task<TEntity> GetById(int id)
        {
            try
            {
                var result = await _httpClient.GetAsync($"{_url}/{id}");
                result.EnsureSuccessStatusCode();
                string responseBody = await result.Content.ReadAsStringAsync();
                var response = JsonSerializer.Deserialize<TEntity>(responseBody);
                return response;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public async Task<TEntity> Insert(TEntity entity)
        {
            try
            {
                var result = await _httpClient.PostAsJsonAsync(_url, entity);
                result.EnsureSuccessStatusCode();
                string responseBody = await result.Content.ReadAsStringAsync();
                var response = JsonSerializer.Deserialize<TEntity>(responseBody);
                return response;
            }
            catch (Exception)
            {
                //todo handle exception
                return null;
            }
        }

        public async Task<TEntity> Update(TEntity entity)
        {
            try
            {
                var result = await _httpClient.PutAsJsonAsync(_url, entity);
                result.EnsureSuccessStatusCode();
                string responseBody = await result.Content.ReadAsStringAsync();
                var response = JsonSerializer.Deserialize<TEntity>(responseBody);
                return response;
            }
            catch (Exception)
            {

                return null;
            }

        }

        public async Task<bool> Delete(int id)
        {
            try
            {
                var result = await _httpClient.DeleteAsync($"{_url}/{id}");
                result.EnsureSuccessStatusCode();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
