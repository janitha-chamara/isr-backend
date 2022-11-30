using BusinessLogic.Interfaces;
using BusinessLogic.Services;
using ISRDataAccess.Interface;
using ISRDataAccess.Services;

var policyName = "_myAllowSpecificOrigins";

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: policyName,
        policyBuilder =>
        {
            policyBuilder
                .WithOrigins("http://localhost:8080") // specifying the allowed origin

                .WithMethods("GET") // defining the allowed HTTP method
                .AllowAnyHeader() // allowing any header to be sent
            .AllowAnyMethod()
            .AllowAnyOrigin();
        });
});

builder.Services.AddControllers();

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IJobService, JobService>();
builder.Services.AddScoped<IJobDal, JobDal>();

builder.Services.AddScoped<ITaskService, TaskService>();
builder.Services.AddScoped<ITaskDal, TaskDal>();





var app = builder.Build();

//Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(policyName);

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();