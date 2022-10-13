using CookTo.Client.HTTPHelpers;
using CookTo.Shared.Models;
using CookTo.Shared.Repositories;
using Microsoft.AspNetCore.Authorization;
using System.Net;
using System.Net.Http.Json;
using System.Text.Json;

namespace CookTo.Client.Services;

public class APIRepository<TEntity> : IMongoRepository<TEntity> where TEntity : BaseEntity
{
    string controllerName;
    private readonly IHttpClientFactory _httpClientFactory;
    private JsonSerializerOptions serliazerOptions;

    public APIRepository(IHttpClientFactory httpClientFactory, string _controllerName)
    {
        _httpClientFactory = httpClientFactory;
        controllerName = _controllerName;
        serliazerOptions = new JsonSerializerOptions() { PropertyNameCaseInsensitive = true };
    }


    public async Task<IList<TEntity>> GetAllAsync()
    {
        try
        {
            var httpClient = HttpNamedClientFactoryHelper.CreateClient(_httpClientFactory, HttpClientType.Anon);
            var response = await httpClient.GetAsync($"/{controllerName}");
            response.EnsureSuccessStatusCode();
            string responseBody = await response.Content.ReadAsStringAsync();
            var listOfEntity = JsonSerializer.Deserialize<IList<TEntity>>(responseBody, serliazerOptions);
            if(listOfEntity is not null)
                return listOfEntity;
            else
                return new List<TEntity>();
        } catch(Exception ex)
        {
            throw new NotImplementedException();
        }
    }

    public async Task<TEntity> GetByIdAsync(string id)
    {
        try
        {
            var httpClient = HttpNamedClientFactoryHelper.CreateClient(_httpClientFactory, HttpClientType.Anon);

            var response = await httpClient.GetAsync($"/{controllerName}/{id}");
            response.EnsureSuccessStatusCode();
            string responseBody = await response.Content.ReadAsStringAsync();
            var entity = JsonSerializer.Deserialize<TEntity>(responseBody, serliazerOptions);
            if(entity is not null)
                return entity;
            else
                return null;
        } catch(Exception ex)
        {
            var msg = ex.Message;
            return null;
        }
    }

    [Authorize]
    public async Task<TEntity> Insert(TEntity newEntity)
    {
        try
        {
            var httpClient = HttpNamedClientFactoryHelper.CreateClient(_httpClientFactory, HttpClientType.Secure);

            var response = await httpClient.PostAsJsonAsync(controllerName, newEntity);
            response.EnsureSuccessStatusCode();
            string responseBody = await response.Content.ReadAsStringAsync();
            var entity = JsonSerializer.Deserialize<TEntity>(responseBody, serliazerOptions);
            if(entity is not null)
                return entity;
            else
                return null;
        } catch(Exception ex)
        {
            Console.Write(ex.Message);
            return null;
        }
    }

    public async Task<TEntity> Update(TEntity entityToUpdate)
    {
        try
        {
            var httpClient = HttpNamedClientFactoryHelper.CreateClient(_httpClientFactory, HttpClientType.Secure);

            var response = await httpClient.PutAsJsonAsync(controllerName, entityToUpdate);
            response.EnsureSuccessStatusCode();
            string responseBody = await response.Content.ReadAsStringAsync();
            var entity = JsonSerializer.Deserialize<TEntity>(responseBody, serliazerOptions);
            if(entity is not null)
                return entity;
            else
                return null;
        } catch(Exception ex)
        {
            return null;
        }
    }


    public async Task<bool> Delete(string id)
    {
        try
        {
            var httpClient = HttpNamedClientFactoryHelper.CreateClient(_httpClientFactory, HttpClientType.Secure);
            var response = await httpClient.DeleteAsync( $"{controllerName}/{id}");
            response.EnsureSuccessStatusCode();
            return true;
        } catch(Exception ex)
        {
            return false;
        }
    }
}
