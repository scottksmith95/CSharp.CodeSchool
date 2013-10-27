using System;

namespace CSharp.CodeSchool
{
    /// <summary>
    /// Exceptions returned in the HTTP response body when something goes wrong.
    /// </summary>
    public class RestException
    {
        /// <summary>
        /// The HTTP status code for the exception.
        /// </summary>
        public string Status { get; set; }

        /// <summary>
        /// (Conditional) The error object returned by Code School.
        /// </summary>
        public Error error { get; set; }

        public class Error
        {
            public string name { get; set; }
            public string message { get; set; }
        }
    }
}