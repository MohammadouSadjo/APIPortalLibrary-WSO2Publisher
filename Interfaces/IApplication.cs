using APIPortalLibraryPublisher.Models;
using Refit;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace APIPortalLibraryPublisher.Interfaces
{
    interface IApplication
    {
        //Get details of an application
        [Headers("Accept:application/json")]
        [Get("/api/am/publisher/v0.14/applications/{applicationId}")]
        Task<ApiResponse<Application>> GetApplicationDetails(
            [Header("Authorization")] string authorization,
            [AliasAs("applicationId")] string applicationId
            );
    }
}
