using JSON2CSHARP.Models;
using JSON2CSHARP.Models.request;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Xamasoft.JsonClassGenerator;
using Xamasoft.JsonClassGenerator.CodeWriters;

namespace JSON2CSHARP.Controllers
{
    public class ValuesController : ApiController
    {
        // GET api/values
        [Route("api/ClassFromJson")]
        public IHttpActionResult GetClassFromJson(JsonToClassRequest input)
        {
            if(!checkFormat(input))
            {
                return BadRequest();
            }
            var gen = Prepare(input);
            List<List<string>> listStringClass = gen.GetClasses();
            return Ok(new { classJson = listStringClass});
        }

        // GET api/values/5
        [Route("api/DataSetFromJson")]
        public IHttpActionResult GetDataSetFromJson(JsonToClassRequest input)
        {
            if (!checkFormat(input))
            {
                return BadRequest();
            }
            var gen = Prepare(input);
            List<DataSet> listDataSet = gen.GetDataSet();
            DocumentResponse document = convertListDataSetToDocumentResponse(listDataSet);
            return Ok(document);
        }

        [Route("api/AllFromJson")]
        public IHttpActionResult GetAllFromJson(JsonToClassRequest input)
        {
            if (!checkFormat(input))
            {
                return BadRequest();
            }
            var gen = Prepare(input);
            List<List<string>> listStringClass = gen.GetClasses();
            List<DataSet> listDataSet = gen.getDataSetAfterProcess();
            DocumentResponse document = convertListDataSetToDocumentResponse(listDataSet);
            return Ok(new { classJson = listStringClass, document});
        }


        private DocumentResponse convertListDataSetToDocumentResponse(List<DataSet> listDataSet)
        {
            DocumentResponse documentResponse = new DocumentResponse();
            foreach(DataSet ds in listDataSet)
            {
                foreach (DataTable table in ds.Tables)
                {
                    DocumentResponse.DatasetJson dJson = new DocumentResponse.DatasetJson();
                    dJson.tableName = table.TableName;
                    foreach(DataRow row in table.Rows)
                    {
                        DocumentResponse.Row dRow = new DocumentResponse.Row();
                        if (table.Columns.Contains("ColumnName"))
                        {
                            dRow.columName = row["ColumnName"].ToString();
                        }
                        if (table.Columns.Contains("Example"))
                        {
                            dRow.example = row["Example"].ToString();
                        }
                        if (table.Columns.Contains("Type"))
                        {
                            dRow.type = row["Type"].ToString();
                        }
                        dJson.rows.Add(dRow);
                    }
                    documentResponse.datasetJson.Add(dJson);
                }
            }
            return documentResponse;
        }

        private bool checkFormat(JsonToClassRequest input)
        {
            if (input.JsonText == string.Empty)
            {
                //MessageBox.Show(this, "Please insert some sample JSON.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //edtJson.Focus();
                return false;
            }


            if (input.MainClass == string.Empty)
            {
                //MessageBox.Show(this, "Please specify a main class name.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }

        private JsonClassGenerator Prepare(JsonToClassRequest input)
        {

            var gen = new JsonClassGenerator();
            gen.Example = input.JsonText;
            gen.InternalVisibility = false;
            gen.CodeWriter = (ICodeWriter)new CSharpCodeWriter();
            gen.ExplicitDeserialization = false && gen.CodeWriter is CSharpCodeWriter;
            gen.Namespace = string.IsNullOrEmpty(input.Namespace) ? null : input.Namespace;
            gen.NoHelperClass = false;
            gen.SecondaryNamespace = true && !string.IsNullOrEmpty(input.SecondaryNamespace) ? input.SecondaryNamespace : null;
            gen.TargetFolder = "C:\\Users\\gt_cake\\Documents";
            gen.UseProperties = input.UseProperties;
            gen.MainClass = input.MainClass;
            gen.UsePascalCase = input.UsePascalCase;
            gen.UseNestedClasses = false;
            gen.ApplyObfuscationAttributes = false;
            gen.SingleFile = false;
            gen.ExamplesInDocumentation = input.ExamplesInDocumentation;
            return gen;
        }
    }
}
