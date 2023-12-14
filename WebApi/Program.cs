using Application.Abstractions;
using Application.Posts.Commands;
using DataAccess;
using DataAccess.Repository;
using Microsoft.EntityFrameworkCore;
using WebApi;
using WebApi.Endpoints;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<AppDbContext>(opt =>
    opt.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")!));

builder.Services.AddScoped<IPostRepository, PostRepository>();
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblyContaining<CreatePostCommand>());

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

PostEndpoints.MapPostsEndpoints(app);

app.Run();