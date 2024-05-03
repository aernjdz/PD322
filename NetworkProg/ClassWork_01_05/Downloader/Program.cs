internal class Program
{
    static string desctopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
    const string img1 = @"https://img.freepik.com/free-vector/gradient-summer-illustration_23-2148946644.jpg?size=338&ext=jpg&ga=GA1.1.553209589.1714521600&semt=sph";
    const string img2 = @"https://advancelocal-adapter-image-uploads.s3.amazonaws.com/image.pennlive.com/home/penn-media/width2048/img/wildaboutpa/photo/summer-sunrisejpg-8a3de64ee9c00a6e.jpg";


    private static async Task Main(string[] args)
    {
        HttpClient client = new HttpClient();
        HttpRequestMessage message = new HttpRequestMessage() { 
            Method = HttpMethod.Get,
            RequestUri = new Uri(img1),
        };
        var response = await client.SendAsync(message);
        Console.WriteLine($"{response.StatusCode}");

        using (FileStream fs = new FileStream(desctopPath+ "/image.jpg", FileMode.Create))
        {
            await response.Content.CopyToAsync(fs);
        }

    }
}
