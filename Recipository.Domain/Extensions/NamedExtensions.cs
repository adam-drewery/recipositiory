using System.Collections.Generic;
using System.Linq;

namespace Recipository.Domain.Extensions
{
	public static class NamedExtensions
	{
		public static T WithName<T>(this IEnumerable<T> source, string name) where T : class, INamed
		{
			// If the entity's ID is 0 then its not been saved yet.
			// Use AsQueryable so it works for both IEnumerable and IQueryable types without materialising the whole DB.
			return source.AsQueryable().SingleOrDefault(x => x.Name == name);
		}
	}
}
