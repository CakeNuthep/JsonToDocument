using JsonToDocumentWindowsForm.Module;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JsonToDocumentWindowsForm
{
    public class Json2csharpAPI
    {
        static public AllDataResponseModel getData(string url,AllDataRequestModel input)
        {
            ////var client = new RestClient("https://localhost:44312/api/AllFromJson");
            var client = new RestClient(url);
            client.Timeout = -1;
            var request = new RestRequest(Method.POST);
            request.AddHeader("Content-Type", "application/json");
            string json = JsonConvert.SerializeObject(input);
            request.AddParameter("application/json", json, ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);

            //var client = new RestClient("https://localhost:44312/api/AllFromJson");
            //client.Timeout = -1;
            //var request = new RestRequest(Method.POST);
            //request.AddHeader("Content-Type", "application/json");
            //request.AddParameter("application/json", "{\"JsonText\":\"{\\n    \\\"name\\\": \\\"cake\\\",\\n    \\\"level\\\": {\\n        \\\"current\\\": 80,\\n        \\\"max\\\": 99\\n    }\\n}\",\"Namespace\":\"Example\",\"MainClass\":\"SampleResponse1\",\"SecondaryNamespace\":\"SampleResponse1JsonTypes\",\"UseProperties\":true,\"UsePascalCase\":true,\"ExamplesInDocumentation\":true}", ParameterType.RequestBody);
            //IRestResponse response = client.Execute(request);
            ////Console.WriteLine(response.Content);

            try
            {
                return JsonConvert.DeserializeObject<AllDataResponseModel>(response.Content);
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
