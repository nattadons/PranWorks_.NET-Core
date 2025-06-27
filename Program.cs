using TaskManagementAPI.Services;

var builder = WebApplication.CreateBuilder(args);

// Load CORS Origins from config
var allowedOrigins = builder.Configuration
    .GetSection("CORS:AllowedOrigins")
    .Get<string[]>();

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Register TaskService
builder.Services.AddScoped<ITaskService, TaskService>();

// Add CORS policy from appsettings.json
builder.Services.AddCors(options =>
{
    options.AddPolicy("ReactApp", policy =>
    {
        policy.WithOrigins(allowedOrigins)
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// Enable CORS with loaded policy
app.UseCors("ReactApp");

app.UseAuthorization();

app.MapControllers();

app.Run();
