using Application.Posts.Commands;
using Application.Posts.Queries;
using MediatR;
using WebApi.Requests;

namespace WebApi.Endpoints;

public abstract class PostEndpoints
{
    private const string BaseEndpoint = "/api/posts";
    
    public static void MapPostsEndpoints(WebApplication app)
    {
        app.MapGet(BaseEndpoint, async (IMediator mediator) =>
        {
            var query = new GetAllPosts();
            var result = await mediator.Send(query);
            return result==null! ? Results.NotFound() : Results.Ok(result);
        }).WithName(nameof(GetAllPosts));

        
        app.MapGet($"{BaseEndpoint}/{{id:guid}}", async (IMediator mediator, Guid id) =>
        {
            var query = new GetPostById(id);
            var result = await mediator.Send(query);
            return result==null! ? Results.NotFound() : Results.Ok(result);
        }).WithName(nameof(GetPostById));
        
        
        app.MapPost(BaseEndpoint, async (IMediator mediator, CreatePostRequest post) =>
        {
            var createPost = new CreatePostCommand { Content = post.Content };
            var result = await mediator.Send(createPost);
            return Results.CreatedAtRoute(nameof(GetPostById), new {result.Id}, result);
        });
        
        app.MapPut($"{BaseEndpoint}/{{id:guid}}", async (IMediator mediator, Guid id, UpdatePostRequest request) =>
        {
            var createPost = new UpdatePostCreatePostCommand { PostId = id, Content = request.Content };
            var result = await mediator.Send(createPost);
            
            if (result!=null!) Results.BadRequest();
            
            Results.NoContent();
        });
        
        app.MapDelete($"{BaseEndpoint}/{{id:guid}}", async (IMediator mediator, Guid id) =>
        {
            var query = new DeletePostCommand(id);
            var result = await mediator.Send(query);
            return Results.Ok(new {success = result});
        });
    }
}