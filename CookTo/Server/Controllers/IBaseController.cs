namespace CookTo.Server.Controllers;

public interface IBaseController<TEntity> where TEntity : BaseEntity
{
	Task<ActionResult<TEntity>> CreateAsync([FromBody] TEntity entity);

	Task<ActionResult<bool>> DeleteAsync(string id);

	Task<ActionResult<List<TEntity>>> GetAllAsync();

	Task<ActionResult<TEntity>> GetByIdAsync(string id);

	Task<ActionResult<TEntity>> UpdateAsync([FromBody] TEntity entity);
}
