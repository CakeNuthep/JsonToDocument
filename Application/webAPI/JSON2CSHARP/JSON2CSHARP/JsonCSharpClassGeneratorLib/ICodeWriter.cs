using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;

namespace Xamasoft.JsonClassGenerator
{
    public interface ICodeWriter
    {
        string FileExtension { get; }
        string DisplayName { get; }
        string GetTypeName(JsonType type, IJsonClassGeneratorConfig config);
        void WriteClass(IJsonClassGeneratorConfig config, TextWriter sw, JsonType type);
        List<string> GetClass(IJsonClassGeneratorConfig config, JsonType type);
        void WriteFileStart(IJsonClassGeneratorConfig config, TextWriter sw);
        List<string> GetFileStart(IJsonClassGeneratorConfig config);
        void WriteFileEnd(IJsonClassGeneratorConfig config, TextWriter sw);
        List<string> GetFileEnd(IJsonClassGeneratorConfig config);
        void WriteNamespaceStart(IJsonClassGeneratorConfig config, TextWriter sw, bool root);
        List<string> GetNamespaceStart(IJsonClassGeneratorConfig config, bool root);
        void WriteNamespaceEnd(IJsonClassGeneratorConfig config, TextWriter sw, bool root);
        List<string> GetNamespaceEnd(IJsonClassGeneratorConfig config, bool root);
        DataTable GetDataTable(IJsonClassGeneratorConfig config, JsonType type);
    }
}
