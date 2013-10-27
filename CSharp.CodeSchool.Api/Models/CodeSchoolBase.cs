using System;

namespace CSharp.CodeSchool.Api.Models
{
    /// <summary>
    /// Base class for all Code SchoolS resource types
    /// </summary>
    public abstract class CodeSchoolBase
    {
        /// <summary>
        /// Exception encountered during API request
        /// </summary>
        public RestException RestException { get; set; }

        /// <summary>
        /// The URI for this resource, relative to https://www.codeschool.com/
        /// </summary>
        public Uri Uri { get; set; }
    }
}
