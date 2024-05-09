// See https://aka.ms/new-console-template for more information
using Newtonsoft.Json;
using System.Text.Json.Serialization;

Console.WriteLine("Hello, World!");

String jsonStr = await File.ReadAllTextAsync("data.json");
var model = JsonConvert.DeserializeObject<MainDto>(jsonStr);

Console.WriteLine(jsonStr);

//Myanmar number to English number
//static string ChangeNum(string num)
//{
//    num = num.Replace("၁၁", "11");
//    return num;
//}

foreach (var num in model.questions)
{
    Console.WriteLine(num.questionNo);
}

Console.ReadLine();


public class MainDto
{
    public Question[] questions { get; set; }
    public Answer[] answers { get; set; }
    public string[] numberList { get; set; }
}

public class Question
{
    public int questionNo { get; set; }
    public string questionName { get; set; }
}

public class Answer
{
    public int questionNo { get; set; }
    public int answerNo { get; set; }
    public string answerResult { get; set; }
}

