using CookTo.Client.HTTPHelpers;
using CookTo.Client.HTTPManagers.Interfaces;
using Newtonsoft.Json;

namespace CookTo.Client.HTTPManagers;

public abstract class BaseManager<T> : IBaseManager<T> where T : class
{
    private readonly IHttpClientFactory _httpClientFactory;
    private readonly string _url;

    public BaseManager(IHttpClientFactory httpClientFactory, string endpoint)
    {
        _httpClientFactory = httpClientFactory;
        _url = $"/api/{endpoint}";
    }

    public async Task<IList<T>> GetAll()
    {
        try
        {
            var httpClient = HttpNamedClientFactoryHelper.CreateClient(_httpClientFactory, HttpClientType.Anon);
            var result = await httpClient.GetAsync(_url, new CancellationToken());
            var content = await result.Content.ReadAsStringAsync();
            var deserializedObject = JsonConvert.DeserializeObject<IList<T>>(content);
            if (deserializedObject != null)
            {
                return deserializedObject;
            }
            else
            {
                return new List<T>();
            }
        }
        catch (HttpRequestException)
        {
            return default!;
        }
    }

    public async Task<T?> GetById(string id)
    {
        try
        {
            var httpClient = HttpNamedClientFactoryHelper.CreateClient(_httpClientFactory, HttpClientType.Anon);
            var result = await httpClient.GetAsync($"{_url}/{id}", new CancellationToken());
            result.EnsureSuccessStatusCode();
            var content = await result.Content.ReadAsStringAsync();
            var deserializedObject = JsonConvert.DeserializeObject<T>(content);
            if (deserializedObject != null)
            {
                return deserializedObject;
            }
            else
            {
                return null;
            }
        }
        catch (HttpRequestException)
        {
            return default!;
        }
    }

    public async Task<T?> Insert(T entity)
    {
        try
        {
            var httpClient = HttpNamedClientFactoryHelper.CreateClient(_httpClientFactory, HttpClientType.Secure);

            var result = await httpClient.PostAsJsonAsync(_url, entity, new CancellationToken());
            result.EnsureSuccessStatusCode();
            var content = await result.Content.ReadAsStringAsync();
            var deserializedObject = JsonConvert.DeserializeObject<T>(content);
            if (deserializedObject != null)
            {
                return deserializedObject;
            }
            else
            {
                return null;
            }
        }
        catch (Exception)
        {
            throw;
        }
    }

    public async Task<bool> Update(T entityToUpdate)
    {
        try
        {
            var httpClient = HttpNamedClientFactoryHelper.CreateClient(_httpClientFactory, HttpClientType.Secure);
            var result = await httpClient.PutAsJsonAsync(_url, entityToUpdate);
            return result.IsSuccessStatusCode;
        }
        catch (Exception)
        {
            throw;
        }
    }
}

