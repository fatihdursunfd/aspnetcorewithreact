using aspnetserver.Data;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

//builder.Services.AddCors(options =>
//{
//    options.AddPolicy("CORSPolicy",builder =>
//    {
//        builder.AllowAnyMethod()
//                .AllowAnyHeader()
//                .WithOrigins("http://localhost:3001" , "https://appname.azurestaticapps.net");
//    }); 
//});

builder.Services.AddCors(options =>
{
    options.AddPolicy(MyAllowSpecificOrigins,
                          policy =>
                          {
                              policy.WithOrigins("http://localhost:3001", "https://ashy-grass-0016f2010.1.azurestaticapps.net")
                                                  .AllowAnyHeader()
                                                  .AllowAnyMethod();
                          });
});

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(
        swaggerGenOptions =>
        {
            swaggerGenOptions.SwaggerDoc("v1", new OpenApiInfo { Title = "ASP NET CORE WITH REACT", Version = "v1" });
        }
    );

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI(swaggerUIOptions =>
{
    swaggerUIOptions.DocumentTitle = "ASP NET CORE WITH REACT";
    swaggerUIOptions.SwaggerEndpoint("/swagger/v1/swagger.json", "Web api serving a post model for react app");
    swaggerUIOptions.RoutePrefix = string.Empty;    
});

app.UseHttpsRedirection();

//app.UseCors("CORSPolicy");
app.UseCors(MyAllowSpecificOrigins);

app.MapGet("get-all-posts", async () => await PostRepo.GetPostsAsync())
        .WithTags("Posts Endpoints");

app.MapGet("get-post-by-id/{id}", async (int id) =>
{
    Post post = await PostRepo.GetPostByIDAsync(id);
    if (post is not null)
        return Results.Ok(post);
    else
        return Results.BadRequest();
}).WithTags("Posts Endpoints"); ;


app.MapPost("create-post", async (Post Post) =>
{
    var post = await PostRepo.CreatePostAsync(Post);
    if (post is not null)
        return post;
    else
        return null;

}).WithTags("Posts Endpoints");


app.MapPut("update-post", async (Post Post) =>
{
    bool isSucccesfull = await PostRepo.UpdatePostAsync(Post);
    if (isSucccesfull)
        return Results.Ok("Updated succesfully");
    else
        return Results.BadRequest();

}).WithTags("Posts Endpoints");


app.MapDelete("delete-post-by-id/{id}", async (int id) =>
{

    bool isSucccesfull = await PostRepo.DeletePostAsync(id);
    if (isSucccesfull)
        return Results.Ok("Deleted succesfully");
    else
        return Results.BadRequest();

}).WithTags("Posts Endpoints");

app.Run();

