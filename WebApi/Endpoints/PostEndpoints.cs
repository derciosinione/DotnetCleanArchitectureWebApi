using Application.Posts.Commands;
using Application.Posts.Queries;
using MediatR;
using WebApi.Abstractions;
using WebApi.Requests;

namespace WebApi.Endpoints;

public class PostEndpoints : IEndpointDefinitions
{
    private const string BaseEndpoint = "/api/posts";
    public void RegisterEndpoints(WebApplication app)
    {
        var api = app.MapGroup(BaseEndpoint);
        
        api.MapGet(string.Empty, GetAllPosts).WithName(nameof(GetAllPostsQuery));
        
        api.MapGet("/{id:guid}", GetPostById).WithName(nameof(GetPostByIdQuery));
        
        api.MapPost(string.Empty, CreatedPost);
        
        api.MapPut("/{id:guid}", UpdatePost);
        
        api.MapDelete("/{id:guid}", DeletePost);
    }
    
    private static async Task<IResult> GetPostById(ISender mediator, Guid id, CancellationToken cancellationToken)
    {
        var query = new GetPostByIdQuery(id);
        var result = await mediator.Send(query, cancellationToken);
        return result==null! ? Results.NotFound() : Results.Ok(result);
    }

    private static async Task<IResult> GetAllPosts(ISender mediator, CancellationToken cancellationToken)
    {
        var query = new GetAllPostsQuery();
        var result = await mediator.Send(query, cancellationToken);
        return result==null! ? TypedResults.NotFound() : TypedResults.Ok(result);
    }
    
    private static async Task UpdatePost(Guid id, UpdatePostRequest request, ISender mediator,
        CancellationToken cancellationToken)
    {
        var createPost = new UpdatePostPostCommand { PostId = id, Content = request.Content };
        var result = await mediator.Send(createPost, cancellationToken);
            
        if (result!=null!) Results.BadRequest();
            
        Results.NoContent();
    }

    private static async Task<IResult> CreatedPost(CreatePostRequest post, ISender mediator,
        CancellationToken cancellationToken)
    {
        var createPost = new CreatePostCommand { Content = post.Content };
        var result = await mediator.Send(createPost, cancellationToken);
        return Results.CreatedAtRoute(nameof(GetPostByIdQuery), new {result.Id}, result);
    }
    
    private static async Task<IResult> DeletePost(Guid id, ISender mediator, CancellationToken cancellationToken)
    {
        var query = new DeletePostCommand(id);
        var success = await mediator.Send(query, cancellationToken);
        return TypedResults.Ok(new {success});
    }
    
}