using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JSON2CSHARP.Models
{
    public class DocumentResponse
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
            public DatasetJson()
            {
                rows = new List<Row>();
            }
        }
        public List<DatasetJson> datasetJson { get; set; }

        public DocumentResponse()
        {
            datasetJson = new List<DatasetJson>();
        }
    }
}