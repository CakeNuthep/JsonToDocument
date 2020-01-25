using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JSON2CSHARP.Models.request
{
    public class JsonToClassRequest
    {
        public string JsonText { get; set; }
        public string Namespace { get; set; }
        public string MainClass { get; set; }
        public string SecondaryNamespace { get; set; }
        public bool UseProperties { get; set; }
        public bool UsePascalCase { get; set; }
        public bool ExamplesInDocumentation { get; set; }
    }
}