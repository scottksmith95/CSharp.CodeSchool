using RestSharp;
using System;

namespace CSharp.CodeSchool
{
    public partial class CodeSchoolRestClient
    {
        /// <summary>
        /// Retrieve the account details for the currently set username.
        /// </summary>
        public Account GetAccount()
        {
            var request = new RestRequest();
            request.Resource = "users/{Username}.json";

            return Execute<Account>(request);
        }
    }
}
