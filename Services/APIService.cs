using APIPortalLibraryPublisher.Configuration;
using APIPortalLibraryPublisher.Interfaces;
using APIPortalLibraryPublisher.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Refit;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace APIPortalLibraryPublisher.Services
{
    public class APIService
    {
        public static async Task<ApiResponse<AllApis>> AllApis(int limit = 25, int offset = 0, string query = "")//Get List of all APIs
        {
            //Bypass SSL Certificate
            HttpClientHandler clientHandler = new HttpClientHandler();
            clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };

            HttpClient _client = new HttpClient(clientHandler)
            {
                BaseAddress = new Uri(Config.baseUrl)
            };

            var authorization = "Bearer " + Config.UserInfos.accessTokenApiView;

            try
            {
                IAPI _restApiService = RestService.For<IAPI>(_client);

                var allApis = await _restApiService.GetAllApis(authorization ,limit, offset, query);

                return allApis;
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

        public static async Task<ApiResponse<API>> APIDetails(string apiId)//Get Details of a given API
        {
            //ByPass SSL Certificate
            HttpClientHandler clientHandler = new HttpClientHandler();
            clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };

            HttpClient _client = new HttpClient(clientHandler)
            {
                BaseAddress = new Uri(Config.baseUrl)
            };

            var authorization = "Bearer " + Config.UserInfos.accessTokenApiView;

            try
            {
                IAPI _restApiService = RestService.For<IAPI>(_client);

                var apiDetails = await _restApiService.GetApiDetails(authorization, apiId);

                return apiDetails;
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

        public static async Task<ApiResponse<API>> AddAPI(string api)//Add an API
        {
            //ByPass SSL Certificate
            HttpClientHandler clientHandler = new HttpClientHandler();
            clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };

            HttpClient _client = new HttpClient(clientHandler)
            {
                BaseAddress = new Uri(Config.baseUrl)
            };

            var authorization = "Bearer " + Config.UserInfos.accessTokenCreate;
            
            API body = JsonConvert.DeserializeObject<API>(api);

            try
            {
                IAPI _restApiService = RestService.For<IAPI>(_client);

                var addApi = await _restApiService.AddApi(authorization, body);

                return addApi;
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

        public static async Task<ApiResponse<API>> AddAPIVersion(string newVersion, string apiId)//Add an API version
        {
            //ByPass SSL Certificate
            HttpClientHandler clientHandler = new HttpClientHandler();
            clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };

            HttpClient _client = new HttpClient(clientHandler)
            {
                BaseAddress = new Uri(Config.baseUrl)
            };

            var authorization = "Bearer " + Config.UserInfos.accessTokenCreate;

            try
            {
                IAPI _restApiService = RestService.For<IAPI>(_client);

                var addApiVersion = await _restApiService.AddApiVersion(authorization, newVersion, apiId);

                return addApiVersion;
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

        public static async Task<ApiResponse<API>> UpdateAPI(string api, string apiId)//Update an API
        {
            //ByPass SSL Certificate
            HttpClientHandler clientHandler = new HttpClientHandler();
            clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };

            HttpClient _client = new HttpClient(clientHandler)
            {
                BaseAddress = new Uri(Config.baseUrl)
            };

            var authorization = "Bearer " + Config.UserInfos.accessTokenCreate;

            API body = JsonConvert.DeserializeObject<API>(api);

            try
            {
                IAPI _restApiService = RestService.For<IAPI>(_client);

                var updateApi = await _restApiService.UpdateApi(authorization, body, apiId);

                return updateApi;
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

        public static async Task<ApiResponse<API>> ChangeApiStatus(string action, string apiId)//Change an API status
        {
            //ByPass SSL Certificate
            HttpClientHandler clientHandler = new HttpClientHandler();
            clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };

            HttpClient _client = new HttpClient(clientHandler)
            {
                BaseAddress = new Uri(Config.baseUrl)
            };

            var authorization = "Bearer " + Config.UserInfos.accessTokenPublish;

            try
            {
                IAPI _restApiService = RestService.For<IAPI>(_client);

                var changeApiStatus = await _restApiService.ChangeApiStatus(authorization, action, apiId);

                return changeApiStatus;
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

        public static async Task<ApiResponse<API>> DeleteApi(string apiId)//Change an API status
        {
            //ByPass SSL Certificate
            HttpClientHandler clientHandler = new HttpClientHandler();
            clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };

            HttpClient _client = new HttpClient(clientHandler)
            {
                BaseAddress = new Uri(Config.baseUrl)
            };

            var authorization = "Bearer " + Config.UserInfos.accessTokenCreate;

            try
            {
                IAPI _restApiService = RestService.For<IAPI>(_client);

                var deleteApi = await _restApiService.DeleteApi(authorization, apiId);

                return deleteApi;
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

        public static async Task<ApiResponse<string>> GetSwaggerDefinition(string apiId)//Get Swagger definition of an API
        {
            //ByPass SSL Certificate
            HttpClientHandler clientHandler = new HttpClientHandler();
            clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };

            HttpClient _client = new HttpClient(clientHandler)
            {
                BaseAddress = new Uri(Config.baseUrl)
            };

            var authorization = "Bearer " + Config.UserInfos.accessTokenApiView;

            try
            {
                IAPI _restApiService = RestService.For<IAPI>(_client);

                var getSwaggerDefinition = await _restApiService.GetSwaggerDefinition(authorization, apiId);

                return getSwaggerDefinition;
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

        public static async Task<ApiResponse<string>> UpdateSwaggerDefinition(string apiId,string apiDefinition)//Get Swagger definition of an API
        {
            //ByPass SSL Certificate
            HttpClientHandler clientHandler = new HttpClientHandler();
            clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };

            HttpClient _client = new HttpClient(clientHandler)
            {
                BaseAddress = new Uri(Config.baseUrl)
            };

            var authorization = "Bearer " + Config.UserInfos.accessTokenCreate;

            try
            {
                IAPI _restApiService = RestService.For<IAPI>(_client);

                var updateSwaggerDefinition = await _restApiService.UpdateSwaggerDefinition(authorization, apiId, apiDefinition);

                return updateSwaggerDefinition;
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
