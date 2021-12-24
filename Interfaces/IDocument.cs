using APIPortalLibraryPublisher.Models;
using Refit;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace APIPortalLibraryPublisher.Interfaces
{
    interface IDocument
    {
        //Get list of documents of an API
        [Headers("Accept:application/json")]
        [Get("/api/am/publisher/v0.14/apis/{apiId}/documents")]
        Task<ApiResponse<AllDocuments>> GetAllDocuments(
            [Header("Authorization")] string authorization,
            [AliasAs("apiId")] string apiId,
            [AliasAs("limit")] int limit = 25,
            [AliasAs("offset")] int offset = 0
            );

        //Add document to an API
        [Headers("Content-Type:application/json")]
        [Post("/api/am/publisher/v0.14/apis/{apiId}/documents")]
        Task<ApiResponse<Document>> AddDocument(
            [Header("Authorization")] string authorization,
            [AliasAs("apiId")] string apiId,
            [Body] string body
            );

        //Get the content of a document
        [Headers("Accept:application/json")]
        [Get("/api/am/publisher/v0.14/apis/{apiId}/documents/{documentId}/content")]
        Task<ApiResponse<string>> GetDocumentContent(
            [Header("Authorization")] string authorization,
            [AliasAs("apiId")] string apiId,
            [AliasAs("documentId")] string documentId
            );

        //Update a document of an API
        [Headers("Content-Type:application/json")]
        [Put("/api/am/publisher/v0.14/apis/{apiId}/documents/{documentId}")]
        Task<ApiResponse<Document>> UpdateDocument(
            [Header("Authorization")] string authorization,
            [AliasAs("apiId")] string apiId,
            [AliasAs("documentId")] string documentId,
            [Body] string body
            );

        //Get a document of an API
        [Headers("Accept:application/json")]
        [Get("/api/am/publisher/v0.14/apis/{apiId}/documents/{documentId}")]
        Task<ApiResponse<Document>> GetDocument(
            [Header("Authorization")] string authorization,
            [AliasAs("apiId")] string apiId,
            [AliasAs("documentId")] string documentId
            );

        //Delete document of an API
        [Delete("/api/am/publisher/v0.14/apis/{apiId}/documents/{documentId}")]
        Task<ApiResponse<Document>> DeleteDocument(
            [Header("Authorization")] string authorization,
            [AliasAs("apiId")] string apiId,
            [AliasAs("documentId")] string documentId
            );
    }
}
