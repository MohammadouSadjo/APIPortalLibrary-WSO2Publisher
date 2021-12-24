using APIPortalLibraryPublisher.Configuration;
using APIPortalLibraryPublisher.Interfaces;
using APIPortalLibraryPublisher.Models;
using Refit;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace APIPortalLibraryPublisher.Services
{
    public class ApplicationService
    {
        public static async Task<ApiResponse<Application>> ApplicationDetails(string applicationId)// Get details of a given application
        {
            //Bypass SSL Certificate
            HttpClientHandler clientHandler = new HttpClientHandler();
            clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };

            HttpClient _client = new HttpClient(clientHandler)
            {
                BaseAddress = new Uri(Config.baseUrl)
            };
            //Set user's authorization
            var authorization = "Bearer " + Config.UserInfos.accessTokenCreate;

            try
            {
                IApplication _restApiService = RestService.For<IApplication>(_client);

                var applicationDetails = await _restApiService.GetApplicationDetails(authorization, applicationId);

                return applicationDetails;
            }
            catch (ApiException ex)
            {
                // Extract the details of the error
                var errors = await ex.GetContentAsAsync<Dictionary<string, string>>();
                // Combine the errors into a string
                var message = string.Join("; ", errors.Values);
                // Throw a normal exception
                throw new Exception(message);
            }

        }
    }
}
