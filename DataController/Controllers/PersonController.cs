using System.Net.Http.Headers;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace DataController.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PersonController : ControllerBase
{
    [HttpGet("getData")]
    public async Task<IActionResult> GetData()
    {
        // Kopiera din befintliga C#-kod här från GetRequest.cs

        // Lägg till logiken för att hämta data
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
                    var people = new List<Person>();

                    if (responseObject != null && responseObject.documentList != null && responseObject.documentList.documents != null)
                    {
                        foreach (var document in responseObject.documentList.documents)
                        {
                            Console.WriteLine("Name: " + document.name);
                            Console.WriteLine("Age:" + document.age);
                            Console.WriteLine("Height:" + document.height);
                            Console.WriteLine("Weight:" + document.weight);
                            Console.WriteLine("Blood_type:" + document.blood_type);
                            Console.WriteLine("City:" + document.city);
                            Console.WriteLine("Email:" + document.email);
                            Console.WriteLine("Phone:" + document.phone);
                            Console.WriteLine();
                        }
                    }

                    
                }
                else
                {
                    Console.WriteLine( getResponse.StatusCode);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("API error: " + ex.Message);
            }
        }

        // Här kan du returnera data till klienten som JSON
        return Ok(new { message = "Data from C# method." });
    }
}
