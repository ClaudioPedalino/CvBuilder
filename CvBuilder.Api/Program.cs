var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options => 
    options.AddPolicy("AppPolicy", policy => policy.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod()));

///
builder.Services.AddCvBuilderCore(builder.Configuration);

builder.Services.AddHttpContextAccessor();
///

var app = builder.Build();

app.UseMiddleware<ExceptionMiddleware>();

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();
app.UseCors("AppPolicy");
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();

app.Run();
