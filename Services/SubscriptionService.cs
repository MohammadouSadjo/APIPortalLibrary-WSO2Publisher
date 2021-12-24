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
    public class SubscriptionService
    {
        public static async Task<ApiResponse<AllSubscriptions>> AllSubscriptions(string apiId, int limit = 25, int offset = 0)//Get list of all subscription of an api
        {
            //Bypass SSL Certificate
            HttpClientHandler clientHandler = new HttpClientHandler();
            clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };

            HttpClient _client = new HttpClient(clientHandler)
            {
                BaseAddress = new Uri(Config.baseUrl)
            };
            //Set user's authorization
            var authorization = "Bearer " + Config.UserInfos.accessTokenSubscriptionView;

            try
            {
                ISubscription _restApiService = RestService.For<ISubscription>(_client);

                var allSubscriptions = await _restApiService.GetAllSubscriptions(authorization, apiId, limit, offset);

                return allSubscriptions;
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

        public static async Task<ApiResponse<Subscription>> SubscriptionDetails(string subsciptionId)// Get details of a given subscription
        {
            //Bypass SSL Certificate
            HttpClientHandler clientHandler = new HttpClientHandler();
            clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };

            HttpClient _client = new HttpClient(clientHandler)
            {
                BaseAddress = new Uri(Config.baseUrl)
            };

            //Set user's authorization
            var authorization = "Bearer " + Config.UserInfos.accessTokenSubscriptionView;

            try
            {
                ISubscription _restApiService = RestService.For<ISubscription>(_client);

                var subscriptionsDetails = await _restApiService.GetSubscriptionsDetails(authorization, subsciptionId);

                return subscriptionsDetails;
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

        public static async Task<ApiResponse<Subscription>> BlockSubscription(string subsciptionId, string blockState)// Block subscription
        {
            //Bypass SSL Certificate
            HttpClientHandler clientHandler = new HttpClientHandler();
            clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };

            HttpClient _client = new HttpClient(clientHandler)
            {
                BaseAddress = new Uri(Config.baseUrl)
            };

            //Set user's authorization
            var authorization = "Bearer " + Config.UserInfos.accessTokenSubscriptionBlock;
            
            try
            {
                ISubscription _restApiService = RestService.For<ISubscription>(_client);

                var blockSubscription = await _restApiService.BlockSubscription(authorization, subsciptionId, blockState);

                return blockSubscription;
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

        public static async Task<ApiResponse<Subscription>> UnblockSubscription(string subsciptionId)// Unblock subscription
        {
            //Bypass SSL Certificate
            HttpClientHandler clientHandler = new HttpClientHandler();
            clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };

            HttpClient _client = new HttpClient(clientHandler)
            {
                BaseAddress = new Uri(Config.baseUrl)
            };

            //Set user's authorization
            var authorization = "Bearer " + Config.UserInfos.accessTokenSubscriptionBlock;

            try
            {
                ISubscription _restApiService = RestService.For<ISubscription>(_client);

                var unblockSubscription = await _restApiService.UnblockSubscription(authorization, subsciptionId);

                return unblockSubscription;
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
