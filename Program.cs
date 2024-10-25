using WTelegram;

class Program
{
    static async Task Main(string[] _)
    {
        using var client = new Client();
        var myself = await client.LoginUserIfNeeded();
        Console.WriteLine($"We are logged-in as {myself} (id {myself.id})");

        await CommandList.ShowCommandList(client);
    }
}