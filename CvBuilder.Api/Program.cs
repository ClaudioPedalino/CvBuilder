public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddControllers().AddNewtonsoftJson(options =>
            options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);

        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        builder.Services.AddCors(options =>
            options.AddPolicy("AppPolicy", policy => policy.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod()));

        builder.Services.AddCvBuilderCore(builder.Configuration);


        var app = builder.Build();

        app.AddCvBuilderCoreApp(builder.Configuration); //*
        app.UseSwagger();
        app.UseSwaggerUI();
        app.UseHttpsRedirection();
        app.UseCors("AppPolicy");
        app.UseAuthentication();
        app.UseAuthorization();
        app.MapControllers();

        app.Run();
    }
}
