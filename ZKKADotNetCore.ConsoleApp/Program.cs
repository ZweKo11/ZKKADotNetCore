// See https://aka.ms/new-console-template for more information
using System.Data;
using System.Data.SqlClient;
using ZKKADotNetCore.ConsoleApp;

Console.WriteLine("Hello, World!");

/*SqlConnectionStringBuilder stringBuilder = new SqlConnectionStringBuilder();
stringBuilder.DataSource = "DESKTOP-49VCNU9"; //server name
stringBuilder.InitialCatalog = "DotNetTrainingBatch4";
stringBuilder.UserID = "sa";
stringBuilder.Password = "sa@123";
SqlConnection connection = new SqlConnection(stringBuilder.ConnectionString);
//SqlConnection connection = new SqlConnection("Data Source=DESKTOP-49VCNU9;Initial Catalog=DotNetTrainingBatch4;User ID=sa;Password=sa@123");
connection.Open();
Console.WriteLine("Connection open");

string query = "select * from tbl_blog";
SqlCommand cmd = new SqlCommand(query, connection);
SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(cmd);
DataTable dt = new DataTable();
sqlDataAdapter.Fill(dt);

connection.Close();
Console.WriteLine("Connection close");

//dataset => dataTable
//dataTable => dataRow
//dataRow => dataColumn
foreach (DataRow dr in dt.Rows)
{
    Console.WriteLine("Blog Id =>"+ dr["BlogId"]);
    Console.WriteLine("Blog Title =>" + dr["BlogTitle"]);
    Console.WriteLine("Blog Author =>" + dr["BlogAuthor"]);
    Console.WriteLine("Blog Content =>" + dr["BlogContent"]);
    Console.WriteLine("-----------------------------");
}*/
//Ado.Net Read

AdoDotNetExample adoDotNetExample = new AdoDotNetExample();
//adoDotNetExample.Read();
//adoDotNetExample.Create("title","author","content");
//adoDotNetExample.Update(12, "update title", "update author", "update content");
//adoDotNetExample.Delete(12);
adoDotNetExample.Edit(12);
adoDotNetExample.Edit(11);


Console.ReadKey();