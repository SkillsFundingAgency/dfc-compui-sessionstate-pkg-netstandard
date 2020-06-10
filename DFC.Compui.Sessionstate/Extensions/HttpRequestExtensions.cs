using Microsoft.AspNetCore.Http;
using System;
using System.Diagnostics.CodeAnalysis;

namespace DFC.Compui.Sessionstate
{
    [ExcludeFromCodeCoverage]
    public static class HttpRequestExtensions
    {
        public static Guid? CompositeSessionId(this HttpRequest request)
        {
            const string CompositeSessionIdHeaderName = "x-dfc-composite-sessionid";

            if (request != null && request.Headers.TryGetValue(CompositeSessionIdHeaderName, out var headerValue) && Guid.TryParse(headerValue, out var guidValue))
            {
                return guidValue;
            }

            return default;
        }
    }
}
