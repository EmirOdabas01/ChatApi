using ChatApi.BL.Interfaces;
using ChatApi.BL.Services;
using ChatApi.DA;
using ChatApi.DA.Interfaces;
using ChatApi.DA.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddCors(corsOption => corsOption.AddDefaultPolicy(options
    => options.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod()));

builder.Services.AddDbContext<ChatApiContext>(options => options.UseSqlite("Data Source=chat.db"));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IMessageRepository, MessageRepository>();
builder.Services.AddScoped<IMessageService, MessageService>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddHttpClient();

var app = builder.Build();
app.UseMiddleware<ChatApi.Api.Exceptions.ExceptionHandlingMiddleware>();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseHttpsRedirection();

app.UseAuthorization();
app.UseCors();

app.UseRouting();
app.MapControllers();

app.Run();
