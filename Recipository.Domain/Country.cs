using System;

namespace Recipository.Domain
{
	public class Country : IEntity, INamed
	{
		public Country() { }

		public Country(string name) => Name = name;

		public Country(int id, string name) : this(name) => Id = id;

		public int Id { get; set; }

		public string Name { get; set; }
	}
}
