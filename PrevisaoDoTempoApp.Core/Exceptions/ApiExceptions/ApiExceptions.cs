using System;

namespace PrevisaoDoTempoApp.Core.Exceptions.ApiExceptions
{
    public class ApiExceptions : Exception
    {
        public ApiExceptions(string message) : base(message) { }
    }
}
