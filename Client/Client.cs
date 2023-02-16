using Microsoft.AspNetCore.SignalR.Client;

var id = Guid.NewGuid().ToString();

var connection = new HubConnectionBuilder()
            .WithUrl("http://localhost:5057/c")
            .Build();

await connection.StartAsync();

List<Task<bool>> l = new();
for (int i = 0; i < 100; i++)
{
 //   Console.WriteLine($"calling send message {i}");
    l.Add(connection.InvokeAsync<bool>("SendMessage", $"{id}  --- call {i}"));
}

Console.WriteLine($"all invoked");
await Task.WhenAll(l);

//Console.WriteLine(string.Join(Environment.NewLine, l.Select(t => t.Result)));

Console.WriteLine($"End");
