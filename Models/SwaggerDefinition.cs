using System;
using System.Collections.Generic;
using System.Text;

namespace APIPortalLibraryPublisher.Models
{
    public class SwaggerDefinition
    {
       public List<Path> paths { get; set; }
    }

    public class Path
    {
        public string path { get; set; }
        public List<Method> method { get; set; }

    }

    public class Method
    {
        public string method { get; set; }
        public string x_auth_type { get; set; }
        public string x_throttling_tier { get; set; }
        public string method_description { get; set; }
        public List<Parameter> parameters { get; set; }
        public List<Response> responses { get; set; }
    }

    public class Parameter
    {
        public string parameter_description { get; set; }
        public string name { get; set; }
        public bool required { get; set; }
        public string in_ { get; set; }
    }

    public class Response
    {
        public RespCode code { get; set; }
    }

    public class RespCode
    {
        public string code { get; set; }
        public string description { get; set; }
    }
}
