using AutoMapper;
using CookTo.Client.Features.ManageRecipes.ViewModel;
using CookTo.Client.Managers.Interfaces;
using CookTo.Shared.Features.ManageIngredients;
using CookTo.Shared.Features.ManageRecipes;
using CookTo.Shared.Features.ManageUtensils;
using Newtonsoft.Json;
using System.Text.Json;

namespace CookTo.Client.Managers;

public class RecipeManager : IRecipeManager
{
    private readonly IHttpClientFactory _factory;
    private readonly IMapper _mapper;
    private const string _url = "/api/recipe";

    public RecipeManager(IHttpClientFactory factory, IMapper mapper)
    {
        _factory = factory;
        _mapper = mapper;
    }

    public async Task<Recipe> GetById(string id)
    {
        try
        {
            var httpClient = HttpClientFactoryHelper.CreateClient(_factory, HttpClientType.Anon);
            var result = await httpClient.GetAsync($"{_url}/{id}", new CancellationToken());
            result.EnsureSuccessStatusCode();
            var content = await result.Content.ReadAsStringAsync();
            var response = JsonConvert.DeserializeObject<RecipeDto>(content);
            var mapped = _mapper.Map<Recipe>(response);
            return mapped;
        } catch(Exception)
        {
            return default!;
        }
    }

    public async Task<IEnumerable<RecipeDto>> GetAll()
    {
        try
        {
            var httpClient = HttpClientFactoryHelper.CreateClient(_factory, HttpClientType.Anon);
            var result = await httpClient.GetAsync(_url, new CancellationToken());
            result.EnsureSuccessStatusCode();
            var content = await result.Content.ReadAsStringAsync();
            var response = JsonConvert.DeserializeObject<List<RecipeDto>>(content);
            return response;
        } catch(Exception)
        {
            return default!;
        }
    }

    public async Task<Recipe> Insert(Recipe entity)
    {
        try
        {
            var httpClient = HttpClientFactoryHelper.CreateClient(_factory, HttpClientType.Secure);
            var dto = _mapper.Map<Recipe>(entity);
            var result = await httpClient.PostAsJsonAsync(_url, dto, new CancellationToken());
            result.EnsureSuccessStatusCode();
            var content = await result.Content.ReadAsStringAsync();
            var response = JsonConvert.DeserializeObject<RecipeDto>(content);
            var mapped = _mapper.Map<Recipe>(response);
            return mapped;
        } catch(Exception)
        {
            throw;
        }
    }

    public async Task<bool> Update(Recipe entityToUpdate)
    {
        try
        {
            var httpClient = HttpClientFactoryHelper.CreateClient(_factory, HttpClientType.Secure);
            var dto = _mapper.Map<Recipe>(entityToUpdate);
            var result = await httpClient.PutAsJsonAsync(_url, dto, new CancellationToken());
            result.EnsureSuccessStatusCode();
            return true;
        } catch(Exception)
        {
            throw;
        }
    }
}
