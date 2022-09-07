using AutoMapper;
using CookTo.DataAccess;
using CookTo.DataAccess.Documents.CategoryDocumentAccess;
using CookTo.DataAccess.Documents.RecipeDocumentAccess;
using CookTo.Server.Modules.Recipes.Helpers;
using CookTo.Shared;
using CookTo.Shared.Modules;
using CookTo.Shared.Modules.ManageCategories;
using CookTo.Shared.Modules.ManageRecipes;

namespace CookTo.Server.Modules;

internal static class GenericHandlers<TDocument, TEntity> where TDocument : BaseDocument where TEntity : BaseEntity
{
    internal static async Task<IResult> GetByIdAsync(string id, IBaseService<TDocument> service, CancellationToken cancellationToken, IMapper mapper)
    {
        var document = await service.GetByIdAsync(id, cancellationToken);
        if(document is null)
            return TypedResults.NotFound(ErrorMessage<Category>.ItemNotFound(id));

        var response = mapper.Map<TEntity>(document);
        return TypedResults.Ok(response);
    }

    internal static async Task<IResult> GetAllAsync(IBaseService<TDocument> service, CancellationToken cancellationToken, IMapper mapper)
    {
        var entites = await service.GetAllAsync(cancellationToken);
        var response = new List<Category>();

        if(entites is not null || entites.Any())
            response.AddRange(entites.Select(c => mapper.Map<Category>(c)));

        return TypedResults.Ok(response);
    }

    internal static async Task<IResult> PostAsync(TEntity entity, IBaseService<TDocument> service, CancellationToken cancellationToken, IMapper mapper, string redirectUrlFragment)
    {
        var newEntity = mapper.Map<TDocument>(entity);
        await service.CreateAsync(newEntity, cancellationToken);
        var response = mapper.Map<TEntity>(newEntity);
        return TypedResults.Created($"{redirectUrlFragment}/{response.Id}", response);
    }

    internal static async Task<IResult> PutAsync(TEntity entity, IBaseService<TDocument> service, CancellationToken cancellationToken, IMapper mapper, string redirectUrlFragment)
    {
        var exisitngEntity = await service.GetByIdAsync(entity.Id, cancellationToken);
        if(exisitngEntity is null)
            return TypedResults.NotFound(ErrorMessage<TEntity>.ItemNotFound(entity.Id));

        var document = mapper.Map<TDocument>(entity);
        await service.UpdateAsync(document, cancellationToken);
        var response = mapper.Map<Recipe>(document);
        return TypedResults.Created($"{redirectUrlFragment}/{entity.Id}", response);
    }

    internal static async Task<IResult> DeleteAsync(string id, IBaseService<TDocument> service, CancellationToken cancellationToken, IMapper mapper)
    {
        var recipe = await service.GetByIdAsync(id, cancellationToken);
        if(recipe is null)
            return TypedResults.NotFound(ErrorMessage<TEntity>.ItemNotFound(id));
        await service.DeleteAsync(id, cancellationToken);
        return TypedResults.NoContent();
    }
}
