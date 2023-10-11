using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

public class GetRequest
{
    static async Task Main(string[] args)
    {
        string baseUrl = "http://localhost:8090";
        string username = "admin";
        string password = "superadmin";

        using (HttpClient client = new HttpClient())
        {
            var byteArray = Encoding.ASCII.GetBytes($"{username}:{password}");
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(byteArray));

            try
            {
                string getResourceUrl = baseUrl + "/rest/apps/defaultApp/searchers/defaultElastic?q=*";
                HttpResponseMessage getResponse = await client.GetAsync(getResourceUrl);

                if (getResponse.IsSuccessStatusCode)
                {
                    string getResponseContent = await getResponse.Content.ReadAsStringAsync();
                    var responseObject = JsonConvert.DeserializeObject<ResponseObject>(getResponseContent);

                    if (responseObject != null && responseObject.documentList != null && responseObject.documentList.documents != null)
                    {
                        foreach (var document in responseObject.documentList.documents)
                        {
                            Console.WriteLine("Name: " + document.name);
                            Console.WriteLine ("Age:" + document.age);
                            Console.WriteLine ("Height:" + document.height);
                            Console.WriteLine ("Weight:" + document.weight);
                            Console.WriteLine ("Blood_type:" + document.blood_type);
                            Console.WriteLine ("City:" + document.city);
                            Console.WriteLine ("Email:" + document.email);
                            Console.WriteLine ("Phone:" + document.phone);
                            Console.WriteLine();
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Invalid HTTP status code: " + getResponse.StatusCode);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("API error: " + ex.Message);
            }
        }
    }

    public String Tmp(){
        return "asd";
    }

}

public class ResponseObject
{
    public DocumentList documentList { get; set; }
}

public class DocumentList
{
    public Document[] documents { get; set; }
}

public class Document
{
    public string name { get; set; }
    public string age { get; set; }
    public string height { get; set; }
    public string weight { get; set; }
    public string blood_type { get; set; }
    public string city { get; set; }
    public string email { get; set; }
    public string phone { get; set; }
    
}
