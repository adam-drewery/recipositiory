namespace Recipository.Domain.Extensions
{
	public static class EntityExtensions
	{
		public static bool IsNew(this IEntity entity)
		{
			// If the entity's ID is 0 then its not been saved yet.
			return entity.Id == 0;
		}
	}
}
