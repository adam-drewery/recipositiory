using System;

namespace Recipository.Domain
{
	public class Recipe : IEntity, INamed
	{
		public Guid Id { get; set; }

		public string Name { get; set; }
	}
}
