using System;

namespace Recipository.Domain
{
	public interface IEntity
	{
		int Id { get; set; }
	}

	public interface IAuditable
	{
		DateTime CreatedDate { get; set; }
	}
}
