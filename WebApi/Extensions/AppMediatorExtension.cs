using Application.Posts.Commands;

namespace WebApi.Extensions;

public static class AppMediatorExtension
{
    public static void RegisterApiMediatorInjection(this WebApplicationBuilder builder)
    {
        builder.Services.AddMediatR(cfg =>
            cfg.RegisterServicesFromAssemblyContaining<CreatePostCommand>());
    }
}