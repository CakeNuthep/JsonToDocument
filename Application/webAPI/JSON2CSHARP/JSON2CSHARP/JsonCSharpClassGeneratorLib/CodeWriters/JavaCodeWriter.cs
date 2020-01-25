using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;

namespace Xamasoft.JsonClassGenerator.CodeWriters
{
    public class JavaCodeWriter : ICodeWriter
    {
        public string FileExtension
        {
            get { return ".java"; }
        }

        public string DisplayName
        {
            get { return "Java"; }
        }

        public string GetTypeName(JsonType type, IJsonClassGeneratorConfig config)
        {
            throw new NotImplementedException();
        }

        public void WriteClass(IJsonClassGeneratorConfig config, TextWriter sw, JsonType type)
        {
            throw new NotImplementedException();
        }

        public void WriteFileStart(IJsonClassGeneratorConfig config, TextWriter sw)
        {
            foreach (var line in JsonClassGenerator.FileHeader)
            {
                sw.WriteLine("// " + line);
            }
        }

        public void WriteFileEnd(IJsonClassGeneratorConfig config, TextWriter sw)
        {
            throw new NotImplementedException();
        }

        public void WriteNamespaceStart(IJsonClassGeneratorConfig config, TextWriter sw, bool root)
        {
            throw new NotImplementedException();
        }

        public void WriteNamespaceEnd(IJsonClassGeneratorConfig config, TextWriter sw, bool root)
        {
            throw new NotImplementedException();
        }

        public List<string> GetClass(IJsonClassGeneratorConfig config, TextWriter sw, JsonType type)
        {
            throw new NotImplementedException();
        }

        public List<string> GetFileStart(IJsonClassGeneratorConfig config, TextWriter sw)
        {
            throw new NotImplementedException();
        }

        public List<string> GetFileEnd(IJsonClassGeneratorConfig config, TextWriter sw)
        {
            throw new NotImplementedException();
        }

        public List<string> GetNamespaceStart(IJsonClassGeneratorConfig config, TextWriter sw, bool root)
        {
            throw new NotImplementedException();
        }

        public List<string> GetNamespaceEnd(IJsonClassGeneratorConfig config, TextWriter sw, bool root)
        {
            throw new NotImplementedException();
        }

        public DataTable GetDataTable(IJsonClassGeneratorConfig config, JsonType type)
        {
            throw new NotImplementedException();
        }
    }
}
