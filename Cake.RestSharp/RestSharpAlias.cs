using System.Net;
using Cake.Core;
using Cake.Core.Annotations;
using Cake.Core.Diagnostics;
using RestSharp;

namespace Cake.RestSharp
{
    [CakeAliasCategory("RestSharp")]
    public static class RestSharpAlias
    {
        [CakeMethodAlias]
        public static string GetUriResource(
            this ICakeContext context,
            string uri)
        {
            var client = new RestClient(uri);

            var request = new RestRequest(Method.GET);

            var response = client.Execute(request);

            context.Log.Information($"Request to uri: {uri} code: {response.StatusCode}");

            return response.StatusCode.ToString();
        }

        [CakeMethodAlias]
        public static string GetUriResource(
            this ICakeContext context,
            string uri,
            string resource)
        {
            var client = new RestClient(uri);

            var request = new RestRequest(resource, Method.GET);

            var response = client.Execute(request);

            context.Log.Information($"Request to uri: {uri} resource: {resource} code: {response.StatusCode}");

            return response.StatusCode.ToString();
        }
    }
}
