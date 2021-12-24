using APIPortalLibraryPublisher.Models;
using Refit;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace APIPortalLibraryPublisher.Interfaces
{
    interface ISubscription
    {
        //Get all subscriptions
        [Headers("Accept:application/json")]
        [Get("/api/am/publisher/v0.14/subscriptions")]
        Task<ApiResponse<AllSubscriptions>> GetAllSubscriptions(
            [Header("Authorization")] string authorization,
            [AliasAs("apiId")] string apiId,
            [AliasAs("limit")] int limit = 25,
            [AliasAs("offset")] int offset = 0
            );

        //Get details of a subscription
        [Headers("Accept:application/json")]
        [Get("/api/am/publisher/v0.14/subscriptions/{subscriptionId}")]
        Task<ApiResponse<Subscription>> GetSubscriptionsDetails(
            [Header("Authorization")] string authorization,
            [AliasAs("subscriptionId")] string subscriptionId
            );

        //Block a subscription
        [Headers("Accept:application/json")]
        [Post("/api/am/publisher/v0.14/subscriptions/block-subscription")]
        Task<ApiResponse<Subscription>> BlockSubscription(
            [Header("Authorization")] string authorization,
            [AliasAs("subscriptionId")] string subscriptionId,
            [AliasAs("blockState")] string blockState
            );

        //UnBlock a subscription
        [Headers("Accept:application/json")]
        [Post("/api/am/publisher/v0.14/subscriptions/unblock-subscription")]
        Task<ApiResponse<Subscription>> UnblockSubscription(
            [Header("Authorization")] string authorization,
            [AliasAs("subscriptionId")] string subscriptionId
            );
    }
}
