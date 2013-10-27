using RestSharp;
using RestSharp.Extensions;
using System.Reflection;
using RestSharp.Deserializers;
using System.Text;
using System;
using System.Net;

namespace CSharp.CodeSchool.Api
{
    public partial class CodeSchoolRestClient
    {
        /// <summary>
        /// Base URL of API (defaults to https://www.codeschool.com/)
        /// </summary>
        public string BaseUrl { get; private set; }

        private string Username { get; set; }

        private RestClient _client;

        /// <summary>
        /// Initializes a new client with the specified username.
        /// </summary>
        /// <param name="username">The username of the account to retrieve</param>
        public CodeSchoolRestClient(string username)
        {
            BaseUrl = "https://www.codeschool.com/";
            Username = username;

            // silverlight friendly way to get current version
            var assembly = Assembly.GetExecutingAssembly();
            AssemblyName assemblyName = new AssemblyName(assembly.FullName);
            var version = assemblyName.Version;

            _client = new RestClient();
            _client.UserAgent = "CSharp.CodeSchool/" + version;
            _client.AddDefaultHeader("Accept-charset", "utf-8");
            _client.BaseUrl = BaseUrl;
            _client.Timeout = 3050;
            _client.AddDefaultUrlSegment("Username", Username);
        }

        /// <summary>
        /// Execute a manual REST request
        /// </summary>
        /// <typeparam name="T">The type of object to create and populate with the returned data.</typeparam>
        /// <param name="request">The RestRequest to execute (will use client credentials)</param>
        public virtual T Execute<T>(RestRequest request) where T : new()
        {
            request.OnBeforeDeserialization = (resp) =>
            {
                // for individual resources when there's an error to make
                // sure that RestException props are populated
                if (((int)resp.StatusCode) >= 400)
                {
                    // have to read the bytes so .Content doesn't get populated
                    string restException = "{{ \"RestException\" : {0} }}";
                    var content = resp.RawBytes.AsString(); //get the response content
                    var newJson = string.Format(restException, content);

                    resp.Content = null;
                    resp.RawBytes = Encoding.UTF8.GetBytes(newJson.ToString());
                }
            };

            request.DateFormat = "ddd, dd MMM yyyy HH:mm:ss '+0000'";

            var response = _client.Execute<T>(request);
            return response.Data;
        }

        /// <summary>
        /// Execute a manual REST request
        /// </summary>
        /// <param name="request">The RestRequest to execute (will use client credentials)</param>
        public virtual IRestResponse Execute(IRestRequest request)
        {
            return _client.Execute(request);
        }
    }
}
