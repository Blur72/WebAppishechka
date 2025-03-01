using Microsoft.EntityFrameworkCore;
using WebAppishechka.Interfaces;
using WebAppishechka.Service;
using WebAppishechka.DataBaseContext;
using WebAppishechka.Hubs;
using WebAppishechka.Model;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ContextDB>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("TestDbString")), ServiceLifetime.Scoped);

builder.Services.AddScoped<IMovieService, MovieService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IChatMessage, ChatService>();
builder.Services.AddScoped<IUserChat, UserChatService>();

builder.Services.AddSignalR();



var app = builder.Build();

app.MapHub<ChatHub>("/chatHub");
app.MapHub<GeneralChatHub>("/generalHub");
app.MapHub<GeneralChatHub>("/userChatHub");

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
