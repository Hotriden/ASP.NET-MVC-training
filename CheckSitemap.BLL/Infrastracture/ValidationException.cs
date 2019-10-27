using System;

namespace CheckSitemap.BLL.Infrastracture
{
    /// <summary>
    /// Catch valid exceptions
    /// </summary>
    public class ValidationException:Exception
    {
        public string Property { get; protected set; }

        public ValidationException(string message, string prop) : base(message)
        {
            Property = prop;
        }
    }
}
