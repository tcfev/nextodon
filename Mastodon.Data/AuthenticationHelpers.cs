﻿namespace Mastodon.Data;

public static class AuthenticationHelpers
{
    public static async Task<Account> FindOrCreateAsync(this IMongoCollection<Account> account, string address, string publicKey)
    {
        publicKey = publicKey.ToLower();

        if (!address.StartsWith("0x", StringComparison.OrdinalIgnoreCase))
        {
            address = $"0x{address}";
        }

        address = address.ToLower();

        var now = DateTime.UtcNow;
        var filter = Builders<Data.Account>.Filter.Eq(x => x.Id, address);
        var update = Builders<Data.Account>.Update
            //.SetOnInsert(x => x.Id, id)
            .SetOnInsert(x => x.PublicKey, publicKey)
            .SetOnInsert(x => x.CreatedAt, now)
            .SetOnInsert(x => x.Username, null)
            .SetOnInsert(x => x.DisplayName, null)
            .SetOnInsert(x => x.Discoverable, null)
            .SetOnInsert(x => x.Fields, new List<Account.Field>())
            .Set(x => x.LoggedInAt, now);


        var result = await account.FindOneAndUpdateAsync(filter, update, new FindOneAndUpdateOptions<Data.Account, Data.Account> { IsUpsert = true, ReturnDocument = ReturnDocument.After });

        return result;
    }
}
