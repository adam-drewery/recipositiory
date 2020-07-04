using System;

namespace Recipository.Domain
{
	public interface IAuditable
	{
		DateTime CreatedDate { get; set; }
	}
}