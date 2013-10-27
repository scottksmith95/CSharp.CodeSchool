using System;

namespace CSharp.CodeSchool
{
    /// <summary>
    /// Base class for all Code School resource types
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
