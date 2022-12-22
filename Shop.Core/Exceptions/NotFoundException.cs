using System.Net;

namespace Shop.Core.Exceptions
{
    public class NotFoundException : ApiException
    {
        public NotFoundException(string name, object key)
             : base($"Entity \"{name}\" ({key}) not found", HttpStatusCode.NotFound)
        {
        }
    }
}
