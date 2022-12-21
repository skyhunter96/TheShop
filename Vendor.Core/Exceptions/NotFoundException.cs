using System.Net;

namespace Vendor.Core.Exceptions
{
    public class NotFoundException : ApiException
    {
        public NotFoundException(string name, object key)
             : base($"Entity \"{name}\" ({key}) not found", HttpStatusCode.NotFound)
        {
        }
    }
}
