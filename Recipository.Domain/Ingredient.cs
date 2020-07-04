using System;

namespace Recipository.Domain
{
	public class Ingredient : IEntity, INamed
	{
		public int Id { get; set; }

		public string Name { get; set; }
	}
}
