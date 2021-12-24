using System;
using System.Collections.Generic;
using System.Text;

namespace APIPortalLibraryPublisher.Models
{
    public class Application
    {
        public string applicationId { get; set; }
        public string name { get; set; }
        public string subscriber { get; set; }
        public string throttlingTier { get; set; }
        public string description { get; set; }
        public string groupId { get; set; }
    }
}
