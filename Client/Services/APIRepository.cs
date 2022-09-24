using CookTo.Client.HTTPHelpers;
using CookTo.Shared.Models;
using CookTo.Shared.Repositories;
using Microsoft.AspNetCore.Authorization;
using Newtonsoft.Json;
using System.Net;
using System.Net.Http.Json;


namespace CookTo.Client.Services;

public class APIRepository<TEntity> : IMongoRepository<TEntity> where TEntity : BaseEntity
{
    string controllerName;
    string primaryKeyName;
    private readonly IHttpClientFactory _httpClientFactory;


    public APIRepository(IHttpClientFactory httpClientFactory, string _controllerName, string _primaryKeyName)
    {
        _httpClientFactory = httpClientFactory;
        controllerName = _controllerName;
        primaryKeyName = _primaryKeyName;
    }


    public async Task<IList<TEntity>> GetAllAsync()
    {
        try
        {
            var httpClient = HttpNamedClientFactoryHelper.CreateClient(_httpClientFactory, HttpClientType.Anon);
            var result = await httpClient.GetAsync($"/{controllerName}");
            result.EnsureSuccessStatusCode();
            string responseBody = await result.Content.ReadAsStringAsync();
            var response = JsonConvert.DeserializeObject<IList<TEntity>>(responseBody);
            if(response is not null)
                return response;
            else
                return new List<TEntity>();
        } catch(Exception ex)
        {
            Console.Write(ex);
            var msg = ex.Message;
            return null;
        }
    }

    public async Task<TEntity> GetByIdAsync(string id)
    {
        try
        {
            var httpClient = HttpNamedClientFactoryHelper.CreateClient(_httpClientFactory, HttpClientType.Anon);

            var result = await httpClient.GetAsync(controllerName);
            result.EnsureSuccessStatusCode();
            string responseBody = await result.Content.ReadAsStringAsync();
            var response = JsonConvert.DeserializeObject<TEntity>(responseBody);
            if(response is not null)
                return response;
            else
                return null;
        } catch(Exception ex)
        {
            var msg = ex.Message;
            return null;
        }
    }

    [Authorize]
    public async Task<TEntity> Insert(TEntity entity)
    {
        try
        {
            var httpClient = HttpNamedClientFactoryHelper.CreateClient(_httpClientFactory, HttpClientType.Secure);

            var result = await httpClient.PostAsJsonAsync(controllerName, entity);
            result.EnsureSuccessStatusCode();
            string responseBody = await result.Content.ReadAsStringAsync();
            var response = JsonConvert.DeserializeObject<TEntity>(responseBody);
            if(response is not null)
                return response;
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

            var result = await httpClient.PutAsJsonAsync(controllerName, entityToUpdate);
            result.EnsureSuccessStatusCode();
            string responseBody = await result.Content.ReadAsStringAsync();
            var response = JsonConvert.DeserializeObject<TEntity>(responseBody);
            if(response is not null)
                return response;
            else
                return null;
        } catch(Exception ex)
        {
            return null;
        }
    }

    public async Task<bool> Delete(TEntity entityToDelete)
    {
        try
        {
            var value = entityToDelete.GetType().GetProperty(primaryKeyName).GetValue(entityToDelete, null).ToString();

            return await DeleteByValue(primaryKeyName, value);
        } catch(Exception ex)
        {
            return false;
        }
    }

    public async Task<bool> DeleteByValue(string PropertyName, string Value)
    {
        try
        {
            var httpClient = HttpNamedClientFactoryHelper.CreateClient(_httpClientFactory, HttpClientType.Secure);

            var url = $"{controllerName}/{WebUtility.HtmlEncode(PropertyName)}/{WebUtility.HtmlEncode(Value)}/DeleteByValue";
            var result = await httpClient.DeleteAsync(url);
            result.EnsureSuccessStatusCode();
            return true;
        } catch(Exception ex)
        {
            return false;
        }
    }
}
