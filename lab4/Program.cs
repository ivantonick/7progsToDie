using Microsoft.EntityFrameworkCore;
using WebApplication1.Database;
using WebApplication1.Repository;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<WebContext>(options =>
{
    options.UseSqlite(builder.Configuration.GetConnectionString("DB"));
});


builder.Services.AddTransient<IWebRepository, WebRepository>();

builder.Services.AddControllers();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// app.UseHttpsRedirection();

app.MapControllers();

app.Run();