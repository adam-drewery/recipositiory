using System;

namespace Recipository.Domain
{
	public interface IEntity
	{
		Guid Id { get; set; }
	}
}