using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JsonToDocumentWindowsForm.Module
{
    public class AllDataResponseModel
    {
        public class Row
        {
            public string columName { get; set; }
            public string type { get; set; }
            public string example { get; set; }
        }

        public class DatasetJson
        {
            public string tableName { get; set; }
            public List<Row> rows { get; set; }
        }

        public class Document
        {
            public List<DatasetJson> datasetJson { get; set; }
        }
        public List<List<string>> classJson { get; set; }
        public Document document { get; set; }

    }
}
