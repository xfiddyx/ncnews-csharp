using System;
using System.Net;

namespace NcNews.Errors
{
    public class NotFoundError : ApiError
    {
        public NotFoundError() : base(404, HttpStatusCode.NotFound.ToString())
        {

        }
        public NotFoundError(string message) : base(404, HttpStatusCode.NotFound.ToString(), message)
        {

        }
    }
}
