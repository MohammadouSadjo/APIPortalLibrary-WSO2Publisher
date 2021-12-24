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
    public class DocumentService
    {
        public static async Task<ApiResponse<AllDocuments>> AllDocuments(string apiId, int limit = 25, int offset = 0)//Get all documents of a given API
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
                IDocument _restApiService = RestService.For<IDocument>(_client);

                var allDocuments = await _restApiService.GetAllDocuments(authorization, apiId, limit, offset);

                return allDocuments;
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

        public static async Task<ApiResponse<Document>> AddDocument(string apiId, string body)//Get all documents of a given API
        {
            //Bypass SSL Certificate
            HttpClientHandler clientHandler = new HttpClientHandler();
            clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };

            HttpClient _client = new HttpClient(clientHandler)
            {
                BaseAddress = new Uri(Config.baseUrl)
            };

            var authorization = "Bearer " + Config.UserInfos.accessTokenCreate;

            try
            {
                IDocument _restApiService = RestService.For<IDocument>(_client);

                var addDocument = await _restApiService.AddDocument(authorization, apiId, body);

                return addDocument;
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

        public static async Task<ApiResponse<string>> GetDocumentContent(string apiId, string documentId)//Get the content of a given document
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
                IDocument _restApiService = RestService.For<IDocument>(_client);

                var documentContent = await _restApiService.GetDocumentContent(authorization ,apiId, documentId);

                return documentContent;
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

        public static async Task<ApiResponse<Document>> UpdateDocument(string apiId, string documentId, string body)//Get all documents of a given API
        {
            //Bypass SSL Certificate
            HttpClientHandler clientHandler = new HttpClientHandler();
            clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };

            HttpClient _client = new HttpClient(clientHandler)
            {
                BaseAddress = new Uri(Config.baseUrl)
            };

            var authorization = "Bearer " + Config.UserInfos.accessTokenCreate;

            try
            {
                IDocument _restApiService = RestService.For<IDocument>(_client);

                var updateDocument = await _restApiService.UpdateDocument(authorization, apiId, documentId, body);

                return updateDocument;
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

        public static async Task<ApiResponse<Document>> GetDocument(string apiId, string documentId)//Get a document
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
                IDocument _restApiService = RestService.For<IDocument>(_client);

                var document = await _restApiService.GetDocument(authorization ,apiId, documentId);

                return document;
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

        public static async Task<ApiResponse<Document>> DeleteDocument(string apiId, string documentId)//Delete a document
        {
            //Bypass SSL Certificate
            HttpClientHandler clientHandler = new HttpClientHandler();
            clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };

            HttpClient _client = new HttpClient(clientHandler)
            {
                BaseAddress = new Uri(Config.baseUrl)
            };

            var authorization = "Bearer " + Config.UserInfos.accessTokenCreate;

            try
            {
                IDocument _restApiService = RestService.For<IDocument>(_client);

                var deleteDocument = await _restApiService.DeleteDocument(authorization, apiId, documentId);

                return deleteDocument;
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
