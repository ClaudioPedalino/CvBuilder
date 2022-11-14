public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddApiConfiguration();
        builder.Services.AddCvBuilderCore(builder.Configuration);

        var app = builder.Build();

        app.AddCvBuilderCoreApp(builder.Configuration);
        app.AddAppConfiguration();

        app.Run();
    }
}
