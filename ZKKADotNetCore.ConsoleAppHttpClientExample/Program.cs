// See https://aka.ms/new-console-template for more information
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using ZKKADotNetCore.ConsoleAppHttpClientExample;

Console.WriteLine("Hello, World!");

/*HttpClient client = new HttpClient();
var response = await client.GetAsync("http://localhost:5095/api/blog");
if (response.IsSuccessStatusCode)
{
    var jsonStr = await response.Content.ReadAsStringAsync();
    Console.WriteLine(jsonStr);
    List<BlogModel> lst = JsonConvert.DeserializeObject<List<BlogModel>>(jsonStr)!;
    foreach (var blog in lst)
    {
        Console.WriteLine(JsonConvert.SerializeObject(blog));
        Console.WriteLine($"Title => {blog.BlogTitle}");
        Console.WriteLine($"Author => {blog.BlogAuthor}");
        Console.WriteLine($"Content => {blog.BlogContent}");
    }
}*/

HttpClientExample httpClientExample = new HttpClientExample();
await httpClientExample.RunAsync();
Console.ReadLine();