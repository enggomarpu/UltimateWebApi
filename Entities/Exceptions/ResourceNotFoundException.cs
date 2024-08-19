using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Exceptions
{
	public sealed class ResourceNotFoundException : NotFoundException
	{
		
		public ResourceNotFoundException(Guid companyId, string resourceName, int statusCode) : base($"The {resourceName} with id: {companyId} doesn't exist in the database.", statusCode)
		{
			
		}
	}




}
