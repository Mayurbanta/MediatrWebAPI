namespace VS2022Demo;

internal class Class1: IDisposable
{
    public void Dispose()
    {
        throw new NotImplementedException();
    }

    public string FirstName { get; set; }
    public string LastName { get; set; } = string.Empty;

    public Task<int> DoSomething(string str, string i, CancellationToken cancellationToken)
    {

        if (cancellationToken.IsCancellationRequested)
        {
            cancellationToken.ThrowIfCancellationRequested();
        }

        return Task.FromResult(0);
    }
}

public class Rootobject
{
    public Color[] Colors { get; set; }
}

public class Color
{
    public int numberKey { get; set; }
    public bool isPrimary { get; set; }
    public string[] listColors { get; set; }
}


