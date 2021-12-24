using APIPortalLibraryPublisher.Models;
using Newtonsoft.Json.Linq;
using Refit;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace APIPortalLibraryPublisher.Interfaces
{
    interface IAPI
    {
        //Get all apis
        [Headers("Accept:application/json")]
        [Get("/api/am/publisher/v0.14/apis")]
        Task<ApiResponse<AllApis>> GetAllApis(
            [Header("Authorization")] string authorization,
            [AliasAs("limit")] int limit = 25,
            [AliasAs("offset")] int offset = 0,
            [AliasAs("query")] string query = ""
            );

        //Get details of an api
        [Headers("Accept:application/json")]
        [Get("/api/am/publisher/v0.14/apis/{apiId}")]
        Task<ApiResponse<API>> GetApiDetails(
            [Header("Authorization")] string authorization,
            [AliasAs("apiId")] string apiId
            );

        //Add an API
        [Headers("Content-Type:application/json")]
        [Post("/api/am/publisher/v0.14/apis")]
        Task<ApiResponse<API>> AddApi(
            [Header("Authorization")] string authorization,
            [Body] API body
            );

        //Add new API version
        [Post("/api/am/publisher/v0.14/apis/copy-api")]
        Task<ApiResponse<API>> AddApiVersion(
            [Header("Authorization")] string authorization,
            [AliasAs("newVersion")] string newVersion,
            [AliasAs("apiId")] string apiId
            );

        //Update an API
        [Headers("Content-Type:application/json")]
        [Put("/api/am/publisher/v0.14/apis/{apiId}")]
        Task<ApiResponse<API>> UpdateApi(
            [Header("Authorization")] string authorization,
            [Body] API body,
            [AliasAs("apiId")] string apiId
            );

        //Change API Status
        [Post("/api/am/publisher/v0.14/apis/change-lifecycle")]
        Task<ApiResponse<API>> ChangeApiStatus(
            [Header("Authorization")] string authorization,
            [AliasAs("action")] string action,
            [AliasAs("apiId")] string apiId
            );

        //Delete API
        [Delete("/api/am/publisher/v0.14/apis/{apiId}")]
        Task<ApiResponse<API>> DeleteApi(
            [Header("Authorization")] string authorization,
            [AliasAs("apiId")] string apiId
            );

        //Get Swagger definition
        [Headers("Accept:application/json")]
        [Get("/api/am/publisher/v0.14/apis/{apiId}/swagger")]
        Task<ApiResponse<string>> GetSwaggerDefinition(
            [Header("Authorization")] string authorization,
            [AliasAs("apiId")] string apiId
            );

        //Update Swagger definition
        [Multipart]
        [Headers("Content-Type:multipart/form-data", "Content-Disposition:form-data")]
        [Put("/api/am/publisher/v0.14/apis/{apiId}/swagger")]
        Task<ApiResponse<string>> UpdateSwaggerDefinition(
            [Header("Authorization")] string authorization,
            [AliasAs("apiId")] string apiId,
            [AliasAs("apiDefinition")] string apiDefinition
            );
    }
}
