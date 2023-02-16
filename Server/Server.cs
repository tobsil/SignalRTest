using Microsoft.AspNetCore.SignalR;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSignalR();
builder.Services.AddSingleton(new ChatHub());

var app = builder.Build();
app.MapHub<ChatHub>("c");

app.Run();

public class ChatHub : Hub
{
    string _inst = Guid.NewGuid().ToString();
    public async Task<bool> SendMessage(string id)
    {
        await Task.Delay(100);
        //await Clients.All.SendAsync("ReceiveMessage", _inst, id);
        return true;
    }
}
