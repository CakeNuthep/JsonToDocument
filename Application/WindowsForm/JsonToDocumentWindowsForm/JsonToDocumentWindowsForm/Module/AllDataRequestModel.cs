using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JsonToDocumentWindowsForm.Module
{
    public class AllDataRequestModel
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
