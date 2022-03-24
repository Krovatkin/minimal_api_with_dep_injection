var builder = WebApplication.CreateBuilder(args);
builder.Services.AddScoped<IMyDependency, MyDependency>();
var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.MapGet("/dep", (IMyDependency dep) => {
    dep.WriteMessage("Boo!");
    return "Hello World!";
});

app.Run();

public interface IMyDependency
{
    void WriteMessage(string message);
}

public class MyDependency: IMyDependency
{
    public void WriteMessage(string message)
    {
        Console.WriteLine($"MyDependency.WriteMessage Message: {message}");
    }
}
