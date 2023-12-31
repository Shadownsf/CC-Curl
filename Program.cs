// See https://aka.ms/new-console-template for more information
using CommandDotNet;

public class Program
{
    static int Main(string[] args)
    {
        return new AppRunner<Program>().Run(args);
    }

    [Subcommand]
    public Curl Curl { get; set; } = null!;
}

public class Curl
{
    [Command(Description = "Get")]
    public Task GET(string s)
    {
        Console.WriteLine(s);

        var subs = s.Split("/").ToList();
        subs.RemoveAt(1);
        
        var protocol = subs[0].AsSpan()[..subs[0].IndexOf(':')];
        var host = subs[1].AsSpan();

        Console.WriteLine(protocol.ToString());
        Console.WriteLine(host.ToString());

        for (int i = 2; i < subs.Count; i++)
        {
            Console.WriteLine(subs[i]);
        }

        return Task.CompletedTask;
    }

    [Command(Description = "Post")]
    public void POST(string s)
    {
        Console.WriteLine(s);
    }

    [Command(Description = "Put")]
    public void PUT(IConsole console)
    {
        console.WriteLine("here's the list of stash");
    }

    [Command(Description = "Delete")]
    public void DELETE(IConsole console)
    {
        console.WriteLine("here's the list of stash");
    }
}
