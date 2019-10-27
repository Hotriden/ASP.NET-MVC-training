using System;

namespace CheckSitemap.BLL.Infrastracture
{
    /// <summary>
    /// Catch 404 error
    /// </summary>
    public class NotFoundException:Exception
    {
        public string Property { get; protected set; }

        public NotFoundException(string message, string prop) : base(message)
        {
            Property = prop;
        }
    }
}
