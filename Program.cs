using Microsoft.EntityFrameworkCore;
using Capstone_MVP.Data;
using Capstone_MVP.Handler;
using Microsoft.AspNetCore.Authentication;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<Capstone_MVPDBContext>(options => options.UseSqlite(builder.Configuration["Capstone_MVPConnection"]));
builder.Services.AddScoped<ICapstone_MVPRepo, Capstone_MVPRepo>();
builder.Services.AddAuthentication().AddScheme<AuthenticationSchemeOptions, Capstone_MVPAuthHandler>("MyAuthentication", null);
builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("AdminOnly", policy => policy.RequireClaim("admin"));
    options.AddPolicy("StudentOnly", policy => policy.RequireClaim("student"));
    options.AddPolicy("VisitorOnly", policy => policy.RequireClaim("visitor"));
});

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseCors(builder =>
{
    builder.AllowAnyOrigin()
           .AllowAnyMethod()
           .AllowAnyHeader();
});

app.UseAuthorization();

app.MapControllers();

app.Run();
