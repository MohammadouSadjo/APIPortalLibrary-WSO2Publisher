using System;
using System.Collections.Generic;
using System.Text;

namespace APIPortalLibraryPublisher.Configuration
{
    static class Config
    {
        //Baseurl of the application
        public static string baseUrl = "https://localhost:9443";

        //Body Request of Login API
        public static string bodyRequestLogin = "{\"callbackUrl\": \"www.google.lk\"," +
                        "\"clientName\": \"rest_api_publisher\"," +
                        "\"owner\": \"admin\"," +
                        "\"grantType\": \"password refresh_token\"," +
                        "\"saasApp\": true}";

        // Get and Set user's data for authentification
        public static class UserInfos
        {
            internal static string accessToken;

            public static string clientId { get; set; }
            public static string clientSecret { get; set; }
            public static string accessTokenApiView { get; set; }
            public static string accessTokenCreate { get; set; }
            public static string accessTokenPublish { get; set; }
            public static string accessTokenSubscriptionView { get; set; }
            public static string accessTokenSubscriptionBlock { get; set; }
        }
    }
}
