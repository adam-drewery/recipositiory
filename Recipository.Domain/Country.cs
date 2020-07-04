using System;

namespace Recipository.Domain
{
	public class Country : IEntity, INamed
	{
		public Guid Id { get; set; }

		public string Name { get; set; }
	}
}