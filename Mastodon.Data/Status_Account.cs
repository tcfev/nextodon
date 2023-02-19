﻿namespace Mastodon.Data;

[BsonIgnoreExtraElements]
public sealed class Status_Account
{
    [BsonElement("_id")]
    [BsonId(IdGenerator = typeof(StringObjectIdGenerator))]
    [BsonRepresentation(BsonType.ObjectId)]
    [BsonRequired]
    public required string Id = default!;

    [BsonRequired]
    [BsonRepresentation(BsonType.ObjectId)]
    public required string StatusId;

    [BsonRequired]
    [BsonRepresentation(BsonType.ObjectId)]
    public required string AccountId;

    [BsonRequired]
    public bool Favorite;

    [BsonRequired]
    public bool Mute;

    [BsonRequired]
    public bool Pin;

    [BsonRequired]
    public bool Bookmark;
}