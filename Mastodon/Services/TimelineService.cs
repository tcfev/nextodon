using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using Mastodon.Client;
using Mastodon.Grpc;

namespace Mastodon.Services;

public sealed class TimelineService : Mastodon.Grpc.Timeline.TimelineBase
{
    private readonly MastodonClient _mastodon;
    //private readonly DataContext _db;
    private readonly ILogger<TimelineService> _logger;
    public TimelineService(ILogger<TimelineService> logger, MastodonClient mastodon/*, DataContext db*/)
    {
        _logger = logger;
        _mastodon = mastodon;
        //_db = db;
    }

    public override async Task<Grpc.Statuses> GetPublic(Empty request, ServerCallContext context)
    {
        _mastodon.SetDefaults(context);

        var result = await _mastodon.Timeline.GetPublicAsync();
        await result.WriteHeadersTo(context);

        return result.Data.ToGrpc();
    }

    public override async Task<Statuses> GetByTag(StringValue request, ServerCallContext context)
    {
        _mastodon.SetDefaults(context);

        var result = await _mastodon.Timeline.GetTagAsync(request.Value);
        return result.ToGrpc();
    }

    public override async Task<Statuses> GetHome(Empty request, ServerCallContext context)
    {
        _mastodon.SetDefaults(context);

        var result = await _mastodon.Timeline.GetHomeAsync();
        return result.ToGrpc();
    }

    public override async Task<Statuses> GetList(StringValue request, ServerCallContext context)
    {
        _mastodon.SetDefaults(context);

        var result = await _mastodon.Timeline.GetListAsync(request.Value);
        return result.ToGrpc();
    }

#pragma warning disable CS0809
    [Obsolete]
    public override async Task<Statuses> GetDirect(Empty request, ServerCallContext context)
    {
        _mastodon.SetDefaults(context);

        var result = await _mastodon.Timeline.GetDirectAsync();
        return result.ToGrpc();
    }
#pragma warning restore CS0809
}
