using System;
using System.Collections.Generic;
using System.Text;

namespace APIPortalLibraryPublisher.Models
{
    public class API
    {
        public string id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public string context { get; set; }
        public string version { get; set; }
        public string provider { get; set; }
        public string status { get; set; }
        public string responseCaching { get; set; }
        public int cacheTimeout { get; set; }
        public List<string> visibleRoles { get; set; } 
        public bool isDefaultVersion { get; set; }
        public string type { get; set; }
        public string thumbnailUri { get; set; }
        public string apiDefinition { get; set; }
        public List<string> transport { get; set; }
        public MaxTps maxTps { get; set; }
        public string authorizationHeader { get; set; }
        public string visibility { get; set; }
        public string endpointConfig { get; set; }
        public EndpointSecurity endpointSecurity { get; set; }
        public string gatewayEnvironments { get; set; }
        public List<Sequence> sequences { get; set; }
        public BusinessInformation businessInformation { get; set; }
        public CorsConfiguration corsConfiguration { get; set; }
        public List<string> tags { get; set; }
        public List<string> tiers { get; set; }
    }

    public class AllApis
    {
        public int count { get; set; }
        public string next { get; set; }
        public string previous { get; set; }
        public List<API> list { get; set; }
        public Pagination pagination { get; set; }
    }

    public class Pagination
    {
        public int total { get; set; }
        public int offset { get; set; }
        public int limit { get; set; }
    }

    public class BusinessInformation
    {
        public string technicalOwnerEmail { get; set; }
        public string businessOwnerEmail { get; set; }
        public string businessOwner { get; set; }
        public string technicalOwner { get; set; }
    }

    public class MaxTps
    {
        public int sandbox { get; set; }
        public int production { get; set; }
    }

    public class EndpointSecurity
    {
        public string username { get; set; }
        public string type { get; set; }
        public string password { get; set; }
    }

    public class Sequence
    {
        public string name { get; set; }
        public string type { get; set; }
    }

    public class CorsConfiguration
    {
        public List<string> accessControlAllowOrigins { get; set; }
        public List<string> accessControlAllowHeaders { get; set; }
        public List<string> accessControlAllowMethods { get; set; }
        public bool accessControlAllowCredentials { get; set; }
        public bool corsConfigurationEnabled { get; set; }
    }
}
