using System.Buffers.Text;
using System.Net.Sockets;
using System.Text;

Console.WriteLine("IIS Replica - Starting Up...");
Console.WriteLine("Week 1: Building HTTP client excercises first");
Console.WriteLine();

// http client exercise goes here
string host = "example.com";
int port = 80;
using TcpClient client = new TcpClient();
Console.WriteLine($"Connecting to {host}:{port}...");

await client.ConnectAsync(host, port);
var stream = client.GetStream();
var request = $"GET / HTTP/1.1\r\n" +
            $"Host: {host}\r\n" +
            $"\r\n";

byte[] requestBytes = Encoding.UTF8.GetBytes(request);
await stream.WriteAsync(requestBytes, 0, requestBytes.Length);
Console.WriteLine("Connected to server!");

byte[] buffer = new byte[4096];

int byteRead = await stream.ReadAsync(buffer, 0, buffer.Length);

string response = Encoding.UTF8.GetString(buffer, 0, byteRead);

string httpVersion = "";
int statusCode = 0;
string reasonPhrase = "";

var lines = response.Split("\r\n");
var statusLine = lines[0];
var statusParts = statusLine.Split(" ");

httpVersion = statusParts[0];
statusCode = int.Parse(statusParts[1]);
reasonPhrase = statusParts[2];

Console.WriteLine($"Status: {statusCode}");
Console.WriteLine($"Version: {httpVersion}");
Console.WriteLine($"Reason: {reasonPhrase}");

Console.WriteLine("\nHeaders:");
for(var i = 1; i < lines.Length; i++)
{
    string line = lines[i];

    if(string.IsNullOrEmpty(line))
    {
        Console.WriteLine("\n ---Body starts at line " + (i + 1) + "----" );
        string body = string.Join("\r\n", lines.Skip(i + 1));
        Console.WriteLine("\nBody: \r\n");
        Console.WriteLine(body);

        break;
    }

    var headers = line.Split(":", 2);
    if(headers.Length == 2)
    {
        Console.WriteLine($"{headers[0].Trim()}: {headers[1].Trim()}");
    }
}


Console.WriteLine("Press any key to exit...");
Console.ReadKey();