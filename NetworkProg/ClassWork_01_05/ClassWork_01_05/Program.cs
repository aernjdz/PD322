using Newtonsoft.Json;
using System.Text;
class Post
{
    public string Title { get; set; }
    public string Body { get; set; }
    public int UserId { get; set; }
}
internal class Program
{

    private static async Task Main(string[] args)
    {
        //Get
        /*   string url = @"https://jsonplaceholder.typicode.com/users";

           using (HttpClient client = new HttpClient())
           {
               var response = await client.GetAsync(url);
               Console.WriteLine($"Status :: {response.StatusCode}");
               var result = await response.Content.ReadAsStringAsync();

               Console.WriteLine(result);
           }*/

        //Post
        var post = new Post()
        {
            Title = "BlaTitle",
            Body = "Blabody",
            UserId = 1
        };

        var json = JsonConvert.SerializeObject(post);

        var data = new StringContent(json, Encoding.UTF8, "application/json");

        string url = @"https://jsonplaceholder.typicode.com/users";


        using var client = new HttpClient();
        var response = await client.PostAsync(url,data);

        Console.WriteLine($"Status :: {response.StatusCode}");
        var result = await response.Content.ReadAsStringAsync();
        Console.WriteLine(result);
    }
}